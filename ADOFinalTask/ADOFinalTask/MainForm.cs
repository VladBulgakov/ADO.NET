using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ADOFinalTask
{
    public partial class MainForm : Form
    {
        private string connectionString;

        List<TableName> tableNames = new List<TableName>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonConnectDB_Click(object sender, EventArgs e)
        {
            connectionString = $@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog={textBoxDBName.Text};Data Source={textBoxServerAddr.Text}";
            try
            {
                if (sqlConnection1.State == ConnectionState.Open) sqlConnection1.Close();
                sqlConnection1.ConnectionString = connectionString;
                sqlConnection1.Open();
                MessageBox.Show($"Соединение с базой данных {textBoxDBName.Text} выполнено успешно", "Соединение");
            }
            catch (Exception ex)
            {
                tableNames.Clear();
                comboBoxTables.DataSource = null;
                comboBoxTables.DataSource = tableNames;
                buttonOpenTable.Enabled = false;
                MessageBox.Show($"Ошибка соединения с базой данных!\n{ex.Message}", "Соединение");
            }
            if (sqlConnection1.State == ConnectionState.Open)
            {
                try
                {
                    sqlCommand1.Connection = sqlConnection1;
                    sqlCommand1.CommandType = CommandType.Text;
                    sqlCommand1.CommandText = $@"USE [{textBoxDBName.Text}]";
                    sqlCommand1.ExecuteNonQuery();
                    sqlCommand1.CommandText = $@"SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_SCHEMA, TABLE_NAME";
                    SqlDataReader reader = sqlCommand1.ExecuteReader();
                    tableNames.Clear();
                    while (reader.Read())
                    {
                        tableNames.Add(new TableName(reader["TABLE_SCHEMA"].ToString(), reader["TABLE_NAME"].ToString()));
                    }
                    reader.Close();
                    comboBoxTables.DataSource = null;
                    comboBoxTables.DataSource = tableNames;
                    buttonOpenTable.Enabled = true;
                }
                catch (Exception ex)
                {
                    buttonOpenTable.Enabled = false;
                    MessageBox.Show($"Ошибка создания списка таблиц!\n{ex.Message}", "Ошибка");
                }
                finally
                {
                    sqlConnection1.Close();
                }
            }
        }

        private void buttonOpenTable_Click(object sender, EventArgs e)
        {
            if ((TableName)comboBoxTables.SelectedItem != null)
            {
                TableForm newForm = new TableForm();
                newForm.connectionString = connectionString;
                newForm.tableName = (TableName)comboBoxTables.SelectedItem;
                newForm.Text = "Редактирование таблицы. DATABASE: "+$"{textBoxDBName.Text} "+((TableName)comboBoxTables.SelectedItem).ToString();
                newForm.Show();
            }
            else MessageBox.Show("Пожалуйста, выберите таблицу для отображения", "Ошибка");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxServerAddr.Text = ConfigurationManager.AppSettings.Get("DefaultServer");
            textBoxDBName.Text = ConfigurationManager.AppSettings.Get("DefaultDatabase");
        }
    }
}
