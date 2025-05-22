namespace IdleSnitch;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.NotifyIcon trayIcon;
    private System.Collections.Generic.Dictionary<string, System.Drawing.Icon> trayIcons;
    private System.Windows.Forms.Panel debugPanel;
    private System.Windows.Forms.Button btnActiveOn;
    private System.Windows.Forms.Button btnActiveOff;
    private System.Windows.Forms.Button btnSnoozed;
    private System.Windows.Forms.Button btnOutside;
    private System.Windows.Forms.Button btnDisabled;

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
        this.debugPanel = new System.Windows.Forms.Panel();
        this.btnActiveOn = new System.Windows.Forms.Button();
        this.btnActiveOff = new System.Windows.Forms.Button();
        this.btnSnoozed = new System.Windows.Forms.Button();
        this.btnOutside = new System.Windows.Forms.Button();
        this.btnDisabled = new System.Windows.Forms.Button();
        // Load icons from assets
        trayIcons["active-on"] = new System.Drawing.Icon("assets/icon-active-on.ico");
        trayIcons["active-off"] = System.Drawing.Icon.ExtractAssociatedIcon("assets/icon-active-off.ico"); // PNG fallback
        trayIcons["snoozed"] = new System.Drawing.Icon("assets/icon-snoozed.ico");
        trayIcons["outside"] = new System.Drawing.Icon("assets/icon-outside.ico");
        trayIcons["disabled"] = new System.Drawing.Icon("assets/icon-disabled.ico");
        // Set default icon
        this.trayIcon.Icon = trayIcons["active-on"];
        this.trayIcon.Visible = true;
        // 
        // debugPanel
        // 
        this.debugPanel.Controls.Add(this.btnActiveOn);
        this.debugPanel.Controls.Add(this.btnActiveOff);
        this.debugPanel.Controls.Add(this.btnSnoozed);
        this.debugPanel.Controls.Add(this.btnOutside);
        this.debugPanel.Controls.Add(this.btnDisabled);
        this.debugPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.debugPanel.Height = 40;
        // 
        // btnActiveOn
        // 
        this.btnActiveOn.Text = "Active On";
        this.btnActiveOn.Left = 10;
        this.btnActiveOn.Top = 8;
        this.btnActiveOn.Width = 90;
        this.btnActiveOn.Click += new System.EventHandler(this.btnActiveOn_Click);
        // 
        // btnActiveOff
        // 
        this.btnActiveOff.Text = "Active Off";
        this.btnActiveOff.Left = 110;
        this.btnActiveOff.Top = 8;
        this.btnActiveOff.Width = 90;
        this.btnActiveOff.Click += new System.EventHandler(this.btnActiveOff_Click);
        // 
        // btnSnoozed
        // 
        this.btnSnoozed.Text = "Snoozed";
        this.btnSnoozed.Left = 210;
        this.btnSnoozed.Top = 8;
        this.btnSnoozed.Width = 90;
        this.btnSnoozed.Click += new System.EventHandler(this.btnSnoozed_Click);
        // 
        // btnOutside
        // 
        this.btnOutside.Text = "Outside";
        this.btnOutside.Left = 310;
        this.btnOutside.Top = 8;
        this.btnOutside.Width = 90;
        this.btnOutside.Click += new System.EventHandler(this.btnOutside_Click);
        // 
        // btnDisabled
        // 
        this.btnDisabled.Text = "Disabled";
        this.btnDisabled.Left = 410;
        this.btnDisabled.Top = 8;
        this.btnDisabled.Width = 90;
        this.btnDisabled.Click += new System.EventHandler(this.btnDisabled_Click);
        // 
        // Add debugPanel to Form
        // 
        this.Controls.Add(this.debugPanel);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Icon = new System.Drawing.Icon("assets/icon-active-on.ico");
        this.Text = "Form1";
    }

    #endregion
}
