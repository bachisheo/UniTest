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
            Tools.FillDG(dataGridView1, "select * from student;", "teacher");
            
            //комбобоксы по таблице дисциплин
            DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
            c.DataSource = Tools.GetDataTable("select * from discipline;", "discipline");
            c.HeaderText = "Предмет";
            c.DisplayMember = "name";
             dataGridView1.Columns.Add(c);

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Delete", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Change", "Изменить");

            // dataGridView1.Columns.AddRange(new DataGridViewColumn[] { new DataGridViewButtonColumn() });
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
               AddAndChange form = new AddAndChange(true, dataGridView1.Rows[e.RowIndex]);
               form.ShowDialog();

            }


        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
