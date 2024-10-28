using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            displayStocks();
            GetCars();
            StockDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private static readonly HttpClient client = new HttpClient();
        private const string SupabaseUrl = "https://owsbowcfbpkwofedkybn.supabase.co";
        private const string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im93c2Jvd2NmYnBrd29mZWRreWJuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mjk2NTE4NjcsImV4cCI6MjA0NTIyNzg2N30.wiqRZ6sch4uzw-1_pexljhvgHsUstKxp4V8Whlii-uc";

        private async void GetCars()
        {
            try
            {
                // Gọi API đến Supabase để lấy dữ liệu từ bảng CarTbl
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"{SupabaseUrl}/rest/v1/CarTbl"))
                {
                    // Thêm headers cần thiết
                    request.Headers.Add("apikey", SupabaseApiKey);
                    request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                    // Gửi request và nhận response
                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize JSON response thành List<Car>
                        var cars = System.Text.Json.JsonSerializer.Deserialize<List<Car>>(responseContent);

                        // Tạo DataTable và thêm cột
                        DataTable dt = new DataTable();
                        dt.Columns.Add("CNum", typeof(string));

                        // Thêm dữ liệu vào DataTable
                        foreach (var car in cars)
                        {
                            dt.Rows.Add(car.CNum);
                        }

                        // Gán nguồn dữ liệu cho ComboBox
                        CarNumberCB.ValueMember = "CNum";
                        CarNumberCB.DataSource = dt;
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

        private async void displayStocks()
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"{SupabaseUrl}/rest/v1/StockTbl"))
                {
                    request.Headers.Add("apikey", SupabaseApiKey);
                    request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var stock = System.Text.Json.JsonSerializer.Deserialize<List<Stock>>(responseContent);
                        StockDGV.DataSource = stock;
                    }
                    else
                    {
                        MessageBox.Show($"Error: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching employees: {ex.Message}");
            }
        }

        private void Billing_Load(object sender, EventArgs e)
        {

        }


        int id = 0, qty = 0, price = 0, key = 0;
        string partName = "";
        private void StockDGV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (StockDGV.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = StockDGV.SelectedRows[0];
                    id = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                    partName = selectedRow.Cells[1].Value.ToString();
                    qty = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
                    price = Convert.ToInt32(selectedRow.Cells[3].Value.ToString());

                    // Set the Key (or EmpKey) for further operations like Edit/Delete
                    key = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        int n = 0, num;
        int tot = 0, GrdTot = 0;
        private void AddPart_Click(object sender, EventArgs e)
        {
            if (key == 0 || QtyTb.Text == "")
            {
                MessageBox.Show("Select Spare Part To Add");
            }
            else
            {
                num = Convert.ToInt32(QtyTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ChangedPartsDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = partName;
                tot = num * price;
                newRow.Cells[2].Value = num;
                newRow.Cells[3].Value = price;
                newRow.Cells[4].Value = tot;
                ChangedPartsDGV.Rows.Add(newRow);
                n++;
                GrdTot = GrdTot + tot;
                PartFeeLbl.Text = $"{GrdTot}";
            }
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            if (MFeesTb.Text == "")
            {
                MessageBox.Show("Enter A Valid Amount");
            }
            else if (PartFeeLbl.Text == "Part Fees")
            {
                TotFeesLbl.Text = Convert.ToString(MFeesTb.Text);
            }
            else
            {
                TotFeesLbl.Text = Convert.ToString(GrdTot + Convert.ToInt32(MFeesTb.Text));
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private async void PrintBtn_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường dữ liệu cần thiết trước khi gửi
            if (CarNumberCB.SelectedIndex == -1 || string.IsNullOrEmpty(MFeesTb.Text) || ChangedPartsDGV.Rows.Count == 0)
            {
                MessageBox.Show("Please fill all the required fields.");

            }
            else
            {

                try
                {


                    // Tạo một đối tượng BillingData
                    var billingData = new
                    {
                        CarNum = CarNumberCB.Text,
                        BDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        MechFees = Convert.ToInt32(MFeesTb.Text.Trim()),
                        PartFees = GrdTot,
                        TotFees = GrdTot + Convert.ToInt32(MFeesTb.Text.Trim())
                    };
                    using (var request = new HttpRequestMessage(HttpMethod.Post, $"{SupabaseUrl}/rest/v1/BillTbl"))
                    {
                        // Thiết lập header cho API key và Bearer token
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                        // Chuyển đổi đối tượng BillingData thành JSON
                        string json = System.Text.Json.JsonSerializer.Serialize(billingData);
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        // Gửi yêu cầu và xử lý phản hồi
                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Billing data saved successfully!");
                        }
                        else
                        {
                            MessageBox.Show($"Error saving billing data: {responseContent}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving billing data: {ex.Message}");
                }
            }

        }

        private void label15_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void UserLbl_Click(object sender, EventArgs e)
        {

        }
        private string _employeeName;

        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                _employeeName = value;
                UserLbl.Text = value;
            }
        }
    }
}