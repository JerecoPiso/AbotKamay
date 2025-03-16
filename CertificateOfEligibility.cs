using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Abot_Kamay_Tracking_and_Queuing_System
{


    public partial class CertificateOfEligibility : Form
    {
        private Step4Form home;
        public CertificateOfEligibility(Step4Form home)
        {
            InitializeComponent();
            this.home = home;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {
            Console.WriteLine("skjhs");
        }

        private void CertificateOfEligibility_Load(object sender, EventArgs e)
        {
            string client = @"SELECT ci.*, 
                bi.last_name as blname,
                bi.first_name as bfname,
                bi.middle_name as bmname,
                bi.ext_name as bename,
                bi.sex as bsex,
                bi.date_of_birth as bdob,
                bi.age as bage,
                bi.birth_place as bbirth_place,
                bi.contact_number as bcontact,
                bi.beneficiary_type,
                bi.other_beneficiary_type,

                bi.region as bregion,
                bi.province as bprovince,
                bi.region as bregion,
                bi.city_municipality as bmun,
                bi.district as bdistrict,
                bi.barangay as bbarangay,
                bi.street_purok as bstreet,
                bi.civil_status as bcivil,
                bi.civil_status_other as bcivilother,
                ai.amount,
                ai.financial_assistance,
                ai.material_assistance,
                ai.medical,
                ai.burial,
                ai.transpo,
                ai.food_pack,
                ai.used_clothing,
                ai.specify,
                ai.material_specify 
                FROM clientinformation AS ci RIGHT JOIN beneficiaryinformation AS bi ON ci.client_id = bi.client_id 
                LEFT JOIN assistanceinformation as ai  ON ci.client_id = ai.client_id

                WHERE ci.client_id = @client_id ORDER BY bi.beneficiary_id DESC LIMIT 1";
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(client, conn))
                {
                    cmd.Parameters.AddWithValue("@client_id", 1);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            SetBeneficiaryType(rd["beneficiary_type"].ToString(), rd["other_beneficiary_type"].ToString());
                            fullname.Text = rd["last_name"].ToString() + " " + rd["first_name"].ToString();
                            clientName.Text = rd["last_name"].ToString() + " " + rd["first_name"].ToString();
                            payableTo.Text = rd["last_name"].ToString() + " " + rd["first_name"].ToString();

                            if (rd["bsex"].ToString().Equals("Male"))
                            {
                                chkMale.Checked = true;
                            }
                            else
                            {
                                chkFemale.Checked = true;
                            }
                            currentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            age.Text = rd["bage"].ToString();
                            //amount2.Text = rd["amount"].ToString();

                            amountFig1.Text = rd["amount"].ToString();
                            amountFig2.Text = rd["amount"].ToString();
                            assistance1.Text = rd["relationship_to_beneficiary"].ToString() + " " + rd["blname"].ToString() + " " + rd["bfname"].ToString();


                            //  assistance1.Text = (rd.GetInt32("financial_assistance") == 1 ? "Financial " : "Material ") + FinancialAssistanceidentifier(rd.GetInt32("financial_assistance"), rd.GetInt32("medical"), rd.GetInt32("burial"), rd.GetInt32("transpo"), rd.GetInt32("food_pack"), rd.GetInt32("used_clothing"));
                            assistance2.Text = (rd.GetInt32("financial_assistance") == 1 ? "Financial " : "Material ") + FinancialAssistanceidentifier(rd.GetInt32("financial_assistance"), rd.GetInt32("medical"), rd.GetInt32("burial"), rd.GetInt32("transpo"), rd.GetInt32("food_pack"), rd.GetInt32("used_clothing"));
                            assistance3.Text = (rd.GetInt32("financial_assistance") == 1 ? "Financial " : "Material ") + FinancialAssistanceidentifier(rd.GetInt32("financial_assistance"), rd.GetInt32("medical"), rd.GetInt32("burial"), rd.GetInt32("transpo"), rd.GetInt32("food_pack"), rd.GetInt32("used_clothing"));
                            specifyAssistance.Text = (rd["specify"].ToString() + " " + rd["material_specify"].ToString());

                            address.Text = rd["street_purok"].ToString() + " " + rd["barangay"].ToString() + " " + rd["district"].ToString() + " " + rd["city_municipality"].ToString() + " " + rd["province"].ToString() + " " + rd["region"].ToString();
                            address2.Text = rd["street_purok"].ToString() + " " + rd["barangay"].ToString() + " " + rd["district"].ToString() + " " + rd["city_municipality"].ToString() + " " + rd["province"].ToString() + " " + rd["region"].ToString();

                        }
                    }
                }
            }

        }
        private void SetBeneficiaryType(string type, string others)
        {
            switch (type)
            {
                case "FHONA":
                    fhona.Checked = true;
                    break;
                case "Solo Parent":
                    solo.Checked = true;

                    break;
                case "PWD":
                    pwd.Checked = true;

                    break;
                case "4Ps":
                    ps.Checked = true;

                    break;
                case "Others":
                    chkOthers.Checked = true;
                    othersSpecify.Text = others;
                    break;
            }
        }
        private string FinancialAssistanceidentifier(int financialAssistance, int medical, int burial, int transpo, int food_pack, int used_clothing)
        {

            if (financialAssistance == 1)
            {
                if (medical == 1)
                {
                    return "(Medical)";
                }
                else if (burial == 1)
                {
                    return "(Burial)";
                }
                else if (transpo == 1)
                {
                    return "(Transpo)";

                }
            }
            else
            {
                if (food_pack == 1)
                {
                    return "(Food pack)";
                }
                else if (used_clothing == 1)
                {
                    return "(Used clothing)";
                }

            }

            return "";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            btnPrint.Visible = false;
            Bitmap panelBitmap = new Bitmap(form.Width, form.Height);

            form.DrawToBitmap(panelBitmap, new Rectangle(0, 0, form.Width, form.Height));

            PrintDocument printDoc = new PrintDocument();

            printDoc.PrintPage += (sender1, e1) =>
            {
                int x = (e1.PageBounds.Width - panelBitmap.Width) / 2;
                int y = (e1.PageBounds.Height - panelBitmap.Height) / 2;
                e1.Graphics.DrawImage(panelBitmap, 0, 0);
            };
            printDoc.Print();
            btnPrint.Visible = true;
            this.home._CoePrint = true;
            if (this.home._GisPrint && this.home._CoePrint && this.home._RerPrint)
            {
                this.home.btnStep4Save.Enabled = true;
                this.home.panelPrintForm.Visible = false;
                MessageBox.Show("You can now save the information!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void assistance3_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void currentDate_Click(object sender, EventArgs e)
        {

        }

        private void CertificateOfEligibility_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnPrint.PerformClick();
            }
        }

        private void btnPrint_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
