namespace VersionOfProject
{
    partial class CasherForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CasherForm));
            DrinkPanel = new Panel();
            FoodPanal = new Panel();
            BillGV = new DataGridView();
            pname = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            BillPanel = new Panel();
            DisplayLableTotal = new Label();
            label1 = new Label();
            Btn_Rmove = new Button();
            Btn_Cancel = new Button();
            Btn_Save = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button16 = new Button();
            button1 = new Button();
            button2 = new Button();
            DrinkCategory = new Panel();
            FoodCategory = new Panel();
            label5 = new Label();
            AllDrinks = new Button();
            AllFoods = new Button();
            panel1 = new Panel();
            WelecomLabel = new Label();
            label6 = new Label();
            pictureBox7 = new PictureBox();
            button11 = new Button();
            button5 = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            ((System.ComponentModel.ISupportInitialize)BillGV).BeginInit();
            BillPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // DrinkPanel
            // 
            DrinkPanel.BackColor = Color.Tan;
            DrinkPanel.Location = new Point(26, 381);
            DrinkPanel.Name = "DrinkPanel";
            DrinkPanel.Size = new Size(501, 500);
            DrinkPanel.TabIndex = 0;
            // 
            // FoodPanal
            // 
            FoodPanal.BackColor = Color.Tan;
            FoodPanal.Location = new Point(665, 436);
            FoodPanal.Name = "FoodPanal";
            FoodPanal.Size = new Size(501, 500);
            FoodPanal.TabIndex = 1;
            // 
            // BillGV
            // 
            BillGV.BackgroundColor = Color.Tan;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Tan;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            BillGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            BillGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BillGV.Columns.AddRange(new DataGridViewColumn[] { pname, Price, Amount, Total });
            BillGV.Location = new Point(3, 3);
            BillGV.Name = "BillGV";
            BillGV.RowHeadersWidth = 51;
            BillGV.RowTemplate.Height = 29;
            BillGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BillGV.Size = new Size(536, 447);
            BillGV.TabIndex = 2;
            // 
            // pname
            // 
            pname.HeaderText = "Name";
            pname.MinimumWidth = 6;
            pname.Name = "pname";
            pname.Width = 83;
            // 
            // Price
            // 
            Price.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Price.HeaderText = " unite Price ";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            // 
            // Amount
            // 
            Amount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Amount.HeaderText = "Amount";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            // 
            // Total
            // 
            Total.HeaderText = "total price";
            Total.MinimumWidth = 6;
            Total.Name = "Total";
            Total.Width = 125;
            // 
            // BillPanel
            // 
            BillPanel.BackColor = Color.Tan;
            BillPanel.Controls.Add(BillGV);
            BillPanel.Controls.Add(DisplayLableTotal);
            BillPanel.Controls.Add(label1);
            BillPanel.Controls.Add(Btn_Rmove);
            BillPanel.Controls.Add(Btn_Cancel);
            BillPanel.Controls.Add(Btn_Save);
            BillPanel.Location = new Point(60, 155);
            BillPanel.Name = "BillPanel";
            BillPanel.Size = new Size(536, 726);
            BillPanel.TabIndex = 2;
            // 
            // DisplayLableTotal
            // 
            DisplayLableTotal.AutoSize = true;
            DisplayLableTotal.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            DisplayLableTotal.Location = new Point(197, 515);
            DisplayLableTotal.Name = "DisplayLableTotal";
            DisplayLableTotal.Size = new Size(49, 31);
            DisplayLableTotal.TabIndex = 5;
            DisplayLableTotal.Text = "0,0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(29, 514);
            label1.Name = "label1";
            label1.Size = new Size(170, 31);
            label1.TabIndex = 4;
            label1.Text = "Total Recet : ";
            // 
            // Btn_Rmove
            // 
            Btn_Rmove.BackColor = Color.FromArgb(159, 111, 79);
            Btn_Rmove.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Rmove.Location = new Point(29, 559);
            Btn_Rmove.Name = "Btn_Rmove";
            Btn_Rmove.Size = new Size(494, 44);
            Btn_Rmove.TabIndex = 3;
            Btn_Rmove.Text = "Remove Item From Bil";
            Btn_Rmove.UseVisualStyleBackColor = false;
            Btn_Rmove.Click += Btn_Rmove_Click;
            // 
            // Btn_Cancel
            // 
            Btn_Cancel.BackColor = Color.FromArgb(159, 111, 79);
            Btn_Cancel.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Cancel.Location = new Point(278, 608);
            Btn_Cancel.Name = "Btn_Cancel";
            Btn_Cancel.Size = new Size(245, 49);
            Btn_Cancel.TabIndex = 1;
            Btn_Cancel.Text = "Cancel";
            Btn_Cancel.UseVisualStyleBackColor = false;
            Btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // Btn_Save
            // 
            Btn_Save.BackColor = Color.FromArgb(159, 111, 79);
            Btn_Save.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Save.Location = new Point(29, 609);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(242, 49);
            Btn_Save.TabIndex = 0;
            Btn_Save.TabStop = false;
            Btn_Save.Text = "Save";
            Btn_Save.UseVisualStyleBackColor = false;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(131, 36);
            label2.Name = "label2";
            label2.Size = new Size(150, 51);
            label2.TabIndex = 4;
            label2.Text = "Drinks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(729, 94);
            label3.Name = "label3";
            label3.Size = new Size(133, 51);
            label3.TabIndex = 5;
            label3.Text = "Foods";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(232, 42);
            label4.Name = "label4";
            label4.Size = new Size(99, 51);
            label4.TabIndex = 6;
            label4.Text = "Bill ";
            // 
            // button16
            // 
            button16.BackgroundImage = (Image)resources.GetObject("button16.BackgroundImage");
            button16.BackgroundImageLayout = ImageLayout.Stretch;
            button16.Location = new Point(910, 94);
            button16.Margin = new Padding(3, 4, 3, 4);
            button16.Name = "button16";
            button16.Size = new Size(51, 64);
            button16.TabIndex = 20;
            button16.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.icon;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(308, 23);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(51, 64);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.dnanner;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(364, 36);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(51, 64);
            button2.TabIndex = 21;
            button2.UseVisualStyleBackColor = true;
            // 
            // DrinkCategory
            // 
            DrinkCategory.AutoScroll = true;
            DrinkCategory.Location = new Point(145, 190);
            DrinkCategory.Name = "DrinkCategory";
            DrinkCategory.Size = new Size(214, 164);
            DrinkCategory.TabIndex = 22;
            // 
            // FoodCategory
            // 
            FoodCategory.AutoScroll = true;
            FoodCategory.Location = new Point(729, 245);
            FoodCategory.Name = "FoodCategory";
            FoodCategory.Size = new Size(214, 164);
            FoodCategory.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(387, 15);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 24;
            label5.Text = "Category";
            // 
            // AllDrinks
            // 
            AllDrinks.BackColor = Color.Tan;
            AllDrinks.Location = new Point(181, 131);
            AllDrinks.Name = "AllDrinks";
            AllDrinks.Size = new Size(128, 53);
            AllDrinks.TabIndex = 25;
            AllDrinks.Text = "All Drinks ";
            AllDrinks.UseVisualStyleBackColor = false;
            AllDrinks.Click += AllDrinks_Click;
            // 
            // AllFoods
            // 
            AllFoods.BackColor = Color.Tan;
            AllFoods.Location = new Point(764, 186);
            AllFoods.Name = "AllFoods";
            AllFoods.Size = new Size(128, 53);
            AllFoods.TabIndex = 26;
            AllFoods.Text = "All Foods";
            AllFoods.UseVisualStyleBackColor = false;
            AllFoods.Click += AllCategoryDrink_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.SaddleBrown;
            panel1.Controls.Add(WelecomLabel);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(pictureBox7);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(button5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 60);
            panel1.TabIndex = 27;
            panel1.Paint += panel1_Paint;
            // 
            // WelecomLabel
            // 
            WelecomLabel.AutoSize = true;
            WelecomLabel.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            WelecomLabel.ForeColor = Color.Transparent;
            WelecomLabel.Location = new Point(962, 15);
            WelecomLabel.Name = "WelecomLabel";
            WelecomLabel.Size = new Size(0, 25);
            WelecomLabel.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(45, 7);
            label6.Name = "label6";
            label6.Size = new Size(150, 38);
            label6.TabIndex = 13;
            label6.Text = "Bell Hana ";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(1695, 5);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(44, 47);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 11;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // button11
            // 
            button11.AutoSize = true;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button11.ForeColor = Color.Transparent;
            button11.Location = new Point(1745, -3);
            button11.Name = "button11";
            button11.Size = new Size(155, 60);
            button11.TabIndex = 12;
            button11.Text = "Logout";
            button11.TextAlign = ContentAlignment.MiddleLeft;
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(910, 8);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(29, 33);
            button5.TabIndex = 3;
            button5.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(159, 111, 79);
            panel2.Controls.Add(DrinkPanel);
            panel2.Controls.Add(AllDrinks);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(DrinkCategory);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(591, 889);
            panel2.TabIndex = 28;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SaddleBrown;
            panel3.Controls.Add(BillPanel);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(1279, 60);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(645, 889);
            panel3.TabIndex = 29;
            // 
            // panel4
            // 
            panel4.BackColor = Color.SaddleBrown;
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(591, 60);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(19, 889);
            panel4.TabIndex = 30;
            // 
            // CasherForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(159, 111, 79);
            ClientSize = new Size(1924, 949);
            ControlBox = false;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(FoodPanal);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(AllFoods);
            Controls.Add(label5);
            Controls.Add(FoodCategory);
            Controls.Add(button16);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CasherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bell Hana";
            WindowState = FormWindowState.Maximized;
            Load += CasherForm_Load;
            ((System.ComponentModel.ISupportInitialize)BillGV).EndInit();
            BillPanel.ResumeLayout(false);
            BillPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel DrinkPanel;
        private Panel FoodPanal;
        private Panel BillPanel;
        private Button Btn_Rmove;
        private DataGridView BillGV;
        private Button Btn_Cancel;
        private Button Btn_Save;
        private Label DisplayLableTotal;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridViewTextBoxColumn pname;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn Total;
        private Button button16;
        private Button button1;
        private Button button2;
        private Panel DrinkCategory;
        private Panel FoodCategory;
        private Label label5;
        private Button AllDrinks;
        private Button AllFoods;
        private Panel panel1;
        private Button button5;
        private PictureBox pictureBox7;
        private Button button11;
        private Panel panel2;
        private Label label6;
        private Panel panel3;
        private Label WelecomLabel;
        private Panel panel4;
    }
}