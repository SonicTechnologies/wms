namespace wms.Forms.Administration.Users.Authorizations
{
    partial class Add_Lvl1_Module
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.custid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel56 = new System.Windows.Forms.Panel();
            this.panel59 = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.panel60 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel20.SuspendLayout();
            this.panel56.SuspendLayout();
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
            this.moduleName,
            this.address,
            this.Add});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(14, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 27;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(441, 318);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // custid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.custid.DefaultCellStyle = dataGridViewCellStyle1;
            this.custid.HeaderText = "ID";
            this.custid.Name = "custid";
            this.custid.ReadOnly = true;
            this.custid.Visible = false;
            this.custid.Width = 5;
            // 
            // moduleName
            // 
            this.moduleName.HeaderText = "Module Name";
            this.moduleName.Name = "moduleName";
            this.moduleName.ReadOnly = true;
            this.moduleName.Width = 5;
            // 
            // address
            // 
            this.address.HeaderText = "Date Created";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 5;
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
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.White;
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.panel14);
            this.panel20.Controls.Add(this.panel56);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(14, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(441, 42);
            this.panel20.TabIndex = 27;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 31);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(439, 10);
            this.panel14.TabIndex = 28;
            // 
            // panel56
            // 
            this.panel56.BackColor = System.Drawing.Color.White;
            this.panel56.Controls.Add(this.panel59);
            this.panel56.Controls.Add(this.panel57);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel56.Location = new System.Drawing.Point(0, 0);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(439, 31);
            this.panel56.TabIndex = 27;
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.textBox7);
            this.panel59.Controls.Add(this.panel60);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel59.Location = new System.Drawing.Point(141, 0);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(169, 31);
            this.panel59.TabIndex = 11;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Info;
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox7.Location = new System.Drawing.Point(0, 10);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(169, 20);
            this.textBox7.TabIndex = 28;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // panel60
            // 
            this.panel60.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel60.Location = new System.Drawing.Point(0, 0);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(169, 10);
            this.panel60.TabIndex = 11;
            // 
            // panel57
            // 
            this.panel57.Controls.Add(this.label8);
            this.panel57.Controls.Add(this.panel58);
            this.panel57.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel57.Location = new System.Drawing.Point(0, 0);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(141, 31);
            this.panel57.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label8.Location = new System.Drawing.Point(0, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Search Module-Name:";
            // 
            // panel58
            // 
            this.panel58.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel58.Location = new System.Drawing.Point(0, 0);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(141, 10);
            this.panel58.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(455, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 384);
            this.panel3.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 384);
            this.panel1.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(14, 370);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(441, 14);
            this.panel4.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(14, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 10);
            this.panel2.TabIndex = 31;
            // 
            // Add_Lvl1_Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 384);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_Lvl1_Module";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Access Module  (Level 1)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Add_Lvl1_Module_FormClosing);
            this.Load += new System.EventHandler(this.Add_Lvl1_Module_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel20.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            this.panel59.ResumeLayout(false);
            this.panel59.PerformLayout();
            this.panel57.ResumeLayout(false);
            this.panel57.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel56;
        private System.Windows.Forms.Panel panel59;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Panel panel60;
        private System.Windows.Forms.Panel panel57;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel58;
        private System.Windows.Forms.DataGridViewTextBoxColumn custid;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewButtonColumn Add;
    }
}