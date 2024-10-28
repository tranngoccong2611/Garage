namespace Garage
{
    partial class Cars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cars));
            OwnerNameTb = new TextBox();
            ColorTb = new TextBox();
            CarModelTb = new TextBox();
            CarBrandTb = new TextBox();
            panel4 = new Panel();
            CarDGV = new DataGridView();
            DeleteBtn = new Button();
            EditBtn = new Button();
            AddBtn = new Button();
            CDate = new DateTimePicker();
            imageList1 = new ImageList(components);
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            CarNumTb = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
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
            panel3 = new Panel();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CarDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // OwnerNameTb
            // 
            OwnerNameTb.BackColor = Color.DimGray;
            OwnerNameTb.Font = new Font("Arial Narrow", 9.75F);
            OwnerNameTb.ForeColor = SystemColors.Info;
            OwnerNameTb.Location = new Point(24, 344);
            OwnerNameTb.Name = "OwnerNameTb";
            OwnerNameTb.Size = new Size(100, 22);
            OwnerNameTb.TabIndex = 23;
            // 
            // ColorTb
            // 
            ColorTb.BackColor = Color.DimGray;
            ColorTb.Font = new Font("Arial Narrow", 9.75F);
            ColorTb.ForeColor = SystemColors.Info;
            ColorTb.Location = new Point(24, 280);
            ColorTb.Name = "ColorTb";
            ColorTb.Size = new Size(100, 22);
            ColorTb.TabIndex = 22;
            // 
            // CarModelTb
            // 
            CarModelTb.BackColor = Color.DimGray;
            CarModelTb.Font = new Font("Arial Narrow", 9.75F);
            CarModelTb.ForeColor = SystemColors.Info;
            CarModelTb.Location = new Point(24, 212);
            CarModelTb.Name = "CarModelTb";
            CarModelTb.Size = new Size(100, 22);
            CarModelTb.TabIndex = 21;
            // 
            // CarBrandTb
            // 
            CarBrandTb.BackColor = Color.DimGray;
            CarBrandTb.Font = new Font("Arial Narrow", 9.75F);
            CarBrandTb.ForeColor = SystemColors.Info;
            CarBrandTb.Location = new Point(24, 147);
            CarBrandTb.Name = "CarBrandTb";
            CarBrandTb.Size = new Size(100, 22);
            CarBrandTb.TabIndex = 20;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkGray;
            panel4.Controls.Add(CarDGV);
            panel4.Location = new Point(153, 86);
            panel4.Name = "panel4";
            panel4.Size = new Size(503, 239);
            panel4.TabIndex = 19;
            panel4.Paint += panel4_Paint;
            // 
            // CarDGV
            // 
            CarDGV.BackgroundColor = Color.LightGray;
            CarDGV.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.DarkGray;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            CarDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            CarDGV.ColumnHeadersHeight = 25;
            CarDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            CarDGV.DefaultCellStyle = dataGridViewCellStyle2;
            CarDGV.GridColor = Color.DarkGray;
            CarDGV.Location = new Point(0, 0);
            CarDGV.Name = "CarDGV";
            CarDGV.RowHeadersVisible = false;
            CarDGV.RowHeadersWidth = 25;
            CarDGV.Size = new Size(503, 238);
            CarDGV.TabIndex = 0;
            CarDGV.SelectionChanged += CarDGV_SelectionChanged;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = Color.Silver;
            DeleteBtn.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteBtn.ForeColor = Color.Black;
            DeleteBtn.Location = new Point(583, 336);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(58, 31);
            DeleteBtn.TabIndex = 18;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // EditBtn
            // 
            EditBtn.BackColor = Color.Silver;
            EditBtn.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EditBtn.ForeColor = Color.Black;
            EditBtn.Location = new Point(495, 336);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(58, 31);
            EditBtn.TabIndex = 17;
            EditBtn.Text = "Edit";
            EditBtn.UseVisualStyleBackColor = false;
            EditBtn.Click += EditBtn_Click;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Silver;
            AddBtn.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.Black;
            AddBtn.Location = new Point(410, 336);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(58, 31);
            AddBtn.TabIndex = 16;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // CDate
            // 
            CDate.CalendarMonthBackground = SystemColors.HighlightText;
            CDate.Location = new Point(471, 12);
            CDate.Name = "CDate";
            CDate.Size = new Size(190, 23);
            CDate.TabIndex = 15;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(14, 10);
            label7.Name = "label7";
            label7.Size = new Size(163, 25);
            label7.TabIndex = 14;
            label7.Text = "Car Information";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(24, 323);
            label6.Name = "label6";
            label6.Size = new Size(56, 18);
            label6.TabIndex = 13;
            label6.Text = "Owner";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(24, 259);
            label5.Name = "label5";
            label5.Size = new Size(45, 18);
            label5.TabIndex = 11;
            label5.Text = "Color";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(24, 191);
            label4.Name = "label4";
            label4.Size = new Size(81, 18);
            label4.TabIndex = 9;
            label4.Text = "Car Model";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(24, 65);
            label2.Name = "label2";
            label2.Size = new Size(96, 18);
            label2.TabIndex = 5;
            label2.Text = "Car Number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(24, 126);
            label3.Name = "label3";
            label3.Size = new Size(80, 18);
            label3.TabIndex = 7;
            label3.Text = "Car Brand";
            // 
            // CarNumTb
            // 
            CarNumTb.BackColor = Color.DimGray;
            CarNumTb.Font = new Font("Arial Narrow", 9.75F);
            CarNumTb.ForeColor = SystemColors.Info;
            CarNumTb.Location = new Point(24, 86);
            CarNumTb.Name = "CarNumTb";
            CarNumTb.Size = new Size(100, 22);
            CarNumTb.TabIndex = 4;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(167, 26);
            label1.Name = "label1";
            label1.Size = new Size(378, 31);
            label1.TabIndex = 3;
            label1.Text = "Record Cars For Servicing";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowText;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(840, 497);
            panel1.TabIndex = 1;
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
            label14.ForeColor = SystemColors.ActiveCaption;
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
            label13.Click += label13_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 14.25F);
            label12.ForeColor = SystemColors.ButtonFace;
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
            label11.Click += label11_Click;
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
            label10.Click += label10_Click;
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
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(OwnerNameTb);
            panel3.Controls.Add(ColorTb);
            panel3.Controls.Add(CarModelTb);
            panel3.Controls.Add(CarBrandTb);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(DeleteBtn);
            panel3.Controls.Add(EditBtn);
            panel3.Controls.Add(AddBtn);
            panel3.Controls.Add(CDate);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(CarNumTb);
            panel3.ForeColor = Color.DimGray;
            panel3.Location = new Point(167, 104);
            panel3.Name = "panel3";
            panel3.Size = new Size(668, 385);
            panel3.TabIndex = 2;
            // 
            // Cars
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 497);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Cars";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cars";
            Load += Cars_Load;
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CarDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox OwnerNameTb;
        private TextBox ColorTb;
        private TextBox CarModelTb;
        private TextBox CarBrandTb;
        private Panel panel4;
        private Button DeleteBtn;
        private Button EditBtn;
        private Button AddBtn;
        private DateTimePicker CDate;
        private ImageList imageList1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private TextBox CarNumTb;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel1;
        private Panel panel3;
        private DataGridView CarDGV;
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
    }
}