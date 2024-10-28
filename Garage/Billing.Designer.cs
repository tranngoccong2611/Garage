namespace Garage
{
    partial class Billing
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Billing));
            bindingSource1 = new BindingSource(components);
            imageList1 = new ImageList(components);
            CarNumberCB = new ComboBox();
            name = new Label();
            panel3 = new Panel();
            MFeesTb = new TextBox();
            label5 = new Label();
            TotFeesLbl = new Label();
            PartFeeLbl = new Label();
            panel5 = new Panel();
            ChangedPartsDGV = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            QtyTb = new TextBox();
            panel4 = new Panel();
            StockDGV = new DataGridView();
            Calculatebtn = new Button();
            PrintBtn = new Button();
            AddPart = new Button();
            dateTimePicker1 = new DateTimePicker();
            label7 = new Label();
            panel1 = new Panel();
            UserLbl = new Label();
            panel2 = new Panel();
            pictureBox11 = new PictureBox();
            pictureBox10 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            pictureBox2 = new PictureBox();
            label8 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ChangedPartsDGV).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StockDGV).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // CarNumberCB
            // 
            CarNumberCB.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CarNumberCB.FormattingEnabled = true;
            CarNumberCB.Location = new Point(280, 67);
            CarNumberCB.Name = "CarNumberCB";
            CarNumberCB.Size = new Size(109, 23);
            CarNumberCB.TabIndex = 22;
            CarNumberCB.Text = "Car Number";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            name.ForeColor = SystemColors.ButtonFace;
            name.Location = new Point(299, 175);
            name.Name = "name";
            name.Size = new Size(71, 18);
            name.TabIndex = 7;
            name.Text = "Quantity";
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(MFeesTb);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(TotFeesLbl);
            panel3.Controls.Add(PartFeeLbl);
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(CarNumberCB);
            panel3.Controls.Add(QtyTb);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(Calculatebtn);
            panel3.Controls.Add(PrintBtn);
            panel3.Controls.Add(AddPart);
            panel3.Controls.Add(dateTimePicker1);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(name);
            panel3.ForeColor = Color.DimGray;
            panel3.Location = new Point(167, 104);
            panel3.Name = "panel3";
            panel3.Size = new Size(668, 385);
            panel3.TabIndex = 2;
            // 
            // MFeesTb
            // 
            MFeesTb.BackColor = Color.DimGray;
            MFeesTb.ForeColor = SystemColors.Info;
            MFeesTb.Location = new Point(280, 260);
            MFeesTb.Name = "MFeesTb";
            MFeesTb.Size = new Size(109, 23);
            MFeesTb.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(273, 239);
            label5.Name = "label5";
            label5.Size = new Size(119, 18);
            label5.TabIndex = 26;
            label5.Text = "Mechanics Fees";
            // 
            // TotFeesLbl
            // 
            TotFeesLbl.AutoSize = true;
            TotFeesLbl.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotFeesLbl.ForeColor = SystemColors.ButtonFace;
            TotFeesLbl.Location = new Point(556, 309);
            TotFeesLbl.Name = "TotFeesLbl";
            TotFeesLbl.Size = new Size(82, 18);
            TotFeesLbl.TabIndex = 25;
            TotFeesLbl.Text = "Total Fees";
            // 
            // PartFeeLbl
            // 
            PartFeeLbl.AutoSize = true;
            PartFeeLbl.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PartFeeLbl.ForeColor = SystemColors.ButtonFace;
            PartFeeLbl.Location = new Point(427, 309);
            PartFeeLbl.Name = "PartFeeLbl";
            PartFeeLbl.Size = new Size(76, 18);
            PartFeeLbl.TabIndex = 24;
            PartFeeLbl.Text = "Part Fees";
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkGray;
            panel5.Controls.Add(ChangedPartsDGV);
            panel5.Location = new Point(412, 67);
            panel5.Name = "panel5";
            panel5.Size = new Size(246, 226);
            panel5.TabIndex = 23;
            // 
            // ChangedPartsDGV
            // 
            ChangedPartsDGV.BackgroundColor = Color.LightGray;
            ChangedPartsDGV.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.DarkGray;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ChangedPartsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ChangedPartsDGV.ColumnHeadersHeight = 25;
            ChangedPartsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ChangedPartsDGV.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ChangedPartsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            ChangedPartsDGV.GridColor = Color.DarkGray;
            ChangedPartsDGV.Location = new Point(0, 0);
            ChangedPartsDGV.Name = "ChangedPartsDGV";
            ChangedPartsDGV.RowHeadersVisible = false;
            ChangedPartsDGV.RowHeadersWidth = 25;
            ChangedPartsDGV.Size = new Size(246, 226);
            ChangedPartsDGV.TabIndex = 4;
            // 
            // Column1
            // 
            Column1.HeaderText = "Num";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Part";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Quantity";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Price";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Total";
            Column5.Name = "Column5";
            // 
            // QtyTb
            // 
            QtyTb.BackColor = Color.DimGray;
            QtyTb.ForeColor = SystemColors.Info;
            QtyTb.Location = new Point(280, 197);
            QtyTb.Name = "QtyTb";
            QtyTb.Size = new Size(109, 23);
            QtyTb.TabIndex = 20;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkGray;
            panel4.Controls.Add(StockDGV);
            panel4.Location = new Point(14, 70);
            panel4.Name = "panel4";
            panel4.Size = new Size(246, 226);
            panel4.TabIndex = 19;
            // 
            // StockDGV
            // 
            StockDGV.BackgroundColor = Color.LightGray;
            StockDGV.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.DarkGray;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            StockDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            StockDGV.ColumnHeadersHeight = 25;
            StockDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.DimGray;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            StockDGV.DefaultCellStyle = dataGridViewCellStyle4;
            StockDGV.GridColor = Color.DarkGray;
            StockDGV.Location = new Point(0, 0);
            StockDGV.Name = "StockDGV";
            StockDGV.RowHeadersVisible = false;
            StockDGV.RowHeadersWidth = 25;
            StockDGV.Size = new Size(246, 226);
            StockDGV.TabIndex = 3;
            StockDGV.SelectionChanged += StockDGV_SelectionChanged;
            // 
            // Calculatebtn
            // 
            Calculatebtn.BackColor = Color.Silver;
            Calculatebtn.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Calculatebtn.ForeColor = Color.Black;
            Calculatebtn.Location = new Point(280, 303);
            Calculatebtn.Name = "Calculatebtn";
            Calculatebtn.Size = new Size(109, 32);
            Calculatebtn.TabIndex = 18;
            Calculatebtn.Text = "Calculate Fees";
            Calculatebtn.UseVisualStyleBackColor = false;
            Calculatebtn.Click += Calculate_Click;
            // 
            // PrintBtn
            // 
            PrintBtn.BackColor = Color.Silver;
            PrintBtn.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrintBtn.ForeColor = Color.Black;
            PrintBtn.Location = new Point(511, 337);
            PrintBtn.Name = "PrintBtn";
            PrintBtn.Size = new Size(58, 31);
            PrintBtn.TabIndex = 17;
            PrintBtn.Text = "Print";
            PrintBtn.UseVisualStyleBackColor = false;
            PrintBtn.Click += PrintBtn_Click;
            // 
            // AddPart
            // 
            AddPart.BackColor = Color.Silver;
            AddPart.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddPart.ForeColor = Color.Black;
            AddPart.Location = new Point(87, 337);
            AddPart.Name = "AddPart";
            AddPart.Size = new Size(58, 31);
            AddPart.TabIndex = 16;
            AddPart.Text = "Add";
            AddPart.UseVisualStyleBackColor = false;
            AddPart.Click += AddPart_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = SystemColors.HighlightText;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(280, 134);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(109, 23);
            dateTimePicker1.TabIndex = 15;
            dateTimePicker1.Value = new DateTime(2024, 10, 26, 14, 16, 20, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(14, 10);
            label7.Name = "label7";
            label7.Size = new Size(162, 25);
            label7.TabIndex = 14;
            label7.Text = "Bill Infromation";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowText;
            panel1.Controls.Add(UserLbl);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(840, 497);
            panel1.TabIndex = 3;
            // 
            // UserLbl
            // 
            UserLbl.AutoSize = true;
            UserLbl.Font = new Font("Georgia", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserLbl.ForeColor = SystemColors.ButtonFace;
            UserLbl.Location = new Point(440, 3);
            UserLbl.Name = "UserLbl";
            UserLbl.Size = new Size(56, 25);
            UserLbl.TabIndex = 15;
            UserLbl.Text = "User";
            UserLbl.Click += UserLbl_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDarkDark;
            panel2.Controls.Add(pictureBox11);
            panel2.Controls.Add(pictureBox10);
            panel2.Controls.Add(pictureBox9);
            panel2.Controls.Add(pictureBox8);
            panel2.Controls.Add(pictureBox7);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(161, 501);
            panel2.TabIndex = 4;
            // 
            // pictureBox11
            // 
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(3, 368);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(41, 43);
            pictureBox11.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox11.TabIndex = 17;
            pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(3, 314);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(41, 43);
            pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox10.TabIndex = 16;
            pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(3, 265);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(41, 43);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 15;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(3, 216);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(41, 43);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 14;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(3, 157);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(41, 43);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 13;
            pictureBox7.TabStop = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Georgia", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ButtonFace;
            label15.Location = new Point(39, 448);
            label15.Name = "label15";
            label15.Size = new Size(86, 25);
            label15.TabIndex = 12;
            label15.Text = "Logout";
            label15.Click += label15_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Georgia", 14.25F);
            label14.ForeColor = SystemColors.ButtonFace;
            label14.Location = new Point(48, 167);
            label14.Name = "label14";
            label14.Size = new Size(48, 23);
            label14.TabIndex = 11;
            label14.Text = "Cars";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Georgia", 14.25F);
            label13.ForeColor = SystemColors.ButtonFace;
            label13.Location = new Point(48, 377);
            label13.Name = "label13";
            label13.Size = new Size(85, 23);
            label13.TabIndex = 10;
            label13.Text = "Analistic";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 14.25F);
            label12.ForeColor = SystemColors.ActiveCaption;
            label12.Location = new Point(48, 325);
            label12.Name = "label12";
            label12.Size = new Size(65, 23);
            label12.TabIndex = 9;
            label12.Text = "Billing";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Georgia", 14.25F);
            label11.ForeColor = SystemColors.ButtonFace;
            label11.Location = new Point(48, 275);
            label11.Name = "label11";
            label11.Size = new Size(92, 23);
            label11.TabIndex = 8;
            label11.Text = "Employee";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Georgia", 14.25F);
            label10.ForeColor = SystemColors.ButtonFace;
            label10.Location = new Point(48, 223);
            label10.Name = "label10";
            label10.Size = new Size(57, 23);
            label10.TabIndex = 7;
            label10.Text = "Stock";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(39, 92);
            label9.Name = "label9";
            label9.Size = new Size(75, 25);
            label9.TabIndex = 6;
            label9.Text = "Menu";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.images;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 54);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonFace;
            label8.Location = new Point(58, 9);
            label8.Name = "label8";
            label8.Size = new Size(100, 29);
            label8.TabIndex = 4;
            label8.Text = "Garage";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(167, 26);
            label1.Name = "label1";
            label1.Size = new Size(107, 31);
            label1.TabIndex = 3;
            label1.Text = "Billing";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.mercedes_benz_e_class_2024_ruc_rich_ra_mat_ngay_trong_thang_nay_Hinh_2;
            pictureBox1.Location = new Point(618, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(219, 114);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Billing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 497);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Billing";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Billing";
            Load += Billing_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ChangedPartsDGV).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)StockDGV).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private BindingSource bindingSource1;
        private ImageList imageList1;
        private ComboBox CarNumberCB;
        private Label name;
        private Panel panel3;
        private TextBox QtyTb;
        private Panel panel4;
        private Button Calculatebtn;
        private Button PrintBtn;
        private Button AddPart;
        private DateTimePicker dateTimePicker1;
        private Label label7;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView StockDGV;
        private Panel panel5;
        private Label TotFeesLbl;
        private Label PartFeeLbl;
        private DataGridView ChangedPartsDGV;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private TextBox MFeesTb;
        private Label label5;
        private Panel panel2;
        private PictureBox pictureBox11;
        private PictureBox pictureBox10;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private PictureBox pictureBox2;
        private Label label8;
        private Label UserLbl;
    }
}