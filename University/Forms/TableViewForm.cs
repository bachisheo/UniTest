using System;
using System.Collections.Generic;
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

            //комбобоксы по таблице дисциплин
            var cmd1 = new NpgsqlCommand("select * from discipline;", connect);
            DataTable dt1 = new DataTable("discipline");
            dt1.Load(cmd1.ExecuteReader());

            DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
            c.DataSource = dt1;
            c.HeaderText = "Предмет";
            c.DisplayMember = "name";
             dataGridView1.Columns.Add(c);

            //кнопки
            DataGridViewButtonColumn b = new DataGridViewButtonColumn();
            b.Name = "Delete";
            b.Text = "Delete";
            b.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(b);

            DataGridViewButtonColumn b1 = new DataGridViewButtonColumn();
            b1.Name = "Change";
            b1.Text = "Chenge";
            b1.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(b1);
          

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
            else
                 if (dataGridView1.Columns[e.ColumnIndex].Name == "Change")
            {
                MessageBox.Show("Дада, сейчас?");
            }


        }

        



    }
}
