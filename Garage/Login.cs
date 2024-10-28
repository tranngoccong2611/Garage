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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private static readonly HttpClient client = new HttpClient();
        private const string SupabaseUrl = "https://owsbowcfbpkwofedkybn.supabase.co";
        private const string SupabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im93c2Jvd2NmYnBrd29mZWRreWJuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mjk2NTE4NjcsImV4cCI6MjA0NTIyNzg2N30.wiqRZ6sch4uzw-1_pexljhvgHsUstKxp4V8Whlii-uc";

        private void AdminLog_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }

        private async void UserSign_Click(object sender, EventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(UsernameTbl.Text) || string.IsNullOrWhiteSpace(PasswordTbl.Text))
                {
                    MessageBox.Show("Please enter both username and password.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Prepare the API request
                var employee = new Employee
                {
                    EmpAdd = UsernameTbl.Text,
                    EmpPass = PasswordTbl.Text
                };

                // Sửa đổi URL để chỉ lấy một bản ghi duy nhất với EmpAdd
                var request = new HttpRequestMessage(HttpMethod.Get,
                    $"{SupabaseUrl}/rest/v1/EmployeeTbl?EmpAdd=eq.{Uri.EscapeDataString(employee.EmpAdd)}&select=*");

                // Add Supabase headers
                request.Headers.Add("apikey", SupabaseApiKey);
                request.Headers.Add("Authorization", $"Bearer {SupabaseApiKey}");
                request.Headers.Add("Prefer", "return=representation");

                // Send request and handle response
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var employees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(content);

                    if (employees != null && employees.Any())
                    {
                        // Kiểm tra mật khẩu
                        var foundEmployee = employees[0];
                        if (foundEmployee.EmpPass == employee.EmpPass)
                        {
                            // Login successful
                            MessageBox.Show("Login Successful!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Create and show the Billings form with employee name
                            Billing billingForm = new Billing();
                            billingForm.EmployeeName = foundEmployee.EmpName;
                            billingForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Account not found.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error connecting to the server: {errorContent}",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Network error: {ex.Message}", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
