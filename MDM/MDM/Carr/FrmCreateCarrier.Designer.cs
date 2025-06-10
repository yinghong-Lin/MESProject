namespace MDM.UI.Carr
{
    partial class FrmCreateCarrier
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
            splitContainer1 = new SplitContainer();
            dataGridViewDurables = new DataGridView();
            dataGridViewCarriers = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            comboBox1 = new ComboBox();
            label16 = new Label();
            label17 = new Label();
            numericUpDown1 = new NumericUpDown();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            textBox7 = new TextBox();
            clearbtn = new Button();
            createbtn = new Button();
            createInfoPanel = new Panel();
            label18 = new Label();
            label19 = new Label();
            textBox8 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label20 = new Label();
            btnSearch = new Button();
            txtDurableId = new TextBox();
            label3 = new Label();
            txtCarrierType = new TextBox();
            label2 = new Label();
            txtCarrierNo = new TextBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDurables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            createInfoPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(48, 145);
            splitContainer1.Margin = new Padding(5, 6, 5, 6);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewDurables);
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewCarriers);
            splitContainer1.Size = new Size(1395, 482);
            splitContainer1.SplitterDistance = 522;
            splitContainer1.SplitterWidth = 7;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewDurables
            // 
            dataGridViewDurables.AllowUserToAddRows = false;
            dataGridViewDurables.AllowUserToDeleteRows = false;
            dataGridViewDurables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDurables.Dock = DockStyle.Top;
            dataGridViewDurables.Location = new Point(0, 0);
            dataGridViewDurables.Margin = new Padding(5, 6, 5, 6);
            dataGridViewDurables.Name = "dataGridViewDurables";
            dataGridViewDurables.ReadOnly = true;
            dataGridViewDurables.RowHeadersWidth = 51;
            dataGridViewDurables.RowTemplate.Height = 24;
            dataGridViewDurables.Size = new Size(522, 506);
            dataGridViewDurables.TabIndex = 0;
            dataGridViewDurables.SelectionChanged += dataGridViewDurables_SelectionChanged;
            // 
            // dataGridViewCarriers
            // 
            dataGridViewCarriers.AllowUserToAddRows = false;
            dataGridViewCarriers.AllowUserToDeleteRows = false;
            dataGridViewCarriers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarriers.Dock = DockStyle.Top;
            dataGridViewCarriers.Location = new Point(0, 0);
            dataGridViewCarriers.Name = "dataGridViewCarriers";
            dataGridViewCarriers.ReadOnly = true;
            dataGridViewCarriers.RowHeadersWidth = 51;
            dataGridViewCarriers.RowTemplate.Height = 24;
            dataGridViewCarriers.Size = new Size(866, 506);
            dataGridViewCarriers.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 31);
            label4.Name = "label4";
            label4.Size = new Size(158, 31);
            label4.TabIndex = 2;
            label4.Text = "耐用品规格号";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 87);
            label5.Name = "label5";
            label5.Size = new Size(110, 31);
            label5.TabIndex = 3;
            label5.Text = "载具类型";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 145);
            label6.Name = "label6";
            label6.Size = new Size(158, 31);
            label6.TabIndex = 4;
            label6.Text = "最大使用次数";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 212);
            label7.Name = "label7";
            label7.Size = new Size(158, 31);
            label7.TabIndex = 5;
            label7.Text = "最大清洗次数";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 270);
            label8.Name = "label8";
            label8.Size = new Size(62, 31);
            label8.TabIndex = 6;
            label8.Text = "容量";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(516, 88);
            label9.Name = "label9";
            label9.Size = new Size(86, 31);
            label9.TabIndex = 7;
            label9.Text = "位置号";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(209, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(253, 38);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ScrollBar;
            textBox2.Location = new Point(484, 29);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(373, 38);
            textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ScrollBar;
            textBox3.Location = new Point(209, 80);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(253, 38);
            textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.BackColor = SystemColors.ScrollBar;
            textBox4.Location = new Point(209, 145);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(253, 38);
            textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.ScrollBar;
            textBox5.Location = new Point(209, 209);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(253, 38);
            textBox5.TabIndex = 12;
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.ScrollBar;
            textBox6.Location = new Point(209, 270);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(253, 38);
            textBox6.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(493, 93);
            label10.Name = "label10";
            label10.Size = new Size(25, 31);
            label10.TabIndex = 14;
            label10.Text = "*";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 92);
            label11.Name = "label11";
            label11.Size = new Size(25, 31);
            label11.TabIndex = 15;
            label11.Text = "*";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 37);
            label12.Name = "label12";
            label12.Size = new Size(25, 31);
            label12.TabIndex = 16;
            label12.Text = "*";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 151);
            label13.Name = "label13";
            label13.Size = new Size(25, 31);
            label13.TabIndex = 17;
            label13.Text = "*";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 218);
            label14.Name = "label14";
            label14.Size = new Size(25, 31);
            label14.TabIndex = 18;
            label14.Text = "*";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 276);
            label15.Name = "label15";
            label15.Size = new Size(25, 31);
            label15.TabIndex = 19;
            label15.Text = "*";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(651, 85);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(206, 39);
            comboBox1.TabIndex = 20;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(48, 108);
            label16.Name = "label16";
            label16.Size = new Size(134, 31);
            label16.TabIndex = 21;
            label16.Text = "耐用品清单";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(577, 108);
            label17.Name = "label17";
            label17.Size = new Size(110, 31);
            label17.TabIndex = 22;
            label17.Text = "载具清单";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(653, 145);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(205, 38);
            numericUpDown1.TabIndex = 23;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(493, 150);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(141, 35);
            radioButton1.TabIndex = 25;
            radioButton1.TabStop = true;
            radioButton1.Text = "创建数量";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(493, 214);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(117, 35);
            radioButton2.TabIndex = 26;
            radioButton2.TabStop = true;
            radioButton2.Text = "载具号";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.ScrollBar;
            textBox7.Location = new Point(653, 212);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(204, 38);
            textBox7.TabIndex = 27;
            // 
            // clearbtn
            // 
            clearbtn.BackColor = SystemColors.HotTrack;
            clearbtn.ForeColor = SystemColors.ButtonFace;
            clearbtn.Location = new Point(532, 271);
            clearbtn.Name = "clearbtn";
            clearbtn.Size = new Size(150, 46);
            clearbtn.TabIndex = 28;
            clearbtn.Text = "清空";
            clearbtn.UseVisualStyleBackColor = false;
            // 
            // createbtn
            // 
            createbtn.BackColor = SystemColors.HotTrack;
            createbtn.ForeColor = SystemColors.ButtonFace;
            createbtn.Location = new Point(707, 270);
            createbtn.Name = "createbtn";
            createbtn.Size = new Size(150, 46);
            createbtn.TabIndex = 29;
            createbtn.Text = "生成";
            createbtn.UseVisualStyleBackColor = false;
            // 
            // createInfoPanel
            // 
            createInfoPanel.Controls.Add(label9);
            createInfoPanel.Controls.Add(createbtn);
            createInfoPanel.Controls.Add(label4);
            createInfoPanel.Controls.Add(clearbtn);
            createInfoPanel.Controls.Add(label5);
            createInfoPanel.Controls.Add(textBox7);
            createInfoPanel.Controls.Add(label6);
            createInfoPanel.Controls.Add(radioButton2);
            createInfoPanel.Controls.Add(label7);
            createInfoPanel.Controls.Add(radioButton1);
            createInfoPanel.Controls.Add(label8);
            createInfoPanel.Controls.Add(numericUpDown1);
            createInfoPanel.Controls.Add(textBox1);
            createInfoPanel.Controls.Add(textBox2);
            createInfoPanel.Controls.Add(textBox3);
            createInfoPanel.Controls.Add(comboBox1);
            createInfoPanel.Controls.Add(textBox4);
            createInfoPanel.Controls.Add(label15);
            createInfoPanel.Controls.Add(textBox5);
            createInfoPanel.Controls.Add(label14);
            createInfoPanel.Controls.Add(textBox6);
            createInfoPanel.Controls.Add(label13);
            createInfoPanel.Controls.Add(label10);
            createInfoPanel.Controls.Add(label12);
            createInfoPanel.Controls.Add(label11);
            createInfoPanel.Location = new Point(53, 678);
            createInfoPanel.Name = "createInfoPanel";
            createInfoPanel.Size = new Size(942, 326);
            createInfoPanel.TabIndex = 30;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(74, 1025);
            label18.Name = "label18";
            label18.Size = new Size(62, 31);
            label18.TabIndex = 30;
            label18.Text = "备注";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ForeColor = Color.IndianRed;
            label19.Location = new Point(52, 1032);
            label19.Name = "label19";
            label19.Size = new Size(25, 31);
            label19.TabIndex = 31;
            label19.Text = "*";
            // 
            // textBox8
            // 
            textBox8.BackColor = SystemColors.Window;
            textBox8.Location = new Point(183, 1025);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(877, 38);
            textBox8.TabIndex = 30;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(1277, 1020);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 31;
            button1.Text = "退出";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.HotTrack;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(1102, 1021);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 30;
            button2.Text = "确定";
            button2.UseVisualStyleBackColor = false;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(54, 644);
            label20.Name = "label20";
            label20.Size = new Size(110, 31);
            label20.TabIndex = 32;
            label20.Text = "创建信息";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.HotTrack;
            btnSearch.ForeColor = SystemColors.ButtonFace;
            btnSearch.Location = new Point(953, 6);
            btnSearch.Margin = new Padding(5, 6, 5, 6);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(131, 48);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtDurableId
            // 
            txtDurableId.Location = new Point(771, 6);
            txtDurableId.Margin = new Padding(5, 6, 5, 6);
            txtDurableId.Name = "txtDurableId";
            txtDurableId.ReadOnly = true;
            txtDurableId.Size = new Size(172, 38);
            txtDurableId.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(597, 0);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(164, 31);
            label3.TabIndex = 17;
            label3.Text = "耐用品规格号:";
            // 
            // txtCarrierType
            // 
            txtCarrierType.Location = new Point(415, 6);
            txtCarrierType.Margin = new Padding(5, 6, 5, 6);
            txtCarrierType.Name = "txtCarrierType";
            txtCarrierType.Size = new Size(172, 38);
            txtCarrierType.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(289, 0);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(116, 31);
            label2.TabIndex = 9;
            label2.Text = "载具类型:";
            // 
            // txtCarrierNo
            // 
            txtCarrierNo.Location = new Point(107, 6);
            txtCarrierNo.Margin = new Padding(5, 6, 5, 6);
            txtCarrierNo.Name = "txtCarrierNo";
            txtCarrierNo.Size = new Size(172, 38);
            txtCarrierNo.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 31);
            label1.TabIndex = 8;
            label1.Text = "载具号:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(txtCarrierNo);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(txtCarrierType);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(txtDurableId);
            flowLayoutPanel1.Controls.Add(btnSearch);
            flowLayoutPanel1.Location = new Point(48, 10);
            flowLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1335, 65);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // FrmCreateCarrier
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1520, 1103);
            Controls.Add(label20);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBox8);
            Controls.Add(label18);
            Controls.Add(label19);
            Controls.Add(createInfoPanel);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(splitContainer1);
            Controls.Add(flowLayoutPanel1);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmCreateCarrier";
            Text = "载具管理";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDurables).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            createInfoPanel.ResumeLayout(false);
            createInfoPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewCarriers;
        private System.Windows.Forms.DataGridView dataGridViewDurables;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private ComboBox comboBox1;
        private Label label16;
        private Label label17;
        private NumericUpDown numericUpDown1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox7;
        private Button clearbtn;
        private Button createbtn;
        private Panel createInfoPanel;
        private Label label18;
        private Label label19;
        private TextBox textBox8;
        private Button button1;
        private Button button2;
        private Label label20;
        private Button btnSearch;
        private TextBox txtDurableId;
        private Label label3;
        private TextBox txtCarrierType;
        private Label label2;
        private TextBox txtCarrierNo;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}