
using Garage.Data.Models;
using System.Text.RegularExpressions;

namespace Garage.Forms.MainForm
{
    public class SelectedStaff {
        public string name { get; set; }
        public int id { get; set; } 
    }
    public class PartsSelected
    {
        public string name { get; set; }
        public int id { get; set; }

    }
    public class SelectServices
    {
        public string name { get; set; }
        public int id { get; set; }

    }
    partial class FormAddTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel Container;
        private Button Save;
        private Label AddTransacstion;
        private Button Cancel;
        private Label FullName;
        private TextBox FullNameBox;
        private Label Phone;
        private TextBox PhoneCall;
        private DateTimePicker dateTransactions;
        private Label date;
        private TextBox TotalSpent;
        private ComboBox staffFullName;
        private Label totalSpent;
        private Label staffFullNameLabel;
        private Label parts;
        private ComboBox selectParts;
        private Label numsParts;
        private TextBox numPartsInput;
        private Label nameBrand;
        private Label modelCar;
        private ComboBox selectServices;
        private Label services;
        private Label issuels;
        private TextBox issuelsInput;
        private Label solution;
        private TextBox solutionInput;
        private TextBox InputBrand;
        private TextBox inputModel;
        private Label BienSoXe;
        private TextBox BienSoXeInput;

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
            List<NhanVien> listStaff=_context.NhanVien.ToList();
            List<DichVu> listServices=_context.DichVu.ToList();
            List<LinhKien> listParts=_context.LinhKien.ToList();

            // Initialize Components
            
            this.Container = new Panel();
            this.Save = new Button();
            this.Cancel = new Button();
            AddTransacstion = new Label();

            // Form Settings
            this.SuspendLayout();
            this.Text = "Add Transaction";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Calculate 70% width and 80% height of the screen
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            this.Width = (int)(screenWidth * 0.7);
            this.Height = (int)(screenHeight * 0.8);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel Container
           Container.Width = screenWidth;   
            Container.Height = screenHeight;    
            Container.Location=new Point(0, 0);
            this.Container.BackColor = Color.LightGray;

            // AddTransaction Label
            this.AddTransacstion.Text = "Add Transaction";
            this.AddTransacstion.Font = new Font("Arial", 18, FontStyle.Bold);
            this.AddTransacstion.Location = new Point(20, 20);
            this.AddTransacstion.AutoSize = true;

            // Save Button
            this.Save.Text = "Save";
            this.Save.Size = new Size(100, 30);
            this.Save.Location = new Point(Width - 300, Height - 80);
            Save.BackColor = Color.White;
            Save.Click+=btn_save;
            // Cancel Button
            this.Cancel.Text = "Cancel";
            this.Cancel.Size = new Size(100, 30);
            this.Cancel.Location = new Point(Width - 180, Height - 80);
            Cancel.BackColor = Color.White;
            Cancel.Click += btn_Cancel_Click;
            // Add components to Container
            this.Container.Controls.Add(this.AddTransacstion);
            this.Container.Controls.Add(this.Save);
            this.Container.Controls.Add(this.Cancel);

            // Add Container to Form
            this.Controls.Add(Container);




            FullName = new Label();
            FullName.Text = "Fullname:";
            FullName.Width = 70;
            FullName.Height = 50;
            FullName.ForeColor = System.Drawing.Color.Black;
            FullName.Location = new Point(AddTransacstion.Location.X+30,AddTransacstion.Bottom+30);
            Container.Controls.Add(FullName);

            FullNameBox = new TextBox();
            FullNameBox.PlaceholderText = "Phong demo";
            FullNameBox.Width = 200;
            FullNameBox.Height = 50;
            FullNameBox.ForeColor = Color.Black;
            FullNameBox.BackColor = Color.White;
            FullNameBox.Location = new Point(FullName.Right + 5,FullName.Location.Y);
            Container.Controls.Add(FullNameBox);

            Phone=new Label();
            Phone.Text = "Phone:";
            Phone.Width = 70;
            Phone.Height = 50;
            Phone.ForeColor = Color.Black;
            Phone.Location = new Point(AddTransacstion.Location.X+30,FullNameBox.Bottom+30);
            Container.Controls.Add(Phone);

            PhoneCall=new TextBox();
            PhoneCall.PlaceholderText = "0365022794";
            PhoneCall.Width = 200;
            PhoneCall.Height = 50;
            PhoneCall.ForeColor = Color.Black;
            PhoneCall.BackColor = Color.White;
            PhoneCall.Location = new Point(Phone.Right+5,Phone.Location.Y);
            Container.Controls.Add(PhoneCall);

