using System.ComponentModel;
using System.Linq;
using ACMEDistrubuting_SWE3313_TeamAlpha.Models;
using ACMEDistrubuting_SWE3313_TeamAlpha.Services;

namespace ACMEDistrubuting_SWE3313_TeamAlpha
{
    public partial class associatePortal : Form
    {
        // --- Order submission state ---------------------------------------------------

        /// <summary>Items added to the order currently being built, before submission.</summary>
        private readonly List<OrderItem> currentOrderItems = new();

        /// <summary>Sales rep ID captured at login; used as the Sales Rep ID on submitted orders.</summary>
        private string loggedInSalesRepId = string.Empty;

        // Created in code (not the designer) so they don't collide with the rest of the
        // team's designer edits while the order screen layout is still being finalized.
        private ListBox orderItemsListBox = null!;
        private Button submitOrderButton = null!;
        private Label orderItemsLabel = null!;

        /// <summary>Acme's master product list (300+ item requirement), loaded once at startup.</summary>
        private List<Product> productCatalog = new();

        public associatePortal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loginPanel.Visible = true;

            CCPanel.Visible = false;
            LogOutPanel.Visible = false;
            addCustomerPanel.Visible = false;
            OrderProccessPanel.Visible = false;

            productCatalog = ProductCatalogService.LoadCatalog();

            // Diagnostic: a silently-empty catalog is exactly what makes every product lookup
            // fall back to free text, which is otherwise indistinguishable from a real typo.
            // Remove this once the deployment/build settings are confirmed working.
            if (productCatalog.Count == 0)
            {
                MessageBox.Show(
                    "Product catalog failed to load (0 items). Check that Products\\product_catalog.csv " +
                    "exists next to the .exe, and that its Build Action is 'Content' with 'Copy to Output " +
                    "Directory' set to 'Copy if newer'.",
                    "Catalog Load Warning");
            }

            InitializeOrderSubmissionControls();
        }

        /// <summary>
        /// Adds the order-items list and Submit Order button to the order panel, and wires
        /// up the Add Item button. Kept separate from InitializeComponent so it's easy for
        /// the designer to keep managing everything else in Form1.Designer.cs.
        /// </summary>
        private void InitializeOrderSubmissionControls()
        {
            // Product/Quantity boxes + Add Item end around y=270. Submit Order gets its own
            // row well below that (y=320), centered, so it can't be mistaken for part of the
            // entry row above it. The items list (with a header label) sits below the button.
            submitOrderButton = new Button
            {
                Name = "submitOrderButton",
                Text = "Submit Order",
                Location = new Point(233, 320),
                Size = new Size(150, 35),
                UseVisualStyleBackColor = true
            };
            submitOrderButton.Click += submitOrderButton_Click;

            orderItemsLabel = new Label
            {
                Name = "orderItemsLabel",
                Text = "Order Items",
                AutoSize = true,
                Location = new Point(11, 375)
            };

            orderItemsListBox = new ListBox
            {
                Name = "orderItemsListBox",
                Location = new Point(11, 400),
                Size = new Size(578, 200),
                Font = new Font("Segoe UI", 11F)
            };

            OrderProccessPanel.Controls.Add(submitOrderButton);
            OrderProccessPanel.Controls.Add(orderItemsLabel);
            OrderProccessPanel.Controls.Add(orderItemsListBox);

            // Controls added in code can end up layered behind ones the designer already
            // created, even when their coordinates don't overlap. Force them to the front so
            // they're never visually hidden.
            submitOrderButton.BringToFront();
            orderItemsLabel.BringToFront();
            orderItemsListBox.BringToFront();

            // Suggest real catalog items ("ID - Name") as the rep types, so orders reference
            // actual inventory instead of arbitrary free text.
            productBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            productBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var suggestions = new AutoCompleteStringCollection();
            suggestions.AddRange(productCatalog.Select(p => p.ToString()).ToArray());
            productBox.AutoCompleteCustomSource = suggestions;

            addItemButton.Click += addItemButton_Click;
        }

