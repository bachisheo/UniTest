using System;
using System.Data;
using System.IO;
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
            var connect = new NpgsqlConnection(ResourceDB.connection_data);
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
