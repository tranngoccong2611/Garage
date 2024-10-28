namespace Garage
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            panel1 = new Panel();
            label3 = new Label();
            PersontageLbl = new Label();
            label1 = new Label();
            progressBar = new ProgressBar();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(PersontageLbl);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(progressBar);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(279, 343);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(51, 284);
            label3.Name = "label3";
            label3.Size = new Size(90, 23);
            label3.TabIndex = 6;
            label3.Text = "Loading";
            // 
            // PersontageLbl
            // 
            PersontageLbl.AutoSize = true;
            PersontageLbl.Font = new Font("Georgia", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PersontageLbl.ForeColor = SystemColors.ButtonFace;
            PersontageLbl.Location = new Point(188, 284);
            PersontageLbl.Name = "PersontageLbl";
            PersontageLbl.Size = new Size(30, 25);
            PersontageLbl.TabIndex = 5;
            PersontageLbl.Text = "%";
            PersontageLbl.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(113, 31);
            label1.TabIndex = 4;
            label1.Text = "Garage";
            // 
            // progressBar
            // 
            progressBar.BackColor = SystemColors.ButtonShadow;
            progressBar.ForeColor = SystemColors.ControlDark;
            progressBar.Location = new Point(22, 318);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(237, 10);
            progressBar.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(279, 196);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 343);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Splash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Splash";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ProgressBar progressBar;
        private PictureBox pictureBox1;
        private Label label1;
        private Label PersontageLbl;
        private Label label3;
        private System.Windows.Forms.Timer timer1;


    }
}