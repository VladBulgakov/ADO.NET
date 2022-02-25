using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADOFinalTask
{
    public partial class TableForm : Form
    {
        public string connectionString;
        public TableName tableName;

        private SqlDataAdapter sqlDataAdapter1;
        private DataSet FormDataset = new DataSet("MyDataSet");
        private DataTable FormTable = new DataTable("MyTable");

        public TableForm()
        {
            InitializeComponent();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            sqlConnection1.ConnectionString = connectionString;
            sqlDataAdapter1 = new SqlDataAdapter($@"SELECT * FROM [{tableName.Schema}].[{tableName.Name}]", sqlConnection1);
            FormDataset.Tables.Add(FormTable);
            sqlDataAdapter1.Fill(FormDataset.Tables["MyTable"]);
            dataGridView1.DataSource = FormDataset.Tables["MyTable"];
            SqlCommandBuilder commands = new SqlCommandBuilder(sqlDataAdapter1);
        }

        private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                FormDataset.EndInit();
                sqlDataAdapter1.Update(FormDataset.Tables["MyTable"]);
                MessageBox.Show("Изменения сохранены!", "Сохранение изменений");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при сохранении изменений!\n{ex.Message}", "Сохранение изменений");
            }
        }

        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Вы уверены, что хотите закрыть окно редактирования таблицы?";
            string caption = "Завершение работы";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) e.Cancel = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.GetType() == typeof(DataGridViewImageCell))
            {
                if (dataGridView1.CurrentCell.Value == DBNull.Value)
                {
                    //Добавить картинку?
                    string message = "Добавить изображение?";
                    string caption = "Работа с изображением";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        OpenFileDialog diag = new OpenFileDialog();
                        if (diag.ShowDialog() == DialogResult.OK)
                        {
                            Image bm = new Bitmap(diag.OpenFile());
                            ImageConverter converter = new ImageConverter();
                            dataGridView1.CurrentCell.Value = (byte[])converter.ConvertTo(bm, typeof(byte[]));
                        }
                    }
                }
                else
                {
                    //Удалить картинку?
                    string message = "Удалить изображение?";
                    string caption = "Работа с изображением";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) dataGridView1.CurrentCell.Value = DBNull.Value;
                }
            }
        }

        private void TableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection1.State != ConnectionState.Closed) sqlConnection1.Close();
        }
    }
}