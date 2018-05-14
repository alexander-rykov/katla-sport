namespace KatlaSport.DataAccess
{
    /// <summary>
    /// Represents a database logger that logs all database queries.
    /// </summary>
    public interface IDatabaseLogger
    {
        void LogDatabaseCall(string info);
    }
}