            nameBrand =new Label();
            nameBrand.Text = "Brand:";
            nameBrand.Width = 70;
            nameBrand.Height = 50;
            nameBrand.ForeColor = Color.Black;
            nameBrand.Location = new Point(AddTransacstion.Location.X+30,PhoneCall.Bottom+30);
            Container.Controls.Add(nameBrand);
            
            InputBrand  =new TextBox();
            InputBrand.PlaceholderText = "Toyota";
            InputBrand.Width = 200;
            InputBrand.Height = 50;
                InputBrand.ForeColor = Color.Black;
            InputBrand.BackColor = Color.White;
            InputBrand.Location = new Point(nameBrand.Right+5,PhoneCall.Bottom+30);
            Container.Controls.Add(InputBrand);

            date =new Label();
            date.Text = "Date:";
            date.Width = 70;
            date.Height = 50;
            date.ForeColor = Color.Black;
            date.Location = new Point(AddTransacstion.Location.X+30,nameBrand.Bottom+30);
            Container.Controls.Add(date);

            dateTransactions =new DateTimePicker();
            dateTransactions.Value = DateTime.Today;
            dateTransactions.Width = 200;
            dateTransactions.Height = 50;
            dateTransactions.ForeColor = Color.Black;
            dateTransactions.BackColor = Color.White;
            dateTransactions.Location = new Point(date.Right+5,nameBrand.Bottom+30);
            Container.Controls.Add(dateTransactions);

            modelCar = new Label();
            modelCar.Text = "Model:";
            modelCar.Width = 70;
            modelCar.Height = 50;
            modelCar.ForeColor = Color.Black;
            modelCar.Location = new Point(AddTransacstion.Location.X+30,date.Bottom+30);
            Container.Controls.Add(modelCar);


            inputModel=new TextBox();
            inputModel.PlaceholderText = "Cross 2022";
            inputModel.Width = 200;
            inputModel.Height = 50;
            inputModel.ForeColor = Color.Black;
            inputModel.BackColor = Color.White;
            inputModel.Location = new Point(modelCar.Right+5,date.Bottom+30);
            Container.Controls.Add(inputModel);

            BienSoXe = new Label();
            BienSoXe.Text = "Model:";
            BienSoXe.Width = 70;
            BienSoXe.Height = 50;
            BienSoXe.ForeColor = Color.Black;
            BienSoXe.Location = new Point(AddTransacstion.Location.X + 30, inputModel.Bottom + 30);
            Container.Controls.Add(modelCar);


            BienSoXeInput = new TextBox();
            BienSoXeInput.PlaceholderText = "34B2-383.83";
            BienSoXeInput.Width = 200;
            BienSoXeInput.Height = 50;
            BienSoXeInput.ForeColor = Color.Black;
            BienSoXeInput.BackColor = Color.White;
            BienSoXeInput.Location = new Point(modelCar.Right + 5, inputModel.Bottom + 30);
            Container.Controls.Add(BienSoXeInput);

            totalSpent = new Label();
            totalSpent.Text = "Total Spent:";
            totalSpent.Width = 70;
            totalSpent.Height = 50;
            totalSpent.ForeColor = Color.Black;
            totalSpent.Location = new Point(AddTransacstion.Location.X+30, BienSoXeInput.Bottom+30);
            Container.Controls.Add(totalSpent);

            TotalSpent = new TextBox();
            TotalSpent.Text = "0.00";
            TotalSpent.Width = 150;
            TotalSpent.Height = 50;
            TotalSpent.ForeColor = Color.Black;
            TotalSpent.BackColor = Color.White;
            TotalSpent.Location = new Point(totalSpent.Right+5,inputModel.Bottom+30);
            Container.Controls.Add(TotalSpent);

            staffFullNameLabel = new Label();
            staffFullNameLabel.Text = "Staff:";
            staffFullNameLabel.Width = 70;
            staffFullNameLabel.Height = 50;
            staffFullNameLabel.ForeColor = Color.Black;
            staffFullNameLabel.Location = new Point(inputModel.Right+135,AddTransacstion.Bottom+30);
            Container.Controls.Add(staffFullNameLabel);

            
            staffFullName= new ComboBox();
            staffFullName.DataSource =listStaff;
            staffFullName.Width = 200;
            staffFullName.Height = 50;
            staffFullName.DisplayMember = "HoTen";
            staffFullName.ValueMember = "NhanVienID";
            staffFullName.ForeColor = Color.Black;
            staffFullName.Location = new Point(staffFullNameLabel.Right+5, staffFullNameLabel.Location.Y);
            staffFullName.BackColor = Color.White;
            Container.Controls.Add(staffFullName);

