namespace DemoApplicationHMSI.Forms.Transaction
{
    partial class CheckPointStore
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMachineNo = new System.Windows.Forms.TextBox();
            this.txtmachineName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLineCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlCaptureImage = new System.Windows.Forms.Panel();
            this.btnCapImage = new System.Windows.Forms.Button();
            this.imgCam = new System.Windows.Forms.PictureBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckingPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckingMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandardValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JudgeMent = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ActionPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaptureImage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCamra = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCaptureImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(141)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1914, 64);
            this.panel1.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(275, 10);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1377, 34);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Preventive Maintenance Check sheet";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(383, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "M/C NO.";
            // 
            // txtMachineNo
            // 
            this.txtMachineNo.Enabled = false;
            this.txtMachineNo.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtMachineNo.Location = new System.Drawing.Point(17, 91);
            this.txtMachineNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMachineNo.Name = "txtMachineNo";
            this.txtMachineNo.ReadOnly = true;
            this.txtMachineNo.Size = new System.Drawing.Size(324, 35);
            this.txtMachineNo.TabIndex = 4;
            this.txtMachineNo.Text = "AF02BC014";
            // 
            // txtmachineName
            // 
            this.txtmachineName.Enabled = false;
            this.txtmachineName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtmachineName.Location = new System.Drawing.Point(751, 91);
            this.txtmachineName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtmachineName.Name = "txtmachineName";
            this.txtmachineName.ReadOnly = true;
            this.txtmachineName.Size = new System.Drawing.Size(421, 35);
            this.txtmachineName.TabIndex = 6;
            this.txtmachineName.Text = "Frame Transfer Belt Conveyor";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(747, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "M/C Name";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(1332, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Line Code";
            // 
            // txtLineCode
            // 
            this.txtLineCode.Enabled = false;
            this.txtLineCode.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.txtLineCode.Location = new System.Drawing.Point(1336, 91);
            this.txtLineCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLineCode.Name = "txtLineCode";
            this.txtLineCode.ReadOnly = true;
            this.txtLineCode.Size = new System.Drawing.Size(421, 35);
            this.txtLineCode.TabIndex = 8;
            this.txtLineCode.Text = " ASSEMBLY FRAME-2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlCaptureImage);
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Location = new System.Drawing.Point(17, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1755, 581);
            this.panel2.TabIndex = 9;
            // 
            // pnlCaptureImage
            // 
            this.pnlCaptureImage.Controls.Add(this.btnCapImage);
            this.pnlCaptureImage.Controls.Add(this.imgCam);
            this.pnlCaptureImage.Controls.Add(this.videoSourcePlayer1);
            this.pnlCaptureImage.Location = new System.Drawing.Point(553, 111);
            this.pnlCaptureImage.Name = "pnlCaptureImage";
            this.pnlCaptureImage.Size = new System.Drawing.Size(586, 398);
            this.pnlCaptureImage.TabIndex = 1;
            // 
            // btnCapImage
            // 
            this.btnCapImage.Location = new System.Drawing.Point(216, 317);
            this.btnCapImage.Name = "btnCapImage";
            this.btnCapImage.Size = new System.Drawing.Size(136, 36);
            this.btnCapImage.TabIndex = 1;
            this.btnCapImage.Text = "Capture Image";
            this.btnCapImage.UseVisualStyleBackColor = true;
            this.btnCapImage.Click += new System.EventHandler(this.btnCapImage_Click);
            // 
            // imgCam
            // 
            this.imgCam.Location = new System.Drawing.Point(45, 42);
            this.imgCam.Name = "imgCam";
            this.imgCam.Size = new System.Drawing.Size(499, 256);
            this.imgCam.TabIndex = 0;
            this.imgCam.TabStop = false;
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoSourcePlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.videoSourcePlayer1.Location = new System.Drawing.Point(21, 17);
            this.videoSourcePlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(539, 293);
            this.videoSourcePlayer1.TabIndex = 5;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame_1);
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
            this.Location,
            this.SNo,
            this.CheckingPoint,
            this.CheckingMethod,
            this.StandardValue,
            this.Freq,
            this.ActualValue,
            this.JudgeMent,
            this.ActionPlan,
            this.CaptureImage,
            this.Image});
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
            this.dgvData.Size = new System.Drawing.Size(1755, 581);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEndEdit);
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
            this.JudgeMent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JudgeMent.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.JudgeMent.HeaderText = "Judement";
            this.JudgeMent.Items.AddRange(new object[] {
            "No Abnormality",
            "Having Problem",
            "Had Problem, Repaired",
            "Not Applicable"});
            this.JudgeMent.MinimumWidth = 6;
            this.JudgeMent.Name = "JudgeMent";
            this.JudgeMent.Width = 105;
            // 
            // ActionPlan
            // 
            this.ActionPlan.HeaderText = "ActionPlan";
            this.ActionPlan.MinimumWidth = 6;
            this.ActionPlan.Name = "ActionPlan";
            this.ActionPlan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionPlan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CaptureImage
            // 
            this.CaptureImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CaptureImage.HeaderText = "CaptureImage";
            this.CaptureImage.MinimumWidth = 6;
            this.CaptureImage.Name = "CaptureImage";
            this.CaptureImage.Text = "Capture Image";
            this.CaptureImage.ToolTipText = "Click Here To Capture Image";
            this.CaptureImage.UseColumnTextForButtonValue = true;
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.MinimumWidth = 6;
            this.Image.Name = "Image";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Location = new System.Drawing.Point(17, 772);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1755, 94);
            this.panel3.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(19, 18);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnSave.Size = new System.Drawing.Size(115, 42);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(298, 18);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnClose.Size = new System.Drawing.Size(115, 42);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(93)))), ((int)(((byte)(139)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Location = new System.Drawing.Point(153, 18);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.btnReset.Size = new System.Drawing.Size(115, 42);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(13, 715);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(383, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(17, 744);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(887, 22);
            this.txtRemarks.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Select Camra";
            // 
            // cmbCamra
            // 
            this.cmbCamra.Font = new System.Drawing.Font("Trebuchet MS", 14.25F);
            this.cmbCamra.FormattingEnabled = true;
            this.cmbCamra.Location = new System.Drawing.Point(389, 88);
            this.cmbCamra.Name = "cmbCamra";
            this.cmbCamra.Size = new System.Drawing.Size(337, 37);
            this.cmbCamra.TabIndex = 14;
            // 
            // CheckPointStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1914, 867);
            this.ControlBox = false;
            this.Controls.Add(this.cmbCamra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtLineCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmachineName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMachineNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckPointStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CheckPointStore_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlCaptureImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMachineNo;
        private System.Windows.Forms.TextBox txtmachineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLineCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Panel pnlCaptureImage;
        private System.Windows.Forms.Button btnCapImage;
        private System.Windows.Forms.PictureBox imgCam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckingPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckingMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn StandardValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn JudgeMent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionPlan;
        private System.Windows.Forms.DataGridViewButtonColumn CaptureImage;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCamra;
    }
}