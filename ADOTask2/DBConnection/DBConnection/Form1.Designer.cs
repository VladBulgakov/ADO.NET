
namespace DBConnection
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectToDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeConnectionToDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNumberProd = new System.Windows.Forms.Button();
            this.labelNumberProd = new System.Windows.Forms.Label();
            this.buttonListProd = new System.Windows.Forms.Button();
            this.listViewListProd = new System.Windows.Forms.ListView();
            this.columnHeaderProdName = new System.Windows.Forms.ColumnHeader();
            this.buttonTransaction = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToDBToolStripMenuItem,
            this.closeConnectionToDBToolStripMenuItem,
            this.connectionListToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectToDBToolStripMenuItem
            // 
            this.connectToDBToolStripMenuItem.Name = "connectToDBToolStripMenuItem";
            this.connectToDBToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.connectToDBToolStripMenuItem.Text = "Connect to DB";
            this.connectToDBToolStripMenuItem.Click += new System.EventHandler(this.connectToDBToolStripMenuItem_Click);
            // 
            // closeConnectionToDBToolStripMenuItem
            // 
            this.closeConnectionToDBToolStripMenuItem.Name = "closeConnectionToDBToolStripMenuItem";
            this.closeConnectionToDBToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.closeConnectionToDBToolStripMenuItem.Text = "Close connection to DB";
            this.closeConnectionToDBToolStripMenuItem.Click += new System.EventHandler(this.closeConnectionToDBToolStripMenuItem_Click);
            // 
            // connectionListToolStripMenuItem
            // 
            this.connectionListToolStripMenuItem.Name = "connectionListToolStripMenuItem";
            this.connectionListToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.connectionListToolStripMenuItem.Text = "Connection List";
            this.connectionListToolStripMenuItem.Click += new System.EventHandler(this.connectionListToolStripMenuItem_Click);
            // 
            // buttonNumberProd
            // 
            this.buttonNumberProd.Location = new System.Drawing.Point(12, 31);
            this.buttonNumberProd.Name = "buttonNumberProd";
            this.buttonNumberProd.Size = new System.Drawing.Size(180, 29);
            this.buttonNumberProd.TabIndex = 1;
            this.buttonNumberProd.Text = "Сколько продуктов";
            this.buttonNumberProd.UseVisualStyleBackColor = true;
            this.buttonNumberProd.Click += new System.EventHandler(this.buttonNumberProd_Click);
            // 
            // labelNumberProd
            // 
            this.labelNumberProd.AutoSize = true;
            this.labelNumberProd.Location = new System.Drawing.Point(207, 35);
            this.labelNumberProd.Name = "labelNumberProd";
            this.labelNumberProd.Size = new System.Drawing.Size(142, 20);
            this.labelNumberProd.TabIndex = 2;
            this.labelNumberProd.Text = "Сколько продуктов";
            // 
            // buttonListProd
            // 
            this.buttonListProd.Location = new System.Drawing.Point(12, 66);
            this.buttonListProd.Name = "buttonListProd";
            this.buttonListProd.Size = new System.Drawing.Size(180, 29);
            this.buttonListProd.TabIndex = 3;
            this.buttonListProd.Text = "Список продуктов";
            this.buttonListProd.UseVisualStyleBackColor = true;
            this.buttonListProd.Click += new System.EventHandler(this.buttonListProd_Click);
            // 
            // listViewListProd
            // 
            this.listViewListProd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProdName});
            this.listViewListProd.HideSelection = false;
            this.listViewListProd.Location = new System.Drawing.Point(12, 101);
            this.listViewListProd.Name = "listViewListProd";
            this.listViewListProd.Size = new System.Drawing.Size(776, 121);
            this.listViewListProd.TabIndex = 4;
            this.listViewListProd.UseCompatibleStateImageBehavior = false;
            this.listViewListProd.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderProdName
            // 
            this.columnHeaderProdName.Text = "Название продукта";
            this.columnHeaderProdName.Width = 450;
            // 
            // buttonTransaction
            // 
            this.buttonTransaction.Location = new System.Drawing.Point(12, 228);
            this.buttonTransaction.Name = "buttonTransaction";
            this.buttonTransaction.Size = new System.Drawing.Size(180, 29);
            this.buttonTransaction.TabIndex = 5;
            this.buttonTransaction.Text = "Транзакция";
            this.buttonTransaction.UseVisualStyleBackColor = true;
            this.buttonTransaction.Click += new System.EventHandler(this.buttonTransaction_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTransaction);
            this.Controls.Add(this.listViewListProd);
            this.Controls.Add(this.buttonListProd);
            this.Controls.Add(this.labelNumberProd);
            this.Controls.Add(this.buttonNumberProd);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ADO Task 2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeConnectionToDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionListToolStripMenuItem;
        private System.Windows.Forms.Button buttonNumberProd;
        private System.Windows.Forms.Label labelNumberProd;
        private System.Windows.Forms.Button buttonListProd;
        private System.Windows.Forms.ListView listViewListProd;
        private System.Windows.Forms.ColumnHeader columnHeaderProdName;
        private System.Windows.Forms.Button buttonTransaction;
    }
}

