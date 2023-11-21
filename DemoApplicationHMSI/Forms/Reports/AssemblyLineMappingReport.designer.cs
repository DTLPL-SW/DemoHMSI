namespace DemoApplicationHMSI.Reports
{
    partial class AssemblyLineMappingReport
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
            this.DateTodate = new System.Windows.Forms.DateTimePicker();
            this.Datefromdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPDFExport = new System.Windows.Forms.Button();
            this.btnGetReport = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMinimize = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.MCNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MachinenAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckingPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckingMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandardValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JudgeMent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.InserterdOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // DateTodate
            // 
            this.DateTodate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DateTodate.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.DateTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTodate.Location = new System.Drawing.Point(340, 42);
            this.DateTodate.Name = "DateTodate";
            this.DateTodate.Size = new System.Drawing.Size(283, 35);
            this.DateTodate.TabIndex = 59;
            // 
            // Datefromdate
            // 
            this.Datefromdate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.Datefromdate.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.Datefromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Datefromdate.Location = new System.Drawing.Point(8, 42);
            this.Datefromdate.Name = "Datefromdate";
            this.Datefromdate.Size = new System.Drawing.Size(306, 35);
            this.Datefromdate.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(336, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 22);
            this.label4.TabIndex = 57;
            this.label4.Text = "To Date";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 22);
            this.label3.TabIndex = 56;
            this.label3.Text = "From Date";
            // 
            // btnPDFExport
            // 
            this.btnPDFExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnPDFExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPDFExport.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnPDFExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPDFExport.Location = new System.Drawing.Point(413, 6);
            this.btnPDFExport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPDFExport.Name = "btnPDFExport";
            this.btnPDFExport.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnPDFExport.Size = new System.Drawing.Size(244, 42);
            this.btnPDFExport.TabIndex = 20;
            this.btnPDFExport.Text = "EXPORT IN PDF";
            this.btnPDFExport.UseVisualStyleBackColor = false;
            this.btnPDFExport.Click += new System.EventHandler(this.btnPDFExport_Click);
            // 
            // btnGetReport
            // 
            this.btnGetReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnGetReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetReport.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnGetReport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGetReport.Location = new System.Drawing.Point(11, 6);
            this.btnGetReport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnGetReport.Size = new System.Drawing.Size(145, 42);
            this.btnGetReport.TabIndex = 19;
            this.btnGetReport.Text = "GET REPORT";
            this.btnGetReport.UseVisualStyleBackColor = false;
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDownload.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnDownload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDownload.Location = new System.Drawing.Point(163, 6);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnDownload.Size = new System.Drawing.Size(244, 42);
            this.btnDownload.TabIndex = 18;
            this.btnDownload.Text = "EXPORT IN EXCEL";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(664, 6);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnClear.Size = new System.Drawing.Size(115, 42);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(786, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnExit.Size = new System.Drawing.Size(115, 42);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.dgvData);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 171);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1256, 518);
            this.panel5.TabIndex = 61;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnPDFExport);
            this.panel3.Controls.Add(this.btnGetReport);
            this.panel3.Controls.Add(this.btnDownload);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Location = new System.Drawing.Point(4, 83);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1190, 62);
            this.panel3.TabIndex = 61;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(1264, 692);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.DateTodate);
            this.panel2.Controls.Add(this.Datefromdate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1256, 153);
            this.panel2.TabIndex = 59;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(141)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 64);
            this.panel1.TabIndex = 55;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Image = global::DemoApplicationHMSI.Properties.Resources.minimize;
            this.button1.Location = new System.Drawing.Point(1197, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 64);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.AutoSize = true;
            this.btnMinimize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMinimize.Depth = 0;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Location = new System.Drawing.Point(1256, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMinimize.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Primary = false;
            this.btnMinimize.Size = new System.Drawing.Size(8, 64);
            this.btnMinimize.TabIndex = 9;
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(249, 6);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(739, 55);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "CHECK POINT LIST REPORT";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 50;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MCNo,
            this.MachinenAM,
            this.LineCode,
            this.Location,
            this.SNo,
            this.CheckingPoint,
            this.CheckingMethod,
            this.StandardValue,
            this.Freq,
            this.ActualValue,
            this.JudgeMent,
            this.ActionPlan,
            this.Remarks,
            this.Image,
            this.InserterdOn});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.RowHeadersWidth = 60;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(1254, 516);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            // 
            // MCNo
            // 
            this.MCNo.HeaderText = "MC NO";
            this.MCNo.MinimumWidth = 6;
            this.MCNo.Name = "MCNo";
            // 
            // MachinenAM
            // 
            this.MachinenAM.HeaderText = "Machine Name";
            this.MachinenAM.MinimumWidth = 6;
            this.MachinenAM.Name = "MachinenAM";
            // 
            // LineCode
            // 
            this.LineCode.HeaderText = "LineCode";
            this.LineCode.MinimumWidth = 6;
            this.LineCode.Name = "LineCode";
            // 
            // Location
            // 
            this.Location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 6;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 189;
            // 
            // SNo
            // 
            this.SNo.HeaderText = "Sno";
            this.SNo.MinimumWidth = 6;
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            // 
            // CheckingPoint
            // 
            this.CheckingPoint.HeaderText = "Checking Point";
            this.CheckingPoint.MinimumWidth = 6;
            this.CheckingPoint.Name = "CheckingPoint";
            this.CheckingPoint.ReadOnly = true;
            // 
            // CheckingMethod
            // 
            this.CheckingMethod.HeaderText = "Checking Method";
            this.CheckingMethod.MinimumWidth = 6;
            this.CheckingMethod.Name = "CheckingMethod";
            this.CheckingMethod.ReadOnly = true;
            // 
            // StandardValue
            // 
            this.StandardValue.HeaderText = "Standard Value";
            this.StandardValue.MinimumWidth = 6;
            this.StandardValue.Name = "StandardValue";
            this.StandardValue.ReadOnly = true;
            // 
            // Freq
            // 
            this.Freq.HeaderText = "Freq";
            this.Freq.MinimumWidth = 6;
            this.Freq.Name = "Freq";
            this.Freq.ReadOnly = true;
            // 
            // ActualValue
            // 
            this.ActualValue.HeaderText = "Actual Value";
            this.ActualValue.MinimumWidth = 6;
            this.ActualValue.Name = "ActualValue";
            // 
            // JudgeMent
            // 
            this.JudgeMent.HeaderText = "Judement";
            this.JudgeMent.MinimumWidth = 6;
            this.JudgeMent.Name = "JudgeMent";
            this.JudgeMent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.JudgeMent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ActionPlan
            // 
            this.ActionPlan.HeaderText = "ActionPlan";
            this.ActionPlan.MinimumWidth = 6;
            this.ActionPlan.Name = "ActionPlan";
            this.ActionPlan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionPlan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.MinimumWidth = 6;
            this.Remarks.Name = "Remarks";
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.MinimumWidth = 6;
            this.Image.Name = "Image";
            // 
            // InserterdOn
            // 
            this.InserterdOn.HeaderText = "InsertedOn";
            this.InserterdOn.MinimumWidth = 6;
            this.InserterdOn.Name = "InserterdOn";
            // 
            // AssemblyLineMappingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 756);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AssemblyLineMappingReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DateTodate;
        private System.Windows.Forms.DateTimePicker Datefromdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPDFExport;
        private System.Windows.Forms.Button btnGetReport;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton btnMinimize;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn MCNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MachinenAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckingPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckingMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn StandardValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn JudgeMent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn InserterdOn;
    }
}