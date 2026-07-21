namespace ACMEDistrubuting_SWE3313_TeamAlpha;

public sealed class RouteDeterminationControl : UserControl
{
    private readonly IReadOnlyList<RouteCustomer> _customers;
    private readonly InMemoryRouteStore _routeStore;
    private readonly DateTimePicker _weekPicker = new();
    private readonly DataGridView _routeGrid = new();
    private readonly GroupBox _editorGroup = new();
    private readonly TextBox _routeNameBox = new();
    private readonly DateTimePicker _routeDatePicker = new();
    private readonly ListBox _availableCustomersList = new();
    private readonly ListBox _routeStopsList = new();
    private readonly Label _addressValue = new();
    private readonly Label _dockValue = new();
    private readonly Label _hoursValue = new();
    private readonly Label _statusLabel = new();
    private DeliveryRoute? _editingRoute;

    public RouteDeterminationControl(
        IReadOnlyList<RouteCustomer> customers,
        InMemoryRouteStore? routeStore = null)
    {
        ArgumentNullException.ThrowIfNull(customers);

        _customers = customers;
        _routeStore = routeStore ?? new InMemoryRouteStore();

        BuildInterface();
        RefreshAvailableCustomers();
        RefreshRouteGrid();
    }

    public event EventHandler? BackRequested;

    //
    // interface construction
    //

    private void BuildInterface()
    {
        Dock = DockStyle.Fill;
        BackColor = Color.WhiteSmoke;

        var rootLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(12)
        };
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

        rootLayout.Controls.Add(BuildHeader(), 0, 0);
        rootLayout.Controls.Add(BuildMainContent(), 0, 1);

        _statusLabel.Dock = DockStyle.Fill;
        _statusLabel.ForeColor = Color.DarkGreen;
        _statusLabel.TextAlign = ContentAlignment.MiddleLeft;
        rootLayout.Controls.Add(_statusLabel, 0, 2);

