using ACMEDistrubuting_SWE3313_TeamAlpha.Models;
using ACMEDistrubuting_SWE3313_TeamAlpha.Services;
namespace ACMEDistrubuting_SWE3313_TeamAlpha
{
    partial class associatePortal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(associatePortal));
            loginPanel = new Panel();
            loginErrorLabel = new Label();
            loginButton = new Button();
            passwordBox = new TextBox();
            associateIDBox = new TextBox();
            logoPicture = new PictureBox();
            LogOutPanel = new Panel();
            logOutLabel = new Label();
            LogOutYesButton = new Button();
            LogOutNoButton = new Button();
            OrderProccessPanel = new Panel();
            orderBackButton = new Button();
            orderSbmnLabel = new Label();
            addItemButton = new Button();
            quantityLabel = new Label();
            orderDateLabel = new Label();
            productLabel = new Label();
            customerLabel = new Label();
            quantityBox = new TextBox();
            productBox = new TextBox();
            orderDateBox = new TextBox();
            SelectCustomerBox = new TextBox();
            pictureBox1 = new PictureBox();
            CCPanel = new Panel();
            routeButton = new Button();
            customerButton = new Button();
            CCLogo = new PictureBox();
            orderButton = new Button();
            LogOutButton = new Button();
            customerSbmPanel = new Panel();
            backButton = new Button();
            pictureBox2 = new PictureBox();
            addCustomerButton = new Button();
            searchCustomerBox = new TextBox();
            cstmrMgmtButton = new Label();
            addCustomerPanel = new Panel();
            cstmSubmitButton = new Button();
            cstmCancelButton = new Button();
            delivConBox = new TextBox();
            pocBox = new TextBox();
            phoneNumBox = new TextBox();
            dockCapBox = new TextBox();
            payMethodBox = new TextBox();
            beerLicBox = new TextBox();
            zipBox = new TextBox();
            stateBox = new TextBox();
            cityBox = new TextBox();
            addressBox = new TextBox();
            fullNameBox = new TextBox();
            addCstmLogo = new PictureBox();
            addCustomerLabel = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).BeginInit();
            LogOutPanel.SuspendLayout();
            OrderProccessPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            CCPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CCLogo).BeginInit();
            customerSbmPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            addCustomerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)addCstmLogo).BeginInit();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.None;
            loginPanel.BorderStyle = BorderStyle.FixedSingle;
            loginPanel.Controls.Add(loginErrorLabel);
            loginPanel.Controls.Add(loginButton);
            loginPanel.Controls.Add(passwordBox);
            loginPanel.Controls.Add(associateIDBox);
            loginPanel.Controls.Add(logoPicture);
            loginPanel.ForeColor = SystemColors.ControlText;
            loginPanel.Location = new Point(123, -1);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(594, 650);
            loginPanel.TabIndex = 0;
            // 
            // loginErrorLabel
            // 
            loginErrorLabel.AutoSize = true;
            loginErrorLabel.ForeColor = Color.FromArgb(192, 0, 0);
            loginErrorLabel.Location = new Point(131, 324);
            loginErrorLabel.Name = "loginErrorLabel";
            loginErrorLabel.Size = new Size(146, 15);
            loginErrorLabel.TabIndex = 4;
            loginErrorLabel.Text = "ID or Password is incorrect";
            loginErrorLabel.Visible = false;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginButton.BackColor = SystemColors.ActiveBorder;
            loginButton.FlatAppearance.BorderColor = Color.Black;
            loginButton.FlatAppearance.BorderSize = 2;
            loginButton.FlatAppearance.MouseDownBackColor = Color.Black;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 15F);
            loginButton.ForeColor = SystemColors.ControlText;
            loginButton.Location = new Point(170, 353);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(226, 75);
            loginButton.TabIndex = 3;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // passwordBox
            // 
            passwordBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            passwordBox.Font = new Font("Segoe UI", 15F);
            passwordBox.HideSelection = false;
            passwordBox.Location = new Point(128, 283);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Password";
            passwordBox.Size = new Size(327, 34);
            passwordBox.TabIndex = 2;
            // 
            // associateIDBox
            // 
            associateIDBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            associateIDBox.Font = new Font("Segoe UI", 15F);
            associateIDBox.Location = new Point(128, 216);
            associateIDBox.Name = "associateIDBox";
            associateIDBox.PlaceholderText = "Associate ID";
            associateIDBox.Size = new Size(327, 34);
            associateIDBox.TabIndex = 1;
            // 
            // logoPicture
            // 
            logoPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logoPicture.Image = (Image)resources.GetObject("logoPicture.Image");
            logoPicture.InitialImage = (Image)resources.GetObject("logoPicture.InitialImage");
            logoPicture.Location = new Point(129, 23);
            logoPicture.Name = "logoPicture";
            logoPicture.Size = new Size(327, 169);
            logoPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPicture.TabIndex = 0;
            logoPicture.TabStop = false;
            // 
            // LogOutPanel
            // 
            LogOutPanel.BackColor = Color.FromArgb(224, 224, 224);
            LogOutPanel.BorderStyle = BorderStyle.FixedSingle;
            LogOutPanel.Controls.Add(logOutLabel);
            LogOutPanel.Controls.Add(LogOutYesButton);
            LogOutPanel.Controls.Add(LogOutNoButton);
            LogOutPanel.ForeColor = SystemColors.ActiveCaptionText;
            LogOutPanel.Location = new Point(196, 239);
            LogOutPanel.Name = "LogOutPanel";
            LogOutPanel.Size = new Size(234, 149);
            LogOutPanel.TabIndex = 5;
            // 
            // logOutLabel
            // 
            logOutLabel.AutoSize = true;
            logOutLabel.Font = new Font("Segoe UI", 13F);
            logOutLabel.Location = new Point(54, 20);
            logOutLabel.Name = "logOutLabel";
            logOutLabel.Size = new Size(85, 25);
            logOutLabel.TabIndex = 2;
            logOutLabel.Text = "Log Out?";
            // 
            // LogOutYesButton
            // 
            LogOutYesButton.BackColor = Color.Silver;
            LogOutYesButton.FlatStyle = FlatStyle.Flat;
            LogOutYesButton.Font = new Font("Segoe UI", 11F);
            LogOutYesButton.Location = new Point(129, 72);
            LogOutYesButton.Name = "LogOutYesButton";
            LogOutYesButton.Size = new Size(75, 33);
            LogOutYesButton.TabIndex = 4;
            LogOutYesButton.Text = "Yes";
            LogOutYesButton.UseVisualStyleBackColor = false;
            LogOutYesButton.Click += LogOutYesButton_Click;
            // 
            // LogOutNoButton
            // 
            LogOutNoButton.Font = new Font("Segoe UI", 11F);
            LogOutNoButton.Location = new Point(30, 72);
            LogOutNoButton.Name = "LogOutNoButton";
            LogOutNoButton.Size = new Size(75, 33);
            LogOutNoButton.TabIndex = 3;
            LogOutNoButton.Text = "No";
            LogOutNoButton.UseVisualStyleBackColor = true;
            LogOutNoButton.Click += LogOutNoButton_Click;
            // 
            // OrderProccessPanel
            // 
            OrderProccessPanel.Anchor = AnchorStyles.None;
            OrderProccessPanel.BorderStyle = BorderStyle.FixedSingle;
            OrderProccessPanel.Controls.Add(orderBackButton);
            OrderProccessPanel.Controls.Add(orderSbmnLabel);
            OrderProccessPanel.Controls.Add(addItemButton);
            OrderProccessPanel.Controls.Add(quantityLabel);
            OrderProccessPanel.Controls.Add(orderDateLabel);
            OrderProccessPanel.Controls.Add(productLabel);
            OrderProccessPanel.Controls.Add(customerLabel);
            OrderProccessPanel.Controls.Add(quantityBox);
            OrderProccessPanel.Controls.Add(productBox);
            OrderProccessPanel.Controls.Add(orderDateBox);
            OrderProccessPanel.Controls.Add(SelectCustomerBox);
            OrderProccessPanel.Controls.Add(pictureBox1);
            OrderProccessPanel.Location = new Point(123, -1);
            OrderProccessPanel.Name = "OrderProccessPanel";
            OrderProccessPanel.Size = new Size(594, 650);
            OrderProccessPanel.TabIndex = 2;
            OrderProccessPanel.Visible = false;
            // 
            // orderBackButton
            // 
            orderBackButton.Location = new Point(17, 591);
            orderBackButton.Name = "orderBackButton";
            orderBackButton.Size = new Size(75, 30);
            orderBackButton.TabIndex = 14;
            orderBackButton.Text = "Back";
            orderBackButton.UseVisualStyleBackColor = true;
            orderBackButton.Click += orderBackButton_Click;
            // 
            // orderSbmnLabel
            // 
            orderSbmnLabel.AutoSize = true;
            orderSbmnLabel.Font = new Font("Segoe UI", 15F);
            orderSbmnLabel.Location = new Point(196, 9);
            orderSbmnLabel.Name = "orderSbmnLabel";
            orderSbmnLabel.Size = new Size(168, 28);
            orderSbmnLabel.TabIndex = 12;
            orderSbmnLabel.Text = "Order Submission";
            // 
            // addItemButton
            // 
            addItemButton.Location = new Point(461, 239);
            addItemButton.Name = "addItemButton";
            addItemButton.Size = new Size(128, 31);
            addItemButton.TabIndex = 11;
            addItemButton.Text = "Add Item";
            addItemButton.UseVisualStyleBackColor = true;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new Point(294, 196);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(53, 15);
            quantityLabel.TabIndex = 10;
            quantityLabel.Text = "Quantity";
            // 
            // orderDateLabel
            // 
            orderDateLabel.AutoSize = true;
            orderDateLabel.Location = new Point(305, 143);
            orderDateLabel.Name = "orderDateLabel";
            orderDateLabel.Size = new Size(64, 15);
            orderDateLabel.TabIndex = 9;
            orderDateLabel.Text = "Order Date";
            // 
            // productLabel
            // 
            productLabel.AutoSize = true;
            productLabel.Location = new Point(11, 196);
            productLabel.Name = "productLabel";
            productLabel.Size = new Size(49, 15);
            productLabel.TabIndex = 8;
            productLabel.Text = "Product";
            // 
            // customerLabel
            // 
            customerLabel.AutoSize = true;
            customerLabel.Location = new Point(11, 144);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(59, 15);
            customerLabel.TabIndex = 7;
            customerLabel.Text = "Customer";
            // 
            // quantityBox
            // 
            quantityBox.Font = new Font("Segoe UI", 13F);
            quantityBox.Location = new Point(289, 212);
            quantityBox.Name = "quantityBox";
            quantityBox.Size = new Size(166, 31);
            quantityBox.TabIndex = 5;
            // 
            // productBox
            // 
            productBox.Font = new Font("Segoe UI", 13F);
            productBox.Location = new Point(11, 212);
            productBox.Name = "productBox";
            productBox.PlaceholderText = "Select Product";
            productBox.Size = new Size(276, 31);
            productBox.TabIndex = 4;
            // 
            // orderDateBox
            // 
            orderDateBox.Font = new Font("Segoe UI", 13F);
            orderDateBox.Location = new Point(305, 161);
            orderDateBox.Name = "orderDateBox";
            orderDateBox.PlaceholderText = "MM/DD/YYYY";
            orderDateBox.Size = new Size(290, 31);
            orderDateBox.TabIndex = 3;
            // 
            // SelectCustomerBox
            // 
            SelectCustomerBox.BorderStyle = BorderStyle.FixedSingle;
            SelectCustomerBox.Font = new Font("Segoe UI", 13F);
            SelectCustomerBox.Location = new Point(11, 162);
            SelectCustomerBox.Name = "SelectCustomerBox";
            SelectCustomerBox.PlaceholderText = "Select Customer";
            SelectCustomerBox.Size = new Size(277, 31);
            SelectCustomerBox.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(415, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(177, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // CCPanel
            // 
            CCPanel.Anchor = AnchorStyles.None;
            CCPanel.BorderStyle = BorderStyle.FixedSingle;
            CCPanel.Controls.Add(LogOutPanel);
            CCPanel.Controls.Add(routeButton);
            CCPanel.Controls.Add(customerButton);
            CCPanel.Controls.Add(CCLogo);
            CCPanel.Controls.Add(orderButton);
            CCPanel.Controls.Add(LogOutButton);
            CCPanel.Location = new Point(123, -1);
            CCPanel.Name = "CCPanel";
            CCPanel.Size = new Size(594, 650);
            CCPanel.TabIndex = 1;
            // 
            // routeButton
            // 
            routeButton.Font = new Font("Segoe UI", 12F);
            routeButton.Location = new Point(227, 416);
            routeButton.Name = "routeButton";
            routeButton.Size = new Size(185, 71);
            routeButton.TabIndex = 3;
            routeButton.Text = "Routes Determination";
            routeButton.UseVisualStyleBackColor = true;
            routeButton.Click += routeButton_Click;
            // 
            // customerButton
            // 
            customerButton.Font = new Font("Segoe UI", 12F);
            customerButton.Location = new Point(227, 317);
            customerButton.Name = "customerButton";
            customerButton.Size = new Size(185, 71);
            customerButton.TabIndex = 2;
            customerButton.Text = "Customer Management";
            customerButton.UseVisualStyleBackColor = true;
            customerButton.Click += customerButton_Click;
            // 
            // CCLogo
            // 
            CCLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CCLogo.Image = (Image)resources.GetObject("CCLogo.Image");
            CCLogo.InitialImage = (Image)resources.GetObject("CCLogo.InitialImage");
            CCLogo.Location = new Point(170, 12);
            CCLogo.Name = "CCLogo";
            CCLogo.Size = new Size(327, 172);
            CCLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            CCLogo.TabIndex = 1;
            CCLogo.TabStop = false;
            // 
            // orderButton
            // 
            orderButton.Font = new Font("Segoe UI", 12F);
            orderButton.Location = new Point(227, 223);
            orderButton.Name = "orderButton";
            orderButton.Size = new Size(185, 68);
            orderButton.TabIndex = 1;
            orderButton.Text = "Order Submission";
            orderButton.UseVisualStyleBackColor = true;
            orderButton.Click += orderButton_Click;
            // 
            // LogOutButton
            // 
            LogOutButton.BackColor = Color.FromArgb(192, 0, 0);
            LogOutButton.FlatAppearance.BorderSize = 3;
            LogOutButton.FlatStyle = FlatStyle.Flat;
            LogOutButton.Font = new Font("Segoe UI", 15F);
            LogOutButton.Location = new Point(227, 524);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(168, 84);
            LogOutButton.TabIndex = 0;
            LogOutButton.Text = "Log Out";
            LogOutButton.UseVisualStyleBackColor = false;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // customerSbmPanel
            // 
            customerSbmPanel.Anchor = AnchorStyles.None;
            customerSbmPanel.Controls.Add(backButton);
            customerSbmPanel.Controls.Add(pictureBox2);
            customerSbmPanel.Controls.Add(addCustomerButton);
            customerSbmPanel.Controls.Add(searchCustomerBox);
            customerSbmPanel.Controls.Add(cstmrMgmtButton);
            customerSbmPanel.Location = new Point(123, -1);
            customerSbmPanel.Name = "customerSbmPanel";
            customerSbmPanel.Size = new Size(594, 650);
            customerSbmPanel.TabIndex = 6;
            // 
            // backButton
            // 
            backButton.Location = new Point(18, 579);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 30);
            backButton.TabIndex = 4;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(418, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(176, 104);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // addCustomerButton
            // 
            addCustomerButton.BackColor = Color.Silver;
            addCustomerButton.FlatStyle = FlatStyle.Flat;
            addCustomerButton.Font = new Font("Segoe UI", 15F);
            addCustomerButton.Location = new Point(440, 191);
            addCustomerButton.Name = "addCustomerButton";
            addCustomerButton.Size = new Size(154, 50);
            addCustomerButton.TabIndex = 2;
            addCustomerButton.Text = "Add customer";
            addCustomerButton.UseVisualStyleBackColor = false;
            addCustomerButton.Click += addCustomerButton_Click;
            // 
            // searchCustomerBox
            // 
            searchCustomerBox.Font = new Font("Segoe UI", 15F);
            searchCustomerBox.Location = new Point(18, 202);
            searchCustomerBox.Name = "searchCustomerBox";
            searchCustomerBox.PlaceholderText = "Search Customer";
            searchCustomerBox.Size = new Size(179, 34);
            searchCustomerBox.TabIndex = 1;
            // 
            // cstmrMgmtButton
            // 
            cstmrMgmtButton.AutoSize = true;
            cstmrMgmtButton.Font = new Font("Segoe UI", 15F);
            cstmrMgmtButton.Location = new Point(171, 26);
            cstmrMgmtButton.Name = "cstmrMgmtButton";
            cstmrMgmtButton.Size = new Size(217, 28);
            cstmrMgmtButton.TabIndex = 0;
            cstmrMgmtButton.Text = "Customer Management";
            // 
            // addCustomerPanel
            // 
            addCustomerPanel.Anchor = AnchorStyles.None;
            addCustomerPanel.Controls.Add(cstmSubmitButton);
            addCustomerPanel.Controls.Add(cstmCancelButton);
            addCustomerPanel.Controls.Add(delivConBox);
            addCustomerPanel.Controls.Add(pocBox);
            addCustomerPanel.Controls.Add(phoneNumBox);
            addCustomerPanel.Controls.Add(dockCapBox);
            addCustomerPanel.Controls.Add(payMethodBox);
            addCustomerPanel.Controls.Add(beerLicBox);
            addCustomerPanel.Controls.Add(zipBox);
            addCustomerPanel.Controls.Add(stateBox);
            addCustomerPanel.Controls.Add(cityBox);
            addCustomerPanel.Controls.Add(addressBox);
            addCustomerPanel.Controls.Add(fullNameBox);
            addCustomerPanel.Controls.Add(addCstmLogo);
            addCustomerPanel.Controls.Add(addCustomerLabel);
            addCustomerPanel.Location = new Point(123, -1);
            addCustomerPanel.Name = "addCustomerPanel";
            addCustomerPanel.Size = new Size(594, 650);
            addCustomerPanel.TabIndex = 7;
            // 
            // cstmSubmitButton
            // 
            cstmSubmitButton.Location = new Point(306, 614);
            cstmSubmitButton.Name = "cstmSubmitButton";
            cstmSubmitButton.Size = new Size(75, 23);
            cstmSubmitButton.TabIndex = 18;
            cstmSubmitButton.Text = "Submit";
            cstmSubmitButton.UseVisualStyleBackColor = true;
            // 
            // cstmCancelButton
            // 
            cstmCancelButton.Location = new Point(213, 614);
            cstmCancelButton.Name = "cstmCancelButton";
            cstmCancelButton.Size = new Size(75, 23);
            cstmCancelButton.TabIndex = 17;
            cstmCancelButton.Text = "Cancel";
            cstmCancelButton.UseVisualStyleBackColor = true;
            // 
            // delivConBox
            // 
            delivConBox.BorderStyle = BorderStyle.FixedSingle;
            delivConBox.Font = new Font("Segoe UI", 12F);
            delivConBox.Location = new Point(214, 467);
            delivConBox.Name = "delivConBox";
            delivConBox.PlaceholderText = "Delivery Constraints";
            delivConBox.Size = new Size(189, 29);
            delivConBox.TabIndex = 16;
            // 
            // pocBox
            // 
            pocBox.BorderStyle = BorderStyle.FixedSingle;
            pocBox.Font = new Font("Segoe UI", 12F);
            pocBox.Location = new Point(214, 516);
            pocBox.Name = "pocBox";
            pocBox.PlaceholderText = "POC";
            pocBox.Size = new Size(188, 29);
            pocBox.TabIndex = 15;
            // 
            // phoneNumBox
            // 
            phoneNumBox.BorderStyle = BorderStyle.FixedSingle;
            phoneNumBox.Font = new Font("Segoe UI", 12F);
            phoneNumBox.Location = new Point(214, 561);
            phoneNumBox.Name = "phoneNumBox";
            phoneNumBox.PlaceholderText = "Phone #";
            phoneNumBox.Size = new Size(188, 29);
            phoneNumBox.TabIndex = 14;
            // 
            // dockCapBox
            // 
            dockCapBox.BorderStyle = BorderStyle.FixedSingle;
            dockCapBox.Font = new Font("Segoe UI", 12F);
            dockCapBox.Location = new Point(215, 423);
            dockCapBox.Name = "dockCapBox";
            dockCapBox.PlaceholderText = "Loading Dock Capabilities";
            dockCapBox.Size = new Size(189, 29);
            dockCapBox.TabIndex = 12;
            // 
            // payMethodBox
            // 
            payMethodBox.BorderStyle = BorderStyle.FixedSingle;
            payMethodBox.Font = new Font("Segoe UI", 12F);
            payMethodBox.Location = new Point(216, 376);
            payMethodBox.Name = "payMethodBox";
            payMethodBox.PlaceholderText = "Payment Method";
            payMethodBox.Size = new Size(189, 29);
            payMethodBox.TabIndex = 11;
            // 
            // beerLicBox
            // 
            beerLicBox.BorderStyle = BorderStyle.FixedSingle;
            beerLicBox.Font = new Font("Segoe UI", 12F);
            beerLicBox.Location = new Point(216, 334);
            beerLicBox.Name = "beerLicBox";
            beerLicBox.PlaceholderText = "Beer License #";
            beerLicBox.Size = new Size(189, 29);
            beerLicBox.TabIndex = 10;
            // 
            // zipBox
            // 
            zipBox.BorderStyle = BorderStyle.FixedSingle;
            zipBox.Font = new Font("Segoe UI", 12F);
            zipBox.Location = new Point(215, 291);
            zipBox.Name = "zipBox";
            zipBox.PlaceholderText = "Zip";
            zipBox.Size = new Size(189, 29);
            zipBox.TabIndex = 9;
            // 
            // stateBox
            // 
            stateBox.BorderStyle = BorderStyle.FixedSingle;
            stateBox.Font = new Font("Segoe UI", 12F);
            stateBox.Location = new Point(215, 249);
            stateBox.Name = "stateBox";
            stateBox.PlaceholderText = "State";
            stateBox.Size = new Size(189, 29);
            stateBox.TabIndex = 8;
            // 
            // cityBox
            // 
            cityBox.BorderStyle = BorderStyle.FixedSingle;
            cityBox.Font = new Font("Segoe UI", 12F);
            cityBox.Location = new Point(215, 205);
            cityBox.Name = "cityBox";
            cityBox.PlaceholderText = "City";
            cityBox.Size = new Size(189, 29);
            cityBox.TabIndex = 7;
            // 
            // addressBox
            // 
            addressBox.BorderStyle = BorderStyle.FixedSingle;
            addressBox.Font = new Font("Segoe UI", 12F);
            addressBox.Location = new Point(215, 160);
            addressBox.Name = "addressBox";
            addressBox.PlaceholderText = "Street Address";
            addressBox.Size = new Size(189, 29);
            addressBox.TabIndex = 6;
            // 
            // fullNameBox
            // 
            fullNameBox.BorderStyle = BorderStyle.FixedSingle;
            fullNameBox.Font = new Font("Segoe UI", 12F);
            fullNameBox.Location = new Point(214, 115);
            fullNameBox.Name = "fullNameBox";
            fullNameBox.PlaceholderText = "Full name";
            fullNameBox.Size = new Size(189, 29);
            fullNameBox.TabIndex = 5;
            // 
            // addCstmLogo
            // 
            addCstmLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            addCstmLogo.Image = (Image)resources.GetObject("addCstmLogo.Image");
            addCstmLogo.InitialImage = (Image)resources.GetObject("addCstmLogo.InitialImage");
            addCstmLogo.Location = new Point(437, 1);
            addCstmLogo.Name = "addCstmLogo";
            addCstmLogo.Size = new Size(157, 105);
            addCstmLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            addCstmLogo.TabIndex = 4;
            addCstmLogo.TabStop = false;
            // 
            // addCustomerLabel
            // 
            addCustomerLabel.AutoSize = true;
            addCustomerLabel.Font = new Font("Segoe UI", 15F);
            addCustomerLabel.Location = new Point(245, 20);
            addCustomerLabel.Name = "addCustomerLabel";
            addCustomerLabel.Size = new Size(138, 28);
            addCustomerLabel.TabIndex = 0;
            addCustomerLabel.Text = "Add Customer";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(879, 661);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // associatePortal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 661);
            Controls.Add(loginPanel);
            Controls.Add(CCPanel);
            Controls.Add(OrderProccessPanel);
            Controls.Add(customerSbmPanel);
            Controls.Add(addCustomerPanel);
            Controls.Add(tableLayoutPanel1);
            Name = "associatePortal";
            Text = "Associate Portal";
            Load += Form1_Load;
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).EndInit();
            LogOutPanel.ResumeLayout(false);
            LogOutPanel.PerformLayout();
            OrderProccessPanel.ResumeLayout(false);
            OrderProccessPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            CCPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CCLogo).EndInit();
            customerSbmPanel.ResumeLayout(false);
            customerSbmPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            addCustomerPanel.ResumeLayout(false);
            addCustomerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)addCstmLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel loginPanel;
        private TextBox passwordBox;
        private TextBox associateIDBox;
        private PictureBox logoPicture;
        private Panel CCPanel;
        private Button LogOutButton;
        private Button orderButton;
        private PictureBox CCLogo;
        private Button routeButton;
        private Button customerButton;
        internal Button loginButton;
        private Label logOutLabel;
        private Button LogOutNoButton;
        private Button LogOutYesButton;
        private Panel LogOutPanel;
        private Panel OrderProccessPanel;
        private PictureBox pictureBox1;
        private TextBox SelectCustomerBox;
        private TextBox productBox;
        private TextBox orderDateBox;
        private TextBox quantityBox;
        private Button addItemButton;
        private Label quantityLabel;
        private Label orderDateLabel;
        private Label productLabel;
        private Label customerLabel;
        private Panel customerSbmPanel;
        private Label cstmrMgmtButton;
        private TextBox searchCustomerBox;
        private Button addCustomerButton;
        private PictureBox pictureBox2;
        private Label orderSbmnLabel;
        private Panel addCustomerPanel;
        private TextBox addressBox;
        private TextBox fullNameBox;
        private PictureBox addCstmLogo;
        private Label addCustomerLabel;
        private TextBox pocBox;
        private TextBox phoneNumBox;
        private TextBox dockCapBox;
        private TextBox payMethodBox;
        private TextBox beerLicBox;
        private TextBox zipBox;
        private TextBox stateBox;
        private TextBox cityBox;
        private TextBox delivConBox;
        private Button cstmSubmitButton;
        private Button cstmCancelButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Button orderBackButton;
        private Button backButton;
        private Label loginErrorLabel;
    }
}
