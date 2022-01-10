using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using University.Forms;

namespace University
{
    public partial class TableViewForm : Form
    {
        public TableViewForm()
        {

            InitializeComponent();
           
            //todo init from file
            
            PgConnection.Open();
            var cmd = new NpgsqlCommand("select * from student;", PgConnection.Instance);
            DataTable dt = new DataTable("teacher");
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;

            //комбобоксы по таблице дисциплин
            var cmd1 = new NpgsqlCommand("select * from discipline;", PgConnection.Instance);
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
            b1.Text = "Change";
            b1.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(b1);
          

            // dataGridView1.Columns.AddRange(new DataGridViewColumn[] { new DataGridViewButtonColumn() });
            cmd.Dispose();
            cmd1.Dispose();
            PgConnection.Close();
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
               var a = ((DataTable)dataGridView1.DataSource).Rows;
               var b = a[0][1];
               //AddAndChange form = new AddAndChange(true, dataGridView1.Rows[e.RowIndex]);
               //form.ShowDialog();

            }


        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
