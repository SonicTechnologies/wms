namespace wms
{
    partial class Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.exitBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.optionBtn = new System.Windows.Forms.Button();
            this.servernameBox = new System.Windows.Forms.TextBox();
            this.clearPassBtn = new System.Windows.Forms.Button();
            this.clearUserBtn = new System.Windows.Forms.Button();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.databaseBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.exitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Location = new System.Drawing.Point(104, 396);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 34);
            this.exitBtn.TabIndex = 23;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.loginBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.loginBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.Location = new System.Drawing.Point(227, 396);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 34);
            this.loginBtn.TabIndex = 22;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // optionBtn
            // 
            this.optionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.optionBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.optionBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.optionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionBtn.ForeColor = System.Drawing.Color.White;
            this.optionBtn.Location = new System.Drawing.Point(265, 231);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(37, 44);
            this.optionBtn.TabIndex = 24;
            this.optionBtn.Text = "...";
            this.optionBtn.UseVisualStyleBackColor = false;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // servernameBox
            // 
            this.servernameBox.BackColor = System.Drawing.SystemColors.Info;
            this.servernameBox.Enabled = false;
            this.servernameBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servernameBox.Location = new System.Drawing.Point(105, 232);
            this.servernameBox.Name = "servernameBox";
            this.servernameBox.ReadOnly = true;
            this.servernameBox.Size = new System.Drawing.Size(160, 22);
            this.servernameBox.TabIndex = 28;
            this.servernameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clearPassBtn
            // 
            this.clearPassBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.clearPassBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.clearPassBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.clearPassBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearPassBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearPassBtn.ForeColor = System.Drawing.Color.White;
            this.clearPassBtn.Location = new System.Drawing.Point(265, 362);
            this.clearPassBtn.Name = "clearPassBtn";
            this.clearPassBtn.Size = new System.Drawing.Size(37, 25);
            this.clearPassBtn.TabIndex = 26;
            this.clearPassBtn.Text = "x";
            this.clearPassBtn.UseVisualStyleBackColor = false;
            this.clearPassBtn.Click += new System.EventHandler(this.clearPassBtn_Click);
            // 
            // clearUserBtn
            // 
            this.clearUserBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.clearUserBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.clearUserBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.clearUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearUserBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearUserBtn.ForeColor = System.Drawing.Color.White;
            this.clearUserBtn.Location = new System.Drawing.Point(265, 308);
            this.clearUserBtn.Name = "clearUserBtn";
            this.clearUserBtn.Size = new System.Drawing.Size(37, 25);
            this.clearUserBtn.TabIndex = 25;
            this.clearUserBtn.Text = "x";
            this.clearUserBtn.UseVisualStyleBackColor = false;
            this.clearUserBtn.Click += new System.EventHandler(this.clearUserBtn_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.SystemColors.Info;
            this.passwordBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.passwordBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordBox.Location = new System.Drawing.Point(105, 363);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(160, 22);
            this.passwordBox.TabIndex = 21;
            this.passwordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Password:";
            // 
            // usernameBox
            // 
            this.usernameBox.BackColor = System.Drawing.SystemColors.Info;
            this.usernameBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.usernameBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameBox.Location = new System.Drawing.Point(105, 309);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(160, 22);
            this.usernameBox.TabIndex = 19;
            this.usernameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Username:";
            // 
            // databaseBox
            // 
            this.databaseBox.BackColor = System.Drawing.SystemColors.Info;
            this.databaseBox.Enabled = false;
            this.databaseBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseBox.Location = new System.Drawing.Point(105, 253);
            this.databaseBox.Name = "databaseBox";
            this.databaseBox.ReadOnly = true;
            this.databaseBox.Size = new System.Drawing.Size(160, 22);
            this.databaseBox.TabIndex = 17;
            this.databaseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Developed By: Sonic Technologies";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(155, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Copyright 2018";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 50);
            this.panel1.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wms.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(104, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(412, 516);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.optionBtn);
            this.Controls.Add(this.servernameBox);
            this.Controls.Add(this.clearPassBtn);
            this.Controls.Add(this.clearUserBtn);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.databaseBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMS - Login Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_Form_FormClosing);
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button optionBtn;
        private System.Windows.Forms.TextBox servernameBox;
        private System.Windows.Forms.Button clearPassBtn;
        private System.Windows.Forms.Button clearUserBtn;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox databaseBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}

