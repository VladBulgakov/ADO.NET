using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWinForms1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-5J5P4KB\SQLEXPRESS;Initial Catalog=Northwind;" + "Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                richTextBox1.Text = $"State: {connection.State}\nConnectionString: {connection.ConnectionString}";

                //Console.WriteLine("State: {0}", connection.State);
                //Console.WriteLine("ConnectionString: {0}", connection.ConnectionString);
            } //Так как соединение создается в блоке using, close connection будет вызвано автоматически после выхода за блок
        }
    }
}
