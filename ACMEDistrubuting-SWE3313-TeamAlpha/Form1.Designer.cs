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
            loginButton = new Button();
            passwordBox = new TextBox();
            associateIDBox = new TextBox();
            logoPicture = new PictureBox();
            LogOutPanel = new Panel();
            label1 = new Label();
            LogOutYesButton = new Button();
            LogOutNoButton = new Button();
            OrderProccessPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            addItemButton = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            customerLabel = new Label();
            textBox4 = new TextBox();
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
            pictureBox2 = new PictureBox();
            button1 = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicture).BeginInit();
            LogOutPanel.SuspendLayout();
            OrderProccessPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            CCPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CCLogo).BeginInit();
            customerSbmPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginPanel.BorderStyle = BorderStyle.FixedSingle;
            loginPanel.Controls.Add(loginButton);
            loginPanel.Controls.Add(passwordBox);
            loginPanel.Controls.Add(associateIDBox);
            loginPanel.Controls.Add(logoPicture);
            loginPanel.ForeColor = SystemColors.ControlText;
            loginPanel.Location = new Point(137, -1);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(594, 650);
            loginPanel.TabIndex = 0;
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
            logoPicture.Location = new Point(128, 19);
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
            LogOutPanel.Controls.Add(label1);
            LogOutPanel.Controls.Add(LogOutYesButton);
            LogOutPanel.Controls.Add(LogOutNoButton);
            LogOutPanel.ForeColor = SystemColors.ActiveCaptionText;
            LogOutPanel.Location = new Point(125, 198);
            LogOutPanel.Name = "LogOutPanel";
            LogOutPanel.Size = new Size(234, 149);
            LogOutPanel.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(54, 20);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 2;
            label1.Text = "Log Out?";
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
            OrderProccessPanel.BorderStyle = BorderStyle.FixedSingle;
            OrderProccessPanel.Controls.Add(tableLayoutPanel1);
            OrderProccessPanel.Controls.Add(addItemButton);
            OrderProccessPanel.Controls.Add(label4);
            OrderProccessPanel.Controls.Add(label3);
            OrderProccessPanel.Controls.Add(label2);
            OrderProccessPanel.Controls.Add(customerLabel);
            OrderProccessPanel.Controls.Add(textBox4);
            OrderProccessPanel.Controls.Add(quantityBox);
            OrderProccessPanel.Controls.Add(productBox);
            OrderProccessPanel.Controls.Add(orderDateBox);
            OrderProccessPanel.Controls.Add(SelectCustomerBox);
            OrderProccessPanel.Controls.Add(pictureBox1);
            OrderProccessPanel.Location = new Point(137, -1);
            OrderProccessPanel.Name = "OrderProccessPanel";
            OrderProccessPanel.Size = new Size(594, 650);
            OrderProccessPanel.TabIndex = 2;
            OrderProccessPanel.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Location = new Point(11, 300);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(564, 279);
            tableLayoutPanel1.TabIndex = 12;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(294, 219);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 10;
            label4.Text = "Quantity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(305, 143);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 9;
            label3.Text = "Order Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 221);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 8;
            label2.Text = "Product";
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
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 20F);
            textBox4.Location = new Point(194, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(213, 43);
            textBox4.TabIndex = 6;
            textBox4.Text = "Order Processing";
            // 
            // quantityBox
            // 
            quantityBox.Font = new Font("Segoe UI", 13F);
            quantityBox.Location = new Point(289, 239);
            quantityBox.Name = "quantityBox";
            quantityBox.Size = new Size(166, 31);
            quantityBox.TabIndex = 5;
            // 
            // productBox
            // 
            productBox.Font = new Font("Segoe UI", 13F);
            productBox.Location = new Point(11, 239);
            productBox.Name = "productBox";
            productBox.Size = new Size(276, 31);
            productBox.TabIndex = 4;
            // 
            // orderDateBox
            // 
            orderDateBox.Font = new Font("Segoe UI", 13F);
            orderDateBox.Location = new Point(305, 161);
            orderDateBox.Name = "orderDateBox";
            orderDateBox.Size = new Size(290, 31);
            orderDateBox.TabIndex = 3;
            // 
            // SelectCustomerBox
            // 
            SelectCustomerBox.BorderStyle = BorderStyle.FixedSingle;
            SelectCustomerBox.Font = new Font("Segoe UI", 13F);
            SelectCustomerBox.Location = new Point(11, 162);
            SelectCustomerBox.Name = "SelectCustomerBox";
            SelectCustomerBox.Size = new Size(277, 31);
            SelectCustomerBox.TabIndex = 2;
            SelectCustomerBox.Text = "Select Customer";
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
            CCPanel.BorderStyle = BorderStyle.FixedSingle;
            CCPanel.Controls.Add(routeButton);
            CCPanel.Controls.Add(customerButton);
            CCPanel.Controls.Add(CCLogo);
            CCPanel.Controls.Add(orderButton);
            CCPanel.Controls.Add(LogOutButton);
            CCPanel.Controls.Add(LogOutPanel);
            CCPanel.Location = new Point(171, -1);
            CCPanel.Name = "CCPanel";
            CCPanel.Size = new Size(500, 650);
            CCPanel.TabIndex = 1;
            // 
            // routeButton
            // 
            routeButton.Font = new Font("Segoe UI", 12F);
            routeButton.Location = new Point(156, 375);
            routeButton.Name = "routeButton";
            routeButton.Size = new Size(185, 60);
            routeButton.TabIndex = 3;
            routeButton.Text = "Routes Determination";
            routeButton.UseVisualStyleBackColor = true;
            // 
            // customerButton
            // 
            customerButton.Font = new Font("Segoe UI", 12F);
            customerButton.Location = new Point(156, 276);
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
            CCLogo.Location = new Point(148, 19);
            CCLogo.Name = "CCLogo";
            CCLogo.Size = new Size(233, 172);
            CCLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            CCLogo.TabIndex = 1;
            CCLogo.TabStop = false;
            // 
            // orderButton
            // 
            orderButton.Font = new Font("Segoe UI", 12F);
            orderButton.Location = new Point(156, 182);
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
            LogOutButton.Location = new Point(156, 483);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(168, 84);
            LogOutButton.TabIndex = 0;
            LogOutButton.Text = "Log Out";
            LogOutButton.UseVisualStyleBackColor = false;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // customerSbmPanel
            // 
            customerSbmPanel.Controls.Add(pictureBox2);
            customerSbmPanel.Controls.Add(button1);
            customerSbmPanel.Controls.Add(textBox1);
            customerSbmPanel.Controls.Add(label5);
            customerSbmPanel.Location = new Point(119, 3);
            customerSbmPanel.Name = "customerSbmPanel";
            customerSbmPanel.Size = new Size(608, 650);
            customerSbmPanel.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(418, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(190, 104);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(440, 191);
            button1.Name = "button1";
            button1.Size = new Size(154, 50);
            button1.TabIndex = 2;
            button1.Text = "Add customer";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 15F);
            textBox1.Location = new Point(18, 202);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 34);
            textBox1.TabIndex = 1;
            textBox1.Text = "Search Customer";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(171, 26);
            label5.Name = "label5";
            label5.Size = new Size(217, 28);
            label5.TabIndex = 0;
            label5.Text = "Customer Management";
            // 
            // associatePortal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 661);
            Controls.Add(loginPanel);
            Controls.Add(CCPanel);
            Controls.Add(customerSbmPanel);
            Controls.Add(OrderProccessPanel);
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
        private Label label1;
        private Button LogOutNoButton;
        private Button LogOutYesButton;
        private Panel LogOutPanel;
        private Panel OrderProccessPanel;
        private PictureBox pictureBox1;
        private TextBox SelectCustomerBox;
        private TextBox productBox;
        private TextBox orderDateBox;
        private TextBox quantityBox;
        private TextBox textBox4;
        private Button addItemButton;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label customerLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel customerSbmPanel;
        private Label label5;
        private TextBox textBox1;
        private Button button1;
        private PictureBox pictureBox2;
    }
}