            parts=new Label();
            parts.Text = "Parts:";
            parts.Width = 70;
            parts.Height = 50;

            parts.ForeColor = Color.Black;
            parts.Location=new Point(staffFullNameLabel.Location.X,staffFullName.Bottom+30);
            Container.Controls.Add(parts);

         
            selectParts=new ComboBox();
            selectParts.Width = 200;
            selectParts.Height = 50;
            selectParts.DataSource =listParts;
            selectParts.DisplayMember = "TenLinhKien";
            selectParts.ValueMember = "LinhKienID";
            selectParts.ForeColor = Color.Black;
            selectParts.Location = new Point(staffFullNameLabel.Right+5,parts.Location.Y);
            selectParts.BackColor = Color.White;
     
            Container.Controls.Add (selectParts);

            numsParts = new Label();
            numsParts.Width = 50;
            numsParts.Height = 50;
            numsParts.ForeColor = Color.Black;
            numsParts.Location = new Point(selectParts.Right + 30,parts.Location.Y);
            numsParts.Text = "Nums:";
            Container.Controls.Add(numsParts);

            numPartsInput=new TextBox();
            numPartsInput.Width = 50;
            numPartsInput.Height = 50;
            numPartsInput.ForeColor = Color.Black;
            numPartsInput.Location = new Point(numsParts.Right+5,parts.Location.Y);
            numPartsInput.BackColor = Color.White;
            numPartsInput.PlaceholderText = "05";
            Container.Controls.Add(numPartsInput);
           

         
            services =new Label();  
            services.Width=70; services.Height=50;
            services.ForeColor = Color.Black;
            
            services.Text = "Services";
            services.Location = new Point(staffFullNameLabel.Location.X,parts.Bottom+30);
            Container.Controls.Add(services);

            selectServices=new ComboBox();
            selectServices.DataSource=listServices;
            selectServices.Width = 200;
            selectServices.Height = 50;
            selectServices.ForeColor = Color.Black;
            selectServices.BackColor = Color.White;
            selectServices.Location = new Point(services.Right+5,parts.Bottom+30);
            selectServices.DisplayMember = "TenDichVu";
            selectServices.ValueMember = "DichVuID";
            Container.Controls.Add(selectServices);

            issuels = new Label();
            issuels.Width = 70;
            issuels.Height = 50;
            issuels.ForeColor = Color.Black;
            issuels.Text = "Issuels:";
            issuels.Location = new Point(staffFullNameLabel.Location.X,selectServices.Bottom+30);
            Container.Controls.Add(issuels);

            issuelsInput=new TextBox();
            issuelsInput.Width = 200;
            issuelsInput.Height = 50;
            issuelsInput.ForeColor = Color.Black;
            issuelsInput.BackColor = Color.White;
            issuelsInput.Location = new Point(issuels.Right+5,issuels.Location.Y);
            Container.Controls.Add(issuelsInput);

            solution =new Label();
            solution.Width = 70;
            solution.Height = 50;
            solution.ForeColor = Color.Black;
            solution.Text = "Solutions:";
            solution.Location = new Point(issuels.Location.X,issuels.Bottom+30);
            Container.Controls.Add(solution);

            solutionInput =new TextBox();
            solutionInput.Width = 200;
            solutionInput.Height = 50;
            solutionInput.ForeColor = Color.Black;
            solutionInput.BackColor = Color.White;
            solutionInput.Location = new Point(solution.Right+5,issuels.Bottom+30);
            Container.Controls.Add(solutionInput);



        }

        public static bool ValidateLicensePlate(string licensePlate)
        {
            // Biểu thức chính quy kiểm tra biển số xe theo định dạng 34B2-383.83
            string pattern = @"^[0-9]{2}[A-Za-z]{1}[0-9]{1}-[0-9]{3}\.[0-9]{2}$";

            // Kiểm tra xem biển số xe có khớp với biểu thức chính quy không
            Regex regex = new Regex(pattern);
            return regex.IsMatch(licensePlate);
        }

        #endregion


    }
}