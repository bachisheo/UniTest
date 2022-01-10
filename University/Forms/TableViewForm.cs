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
           // dataGridView1.Columns.AddRange(new DataGridViewColumn[] { new DataGridViewButtonColumn() });
            cmd.Dispose();
            connect.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                MessageBox.Show("Ты уверен?");
            }
        }
    }
}
