namespace MDM.UI.WorkOrders
{
    partial class FrmCancelWorkOrder
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
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            txtDetailType = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            txtUserNumber = new TextBox();
            txtRemark = new TextBox();
            button6 = new Button();
            btnConfirm = new Button();
            label19 = new Label();
            label18 = new Label();
            btnQuery = new Button();
            label25 = new Label();
            label5 = new Label();
            label21 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(55, 221);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1587, 354);
            dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.Location = new Point(65, 61);
            label2.Name = "label2";
            label2.Size = new Size(73, 23);
            label2.TabIndex = 2;
            label2.Text = "工单号";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(802, 56);
            label1.Name = "label1";
            label1.Size = new Size(94, 23);
            label1.TabIndex = 3;
            label1.Text = "计划日期";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(401, 59);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 4;
            label3.Text = "产品编号";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(920, 53);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(300, 30);
            dateTimePickerStart.TabIndex = 49;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(1235, 53);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(300, 30);
            dateTimePickerEnd.TabIndex = 50;
            // 
            // txtDetailType
            // 
            txtDetailType.Location = new Point(160, 57);
            txtDetailType.Name = "txtDetailType";
            txtDetailType.Size = new Size(203, 30);
            txtDetailType.TabIndex = 51;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(525, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(217, 30);
            textBox1.TabIndex = 52;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("华文宋体", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label4.Location = new Point(40, 138);
            label4.Name = "label4";
            label4.Size = new Size(108, 27);
            label4.TabIndex = 53;
            label4.Text = "工单清单";
            // 
            // txtUserNumber
            // 
            txtUserNumber.Location = new Point(1034, 687);
            txtUserNumber.Name = "txtUserNumber";
            txtUserNumber.Size = new Size(190, 30);
            txtUserNumber.TabIndex = 60;
            // 
            // txtRemark
            // 
            txtRemark.Location = new Point(135, 686);
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new Size(700, 30);
            txtRemark.TabIndex = 59;
            // 
            // button6
            // 
            button6.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button6.Location = new Point(1494, 681);
            button6.Name = "button6";
            button6.Size = new Size(112, 45);
            button6.TabIndex = 58;
            button6.Text = "取消";
            button6.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnConfirm.Location = new Point(1339, 681);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(112, 45);
            btnConfirm.TabIndex = 57;
            btnConfirm.Text = "确认";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label19.Location = new Point(888, 691);
            label19.Name = "label19";
            label19.Size = new Size(94, 23);
            label19.TabIndex = 56;
            label19.Text = "用户编号";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("华文宋体", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label18.Location = new Point(77, 686);
            label18.Name = "label18";
            label18.Size = new Size(52, 23);
            label18.TabIndex = 55;
            label18.Text = "备注";
            // 
            // btnQuery
            // 
            btnQuery.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnQuery.Location = new Point(1572, 49);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(112, 45);
            btnQuery.TabIndex = 61;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label25.ForeColor = Color.Red;
            label25.Location = new Point(878, 695);
            label25.Name = "label25";
            label25.Size = new Size(15, 12);
            label25.TabIndex = 62;
            label25.Text = "●";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(66, 692);
            label5.Name = "label5";
            label5.Size = new Size(15, 12);
            label5.TabIndex = 63;
            label5.Text = "●";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label21.ForeColor = SystemColors.ButtonShadow;
            label21.Location = new Point(391, 64);
            label21.Name = "label21";
            label21.Size = new Size(15, 12);
            label21.TabIndex = 64;
            label21.Text = "●";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label6.ForeColor = SystemColors.ButtonShadow;
            label6.Location = new Point(55, 67);
            label6.Name = "label6";
            label6.Size = new Size(15, 12);
            label6.TabIndex = 65;
            label6.Text = "●";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("华文宋体", 4.99999952F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label7.ForeColor = SystemColors.ButtonShadow;
            label7.Location = new Point(792, 61);
            label7.Name = "label7";
            label7.Size = new Size(15, 12);
            label7.TabIndex = 66;
            label7.Text = "●";
            // 
            // FrmCancelWorkOrder
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1711, 819);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label21);
            Controls.Add(label5);
            Controls.Add(label25);
            Controls.Add(btnQuery);
            Controls.Add(txtUserNumber);
            Controls.Add(txtRemark);
            Controls.Add(button6);
            Controls.Add(btnConfirm);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(txtDetailType);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Name = "FrmCancelWorkOrder";
            Text = "FrmCancelWorkOrder";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
        private Label label3;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private TextBox txtDetailType;
        private TextBox textBox1;
        private Label label4;
        private TextBox txtUserNumber;
        private TextBox txtRemark;
        private Button button6;
        private Button btnConfirm;
        private Label label19;
        private Label label18;
        private Button btnQuery;
        private Label label25;
        private Label label5;
        private Label label21;
        private Label label6;
        private Label label7;
    }
}