// MDM.UI/Carr/FrmCarrier.Designer.cs

namespace MDM.UI.Carr
{
    partial class FrmCarrier
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewCarriers = new DataGridView();
            panel1 = new Panel();
            SearchBtn = new Button();
            label6 = new Label();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtCarrierNumber = new TextBox();
            carrierNotxt = new Label();
            comboBoxCapacityStatus = new ComboBox();
            label3 = new Label();
            comboBoxCarrierStatus = new ComboBox();
            carrierStatustxt = new Label();
            comboBoxDurableItemSpec = new ComboBox();
            durableIdtxt = new Label();
            comboBoxCleaningStatus = new ComboBox();
            comboBoxCarrierType = new ComboBox();
            cleaningStatustxt = new Label();
            carrierTypetxt = new Label();
            carrierList = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewCarriers
            // 
            dataGridViewCarriers.AllowUserToAddRows = false;
            dataGridViewCarriers.AllowUserToDeleteRows = false;
            dataGridViewCarriers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarriers.Location = new Point(0, 234);
            dataGridViewCarriers.Name = "dataGridViewCarriers";
            dataGridViewCarriers.ReadOnly = true;
            dataGridViewCarriers.RowHeadersWidth = 82;
            dataGridViewCarriers.RowTemplate.Height = 24;
            dataGridViewCarriers.Size = new Size(1629, 791);
            dataGridViewCarriers.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(SearchBtn);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtCarrierNumber);
            panel1.Controls.Add(carrierNotxt);
            panel1.Controls.Add(comboBoxCapacityStatus);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(comboBoxCarrierStatus);
            panel1.Controls.Add(carrierStatustxt);
            panel1.Controls.Add(comboBoxDurableItemSpec);
            panel1.Controls.Add(durableIdtxt);
            panel1.Controls.Add(comboBoxCleaningStatus);
            panel1.Controls.Add(comboBoxCarrierType);
            panel1.Controls.Add(cleaningStatustxt);
            panel1.Controls.Add(carrierTypetxt);
            panel1.Location = new Point(1, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1634, 141);
            panel1.TabIndex = 1;
            // 
            // SearchBtn
            // 
            SearchBtn.BackColor = SystemColors.HotTrack;
            SearchBtn.ForeColor = SystemColors.HighlightText;
            SearchBtn.Location = new Point(1477, 72);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(139, 60);
            SearchBtn.TabIndex = 18;
            SearchBtn.Text = "查询";
            SearchBtn.UseVisualStyleBackColor = false;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1005, 96);
            label6.Name = "label6";
            label6.Size = new Size(27, 36);
            label6.TabIndex = 17;
            label6.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1005, 17);
            label7.Name = "label7";
            label7.Size = new Size(27, 36);
            label7.TabIndex = 16;
            label7.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(475, 95);
            label4.Name = "label4";
            label4.Size = new Size(27, 36);
            label4.TabIndex = 15;
            label4.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(475, 16);
            label5.Name = "label5";
            label5.Size = new Size(27, 36);
            label5.TabIndex = 14;
            label5.Text = "*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 95);
            label2.Name = "label2";
            label2.Size = new Size(27, 36);
            label2.TabIndex = 13;
            label2.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(24, 16);
            label1.Name = "label1";
            label1.Size = new Size(27, 36);
            label1.TabIndex = 12;
            label1.Text = "*";
            // 
            // txtCarrierNumber
            // 
            txtCarrierNumber.Location = new Point(1179, 88);
            txtCarrierNumber.Name = "txtCarrierNumber";
            txtCarrierNumber.Size = new Size(241, 44);
            txtCarrierNumber.TabIndex = 11;
            // 
            // carrierNotxt
            // 
            carrierNotxt.AutoSize = true;
            carrierNotxt.Location = new Point(1026, 91);
            carrierNotxt.Name = "carrierNotxt";
            carrierNotxt.Size = new Size(111, 36);
            carrierNotxt.TabIndex = 10;
            carrierNotxt.Text = "载具号";
            // 
            // comboBoxCapacityStatus
            // 
            comboBoxCapacityStatus.FormattingEnabled = true;
            comboBoxCapacityStatus.Location = new Point(1179, 6);
            comboBoxCapacityStatus.Name = "comboBoxCapacityStatus";
            comboBoxCapacityStatus.Size = new Size(241, 44);
            comboBoxCapacityStatus.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1025, 9);
            label3.Name = "label3";
            label3.Size = new Size(143, 36);
            label3.TabIndex = 8;
            label3.Text = "容量状态";
            // 
            // comboBoxCarrierStatus
            // 
            comboBoxCarrierStatus.FormattingEnabled = true;
            comboBoxCarrierStatus.Location = new Point(730, 87);
            comboBoxCarrierStatus.Name = "comboBoxCarrierStatus";
            comboBoxCarrierStatus.Size = new Size(241, 44);
            comboBoxCarrierStatus.TabIndex = 7;
            // 
            // carrierStatustxt
            // 
            carrierStatustxt.AutoSize = true;
            carrierStatustxt.Location = new Point(496, 90);
            carrierStatustxt.Name = "carrierStatustxt";
            carrierStatustxt.Size = new Size(143, 36);
            carrierStatustxt.TabIndex = 6;
            carrierStatustxt.Text = "载具状态";
            // 
            // comboBoxDurableItemSpec
            // 
            comboBoxDurableItemSpec.FormattingEnabled = true;
            comboBoxDurableItemSpec.Location = new Point(730, 10);
            comboBoxDurableItemSpec.Name = "comboBoxDurableItemSpec";
            comboBoxDurableItemSpec.Size = new Size(241, 44);
            comboBoxDurableItemSpec.TabIndex = 5;
            // 
            // durableIdtxt
            // 
            durableIdtxt.AutoSize = true;
            durableIdtxt.Location = new Point(496, 13);
            durableIdtxt.Name = "durableIdtxt";
            durableIdtxt.Size = new Size(207, 36);
            durableIdtxt.TabIndex = 4;
            durableIdtxt.Text = "耐用品规格号";
            // 
            // comboBoxCleaningStatus
            // 
            comboBoxCleaningStatus.FormattingEnabled = true;
            comboBoxCleaningStatus.Location = new Point(213, 87);
            comboBoxCleaningStatus.Name = "comboBoxCleaningStatus";
            comboBoxCleaningStatus.Size = new Size(241, 44);
            comboBoxCleaningStatus.TabIndex = 3;
            // 
            // comboBoxCarrierType
            // 
            comboBoxCarrierType.FormattingEnabled = true;
            comboBoxCarrierType.Location = new Point(213, 8);
            comboBoxCarrierType.Name = "comboBoxCarrierType";
            comboBoxCarrierType.Size = new Size(241, 44);
            comboBoxCarrierType.TabIndex = 2;
            // 
            // cleaningStatustxt
            // 
            cleaningStatustxt.AutoSize = true;
            cleaningStatustxt.Location = new Point(47, 90);
            cleaningStatustxt.Name = "cleaningStatustxt";
            cleaningStatustxt.Size = new Size(143, 36);
            cleaningStatustxt.TabIndex = 1;
            cleaningStatustxt.Text = "清洗状态";
            // 
            // carrierTypetxt
            // 
            carrierTypetxt.AutoSize = true;
            carrierTypetxt.Location = new Point(47, 8);
            carrierTypetxt.Name = "carrierTypetxt";
            carrierTypetxt.Size = new Size(143, 36);
            carrierTypetxt.TabIndex = 0;
            carrierTypetxt.Text = "载具类型";
            // 
            // carrierList
            // 
            carrierList.AutoSize = true;
            carrierList.Font = new Font("等线", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            carrierList.Location = new Point(12, 172);
            carrierList.Name = "carrierList";
            carrierList.Size = new Size(143, 33);
            carrierList.TabIndex = 19;
            carrierList.Text = "载具清单";
            // 
            // FrmCarrier
            // 
            AutoScaleDimensions = new SizeF(18F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1629, 1025);
            Controls.Add(carrierList);
            Controls.Add(panel1);
            Controls.Add(dataGridViewCarriers);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 6, 5, 6);
            Name = "FrmCarrier";
            Text = "载具管理";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarriers).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewCarriers;
        private Panel panel1;
        private ComboBox comboBoxDurableItemSpec;
        private Label durableIdtxt;
        private ComboBox comboBoxCleaningStatus;
        private ComboBox comboBoxCarrierType;
        private Label cleaningStatustxt;
        private Label carrierTypetxt;
        private ComboBox comboBoxCarrierStatus;
        private Label carrierStatustxt;
        private TextBox txtCarrierNumber;
        private Label carrierNotxt;
        private ComboBox comboBoxCapacityStatus;
        private Label label3;
        private Label label1;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label5;
        private Label label2;
        private Button SearchBtn;
        private Label carrierList;
    }
}