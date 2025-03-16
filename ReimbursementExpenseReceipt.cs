using Abot_Kamay_Tracking_and_Queuing_System;
using Abot_Kamay_Tracking_and_Queuing_System.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Drawing.Printing;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    public partial class ReimbursementExpenseReceipt : Form
    {
        private Step4Form home;
    

        public ReimbursementExpenseReceipt(Step4Form home)
        {
            InitializeComponent();
            this.home = home;
            date.Text = "Date: " + DateTime.Now.ToString("yyyy-MM-dd");

        }

        private void ReimbursementExpenseReceipt_Load(object sender, EventArgs e)
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
                bi.civil_status_other as bcivilother 
                FROM clientinformation AS ci RIGHT JOIN beneficiaryinformation AS bi ON ci.client_id = bi.client_id WHERE ci.client_id = @client_id ORDER BY bi.beneficiary_id DESC LIMIT 1";
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(client, conn))
                {
                    cmd.Parameters.AddWithValue("@client_id", this.home.clientId);

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                           // MessageBox.Show(rd["last_name"].ToString());
                            clientName.Text = rd["last_name"].ToString() + " " + rd["first_name"].ToString() + " " + rd["middle_name"].ToString();
                            clientAddess.Text = rd["street_purok"].ToString() + " " + rd["barangay"].ToString() + " " + rd["district"].ToString() + " " + rd["city_municipality"].ToString() + " " + rd["province"].ToString() + " " + rd["region"].ToString();
                        }
                    }
                }
            }
        }

        private void ReimbursementExpenseReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnPrint.PerformClick();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
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
            this.home._RerPrint = true;
            if (this.home._GisPrint && this.home._CoePrint && this.home._RerPrint)
            {
                this.home.btnStep4Save.Enabled = true;
                this.home.panelPrintForm.Visible = false;
                MessageBox.Show("You can now save the information!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
