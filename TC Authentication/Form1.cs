using System;
using System.Windows.Forms;

namespace TC_Authentication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var identificationNumber = long.Parse(txtTC.Text);
            var birthOfYear = int.Parse(txtBirth.Text);
            bool situation;

            try
            {
                using (TCVerify.KPSPublicSoapClient service = new TCVerify.KPSPublicSoapClient { })
                {
                    situation = service.TCKimlikNoDogrula(identificationNumber, txtName.Text, txtLastname.Text, birthOfYear);
                }

                if (situation == true)
                {
                    MessageBox.Show("Valid user.");
                }
                else
                {
                    MessageBox.Show("Invalid user.");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}