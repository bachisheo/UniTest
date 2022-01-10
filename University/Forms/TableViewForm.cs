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
        private string _cmnd , _name = "student_view";

        public void MyRefresh()
        {
            Tools.FillDG(dataGridView1, "select * from " + _name + ";", _name);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            //комбобоксы по таблице дисциплин
            DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
            c.DataSource = Tools.GetDataTable("select * from discipline;");
            c.HeaderText = "Предмет";
            c.DisplayMember = "name";
            dataGridView1.Columns.Add(c);

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Delete", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Change", "Изменить");

            // dataGridView1.Columns.AddRange(new DataGridViewColumn[] { new DataGridViewButtonColumn() });
        }
        public TableViewForm()
        {
            InitializeComponent();
            MyRefresh();
        }

        private int GetId(DataGridView dgv, int entry_number)
        {
            var dt = dgv.DataSource as DataTable;

            for (int i = 0; i <  dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == "id")
                    return (int)dt.Rows[entry_number][i];
            }
            throw new Exception("Запись не существует!");
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
              // MessageBox.Show("Дада, сейчас?");
               var add = new AddAndChange(true, dataGridView1.DataSource as DataTable, GetId(dataGridView1, e.RowIndex));
               add.ShowDialog();
               MyRefresh();
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
