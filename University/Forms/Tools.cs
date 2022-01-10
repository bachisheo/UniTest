using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace University
{
    public static class Tools
    {
        private static List<string> _stopWords = new List<string>(){ "login", "_pk", "password" };

        private static Dictionary<string, string> headers = new Dictionary<string, string>()
        {
            { "firstname", "Имя" }, { "lastname", "Фамилия" }, { "patronymic", "Отчество" }, {"name", "Название"}, {"data", "Время"},
            {"discipline", "Предмет"},  {"number", "Номер"}
        };
        public static void FillDG(DataGridView dgv, string sql_script, string name)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            PgConnection.Open();
            var cmd = new NpgsqlCommand(sql_script, PgConnection.Instance);
            DataTable dt = new DataTable(name);
            dt.Load(cmd.ExecuteReader());
            dgv.DataSource = dt;
            cmd.Dispose();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string _h;
                if (headers.TryGetValue(dt.Columns[i].ColumnName, out _h))
                    dgv.Columns[i].HeaderText = _h;
                foreach (var s_word in _stopWords)
                {
                    if (dt.Columns[i].ColumnName.Contains(s_word))
                        dgv.Columns[i].Visible = false;
                }
            }
            cmd.Dispose();
            PgConnection.Close();
        }

        public static DataGridViewButtonColumn AddButtonInGrid(DataGridView dgv, string name, string textForUser)
        {
            DataGridViewButtonColumn b = new DataGridViewButtonColumn();
            b.Name = name;
            b.Text = textForUser;
            b.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(b);
            return b;
        }

        public static DataTable GetDataTable(string script, string name = "")
        {
            PgConnection.Open();
            var cmd1 = new NpgsqlCommand(script, PgConnection.Instance);
            DataTable dt1 = new DataTable(name);
            dt1.Load(cmd1.ExecuteReader());
            cmd1.Dispose();
            PgConnection.Close();
            return dt1;

        }
    }
}