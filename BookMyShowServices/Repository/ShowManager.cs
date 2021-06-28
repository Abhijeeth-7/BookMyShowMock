using Models.DataModels;
using Dapper;
using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repository
{
    public class ShowManager : IShowManager
    {
        private IDbConnection _dbConnection;
        public ShowManager(IDBContext context)
        {
            _dbConnection = context.Connection();
        }
        public async Task<List<Show>> GetShows(int movieId)
        {
            string sql = "select * from Show where MovieId = @id";
            var param = new { id = movieId };
            var shows = await _dbConnection.QueryAsync<Show>(sql, param);
            return shows.ToList();
        }
        public async Task<Show> GetShow(int showId)
        {
            string sql = "select * from Show where id = @id";
            var param = new { id = showId };
            return await _dbConnection.QueryFirstAsync<Show>(sql, param);
        }

        public async Task<List<Seat>> GetSeatingData(int Id)
        {
            string sql = "select SeatingData from Show as s inner join Seating as st on s.SeatingId = st.Id where st.Id=@showId";
            var param = new { showId = Id, };
            var seatingDataString = await _dbConnection.QueryAsync<string>(sql, param);
            string seatingDataJson = string.Join("", seatingDataString.TakeWhile(a=>true));

            IEnumerable<Seat> seatingData = JsonConvert.DeserializeObject<IEnumerable<Seat>>(
                seatingDataJson, 
                new CustomBooleanJsonConverter()
                );

            return seatingData.ToList();
        }
        public async Task<bool> UpdateSeatingData(int id, List<string> selectedSeatIds)
        {
            List<Seat> seatingData = await GetSeatingData(id);
            IEnumerable<Seat> selectedSeats = seatingData.Where(s => selectedSeatIds.Contains(s.Id));
            foreach(Seat seat in selectedSeats)
            {
                if (seat.IsAvailable == 0)
                {
                    return false;
                }
                seat.IsAvailable = 0;
            }

            string json = JsonConvert.SerializeObject(seatingData);
            var sql = "UPDATE Seating SET SeatingData = @seatingData WHERE ShowId = @showId";
            var param = new { showId = id, seatingData = json, };
            await _dbConnection.QueryAsync<Seating>(sql, param);
            return true;
        }
    }
}
public class CustomBooleanJsonConverter : JsonConverter<bool>
{
    public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
    }

    public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}