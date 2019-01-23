namespace wms.Forms
{
    partial class Select_Server_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BGworker1 = new System.ComponentModel.BackgroundWorker();
            this.selectBtn = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.pwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srvr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // BGworker1
            // 
            this.BGworker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGworker1_DoWork);
            this.BGworker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGworker1_RunWorkerCompleted);
            // 
            // selectBtn
            // 
            this.selectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.selectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBtn.ForeColor = System.Drawing.Color.White;
            this.selectBtn.Location = new System.Drawing.Point(0, 0);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(95, 34);
            this.selectBtn.TabIndex = 7;
            this.selectBtn.Text = "Select";
            this.selectBtn.UseVisualStyleBackColor = false;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.selectBtn);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(677, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(95, 34);
            this.panel13.TabIndex = 2;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.backBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(0, 0);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(95, 34);
            this.backBtn.TabIndex = 7;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.backBtn);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(95, 34);
            this.panel14.TabIndex = 3;
            // 
            // pwd
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwd.DefaultCellStyle = dataGridViewCellStyle1;
            this.pwd.HeaderText = "Password";
            this.pwd.Name = "pwd";
            this.pwd.ReadOnly = true;
            this.pwd.Visible = false;
            // 
            // uname
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uname.DefaultCellStyle = dataGridViewCellStyle2;
            this.uname.HeaderText = "Username";
            this.uname.Name = "uname";
            this.uname.ReadOnly = true;
            this.uname.Visible = false;
            // 
            // db
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.db.DefaultCellStyle = dataGridViewCellStyle3;
            this.db.HeaderText = "Database";
            this.db.Name = "db";
            this.db.ReadOnly = true;
            // 
            // srvr
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srvr.DefaultCellStyle = dataGridViewCellStyle4;
            this.srvr.HeaderText = "Server Name";
            this.srvr.Name = "srvr";
            this.srvr.ReadOnly = true;
            // 
            // ip
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip.DefaultCellStyle = dataGridViewCellStyle5;
            this.ip.HeaderText = "IP Address";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.srvr,
            this.db,
            this.uname,
            this.pwd});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(14, 48);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(772, 349);
            this.dataGridView1.TabIndex = 13;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(14, 397);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(772, 5);
            this.panel15.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Found Database (0):";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.label1);
            this.panel17.Controls.Add(this.panel6);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(501, 34);
            this.panel17.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(501, 5);
            this.panel6.TabIndex = 20;
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.refreshBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.White;
            this.refreshBtn.Location = new System.Drawing.Point(0, 0);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(95, 34);
            this.refreshBtn.TabIndex = 7;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.refreshBtn);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel18.Location = new System.Drawing.Point(677, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(95, 34);
            this.panel18.TabIndex = 3;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(14, 402);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(772, 34);
            this.panel12.TabIndex = 20;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel18);
            this.panel5.Controls.Add(this.panel17);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(14, 14);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(772, 34);
            this.panel5.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(14, 436);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(772, 14);
            this.panel4.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(14, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(772, 14);
            this.panel3.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(786, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 450);
            this.panel2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 450);
            this.panel1.TabIndex = 14;
            // 
            // Select_Server_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Select_Server_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Select_Server_Form_FormClosing);
            this.Load += new System.EventHandler(this.Select_Server_Form_Load);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BGworker1;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.DataGridViewTextBoxColumn pwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn uname;
        private System.Windows.Forms.DataGridViewTextBoxColumn db;
        private System.Windows.Forms.DataGridViewTextBoxColumn srvr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
    }
}