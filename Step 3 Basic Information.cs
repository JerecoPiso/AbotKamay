using Abot_Kamay_Tracking_and_Queuing_System.Services;
using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Region = Abot_Kamay_Tracking_and_Queuing_System.Models.GeographicalRegion;



namespace Abot_Kamay_Tracking_and_Queuing_System
{
    //public class UnselectableRadioButton : RadioButton
    //{
    //    protected override void OnClick(EventArgs e)
    //    {
    //        if (this.Checked)
    //        {
    //            this.Checked = false;
    //        }
    //        else
    //        {
    //            base.OnClick(e);
    //        }
    //    }
    //}
    public partial class Step3Form : Form
    {   
       // private UnselectableRadioButton 
        private int currentClientId;
        private int currentBeneficiaryId;

        private string role;

        private AddressDataLoader dataLoader;

        private bool allowTabChange = false;

        List<DataRow> familyMemberList = new List<DataRow>();

        public Step3Form(string userRole, int? clientId = null, string fullName = null)
        {
            InitializeComponent();

            role = userRole;

            if (clientId.HasValue)
            {
                lblGetName.Text = fullName;
                LoadClientData(clientId.Value); // Load client data only if ID is provided
            }
            else
            {
                lblGetName.Visible = false;
            }

                // Subscribe to the TextChanged event for all TextBox controls
                SubscribeToTextChanged(this);

            // Other initialization code...
            LoadAllComboBoxes();

            //KeyPress event for contact and PhilHealth textboxes
            txtContact.KeyPress += txtContact_KeyPress;
            txtPHealth.KeyPress += txtPHealth_KeyPress;
            txtbContact.KeyPress += txtbContact_KeyPress;


            txtContact.TextChanged += txtContact_TextChanged;
            txtbContact.TextChanged += txtbContact_TextChanged;


            chkSelf.CheckedChanged += chkSelf_CheckedChanged;

            dataLoader = new AddressDataLoader();
            dataLoader.LoadData();


            // Populate regions for Tab1 and Tab2
            PopulateRegions(cmbRegion);
            PopulateRegions(cmbbRegion);

            // Wire up event handlers for Tab1
            cmbRegion.SelectedIndexChanged += cmbRegion_SelectedIndexChanged;
            cmbProvince.SelectedIndexChanged += cmbProvince_SelectedIndexChanged;
            cmbCity.SelectedIndexChanged += cmbCity_SelectedIndexChanged;

            // Wire up event handlers for Tab2
            cmbbRegion.SelectedIndexChanged += cmbbRegion_SelectedIndexChanged;
            cmbbProvince.SelectedIndexChanged += cmbbProvince_SelectedIndexChanged;
            cmbbCity.SelectedIndexChanged += cmbbCity_SelectedIndexChanged;
        }

