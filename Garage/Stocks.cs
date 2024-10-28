using System.Text;
using System.Windows.Forms;

namespace Garage
{
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
            displayStocks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddBtn.MouseEnter += AddButton_MouseEnter;
            AddBtn.MouseLeave += AddButton_MouseLeave;

            Editbtn.MouseEnter += EditButton_MouseEnter;
            Editbtn.MouseLeave += EditButton_MouseLeave;

            DeleteBtn.MouseEnter += DeleteButton_MouseEnter;
            DeleteBtn.MouseLeave += DeleteButton_MouseLeave;
            StockDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private static readonly HttpClient client = new HttpClient();
        private const string SupabaseUrl = "https://owsbowcfbpkwofedkybn.supabase.co";
        private const string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im93c2Jvd2NmYnBrd29mZWRreWJuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mjk2NTE4NjcsImV4cCI6MjA0NTIyNzg2N30.wiqRZ6sch4uzw-1_pexljhvgHsUstKxp4V8Whlii-uc";

        private async void AddBtn_click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartQuantityTb.Text == "" || PartPriceTb.Text == "")
            {
                MessageBox.Show("Wrong Input");
            }
            else
            {
                try
                {
                    var stock = new
                    {
                        PartId = Convert.ToInt32(PartIdTb.Text.Trim()),
                        PartName = PartNameTb.Text.Trim(),
                        PartQty = Convert.ToInt32(PartQuantityTb.Text.Trim()),
                        PartPrice = Convert.ToInt32(PartPriceTb.Text.Trim()),
                    };

                    using (var request = new HttpRequestMessage(HttpMethod.Post, $"{SupabaseUrl}/rest/v1/StockTbl"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");
                        request.Headers.Add("Prefer", "return=minimal");

                        var json = System.Text.Json.JsonSerializer.Serialize(stock);
                        Console.WriteLine($"Sending JSON: {json}");

                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Stock Added Successfully");
                            // Reset các trường
                            PartIdTb.Text = "";
                            PartNameTb.Text = "";
                            PartPriceTb.Text = "";
                            PartQuantityTb.Text = "";
                            displayStocks();
                        }
                        else
                        {
                            MessageBox.Show($"Error: {responseContent}");
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = -1;
        private void StockDGV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (StockDGV.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = StockDGV.SelectedRows[0];
                    PartIdTb.Text = selectedRow.Cells[0].Value.ToString();
                    PartNameTb.Text = selectedRow.Cells[1].Value.ToString();
                    PartQuantityTb.Text = selectedRow.Cells[2].Value.ToString();
                    PartPriceTb.Text = selectedRow.Cells[3].Value.ToString();

                    // Set the Key (or EmpKey) for further operations like Edit/Delete
                    key = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async void EditBtn_click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartQuantityTb.Text == "" || PartPriceTb.Text == "")
            {
                MessageBox.Show("Wrong Input");
            }
            else
            {
                try
                {
                    var stock = new
                    {
                        PartId = Convert.ToInt32(PartIdTb.Text.Trim()),
                        PartName = PartNameTb.Text.Trim(),
                        PartQty = Convert.ToInt32(PartQuantityTb.Text.Trim()),
                        PartPrice = Convert.ToInt32(PartPriceTb.Text.Trim()),
                    };

                    using (var request = new HttpRequestMessage(HttpMethod.Put, $"{SupabaseUrl}/rest/v1/StockTbl?PartId=eq.{Convert.ToInt32(PartIdTb.Text.Trim())}"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");
                        request.Headers.Add("Prefer", "return=minimal");

                        var json = System.Text.Json.JsonSerializer.Serialize(stock);
                        Console.WriteLine($"Sending JSON: {json}");

                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Stock Edited Successfully");
                            // Reset các trường
                            PartIdTb.Text = "";
                            PartNameTb.Text = "";
                            PartPriceTb.Text = "";
                            PartQuantityTb.Text = "";
                            displayStocks();
                        }
                        else
                        {
                            MessageBox.Show($"Error: {responseContent}");
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private async void DeleteBtn_click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Stock");
            }
            else
            {
                try
                {
                    // Gửi yêu cầu DELETE với EmpId là EmpKey
                    using (var request = new HttpRequestMessage(HttpMethod.Delete, $"{SupabaseUrl}/rest/v1/StockTbl?PartId=eq.{key}"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Stock Deleted");
                            PartIdTb.Text = "";
                            PartNameTb.Text = "";
                            PartQuantityTb.Text = "";
                            PartPriceTb.Text = "";
                            displayStocks();
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

        private void AddButton_MouseEnter(object sender, EventArgs e)
        {
            AddBtn.BackColor = Color.LightGreen;
        }

        private void EditButton_MouseEnter(object sender, EventArgs e)
        {
            Editbtn.BackColor = Color.LightYellow;
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
            Editbtn.BackColor = Color.Silver;
        }

        private void DeleteButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteBtn.BackColor = Color.Silver;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Cars obj = new Cars();
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

