using System.ComponentModel;

namespace ACMEDistrubuting_SWE3313_TeamAlpha
{
    public partial class associatePortal : Form
    {
        public associatePortal()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loginPanel.Visible = true;


            CCPanel.Visible = false;
            LogOutPanel.Visible = false;
            OrderProccessPanel.Visible = false;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            customerSbmPanel.Visible = false;
            
            CCPanel.Visible = true;


        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            LogOutPanel.Visible = true;
        }

        private void LogOutNoButton_Click(object sender, EventArgs e)
        {
            LogOutPanel.Visible = false;
        }

        private void LogOutYesButton_Click(object sender, EventArgs e)
        {
            LogOutPanel.Visible = false;
            CCPanel.Visible = false;
            loginPanel.Visible = true;
        }

        /// <summary>
        /// TODO: Finish layout etc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderButton_Click(object sender, EventArgs e)
        {
            OrderProccessPanel.Visible = true;
            CCPanel.Visible = false;
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CCPanel.Visible = false;
            customerSbmPanel.Visible = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
