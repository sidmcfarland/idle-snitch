using System.IO;
using Newtonsoft.Json;

namespace IdleSnitch;

public enum TrayIconState
{
    ActiveOn,
    ActiveOff,
    Snoozed,
    Outside,
    Disabled
}

public class BusinessHoursConfig
{
    public bool Enabled { get; set; }
    public List<string>? DaysOfWeek { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
}

public class AppConfig
{
    public BusinessHoursConfig? BusinessHours { get; set; }
}

public partial class Form1 : Form
{
    private TrayIconState currentTrayIconState;
    private AppConfig? config;

    public Form1()
    {
        InitializeComponent();
        LoadConfig();
        // Tray icon and icons are initialized in InitializeComponent
        currentTrayIconState = TrayIconState.ActiveOn;
    }

    private void LoadConfig()
    {
        // Copy config/appsettings.json to output directory if not present
        var sourceConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "config", "appsettings.json");
        var destConfigDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config");
        var destConfigPath = Path.Combine(destConfigDir, "appsettings.json");
        if (!Directory.Exists(destConfigDir))
            Directory.CreateDirectory(destConfigDir);
        if (!File.Exists(destConfigPath) && File.Exists(sourceConfigPath))
            File.Copy(sourceConfigPath, destConfigPath, true);

        var configPath = destConfigPath;
        if (File.Exists(configPath))
        {
            var json = File.ReadAllText(configPath);
            config = JsonConvert.DeserializeObject<AppConfig>(json);
        }
    }

    // Returns true if the current time is within configured business hours
    public bool IsWithinBusinessHours()
    {
        if (config?.BusinessHours == null || !config.BusinessHours.Enabled)
            return false;

        var now = DateTime.Now;
        var today = now.DayOfWeek.ToString();
        if (config.BusinessHours.DaysOfWeek == null ||
            !config.BusinessHours.DaysOfWeek.Any(d => string.Equals(d, today, StringComparison.OrdinalIgnoreCase)))
            return false;

        if (!TimeSpan.TryParse(config.BusinessHours.StartTime, out var start))
            return false;
        if (!TimeSpan.TryParse(config.BusinessHours.EndTime, out var end))
            return false;

        var current = now.TimeOfDay;
        return current >= start && current <= end;
    }

    // Example: update tray icon state based on business hours at startup
    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        try
        {
            if (!IsWithinBusinessHours())
            {
                SetTrayIconState(TrayIconState.Outside);
            }
            else
            {
                // TODO: Integrate with Teamwork API to check timer status
                // For now, default to ActiveOn (on the clock) for demo purposes
                SetTrayIconState(TrayIconState.ActiveOn);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error in business hours logic: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
        if (trayIcons.ContainsKey(key) && trayIcons[key] != null)
        {
            trayIcon.Icon = trayIcons[key];
            trayIcon.Visible = true;
            this.Icon = trayIcons[key]; // Update the form's icon as well
        }
        else
        {
            // Show a message if the icon is missing
            MessageBox.Show($"Tray icon asset missing or failed to load: {key}", "Tray Icon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
