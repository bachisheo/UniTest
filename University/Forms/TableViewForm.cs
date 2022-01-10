using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
namespace University
{
    public partial class TableViewForm : Form
    {
        public TableViewForm()
        {

            InitializeComponent();
           
            //todo init from file
            //or localhost
            string server_addr = "192.168.100.21", port = "5432", db_name = "uni_04", pass = "0489";
            string connect_str = "Server=" + server_addr + ";Port=" + port + ";Database=" + db_name +
                                 ";User Id=postgres; password=" + pass + ";";
            var connect = new NpgsqlConnection(connect_str);
            connect.Open();
            var cmd = new NpgsqlCommand("select * from student;", connect);
            DataTable dt = new DataTable("teacher");
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            cmd.Dispose();
            connect.Close();
        }
    }
}
