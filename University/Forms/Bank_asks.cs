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
        public Bank_asks(bool flag, int id)
        {
            InitializeComponent();
            if (flag)
            {
                label1.Text = "Банк заданий";

                // Tools.FillDG(dataGridView1, "SELECT * FROM task","");

                Tools.FillDG(dataGridView1, "SELECT * FROM task a1 inner JOIN topic a2 on a1.task_pk = a2.topic_pk inner JOIN discipline a3 on a3.discipline_pk = a2.topic_pk inner JOIN entry_in_study_statement a4 on a3.discipline_pk = a4.entry_in_study_statement_pk inner JOIN study_statement_header a5 on a5.study_statement_header_pk = a4.entry_in_study_statement_pk WHERE a5.teacher_pk =" +  id+";", "");
            }
            else

            {
                label1.Text = "Аттестации";
                Tools.FillDG(dataGridView1, "SELECT * FROM statement_header a1  inner JOIN study_statement_header a2 on a1.statement_header_pk = a2.study_statement_header_pk WHERE a2.teacher_pk = "+id+";", "");


            }

            //кнопки
            Tools.AddButtonInGrid(dataGridView1, "Delete", "Удалить");
            Tools.AddButtonInGrid(dataGridView1, "Change", "Изменить");
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
                //AddAndChange form = new AddAndChange(true, b.ToString());
               // form.ShowDialog();

            }


        }
    }
}
