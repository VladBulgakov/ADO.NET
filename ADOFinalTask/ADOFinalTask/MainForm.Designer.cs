
namespace ADOFinalTask
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxServerAddr = new System.Windows.Forms.TextBox();
            this.buttonConnectDB = new System.Windows.Forms.Button();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelDBName = new System.Windows.Forms.Label();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.labelSelectedTableInfo = new System.Windows.Forms.Label();
            this.buttonOpenTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxServerAddr
            // 
            this.textBoxServerAddr.Location = new System.Drawing.Point(128, 6);
            this.textBoxServerAddr.Name = "textBoxServerAddr";
            this.textBoxServerAddr.Size = new System.Drawing.Size(465, 22);
            this.textBoxServerAddr.TabIndex = 0;
            // 
            // buttonConnectDB
            // 
            this.buttonConnectDB.Location = new System.Drawing.Point(15, 63);
            this.buttonConnectDB.Name = "buttonConnectDB";
            this.buttonConnectDB.Size = new System.Drawing.Size(578, 52);
            this.buttonConnectDB.TabIndex = 1;
            this.buttonConnectDB.Text = "Подключиться к базе данных и получить список таблиц";
            this.buttonConnectDB.UseVisualStyleBackColor = true;
            this.buttonConnectDB.Click += new System.EventHandler(this.buttonConnectDB_Click);
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(12, 9);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(110, 17);
            this.labelServer.TabIndex = 2;
            this.labelServer.Text = "Адрес сервера:";
            // 
            // labelDBName
            // 
            this.labelDBName.AutoSize = true;
            this.labelDBName.Location = new System.Drawing.Point(22, 38);
            this.labelDBName.Name = "labelDBName";
            this.labelDBName.Size = new System.Drawing.Size(100, 17);
            this.labelDBName.TabIndex = 3;
            this.labelDBName.Text = "Название БД:";
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(128, 35);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(465, 22);
            this.textBoxDBName.TabIndex = 4;
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(15, 152);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(578, 24);
            this.comboBoxTables.TabIndex = 5;
            // 
            // labelSelectedTableInfo
            // 
            this.labelSelectedTableInfo.AutoSize = true;
            this.labelSelectedTableInfo.Location = new System.Drawing.Point(12, 122);
            this.labelSelectedTableInfo.Name = "labelSelectedTableInfo";
            this.labelSelectedTableInfo.Size = new System.Drawing.Size(344, 17);
            this.labelSelectedTableInfo.TabIndex = 6;
            this.labelSelectedTableInfo.Text = "Выберите таблицу из списка, и затем откройте ее";
            // 
            // buttonOpenTable
            // 
            this.buttonOpenTable.Enabled = false;
            this.buttonOpenTable.Location = new System.Drawing.Point(15, 182);
            this.buttonOpenTable.Name = "buttonOpenTable";
            this.buttonOpenTable.Size = new System.Drawing.Size(578, 45);
            this.buttonOpenTable.TabIndex = 7;
            this.buttonOpenTable.Text = "Открыть таблицу...";
            this.buttonOpenTable.UseVisualStyleBackColor = true;
            this.buttonOpenTable.Click += new System.EventHandler(this.buttonOpenTable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 240);
            this.Controls.Add(this.buttonOpenTable);
            this.Controls.Add(this.labelSelectedTableInfo);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.textBoxDBName);
            this.Controls.Add(this.labelDBName);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.buttonConnectDB);
            this.Controls.Add(this.textBoxServerAddr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Редактор базы данных";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxServerAddr;
        private System.Windows.Forms.Button buttonConnectDB;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelDBName;
        private System.Windows.Forms.TextBox textBoxDBName;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Label labelSelectedTableInfo;
        private System.Windows.Forms.Button buttonOpenTable;
    }
}

