using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Npgsql;

namespace University
{
    public static class PgConnection
    {
        private static NpgsqlConnection _connect;
        public static NpgsqlConnection Instance
        {
            get
            {
                if (_connect == null)
                    _connect = new NpgsqlConnection(ResourceDB.connection_data);
                return _connect;
            }
        }

        public static void Open()
        {
            Instance.Open();
        }
        public static void Close()
        {
            Instance.Close();
        }
    }
}