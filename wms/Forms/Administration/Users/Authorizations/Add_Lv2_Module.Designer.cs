namespace wms.Forms.Administration.Users.Authorizations
{
    partial class Add_Lv2_Module
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel56 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel59 = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.panel60 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.custid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessModuleLevel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel20.SuspendLayout();
            this.panel56.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel59.SuspendLayout();
            this.panel57.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.custid,
            this.custname,
            this.moduleName,
            this.AccessModuleLevel2,
            this.Column2,
            this.Add});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(14, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 27;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(441, 311);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.White;
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.panel56);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(14, 13);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(441, 36);
            this.panel20.TabIndex = 28;
            // 
            // panel56
            // 
            this.panel56.BackColor = System.Drawing.Color.White;
            this.panel56.Controls.Add(this.panel2);
            this.panel56.Controls.Add(this.panel1);
            this.panel56.Controls.Add(this.panel59);
            this.panel56.Controls.Add(this.panel57);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel56.Location = new System.Drawing.Point(0, 0);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(439, 27);
            this.panel56.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(429, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 22);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 5);
            this.panel3.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(368, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(71, 5);
            this.panel1.TabIndex = 17;
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.textBox7);
            this.panel59.Controls.Add(this.panel60);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel59.Location = new System.Drawing.Point(149, 0);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(219, 27);
            this.panel59.TabIndex = 11;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Info;
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox7.Location = new System.Drawing.Point(0, 5);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(219, 20);
            this.textBox7.TabIndex = 28;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // panel60
            // 
            this.panel60.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel60.Location = new System.Drawing.Point(0, 0);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(219, 5);
            this.panel60.TabIndex = 11;
            // 
            // panel57
            // 
            this.panel57.Controls.Add(this.label8);
            this.panel57.Controls.Add(this.panel58);
            this.panel57.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel57.Location = new System.Drawing.Point(0, 0);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(149, 27);
            this.panel57.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label8.Location = new System.Drawing.Point(0, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Search Module (Level 2):";
            // 
            // panel58
            // 
            this.panel58.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel58.Location = new System.Drawing.Point(0, 0);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(149, 5);
            this.panel58.TabIndex = 13;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(14, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(441, 13);
            this.panel7.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(455, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(14, 384);
            this.panel4.TabIndex = 34;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(14, 384);
            this.panel5.TabIndex = 35;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(14, 370);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(441, 14);
            this.panel6.TabIndex = 36;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(14, 49);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(441, 10);
            this.panel8.TabIndex = 37;
            // 
            // custid
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.custid.DefaultCellStyle = dataGridViewCellStyle2;
            this.custid.HeaderText = "ID";
            this.custid.Name = "custid";
            this.custid.ReadOnly = true;
            this.custid.Visible = false;
            this.custid.Width = 5;
            // 
            // custname
            // 
            this.custname.HeaderText = "Module ID";
            this.custname.Name = "custname";
            this.custname.ReadOnly = true;
            this.custname.Visible = false;
            this.custname.Width = 5;
            // 
            // moduleName
            // 
            this.moduleName.HeaderText = "Module Name";
            this.moduleName.Name = "moduleName";
            this.moduleName.ReadOnly = true;
            this.moduleName.Visible = false;
            this.moduleName.Width = 5;
            // 
            // AccessModuleLevel2
            // 
            this.AccessModuleLevel2.HeaderText = "Access Module (Level 2)";
            this.AccessModuleLevel2.Name = "AccessModuleLevel2";
            this.AccessModuleLevel2.ReadOnly = true;
            this.AccessModuleLevel2.Width = 5;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Date Created";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 5;
            // 
            // Add
            // 
            this.Add.HeaderText = "Action";
            this.Add.Name = "Add";
            this.Add.ReadOnly = true;
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Add.Text = "Add";
            this.Add.UseColumnTextForButtonValue = true;
            this.Add.Width = 5;
            // 
            // Add_Lv2_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 384);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_Lv2_Module";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Access Module (Level 2)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Add_Lv2_Module_FormClosing);
            this.Load += new System.EventHandler(this.Add_Lv2_Module_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel20.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel59.ResumeLayout(false);
            this.panel59.PerformLayout();
            this.panel57.ResumeLayout(false);
            this.panel57.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel56;
        private System.Windows.Forms.Panel panel59;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Panel panel60;
        private System.Windows.Forms.Panel panel57;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel58;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridViewTextBoxColumn custid;
        private System.Windows.Forms.DataGridViewTextBoxColumn custname;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessModuleLevel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
    }
}