using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Timers;
using System.Media;

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

public class TeamworkConfig
{
    public string? ApiToken { get; set; }
    public string? BaseUrl { get; set; }
}

public class AppConfig
{
    public BusinessHoursConfig? BusinessHours { get; set; }
    public TeamworkConfig? Teamwork { get; set; }
}

public partial class Form1 : Form
{
    private TrayIconState currentTrayIconState;
    private AppConfig? config;
    private TeamworkApiClient? teamworkApiClient;
    private bool? lastTimerStatus = null;
    private System.Timers.Timer? pollTimer;
    private int pollIntervalSeconds = 10;
    private SoundPlayer? alertPlayer;
    private string? alertSoundPath;

    public Form1()
    {
        InitializeComponent();
        LoadConfig();
        // Tray icon and icons are initialized in InitializeComponent
        currentTrayIconState = TrayIconState.ActiveOn;
        InitializePolling();
    }

    private void InitializePolling()
    {
        pollTimer = new System.Timers.Timer(pollIntervalSeconds * 1000);
        pollTimer.Elapsed += async (s, e) => await PollTimerStatusAsync();
        pollTimer.AutoReset = true;
        pollTimer.Enabled = true;
    }

    private async Task PollTimerStatusAsync()
    {
        try
        {
            string statusMsg;
            if (!IsWithinBusinessHours())
            {
                SetTrayIconState(TrayIconState.Outside);
                statusMsg = "Status: Outside business hours.";
                MessageBox.Show(statusMsg, "IdleSnitch Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (config?.Teamwork != null)
            {
                // Debug: Show what values are being read from config
                MessageBox.Show($"ApiToken: '{config.Teamwork.ApiToken ?? "<null>"}'\nBaseUrl: '{config.Teamwork.BaseUrl ?? "<null>"}'", "Debug: Teamwork Config");
            }
            if (config?.Teamwork != null && !string.IsNullOrEmpty(config.Teamwork.ApiToken) && !string.IsNullOrEmpty(config.Teamwork.BaseUrl))
            {
                teamworkApiClient ??= new TeamworkApiClient(config.Teamwork.ApiToken, config.Teamwork.BaseUrl);
                bool isRunning = false;
                try
                {
                    isRunning = await teamworkApiClient.IsTimerRunningAsync();
                    lastTimerStatus = isRunning;
                }
                catch (Exception)
                {
                    if (lastTimerStatus.HasValue)
                        isRunning = lastTimerStatus.Value;
                    else
                        throw;
                }
                SetTrayIconState(isRunning ? TrayIconState.ActiveOn : TrayIconState.ActiveOff);
                statusMsg = isRunning ? "Status: Timer is running (ActiveOn)." : "Status: Timer is NOT running (ActiveOff).";
                MessageBox.Show(statusMsg, "IdleSnitch Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SetTrayIconState(TrayIconState.Disabled);
                statusMsg = "Status: Teamwork API not configured (Disabled).";
                MessageBox.Show(statusMsg, "IdleSnitch Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception)
        {
            // Optionally log or show error
        }
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

        // DEBUG: Log config file path and contents
        var debugConfigPath = configPath;
        var debugConfigJson = File.Exists(debugConfigPath) ? File.ReadAllText(debugConfigPath) : "<not found>";
        MessageBox.Show($"Config path: {debugConfigPath}\nConfig contents:\n{debugConfigJson}", "DEBUG: Config File");
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
    protected override async void OnShown(EventArgs e)
    {
        base.OnShown(e);
        await PollTimerStatusAsync();
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
