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
            this.Text = "Авторизация";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String log = LoginBox.Text;
            String pas = PassBox.Text;
            DataTable dt1 = new DataTable();

            if (log.Length > 0)
            {
                PgConnection.Open();
                var cmd1 = new NpgsqlCommand("select password from student where login = '" + log + "';",
                    PgConnection.Instance);
                var res = cmd1.ExecuteReader();

                if (res.HasRows)
                {
                    dt1.Load(res);
                    cmd1.Dispose();
                    PgConnection.Close();
                    if (dt1.Rows[0][0].ToString() == pas)
                    {
                        PgConnection.id =
                            (int)Tools.GetDataTable("select student_pk from student where login = '" + log + "';")
                                .Rows[0][0];
                        PgConnection.user_type = "student";
                        Main_student_form form = new Main_student_form();
                        form.ShowDialog();
                    }
                }
                else
                {
                    res.Close();
                    PgConnection.Open();
                    var cmd2 = new NpgsqlCommand("select password from teacher where login = '" + log + "';",
                        PgConnection.Instance);
                    res = cmd2.ExecuteReader();
                    if (res.HasRows)
                    {
                        dt1.Load(res);
                        cmd2.Dispose();
                        PgConnection.Close();
                        if (dt1.Rows[0][0].ToString() == pas)
                        {
                            PgConnection.id =
                                (int)Tools.GetDataTable("select teacher_pk from teacher where login = '" + log + "';")
                                    .Rows[0][0];
                            PgConnection.user_type = "teacher";
                            Main_teacher_form form = new Main_teacher_form();
                            form.ShowDialog();
                        }
                    }
                    else
                    {

                        res.Close();

                        PgConnection.Open();
                        var cmd3 = new NpgsqlCommand("select password from admin where login = '" + log + "';",
                            PgConnection.Instance);
                        res = cmd3.ExecuteReader();
                        if (res.HasRows)
                        {
                            dt1.Load(res);
                            cmd3.Dispose();
                            PgConnection.Close();
                            if (dt1.Rows[0][0].ToString() == pas)
                            {
                                PgConnection.id =
                                    (int)Tools.GetDataTable("select admin_pk from admin where login = '" + log + "';")
                                        .Rows[0][0];
                                PgConnection.user_type = "admin";
                                Main_admin_form form = new Main_admin_form(this);
                                form.ShowDialog();
                            }
                        }

                        cmd3.Dispose();
                        PgConnection.Close();
                        MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OKCancel);
                    }
                }
            }

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

        private void Main_first_inpute_form_Load(object sender, EventArgs e)
        {

        }
    }
}
