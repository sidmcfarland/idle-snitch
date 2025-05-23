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
        // Set default icon
        this.trayIcon.Icon = trayIcons["active-on"];
        this.trayIcon.Visible = true;
        this.trayIcon.ContextMenuStrip = this.trayMenu;
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Icon = new System.Drawing.Icon("assets/icon-active-on.ico");
        this.Text = "Form1";
    }

    #endregion
}
