using Npgsql;
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
    public partial class Bank_asks : Form
    {
        String name_tab;
        public Bank_asks(bool _is_bank, int id)
        {
            PgConnection.id = id;
            PgConnection.user_type = "teacher";
            InitializeComponent();
            if (_is_bank)
            {
                label1.Text = "Банк заданий";
                Tools.FillDG(dataGridView1, "SELECT * FROM task a1 inner JOIN topic a2 on a1.task_pk = a2.topic_pk inner JOIN discipline a3 on a3.discipline_pk = a2.topic_pk inner JOIN entry_in_study_statement a4 on a3.discipline_pk = a4.entry_in_study_statement_pk inner JOIN study_statement_header a5 on a5.study_statement_header_pk = a4.entry_in_study_statement_pk WHERE a5.teacher_pk =" +  id + ";", "task");
                name_tab = "task";
            }
            else

            {
                label1.Text = "Аттестации";
                Tools.FillDG(dataGridView1, "SELECT * FROM statement_header  a1  inner JOIN study_statement_header a2 on a1.statement_header_pk = a2.study_statement_header_pk WHERE a2.teacher_pk = " + id+";", "statement_header");
                name_tab = "statement_header";

            }

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Delete", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Change", "Изменить");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                var result = MessageBox.Show("Данные будут удалены безвозвратно. Вы уверены?", "Предупреждение",
                           MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    Tools.Execute("delete from " + name_tab + " where " + name_tab + "_pk = " + Tools.GetId(dataGridView1, e.RowIndex) + ";");
                    MyRefresh();
                }

            }
            else
                 if (dataGridView1.Columns[e.ColumnIndex].Name == "Change")
            {
                var add = new AddAndChange(true, dataGridView1.DataSource as DataTable,
                    Tools.GetId(dataGridView1, e.RowIndex));
                add.ShowDialog();
                MyRefresh();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        
    }

        public void MyRefresh()
        {
            Tools.FillDG(dataGridView1, "select * from " + name_tab + ";", name_tab);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
          

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Delete", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Change", "Изменить");

            // dataGridView1.Columns.AddRange(new DataGridViewColumn[] { new DataGridViewButtonColumn() });
        }
    }
}
