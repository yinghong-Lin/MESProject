namespace MDM.UI.Material
{
    partial class FrmLoadMaterial
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
            button3 = new Button();
            btnConfirm = new Button();
            txtBatchNumber = new TextBox();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            dataGridView2 = new DataGridView();
            dataGridView1 = new DataGridView();
            btnQuery = new Button();
            txtGroupNumber = new TextBox();
            textBox15 = new TextBox();
            textBox16 = new TextBox();
            txtE10Status = new TextBox();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            txtLockStatus = new TextBox();
            txtCommunicationStatus = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            txtArea = new TextBox();
            txtDeviceStatus = new TextBox();
            label9 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            txtPreviousStatus = new TextBox();
            txtDeviceType = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtDeviceNumber = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(1100, 223);
            button3.Name = "button3";
            button3.Size = new Size(63, 29);
            button3.TabIndex = 257;
            button3.Text = "取消";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(1031, 223);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(63, 29);
            btnConfirm.TabIndex = 256;
            btnConfirm.Text = "确定";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtBatchNumber
            // 
            txtBatchNumber.Location = new Point(890, 229);
            txtBatchNumber.Name = "txtBatchNumber";
            txtBatchNumber.Size = new Size(125, 27);
            txtBatchNumber.TabIndex = 255;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(800, 232);
            label20.Name = "label20";
            label20.Size = new Size(84, 20);
            label20.TabIndex = 254;
            label20.Text = "物料批次号";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(666, 232);
            label19.Name = "label19";
            label19.Size = new Size(128, 20);
            label19.TabIndex = 253;
            label19.Text = "材料LOT装载信息";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(178, 232);
            label18.Name = "label18";
            label18.Size = new Size(69, 20);
            label18.TabIndex = 252;
            label18.Text = "上料信息";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(675, 258);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(488, 260);
            dataGridView2.TabIndex = 251;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(178, 258);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(478, 260);
            dataGridView1.TabIndex = 250;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(1000, 34);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(94, 29);
            btnQuery.TabIndex = 249;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click_1;
            // 
            // txtGroupNumber
            // 
            txtGroupNumber.Location = new Point(1000, 195);
            txtGroupNumber.Name = "txtGroupNumber";
            txtGroupNumber.Size = new Size(125, 27);
            txtGroupNumber.TabIndex = 248;
            // 
            // textBox15
            // 
            textBox15.Location = new Point(1000, 160);
            textBox15.Name = "textBox15";
            textBox15.Size = new Size(125, 27);
            textBox15.TabIndex = 247;
            // 
            // textBox16
            // 
            textBox16.Location = new Point(1000, 121);
            textBox16.Name = "textBox16";
            textBox16.Size = new Size(125, 27);
            textBox16.TabIndex = 246;
            // 
            // txtE10Status
            // 
            txtE10Status.Location = new Point(1000, 79);
            txtE10Status.Name = "txtE10Status";
            txtE10Status.Size = new Size(125, 27);
            txtE10Status.TabIndex = 245;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(905, 82);
            label14.Name = "label14";
            label14.Size = new Size(65, 20);
            label14.TabIndex = 244;
            label14.Text = "E10状态";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(905, 118);
            label15.Name = "label15";
            label15.Size = new Size(69, 20);
            label15.TabIndex = 243;
            label15.Text = "原因代码";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(905, 195);
            label16.Name = "label16";
            label16.Size = new Size(69, 20);
            label16.TabIndex = 242;
            label16.Text = "设备组号";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(905, 157);
            label17.Name = "label17";
            label17.Size = new Size(54, 20);
            label17.TabIndex = 241;
            label17.Text = "程序名";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(761, 192);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(125, 27);
            textBox10.TabIndex = 240;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(761, 157);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(125, 27);
            textBox11.TabIndex = 239;
            // 
            // txtLockStatus
            // 
            txtLockStatus.Location = new Point(761, 118);
            txtLockStatus.Name = "txtLockStatus";
            txtLockStatus.Size = new Size(125, 27);
            txtLockStatus.TabIndex = 238;
            // 
            // txtCommunicationStatus
            // 
            txtCommunicationStatus.Location = new Point(761, 76);
            txtCommunicationStatus.Name = "txtCommunicationStatus";
            txtCommunicationStatus.Size = new Size(125, 27);
            txtCommunicationStatus.TabIndex = 237;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(666, 79);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 236;
            label10.Text = "通信状态";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(666, 115);
            label11.Name = "label11";
            label11.Size = new Size(69, 20);
            label11.TabIndex = 235;
            label11.Text = "锁定状态";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(666, 192);
            label12.Name = "label12";
            label12.Size = new Size(69, 20);
            label12.TabIndex = 234;
            label12.Text = "型号编号";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(666, 154);
            label13.Name = "label13";
            label13.Size = new Size(54, 20);
            label13.TabIndex = 233;
            label13.Text = "工站号";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(520, 189);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 232;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(520, 154);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(125, 27);
            textBox7.TabIndex = 231;
            // 
            // txtArea
            // 
            txtArea.Location = new Point(520, 115);
            txtArea.Name = "txtArea";
            txtArea.Size = new Size(125, 27);
            txtArea.TabIndex = 230;
            // 
            // txtDeviceStatus
            // 
            txtDeviceStatus.Location = new Point(520, 73);
            txtDeviceStatus.Name = "txtDeviceStatus";
            txtDeviceStatus.Size = new Size(125, 27);
            txtDeviceStatus.TabIndex = 229;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(425, 76);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 228;
            label9.Text = "设备状态";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(272, 189);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 227;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(272, 154);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 226;
            // 
            // txtPreviousStatus
            // 
            txtPreviousStatus.Location = new Point(272, 115);
            txtPreviousStatus.Name = "txtPreviousStatus";
            txtPreviousStatus.Size = new Size(125, 27);
            txtPreviousStatus.TabIndex = 225;
            // 
            // txtDeviceType
            // 
            txtDeviceType.Location = new Point(272, 73);
            txtDeviceType.Name = "txtDeviceType";
            txtDeviceType.Size = new Size(125, 27);
            txtDeviceType.TabIndex = 224;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(167, 115);
            label8.Name = "label8";
            label8.Size = new Size(99, 20);
            label8.TabIndex = 223;
            label8.Text = "先前设备状态";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(178, 154);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 222;
            label7.Text = "产品编号";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(178, 189);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 221;
            label6.Text = "批次号";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(425, 112);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 220;
            label5.Text = "区域";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(425, 189);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 219;
            label4.Text = "载具号";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(425, 151);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 218;
            label3.Text = "工艺流程号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(178, 76);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 217;
            label2.Text = "设备类型";
            // 
            // txtDeviceNumber
            // 
            txtDeviceNumber.Location = new Point(242, 38);
            txtDeviceNumber.Name = "txtDeviceNumber";
            txtDeviceNumber.Size = new Size(125, 27);
            txtDeviceNumber.TabIndex = 216;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(178, 38);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 215;
            label1.Text = "设备号";
            // 
            // FrmLoadMaterial
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 552);
            Controls.Add(button3);
            Controls.Add(btnConfirm);
            Controls.Add(txtBatchNumber);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(btnQuery);
            Controls.Add(txtGroupNumber);
            Controls.Add(textBox15);
            Controls.Add(textBox16);
            Controls.Add(txtE10Status);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(label17);
            Controls.Add(textBox10);
            Controls.Add(textBox11);
            Controls.Add(txtLockStatus);
            Controls.Add(txtCommunicationStatus);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(textBox6);
            Controls.Add(textBox7);
            Controls.Add(txtArea);
            Controls.Add(txtDeviceStatus);
            Controls.Add(label9);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(txtPreviousStatus);
            Controls.Add(txtDeviceType);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtDeviceNumber);
            Controls.Add(label1);
            Name = "FrmLoadMaterial";
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button btnConfirm;
        private TextBox txtBatchNumber;
        private Label label20;
        private Label label19;
        private Label label18;
        private DataGridView dataGridView2;
        private DataGridView dataGridView1;
        private Button btnQuery;
        private TextBox txtGroupNumber;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox txtE10Status;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox txtLockStatus;
        private TextBox txtCommunicationStatus;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox txtArea;
        private TextBox txtDeviceStatus;
        private Label label9;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox txtPreviousStatus;
        private TextBox txtDeviceType;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtDeviceNumber;
        private Label label1;
    }
}