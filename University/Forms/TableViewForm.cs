using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using University.Forms;

namespace University
{
    public partial class TableViewForm : Form
    {
        private string _cmnd, _view_name = "student_view", _table_name = "student";

        public void MyRefresh()
        {
            Tools.FillDG(dataGridView1, "select * from " + _view_name + ";", _view_name);
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            var add = new AddAndChange( dataGridView1.DataSource as DataTable);
            add.ShowDialog();
       
           // Tools.Execute("select * from add_user( " + firstname + " , " + lastname + " , " + patronymic + ", " + login + ", " + password + " , student);");
            MyRefresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Delete":
                    {

                        var result = MessageBox.Show("Данные будут удалены безвозвратно. Вы уверены?", "Предупреждение",
                            MessageBoxButtons.OKCancel);
                        if (result == DialogResult.OK)
                        {
                            Tools.Execute("delete from "+ _table_name + " where " + _table_name + "_pk = " + Tools.GetId(dataGridView1, e.RowIndex));
                            MyRefresh();

                        }

                        break;
                    }
                case "Change":
                    {
                        // MessageBox.Show("Дада, сейчас?");
                        var add = new AddAndChange(true, dataGridView1.DataSource as DataTable,
                            Tools.GetId(dataGridView1, e.RowIndex));
                        add.ShowDialog();
                        MyRefresh();
                        break;
                    }

            }

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
