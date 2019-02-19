namespace wms.Forms.Administration.Item
{
    partial class IM_Upload_data
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.itemTxtBox = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.optionBtn = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressLabel = new System.Windows.Forms.Label();
            this.itemLabel = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Location = new System.Drawing.Point(14, 135);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(682, 23);
            this.progressBar.TabIndex = 30;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(14, 92);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(682, 14);
            this.panel10.TabIndex = 31;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel13);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.optionBtn);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.uploadBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(14, 62);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(682, 30);
            this.panel5.TabIndex = 29;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.itemTxtBox);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(81, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(401, 30);
            this.panel6.TabIndex = 13;
            // 
            // itemTxtBox
            // 
            this.itemTxtBox.BackColor = System.Drawing.SystemColors.Info;
            this.itemTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemTxtBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemTxtBox.ForeColor = System.Drawing.Color.Black;
            this.itemTxtBox.Location = new System.Drawing.Point(0, 5);
            this.itemTxtBox.Name = "itemTxtBox";
            this.itemTxtBox.Size = new System.Drawing.Size(401, 22);
            this.itemTxtBox.TabIndex = 2;
            this.itemTxtBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.itemTxtBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(401, 5);
            this.panel9.TabIndex = 9;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label2);
            this.panel13.Controls.Add(this.panel24);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(81, 30);
            this.panel13.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Choose File:";
            // 
            // panel24
            // 
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(81, 5);
            this.panel24.TabIndex = 16;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(482, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 30);
            this.panel7.TabIndex = 12;
            // 
            // optionBtn
            // 
            this.optionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.optionBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.optionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.optionBtn.ForeColor = System.Drawing.Color.White;
            this.optionBtn.Location = new System.Drawing.Point(487, 0);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(95, 30);
            this.optionBtn.TabIndex = 11;
            this.optionBtn.Text = "...";
            this.optionBtn.UseVisualStyleBackColor = false;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(582, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(5, 30);
            this.panel8.TabIndex = 10;
            // 
            // uploadBtn
            // 
            this.uploadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(104)))), ((int)(((byte)(179)))));
            this.uploadBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.uploadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.uploadBtn.ForeColor = System.Drawing.Color.White;
            this.uploadBtn.Location = new System.Drawing.Point(587, 0);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(95, 30);
            this.uploadBtn.TabIndex = 2;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = false;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(14, 163);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(682, 14);
            this.panel4.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(14, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(682, 14);
            this.panel3.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 177);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(696, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 177);
            this.panel2.TabIndex = 26;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.progressLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.ForeColor = System.Drawing.Color.Black;
            this.progressLabel.Location = new System.Drawing.Point(588, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(94, 17);
            this.progressLabel.TabIndex = 13;
            this.progressLabel.Text = "0% Completed";
            // 
            // itemLabel
            // 
            this.itemLabel.AutoSize = true;
            this.itemLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemLabel.ForeColor = System.Drawing.Color.Black;
            this.itemLabel.Location = new System.Drawing.Point(0, 0);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(173, 17);
            this.itemLabel.TabIndex = 14;
            this.itemLabel.Text = "Uploading 0 out of 0 Item(s)";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.progressLabel);
            this.panel11.Controls.Add(this.itemLabel);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(14, 106);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(682, 29);
            this.panel11.TabIndex = 32;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.label1);
            this.panel17.Controls.Add(this.panel18);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(14, 14);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(682, 34);
            this.panel17.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Item Maintenance - Upload Excel File";
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 26);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(680, 6);
            this.panel18.TabIndex = 9;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(14, 48);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(682, 14);
            this.panel12.TabIndex = 34;
            // 
            // IM_Upload_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 177);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IM_Upload_data";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IM_Upload_Data_FormClosing);
            this.Load += new System.EventHandler(this.IM_Upload_Data_Load);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox itemTxtBox;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button optionBtn;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel24;
    }
}