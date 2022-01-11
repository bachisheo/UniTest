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
    public partial class Main_first_inpute_form : Form
    {
        public Main_first_inpute_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String log = LoginBox.Text;
            String pas = PassBox.Text;

            /*
            PgConnection.Open();
            var cmd1 = new NpgsqlCommand("select password from student where login = " + log + ";", PgConnection.Instance);
            cmd1.Connection = PgConnection.Instance;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select password from student where login = " + log + ";";
            NpgsqlDataReader dr = cmd1.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);

            
            }
            cmd1.Dispose();
            PgConnection.Close();
            */
            /*    
                PgConnection.Open();
                var cmd1 = new NpgsqlCommand("select password from student where login = "+log+";", PgConnection.Instance);



                DataTable dt1 = new DataTable();



                dt1.Load(cmd1.ExecuteReader());
               if (dt1.Select("Colum1=" + pas) != null)
                {
                    Main_student_form form = new Main_student_form();
                    form.ShowDialog();
                }
                cmd1.Dispose();

                var cmd2 = new NpgsqlCommand("select password from  teacher where login = " + log + ";", PgConnection.Instance);
                DataTable dt2 = new DataTable();

                dt2.Load(cmd2.ExecuteReader());


                         if (dt2.Select("Colum1=" + pas) != null)
                {
                    Main_teacher_form form = new Main_teacher_form();
                    form.ShowDialog();
                }

                  cmd2.Dispose();
    var cmd3 = new NpgsqlCommand("select password from admin where login = " + log + ";", PgConnection.Instance);
                DataTable dt3 = new DataTable();
                dt3.Load(cmd3.ExecuteReader());


                        if (dt3.Select("Colum1=" + pas) != null)
                {
                    Main_admin_form form = new Main_admin_form(this);
                    form.ShowDialog();
                }



                cmd3.Dispose();
                PgConnection.Close();

                */
            if (LoginBox.Text == "1")
            {
               // this.Visible = false;
                Main_admin_form form = new Main_admin_form(this);
                form.ShowDialog();
            }
            else
                 if (LoginBox.Text == "2")
            {
                Main_student_form form = new Main_student_form();
                form.ShowDialog();
            }
            else
            {
                Main_teacher_form form = new Main_teacher_form();
                form.ShowDialog();
            }
        }
    }
}
