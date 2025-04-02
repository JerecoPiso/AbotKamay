using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class HomeForm : Form
    {
        // This static flag will be used to track if QueueForm is open
        public static bool isQueueFormOpen = false;

        private string role;

        private bool isMessageBoxShowing = false; // Prevent multiple triggers
        public HomeForm(string userRole = null)
        {
            InitializeComponent();

            this.Shown += HomeForm_Shown;

            if (userRole != null)
            {
                role = userRole;
            }

            LoadClients();
            SetupClientGrid();

            // If Admin Clerk 1 or 3, load all beneficiaries initially
            if (role == "Admin Clerk 1" || role == "Admin Clerk 3")
            {
                LoadAllBeneficiaries();
            }

            txtSearch.TextChanged += txtSearch_TextChanged;

            // Preserving the existing event handlers
            dgClient.CellDoubleClick += dgClient_CellDoubleClick;
            //dgClient.CellContentClick += dgClient_CellContentClick;
            dgClient.CellFormatting += dgClient_CellFormatting;


            // Add the refresh button for Admin Clerk 1 and 3
            if (role == "Admin Clerk 1" || role == "Admin Clerk 3")
            {
                Button btnRefresh = new Button();
                btnRefresh.Text = "Refresh Data";
                btnRefresh.Size = new Size(120, 30);
                btnRefresh.Location = new Point(txtSearch.Location.X + txtSearch.Width + 10, txtSearch.Location.Y);
                btnRefresh.BackColor = Color.FromArgb(0, 99, 177);
                btnRefresh.ForeColor = Color.White;
                btnRefresh.Font = new Font("Arial Rounded MT Bold", 9);
                // btnRefresh.Click += BtnRefresh_Click;
                this.Controls.Add(btnRefresh);
            }

        }

        // Event handler for cell formatting in dgClient
        private void dgClient_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgClient.Columns[e.ColumnIndex].Name == "LastAssistanceDate" && e.Value == DBNull.Value)
            {
                //e.Value = "Not found...";
                e.Value = "";
                e.FormattingApplied = true;
            }

        }


        private void LoadClients()
        {
            string query = @"
            SELECT 
                ci.client_id AS ClientID,
                CONCAT(ci.last_name, ' ', ci.first_name) AS FullName,
                ci.contact_number AS ContactNumber,
                ci.last_assistance_date AS LastAssistanceDate,";

            // Add date of birth for Admin Clerk 1
            if (role == "Admin Clerk 1")
            {
                query += "ci.date_of_birth AS DateOfBirth,";
            }

            query += @"
                CASE 
                    WHEN DATEDIFF(CURDATE(), ci.last_assistance_date) > 90 THEN 'Eligible' 
                    ELSE 'Not Eligible' 
                END AS Eligibility FROM clientinformation as ci 
                RIGHT JOIN beneficiaryinformation AS bi ON ci.client_id = bi.client_id 
                LEFT JOIN beneficiaryfamilycomposition bfc ON bi.beneficiary_id = bfc.beneficiary_id ";

           //$sql =0 @"LEFT JOIN beneficiaryinformation as bi ON ci.client_id = bi.client_id
           // LEFT JOIN 
           // FROM ClientInformation as ci";
            if (role == "Social Worker")
            {
                query += "WHERE DATE(bfc.created_timestamp) = CURDATE() ";
            }

            //query += @"ORDER BY FullName";
            query += @" ORDER BY bi.beneficiary_id DESC LIMIT 1";
            


            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["FullName"] = "";
                    newRow["ContactNumber"] = "";
                    newRow["LastAssistanceDate"] = DBNull.Value;
                    if (role == "Admin Clerk 1")
                    {
                        newRow["DateOfBirth"] = DBNull.Value;
                    }
                    newRow["Eligibility"] = "";
                    dt.Rows.Add(newRow);
                }
                dgClient.DataSource = dt;
                ApplyClientColorCoding();
            }
        }

        // New method to load all beneficiaries for Admin Clerk 1 and 3
        private void LoadAllBeneficiaries()
        {
            string query = @"
            SELECT 
                beneficiary_id AS BeneficiaryID,
                CONCAT(last_name, ' ', first_name) AS FullName,
                contact_number AS ContactNumber,
                last_assistance_date AS LastAssistanceDate,
                date_of_birth AS DateOfBirth,
                client_id AS ClientID,
                CASE 
                    WHEN DATEDIFF(CURDATE(), last_assistance_date) > 90 THEN 'Eligible' 
                    ELSE 'Not Eligible' 
                END AS Eligibility
            FROM BeneficiaryInformation
            ORDER BY FullName";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["FullName"] = "";
                    newRow["ContactNumber"] = "";
                    newRow["LastAssistanceDate"] = DBNull.Value;
                    newRow["DateOfBirth"] = DBNull.Value;
                    newRow["Eligibility"] = "";
                    dt.Rows.Add(newRow);
                }

                dgBenef.DataSource = dt;

                // First load: Show Date of Birth, hide Add as Client
                SetupBeneficiaryGrid(false);

                ApplyBeneficiaryColorCoding();
            }
        }




        // Original LoadBeneficiaries method that gets called on double-click
        private void LoadBeneficiaries(int clientId)
        {
            dgBenef.DataSource = null;

            string query = @"
    SELECT 
        beneficiary_id AS BeneficiaryID,
        CONCAT(last_name, ' ', first_name) AS FullName,
        contact_number AS ContactNumber,
        last_assistance_date AS LastAssistanceDate,
        date_of_birth AS DateOfBirth,
        client_id AS ClientID,
        CASE 
            WHEN DATEDIFF(CURDATE(), last_assistance_date) > 90 THEN 'Eligible' 
            ELSE 'Not Eligible' 
        END AS Eligibility
    FROM BeneficiaryInformation
    WHERE client_id = @clientId
    ORDER BY FullName";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["FullName"] = "";
                        newRow["ContactNumber"] = "";
                        newRow["LastAssistanceDate"] = DBNull.Value; // Keep it as NULL
                        newRow["DateOfBirth"] = DBNull.Value;
                        newRow["Eligibility"] = "";
                        dt.Rows.Add(newRow);
                    }



                    dgBenef.DataSource = dt;

                    // Check if at least one beneficiary qualifies (no record in ClientInformation)
                    bool hasEligibleBeneficiary = dt.AsEnumerable().Any(row =>
                        IsEligibleToBeClient(row["FullName"].ToString(), row["DateOfBirth"])
                    );

                    // If at least one is eligible, show "Add as Client" and remove "Date of Birth"
                    SetupBeneficiaryGrid(hasEligibleBeneficiary);

                    ApplyBeneficiaryColorCoding();
                }
            }
        }

        private bool IsEligibleToBeClient(string fullName, object dateOfBirth)
        {
            if (dateOfBirth == DBNull.Value) return false; // Skip if no date of birth

            string query = @"
            SELECT COUNT(*) 
            FROM ClientInformation 
            WHERE CONCAT(last_name, ' ', first_name) = @fullName 
            AND date_of_birth = @dateOfBirth";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@dateOfBirth", Convert.ToDateTime(dateOfBirth));

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0; // True if no client record exists
            }
        }








        // Helper method to highlight beneficiaries related to the selected client
        private void HighlightRelatedBeneficiaries(int clientId)
        {
            foreach (DataGridViewRow row in dgBenef.Rows)
            {
                if (row.Cells["ClientID"].Value != DBNull.Value &&
                    Convert.ToInt32(row.Cells["ClientID"].Value) == clientId)
                {
                    row.Selected = true;
                }
                else
                {
                    row.Selected = false;
                }
            }

            // Scroll to the first selected row if any
            if (dgBenef.SelectedRows.Count > 0)
            {
                dgBenef.FirstDisplayedScrollingRowIndex = dgBenef.SelectedRows[0].Index;
            }
        }



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            // For Admin Clerk 1 and 3, search both clients and beneficiaries
            if (role == "Admin Clerk 1" || role == "Admin Clerk 3")
            {
                SearchClients(searchTerm);
                SearchBeneficiaries(searchTerm);
            }
            else
            {
                // For other roles, only search clients
                SearchClients(searchTerm);
            }
        }



        private void SearchClients(string searchTerm)
        {
            string query = @"
            SELECT 
                ci.client_id AS ClientID,
                CONCAT(ci.last_name, ' ', ci.first_name) AS FullName,
                ci.contact_number AS ContactNumber,
                ci.last_assistance_date AS LastAssistanceDate,";

            // Add date of birth for Admin Clerk 1
            if (role == "Admin Clerk 1")
            {
                query += "ci.date_of_birth AS DateOfBirth,";
            }

            query += @"
                CASE 
                    WHEN DATEDIFF(CURDATE(), ci.last_assistance_date) > 90 THEN 'Eligible' 
                    ELSE 'Not Eligible' 
                END AS Eligibility
            FROM clientinformation as ci 
            RIGHT JOIN beneficiaryinformation AS bi ON ci.client_id = bi.client_id 
            LEFT JOIN beneficiaryfamilycomposition bfc ON bi.beneficiary_id = bfc.beneficiary_id  
            WHERE 
                (CONCAT(ci.last_name, ' ', ci.first_name) LIKE @searchTerm
                OR ci.contact_number LIKE @searchTerm
                OR DATE_FORMAT(ci.last_assistance_date, '%M') LIKE @searchTerm)";

            if (role == "Admin Clerk 1")
            {
                query += " OR DATE_FORMAT(ci.date_of_birth, '%M %d, %Y') LIKE @searchTerm ";
            }
            if (role == "Social Worker")
            {
                query += " AND DATE(bfc.created_timestamp) = CURDATE() ";
            }
            query += @" ORDER BY bi.beneficiary_id DESC LIMIT 1";
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgClient.DataSource = dt;
                    ApplyClientColorCoding();
              
                    // Display "Not Found" when no data is present
                    if (dt.Rows.Count == 0)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["FullName"] = "";
                        newRow["ContactNumber"] = "";
                        newRow["LastAssistanceDate"] = DBNull.Value;
                        if (role == "Admin Clerk 1")
                        {
                            newRow["DateOfBirth"] = DBNull.Value;
                        }
                        newRow["Eligibility"] = "";
                        dt.Rows.Add(newRow);
                    }
                }
            }
        }

        private void SearchBeneficiaries(string searchTerm)
        {
            if (role != "Admin Clerk 1" && role != "Admin Clerk 3") return;

            string query = @"
            SELECT 
                beneficiary_id AS BeneficiaryID,
                CONCAT(last_name, ' ', first_name) AS FullName,
                contact_number AS ContactNumber,
                last_assistance_date AS LastAssistanceDate,
                date_of_birth AS DateOfBirth,
                client_id AS ClientID,
                CASE 
                    WHEN DATEDIFF(CURDATE(), last_assistance_date) > 90 THEN 'Eligible' 
                    ELSE 'Not Eligible' 
                END AS Eligibility
            FROM BeneficiaryInformation
            WHERE 
                CONCAT(last_name, ' ', first_name) LIKE @searchTerm
                OR contact_number LIKE @searchTerm
                OR DATE_FORMAT(last_assistance_date, '%M') LIKE @searchTerm
                OR DATE_FORMAT(date_of_birth, '%M %d, %Y') LIKE @searchTerm
            ORDER BY FullName";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgBenef.DataSource = dt;

                    // Check if any beneficiary is NOT a client
                    bool hasBeneficiaryWithoutClient = dt.AsEnumerable().Any(row => row["ClientID"] == DBNull.Value);

                    // Pass the correct argument to SetupBeneficiaryGrid()
                    SetupBeneficiaryGrid(hasBeneficiaryWithoutClient);

                    ApplyBeneficiaryColorCoding();

                    // Display "Not Found" when no data is present
                    if (dt.Rows.Count == 0)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["FullName"] = "";
                        newRow["ContactNumber"] = "";
                        newRow["LastAssistanceDate"] = DBNull.Value;
                        newRow["DateOfBirth"] = DBNull.Value;
                        newRow["Eligibility"] = "";
                        dt.Rows.Add(newRow);
                    }
                }
            }
        }


        private void dgClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgClient.Rows[e.RowIndex].Cells["ClientID"].Value != null)
            {
                int clientId = Convert.ToInt32(dgClient.Rows[e.RowIndex].Cells["ClientID"].Value);
                LoadBeneficiaries(clientId);
            }
        }

        private void ApplyClientColorCoding()
        {
            foreach (DataGridViewRow row in dgClient.Rows)
            {
                if (row.Cells["Eligibility"].Value != null && row.Cells["Eligibility"].Value.ToString() == "Eligible")
                {
                    row.Cells["Eligibility"].Style.BackColor = Color.LightGreen;
                    row.Cells["Eligibility"].Style.ForeColor = Color.Black;
                }
                else if (row.Cells["Eligibility"].Value != null)
                {
                    row.Cells["Eligibility"].Style.BackColor = Color.LightGray;
                    row.Cells["Eligibility"].Style.ForeColor = Color.Black;
                }
            }
        }

        private void ApplyBeneficiaryColorCoding()
        {
            foreach (DataGridViewRow row in dgBenef.Rows)
            {
                if (row.Cells["Eligibility"].Value != null && row.Cells["Eligibility"].Value.ToString() == "Eligible")
                {
                    row.Cells["Eligibility"].Style.BackColor = Color.LightGreen;
                    row.Cells["Eligibility"].Style.ForeColor = Color.Black;
                }
                else if (row.Cells["Eligibility"].Value != null)
                {
                    row.Cells["Eligibility"].Style.BackColor = Color.LightGray;
                    row.Cells["Eligibility"].Style.ForeColor = Color.Black;
                }
            }
        }


        // Event handler to track when QueueForm is closed
        private void QueueForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isQueueFormOpen = false; // Reset the flag when QueueForm is closed
        }


        public void loadform(object Form)
        {
            // Clear the mainPanel first, but don't dispose of the controls
            if (this.mainPanel.Controls.Count > 0)
            {
                this.mainPanel.Controls.Clear();
            }

            // Add the new form
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f; // Optionally, tag the panel with the form
            f.Show();
        }


        private void HomeForm_Shown(object sender, EventArgs e)
        {
            dgClient.ClearSelection();
            dgClient.CurrentCell = null;
            ApplyClientColorCoding();
            ApplyBeneficiaryColorCoding();

            switch (role)
            {
                case "Admin Clerk 1":
                    btnAddNew.Visible = false;
                    break;
                case "Admin Clerk 3":
                    // First Load: Show Date of Birth, hide Add as Client
                    SetupBeneficiaryGrid(false);
                    break;
                case "Social Worker":
                case "SDO":
                    btnAddNew.Visible = false;
                    dgClient.Size = new Size(1386, 709);
                    lblBenef.Visible = false;
                    dgBenef.Visible = false;
                    break;
            }
        }



        /* private void dgClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {
             if (e.RowIndex >= 0)
             {
                 int clientId = Convert.ToInt32(dgClient.Rows[e.RowIndex].Cells["ClientID"].Value);
                 string fullName = dgClient.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                 string eligibility = dgClient.Rows[e.RowIndex].Cells["Eligibility"].Value.ToString();

                 if (dgClient.Columns.Contains("Control") && e.ColumnIndex == dgClient.Columns["Control"].Index)
                 {
                     string buttonText = dgClient.Rows[e.RowIndex].Cells["Control"].Value.ToString();

                     // Check eligibility before proceeding
                     if (eligibility == "Not Eligible")
                     {
                         MessageBox.Show($"{fullName} is not eligible for this action.", "Eligibility Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         return;
                     }

                     HandleButtonClick(buttonText, clientId, fullName);
                 }
                 else if (dgClient.Columns.Contains("Edit") && e.ColumnIndex == dgClient.Columns["Edit"].Index)
                 {
                     // Restrict editing to only Admins
                     if (role != "Admin")
                     {
                         MessageBox.Show("Only admins are allowed to edit client information.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                     }

                     HandleButtonClick("Edit", clientId, fullName);
                 }
             }
         }*/


        private void HandleButtonClick(string buttonText, int clientId, string fullName)
        {
            switch (role)
            {
                case "Admin Clerk 3" when buttonText == "Add" || buttonText == "Edit":
                    MessageBox.Show("df");
                    Step3Form step3Form = new Step3Form(role, clientId, fullName);
                    loadform(step3Form);
                    break;
                case "Social Worker" when buttonText == "Assess" || buttonText == "Edit":
                    Step4Form step4Form = new Step4Form(role, clientId, fullName);
                    loadform(step4Form);
                    break;
                case "SDO" when buttonText == "Disburse" || buttonText == "Edit":
                    Step5Form step5Form = new Step5Form(role, clientId, fullName);
                    loadform(step5Form);
                    break;
            }
        }



        private void SetupClientGrid()
        {
            if (dgClient.Columns.Count == 0) return;

            dgClient.Columns["ClientID"].Visible = false;
            dgClient.Columns["FullName"].HeaderText = "Client Name";
            dgClient.Columns["ContactNumber"].HeaderText = "Contact";
            dgClient.Columns["LastAssistanceDate"].HeaderText = "Last Assistance Date";
            dgClient.Columns["Eligibility"].HeaderText = "Eligibility";

         //   dgClient.Columns["FullName"].Width = 280;
        //    dgClient.Columns["ContactNumber"].Width = 240;
          //  dgClient.Columns["LastAssistanceDate"].Width = 280;
          //  dgClient.Columns["Eligibility"].Width = 250;


            dgClient.Columns["LastAssistanceDate"].DefaultCellStyle.Format = "MMMM dd, yyyy";
            if (role.Equals("Social Worker"))
            {
            //    dgClient.Columns["FullName"].Width = 410;
             //   dgClient.Columns["LastAssistanceDate"].Width = 410;

                dgClient.Columns["Eligibility"].Visible = false;

            }
            // Ensure "Date of Birth" is correctly placed after "Eligibility" for Admin Clerk 1
            if (role == "Admin Clerk 1")
            {
                if (dgClient.Columns.Contains("DateOfBirth"))
                {
                    dgClient.Columns["DateOfBirth"].HeaderText = "Date of Birth";
                  //  dgClient.Columns["DateOfBirth"].Width = 285;
                    dgClient.Columns["DateOfBirth"].DefaultCellStyle.Format = "MMMM dd, yyyy";

                    // Move "Date of Birth" after "Eligibility"
                    int eligibilityIndex = dgClient.Columns["Eligibility"].DisplayIndex;
                    int newDobIndex = Math.Min(eligibilityIndex + 1, dgClient.Columns.Count - 1);
                    dgClient.Columns["DateOfBirth"].DisplayIndex = newDobIndex;
                }
            }

            // Don't add control/edit buttons for Admin Clerk 1
            if (role != "Admin Clerk 1")
            {
                DataGridViewCellStyle buttonStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 99, 177),
                    ForeColor = Color.White,
                    Font = new Font("Arial Rounded MT Bold", 8)
                };

                if (!dgClient.Columns.Contains("Control"))
                {
                    DataGridViewButtonColumn controlsColumn = new DataGridViewButtonColumn
                    {
                        Name = "Control",
                        HeaderText = "Control",
                        Text = role == "Admin Clerk 3" ? "Add" : role == "Social Worker" ? "Assess" : "Disburse",
                        UseColumnTextForButtonValue = true,
                        DefaultCellStyle = buttonStyle
                    };
                    dgClient.Columns.Add(controlsColumn);
                }

                if (!dgClient.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editButton = new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true,
                        DefaultCellStyle = buttonStyle
                    };
                    dgClient.Columns.Add(editButton);
                }
            }
        }


        private void SetupBeneficiaryGrid(bool showAddClient)
        {
            if (dgBenef.Columns.Count == 0) return;

            dgBenef.Columns["BeneficiaryID"].Visible = false;
            if (dgBenef.Columns.Contains("ClientID"))
            {
                dgBenef.Columns["ClientID"].Visible = false;
            }

            dgBenef.Columns["FullName"].HeaderText = "Beneficiary Name";
            //dgBenef.Columns["FullName"].Width = 280;
            dgBenef.Columns["ContactNumber"].HeaderText = "Contact";
            //dgBenef.Columns["ContactNumber"].Width = 240;
            dgBenef.Columns["LastAssistanceDate"].HeaderText = "Last Assistance Date";
            //dgBenef.Columns["LastAssistanceDate"].Width = 280;
            dgBenef.Columns["Eligibility"].HeaderText = "Eligibility";
            //dgBenef.Columns["Eligibility"].Width = 250;
            dgBenef.Columns["LastAssistanceDate"].DefaultCellStyle.Format = "MMMM dd, yyyy";

            // Ensure "Date of Birth" is always visible for Admin Clerk 1
            if (role == "Admin Clerk 1" || !showAddClient)
            {
                if (!dgBenef.Columns.Contains("DateOfBirth"))
                {
                    DataGridViewTextBoxColumn dobColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "DateOfBirth",
                        HeaderText = "Date of Birth",
                        DefaultCellStyle = new DataGridViewCellStyle { Format = "MMMM dd, yyyy" }
                    };
                    dgBenef.Columns.Add(dobColumn);
                }

                dgBenef.Columns["DateOfBirth"].HeaderText = "Date of Birth";
             //   dgBenef.Columns["DateOfBirth"].Width = 282;
                dgBenef.Columns["DateOfBirth"].DefaultCellStyle.Format = "MMMM dd, yyyy";

                // Ensure "Date of Birth" is placed AFTER "Eligibility"
                if (dgBenef.Columns.Contains("DateOfBirth") && dgBenef.Columns.Contains("Eligibility"))
                {
                    int eligibilityIndex = dgBenef.Columns["Eligibility"].DisplayIndex;
                    int newDobIndex = Math.Min(eligibilityIndex + 1, dgBenef.Columns.Count - 1);
                    dgBenef.Columns["DateOfBirth"].DisplayIndex = newDobIndex;
                }
            }

            if (showAddClient)
            {
                // Only remove "Date of Birth" for Admin Clerk 3 (not Admin Clerk 1)
                if (role == "Admin Clerk 3" && dgBenef.Columns.Contains("DateOfBirth"))
                {
                    dgBenef.Columns.Remove("DateOfBirth");
                }

                // Add "Add as Client" button for Admin Clerk 3
                if (role == "Admin Clerk 3" && !dgBenef.Columns.Contains("AddAsClient"))
                {
                    DataGridViewButtonColumn addAsClientButton = new DataGridViewButtonColumn
                    {
                        Name = "AddAsClient",
                        HeaderText = "Add as Client",
                        Text = "Add as Client",
                        UseColumnTextForButtonValue = true,
                        DefaultCellStyle = new DataGridViewCellStyle
                        {
                            BackColor = Color.FromArgb(0, 99, 177),
                            ForeColor = Color.White,
                            Font = new Font("Arial Rounded MT Bold", 8),
                            Alignment = DataGridViewContentAlignment.MiddleCenter
                        }
                    };
                    dgBenef.Columns.Add(addAsClientButton);
                }

                if (dgBenef.Columns.Contains("AddAsClient"))
                {
                    dgBenef.Columns["AddAsClient"].Width = 282;
                    dgBenef.Columns["AddAsClient"].DisplayIndex = dgBenef.Columns.Count - 1;
                }
            }
            else
            {
                // Remove "Add as Client" if it exists
                if (dgBenef.Columns.Contains("AddAsClient"))
                {
                    dgBenef.Columns.Remove("AddAsClient");
                }
            }

            // Ensure "No Beneficiary Found..." appears in Last Assistance Date
            dgBenef.CellFormatting += (s, e) =>
            {
                if (dgBenef.Columns[e.ColumnIndex].Name == "LastAssistanceDate" && e.Value == DBNull.Value)
                {
                    //e.Value = "No beneficiary found...";
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            };

            dgBenef.Update();
            dgBenef.Refresh();
        }




        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            switch (role)
            {
                case "Admin Clerk 3":
                   
                    Step3Form step3Form = new Step3Form(role); // Pass role to Step3Form
                    loadform(step3Form); // Load the form in the mainPanel
                    break;

                default:
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reload all data
            LoadClients();
            ApplyClientColorCoding();

            if (role == "Admin Clerk 1" || role == "Admin Clerk 3")
            {
                LoadAllBeneficiaries();
                ApplyBeneficiaryColorCoding();
            }
        }

        private void dgBenef_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow clickedRow = dgBenef.Rows[e.RowIndex];

                if (clickedRow.Selected)
                {
                    clickedRow.Selected = false;
                }
                else
                {
                    dgBenef.ClearSelection();
                    clickedRow.Selected = true;
                }
            }
        }

        private void dgBenef_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked column is "AddAsClient"
            if (e.ColumnIndex >= 0 && dgBenef.Columns[e.ColumnIndex].Name == "AddAsClient")
            {
                MessageBox.Show("Sorry, this feature is not yet working.", "Feature Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Prevent any further execution
            }

            /*if (role == "Admin Clerk 3" && e.RowIndex >= 0 &&
                dgBenef.Columns.Contains("AddAsClient") &&
                e.ColumnIndex == dgBenef.Columns["AddAsClient"].Index)
            {
                // Get beneficiary ID
                if (dgBenef.Rows[e.RowIndex].Cells["BeneficiaryID"].Value != DBNull.Value)
                {
                    int beneficiaryId = Convert.ToInt32(dgBenef.Rows[e.RowIndex].Cells["BeneficiaryID"].Value);

                    // Open Step3Form to add this beneficiary as a client
                    Step3Form step3Form = new Step3Form(role); //, beneficiaryId
                    loadform(step3Form);
                }
            }*/


        }

        private void dgBenef_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgBenef.Columns[e.ColumnIndex].Name == "AddAsClient" && e.RowIndex >= 0)
            {
                var clientId = dgBenef.Rows[e.RowIndex].Cells["ClientID"].Value;
                if (clientId == DBNull.Value)
                {
                    e.Value = "";
                }
                else
                {
                    e.Value = "Add as Client";
                }
                e.FormattingApplied = true;
            }
        }

        private void dgClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int clientId = Convert.ToInt32(dgClient.Rows[e.RowIndex].Cells["ClientID"].Value);
                string fullName = dgClient.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                string eligibility = dgClient.Rows[e.RowIndex].Cells["Eligibility"].Value.ToString();

                if (dgClient.Columns.Contains("Control") && e.ColumnIndex == dgClient.Columns["Control"].Index)
                {
                    string buttonText = dgClient.Rows[e.RowIndex].Cells["Control"].Value.ToString();

                    // Check eligibility before proceeding
                    //if (eligibility == "Not Eligible")
                    //{
                    //    // MessageBox.Show($"{fullName} is not eligible for this action.", "Eligibility Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    HandleButtonClick(buttonText, clientId, fullName);
                }
                else if (dgClient.Columns.Contains("Edit") && e.ColumnIndex == dgClient.Columns["Edit"].Index)
                {
                    // Restrict editing to only Admins
                    if (role != "Admin")
                    {
                        MessageBox.Show("Only admins are allowed to edit client information.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    HandleButtonClick("Edit", clientId, fullName);
                }
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgClient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PrintGeneralntakeSheet printForm = new PrintGeneralntakeSheet(this);
            //printForm.Show();
        }
    }
}




