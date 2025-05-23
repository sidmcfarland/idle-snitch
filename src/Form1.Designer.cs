namespace IdleSnitch;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.NotifyIcon trayIcon;
    private System.Collections.Generic.Dictionary<string, System.Drawing.Icon> trayIcons;
    private System.Windows.Forms.ContextMenuStrip trayMenu;
    private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    private System.Windows.Forms.Label labelAudioAlert;
    private System.Windows.Forms.ComboBox comboBoxAudioAlert;
    private System.Windows.Forms.TabControl tabControlSettings;
    private System.Windows.Forms.TabPage tabPageGeneral;
    private System.Windows.Forms.TabPage tabPageLog;
    private System.Windows.Forms.TextBox textBoxLog;
    private System.Windows.Forms.CheckBox checkBoxBusinessHoursEnabled;
    private System.Windows.Forms.CheckedListBox checkedListBoxDaysOfWeek;
    private System.Windows.Forms.Label labelStartTime;
    private System.Windows.Forms.Label labelEndTime;
    private System.Windows.Forms.TextBox textBoxStartTime;
    private System.Windows.Forms.TextBox textBoxEndTime;
    private System.Windows.Forms.Label labelApiToken;
    private System.Windows.Forms.TextBox textBoxApiToken;
    private System.Windows.Forms.Label labelBaseUrl;
    private System.Windows.Forms.TextBox textBoxBaseUrl;
    private System.Windows.Forms.Button buttonSaveSettings;
    private System.Windows.Forms.Button buttonCancelSettings;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneral;
    private System.Windows.Forms.GroupBox groupBoxBusinessHours;
    private System.Windows.Forms.GroupBox groupBoxTeamwork;
    private System.Windows.Forms.Label labelAlertInterval;
    private System.Windows.Forms.TextBox textBoxAlertInterval;

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
        this.components = new System.ComponentModel.Container();
        this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
        this.trayIcons = new System.Collections.Generic.Dictionary<string, System.Drawing.Icon>();
        this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.labelAudioAlert = new System.Windows.Forms.Label();
        this.comboBoxAudioAlert = new System.Windows.Forms.ComboBox();
        this.tabControlSettings = new System.Windows.Forms.TabControl();
        this.tabPageGeneral = new System.Windows.Forms.TabPage();
        this.tabPageLog = new System.Windows.Forms.TabPage();
        this.textBoxLog = new System.Windows.Forms.TextBox();
        this.checkBoxBusinessHoursEnabled = new System.Windows.Forms.CheckBox();
        this.checkedListBoxDaysOfWeek = new System.Windows.Forms.CheckedListBox();
        this.labelStartTime = new System.Windows.Forms.Label();
        this.labelEndTime = new System.Windows.Forms.Label();
        this.textBoxStartTime = new System.Windows.Forms.TextBox();
        this.textBoxEndTime = new System.Windows.Forms.TextBox();
        this.labelApiToken = new System.Windows.Forms.Label();
        this.textBoxApiToken = new System.Windows.Forms.TextBox();
        this.labelBaseUrl = new System.Windows.Forms.Label();
        this.textBoxBaseUrl = new System.Windows.Forms.TextBox();
        this.buttonSaveSettings = new System.Windows.Forms.Button();
        this.buttonCancelSettings = new System.Windows.Forms.Button();
        this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
        this.groupBoxBusinessHours = new System.Windows.Forms.GroupBox();
        this.groupBoxTeamwork = new System.Windows.Forms.GroupBox();
        this.labelAlertInterval = new System.Windows.Forms.Label();
        this.textBoxAlertInterval = new System.Windows.Forms.TextBox();
        // Load icons from assets
        trayIcons["active-on"] = new System.Drawing.Icon("assets/icon-active-on.ico");
        trayIcons["active-off"] = System.Drawing.Icon.ExtractAssociatedIcon("assets/icon-active-off.ico"); // PNG fallback
        trayIcons["snoozed"] = new System.Drawing.Icon("assets/icon-snoozed.ico");
        trayIcons["outside"] = new System.Drawing.Icon("assets/icon-outside.ico");
        trayIcons["disabled"] = new System.Drawing.Icon("assets/icon-disabled.ico");
        // 
        // trayMenu
        // 
        this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.exitMenuItem});
        // 
        // settingsMenuItem
        // 
        this.settingsMenuItem.Name = "settingsMenuItem";
        this.settingsMenuItem.Size = new System.Drawing.Size(116, 22);
        this.settingsMenuItem.Text = "Settings";
        this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
        // 
        // exitMenuItem
        // 
        this.exitMenuItem.Name = "exitMenuItem";
        this.exitMenuItem.Size = new System.Drawing.Size(116, 22);
        this.exitMenuItem.Text = "Exit";
        this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
        // 
        // labelAudioAlert
        // 
        this.labelAudioAlert.AutoSize = true;
        this.labelAudioAlert.Location = new System.Drawing.Point(30, 30);
        this.labelAudioAlert.Name = "labelAudioAlert";
        this.labelAudioAlert.Size = new System.Drawing.Size(120, 15);
        this.labelAudioAlert.TabIndex = 0;
        this.labelAudioAlert.Text = "Audio Notification:";
        // 
        // comboBoxAudioAlert
        // 
        this.comboBoxAudioAlert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBoxAudioAlert.FormattingEnabled = true;
        this.comboBoxAudioAlert.Location = new System.Drawing.Point(160, 27);
        this.comboBoxAudioAlert.Name = "comboBoxAudioAlert";
        this.comboBoxAudioAlert.Size = new System.Drawing.Size(250, 23);
        this.comboBoxAudioAlert.TabIndex = 1;
        // 
        // tabControlSettings
        // 
        this.tabControlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControlSettings.Name = "tabControlSettings";
        this.tabControlSettings.TabIndex = 0;
        this.tabControlSettings.Controls.Add(this.tabPageGeneral);
        this.tabControlSettings.Controls.Add(this.tabPageLog);
        // 
        // tabPageGeneral
        // 
        this.tabPageGeneral.Name = "tabPageGeneral";
        this.tabPageGeneral.Text = "General";
        this.tabPageGeneral.UseVisualStyleBackColor = true;
        // 
        // tabPageLog
        // 
        this.tabPageLog.Name = "tabPageLog";
        this.tabPageLog.Text = "Log";
        this.tabPageLog.UseVisualStyleBackColor = true;
        // 
        // textBoxLog
        // 
        this.textBoxLog.Multiline = true;
        this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBoxLog.ReadOnly = true;
        this.textBoxLog.Font = new System.Drawing.Font("Consolas", 10F);
        this.tabPageLog.Controls.Add(this.textBoxLog);
        // Add tabControlSettings to the form
        this.Controls.Add(this.tabControlSettings);
        // Set default icon
        this.trayIcon.Icon = trayIcons["active-on"];
        this.trayIcon.Visible = true;
        this.trayIcon.ContextMenuStrip = this.trayMenu;
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Icon = new System.Drawing.Icon("assets/icon-active-on.ico");
        this.Text = "Form1";
        // Main TableLayoutPanel for General tab
        this.tableLayoutPanelGeneral = new System.Windows.Forms.TableLayoutPanel();
        this.tableLayoutPanelGeneral.ColumnCount = 1;
        this.tableLayoutPanelGeneral.RowCount = 5;
        this.tableLayoutPanelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanelGeneral.AutoSize = true;
        this.tableLayoutPanelGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.tableLayoutPanelGeneral.Padding = new System.Windows.Forms.Padding(16);
        this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        this.tableLayoutPanelGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

        // --- Business Hours Group ---
        this.groupBoxBusinessHours = new System.Windows.Forms.GroupBox();
        this.groupBoxBusinessHours.Text = "Business Hours";
        this.groupBoxBusinessHours.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBoxBusinessHours.AutoSize = true;
        this.groupBoxBusinessHours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.groupBoxBusinessHours.Padding = new System.Windows.Forms.Padding(12);

        var tableBusiness = new System.Windows.Forms.TableLayoutPanel();
        tableBusiness.ColumnCount = 3;
        tableBusiness.RowCount = 4;
        tableBusiness.Dock = System.Windows.Forms.DockStyle.Fill;
        tableBusiness.AutoSize = true;
        tableBusiness.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tableBusiness.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        tableBusiness.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        tableBusiness.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableBusiness.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        tableBusiness.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        tableBusiness.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        tableBusiness.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

        this.checkBoxBusinessHoursEnabled = new System.Windows.Forms.CheckBox();
        this.checkBoxBusinessHoursEnabled.Text = "Enable Business Hours";
        this.checkBoxBusinessHoursEnabled.AutoSize = true;
        tableBusiness.SetColumnSpan(this.checkBoxBusinessHoursEnabled, 3);
        tableBusiness.Controls.Add(this.checkBoxBusinessHoursEnabled, 0, 0);

        this.checkedListBoxDaysOfWeek = new System.Windows.Forms.CheckedListBox();
        this.checkedListBoxDaysOfWeek.Items.AddRange(new object[] {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        });
        this.checkedListBoxDaysOfWeek.CheckOnClick = true;
        this.checkedListBoxDaysOfWeek.Height = 120;
        this.checkedListBoxDaysOfWeek.Width = 140;
        this.checkedListBoxDaysOfWeek.Dock = System.Windows.Forms.DockStyle.Top;
        tableBusiness.Controls.Add(this.checkedListBoxDaysOfWeek, 0, 1);
        tableBusiness.SetRowSpan(this.checkedListBoxDaysOfWeek, 3);

        this.labelStartTime = new System.Windows.Forms.Label();
        this.labelStartTime.Text = "Start Time (HH:mm):";
        this.labelStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.labelStartTime.AutoSize = true;
        tableBusiness.Controls.Add(this.labelStartTime, 1, 1);

        this.textBoxStartTime = new System.Windows.Forms.TextBox();
        this.textBoxStartTime.Width = 80;
        tableBusiness.Controls.Add(this.textBoxStartTime, 2, 1);

        this.labelEndTime = new System.Windows.Forms.Label();
        this.labelEndTime.Text = "End Time (HH:mm):";
        this.labelEndTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.labelEndTime.AutoSize = true;
        tableBusiness.Controls.Add(this.labelEndTime, 1, 2);

        this.textBoxEndTime = new System.Windows.Forms.TextBox();
        this.textBoxEndTime.Width = 80;
        tableBusiness.Controls.Add(this.textBoxEndTime, 2, 2);

        this.groupBoxBusinessHours.Controls.Clear();
        this.groupBoxBusinessHours.Controls.Add(tableBusiness);

        // --- Teamwork API Group ---
        this.groupBoxTeamwork = new System.Windows.Forms.GroupBox();
        this.groupBoxTeamwork.Text = "Teamwork API";
        this.groupBoxTeamwork.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBoxTeamwork.AutoSize = true;
        this.groupBoxTeamwork.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.groupBoxTeamwork.Padding = new System.Windows.Forms.Padding(12);

        var tableTeamwork = new System.Windows.Forms.TableLayoutPanel();
        tableTeamwork.ColumnCount = 2;
        tableTeamwork.RowCount = 2;
        tableTeamwork.Dock = System.Windows.Forms.DockStyle.Fill;
        tableTeamwork.AutoSize = true;
        tableTeamwork.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tableTeamwork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        tableTeamwork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableTeamwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
        tableTeamwork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));

        this.labelApiToken = new System.Windows.Forms.Label();
        this.labelApiToken.Text = "API Token:";
        this.labelApiToken.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.labelApiToken.AutoSize = true;
        tableTeamwork.Controls.Add(this.labelApiToken, 0, 0);

        this.textBoxApiToken = new System.Windows.Forms.TextBox();
        this.textBoxApiToken.Dock = System.Windows.Forms.DockStyle.Fill;
        tableTeamwork.Controls.Add(this.textBoxApiToken, 1, 0);

        this.labelBaseUrl = new System.Windows.Forms.Label();
        this.labelBaseUrl.Text = "Base URL:";
        this.labelBaseUrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.labelBaseUrl.AutoSize = true;
        tableTeamwork.Controls.Add(this.labelBaseUrl, 0, 1);

        this.textBoxBaseUrl = new System.Windows.Forms.TextBox();
        this.textBoxBaseUrl.Dock = System.Windows.Forms.DockStyle.Fill;
        tableTeamwork.Controls.Add(this.textBoxBaseUrl, 1, 1);

        this.groupBoxTeamwork.Controls.Clear();
        this.groupBoxTeamwork.Controls.Add(tableTeamwork);

        // --- Audio Alert Row ---
        var tableAudio = new System.Windows.Forms.TableLayoutPanel();
        tableAudio.ColumnCount = 2;
        tableAudio.RowCount = 1;
        tableAudio.Dock = System.Windows.Forms.DockStyle.Top;
        tableAudio.AutoSize = true;
        tableAudio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tableAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        tableAudio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

        this.labelAudioAlert = new System.Windows.Forms.Label();
        this.labelAudioAlert.Text = "Audio Notification:";
        this.labelAudioAlert.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.labelAudioAlert.AutoSize = true;
        tableAudio.Controls.Add(this.labelAudioAlert, 0, 0);

        this.comboBoxAudioAlert = new System.Windows.Forms.ComboBox();
        this.comboBoxAudioAlert.Dock = System.Windows.Forms.DockStyle.Fill;
        tableAudio.Controls.Add(this.comboBoxAudioAlert, 1, 0);

        // --- Alert Interval Row ---
        var tableAlertInterval = new System.Windows.Forms.TableLayoutPanel();
        tableAlertInterval.ColumnCount = 2;
        tableAlertInterval.RowCount = 1;
        tableAlertInterval.Dock = System.Windows.Forms.DockStyle.Top;
        tableAlertInterval.AutoSize = true;
        tableAlertInterval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tableAlertInterval.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        tableAlertInterval.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.labelAlertInterval.Text = "Alert Interval (seconds):";
        this.labelAlertInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.labelAlertInterval.AutoSize = true;
        tableAlertInterval.Controls.Add(this.labelAlertInterval, 0, 0);
        this.textBoxAlertInterval.Width = 80;
        this.textBoxAlertInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
        tableAlertInterval.Controls.Add(this.textBoxAlertInterval, 1, 0);

        // --- Buttons Row ---
        var tableButtons = new System.Windows.Forms.TableLayoutPanel();
        tableButtons.ColumnCount = 2;
        tableButtons.RowCount = 1;
        tableButtons.Dock = System.Windows.Forms.DockStyle.Right;
        tableButtons.AutoSize = true;
        tableButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
        tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));

        this.buttonSaveSettings = new System.Windows.Forms.Button();
        this.buttonSaveSettings.Text = "Save";
        this.buttonSaveSettings.AutoSize = true;
        tableButtons.Controls.Add(this.buttonSaveSettings, 0, 0);

        this.buttonCancelSettings = new System.Windows.Forms.Button();
        this.buttonCancelSettings.Text = "Cancel";
        this.buttonCancelSettings.AutoSize = true;
        tableButtons.Controls.Add(this.buttonCancelSettings, 1, 0);

        // --- Add all to main TableLayoutPanel ---
        this.tableLayoutPanelGeneral.Controls.Clear();
        this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxBusinessHours, 0, 0);
        this.tableLayoutPanelGeneral.Controls.Add(this.groupBoxTeamwork, 0, 1);
        this.tableLayoutPanelGeneral.Controls.Add(tableAudio, 0, 2);
        this.tableLayoutPanelGeneral.Controls.Add(tableAlertInterval, 0, 3);
        this.tableLayoutPanelGeneral.Controls.Add(tableButtons, 0, 4);

        // --- Add TableLayoutPanel to General tab ---
        this.tabPageGeneral.Controls.Clear();
        this.tabPageGeneral.Controls.Add(this.tableLayoutPanelGeneral);

        // Set minimum size for the form to fit all controls
        this.MinimumSize = new System.Drawing.Size(600, 600);
        this.ClientSize = new System.Drawing.Size(700, 700);
    }

    #endregion
}