        /// <summary>
        /// Matches what the rep typed against the loaded catalog, accepting either the full
        /// "ID - Name" autocomplete suggestion or a bare item ID.
        /// </summary>
        private Product? ResolveProduct(string input)
        {
            return productCatalog.FirstOrDefault(p =>
                       p.ToString().Equals(input, StringComparison.OrdinalIgnoreCase))
                ?? productCatalog.FirstOrDefault(p =>
                       p.ItemId.Equals(input, StringComparison.OrdinalIgnoreCase));
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // TODO: replace with real credential check once that backend piece exists.
            loggedInSalesRepId = associateIDBox.Text.Trim();

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
            loginPanel.Visible = true;
        }

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
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            addCustomerPanel.Visible = true;
            customerSbmPanel.Visible = false;
        }

        // --- Order submission handlers ---------------------------------------------------

        /// <summary>
        /// Shows the given text (a receipt or summary) in a small read-only dialog using a
        /// monospace font. Plain MessageBox uses a proportional font, which throws off the
        /// padded columns in GenerateReceipt/GenerateDailySummary, so those need a fixed-width
        /// font to actually line up.
        /// </summary>
        private static void ShowReceiptDialog(string title, string bodyText)
        {
            using var receiptForm = new Form
            {
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(520, 420),
                MinimizeBox = false,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            var receiptBox = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10F),
                Text = bodyText
            };

            var closeButton = new Button
            {
                Text = "Close",
                Dock = DockStyle.Bottom,
                Height = 35,
                DialogResult = DialogResult.OK
            };

            receiptForm.Controls.Add(receiptBox);
            receiptForm.Controls.Add(closeButton);
            receiptForm.AcceptButton = closeButton;
            receiptForm.ShowDialog();
        }

        /// <summary>
        /// Adds the currently entered product/quantity as a line item on the in-progress order.
        /// </summary>
        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productBox.Text) || productBox.Text == "Select Product")
            {
                MessageBox.Show("Please enter an item.", "Missing Item");
                return;
            }

            if (!int.TryParse(quantityBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity");
                return;
            }

            // Resolve against the loaded product catalog (300+ active items from the master
            // product list) so the order references a real item ID/name pair. Falls back to
            // treating the typed text as both ID and name if it doesn't match anything, so a
            // rep can't be blocked entirely by a catalog miss/typo.
            Product? matched = ResolveProduct(productBox.Text.Trim());
            string itemId = matched?.ItemId ?? productBox.Text.Trim();
            string itemName = matched?.ItemName ?? productBox.Text.Trim();

            var item = new OrderItem(itemId, itemName, quantity);
            currentOrderItems.Add(item);
            orderItemsListBox.Items.Add(item.ToString());

            productBox.Clear();
            quantityBox.Clear();
        }

        /// <summary>
        /// Builds an Order from the current form state and hands it to
        /// OrderSubmissionService to be validated and "transmitted" (written to disk).
        /// </summary>
        private void submitOrderButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectCustomerBox.Text) ||
                SelectCustomerBox.Text.Trim() == "Select Customer")
            {
                MessageBox.Show("Please select a customer.", "Missing Customer");
                return;
            }

            if (!DateTime.TryParse(orderDateBox.Text, out DateTime deliveryDate))
            {
                MessageBox.Show("Please enter a valid delivery date (MM/DD/YYYY).", "Invalid Date");
                return;
            }

            var order = new Order
            {
                AccountId = SelectCustomerBox.Text.Trim(),
                SalesRepId = loggedInSalesRepId,
                DeliveryRepId = loggedInSalesRepId, // TODO: replace once a separate delivery rep field/lookup exists
                DeliveryDate = deliveryDate,
                Items = new List<OrderItem>(currentOrderItems)
            };

            List<string> errors = order.Validate();
            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, errors), "Cannot Submit Order");
                return;
            }

            try
            {
                string filePath = OrderSubmissionService.Submit(order);
                string receipt = OrderSubmissionService.GenerateReceipt(order);
                ShowReceiptDialog("Order Submitted", $"{receipt}\nSaved to: {filePath}");

                currentOrderItems.Clear();
                orderItemsListBox.Items.Clear();
                productBox.Clear();
                quantityBox.Clear();
                SelectCustomerBox.Clear();

                OrderProccessPanel.Visible = false;
                CCPanel.Visible = true;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Cannot Submit Order");
            }
        }
    }
}