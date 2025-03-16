using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // Automatically trigger login when pressing Enter
            this.AcceptButton = btnLogin;

            txtUsername.KeyPress += txtUsername_KeyPress;
            txtUsername.TextChanged += txtUsername_TextChanged;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            timeDateTimer.Start();
            txtUsername.Text = "clerk3";
            txtPassword.Text = "Cl3rk333";
            txtUsername.Text = "socialworker1";
            txtPassword.Text = "Worker1p@55";

            this.KeyDown += LoginForm_KeyDown;
            txtPassword.KeyDown += txtPassword_KeyDown; // Trigger login and prevent newline
        }

        private void timeDateTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void ConnectToDatabase()
        {
            // Get the username and password from input fields
            string username = txtUsername.Text.Trim().ToLower(); // Remove whitespace and convert to lowercase
            string password = txtPassword.Text;

            // Validation: Ensure all required fields are filled out
            if (!ValidateRequiredFields(username, password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation: Ensure username and password meet specific criteria
            if (!ValidateUsername(username) || !ValidatePassword(password))
            {
                MessageBox.Show("Invalid username or password format. Please try again.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "SELECT first_name, user_role FROM users WHERE BINARY user_name = @username AND BINARY user_pass = @password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["first_name"].ToString();
                            string userRole = reader["user_role"].ToString();

                            // Update the last login time
                            UpdateLastLogin(username);

                            //   MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Pass the first name and role to the main form
                            OpenFormBasedOnRole(userRole, firstName);
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
        }

        private void UpdateLastLogin(string username)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string updateQuery = "UPDATE users SET last_login = CURRENT_TIMESTAMP WHERE BINARY user_name = @username";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@username", username);
                updateCommand.ExecuteNonQuery();
            }
        }



        private void OpenFormBasedOnRole(string userRole, string firstName)
        {
            Form mainForm;
            Form inputQueueForm;

            switch (userRole)
            {
                case "Admin Clerk 2":
                    inputQueueForm = new InputQueueForm();
                    inputQueueForm.Show();
                    break;
                case "Admin":
                case "Admin Clerk 1":
                case "Admin Clerk 3":
                case "Social Worker":
                case "SDO":
                    mainForm = new MainForm(userRole, firstName);
                    mainForm.Show();
                    break;

                default:
                    mainForm = new MainForm(); // A default form or generic form
                    mainForm.Show();
                    break;
            }

            this.Hide(); // Hide the current form
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }

        private void lblEx_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkViewPass_CheckedChanged(object sender, EventArgs e)
        {
            // Reveal and unreveal password
            txtPassword.UseSystemPasswordChar = chkViewPass.Checked;
        }


        private bool ValidateRequiredFields(string username, string password)
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }

        private bool ValidateUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username);
        }

        private bool ValidatePassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
            return regex.IsMatch(password);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevent new line
                ConnectToDatabase();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string lowerUsername = txtUsername.Text.ToLower();
            if (txtUsername.Text != lowerUsername)
            {
                txtUsername.Text = lowerUsername;
                txtUsername.SelectionStart = txtUsername.Text.Length;
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevent adding a new line

                // Trigger the login button click event
                btnLogin.PerformClick();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a space
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press if it's a space
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
