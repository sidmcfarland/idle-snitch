namespace IdleSnitch;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.NotifyIcon trayIcon;
    private System.Collections.Generic.Dictionary<string, System.Drawing.Icon> trayIcons;

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
        // Load icons from assets
        trayIcons["active-on"] = new System.Drawing.Icon("assets/icon-active-on.ico");
        trayIcons["active-off"] = System.Drawing.Icon.ExtractAssociatedIcon("assets/icon-active-off.png"); // PNG fallback
        trayIcons["snoozed"] = new System.Drawing.Icon("assets/icon-snoozed.ico");
        trayIcons["outside"] = new System.Drawing.Icon("assets/icon-outside.ico");
        trayIcons["disabled"] = new System.Drawing.Icon("assets/icon-disabled.ico");
        // Set default icon
        this.trayIcon.Icon = trayIcons["active-on"];
        this.trayIcon.Visible = true;
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(typeof(Form1)).GetObject("AppIcon")));
        this.Text = "Form1";
    }

    #endregion
}
