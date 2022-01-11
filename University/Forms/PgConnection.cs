using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Npgsql;

namespace University
{
    public static class PgConnection
    {
        public static string user_type;
        public static int id;
        private static bool _is_open = false;

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
            if (!_is_open)
            {
                Instance.Open();
                _is_open = true;
            }
        }
        public static void Close()
        {
            if (_is_open)
            {
                Instance.Close();
                _is_open = false;
            }
        }
    }
}