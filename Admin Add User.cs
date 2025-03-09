using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracking_and_Queuing_System
{
    public partial class AddUserForm : Form
    {
        //Class-level variables
        private string currentUsername;
        private bool isEditMode = false;


        public AddUserForm()
        {
            InitializeComponent();
            LoadUsersIntoDataGrid();
            LoadFirstUserData();

        }

        //------------------------------------------------ MY FUNCTIONS ----------------------------------------------

        // Loading Data to Datagrid
        private void LoadUsersIntoDataGrid()
        {
            string query = "SELECT user_name AS 'Username', user_pass AS 'Password', user_role AS 'Role', first_name AS 'First Name', last_name AS 'Last Name' FROM users";

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgUsers.DataSource = dt;
            }
        }

        // Loading the first data in database to textboxes and combobox
        private void LoadFirstUserData()
        {
            if (dgUsers.Rows.Count > 0)
            {
                DataGridViewRow firstRow = dgUsers.Rows[0];
                txtUsername.Text = firstRow.Cells["Username"].Value.ToString();
                txtPassword.Text = firstRow.Cells["Password"].Value.ToString();
                cmbRole.SelectedItem = firstRow.Cells["Role"].Value.ToString();
                txtFirstName.Text = firstRow.Cells["First Name"].Value.ToString();
                txtLastName.Text = firstRow.Cells["Last Name"].Value.ToString();

                SetControlsReadOnly(true);
            }
        }

        // Control for readonly textboxes, combobox, and buttons
        private void SetControlsReadOnly(bool isReadOnly)
        {
            txtUsername.ReadOnly = isReadOnly;
            txtPassword.ReadOnly = isReadOnly;
            txtFirstName.ReadOnly = isReadOnly;
            txtLastName.ReadOnly = isReadOnly;
            cmbRole.Enabled = !isReadOnly;
            btnSave.Enabled = !isReadOnly;
            btnEdit.Enabled = isReadOnly;
        }

        // Deleting data inside textboxes and combobox
        private void ClearControls()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            cmbRole.SelectedIndex = -1; // Clear ComboBox selection
        }

        // Checking if username is unique
        private bool IsUsernameUnique(string username)
        {
            string query = "SELECT COUNT(*) FROM users WHERE user_name = @username";

            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                int userCount = Convert.ToInt32(command.ExecuteScalar());
                return userCount == 0;
            }
        }

        //------------------------------------------------ FUNCTIONS END ----------------------------------------------




        //------------------------------------------ FORM, DATAGRID, AND BUTTONS --------------------------------------


        //Form
        private void AddUserForm_Load(object sender, EventArgs e)
        {
            LoadUsersIntoDataGrid();
            btnSave.BackColor = Color.Gray;
        }


        //When user click a cell in the datagrid
        private void dgUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgUsers.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();
                txtFirstName.Text = row.Cells["First Name"].Value.ToString();
                txtLastName.Text = row.Cells["Last Name"].Value.ToString();

                SetControlsReadOnly(true);
                btnEdit.Enabled = true;
                isEditMode = true; // Set mode to edit existing user
            }
        }

        //Add New Button
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearControls();
            SetControlsReadOnly(false);
            btnEdit.Enabled = false;
            isEditMode = false; // Set mode to add new user
        }

        //Edit Button
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.Gray;
            btnSave.BackColor = Color.FromArgb(0, 99, 177);

            SetControlsReadOnly(false);
            txtUsername.ReadOnly = true; // Ensuring username is read-only during edit
            isEditMode = true; // Set mode to edit existing user
        }

        //Save Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validating inputs
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the username is unique, only for new users
            if (isEditMode == false && !IsUsernameUnique(txtUsername.Text))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query;
            bool isNewUser = !isEditMode; // Determine if adding a new user

            if (isNewUser) // Adding a new user
            {
                query = "INSERT INTO users (user_name, user_pass, user_role, first_name, last_name) VALUES (@username, @password, @role, @firstName, @lastName)";
            }
            else // Editing an existing user
            {
                query = "UPDATE users SET user_pass = @password, user_role = @role, first_name = @firstName, last_name = @lastName WHERE user_name = @username";
            }

            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Ensure parameters are added in the correct order as per SQL query
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    command.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@firstName", txtFirstName.Text); // First Name should come here
                    command.Parameters.AddWithValue("@lastName", txtLastName.Text); // Last Name should come here

                    command.ExecuteNonQuery();
                    MessageBox.Show(isNewUser ? "User successfully added." : "User successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Refresh DataGrid and clear controls
            LoadUsersIntoDataGrid();
            ClearControls();
            SetControlsReadOnly(true);
            isEditMode = false; // Reset edit mode
        }


        //Clear Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        //Delete Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please select a user to delete.", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string query = "DELETE FROM users WHERE user_name = @username";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", txtUsername.Text);

                    command.ExecuteNonQuery();
                }

                LoadUsersIntoDataGrid();
                ClearControls();
                SetControlsReadOnly(true);
            }
        }


        //Close or (X) Button
        private void lblEx_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCheckPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = chkCheckPass.Checked;
        }

        //----------------------------------------- FORM, DATAGRID, AND BUTTONS END------------------------------------

    }

}
