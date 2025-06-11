namespace MDM.UI.WorkOrders
{
    partial class FrmDispatchWorkOrder
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
            btnQuery = new Button();
            txtDetailType = new TextBox();
            label2 = new Label();
            txWorkOrderId = new TextBox();
            label4 = new Label();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            label3 = new Label();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            label6 = new Label();
            textBoxWorkOrderVersion = new TextBox();
            textBoxWorkOrderId = new TextBox();
            label7 = new Label();
            btnChangeProcessFlow = new Button();
            textBoxProcessVersion = new TextBox();
            comboBoxProcessFlow = new ComboBox();
            label21 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnQuery
            // 
            btnQuery.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Location = new Point(1257, 60);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(112, 45);
            btnQuery.TabIndex = 67;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click_1;
            // 
            // txtDetailType
            // 
            txtDetailType.Location = new Point(-314, 211);
            txtDetailType.Name = "txtDetailType";
            txtDetailType.Size = new Size(203, 30);
            txtDetailType.TabIndex = 66;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.Location = new Point(-409, 215);
            label2.Name = "label2";
            label2.Size = new Size(73, 23);
            label2.TabIndex = 62;
            label2.Text = "工单号";
            // 
            // txWorkOrderId
            // 
            txWorkOrderId.Location = new Point(138, 68);
            txWorkOrderId.Name = "txWorkOrderId";
            txWorkOrderId.Size = new Size(203, 30);
            txWorkOrderId.TabIndex = 72;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label4.Location = new Point(43, 72);
            label4.Name = "label4";
            label4.Size = new Size(73, 23);
            label4.TabIndex = 68;
            label4.Text = "工单号";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(874, 69);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(300, 30);
            dtpEndDate.TabIndex = 71;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(559, 69);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(300, 30);
            dtpStartDate.TabIndex = 70;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(441, 72);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 69;
            label3.Text = "计划日期";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("华文宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(43, 153);
            label1.Name = "label1";
            label1.Size = new Size(108, 27);
            label1.TabIndex = 73;
            label1.Text = "工单清单";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 217);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1587, 354);
            dataGridView1.TabIndex = 74;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("华文宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label5.Location = new Point(43, 645);
            label5.Name = "label5";
            label5.Size = new Size(108, 27);
            label5.TabIndex = 81;
            label5.Text = "变更信息";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label6.Location = new Point(138, 730);
            label6.Name = "label6";
            label6.Size = new Size(73, 23);
            label6.TabIndex = 82;
            label6.Text = "工单号";
            // 
            // textBoxWorkOrderVersion
            // 
            textBoxWorkOrderVersion.Location = new Point(488, 725);
            textBoxWorkOrderVersion.Name = "textBoxWorkOrderVersion";
            textBoxWorkOrderVersion.Size = new Size(100, 30);
            textBoxWorkOrderVersion.TabIndex = 83;
            // 
            // textBoxWorkOrderId
            // 
            textBoxWorkOrderId.Location = new Point(256, 726);
            textBoxWorkOrderId.Name = "textBoxWorkOrderId";
            textBoxWorkOrderId.Size = new Size(203, 30);
            textBoxWorkOrderId.TabIndex = 84;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label7.Location = new Point(705, 726);
            label7.Name = "label7";
            label7.Size = new Size(115, 23);
            label7.TabIndex = 85;
            label7.Text = "工艺流程号";
            // 
            // btnChangeProcessFlow
            // 
            btnChangeProcessFlow.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnChangeProcessFlow.Location = new Point(1273, 713);
            btnChangeProcessFlow.Name = "btnChangeProcessFlow";
            btnChangeProcessFlow.Size = new Size(145, 45);
            btnChangeProcessFlow.TabIndex = 88;
            btnChangeProcessFlow.Text = "变更工艺流";
            btnChangeProcessFlow.UseVisualStyleBackColor = true;
            // 
            // textBoxProcessVersion
            // 
            textBoxProcessVersion.Location = new Point(1132, 722);
            textBoxProcessVersion.Name = "textBoxProcessVersion";
            textBoxProcessVersion.Size = new Size(119, 30);
            textBoxProcessVersion.TabIndex = 86;
            // 
            // comboBoxProcessFlow
            // 
            comboBoxProcessFlow.FormattingEnabled = true;
            comboBoxProcessFlow.Location = new Point(844, 721);
            comboBoxProcessFlow.Name = "comboBoxProcessFlow";
            comboBoxProcessFlow.Size = new Size(266, 32);
            comboBoxProcessFlow.TabIndex = 87;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label21.ForeColor = SystemColors.ButtonShadow;
            label21.Location = new Point(432, 78);
            label21.Name = "label21";
            label21.Size = new Size(15, 12);
            label21.TabIndex = 89;
            label21.Text = "●";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label8.ForeColor = SystemColors.ButtonShadow;
            label8.Location = new Point(33, 78);
            label8.Name = "label8";
            label8.Size = new Size(15, 12);
            label8.TabIndex = 90;
            label8.Text = "●";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label9.ForeColor = SystemColors.ButtonShadow;
            label9.Location = new Point(128, 736);
            label9.Name = "label9";
            label9.Size = new Size(15, 12);
            label9.TabIndex = 91;
            label9.Text = "●";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label10.ForeColor = SystemColors.ButtonShadow;
            label10.Location = new Point(694, 732);
            label10.Name = "label10";
            label10.Size = new Size(15, 12);
            label10.TabIndex = 92;
            label10.Text = "●";
            // 
            // FrmDispatchWorkOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1738, 908);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label21);
            Controls.Add(btnChangeProcessFlow);
            Controls.Add(comboBoxProcessFlow);
            Controls.Add(textBoxProcessVersion);
            Controls.Add(label7);
            Controls.Add(textBoxWorkOrderId);
            Controls.Add(textBoxWorkOrderVersion);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(txWorkOrderId);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(btnQuery);
            Controls.Add(txtDetailType);
            Controls.Add(label2);
            Name = "FrmDispatchWorkOrder";
            Text = "FrmDispatchWorkOrder";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button btnQuery;
        private TextBox txtDetailType;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePickerStartDate;
        private Label label1;
        private Label label2;
        private TextBox txWorkOrderId;
        private Label label4;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Label label3;
        private DataGridView dataGridView1;
        private Label label5;
        private Label label6;
        private TextBox textBoxWorkOrderVersion;
        private TextBox textBoxWorkOrderId;
        private Label label7;
        private Button btnChangeProcessFlow;
        private TextBox textBoxProcessVersion;
        private ComboBox comboBoxProcessFlow;
        private Label label21;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}