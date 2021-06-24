using Models.DataModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Data
{
    public class seedData
    {
        private static IDbConnection _dbConnection;
        public static async void Initialize(IDBContext context)
        {
            _dbConnection = context.Connection();
            _dbConnection.Open();
            await seedData.InsertMovies();
            await seedData.InsertTheates();
            await seedData.InsertShows();
            await seedData.InsertSeatingData();
        }
        
        public static async Task InsertMovies()
        {
            await _dbConnection.ExecuteAsync("DELETE FROM [dbo].[Movie]");
            List<Movie> movies = new List<Movie> {
                new Movie
                {
                    Id = 1,
                    Title = "Wonder Woman",
                    Description = "Wonder Woman finds herself battling two opponents, Maxwell Lord, a shrewd entrepreneur, and Barbara Minerva, a friend-turned-foe. Meanwhile, she also ends up crossing paths with her love interest.",
                    Genre = "2",
                    Duration = new TimeSpan(02,31,00)
                },
                new Movie
                {
                    Id = 2,
                    Title = "The pursuit of Happiness",
                    Description = "Chris's professional failures, his wife decides to separate, leaving him financially broke with an unpaid internship in a brokerage firm and his son's custody to deal with.",
                    Genre = "3",
                    Duration = new TimeSpan(01,57,00)
                },
                new Movie
                {
                    Id = 3,
                    Title = "Tenet",   
                    Description = "When a few objects that can be manipulated and used as weapons in the future fall into the wrong hands, a CIA operative, known as the Protagonist, must save the world.",
                    Genre = "5",
                    Duration = new TimeSpan(02,30,00)
                },
                new Movie
                {
                    Id = 4,
                    Title = "Snowden",
                    Description = "Disillusioned with the intelligence community, top contractor Edward Snowden leaves his job at the National Security Agency. He now knows that a virtual mountain of data is being assembled to track all forms of digital communication",
                    Genre = "2",
                    Duration = new TimeSpan(02,14,00)
                },
                new Movie
                {
                    Id = 5,
                    Title = "knock Knock",
                    Description = "Evan, a dedicated father and husband, opens his house to Genesis and Bel, two women who claim to be stranded....",
                    Genre = "4",
                    Duration = new TimeSpan(01,39,00)
                },
            };
            foreach(Movie movie in movies)
            {

                string sql = "INSERT INTO[dbo].[Movie]" +
                            "([Id],[Title],[Description],[Genre],[Duration])" +
                            "VALUES(" +
                                "@Id," +
                                "@Title," +
                                "@Description," +
                                "@Genre," +
                                "@Duration" +
                                ")";
                var param = new Movie
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Genre = movie.Genre,
                    Duration = movie.Duration
                };
                await _dbConnection.ExecuteAsync(sql,param);
            }
        }

        public static async Task InsertShows() {
            await _dbConnection.ExecuteAsync("DELETE FROM [dbo].[Show]");
            List<Show> shows = new List<Show>
            {

                new Show{
                    Id = 1,
                    TheaterId = 1,
                    MovieId = 1,
                    StartTime = new TimeSpan(9,0,00),
                    EndTime = new TimeSpan(11,31,00),
                    SeatingId = 1
                },
                new Show{
                    Id = 2,
                    TheaterId = 1,
                    MovieId = 1,
                    StartTime = new TimeSpan(14,32,00),
                    EndTime = new TimeSpan(17,3,00),
                    SeatingId = 2
                },
                new Show{
                    Id = 3,
                    TheaterId = 1,
                    MovieId = 1,
                    StartTime = new TimeSpan(20,4,00),
                    EndTime = new TimeSpan(22,35,00),
                    SeatingId = 3
                },
                new Show{
                    Id = 4,
                    TheaterId = 2,
                    MovieId = 1,
                    StartTime = new TimeSpan(9,30,00),
                    EndTime = new TimeSpan(12,1,00),
                    SeatingId = 4
                },
                new Show{
                    Id = 5,
                    TheaterId = 2,
                    MovieId = 1,
                    StartTime = new TimeSpan(15,2,00),
                    EndTime = new TimeSpan(17,33,00),
                    SeatingId = 5
                },
                new Show{
                    Id = 6,
                    TheaterId = 2,
                    MovieId = 1,
                    StartTime = new TimeSpan(20,34,00),
                    EndTime = new TimeSpan(23,5,00),
                    SeatingId = 6
                },
                new Show{
                    Id = 7,
                    TheaterId = 3,
                    MovieId = 1,
                    StartTime = new TimeSpan(9,45,00),
                    EndTime = new TimeSpan(12,16,00),
                    SeatingId = 7
                },
                new Show{
                    Id = 8,
                    TheaterId = 3,
                    MovieId = 1,
                    StartTime = new TimeSpan(15,17,00),
                    EndTime = new TimeSpan(17,48,00),
                    SeatingId = 8
                },
                new Show{
                    Id = 45,
                    TheaterId = 3,
                    MovieId = 1,
                    StartTime = new TimeSpan(20,49,00),
                    EndTime = new TimeSpan(23,20,00),
                    SeatingId = 45
                },
                new Show{
                    Id = 9,
                    TheaterId = 1,
                    MovieId = 3,
                    StartTime = new TimeSpan(10,45,00),
                    EndTime = new TimeSpan(13,15,00),
                    SeatingId = 9
                },
                new Show{
                    Id = 10,
                    TheaterId = 1,
                    MovieId = 3,
                    StartTime = new TimeSpan(16,15,00),
                    EndTime = new TimeSpan(18,45,00),
                    SeatingId = 10
                },
                new Show{
                    Id = 11,
                    TheaterId = 1,
                    MovieId = 3,
                    StartTime = new TimeSpan(21,45,00),
                    EndTime = new TimeSpan(00,15,00),
                    SeatingId = 11
                },
                new Show{
                    Id = 12,
                    TheaterId = 2,
                    MovieId = 3,
                    StartTime = new TimeSpan(10,15,00),
                    EndTime = new TimeSpan(12,45,00),
                    SeatingId = 12
                },
                new Show{
                    Id = 13,
                    TheaterId = 2,
                    MovieId = 3,
                    StartTime = new TimeSpan(15,45,00),
                    EndTime = new TimeSpan(18,15,00),
                    SeatingId = 13
                },
                new Show{
                    Id = 14,
                    TheaterId = 2,
                    MovieId = 3,
                    StartTime = new TimeSpan(21,15,00),
                    EndTime = new TimeSpan(23,45,00),
                    SeatingId = 14
                },
                new Show{
                    Id = 15,
                    TheaterId = 3,
                    MovieId = 3,
                    StartTime = new TimeSpan(10,30,00),
                    EndTime = new TimeSpan(13,0,00),
                    SeatingId = 15
                },
                new Show{
                    Id = 16,
                    TheaterId = 3,
                    MovieId = 3,
                    StartTime = new TimeSpan(16,0,00),
                    EndTime = new TimeSpan(18,30,00),
                    SeatingId = 16
                },
                new Show{
                    Id = 17,
                    TheaterId = 3,
                    MovieId = 3,
                    StartTime = new TimeSpan(21,30,00),
                    EndTime = new TimeSpan(0,0,00),
                    SeatingId = 17
                },
                new Show{
                    Id = 18,
                    TheaterId = 1,
                    MovieId = 2,
                    StartTime = new TimeSpan(11,30,00),
                    EndTime = new TimeSpan(13,27,00),
                    SeatingId = 18
                },
                new Show{
                    Id = 19,
                    TheaterId = 1,
                    MovieId = 2,
                    StartTime = new TimeSpan(15,54,00),
                    EndTime = new TimeSpan(17,51,00),
                    SeatingId = 19
                },
                new Show{
                    Id = 20,
                    TheaterId = 1,
                    MovieId = 2,
                    StartTime = new TimeSpan(19,18,00),
                    EndTime = new TimeSpan(21,15,00),
                    SeatingId = 20
                },
                new Show{
                    Id = 21,
                    TheaterId = 2,
                    MovieId = 2,
                    StartTime = new TimeSpan(11,0,00),
                    EndTime = new TimeSpan(12,57,00),
                    SeatingId = 21
                },
                new Show{
                    Id = 22,
                    TheaterId = 2,
                    MovieId = 2,
                    StartTime = new TimeSpan(14,24,00),
                    EndTime = new TimeSpan(16,21,00),
                    SeatingId = 22
                },
                new Show{
                    Id = 23,
                    TheaterId = 2,
                    MovieId = 2,
                    StartTime = new TimeSpan(18,48,00),
                    EndTime = new TimeSpan(20,45,00),
                    SeatingId = 23
                },
                new Show{
                    Id = 24,
                    TheaterId = 3,
                    MovieId = 2,
                    StartTime = new TimeSpan(10,0,00),
                    EndTime = new TimeSpan(11,57,00),
                    SeatingId = 24
                },
                new Show{
                    Id = 25,
                    TheaterId = 3,
                    MovieId = 2,
                    StartTime = new TimeSpan(13,24,00),
                    EndTime = new TimeSpan(15,21,00),
                    SeatingId = 25
                },
                new Show{
                    Id = 26,
                    TheaterId = 3,
                    MovieId = 2,
                    StartTime = new TimeSpan(17,48,00),
                    EndTime = new TimeSpan(19,45,00),
                    SeatingId = 26
                },
                new Show{
                    Id = 27,
                    TheaterId = 1,
                    MovieId = 4,
                    StartTime = new TimeSpan(9,45,00),
                    EndTime = new TimeSpan(11,59,00),
                    SeatingId = 27
                },
                new Show{
                    Id = 28,
                    TheaterId = 1,
                    MovieId = 4,
                    StartTime = new TimeSpan(14,43,00),
                    EndTime = new TimeSpan(16,57,00),
                    SeatingId = 28
                },
                new Show{
                    Id = 29,
                    TheaterId = 1,
                    MovieId = 4,
                    StartTime = new TimeSpan(19,41,00),
                    EndTime = new TimeSpan(21,55,00),
                    SeatingId = 29
                },
                new Show{
                    Id = 30,
                    TheaterId = 2,
                    MovieId = 4,
                    StartTime = new TimeSpan(9,0,00),
                    EndTime = new TimeSpan(11,14,00),
                    SeatingId = 30
                },
                new Show{
                    Id = 31,
                    TheaterId = 2,
                    MovieId = 4,
                    StartTime = new TimeSpan(13,58,00),
                    EndTime = new TimeSpan(16,12,00),
                    SeatingId = 31
                },
                new Show{
                    Id = 32,
                    TheaterId = 2,
                    MovieId = 4,
                    StartTime = new TimeSpan(18,56,00),
                    EndTime = new TimeSpan(21,10,00),
                    SeatingId = 32
                },
                new Show{
                    Id = 33,
                    TheaterId = 3,
                    MovieId = 4,
                    StartTime = new TimeSpan(10,0,00),
                    EndTime = new TimeSpan(12,14,00),
                    SeatingId = 33
                },
                new Show{
                    Id = 34,
                    TheaterId = 3,
                    MovieId = 4,
                    StartTime = new TimeSpan(14,58,00),
                    EndTime = new TimeSpan(17,12,00),
                    SeatingId = 34
                },
                new Show{
                    Id = 35,
                    TheaterId = 3,
                    MovieId = 4,
                    StartTime = new TimeSpan(19,56,00),
                    EndTime = new TimeSpan(22,10,00),
                    SeatingId = 35
                },
                new Show{
                    Id = 36,
                    TheaterId = 1,
                    MovieId = 5,
                    StartTime = new TimeSpan(10,15,00),
                    EndTime = new TimeSpan(11,54,00),
                    SeatingId = 36
                },
                new Show{
                    Id = 37,
                    TheaterId = 1,
                    MovieId = 5,
                    StartTime = new TimeSpan(13,3,00),
                    EndTime = new TimeSpan(14,42,00),
                    SeatingId = 37
                },
                new Show{
                    Id = 38,
                    TheaterId = 1,
                    MovieId = 5,
                    StartTime = new TimeSpan(16,51,00),
                    EndTime = new TimeSpan(18,30,00),
                    SeatingId = 38
                },
                new Show{
                    Id = 39,
                    TheaterId = 2,
                    MovieId = 5,
                    StartTime = new TimeSpan(11,15,00),
                    EndTime = new TimeSpan(12,54,00),
                    SeatingId = 39
                },
                new Show{
                    Id = 40,
                    TheaterId = 2,
                    MovieId = 5,
                    StartTime = new TimeSpan(14,3,00),
                    EndTime = new TimeSpan(15,42,00),
                    SeatingId = 40
                },
                new Show{
                    Id = 41,
                    TheaterId = 2,
                    MovieId = 5,
                    StartTime = new TimeSpan(17,51,00),
                    EndTime = new TimeSpan(19,30,00),
                    SeatingId = 41
                },
                new Show{
                    Id = 42,
                    TheaterId = 3,
                    MovieId = 5,
                    StartTime = new TimeSpan(10,35,00),
                    EndTime = new TimeSpan(12,14,00),
                    SeatingId = 42
                },
                new Show{
                    Id = 43,
                    TheaterId = 3,
                    MovieId = 5,
                    StartTime = new TimeSpan(14,23,00),
                    EndTime = new TimeSpan(16,2,00),
                    SeatingId = 43
                },
                new Show{
                    Id = 44,
                    TheaterId = 3,
                    MovieId = 5,
                    StartTime = new TimeSpan(18,11,00),
                    EndTime = new TimeSpan(19,50,00),
                    SeatingId = 44
                },
            };
            foreach(Show show in shows)
            {
                string sql = "INSERT INTO [dbo].[Show] " +
                    "([Id],[TheaterId],[MovieId],[StartTime],[EndTime],[SeatingId])" +
                    "VALUES(" +
                    "@Id," +
                    "@TheaterId," +
                    "@MovieId,"+
                    "@StartTime," +
                    "@EndTime," +
                    "@SeatingId" +
                    ")";
                var param = new Show
                {
                    Id = show.Id,
                    TheaterId = show.TheaterId,
                    MovieId = show.MovieId,
                    StartTime = show.StartTime,
                    EndTime = show.EndTime,
                    SeatingId = show.SeatingId
                };
                await _dbConnection.ExecuteAsync(sql, param);
            }
        }
        public static async Task InsertTheates()
        {
            await _dbConnection.ExecuteAsync("DELETE FROM [dbo].[Theater]");
            List<Theater> theaters = new List<Theater>
            {
                new Theater{
                    Id=1,
                    TheaterName="INOX",
                    TotalSeats=100,
                    Price=200,
                },
                new Theater{
                    Id=2,
                    TheaterName="PVR",
                    TotalSeats=100,
                    Price=225,
                },
                new Theater{
                    Id=3,
                    TheaterName="IMAX",
                    TotalSeats=100,
                    Price=250,
                }
            };
            foreach (Theater theater in theaters)
            {
                string sql = "INSERT INTO[dbo].[Theater] " +
                    "([Id],[TheaterName],[TotalSeats],[price]) " +
                    "VALUES(" +
                    "@Id," +
                    "@TheaterName," +
                    "@TotalSeats," +
                    "@Price" +
                    ")";
                var param = new Theater
                {
                    Id = theater.Id,
                    TheaterName = theater.TheaterName,
                    TotalSeats = theater.TotalSeats,
                    Price = theater.Price
                };
                await _dbConnection.ExecuteAsync(sql, param);
            }
        }
        public static async Task InsertSeatingData() {
            var seatingData = @"[{ ""Id"":""1A"",""IsAvailable"":""1""},{ ""Id"":""1B"",""IsAvailable"":""1""},{ ""Id"":""1C"",""IsAvailable"":""1""},{ ""Id"":""1D"",""IsAvailable"":""1""},{ ""Id"":""1E"",""IsAvailable"":""1""},{ ""Id"":""1F"",""IsAvailable"":""1""},{ ""Id"":""1G"",""IsAvailable"":""1""},{ ""Id"":""1H"",""IsAvailable"":""1""},{ ""Id"":""1I"",""IsAvailable"":""1""},{ ""Id"":""1J"",""IsAvailable"":""1""},{ ""Id"":""2A"",""IsAvailable"":""1""},{ ""Id"":""2B"",""IsAvailable"":""1""},{ ""Id"":""2C"",""IsAvailable"":""1""},{ ""Id"":""2D"",""IsAvailable"":""1""},{ ""Id"":""2E"",""IsAvailable"":""1""},{ ""Id"":""2F"",""IsAvailable"":""1""},{ ""Id"":""2G"",""IsAvailable"":""1""},{ ""Id"":""2H"",""IsAvailable"":""1""},{ ""Id"":""2I"",""IsAvailable"":""1""},{ ""Id"":""2J"",""IsAvailable"":""1""},{ ""Id"":""3A"",""IsAvailable"":""1""},{ ""Id"":""3B"",""IsAvailable"":""1""},{ ""Id"":""3C"",""IsAvailable"":""1""},{ ""Id"":""3D"",""IsAvailable"":""1""},{ ""Id"":""3E"",""IsAvailable"":""1""},{ ""Id"":""3F"",""IsAvailable"":""1""},{ ""Id"":""3G"",""IsAvailable"":""1""},{ ""Id"":""3H"",""IsAvailable"":""1""},{ ""Id"":""3I"",""IsAvailable"":""1""},{ ""Id"":""3J"",""IsAvailable"":""1""},{ ""Id"":""4A"",""IsAvailable"":""1""},{ ""Id"":""4B"",""IsAvailable"":""1""},{ ""Id"":""4C"",""IsAvailable"":""1""},{ ""Id"":""4D"",""IsAvailable"":""1""},{ ""Id"":""4E"",""IsAvailable"":""1""},{ ""Id"":""4F"",""IsAvailable"":""1""},{ ""Id"":""4G"",""IsAvailable"":""1""},{ ""Id"":""4H"",""IsAvailable"":""1""},{ ""Id"":""4I"",""IsAvailable"":""1""},{ ""Id"":""4J"",""IsAvailable"":""1""},{ ""Id"":""5A"",""IsAvailable"":""1""},{ ""Id"":""5B"",""IsAvailable"":""1""},{ ""Id"":""5C"",""IsAvailable"":""1""},{ ""Id"":""5D"",""IsAvailable"":""1""},{ ""Id"":""5E"",""IsAvailable"":""1""},{ ""Id"":""5F"",""IsAvailable"":""1""},{ ""Id"":""5G"",""IsAvailable"":""1""},{ ""Id"":""5H"",""IsAvailable"":""1""},{ ""Id"":""5I"",""IsAvailable"":""1""},{ ""Id"":""5J"",""IsAvailable"":""1""},{ ""Id"":""6A"",""IsAvailable"":""1""},{ ""Id"":""6B"",""IsAvailable"":""1""},{ ""Id"":""6C"",""IsAvailable"":""1""},{ ""Id"":""6D"",""IsAvailable"":""1""},{ ""Id"":""6E"",""IsAvailable"":""1""},{ ""Id"":""6F"",""IsAvailable"":""1""},{ ""Id"":""6G"",""IsAvailable"":""1""},{ ""Id"":""6H"",""IsAvailable"":""1""},{ ""Id"":""6I"",""IsAvailable"":""1""},{ ""Id"":""6J"",""IsAvailable"":""1""},{ ""Id"":""7A"",""IsAvailable"":""1""},{ ""Id"":""7B"",""IsAvailable"":""1""},{ ""Id"":""7C"",""IsAvailable"":""1""},{ ""Id"":""7D"",""IsAvailable"":""1""},{ ""Id"":""7E"",""IsAvailable"":""1""},{ ""Id"":""7F"",""IsAvailable"":""1""},{ ""Id"":""7G"",""IsAvailable"":""1""},{ ""Id"":""7H"",""IsAvailable"":""1""},{ ""Id"":""7I"",""IsAvailable"":""1""},{ ""Id"":""7J"",""IsAvailable"":""1""},{ ""Id"":""8A"",""IsAvailable"":""1""},{ ""Id"":""8B"",""IsAvailable"":""1""},{ ""Id"":""8C"",""IsAvailable"":""1""},{ ""Id"":""8D"",""IsAvailable"":""1""},{ ""Id"":""8E"",""IsAvailable"":""1""},{ ""Id"":""8F"",""IsAvailable"":""1""},{ ""Id"":""8G"",""IsAvailable"":""1""},{ ""Id"":""8H"",""IsAvailable"":""1""},{ ""Id"":""8I"",""IsAvailable"":""1""},{ ""Id"":""8J"",""IsAvailable"":""1""},{ ""Id"":""9A"",""IsAvailable"":""1""},{ ""Id"":""9B"",""IsAvailable"":""1""},{ ""Id"":""9C"",""IsAvailable"":""1""},{ ""Id"":""9D"",""IsAvailable"":""1""},{ ""Id"":""9E"",""IsAvailable"":""1""},{ ""Id"":""9F"",""IsAvailable"":""1""},{ ""Id"":""9G"",""IsAvailable"":""1""},{ ""Id"":""9H"",""IsAvailable"":""1""},{ ""Id"":""9I"",""IsAvailable"":""1""},{ ""Id"":""9J"",""IsAvailable"":""1""},{ ""Id"":""10A"",""IsAvailable"":""1""},{ ""Id"":""10B"",""IsAvailable"":""1""},{ ""Id"":""10C"",""IsAvailable"":""1""},{ ""Id"":""10D"",""IsAvailable"":""1""},{ ""Id"":""10E"",""IsAvailable"":""1""},{ ""Id"":""10F"",""IsAvailable"":""1""},{ ""Id"":""10G"",""IsAvailable"":""1""},{ ""Id"":""10H"",""IsAvailable"":""1""},{ ""Id"":""10I"",""IsAvailable"":""1""},{ ""Id"":""10J"",""IsAvailable"":""1""}]";
            List<Seating> seatings = new List<Seating> {
                new Seating{
                    Id = 1,
                    ShowId = 1,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 2,
                    ShowId = 2,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 3,
                    ShowId = 3,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 4,
                    ShowId = 4,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 5,
                    ShowId = 5,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 6,
                    ShowId = 6,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 7,
                    ShowId = 7,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 8,
                    ShowId = 8,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 9,
                    ShowId = 9,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 10,
                    ShowId = 10,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 11,
                    ShowId = 11,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 12,
                    ShowId = 12,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 13,
                    ShowId = 13,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 14,
                    ShowId = 14,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 15,
                    ShowId = 15,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 16,
                    ShowId = 16,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 17,
                    ShowId = 17,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 18,
                    ShowId = 18,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 19,
                    ShowId = 19,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 20,
                    ShowId = 20,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 21,
                    ShowId = 21,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 22,
                    ShowId = 22,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 23,
                    ShowId = 23,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 24,
                    ShowId = 24,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 25,
                    ShowId = 25,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 26,
                    ShowId = 26,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 27,
                    ShowId = 27,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 28,
                    ShowId = 28,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 29,
                    ShowId = 29,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 30,
                    ShowId = 30,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 31,
                    ShowId = 31,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 32,
                    ShowId = 32,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 33,
                    ShowId = 33,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 34,
                    ShowId = 34,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 35,
                    ShowId = 35,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 36,
                    ShowId = 36,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 37,
                    ShowId = 37,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 38,
                    ShowId = 38,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 39,
                    ShowId = 39,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 40,
                    ShowId = 40,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 41,
                    ShowId = 41,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 42,
                    ShowId = 42,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 43,
                    ShowId = 43,
                    TheaterId = 2,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 44,
                    ShowId = 44,
                    TheaterId = 3,
                    SeatingData = seatingData
                },
                new Seating{
                    Id = 45,
                    ShowId = 45,
                    TheaterId = 1,
                    SeatingData = seatingData
                },
            };
            foreach(Seating seating in seatings)
            {
                string sql = "INSERT INTO [dbo].[Seating]" +
                            "([Id],[ShowId],[TheaterId],[SeatingData])" +
                            "VALUES(" +
                                "@Id," +
                                "@ShowId," +
                                "@TheaterId," +
                                "@SeatingData" +
                            ")";
                var param = new Seating
                {
                    Id = seating.Id,
                    ShowId = seating.ShowId,
                    TheaterId = seating.TheaterId,
                    SeatingData = seating.SeatingData
                };
                await _dbConnection.ExecuteAsync(sql, param);
            }

        }
    }
}
