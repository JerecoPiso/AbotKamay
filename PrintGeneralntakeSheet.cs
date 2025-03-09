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
        private HomeForm home;

        public PrintGeneralntakeSheet(HomeForm home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void PrintGeneralntakeSheet_Load(object sender, EventArgs e)
        {
            ///MessageBox.Show(this.home.btnAddNew.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
