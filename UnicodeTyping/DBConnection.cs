using System.Data.SqlClient;
using System.Data.SQLite;
using System.Configuration;

namespace UnicodeTyping
{
    class DBConnection
    {
        public SQLiteConnection cn = new SQLiteConnection("Data Source=unicodetyping.db");
    }
}
