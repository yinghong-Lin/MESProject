namespace MDM.UI.Admin
{
    partial class FrmEqpGroupHis
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
            dataGridViewHistory = new DataGridView();
            lblRecordCount = new Label();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.AllowUserToAddRows = false;
            dataGridViewHistory.AllowUserToDeleteRows = false;
            dataGridViewHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistory.Location = new Point(21, 19);
            dataGridViewHistory.Margin = new Padding(5, 5, 5, 5);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.ReadOnly = true;
            dataGridViewHistory.RowHeadersWidth = 51;
            dataGridViewHistory.RowTemplate.Height = 29;
            dataGridViewHistory.Size = new Size(2058, 815);
            dataGridViewHistory.TabIndex = 0;
            dataGridViewHistory.CellContentClick += dataGridViewHistory_CellContentClick;
            // 
            // lblRecordCount
            // 
            lblRecordCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRecordCount.AutoSize = true;
            lblRecordCount.Location = new Point(21, 857);
            lblRecordCount.Margin = new Padding(5, 0, 5, 0);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(138, 31);
            lblRecordCount.TabIndex = 1;
            lblRecordCount.Text = "共 0 条记录";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(1904, 848);
            btnClose.Margin = new Padding(5, 5, 5, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(175, 50);
            btnClose.TabIndex = 2;
            btnClose.Text = "关闭";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmEqpGroupHis
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2100, 916);
            Controls.Add(btnClose);
            Controls.Add(lblRecordCount);
            Controls.Add(dataGridViewHistory);
            Margin = new Padding(5, 5, 5, 5);
            Name = "FrmEqpGroupHis";
            StartPosition = FormStartPosition.CenterParent;
            Text = "设备组历史记录";
            Load += FrmEqpGroupHis_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button btnClose;
    }
}
