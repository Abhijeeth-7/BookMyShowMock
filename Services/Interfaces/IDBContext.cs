using System.Data;

namespace Services.Interfaces
{
    public interface IDBContext
    {
        public IDbConnection Connection();
    }
}