        Controls.Add(rootLayout);
    }

    private Control BuildHeader()
    {
        var header = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 1
        };
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165));
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105));

        var title = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            Text = "Route Determination",
            Anchor = AnchorStyles.Left
        };
        var weekLabel = new Label
        {
            AutoSize = true,
            Text = "Week of:",
            Anchor = AnchorStyles.Right
        };

        _weekPicker.Format = DateTimePickerFormat.Short;
        _weekPicker.Value = InMemoryRouteStore.GetWeekStart(DateTime.Today);
        _weekPicker.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _weekPicker.ValueChanged += (_, _) => RefreshRouteGrid();

        var backButton = CreateButton("Control Center", (_, _) => RequestBack());

        header.Controls.Add(title, 0, 0);
        header.Controls.Add(weekLabel, 1, 0);
        header.Controls.Add(_weekPicker, 2, 0);
        header.Controls.Add(backButton, 3, 0);
        return header;
    }

    private Control BuildMainContent()
    {
        // Give the split an initial size before min/distance constraints.
        // At construction time Width is still tiny, so setting Panel2MinSize
        // first throws: "SplitterDistance must be between Panel1MinSize and Width - Panel2MinSize."
        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            FixedPanel = FixedPanel.Panel1,
            Width = 1200,
            Height = 700
        };
        split.Panel1MinSize = 275;
        split.Panel2MinSize = 410;
        split.SplitterDistance = 330;

        split.Panel1.Controls.Add(BuildWeeklyRoutesPanel());
        split.Panel2.Controls.Add(BuildEditor());
        return split;
    }

    private Control BuildWeeklyRoutesPanel()
    {
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(0, 0, 8, 0)
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));

        layout.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            Text = "Weekly Routes",
            TextAlign = ContentAlignment.MiddleLeft
        }, 0, 0);

        ConfigureRouteGrid();
        layout.Controls.Add(_routeGrid, 0, 1);

        var actions = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight
        };
        actions.Controls.Add(CreateButton("Add", (_, _) => StartNewRoute()));
        actions.Controls.Add(CreateButton("Edit", (_, _) => EditSelectedRoute()));
        actions.Controls.Add(CreateButton("Delete", (_, _) => DeleteSelectedRoute()));
        layout.Controls.Add(actions, 0, 2);
        return layout;
    }

    private void ConfigureRouteGrid()
    {
        _routeGrid.Dock = DockStyle.Fill;
        _routeGrid.AllowUserToAddRows = false;
        _routeGrid.AllowUserToDeleteRows = false;
        _routeGrid.AllowUserToResizeRows = false;
        _routeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _routeGrid.BackgroundColor = Color.White;
        _routeGrid.MultiSelect = false;
        _routeGrid.ReadOnly = true;
        _routeGrid.RowHeadersVisible = false;
        _routeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _routeGrid.Columns.Add("RouteId", "Route ID");
        _routeGrid.Columns["RouteId"].Visible = false;
        _routeGrid.Columns.Add("Day", "Day");
        _routeGrid.Columns.Add("RouteName", "Route");
        _routeGrid.Columns.Add("Stops", "Stops");
        _routeGrid.Columns["Stops"].FillWeight = 45;
        _routeGrid.CellDoubleClick += (_, eventArgs) =>
        {
            if (eventArgs.RowIndex >= 0)
            {
                EditSelectedRoute();
            }
        };
    }

    private Control BuildEditor()
    {
        _editorGroup.Dock = DockStyle.Fill;
        _editorGroup.Enabled = false;
        _editorGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        _editorGroup.Text = "Daily Route";
        _editorGroup.Controls.Add(BuildEditorLayout());
        return _editorGroup;
    }

    private Control BuildEditorLayout()
    {
        var editorLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 5,
            Padding = new Padding(8)
        };
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44));
        editorLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 4));

        editorLayout.Controls.Add(BuildRouteFields(), 0, 0);
        editorLayout.Controls.Add(BuildStopLists(), 0, 1);
        editorLayout.Controls.Add(BuildCustomerDetails(), 0, 2);
        editorLayout.Controls.Add(BuildEditorActions(), 0, 3);
        return editorLayout;
    }

    private Control BuildRouteFields()
    {
        var fields = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 2
        };
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55));
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45));
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        fields.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));

        fields.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = "Name:",
            TextAlign = ContentAlignment.MiddleLeft
        }, 0, 0);

        _routeNameBox.Dock = DockStyle.Fill;
        fields.Controls.Add(_routeNameBox, 1, 0);
        fields.SetColumnSpan(_routeNameBox, 3);

        fields.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = "Date:",
            TextAlign = ContentAlignment.MiddleLeft
        }, 0, 1);

        _routeDatePicker.Dock = DockStyle.Fill;
        _routeDatePicker.Format = DateTimePickerFormat.Long;
        fields.Controls.Add(_routeDatePicker, 1, 1);
        fields.SetColumnSpan(_routeDatePicker, 3);
        return fields;
    }

    private Control BuildStopLists()
    {
        var lists = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 2
        };
        lists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        lists.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82));
        lists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        lists.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        lists.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        lists.Controls.Add(CreateSectionLabel("Available Customers"), 0, 0);
        lists.Controls.Add(CreateSectionLabel("Ordered Stops"), 2, 0);

        _availableCustomersList.Dock = DockStyle.Fill;
        _availableCustomersList.DisplayMember = nameof(RouteCustomer.Name);
        _availableCustomersList.SelectedIndexChanged += (_, _) =>
            ShowCustomerDetails(_availableCustomersList.SelectedItem as RouteCustomer);
        lists.Controls.Add(_availableCustomersList, 0, 1);

        var stopActions = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            Padding = new Padding(5, 8, 5, 0),
            WrapContents = false
        };
        stopActions.Controls.Add(CreateButton("Add >", (_, _) => AddSelectedCustomer(), 66));
        stopActions.Controls.Add(CreateButton("< Remove", (_, _) => RemoveSelectedStop(), 66));
        stopActions.Controls.Add(CreateButton("Move Up", (_, _) => MoveSelectedStop(-1), 66));
        stopActions.Controls.Add(CreateButton("Move Down", (_, _) => MoveSelectedStop(1), 66));
        lists.Controls.Add(stopActions, 1, 1);

        _routeStopsList.Dock = DockStyle.Fill;
        _routeStopsList.SelectedIndexChanged += (_, _) => ShowSelectedStopDetails();
        lists.Controls.Add(_routeStopsList, 2, 1);
        return lists;
    }

    private Control BuildCustomerDetails()
    {
        var details = new GroupBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Text = "Customer Delivery Details"
        };
        var fields = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 3,
            Padding = new Padding(6)
        };
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
        fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33));
        fields.RowStyles.Add(new RowStyle(SizeType.Percent, 34));
        fields.RowStyles.Add(new RowStyle(SizeType.Percent, 33));

        AddDetailRow(fields, "Address:", _addressValue, 0);
        AddDetailRow(fields, "Dock:", _dockValue, 1);
        AddDetailRow(fields, "Hours:", _hoursValue, 2);
        details.Controls.Add(fields);
        return details;
    }

    private Control BuildEditorActions()
    {
        var actions = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft
        };
        actions.Controls.Add(CreateButton("Save Route", (_, _) => SaveRoute(), 100));
        actions.Controls.Add(CreateButton("Cancel", (_, _) => CancelEdit(), 85));
        return actions;
    }

    //
    // Route editing actions
    //

    private void StartNewRoute()
    {
        DateTime selectedWeekStart = InMemoryRouteStore.GetWeekStart(_weekPicker.Value);
        _editingRoute = new DeliveryRoute(Guid.NewGuid(), string.Empty, selectedWeekStart);
        _routeNameBox.Clear();
        _routeDatePicker.Value = selectedWeekStart;
        _editorGroup.Text = "Add Daily Route";
        _editorGroup.Enabled = true;
        RefreshStopList();
        ClearCustomerDetails();
        _routeNameBox.Focus();
        SetStatus(string.Empty);
    }

    private void EditSelectedRoute()
    {
        DeliveryRoute? selectedRoute = GetSelectedRoute();
        if (selectedRoute is null)
        {
            ShowWarning("Select a route to edit.");
            return;
        }

        _editingRoute = selectedRoute.Copy();
        _routeNameBox.Text = _editingRoute.Name;
        _routeDatePicker.Value = _editingRoute.RouteDate;
        _editorGroup.Text = "Edit Daily Route";
        _editorGroup.Enabled = true;
        RefreshStopList();
        ClearCustomerDetails();
        SetStatus(string.Empty);
    }

    private void DeleteSelectedRoute()
    {
        DeliveryRoute? selectedRoute = GetSelectedRoute();
        if (selectedRoute is null)
        {
            ShowWarning("Select a route to delete.");
            return;
        }

        DialogResult result = MessageBox.Show(
            $"Delete \"{selectedRoute.Name}\" for {selectedRoute.RouteDate:d}?",
            "Delete Route",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result != DialogResult.Yes)
        {
            return;
        }

        _routeStore.Delete(selectedRoute.Id);
        if (_editingRoute?.Id == selectedRoute.Id)
        {
            CancelEdit();
        }

        RefreshRouteGrid();
        SetStatus("Route deleted.");
    }

    private void AddSelectedCustomer()
    {
        if (_editingRoute is null
            || _availableCustomersList.SelectedItem is not RouteCustomer customer)
        {
            ShowWarning("Select an available customer.");
            return;
        }

        if (!_editingRoute.AddStop(customer))
        {
            ShowWarning("That customer is already on this route.");
            return;
        }

        RefreshStopList();
        _routeStopsList.SelectedIndex = _routeStopsList.Items.Count - 1;
    }

    private void RemoveSelectedStop()
    {
        if (_editingRoute is null || _routeStopsList.SelectedIndex < 0)
        {
            ShowWarning("Select a route stop to remove.");
            return;
        }

        int selectedIndex = _routeStopsList.SelectedIndex;
        _editingRoute.RemoveStopAt(selectedIndex);
        RefreshStopList();

        if (_routeStopsList.Items.Count > 0)
        {
            _routeStopsList.SelectedIndex =
                Math.Min(selectedIndex, _routeStopsList.Items.Count - 1);
        }
        else
        {
            ClearCustomerDetails();
        }
    }

    private void MoveSelectedStop(int offset)
    {
        if (_editingRoute is null || _routeStopsList.SelectedIndex < 0)
        {
            ShowWarning("Select a route stop to move.");
            return;
        }

        int selectedIndex = _routeStopsList.SelectedIndex;
        if (!_editingRoute.MoveStop(selectedIndex, offset))
        {
            return;
        }

        RefreshStopList();
        _routeStopsList.SelectedIndex = selectedIndex + offset;
    }

    private void SaveRoute()
    {
        if (_editingRoute is null)
        {
            return;
        }

        DateTime weekStart = InMemoryRouteStore.GetWeekStart(_weekPicker.Value);
        DateTime routeDate = _routeDatePicker.Value.Date;
        if (routeDate < weekStart || routeDate >= weekStart.AddDays(7))
        {
            ShowWarning("Choose a route date within the displayed week.");
            return;
        }

        _editingRoute.Name = _routeNameBox.Text.Trim();
        _editingRoute.RouteDate = routeDate;

        try
        {
            _routeStore.Save(_editingRoute);
        }
        catch (ArgumentException exception)
        {
            ShowWarning(exception.Message);
            return;
        }

        string savedName = _editingRoute.Name;
        CancelEdit();
        RefreshRouteGrid();
        SetStatus($"Route \"{savedName}\" saved.");
    }

    private void CancelEdit()
    {
        _editingRoute = null;
        _editorGroup.Enabled = false;
        _editorGroup.Text = "Daily Route";
        _routeNameBox.Clear();
        _routeStopsList.Items.Clear();
        ClearCustomerDetails();
    }

    private void RequestBack()
    {
        if (_editingRoute is not null)
        {
            DialogResult result = MessageBox.Show(
                "Discard the unsaved route changes?",
                "Unsaved Route",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            CancelEdit();
        }

        // notify the parent form to return to the control center
        BackRequested?.Invoke(this, EventArgs.Empty);
    }

    //
    // Display and selection helpers
    //

    private void RefreshRouteGrid()
    {
        _routeGrid.Rows.Clear();
        foreach (DeliveryRoute route in _routeStore.GetRoutesForWeek(_weekPicker.Value))
        {
            _routeGrid.Rows.Add(
                route.Id,
                $"{route.RouteDate:ddd M/d}",
                route.Name,
                route.Stops.Count);
        }

        _routeGrid.ClearSelection();
    }

    private void RefreshAvailableCustomers()
    {
        _availableCustomersList.Items.Clear();
        foreach (RouteCustomer customer in _customers.OrderBy(customer => customer.Name))
        {
            _availableCustomersList.Items.Add(customer);
        }
    }

    private void RefreshStopList()
    {
        _routeStopsList.Items.Clear();
        if (_editingRoute is null)
        {
            return;
        }

        for (int index = 0; index < _editingRoute.Stops.Count; index++)
        {
            _routeStopsList.Items.Add(
                new RouteStopDisplay(index + 1, _editingRoute.Stops[index]));
        }
    }

    private DeliveryRoute? GetSelectedRoute()
    {
        if (_routeGrid.SelectedRows.Count == 0
            || _routeGrid.SelectedRows[0].Cells["RouteId"].Value is not Guid routeId)
        {
            return null;
        }

        return _routeStore
            .GetRoutesForWeek(_weekPicker.Value)
            .SingleOrDefault(route => route.Id == routeId);
    }

    private void ShowSelectedStopDetails()
    {
        RouteCustomer? customer =
            (_routeStopsList.SelectedItem as RouteStopDisplay)?.Customer;
        ShowCustomerDetails(customer);
    }

    private void ShowCustomerDetails(RouteCustomer? customer)
    {
        if (customer is null)
        {
            ClearCustomerDetails();
            return;
        }

        _addressValue.Text = customer.Address;
        _dockValue.Text = customer.LoadingDockCapabilities;
        _hoursValue.Text = customer.DeliveryHours;
    }

    private void ClearCustomerDetails()
    {
        _addressValue.Text = "—";
        _dockValue.Text = "—";
        _hoursValue.Text = "—";
    }

    private void SetStatus(string message)
    {
        _statusLabel.Text = message;
    }

    private static void ShowWarning(string message)
    {
        MessageBox.Show(
            message,
            "Route Determination",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private static Button CreateButton(
        string text,
        EventHandler clickHandler,
        int width = 90)
    {
        var button = new Button
        {
            AutoSize = false,
            Height = 32,
            Text = text,
            Width = width
        };
        button.Click += clickHandler;
        return button;
    }

    private static Label CreateSectionLabel(string text) => new()
    {
        Dock = DockStyle.Fill,
        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
        Text = text,
        TextAlign = ContentAlignment.MiddleLeft
    };

    private static void AddDetailRow(
        TableLayoutPanel fields,
        string labelText,
        Label valueLabel,
        int row)
    {
        fields.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = labelText,
            TextAlign = ContentAlignment.TopLeft
        }, 0, row);

        valueLabel.AutoEllipsis = true;
        valueLabel.Dock = DockStyle.Fill;
        valueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        valueLabel.TextAlign = ContentAlignment.TopLeft;
        fields.Controls.Add(valueLabel, 1, row);
    }

    private sealed record RouteStopDisplay(int Number, RouteCustomer Customer)
    {
        public override string ToString() => $"{Number}. {Customer.Name}";
    }
}
