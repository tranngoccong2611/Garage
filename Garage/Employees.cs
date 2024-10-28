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

namespace Garage
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            displayEmployees();
        }

        private static readonly HttpClient client = new HttpClient();
        private const string SupabaseUrl = "https://owsbowcfbpkwofedkybn.supabase.co";
        private const string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im93c2Jvd2NmYnBrd29mZWRreWJuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mjk2NTE4NjcsImV4cCI6MjA0NTIyNzg2N30.wiqRZ6sch4uzw-1_pexljhvgHsUstKxp4V8Whlii-uc";

        private void Employee_Load(object sender, EventArgs e)
        {
            AddBtn.MouseEnter += AddButton_MouseEnter;
            AddBtn.MouseLeave += AddButton_MouseLeave;

            EditBtn.MouseEnter += EditButton_MouseEnter;
            EditBtn.MouseLeave += EditButton_MouseLeave;

            DeleteBtn.MouseEnter += DeleteButton_MouseEnter;
            DeleteBtn.MouseLeave += DeleteButton_MouseLeave;
            EmployeeDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void displayEmployees()
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, $"{SupabaseUrl}/rest/v1/EmployeeTbl"))
                {
                    request.Headers.Add("apikey", SupabaseApiKey);
                    request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                    var response = await client.SendAsync(request);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var employees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(responseContent);
                        EmployeeDGV.DataSource = employees;
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

        private async void AddBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "Employee Name" || EmpPassTb.Text == "Employee Password" ||
                EmpAddTb.Text == "Employee Address" || EmpGenCb.SelectedIndex == -1 ||
                EmpNameTb.Text == "" || EmpPassTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Wrong Input");
            }
            else
            {
                try
                {
                    var employee = new
                    {
                        EmpId = Convert.ToInt32(EmpIdTb.Text.Trim()),
                        EmpName = EmpNameTb.Text.Trim(),
                        EmpPass = EmpPassTb.Text.Trim(),
                        EmpAdd = EmpAddTb.Text.Trim(),
                        EmpGen = EmpGenCb.SelectedItem.ToString()
                    };

                    using (var request = new HttpRequestMessage(HttpMethod.Post, $"{SupabaseUrl}/rest/v1/EmployeeTbl"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");
                        request.Headers.Add("Prefer", "return=minimal");

                        var json = System.Text.Json.JsonSerializer.Serialize(employee);
                        Console.WriteLine($"Sending JSON: {json}");

                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Employee Added Successfully");
                            // Reset các trường
                            EmpIdTb.Text = "";
                            EmpNameTb.Text = "";
                            EmpPassTb.Text = "";
                            EmpAddTb.Text = "";
                            EmpGenCb.SelectedIndex = -1;
                            displayEmployees();
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

        int Key = 0; // Khai báo Key là kiểu int

        private void EmployeeDGV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (EmployeeDGV.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = EmployeeDGV.SelectedRows[0];
                    EmpIdTb.Text = selectedRow.Cells[0].Value.ToString();
                    EmpNameTb.Text = selectedRow.Cells[1].Value.ToString();
                    EmpGenCb.SelectedItem = selectedRow.Cells[2].Value.ToString();
                    EmpAddTb.Text = selectedRow.Cells[4].Value.ToString();
                    EmpPassTb.Text = selectedRow.Cells[3].Value.ToString();

                    // Set the Key (or EmpKey) for further operations like Edit/Delete
                    Key = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Employee");
            }
            else
            {
                try
                {
                    // Gửi yêu cầu DELETE với EmpId là EmpKey
                    using (var request = new HttpRequestMessage(HttpMethod.Delete, $"{SupabaseUrl}/rest/v1/EmployeeTbl?EmpId=eq.{Key}"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");

                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Employee Deleted");
                            EmpIdTb.Text = "";
                            EmpNameTb.Text = "";
                            EmpPassTb.Text = "";
                            EmpAddTb.Text = "";
                            EmpGenCb.SelectedIndex = -1;
                            displayEmployees(); // Cập nhật lại danh sách sau khi xóa
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
            if (EmpNameTb.Text == "Employee Name" || EmpPassTb.Text == "Employee Password" ||
                EmpAddTb.Text == "Employee Address" || EmpGenCb.SelectedIndex == -1 ||
                EmpNameTb.Text == "" || EmpPassTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Wrong Input");
            }
            else
            {
                try
                {
                    var employee = new
                    {
                        EmpId = Convert.ToInt32(EmpIdTb.Text.Trim()),
                        EmpName = EmpNameTb.Text.Trim(),
                        EmpPass = EmpPassTb.Text.Trim(),
                        EmpAdd = EmpAddTb.Text.Trim(),
                        EmpGen = EmpGenCb.SelectedItem.ToString()
                    };

                    using (var request = new HttpRequestMessage(HttpMethod.Put, $"{SupabaseUrl}/rest/v1/EmployeeTbl?EmpId=eq.{Convert.ToInt32(EmpIdTb.Text.Trim())}"))
                    {
                        request.Headers.Add("apikey", SupabaseApiKey);
                        request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");
                        request.Headers.Add("Prefer", "return=minimal");

                        var json = System.Text.Json.JsonSerializer.Serialize(employee);
                        Console.WriteLine($"Sending JSON: {json}");

                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.SendAsync(request);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Employee Updated");
                            EmpIdTb.Text = "";
                            EmpNameTb.Text = "";
                            EmpPassTb.Text = "";
                            EmpAddTb.Text = "";
                            EmpGenCb.SelectedIndex = -1;
                            displayEmployees();
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


        // Mouse hover effects
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