using SQLite;

namespace ContactBook
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

