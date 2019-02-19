namespace wms.Forms.Warehouse_Management.Stock_Receiving_Plan
{
    partial class Receiving_Plan
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
            this.DatePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.DatePickerTo = new System.Windows.Forms.DateTimePicker();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DateTimeSchedule = new System.Windows.Forms.DateTimePicker();
            this.DataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView6 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView7 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView8 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.vanDataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDocGridView = new System.Windows.Forms.DataGridView();
            this.BillDocsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteBillDocColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siteGridView = new System.Windows.Forms.DataGridView();
            this.SiteCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CasesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView3 = new System.Windows.Forms.DataGridView();
            this.InventoryIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vanDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillDocGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // DatePickerFrom
            // 
            this.DatePickerFrom.Location = new System.Drawing.Point(111, 12);
            this.DatePickerFrom.Name = "DatePickerFrom";
            this.DatePickerFrom.Size = new System.Drawing.Size(200, 20);
            this.DatePickerFrom.TabIndex = 0;
            this.DatePickerFrom.ValueChanged += new System.EventHandler(this.DatePickerFrom_ValueChanged);
            // 
            // DatePickerTo
            // 
            this.DatePickerTo.Location = new System.Drawing.Point(342, 12);
            this.DatePickerTo.Name = "DatePickerTo";
            this.DatePickerTo.Size = new System.Drawing.Size(200, 20);
            this.DatePickerTo.TabIndex = 2;
            this.DatePickerTo.ValueChanged += new System.EventHandler(this.DatePickerTo_ValueChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(512, 232);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(91, 37);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "ADD SCHEDULE";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DateTimeSchedule
            // 
            this.DateTimeSchedule.Enabled = false;
            this.DateTimeSchedule.Location = new System.Drawing.Point(791, 11);
            this.DateTimeSchedule.Name = "DateTimeSchedule";
            this.DateTimeSchedule.Size = new System.Drawing.Size(200, 20);
            this.DateTimeSchedule.TabIndex = 10;
            this.DateTimeSchedule.ValueChanged += new System.EventHandler(this.DateTimeSchedule_ValueChanged);
            // 
            // DataGridView5
            // 
            this.DataGridView5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.DataGridView5.Location = new System.Drawing.Point(650, 38);
            this.DataGridView5.Name = "DataGridView5";
            this.DataGridView5.Size = new System.Drawing.Size(591, 188);
            this.DataGridView5.TabIndex = 11;
            this.DataGridView5.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView5_CellContentDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Van";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Loaded";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Added Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // DataGridView6
            // 
            this.DataGridView6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.DataGridView6.Location = new System.Drawing.Point(650, 232);
            this.DataGridView6.Name = "DataGridView6";
            this.DataGridView6.Size = new System.Drawing.Size(591, 168);
            this.DataGridView6.TabIndex = 12;
            this.DataGridView6.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView6_CellContentDoubleClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "SiteCode";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Site Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Cases";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // DataGridView7
            // 
            this.DataGridView7.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.DataGridView7.Location = new System.Drawing.Point(650, 406);
            this.DataGridView7.Name = "DataGridView7";
            this.DataGridView7.Size = new System.Drawing.Size(591, 175);
            this.DataGridView7.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Inventory ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Description";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // DataGridView8
            // 
            this.DataGridView8.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView8.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.DataGridView8.Location = new System.Drawing.Point(650, 587);
            this.DataGridView8.Name = "DataGridView8";
            this.DataGridView8.Size = new System.Drawing.Size(591, 150);
            this.DataGridView8.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Billdocs";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Site_Name";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(646, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Choose Schedule:";
            // 
            // vanDataGrid
            // 
            this.vanDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vanDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.vanDataGrid.Location = new System.Drawing.Point(12, 38);
            this.vanDataGrid.Name = "vanDataGrid";
            this.vanDataGrid.Size = new System.Drawing.Size(591, 188);
            this.vanDataGrid.TabIndex = 16;
            this.vanDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vanDataGrid_CellContentDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Van";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Loaded";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Scheduled Date";
            this.Column3.Name = "Column3";
            // 
            // BillDocGridView
            // 
            this.BillDocGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BillDocGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillDocsColumn,
            this.SiteBillDocColumn});
            this.BillDocGridView.Location = new System.Drawing.Point(12, 587);
            this.BillDocGridView.Name = "BillDocGridView";
            this.BillDocGridView.Size = new System.Drawing.Size(591, 150);
            this.BillDocGridView.TabIndex = 17;
            // 
            // BillDocsColumn
            // 
            this.BillDocsColumn.HeaderText = "BillDocs";
            this.BillDocsColumn.Name = "BillDocsColumn";
            // 
            // SiteBillDocColumn
            // 
            this.SiteBillDocColumn.HeaderText = "SiteName";
            this.SiteBillDocColumn.Name = "SiteBillDocColumn";
            // 
            // siteGridView
            // 
            this.siteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.siteGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SiteCodeColumn,
            this.SiteNameColumn,
            this.CasesColumn});
            this.siteGridView.Location = new System.Drawing.Point(12, 275);
            this.siteGridView.Name = "siteGridView";
            this.siteGridView.Size = new System.Drawing.Size(591, 150);
            this.siteGridView.TabIndex = 18;
            this.siteGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.siteGridView_CellContentDoubleClick);
            // 
            // SiteCodeColumn
            // 
            this.SiteCodeColumn.HeaderText = "SiteCode";
            this.SiteCodeColumn.Name = "SiteCodeColumn";
            // 
            // SiteNameColumn
            // 
            this.SiteNameColumn.HeaderText = "SiteName";
            this.SiteNameColumn.Name = "SiteNameColumn";
            // 
            // CasesColumn
            // 
            this.CasesColumn.HeaderText = "Cases";
            this.CasesColumn.Name = "CasesColumn";
            // 
            // DataGridView3
            // 
            this.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryIdColumn,
            this.DescriptionColumn,
            this.QuantityColumn});
            this.DataGridView3.Location = new System.Drawing.Point(12, 431);
            this.DataGridView3.Name = "DataGridView3";
            this.DataGridView3.Size = new System.Drawing.Size(591, 150);
            this.DataGridView3.TabIndex = 19;
            // 
            // InventoryIdColumn
            // 
            this.InventoryIdColumn.HeaderText = "InventoryId";
            this.InventoryIdColumn.Name = "InventoryIdColumn";
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            // 
            // QuantityColumn
            // 
            this.QuantityColumn.HeaderText = "Quantity";
            this.QuantityColumn.Name = "QuantityColumn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Select Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "--";
            // 
            // Receiving_Plan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 757);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataGridView3);
            this.Controls.Add(this.siteGridView);
            this.Controls.Add(this.BillDocGridView);
            this.Controls.Add(this.vanDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGridView8);
            this.Controls.Add(this.DataGridView7);
            this.Controls.Add(this.DataGridView6);
            this.Controls.Add(this.DataGridView5);
            this.Controls.Add(this.DateTimeSchedule);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DatePickerTo);
            this.Controls.Add(this.DatePickerFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Receiving_Plan";
            this.Text = "Receiving_Plan";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vanDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillDocGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DatePickerFrom;
        private System.Windows.Forms.DateTimePicker DatePickerTo;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.DateTimePicker DateTimeSchedule;
        private System.Windows.Forms.DataGridView DataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView DataGridView6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView DataGridView7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridView DataGridView8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView vanDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView BillDocGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDocsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteBillDocColumn;
        private System.Windows.Forms.DataGridView siteGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CasesColumn;
        private System.Windows.Forms.DataGridView DataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}