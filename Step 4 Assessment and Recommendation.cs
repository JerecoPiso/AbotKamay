using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class Step4Form : Form
    {
        public int SelectedId { get; set; } // Public property to set the selected ID
        public bool IsClient { get; set; } // Public property to differentiate between client and beneficiary

        private string role;
        public int? clientId;
        private string fullName;

        public bool _GisPrint;
        public bool _CoePrint;
        public bool _RerPrint;

        public Step4Form(string userRole, int? clientId = null, string fullName = null)
        {
            InitializeComponent();

            role = userRole;
            this.clientId = clientId;
            this.fullName = fullName;
            this.txtPayeeName.Text = fullName;
            lblGetName.Text = fullName;  // Display full name in the label


            // Event handlers for enabling/disabling controls
            rBtnFinancialAssistance.CheckedChanged += chkFinancialAssistance_CheckedChanged;
            rBtnMaterialAssistance.CheckedChanged += chkMaterialAssistance_CheckedChanged;

            rBtnReferralSpecify.CheckedChanged += rBtnReferralSpecify_CheckedChanged;
            rBtnOther.CheckedChanged += rBtnOther_CheckedChanged;

            // Initially, only financial and material assistance checkboxes are enabled
            SetAssistanceControlsEnabled(false);


            this.txtAmount.Leave += new EventHandler(this.txtAmount_Leave);
            this.txtValuePesos.Leave += new EventHandler(this.txtValuePesos_Leave);


            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtValuePesos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValuePesos_KeyPress);

        }

        private void Step4Form_Load(object sender, EventArgs e)
        {
            button5.PerformClick();
            timeDateTimer.Start();
        }



        private void btnSaveOne_Click(object sender, EventArgs e)
        {
            if (ValidateAssessment())
            {
                //string selectedCategory = GetSelectedCategory(); // Method to get the checked category
                string sqlQuery = "INSERT INTO AssessmentInformation (client_id, beneficiary_id, problem_presented, social_worker_assessment, client_category, client_sub_category) " +
                                  "VALUES (@client_id, @beneficiary_id, @problem, @assessment, @category, @subCategory)";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                {
                    // Set the correct ID based on whether it is client or beneficiary
                    //cmd.Parameters.AddWithValue("@client_id", IsClient ? SelectedId : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@client_id", clientId);

                    cmd.Parameters.AddWithValue("@beneficiary_id", !IsClient ? SelectedId : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@problem", txtProblem.Text);
                    cmd.Parameters.AddWithValue("@assessment", txtAssessment.Text);
                    //  cmd.Parameters.AddWithValue("@category", selectedCategory);
                    cmd.Parameters.AddWithValue("@subCategory", txtClientSub.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Assessment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveTwo_Click(object sender, EventArgs e)
        {
            int bid = 1;
            string q = @"SELECT beneficiary_id FROM beneficiaryinformation where client_id = @client_id ORDER BY beneficiary_id DESC LIMIT 1";
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            using (MySqlCommand cd = new MySqlCommand(q, conn))
            {
                cd.Parameters.AddWithValue("@client_id", clientId);
                using (MySqlDataReader rd = cd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        bid = rd.GetInt32("beneficiary_id");
                    }
                }
            }

            if (ValidateAssessment())
            {
                //string selectedCategory = GetSelectedCategory(); // Method to get the checked category
                string qry = "INSERT INTO AssessmentInformation (client_id, beneficiary_id, problem_presented, social_worker_assessment, client_category, client_sub_category) " +
                                  "VALUES (@client_id, @beneficiary_id, @problem, @assessment, @category, @subCategory)";

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                using (MySqlCommand cmd = new MySqlCommand(qry, connection))
                {
                    // Set the correct ID based on whether it is client or beneficiary
                    cmd.Parameters.AddWithValue("@client_id", clientId);
                    cmd.Parameters.AddWithValue("@beneficiary_id", bid);
                    cmd.Parameters.AddWithValue("@problem", txtProblem.Text);
                    cmd.Parameters.AddWithValue("@assessment", txtAssessment.Text);
                    cmd.Parameters.AddWithValue("@category", cmbClientCateg.SelectedIndex);
                    cmd.Parameters.AddWithValue("@subCategory", txtClientSub.Text);

                    cmd.ExecuteNonQuery();
                }
                if (ValidateAssistance())
                {
                    string sqlQuery = "INSERT INTO assistanceinformation (client_id, beneficiary_id, counselling, legal_assistance, referral_specify, other, amount, mode_of_assistance, financial_assistance, medical, burial, transpo, specify, value_pesos, fund_source, material_assistance, food_pack, used_clothing, material_specify, material_value_pesos, payee_name, payee_address) " +
                                      "VALUES (@client_id, @beneficiary_id, @counselling, @legal_assistance, @referral_specify, @other, @amount, @mode_of_assistance, @financial_assistance, @medical, @burial, @transpo, @specify, @value_pesos, @fund_source, @material_assistance, @food_pack, @used_clothing, @material_specify, @material_value_pesos, @payee_name, @payee_address)";

                    using (MySqlConnection connection = DatabaseConnection.GetConnection())
                    using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                    {
                        //cmd.Parameters.AddWithValue("@client_id", IsClient ? SelectedId : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@client_id", clientId);

                        cmd.Parameters.AddWithValue("@beneficiary_id", bid);
                        cmd.Parameters.AddWithValue("@counselling", rBtnCounselling.Checked);
                        cmd.Parameters.AddWithValue("@legal_assistance", rBtnLegalAssistance.Checked);
                        cmd.Parameters.AddWithValue("@referral_specify", rBtnReferralSpecify.Checked ? txtReferralSpecify.Text : DBNull.Value);
                        cmd.Parameters.AddWithValue("@other", rBtnOther.Checked ? txtOther.Text : DBNull.Value);

                        // Parse and save the currency values correctly
                        cmd.Parameters.AddWithValue("@amount", ParseCurrencyToDecimal(txtAmount.Text));
                        cmd.Parameters.AddWithValue("@mode_of_assistance", rBtnCash.Checked ? "Cash" : rBtnGL.Checked ? "GL" : DBNull.Value);
                        cmd.Parameters.AddWithValue("@financial_assistance", rBtnFinancialAssistance.Checked);
                        cmd.Parameters.AddWithValue("@medical", chkMedical.Checked);
                        cmd.Parameters.AddWithValue("@burial", chkBurial.Checked);
                        cmd.Parameters.AddWithValue("@transpo", chkTranspo.Checked);
                        cmd.Parameters.AddWithValue("@specify", txtSpecify.Text);
                        cmd.Parameters.AddWithValue("@value_pesos", ParseCurrencyToDecimal(txtValuePesos.Text));
                        cmd.Parameters.AddWithValue("@fund_source", txtFundSource.Text);
                        cmd.Parameters.AddWithValue("@material_assistance", rBtnMaterialAssistance.Checked);
                        cmd.Parameters.AddWithValue("@food_pack", chkFoodPack.Checked);
                        cmd.Parameters.AddWithValue("@used_clothing", chkUsedClothing.Checked);
                        cmd.Parameters.AddWithValue("@material_specify", txtbSpecify.Text);
                        cmd.Parameters.AddWithValue("@material_value_pesos", ParseCurrencyToDecimal(txtbValuePesos.Text));
                        cmd.Parameters.AddWithValue("@payee_name", txtPayeeName.Text);
                        cmd.Parameters.AddWithValue("@payee_address", txtPayeeAddress.Text);

                        //connection.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Assistance information and Assessment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm main = (MainForm)Application.OpenForms["MainForm"];
                    main.btnHome.PerformClick();
                }
                //MessageBox.Show("Assessment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        // Parse currency string to decimal
        private decimal ParseCurrencyToDecimal(string currency)
        {
            // Remove commas and parse to decimal
            if (decimal.TryParse(currency.Replace(",", "").Trim(), out decimal result))
            {
                return result;
            }
            return 0; // Return 0 or handle the case where parsing fails
        }

        private bool ValidateAssessment()
        {
            if (string.IsNullOrWhiteSpace(txtProblem.Text))
            {
                ShowValidationError("Please enter the problem(s) presented.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAssessment.Text))
            {
                ShowValidationError("Please enter the social worker's assessment.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtClientSub.Text))
            {
                ShowValidationError("Please enter the client sub-category.");
                return false;
            }
            if (string.IsNullOrEmpty(cmbClientCateg.Text))
            {
                ShowValidationError("Please select a client category.");
                return false;
            }

            return true;
        }

        private bool ValidateAssistance()
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                ShowValidationError("Please enter the amount of financial assistance.");
                return false;
            }

            if (rBtnReferralSpecify.Checked && string.IsNullOrWhiteSpace(txtReferralSpecify.Text))
            {
                ShowValidationError("Please specify the referral details.");
                return false;
            }

            if (rBtnOther.Checked && string.IsNullOrWhiteSpace(txtOther.Text))
            {
                ShowValidationError("Please specify the other details.");
                return false;
            }

            return true;
        }


        private void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkFinancialAssistance_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnFinancialAssistance.Checked)
            {
                // Enable financial assistance related fields
                SetFinancialAssistanceControlsEnabled(true);

                // Disable material assistance related fields when financial assistance is selected
                SetMaterialAssistanceControlsEnabled(false);
            }
            else
            {
                // Reset financial assistance fields when unchecked
                SetFinancialAssistanceControlsEnabled(false);
            }
        }

        private void chkMaterialAssistance_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnMaterialAssistance.Checked)
            {
                // Enable material assistance related fields
                SetMaterialAssistanceControlsEnabled(true);

                // Disable financial assistance related fields when material assistance is selected
                SetFinancialAssistanceControlsEnabled(false);
            }
            else
            {
                // Reset material assistance fields when unchecked
                SetMaterialAssistanceControlsEnabled(false);
            }
        }

        private void SetFinancialAssistanceControlsEnabled(bool enabled)
        {
            chkMedical.Enabled = enabled;
            chkBurial.Enabled = enabled;
            chkTranspo.Enabled = enabled;
            txtSpecify.Enabled = enabled;
            txtValuePesos.Enabled = enabled;
            txtFundSource.Enabled = enabled;

        }

        private void SetMaterialAssistanceControlsEnabled(bool enabled)
        {
            chkFoodPack.Enabled = enabled;
            chkUsedClothing.Enabled = enabled;
            txtbSpecify.Enabled = enabled;
            txtbValuePesos.Enabled = enabled;

        }

        private void SetAssistanceControlsEnabled(bool enabled)
        {
            SetFinancialAssistanceControlsEnabled(enabled);
            SetMaterialAssistanceControlsEnabled(enabled);
        }

        private void rBtnReferralSpecify_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("sd");
            //  txtReferralSpecify.Enabled = rBtnReferralSpecify.Checked;
        }

        private void rBtnOther_CheckedChanged(object sender, EventArgs e)
        {
            txtOther.Enabled = rBtnOther.Checked;
        }

        private void FormatCurrencyTextBox(TextBox textBox)
        {
            // Remove any non-digit characters, allowing decimal points
            string rawText = textBox.Text.Replace(",", "").Replace(" ", "");

            // Parse only if it's not empty
            if (!string.IsNullOrEmpty(rawText) && decimal.TryParse(rawText, out decimal amount))
            {
                // Format as currency
                textBox.Text = string.Format("{0:N2}", amount); // Format with 2 decimal places
                                                                // Move the cursor to the end of the text box
                textBox.SelectionStart = textBox.Text.Length;
            }
        }



        private void txtAmount_Leave(object sender, EventArgs e)
        {
            FormatCurrencyTextBox(txtAmount);
        }

        private void txtValuePesos_Leave(object sender, EventArgs e)
        {
            FormatCurrencyTextBox(txtValuePesos);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, control keys, and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Prevent the character from being entered
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
            {
                e.Handled = true; // Prevent additional decimal points
            }
        }
        private void txtValuePesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAmount_KeyPress(sender, e);
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage1;
        }

        private void btnNextToReco_Click(object sender, EventArgs e)
        {

            tabControl.SelectedTab = tabPage2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //PrintGeneralntakeSheet printForm = new PrintGeneralntakeSheet(this);
            // CertificateOfEligibility printForm = new CertificateOfEligibility(this);
            // ReimbursementExpenseReceipt printForm = new ReimbursementExpenseReceipt(this);

            // printForm.Show();
            if(ValidateAssessment() && ValidateAssistance())
            {
                panelPrintForm.Visible = true;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rBtnGL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rBtnCash_CheckedChanged(object sender, EventArgs e)
        {
            return;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void gis_CheckedChanged(object sender, EventArgs e)
        {

            if (gis.Checked)
            {
                PrintGeneralntakeSheet pis = new PrintGeneralntakeSheet(this);
                pis.Show();
            }

        }

        private void coe_CheckedChanged(object sender, EventArgs e)
        {
            if (coe.Checked)
            {
                CertificateOfEligibility coe = new CertificateOfEligibility(this);
                coe.Show();
            }

        }

        private void rer_CheckedChanged(object sender, EventArgs e)
        {
            if (rer.Checked)
            {
                ReimbursementExpenseReceipt rer = new ReimbursementExpenseReceipt(this);
                rer.Show();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            panelPrintForm.Visible = false;
        }
    }
}
