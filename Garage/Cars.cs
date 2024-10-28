using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.Mime.MediaTypeNames;


namespace Garage
{
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
            displayCars();
            CDate.Format = DateTimePickerFormat.Custom;
            CDate.CustomFormat = "yyyy-MM-dd";
            CDate.Value = DateTime.Now;
            CarDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private static readonly HttpClient client = new HttpClient();
        private const string SupabaseUrl = "https://owsbowcfbpkwofedkybn.supabase.co";
        private const string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im93c2Jvd2NmYnBrd29mZWRreWJuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mjk2NTE4NjcsImV4cCI6MjA0NTIyNzg2N30.wiqRZ6sch4uzw-1_pexljhvgHsUstKxp4V8Whlii-uc";

        private void Cars_Load(object sender, EventArgs e)
        {
            AddBtn.MouseEnter += AddButton_MouseEnter;
            AddBtn.MouseLeave += AddButton_MouseLeave;

            EditBtn.MouseEnter += EditButton_MouseEnter;
            EditBtn.MouseLeave += EditButton_MouseLeave;

            DeleteBtn.MouseEnter += DeleteButton_MouseEnter;
            DeleteBtn.MouseLeave += DeleteButton_MouseLeave;
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }
        private async void displayCars()
        {
            try
            {
                // Gửi yêu cầu GET tới Supabase để lấy dữ liệu từ bảng CarTbl
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"{SupabaseUrl}/rest/v1/CarTbl"))
                {
                    request.Headers.Add("apikey", SupabaseApiKey);
                    request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var cars = System.Text.Json.JsonSerializer.Deserialize<List<Car>>(responseContent);
                        CarDGV.DataSource = cars;
                    }
                    else
                    {
                        MessageBox.Show($"Error: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching cars: {ex.Message}");
            }
        }


        private async void AddBtn_Click(object sender, EventArgs e)
        {
            if (CarNumTb.Text == "Car Number" || CarBrandTb.Text == "Car Brand" || CarModelTb.Text == "Car Model" || ColorTb.Text == "Color" || OwnerNameTb.Text == "Owner" ||
                CarNumTb.Text == "" || CarBrandTb.Text == "" || CarModelTb.Text == "" || ColorTb.Text == "" || OwnerNameTb.Text == "")
            {
                MessageBox.Show("Wrong Input");
            }
            else
            {
                try
                {
                    // 2. Kiểm tra xem các controls có tồn tại và có giá trị không
                    Console.WriteLine($"CarNum: {CarNumTb.Text}"); // Debug
                    Console.WriteLine($"Brand: {CarBrandTb.Text}"); // Debug

                    var car = new
                    {
                        CNum = CarNumTb.Text.Trim(),
                        CBrand = CarBrandTb.Text.Trim(),
                        CModel = CarModelTb.Text.Trim(),
                        CDate = DateTime.Now.ToString("yyyy-MM-dd"), // Format ngày tháng cho Supabase
                        CColor = ColorTb.Text.Trim(),
                        OwnerName = OwnerNameTb.Text.Trim()
                    };

                    using (var request = new HttpRequestMessage(HttpMethod.Post, $"{SupabaseUrl}/rest/v1/CarTbl"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");
                        request.Headers.Add("Prefer", "return=minimal");

                        var json = System.Text.Json.JsonSerializer.Serialize(car);
                        Console.WriteLine($"Sending JSON: {json}");

                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Response: {responseContent}");

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Car Register");
                            CarNumTb.Text = "";
                            CarBrandTb.Text = "";
                            CarModelTb.Text = "";
                            ColorTb.Text = "";
                            OwnerNameTb.Text = "";
                            displayCars();
                        }
                        else
                        {
                            MessageBox.Show($"Error: {responseContent}");
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message); // Giữ nguyên cách handle exception như code gốc
                }
            }
        }

        string CarKey = "";

        private void CarDGV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (CarDGV.SelectedRows.Count > 0)
                {
                    CarNumTb.Text = CarDGV.SelectedRows[0].Cells[0].Value?.ToString();
                    CarBrandTb.Text = CarDGV.SelectedRows[0].Cells[1].Value?.ToString();
                    CarModelTb.Text = CarDGV.SelectedRows[0].Cells[2].Value?.ToString();
                    CDate.Text = CarDGV.SelectedRows[0].Cells[5].Value?.ToString();
                    ColorTb.Text = CarDGV.SelectedRows[0].Cells[4].Value?.ToString();
                    OwnerNameTb.Text = CarDGV.SelectedRows[0].Cells[3].Value?.ToString();

                    CarKey = CarNumTb.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"CarKey: {CarKey}"); // Debug để kiểm tra giá trị CarKey
            if (CarKey == "")
            {
                MessageBox.Show("Select The Car");
            }
            else
            {
                try
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Delete, $"{SupabaseUrl}/rest/v1/CarTbl?CNum=eq.{CarKey}"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        // Kiểm tra trạng thái phản hồi
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Car Deleted");
                            CarNumTb.Text = "";
                            CarBrandTb.Text = "";
                            CarModelTb.Text = "";
                            ColorTb.Text = "";
                            OwnerNameTb.Text = "";
                            displayCars();
                        }
                        else
                        {
                            MessageBox.Show($"Error: {responseContent}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private async void EditBtn_Click(object sender, EventArgs e)
        {
            if (CarNumTb.Text == "Car Number" || CarBrandTb.Text == "Car Brand" ||
                CarModelTb.Text == "Car Model" || ColorTb.Text == "Color" ||
                OwnerNameTb.Text == "Owner" || CarNumTb.Text == "" ||
                CarBrandTb.Text == "" || CarModelTb.Text == "" ||
                ColorTb.Text == "" || OwnerNameTb.Text == "")
            {
                MessageBox.Show("Wrong Input");
            }
            else
            {
                try
                {
                    // 1. Kiểm tra các giá trị nhập vào
                    Console.WriteLine($"CarNum: {CarNumTb.Text}"); // Debug
                    Console.WriteLine($"Brand: {CarBrandTb.Text}"); // Debug

                    // 2. Tạo đối tượng car chứa dữ liệu cập nhật
                    var car = new
                    {
                        CNum = CarNumTb.Text.Trim(),
                        CBrand = CarBrandTb.Text.Trim(),
                        CModel = CarModelTb.Text.Trim(),
                        CDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        CColor = ColorTb.Text.Trim(),
                        OwnerName = OwnerNameTb.Text.Trim()
                    };

                    // 3. Gửi yêu cầu PUT tới Supabase để cập nhật bản ghi
                    using (var request = new HttpRequestMessage(HttpMethod.Put, $"{SupabaseUrl}/rest/v1/CarTbl?CNum=eq.{CarNumTb.Text.Trim()}"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");
                        request.Headers.Add("Prefer", "return=minimal");

                        // 4. Chuyển dữ liệu car thành JSON
                        var json = System.Text.Json.JsonSerializer.Serialize(car);
                        Console.WriteLine($"Sending JSON: {json}");

                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        // 5. Gửi yêu cầu và nhận phản hồi
                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Response: {responseContent}");

                        // 6. Xử lý kết quả phản hồi
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Car Updated");
                            CarNumTb.Text = "";
                            CarBrandTb.Text = "";
                            CarModelTb.Text = "";
                            ColorTb.Text = "";
                            OwnerNameTb.Text = "";
                            displayCars();
                        }
                        else
                        {
                            MessageBox.Show($"Error: {responseContent}");
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message); // Xử lý lỗi
                }
            }
        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddButton_MouseEnter(object sender, EventArgs e)
        {
            AddBtn.BackColor = Color.LightGreen;
        }

        private void EditButton_MouseEnter(object sender, EventArgs e)
        {
            EditBtn.BackColor = Color.LightYellow;
        }

        private void DeleteButton_MouseEnter(object sender, EventArgs e)
        {
            DeleteBtn.BackColor = Color.MediumVioletRed;
        }

        private void AddButton_MouseLeave(object sender, EventArgs e)
        {
            AddBtn.BackColor = Color.Silver;
        }

        private void EditButton_MouseLeave(object sender, EventArgs e)
        {
            EditBtn.BackColor = Color.Silver;
        }

        private void DeleteButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteBtn.BackColor = Color.Silver;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Stocks obj = new Stocks();
            obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Analistic obj = new Analistic();
            obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
