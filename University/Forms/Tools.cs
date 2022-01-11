using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using Npgsql;

namespace University
{
    public static class Tools
    {
        private static List<string> _stopWords = new List<string>(){  "_pk", "id" };

        private static Dictionary<string, string> headers = new Dictionary<string, string>()
        {
            { "firstname", "Имя" }, { "lastname", "Фамилия" }, { "patronymic", "Отчество" }, {"name", "Название"}, {"data", "Время"},
            {"discipline", "Предмет"},  {"number", "Номер"},  {"login", "Логин"},  {"password", "Пароль"}
        };

        public static void FillDG(DataGridView dgv, string sql_script, string table_name)
        {
            PgConnection.Open();
            var cmd = new NpgsqlCommand(sql_script, PgConnection.Instance);
            DataTable dt = new DataTable(table_name);
            dt.Load(cmd.ExecuteReader());
            FillDG(dgv, dt);
            cmd.Dispose();
            PgConnection.Close();
        }

        public static void FillDG(DataGridView dgv, DataTable dt)
        {
            dgv.DataSource = null;
            dgv.AllowUserToAddRows = false;
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.DataSource = dt;
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

        public static DataTable GetDataTableFromOneObj( string table_name, string param_name, string param_value)
        {
            var dt = GetDataTable("select * from " + table_name + " where " + param_name + " = " + param_value);
            dt.TableName = table_name;
            return dt;
        } 
        public static void Delete( string table_name, string param_name, string param_value)
        {
            Execute("delete from " + table_name + " where " + param_name + " = " + param_value);
        }

        public static DataTable GetDataTable(string script)
        {
            PgConnection.Open();
            var cmd1 = new NpgsqlCommand(script, PgConnection.Instance);
            DataTable dt1 = new DataTable();
            dt1.Load(cmd1.ExecuteReader());
            cmd1.Dispose();
            PgConnection.Close();
            return dt1;
        }

        public static int executeFunction(string script)
        {
            PgConnection.Open();
            var cmd1 = new NpgsqlCommand(script, PgConnection.Instance);
            var res = cmd1.ExecuteScalar();
            cmd1.Dispose();
            PgConnection.Close();
            return (int)res;
        }
    
        public static NpgsqlDataReader Execute(string script)
        {
            PgConnection.Open();
            var cmd1 = new NpgsqlCommand(script, PgConnection.Instance);
            var r = cmd1.ExecuteReader();
            cmd1.Dispose();
            PgConnection.Close();
            return r;
        }
        public static int GetId(DataGridView dgv, int entry_number)
        {
            var dt = dgv.DataSource as DataTable;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == "id" || dt.Columns[i].ColumnName == dt.TableName + "_pk");
                    return (int)dt.Rows[entry_number][i];

            }
            throw new Exception("Запись не существует!");
        }

    }
}