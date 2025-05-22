namespace IdleSnitch;

public enum TrayIconState
{
    ActiveOn,
    ActiveOff,
    Snoozed,
    Outside,
    Disabled
}

public partial class Form1 : Form
{
    private TrayIconState currentTrayIconState;

    public Form1()
    {
        InitializeComponent();
        // Tray icon and icons are initialized in InitializeComponent
        currentTrayIconState = TrayIconState.ActiveOn;
    }

    public void SetTrayIconState(TrayIconState state)
    {
        if (currentTrayIconState == state) return;
        currentTrayIconState = state;
        string key = state switch
        {
            TrayIconState.ActiveOn => "active-on",
            TrayIconState.ActiveOff => "active-off",
            TrayIconState.Snoozed => "snoozed",
            TrayIconState.Outside => "outside",
            TrayIconState.Disabled => "disabled",
            _ => "active-on"
        };
        if (trayIcons.ContainsKey(key))
        {
            trayIcon.Icon = trayIcons[key];
        }
    }

    private void btnActiveOn_Click(object sender, EventArgs e)
    {
        SetTrayIconState(TrayIconState.ActiveOn);
    }
    private void btnActiveOff_Click(object sender, EventArgs e)
    {
        SetTrayIconState(TrayIconState.ActiveOff);
    }
    private void btnSnoozed_Click(object sender, EventArgs e)
    {
        SetTrayIconState(TrayIconState.Snoozed);
    }
    private void btnOutside_Click(object sender, EventArgs e)
    {
        SetTrayIconState(TrayIconState.Outside);
    }
    private void btnDisabled_Click(object sender, EventArgs e)
    {
        SetTrayIconState(TrayIconState.Disabled);
    }
}
