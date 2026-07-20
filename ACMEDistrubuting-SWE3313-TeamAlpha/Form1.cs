using System.ComponentModel;

namespace ACMEDistrubuting_SWE3313_TeamAlpha
{
    public partial class associatePortal : Form
    {
        private readonly RouteDeterminationControl routeDeterminationControl;

        public associatePortal()
        {
            InitializeComponent();

            routeDeterminationControl = new RouteDeterminationControl(
                SampleRouteCustomers.Create());
            routeDeterminationControl.Visible = false;
            routeDeterminationControl.BackRequested +=
                routeDeterminationControl_BackRequested;
            Controls.Add(routeDeterminationControl);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loginPanel.Visible = true;


            CCPanel.Visible = false;
            LogOutPanel.Visible = false;
            addCustomerPanel.Visible = false;
            OrderProccessPanel.Visible = false;
            routeDeterminationControl.Visible = false;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            CCPanel.Visible = true;

            loginPanel.Visible = false;
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
            routeDeterminationControl.Visible = false;
            loginPanel.Visible = true;
        }

        //TODO: Generate a reciept for the order and must feature a "go back" button to fix any errors for a short time.
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

        private void routeButton_Click(object sender, EventArgs e)
        {
            CCPanel.Visible = false;
            routeDeterminationControl.Visible = true;
            routeDeterminationControl.BringToFront();
        }

        private void routeDeterminationControl_BackRequested(
            object? sender,
            EventArgs e)
        {
            routeDeterminationControl.Visible = false;
            CCPanel.Visible = true;
            CCPanel.BringToFront();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            addCustomerPanel.Visible = true;
            customerSbmPanel.Visible = false;
        }
    }
}
