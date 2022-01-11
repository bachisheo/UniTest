using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University.Forms
{
    public partial class Study_statement : Form
    {
        private string _cmnd, _view_name = "student_view", _table_name = "student";
        private string formName = "Студенты";
        public Study_statement(int id)
        {
            InitializeComponent();
            Tools.FillDG(dataGridView1, "SELECT * FROM statement_header a1  inner JOIN study_statement_header a2 on a1.statement_header_pk = a2.study_statement_header_pk WHERE a2.teacher_pk = " + id + ";", "");

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Delete", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Change", "Изменить");
        }
        public void MyRefresh()
        {
            _view_name = "statement_header";
            Tools.FillDG(dataGridView1, "select * from statement_header; ", _view_name);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
  

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Delete", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Change", "Изменить");

            // dataGridView1.Columns.AddRange(new DataGridViewColumn[] { new DataGridViewButtonColumn() });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            rand.Next();
            var res = Tools.executeFunction(" select * from add_statement_header( "+ rand.Next().ToString() +
                                    ", "+rand.Next().ToString()+");");
            AddAndChange form = new AddAndChange(false, dataGridView1.DataSource as DataTable, res);
            form.ShowDialog();
            MyRefresh();
        }
    }
}
