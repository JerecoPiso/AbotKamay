using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class PrintGeneralntakeSheet : Form
    {
        private Step4Form home;

        public PrintGeneralntakeSheet(Step4Form home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void PrintGeneralntakeSheet_Load(object sender, EventArgs e)
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

                bi.region as bregion,
                bi.province as bprovince,
                bi.region as bregion,
                bi.city_municipality as bmun,
                bi.district as bdistrict,
                bi.barangay as bbarangay,
                bi.street_purok as bstreet,
                bi.civil_status as bcivil,
                bi.civil_status_other as bcivilother,
                ai.problem_presented,
                ai.social_worker_assessment,
                ai.client_category,
                ai.client_sub_category 
                FROM clientinformation AS ci RIGHT JOIN beneficiaryinformation AS bi ON ci.client_id = bi.client_id 
                LEFT JOIN assessmentinformation AS ai ON bi.beneficiary_id = ai.beneficiary_id

                WHERE ci.client_id = @client_id ORDER BY bi.client_id, ai.assessment_id DESC LIMIT 1";
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(client, conn))
                {
                    cmd.Parameters.AddWithValue("@client_id", this.home.clientId);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {

                            lname.Text = rd["last_name"].ToString();
                            fname.Text = rd["first_name"].ToString();
                            mname.Text = rd["middle_name"].ToString();
                            ext.Text = rd["ext_name"].ToString();
                            if (rd["sex"].ToString().Equals("Male"))
                            {
                                gmale.Checked = true;
                            }
                            else
                            {
                                gfemale.Checked = true;
                            }
                              
                            philhealthno.Text = rd["id_number"].ToString();
                            placeofbirth.Text = rd["birth_place"].ToString(); lname.Text = rd["last_name"].ToString();
                            relationshiptobeneficiary.Text = rd["relationship_to_beneficiary"].ToString();
                            nationality.Text = rd["nationality"].ToString();
                            contactno.Text = rd["contact_number"].ToString();
                            occupation.Text = rd["skills_occupation"].ToString();
                            referringparty.Text = rd["referring_party"].ToString();
                            dateofbirth.Text = rd["date_of_birth"].ToString();
                            age.Text = rd["age"].ToString();
                            presentaddress.Text = rd["street_purok"].ToString() + " " + rd["barangay"].ToString() + " " + rd["district"].ToString() + " " + rd["city_municipality"].ToString() + " " + rd["province"].ToString() + " " + rd["region"].ToString();
                            philhealthno.Text = rd["philhealth_no"].ToString();
                            referringparty.Text = rd["referring_party"].ToString();
                            contactno.Text = rd["contact_number"].ToString();
                            //highesteduc.Text = rd["contact_number"].ToString();
                            blname.Text = rd["blname"].ToString();
                            bfname.Text = rd["bfname"].ToString();
                            bmname.Text = rd["bmname"].ToString();
                            bext.Text = rd["bename"].ToString();
                            bage.Text = rd["bage"].ToString();
                            bpob.Text = rd["bbirth_place"].ToString();
                            bcontact.Text = rd["bcontact"].ToString();

                            problem_presented.Text = rd["problem_presented"].ToString();
                            social_worker_assessment.Text = rd["social_worker_assessment"].ToString();
                            client_sub.Text = rd["client_sub_category"].ToString();

                            checkClientCategory(Int32.Parse(rd["client_category"].ToString()));
                            //MessageBox.Show(rd["last_name"].ToString());
                        }
                    }
                }
            }

        }
        private void checkClientCategory(int category)
        {
            switch (category)
            {
                case 1:
                    chb_client1.Checked = true;
                    break;
                case 2:
                    chb_client2.Checked = true;

                    break;
                case 3:
                    chb_client3.Checked = true;

                    break;
                case 4:
                    chb_client4.Checked = true;

                    break;
                case 5:
                    chb_client5.Checked = true;

                    break;
                case 6:
                    chb_client6.Checked = true;

                    break;
            }
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
            this.home._GisPrint = true;
            if (this.home._GisPrint && this.home._CoePrint && this.home._RerPrint)
            {
                this.home.btnStep4Save.Enabled = true;
                this.home.panelPrintForm.Visible = false;
                MessageBox.Show("You can now save the information!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void form_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrintGeneralntakeSheet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnPrint.PerformClick();
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void highesteduc_TextChanged(object sender, EventArgs e)
        {

        }

        private void gfemale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
