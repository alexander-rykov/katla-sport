using System.Diagnostics;

namespace KatlaSport.DataAccess
{
    internal class DebugDatabaseLogger : IDatabaseLogger
    {
        public void LogDatabaseCall(string info)
        {
            Debug.WriteLine(string.Format("--- {0}", info));
        }
    }
}
