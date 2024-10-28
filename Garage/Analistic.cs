using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage
{
    public partial class Analistic : Form
    {
        public Analistic()
        {
            InitializeComponent();
            CountCars();
            CountStocks();
            CountEmployees();
            SumAmount();
        }

        private void Analistic_Load(object sender, EventArgs e)
        {

        }
        private static readonly HttpClient client = new HttpClient();
        private const string SupabaseUrl = "https://owsbowcfbpkwofedkybn.supabase.co";
        private const string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im93c2Jvd2NmYnBrd29mZWRreWJuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mjk2NTE4NjcsImV4cCI6MjA0NTIyNzg2N30.wiqRZ6sch4uzw-1_pexljhvgHsUstKxp4V8Whlii-uc";

        private async void CountCars()
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"{SupabaseUrl}/rest/v1/CarTbl?select=*"))
                {
                    request.Headers.Add("apikey", SupabaseApiKey);
                    request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the JSON response to count the items
                        var cars = System.Text.Json.JsonSerializer.Deserialize<List<Car>>(responseContent);
                        int carCount = cars?.Count ?? 0;

                        // Display the car count in CarLbl
                        CarLbl.Text = carCount.ToString();
                    }
                    else
                    {
                        MessageBox.Show($"Error: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async void CountStocks()
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"{SupabaseUrl}/rest/v1/StockTbl?select=*"))
                {
                    request.Headers.Add("apikey", SupabaseApiKey);
                    request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the JSON response to count the items
                        var stock = System.Text.Json.JsonSerializer.Deserialize<List<Stock>>(responseContent);
                        int stockCount = stock?.Count ?? 0;

                        // Display the car count in CarLbl
                        StockLbl.Text = stockCount.ToString();
                    }
                    else
                    {
                        MessageBox.Show($"Error: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async void CountEmployees()
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"{SupabaseUrl}/rest/v1/EmployeeTbl?select=*"))
                {
                    request.Headers.Add("apikey", SupabaseApiKey);
                    request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the JSON response to count the items
                        var emp = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(responseContent);
                        int empCount = emp?.Count ?? 0;

                        // Display the car count in CarLbl
                        EmpLbl.Text = empCount.ToString();
                    }
                    else
                    {
                        MessageBox.Show($"Error: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void SumAmount()
        {
            try
            {
                // Sửa lại URL với cú pháp chính xác hơn
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"{SupabaseUrl}/rest/v1/BillTbl"))
                {
                    request.Headers.Add("apikey", SupabaseApiKey);
                    request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");
                    // Thêm Prefer header để chỉ định format response
                    request.Headers.Add("Prefer", "return=representation");

                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var bills = JsonSerializer.Deserialize<List<BillingData>>(responseContent);
                        if (bills != null && bills.Any())
                        {
                            // Tính tổng trực tiếp từ danh sách đã lấy về
                            var total = bills.Sum(b => b.TotFees);
                            AmountLbl.Text = total.ToString("N0");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void AmountLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Cars obj = new Cars();
            obj.Show();
            this.Hide();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Stocks obj = new Stocks();
            obj.Show();
            this.Hide();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Employees obj = new Employees();
            obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Cars obj = new Cars();
            obj.Show();
            this.Hide();
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
    }
}