        private void LoadClientData(int clientId)
        {
            string query = @"
            SELECT c.last_name, c.first_name, c.middle_name, c.ext_name, c.birth_place, 
                   c.contact_number, c.date_of_birth, c.sex, 
                   c.region, c.province, c.city_municipality, c.district, c.barangay, c.street_purok,
                   c.nationality, c.id_number, c.civil_status, c.civil_status_other, c.id_type_id, 
                   c.religion_id, c.occupation_id, c.income_range_id, c.highest_educ_attainment,
                   c.relationship_to_beneficiary, c.mode_of_admission, c.referring_party,
                   o.occupation_name, i.income_range, r.religion_name, idt.id_name, e.education_level
            FROM ClientInformation c
            LEFT JOIN Occupation o ON c.occupation_id = o.occupation_id
            LEFT JOIN IncomeRange i ON c.income_range_id = i.income_range_id
            LEFT JOIN Religions r ON c.religion_id = r.religion_id
            LEFT JOIN IdTypes idt ON c.id_type_id = idt.id_type_id
            LEFT JOIN EducationalAttainment e ON c.highest_educ_attainment = e.educational_id
            WHERE c.client_id = @clientId";

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@clientId", clientId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Basic Info
                        txtLastName.Text = reader["last_name"].ToString();
                        txtFirstName.Text = reader["first_name"].ToString();
                        txtMidName.Text = reader["middle_name"].ToString();
                        txtExtJrSr.Text = reader["ext_name"].ToString();
                        txtBirthPlace.Text = reader["birth_place"].ToString();
                        txtNationality.Text = reader["nationality"].ToString();
                        txtIdNum.Text = reader["id_number"].ToString();
                        txtContact.Text = reader["contact_number"]?.ToString() ?? "09";

                        // Birthdate
                        if (reader["date_of_birth"] != DBNull.Value)
                            dateTimePickerBirth.Value = Convert.ToDateTime(reader["date_of_birth"]);
                        else
                            dateTimePickerBirth.Value = DateTime.Today;

                        // Address
                        //PopulateRegions(cmbRegion);
                        cmbRegion.Text = reader["region"].ToString();  // Use .Text instead of .SelectedValue
                        cmbProvince.Text = reader["province"].ToString();
                        cmbCity.Text = reader["city_municipality"].ToString();
                        txtDistrict.Text = reader["district"].ToString();
                        cmbBarangay.Text = reader["barangay"].ToString();
                        txtStPurok.Text = reader["street_purok"].ToString();

                        // Dropdowns
                        cmbIdType.SelectedValue = reader["id_type_id"];
                        cmbReligion.SelectedValue = reader["religion_id"];
                        cmbOccupation.SelectedValue = reader["occupation_id"];
                        cmbIncomeRange.SelectedValue = reader["income_range_id"];
                        cmbHighestEduc.SelectedValue = reader["highest_educ_attainment"];

                        // Sex
                        if (reader["sex"].ToString() == "Male")
                            rBtnMale.Checked = true;
                        else if (reader["sex"].ToString() == "Female")
                            rBtnFemale.Checked = true;

                        // Civil Status
                        string civilStatus = reader["civil_status"].ToString();
                        if (civilStatus == "Single")
                            rBtnSingle.Checked = true;
                        else if (civilStatus == "Married")
                            rBtnMarried.Checked = true;
                        else
                        {
                            rBtnOther.Checked = true;
                            txtOther.Text = reader["civil_status_other"].ToString();
                        }

                        // Mode of Admission - Fix
                        string modeOfAdmission = reader["mode_of_admission"].ToString().Trim();
                        if (modeOfAdmission.Equals("Walk-In", StringComparison.OrdinalIgnoreCase))
                        {
                            rBtnWalkIn.Checked = true;
                            rBtnReferral.Checked = false;
                            txtRefParty.Text = "";  // Clear referring party if Walk-In
                        }
                        else
                        {
                            rBtnWalkIn.Checked = false;
                            rBtnReferral.Checked = true;
                            txtRefParty.Text = reader["referring_party"].ToString();
                        }

                        // Relationship to Beneficiary
                        if (reader["relationship_to_beneficiary"].ToString() == "Self")
                        {
                            chkSelf.Checked = true;
                        }
                        else
                        {
                            txtRelationship.Text = reader["relationship_to_beneficiary"].ToString();
                        }
                    }
                }
            }
        }




        private void SubscribeToTextChanged(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                // If the control is a TextBox, subscribe to its TextChanged event
                if (childControl is System.Windows.Forms.TextBox textBox)
                {
                    textBox.TextChanged += TextBox_TextChanged;
                }

                // Recursively call this method for child controls (e.g., panels, group boxes)
                if (childControl.HasChildren)
                {
                    SubscribeToTextChanged(childControl);
                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null)
            {
                // Save the cursor position
                int cursorPosition = textBox.SelectionStart;

                // Convert the text to uppercase
                textBox.Text = textBox.Text.ToUpper();

                // Restore the cursor position
                textBox.SelectionStart = cursorPosition;

                // Prevent the cursor from jumping to the end
                textBox.SelectionLength = 0;
            }
        }

        private void PopulateRegions(System.Windows.Forms.ComboBox targetComboBox)
        {
            if (dataLoader == null || dataLoader.Regions == null)
            {
                MessageBox.Show("Region data is not loaded. Please check the data source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var regions = dataLoader.Regions
                .Select(r => new { RegionName = r.RegionName, RegionCode = r.RegionCode })
                .ToList();

            // Add the default placeholder
            regions.Insert(0, new { RegionName = "Select Region", RegionCode = "" });

            targetComboBox.DataSource = regions;
            targetComboBox.DisplayMember = "RegionName";
            targetComboBox.ValueMember = "RegionCode";
            targetComboBox.SelectedIndex = 6; // Set default selected item to the placeholder
        }


        private void Step3Form_Load(object sender, EventArgs e)
        {
            dateTimePickerBirth.ValueChanged += dateTimePickerBirth_ValueChanged;
            dateTimePickerbBirth.ValueChanged += dateTimePickerbBirth_ValueChanged;
            dateTimePickerfBirth.ValueChanged += dateTimePickerfBirth_ValueChanged;

            // Initialize other controls
            UpdateClientStatus();
            UpdateBeneficiaryStatus();
            UpdateFamilyStatus();

            InitializeFamilyCompositionTable();
            dgFamily.Columns["Middle Name"].Width = 140;
            dgFamily.Columns["Occupation"].Width = 150;
            dgFamily.Columns["Estimated Income"].Width = 150;

            //ConfigureDateTimePicker(dateTimePickerBirth);
            //ConfigureDateTimePicker(dateTimePickerbBirth);
            //ConfigureDateTimePicker(dateTimePickerfBirth);

        }



        //------------------------------------------------------------- MOST FUNCTIONS ---------------------------------------------------------------
        private void LoadAllComboBoxes()
        {

            // Load ID type data into cmbIDtype
            LoadComboBoxData(
                new List<System.Windows.Forms.ComboBox> { cmbIdType },
                "SELECT id_type_id, id_name FROM IdTypes", "id_name", "id_type_id", "Select ID type", true
            );

            // Load Highest Educ data into cmbHighestEduc
            LoadComboBoxData(
                new List<System.Windows.Forms.ComboBox> { cmbHighestEduc }, "SELECT educational_id, education_level FROM EducationalAttainment",
                "education_level", "educational_id", "Select Education", true
            );

            // Load Occupation data into both cmbbOccupation and cmbfOccupation
            LoadComboBoxData(
                new List<System.Windows.Forms.ComboBox> { cmbOccupation, cmbfOccupation },
                "SELECT occupation_id, occupation_name FROM Occupation", "occupation_name", "occupation_id", "Select Occupation", true
            );

            // Load Income Range data into both cmbbIncomeRange and cmbfIncomeRange
            LoadComboBoxData(
                new List<System.Windows.Forms.ComboBox> { cmbIncomeRange, cmbfIncomeRange },
                "SELECT income_range_id, income_range FROM IncomeRange", "income_range", "income_range_id", "Select Income Range"
            );

            // Load Religion data into cmbReligion
            LoadComboBoxData(
                new List<System.Windows.Forms.ComboBox> { cmbReligion },
                "SELECT religion_id, religion_name FROM Religions", "religion_name", "religion_id", "Select Religion", true
            );

        }
        //------------------------------------------------------------------------------------
        private void LoadComboBoxData(List<System.Windows.Forms.ComboBox> comboBoxes, string query, string displayMember,
                               string valueMember, string defaultText, bool isEditable = false)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a default row at the top
                    DataRow defaultRow = dt.NewRow();
                    defaultRow[displayMember] = defaultText;
                    defaultRow[valueMember] = DBNull.Value;
                    dt.Rows.InsertAt(defaultRow, 0);

                    // Bind the same data to all specified ComboBoxes
                    foreach (var comboBox in comboBoxes)
                    {
                        comboBox.DataSource = new DataView(dt).ToTable(); // Clone the DataTable for each ComboBox
                        comboBox.DisplayMember = displayMember;
                        comboBox.ValueMember = valueMember;
                        comboBox.SelectedIndex = 0; // Display default item
                        comboBox.DropDownStyle = isEditable ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
            }
        }


        //------------------------------------------------------------------------------------


        //Method to remove DateTimePickers initail text
        private void ConfigureDateTimePicker(DateTimePicker dateTimePicker)
        {
            // dateTimePicker.Format = DateTimePickerFormat.Custom;
            // dateTimePicker.CustomFormat = " ";
            // dateTimePicker.ShowUpDown = false;
        }
        //------------------------------------------------------------------------------------

        //Method to Calculate Age from the datetime picker
        private void CalculateAge(DateTimePicker birthDatePicker, System.Windows.Forms.TextBox ageTextBox)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDatePicker.Value.Year;

            // Adjust if birthdate is after today's date in the year (hasn't had their birthday yet)
            if (birthDatePicker.Value.Date > today.AddYears(-age))
            {
                age--;
            }

            if (age < 0)
            {
                MessageBox.Show("The entered date of birth is not valid. Please select a valid date.", "Invalid Date of Birth", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reset the date picker to today's date
                birthDatePicker.Value = today;
                ageTextBox.Text = ""; // Clear the age text box
                return;
            }

            ageTextBox.Text = age.ToString();
        }


        //Calling CalculateAge() Method to display in Age Textboxes
        private void dateTimePickerBirth_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge(dateTimePickerBirth, txtAge);
        }
        private void dateTimePickerbBirth_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge(dateTimePickerbBirth, txtbAge);
        }
        private void dateTimePickerfBirth_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge(dateTimePickerfBirth, txtfAge);
        }
        //------------------------------------------------------------------------------------


        //Enabling and disabling "Other" radio buttons in CLIENT INFORMATION
        private void UpdateClientStatus()
        {
            txtOther.Enabled = rBtnOther.Checked;
            if (!rBtnOther.Checked) txtOther.Text = "";
        }

        //Calling UpdateClientStatus() (Single, Married, Other)
        private void rBtnSingle_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClientStatus();
        }
        private void rBtnMarried_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClientStatus();
        }
        private void rBtnOther_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClientStatus();
        }



        //Enabling and disabling "Other" radio buttons in BENEFICIARY INFORMATION
        private void UpdateBeneficiaryStatus()
        {
            txtbStatusOther.Enabled = rBtnbOther.Checked;
            if (!rBtnbOther.Checked) txtbStatusOther.Text = "";
        }

        //Calling UpdateBeneficiaryStatus() (Single, Married, Other)
        private void rBtnbSingle_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBeneficiaryStatus();
        }
        private void rBtnbMarried_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBeneficiaryStatus();
        }
        private void rBtnbOther_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBeneficiaryStatus();
        }



        //Enabling and disabling "Other" radio buttons in BENEFICIARY FAMILY COMPOSITION
        private void UpdateFamilyStatus()
        {
            txtfStatusOther.Enabled = rBtnfStatusOther.Checked;
            if (!rBtnfStatusOther.Checked) txtfStatusOther.Text = "";
        }

        //Calling UpdateFamilyStatus() (Single, Married, Other)
        private void rBtnfSingle_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFamilyStatus();
        }
        private void rBtnfMarried_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFamilyStatus();
        }
        private void rBtnfStatusOther_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFamilyStatus();
        }




        //Enabling and disabling "mode of admissions" radio buttons
        private void UpdateModeAdmission()
        {
            txtRefParty.Enabled = rBtnReferral.Checked;
            if (!rBtnReferral.Checked) txtOther.Text = "";
        }

        private void rBtnWalkIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateModeAdmission();
        }
        private void rBtnReferral_CheckedChanged(object sender, EventArgs e)
        {
            UpdateModeAdmission();
        }


        private void chkSelf_CheckedChanged(object sender, EventArgs e)
        {
            txtRelationship.Enabled = !chkSelf.Checked;

            if (chkSelf.Checked)
            {
                // groupBox1.Enabled = false;
              
                txtbFirstName.Enabled = false;
                txtbMidName.Enabled = false;
                txtbLastName.Enabled = false;
                txtbExtJrSr.Enabled = false;
                rBtnbFemale.Enabled = false;
                rBtnbMale.Enabled = false;
                rBtnbSingle.Enabled = false;
                rBtnbMarried.Enabled = false;
                rBtnbOther.Enabled = false;
                txtbStatusOther.Enabled = false;
                txtbBirthPlace.Enabled = false;
                txtbContact.Enabled = false;
                txtbAge.Enabled = false;
                cmbbRegion.Enabled = false;
                cmbbBarangay.Enabled = false;
                cmbbProvince.Enabled = false;
                cmbbCity.Enabled = false;
                txtbDistrict.Enabled = false;
                txtbStPurok.Enabled = false;
                dateTimePickerbBirth.Enabled = false;
            }
            else
            {
                // groupBox1.Enabled = true;
                rBtnYouth.Checked = false;
                rBtnSeniorCitizen.Checked = false;
                chkFhona.Checked = false;
                chkSoloParent.Checked = false;
                chkPwd.Checked = false;
                chk4ps.Checked = false;
                chkbOther.Checked = false;
                txtbOther.Text = "";
                txtbFirstName.Text = "";
                txtbMidName.Text = "";
                txtbLastName.Text = "";
                txtbExtJrSr.Text = "";
                rBtnbFemale.Checked = false;
                rBtnbMale.Checked = false;
                rBtnbSingle.Checked = false;
                rBtnbMarried.Checked = false;
                rBtnbOther.Checked = false;
                txtbStatusOther.Text = "";
                txtbBirthPlace.Text = "";
                txtbContact.Text = "";
                txtbAge.Text = "0";
                cmbbRegion.SelectedIndex = cmbbRegion.Items.Count > 5 ? 6 : -1;
                cmbbBarangay.SelectedIndex = cmbbBarangay.Items.Count > 0 ? 0 : -1;
                cmbbProvince.SelectedIndex = cmbbProvince.Items.Count > 0 ? 0 : -1;
                cmbbCity.SelectedIndex = cmbbCity.Items.Count > 0 ? 0 : -1;
                txtbDistrict.Text = "";
                txtbStPurok.Text = "";

                txtbFirstName.Enabled = true;
                txtbMidName.Enabled = true;
                txtbLastName.Enabled = true;
                txtbExtJrSr.Enabled = true;
                rBtnbFemale.Enabled = true;
                rBtnbMale.Enabled = true;
                rBtnbSingle.Enabled = true;
                rBtnbMarried.Enabled = true;
                rBtnbOther.Enabled = true;
                txtbStatusOther.Enabled = true;
                txtbBirthPlace.Enabled = true;
                txtbContact.Enabled = true;
                txtbAge.Enabled = true;
                cmbbRegion.Enabled = true;
                cmbbBarangay.Enabled = true;
                cmbbProvince.Enabled = true;
                cmbbCity.Enabled = true;
                txtbDistrict.Enabled = true;
                txtbStPurok.Enabled = true;
                dateTimePickerbBirth.Enabled = true;
            }
        }



        //------------------------------------------------------------------------------------

        // Parse currency string to decimal
        private decimal ParseCurrencyToDecimal(string currency)
        {
            // Remove any currency symbols and commas
            string cleanedCurrency = currency.Replace("$", "").Replace(",", "").Trim();

            // Attempt to parse the cleaned string to a decimal
            if (decimal.TryParse(cleanedCurrency, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }

            return 0;
        }
        //------------------------------------------------------------------------------------

        //Formatting Income
        private void FormatIncomeTextBox(System.Windows.Forms.TextBox textBox)
        {
            // Remove any non-digit characters, allowing decimal points
            string rawText = textBox.Text.Replace(",", "").Replace(" ", "");

            // Parse only if it's not empty
            if (!string.IsNullOrEmpty(rawText) && decimal.TryParse(rawText, out decimal income))
            {
                // Format as currency
                textBox.Text = string.Format("{0:N2}", income); // Format with 2 decimal places
                                                                // Move the cursor to the end of the text box
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        /*   //Calling FormatIncomeTextBox() 
           private void txtEstIncome_Leave(object sender, EventArgs e)
           {
               FormatIncomeTextBox(txtEstIncome);
           }
           private void txtfEstIncome_Leave(object sender, EventArgs e)
           {
               FormatIncomeTextBox(txtfEstIncome);
           } */

        //------------------------------------------------------------------------------------

        //Allowing to enter only numbers with period for decimals
        private void txtEstIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control keys, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Prevent the character from being entered
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && ((System.Windows.Forms.TextBox)sender).Text.Contains('.'))
            {
                e.Handled = true; // Prevent additional decimal points
            }
        }

        private void txtfEstIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtEstIncome_KeyPress(sender, e);
        }

        //------------------------------------------------------------------------------------

        //Allowing numbers only to be entered (Contacts, and PhilHealth)
        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (like backspace) and digits only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }
        private void txtPHealth_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtContact_KeyPress(sender, e);
        }
        private void txtbContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtContact_KeyPress(sender, e);
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            FormatContactNumber(txtContact);
        }

        private void txtbContact_TextChanged(object sender, EventArgs e)
        {
            FormatContactNumber(txtbContact);
        }


        private void FormatContactNumber(System.Windows.Forms.TextBox textBox)
        {
            string input = textBox.Text.Replace(" ", ""); // Remove existing spaces

            // Ensure the input starts with "09"
            if (!input.StartsWith("09"))
            {
                input = "09" + input.TrimStart('0', '9');
            }

            // Limit input to 11 digits
            if (input.Length > 11)
            {
                input = input.Substring(0, 11);
            }

            // Format as "0987 876 9876"
            if (input.Length > 4)
            {
                input = input.Insert(4, " ");
            }
            if (input.Length > 8)
            {
                input = input.Insert(8, " ");
            }

            // Update the text and set the cursor position
            textBox.Text = input;
            textBox.SelectionStart = textBox.Text.Length;
        }



        //.....................................Add Button.....................................



        DataTable familyCompositionTable = new DataTable();

        //Displaying Values to the datagrid
        private void InitializeFamilyCompositionTable()
        {
            familyCompositionTable.Columns.Add("No.", typeof(int)); // New column for numbering
            familyCompositionTable.Columns.Add("Last Name");
            familyCompositionTable.Columns.Add("First Name");
            familyCompositionTable.Columns.Add("Middle Name");
            familyCompositionTable.Columns.Add("Birthdate");
            familyCompositionTable.Columns.Add("Age");
            familyCompositionTable.Columns.Add("Sex");
            familyCompositionTable.Columns.Add("Relationship");
            familyCompositionTable.Columns.Add("Occupation");
            familyCompositionTable.Columns.Add("Estimated Income");
            familyCompositionTable.Columns.Add("Civil Status");

            // Bind the DataTable to the DataGridView
            dgFamily.DataSource = familyCompositionTable;
        }

        private void UpdateRowNumbers()
        {
            for (int i = 0; i < familyCompositionTable.Rows.Count; i++)
            {
                familyCompositionTable.Rows[i]["No."] = i + 1; // Assign sequential numbers starting from 1
            }
        }


        private bool ValidateFamilyCompositionForm()
        {
            // List of required fields
            var requiredFields = new List<Control>
            {
                txtfLastName, txtfFirstName, txtfAge, txtfRelationship, dateTimePickerfBirth, rBtnfMale, rBtnfFemale
            };

            // Check for empty fields
            foreach (var field in requiredFields)
            {
                if (field is System.Windows.Forms.TextBox && string.IsNullOrWhiteSpace(((System.Windows.Forms.TextBox)field).Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    field.Focus(); // Focus on the first empty field
                    return false;
                }
                else if (field is DateTimePicker && ((DateTimePicker)field).Value == DateTimePicker.MinimumDateTime)
                {
                    MessageBox.Show("Please select a valid birthdate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    field.Focus(); // Focus on the DateTimePicker if invalid
                    return false;
                }
                else if ((field is RadioButton) && !rBtnfMale.Checked && !rBtnfFemale.Checked)
                {
                    MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true; // All required fields are filled
        }





        //Clearing data inputs in Beneficiary Family Composition
        private void ClearFamilyCompositionInputs()
        {
            txtfLastName.Clear();
            txtfFirstName.Clear();
            txtfMidName.Clear();
            dateTimePickerfBirth.Value = DateTime.Today;
            txtfAge.Clear();
            rBtnfMale.Checked = false;
            rBtnfFemale.Checked = false;
            txtfRelationship.Clear();

            // Reset ComboBox values
            cmbfOccupation.SelectedIndex = -1; // Deselect any selected item
            cmbfIncomeRange.SelectedIndex = -1; // Deselect any selected item

            // Reset Civil Status
            rBtnfSingle.Checked = false;
            rBtnfMarried.Checked = false;
            txtfStatusOther.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgFamily.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this family member?",
                                             "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int selectedIndex = dgFamily.SelectedRows[0].Index;

                    familyCompositionTable.Rows.RemoveAt(selectedIndex);
                    UpdateRowNumbers(); // Update numbering after deletion

                    MessageBox.Show("Family member deleted from the list.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a family member to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        private void btnStep3Save_Click(object sender, EventArgs e)
        {

            // Confirm save action
            var confirmSave = MessageBox.Show("Are you sure you want to save all the entered data?",
                                              "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmSave != DialogResult.Yes)
            {
                return; // Stop execution if user cancels
            }

            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    //conn.Open(); // ✅ Ensure connection is opened only once

                    using (var transaction = conn.BeginTransaction()) // ✅ Begin a transaction
                    {
                        try
                        {
                            // ✅ Save Client Information and retrieve Client ID
                            currentClientId = SaveClientInformation(conn, transaction);

                            // ✅ Save Beneficiary Information (Self or Different)
                            if (chkSelf.Checked)
                            {
                                currentBeneficiaryId = SaveBeneficiaryInformation(conn, transaction, isSelf: true);
                            }
                            else
                            {
                                currentBeneficiaryId = SaveBeneficiaryInformation(conn, transaction, isSelf: false);
                            }

                            // ✅ Save Family Composition
                            SaveFamilyComposition(conn, transaction);

                            // ✅ Commit all changes
                            transaction.Commit();
                            MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // ❌ Rollback if any error occurs
                            MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A critical error occurred: {ex.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int SaveClientInformation(MySqlConnection conn, MySqlTransaction transaction)
        {
            string query = @"
            INSERT INTO ClientInformation (
                last_name, first_name, middle_name, ext_name, id_type_id, id_number, sex, date_of_birth, 
                age, birth_place, region, province, city_municipality, district, barangay, street_purok, 
                relationship_to_beneficiary, civil_status, civil_status_other, religion_id, nationality, 
                highest_educ_attainment, occupation_id, income_range_id, philhealth_no, 
                mode_of_admission, referring_party, contact_number, last_assistance_date
            ) VALUES (
                @lastName, @firstName, @middleName, @extName, @idTypeId, @idNumber, @sex, @dateOfBirth, 
                @age, @birthPlace, @region, @province, @cityMunicipality, @district, @barangay, @streetPurok, 
                @relationshipToBeneficiary, @civilStatus, @civilStatusOther, @religionId, @nationality, 
                @highestEducAttainment, @occupationId, @incomeRangeId, @philhealthNo, 
                @modeOfAdmission, @referringParty, @contactNumber, @lastAssistanceDate
            )";

            using (var cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@middleName", txtMidName.Text);
                cmd.Parameters.AddWithValue("@extName", txtExtJrSr.Text);
                cmd.Parameters.AddWithValue("@idTypeId", cmbIdType.SelectedValue);  // ✅ Foreign Key
                cmd.Parameters.AddWithValue("@idNumber", txtIdNum.Text);
                cmd.Parameters.AddWithValue("@sex", rBtnMale.Checked ? "Male" : "Female");
                cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePickerBirth.Value);
                cmd.Parameters.AddWithValue("@age", txtAge.Text);
                cmd.Parameters.AddWithValue("@birthPlace", txtBirthPlace.Text);
                cmd.Parameters.AddWithValue("@region", cmbRegion.Text);
                cmd.Parameters.AddWithValue("@province", cmbProvince.Text);
                cmd.Parameters.AddWithValue("@cityMunicipality", cmbCity.Text);
                cmd.Parameters.AddWithValue("@district", txtDistrict.Text);
                cmd.Parameters.AddWithValue("@barangay", cmbBarangay.Text);
                cmd.Parameters.AddWithValue("@streetPurok", txtStPurok.Text);
                cmd.Parameters.AddWithValue("@relationshipToBeneficiary", txtRelationship.Text);
                cmd.Parameters.AddWithValue("@civilStatus", rBtnSingle.Checked ? "Single" : rBtnMarried.Checked ? "Married" : "Other");
                cmd.Parameters.AddWithValue("@civilStatusOther", rBtnOther.Checked ? txtOther.Text : DBNull.Value);
                cmd.Parameters.AddWithValue("@religionId", cmbReligion.SelectedValue);  // ✅ Foreign Key
                cmd.Parameters.AddWithValue("@nationality", txtNationality.Text);
                cmd.Parameters.AddWithValue("@highestEducAttainment", cmbHighestEduc.SelectedValue); // ✅ Foreign Key
                cmd.Parameters.AddWithValue("@occupationId", cmbOccupation.SelectedValue);  // ✅ Foreign Key
                cmd.Parameters.AddWithValue("@incomeRangeId", cmbIncomeRange.SelectedValue); // ✅ Foreign Key
                cmd.Parameters.AddWithValue("@philhealthNo", txtPHealth.Text);
                cmd.Parameters.AddWithValue("@modeOfAdmission", rBtnWalkIn.Checked ? "Walk-In" : "Referral");
                cmd.Parameters.AddWithValue("@referringParty", txtRefParty.Text);
                cmd.Parameters.AddWithValue("@contactNumber", txtContact.Text);
                cmd.Parameters.AddWithValue("@lastAssistanceDate", DBNull.Value);

                cmd.ExecuteNonQuery();

                // ✅ Fix: Properly cast LAST_INSERT_ID() to int
                object result = new MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction).ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }





        private int SaveBeneficiaryInformation(MySqlConnection conn, MySqlTransaction transaction, bool isSelf)
        {
            string query = "";
            if (isSelf)
            {
                query = @"
    INSERT INTO BeneficiaryInformation (
        client_id, last_name, first_name, middle_name, ext_name, sex, date_of_birth, age, 
        birth_place, region, province, city_municipality, district, barangay, street_purok, 
        contact_number, civil_status, civil_status_other
    ) VALUES (
        @clientId, @lastName, @firstName, @middleName, @extName, @sex, @dateOfBirth, @age, 
        @birthPlace, @region, @province, @cityMunicipality, @district, @barangay, @streetPurok, 
        @contactNumber, @civilStatus, @civilStatusOther
    )";
            }
            else
            {
                query = @"
    INSERT INTO BeneficiaryInformation (
        client_id
    ) VALUES (
        @clientId
    )";
            }


            using (var cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@clientId", currentClientId);

                if (isSelf)
                {
                    cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@middleName", txtMidName.Text);
                    cmd.Parameters.AddWithValue("@extName", txtExtJrSr.Text);
                    cmd.Parameters.AddWithValue("@sex", rBtnMale.Checked ? "Male" : "Female");
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePickerBirth.Value);
                    cmd.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@birthPlace", txtBirthPlace.Text);
                    cmd.Parameters.AddWithValue("@region", cmbRegion.Text);
                    cmd.Parameters.AddWithValue("@province", cmbProvince.Text);
                    cmd.Parameters.AddWithValue("@cityMunicipality", cmbCity.Text);
                    cmd.Parameters.AddWithValue("@district", txtDistrict.Text);
                    cmd.Parameters.AddWithValue("@barangay", cmbBarangay.Text);
                    cmd.Parameters.AddWithValue("@streetPurok", txtStPurok.Text);
                    cmd.Parameters.AddWithValue("@contactNumber", txtContact.Text);
                    cmd.Parameters.AddWithValue("@civilStatus", rBtnSingle.Checked ? "Single" : rBtnMarried.Checked ? "Married" : "Other");
                    cmd.Parameters.AddWithValue("@civilStatusOther", DBNull.Value);
                }

                cmd.ExecuteNonQuery();

                // return (int)new MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction).ExecuteScalar();

                // ✅ Fix: Properly cast LAST_INSERT_ID() to int
                object result = new MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction).ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }



        private void SaveFamilyComposition(MySqlConnection conn, MySqlTransaction transaction)
        {
            string query = @"
            INSERT INTO BeneficiaryFamilyComposition (
                beneficiary_id, last_name, first_name, middle_name, date_of_birth, age, sex, 
                relationship, occupation_id, income_range_id, civil_status
            ) VALUES (
                @beneficiaryId, @lastName, @firstName, @middleName, @birthDate, @age, @sex, 
                @relationship, @occupationId, @incomeRangeId, @civilStatus
            )";

            using (var cmd = new MySqlCommand(query, conn, transaction))
            {
                foreach (var familyRow in familyMemberList)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@beneficiaryId", currentBeneficiaryId);
                    cmd.Parameters.AddWithValue("@lastName", familyRow["Last Name"]);
                    cmd.Parameters.AddWithValue("@firstName", familyRow["First Name"]);
                    cmd.Parameters.AddWithValue("@middleName", familyRow["Middle Name"]);
                    cmd.Parameters.AddWithValue("@birthDate", Convert.ToDateTime(familyRow["Birthdate"]));
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(familyRow["Age"]));
                    cmd.Parameters.AddWithValue("@sex", familyRow["Sex"]);
                    cmd.Parameters.AddWithValue("@relationship", familyRow["Relationship"]);
                    cmd.Parameters.AddWithValue("@occupationId", familyRow["Occupation"]); // ✅ Foreign Key
                    cmd.Parameters.AddWithValue("@incomeRangeId", familyRow["Estimated Income"]); // ✅ Foreign Key
                    cmd.Parameters.AddWithValue("@civilStatus", familyRow["Civil Status"]);

                    cmd.ExecuteNonQuery();
                }
            }
        }



















        //------------------------------------------------------------------------------------

        //.....................................Back Button.....................................
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(role); // Pass the role back to MainForm
            mainForm.Show();
            this.Close(); // Close the current form
        }







        //Tab 1 Address
        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleRegionChange(cmbRegion, cmbProvince, cmbCity, cmbBarangay);
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleProvinceChange(cmbProvince, cmbCity, cmbBarangay);
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleCityChange(cmbProvince, cmbCity, cmbBarangay, txtDistrict);
        }

        //Tab 2 Address
        private void cmbbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleRegionChange(cmbbRegion, cmbbProvince, cmbbCity, cmbbBarangay);
        }

        private void cmbbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleProvinceChange(cmbbProvince, cmbbCity, cmbbBarangay);
        }

        private void cmbbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleCityChange(cmbbProvince, cmbbCity, cmbbBarangay, txtbDistrict);
        }






        private void HandleRegionChange(System.Windows.Forms.ComboBox cmbRegion, System.Windows.Forms.ComboBox cmbProvince,
                                        System.Windows.Forms.ComboBox cmbCity, System.Windows.Forms.ComboBox cmbBarangay)
        {
            if (cmbRegion.SelectedIndex <= 0)
            {
                cmbProvince.DataSource = null;
                cmbCity.DataSource = null;
                cmbBarangay.DataSource = null;
                return;
            }

            string selectedRegionCode = cmbRegion.SelectedValue.ToString();

            // Filter and load provinces
            var provinces = dataLoader.Provinces
                .Where(p => p.RegionCode == selectedRegionCode)
                .Select(p => new { p.ProvinceName, p.ProvinceCode })
                .ToList();

            provinces.Insert(0, new { ProvinceName = "Select Province", ProvinceCode = "" });

            cmbProvince.DataSource = provinces;
            cmbProvince.DisplayMember = "ProvinceName";
            cmbProvince.ValueMember = "ProvinceCode";
            cmbProvince.SelectedIndex = 0;

            cmbCity.DataSource = null;
            cmbBarangay.DataSource = null;
        }


        private void HandleProvinceChange(System.Windows.Forms.ComboBox cmbProvince, System.Windows.Forms.ComboBox cmbCity,
                                          System.Windows.Forms.ComboBox cmbBarangay)
        {
            if (cmbProvince.SelectedIndex <= 0)
            {
                cmbCity.DataSource = null;
                cmbBarangay.DataSource = null;
                return;
            }

            string selectedProvinceCode = cmbProvince.SelectedValue.ToString();

            // Filter and load cities
            var cities = dataLoader.Cities
                .Where(c => c.ProvinceCode == selectedProvinceCode)
                .Select(c => new { c.CityName, c.CityCode })
                .ToList();

            cities.Insert(0, new { CityName = "Select City", CityCode = "" });

            cmbCity.DataSource = cities;
            cmbCity.DisplayMember = "CityName";
            cmbCity.ValueMember = "CityCode";
            cmbCity.SelectedIndex = 0;

            cmbBarangay.DataSource = null;
        }


        private void HandleCityChange(System.Windows.Forms.ComboBox cmbProvince, System.Windows.Forms.ComboBox cmbCity,
                                      System.Windows.Forms.ComboBox cmbBarangay, System.Windows.Forms.TextBox txtDistrict)
        {
            if (cmbCity.SelectedIndex <= 0)
            {
                cmbBarangay.DataSource = null;
                txtDistrict.Text = "";
                return;
            }

            string selectedCityCode = cmbCity.SelectedValue.ToString();

            // Filter and load barangays
            var barangays = dataLoader.Barangays
                .Where(b => b.CityCode == selectedCityCode)
                .Select(b => new { b.BrgyName, b.BrgyCode })
                .ToList();

            barangays.Insert(0, new { BrgyName = "Select Barangay", BrgyCode = "" });

            cmbBarangay.DataSource = barangays;
            cmbBarangay.DisplayMember = "BrgyName";
            cmbBarangay.ValueMember = "BrgyCode";
            cmbBarangay.SelectedIndex = 0;

            // Sorsogon-specific logic
            if (cmbProvince.SelectedValue != null && cmbProvince.Text == "Sorsogon")
            {
                string selectedCity = cmbCity.Text;
                txtDistrict.Text = GetDistrictForSorsogon(selectedCity);
            }
            else
            {
                txtDistrict.Text = "";
            }
        }


        // Helper method to determine the district for Sorsogon cities
        private string GetDistrictForSorsogon(string cityName)
        {
            // First District cities
            var firstDistrictCities = new List<string>
            {
                "City Of Sorsogon (Capital)", "Casiguran", "Castilla", "Donsol", "Magallanes", "Pilar"
            };

            // Second District cities
            var secondDistrictCities = new List<string>
            {
                "Barcelona", "Bulan", "Bulusan", "Gubat", "Irosin", "Juban", "Matnog", "Prieto Diaz", "Santa Magdalena"
            };

            if (firstDistrictCities.Contains(cityName))
            {
                return "1st";
            }
            else if (secondDistrictCities.Contains(cityName))
            {
                return "2nd";
            }

            return ""; // Return empty if the city is not recognized
        }



        private bool ValidateRequiredFields(List<Control> controls)
        {
            foreach (var control in controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    // Skip validation for txtRelationship if chkSelf is checked
                    if (textBox == txtRelationship && chkSelf.Checked)
                        continue;

                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.Focus(); // Focus on the invalid field
                        return false; // Validation failed
                    }

                    // Special validation for contact numbers
                    if (textBox == txtContact || textBox == txtbContact)
                    {
                        if (textBox.Text.Replace(" ", "").Length != 11)
                        {
                            MessageBox.Show("Contact number must be 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox.Focus();
                            return false; // Validation failed
                        }
                    }
                }
                else if (control is System.Windows.Forms.ComboBox comboBox && (comboBox.SelectedIndex <= 0 || comboBox.SelectedItem == null))
                {
                    comboBox.Focus(); // Focus on the invalid field
                    return false; // Validation failed
                }
                else if (control is System.Windows.Forms.RadioButton radioButton)
                {
                    // Ensure at least one radio button in the "sex" group is checked
                    if ((radioButton == rBtnMale || radioButton == rBtnFemale || radioButton == rBtnbMale || radioButton == rBtnbFemale) &&
                        !((rBtnMale.Checked || rBtnFemale.Checked) || (rBtnbMale.Checked || rBtnbFemale.Checked)))
                    {
                        MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // radioButton.Focus(); // Focus on the radio button group
                        return false; // Validation failed
                    }
                }
            }

            return true; // All fields are valid
        }


        private void ShowValidationErrorMessage()
        {
            MessageBox.Show("Please fill in all required fields before proceeding.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void CopyClientDataToBeneficiary()
        {
            txtbLastName.Text = txtLastName.Text;
            txtbFirstName.Text = txtFirstName.Text;
            txtbMidName.Text = txtMidName.Text;
            txtbExtJrSr.Text = txtExtJrSr.Text;
            if (rBtnSingle.Checked) rBtnbSingle.Checked = true;
            if (rBtnMarried.Checked) rBtnbMarried.Checked = true;
            if (rBtnOther.Checked && txtOther.Enabled)
            {
                rBtnbOther.Checked = true;
                txtbStatusOther.Text = txtOther.Text;
            }

            if (rBtnMale.Checked) rBtnbMale.Checked = true;
            if (rBtnFemale.Checked) rBtnbFemale.Checked = true;
            dateTimePickerbBirth.Value = dateTimePickerBirth.Value;
            txtbAge.Text = txtAge.Text;
            txtbContact.Text = txtContact.Text;
            txtbBirthPlace.Text = txtBirthPlace.Text;

            cmbbRegion.SelectedValue = cmbRegion.SelectedValue;
            cmbbProvince.SelectedValue = cmbProvince.SelectedValue;
            cmbbCity.SelectedValue = cmbCity.SelectedValue;
            txtbDistrict.Text = txtDistrict.Text;
            cmbbBarangay.SelectedValue = cmbBarangay.SelectedValue;
            txtbStPurok.Text = txtStPurok.Text;
        }



        private void btnNextToBen_Click(object sender, EventArgs e)
        {
            var requiredFieldsTab1 = new List<Control>
            {
                txtLastName, txtFirstName,
                rBtnMale, rBtnFemale,
                dateTimePickerBirth, txtAge,
                cmbIncomeRange,
                txtBirthPlace, cmbRegion, cmbProvince, cmbCity,
                txtDistrict, cmbBarangay, txtStPurok
            };

            // Add txtRelationship only if chkSelf is not checked
            if (!chkSelf.Checked)
            {
                requiredFieldsTab1.Add(txtRelationship);
            }

            if (!ValidateRequiredFields(requiredFieldsTab1))
            {
                ShowValidationErrorMessage();
                return; // Prevent navigating to the next tab
            }

            if (chkSelf.Checked)
            {
                CopyClientDataToBeneficiary();
            }

            // Allow tab change and navigate to Tab2
            allowTabChange = true;
            tabControl.SelectedTab = tab2Beneficiary;
            allowTabChange = false;
        }

        private void btnNextToFam_Click(object sender, EventArgs e)
        {
            var requiredFieldsTab2 = new List<Control>
            {
                txtbLastName, txtbFirstName,
                rBtnbMale, rBtnbFemale,
                dateTimePickerbBirth, txtbAge,
                 txtbBirthPlace,
                cmbbRegion, cmbbProvince, cmbbCity,
                txtbDistrict, cmbbBarangay, txtbStPurok
            };

            if (!ValidateRequiredFields(requiredFieldsTab2))
            {
                ShowValidationErrorMessage();
                return; // Prevent navigating to the next tab
            }

            // Allow tab change and navigate to Family tab
            allowTabChange = true;
            tabControl.SelectedTab = tab3BenFam;
            allowTabChange = false;
        }


        private void btnBackToClient_Click(object sender, EventArgs e)
        {
            allowTabChange = true;
            tabControl.SelectedTab = tab1Client;
            allowTabChange = false;
        }

        private void btnBackToBene_Click(object sender, EventArgs e)
        {
            allowTabChange = true;
            tabControl.SelectedTab = tab2Beneficiary;
            allowTabChange = false;
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!allowTabChange)
            {
                e.Cancel = true; // Prevent tab selection
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFamilyCompositionForm())
            {
                return; // Stop execution if validation fails
            }

            // Confirmation dialog
            var result = MessageBox.Show("Are you sure you want to add this family member?", "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Create a new row for the DataTable
                    DataRow newRow = familyCompositionTable.NewRow();
                    newRow["Last Name"] = txtfLastName.Text;
                    newRow["First Name"] = txtfFirstName.Text;
                    newRow["Middle Name"] = txtfMidName.Text;
                    newRow["Birthdate"] = dateTimePickerfBirth.Value.ToString("yyyy-MM-dd");
                    newRow["Age"] = txtfAge.Text;
                    newRow["Sex"] = rBtnfMale.Checked ? "Male" : "Female";
                    newRow["Relationship"] = txtfRelationship.Text;

                    // Set the Occupation and Income Range only if they have valid values, otherwise leave them empty
                    newRow["Occupation"] = string.IsNullOrWhiteSpace(cmbfOccupation.Text) || cmbfOccupation.SelectedIndex == 0 ? string.Empty : cmbfOccupation.Text;
                    newRow["Estimated Income"] = string.IsNullOrWhiteSpace(cmbfIncomeRange.Text) || cmbfIncomeRange.SelectedIndex == 0 ? string.Empty : cmbfIncomeRange.Text;

                    newRow["Civil Status"] = rBtnfSingle.Checked ? "Single" : rBtnfMarried.Checked ? "Married" : txtfStatusOther.Text;

                    // Add the row to the DataTable
                    familyCompositionTable.Rows.Add(newRow);

                    UpdateRowNumbers(); // Update numbering after adding

                    ClearFamilyCompositionInputs(); // Clear input fields after adding
                    MessageBox.Show("Family member added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding family composition: {ex.Message}");
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkFhona_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFhona.Checked)
            {
                chkSoloParent.Checked = false;
                chkPwd.Checked = false;
                chk4ps.Checked = false;
                chkbOther.Checked = false;
                txtbOther.Enabled = false;
                txtbOther.Text = "";
            }
        }

        private void chkSoloParent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoloParent.Checked)
            {
                chkFhona.Checked = false;
                chkPwd.Checked = false;
                chk4ps.Checked = false;
                chkbOther.Checked = false;
                txtbOther.Enabled = false;
                txtbOther.Text = "";
            }
        }

        private void chkPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPwd.Checked)
            {
                chkFhona.Checked = false;
                chkSoloParent.Checked = false;
                chk4ps.Checked = false;
                chkbOther.Checked = false;
                txtbOther.Enabled = false;
                txtbOther.Text = "";
            }
        }

        private void chk4ps_CheckedChanged(object sender, EventArgs e)
        {
            if (chk4ps.Checked)
            {
                chkFhona.Checked = false;
                chkSoloParent.Checked = false;
                chkPwd.Checked = false;
                chkbOther.Checked = false;
                txtbOther.Enabled = false;
                txtbOther.Text = "";
            }
        }

        private void chkbOther_CheckedChanged(object sender, EventArgs e)
        {
            txtbOther.Enabled = chkbOther.Checked;
            if (chkbOther.Checked)
            {
                chkFhona.Checked = false;
                chkSoloParent.Checked = false;
                chkPwd.Checked = false;
                chk4ps.Checked = false;

            }
        }

        private void txtbAge_TextChanged(object sender, EventArgs e)
        {
            if (!txtbAge.Text.Equals(""))
            {
                var age = Int32.Parse(txtbAge.Text);

                if (age >= 0 && age <= 24)
                {
                    rBtnSeniorCitizen.Enabled = false;
                    rBtnSeniorCitizen.Checked = false;
                    rBtnYouth.Enabled = true;
                }
                else if (age >= 60)
                {
                    rBtnSeniorCitizen.Enabled = true;
                    rBtnYouth.Enabled = false;
                    rBtnYouth.Checked = false;
                }
                else
                {
                    rBtnYouth.Enabled = true;
                    rBtnSeniorCitizen.Enabled = true;
                }
            }
            else
            {
                rBtnYouth.Enabled = true;
                rBtnSeniorCitizen.Enabled = true;
            }
        }
        private void rBtnMale_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(rBtnMale.Checked.ToString());
        }

        private void rBtnMale_MouseClick(object sender, MouseEventArgs e)
        {
         //   MessageBox.Show(rBtnMale.Checked.ToString());
        }

        private void rBtnMale_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.rBtnMale.Checked)
            {
                this.rBtnMale.Checked = false;
            }
            else
            {
                base.OnMouseDown(e);
            }
        }

        private void rBtnMale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
