namespace MDM.UI.Batch
{
    partial class FrmCancelCreateBatch
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
            label5 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            button2 = new Button();
            textBox3 = new TextBox();
            label7 = new Label();
            textBox2 = new TextBox();
            label8 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonShadow;
            label5.Location = new Point(27, 25);
            label5.Name = "label5";
            label5.Size = new Size(19, 20);
            label5.TabIndex = 16;
            label5.Text = "●";
            label5.Click += label5_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1114, 17);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 15;
            button1.Text = "查询";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(105, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(174, 27);
            textBox1.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 26);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 13;
            label1.Text = "批次号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 77);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 17;
            label2.Text = "主界面";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1181, 240);
            dataGridView1.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Location = new Point(318, 26);
            label3.Name = "label3";
            label3.Size = new Size(19, 20);
            label3.TabIndex = 20;
            label3.Text = "●";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(336, 26);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 19;
            label4.Text = "创建日期";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(569, 26);
            label6.Name = "label6";
            label6.Size = new Size(20, 20);
            label6.TabIndex = 23;
            label6.Text = "~";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(1096, 360);
            button2.Name = "button2";
            button2.Size = new Size(112, 29);
            button2.TabIndex = 24;
            button2.Text = "取消创建批次";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(241, 74);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(70, 27);
            textBox3.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label7.ForeColor = Color.DarkBlue;
            label7.Location = new Point(151, 78);
            label7.Name = "label7";
            label7.Size = new Size(84, 19);
            label7.TabIndex = 25;
            label7.Text = "已选批次数";
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(410, 74);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(70, 27);
            textBox2.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label8.ForeColor = Color.DarkBlue;
            label8.Location = new Point(335, 78);
            label8.Name = "label8";
            label8.Size = new Size(69, 19);
            label8.TabIndex = 27;
            label8.Text = "选中数量";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(424, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(139, 27);
            dateTimePicker1.TabIndex = 29;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(595, 23);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(139, 27);
            dateTimePicker2.TabIndex = 30;
            // 
            // FrmCancelCreateBatch
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 401);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(label8);
            Controls.Add(textBox3);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "FrmCancelCreateBatch";
            Text = "FrmCancelCreateBatch";
            Load += FrmCancelCreateBatch_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label4;
        private Label label6;
        private Button button2;
        private TextBox textBox3;
        private Label label7;
        private TextBox textBox2;
        private Label label8;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
    }
}