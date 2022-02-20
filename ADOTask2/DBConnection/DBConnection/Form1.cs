using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DBConnection
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        //string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=DESKTOP-5J5P4KB\SQLEXPRESS";
        //string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AdventureWorks2017;Data Source=DESKTOP-5J5P4KB\SQLEXPRESS";
        string testConnect = GetConnectionStringByName("DBConnect.NorthwindConnectionString");
        //string testConnect = "";

        public Form1()
        {
            InitializeComponent();
            this.connection.StateChange += new System.Data.StateChangeEventHandler(this.connection_StateChange);
        }

        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null) returnValue = settings.ConnectionString;
            return returnValue;
        }

        private void connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            connectToDBToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Closed);
            closeConnectionToDBToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Open);
        }

        private void connectToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = testConnect;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных установлено");
                }
                else MessageBox.Show("Соединение уже было установлено");
            }
            catch (OleDbException XcpSQL)
            {
                foreach (OleDbError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message, "SQL Error code " + se.NativeError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeConnectionToDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else MessageBox.Show("Соединение с базой данных уже закрыто");
        }

        private void connectionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    MessageBox.Show($"name: {cs.Name}\n" + $"providerName: {cs.ProviderName}\n" + $"connectionString: {cs.ConnectionString}");
                }
            }
        }

        private void buttonNumberProd_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                MessageBox.Show("Сначала подключитесь к базе");
                return;
            }
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT COUNT(*) FROM [dbo].[Products]";
            int NumberProd = (int)command.ExecuteScalar();
            labelNumberProd.Text = $"Число товаров: {NumberProd}";
        }

        private void buttonListProd_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Closed)
            {
                MessageBox.Show("Сначала подключитесь к базе");
                return;
            }
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM [dbo].[Products]";
            OleDbDataReader reader = command.ExecuteReader();
            listViewListProd.Items.Clear();
            while (reader.Read())
            {
                listViewListProd.Items.Add(reader["ProductName"].ToString());
            }
        }

        private void buttonTransaction_Click(object sender, EventArgs e)
        {
            OleDbConnection connection2 = new OleDbConnection(testConnect);
            connection2.Open();
            OleDbTransaction OleTran = connection2.BeginTransaction();
            OleDbCommand command = connection2.CreateCommand();
            command.Transaction = OleTran;
            try
            {
                command.CommandText = "INSERT INTO Products (ProductName1) VALUES('Wrong size')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Products (ProductName) VALUES('Wrong color')";
                command.ExecuteNonQuery();
                OleTran.Commit();
                MessageBox.Show("Both records were written to database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!\n" + ex.Message);
                try
                {
                    OleTran.Rollback();
                }
                catch (Exception exRollback)
                {
                    MessageBox.Show("Ошибка отката транзакции!\n" + exRollback.Message);
                }
            }
            connection2.Close();
        }
    }
}
