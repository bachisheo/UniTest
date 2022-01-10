using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Npgsql;

namespace University
{
    public class PgConnection
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

        public void Open()
        {
            Instance.Open();
        }
        public void Close()
        {
            Instance.Close();
        }
    }
}