using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Timers;
using System.Media;
using System.Linq;
using System.Diagnostics;

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
    public string? AudioAlertFile { get; set; }
    public int? AlertIntervalSeconds { get; set; } // New property
}

public partial class Form1 : Form
{
    private TrayIconState currentTrayIconState;
    private AppConfig? config;
    private TeamworkApiClient? teamworkApiClient;
    private bool? lastTimerStatus = null;
    private System.Timers.Timer? pollTimer;
    private int pollIntervalSeconds = 10;
    private int alertIntervalSeconds = 60; // Default value
    private string selectedAudioAlert = "Windows Message Nudge.wav";
    private string tempSelectedAudioAlert = "";
    private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IdleSnitch.log");

    public Form1()
    {
        InitializeComponent();
        // Restore minimize and maximize box functionality
        this.MaximizeBox = true;
        this.MinimizeBox = true;
        Log("Application started");
        LoadConfig();
        // Tray icon and icons are initialized in InitializeComponent
        currentTrayIconState = TrayIconState.ActiveOn;
        InitializePolling();
        InitializeAudioAlertComboBox();
        this.WindowState = FormWindowState.Minimized;
        this.ShowInTaskbar = false;
        this.Hide();
        tabControlSettings.SelectedIndexChanged += tabControlSettings_SelectedIndexChanged;
        buttonSaveSettings.Click += ButtonSaveSettings_Click;
        buttonCancelSettings.Click += ButtonCancelSettings_Click;
        LoadSettingsToUI();
        tempSelectedAudioAlert = selectedAudioAlert;
        comboBoxAudioAlert.SelectedIndexChanged -= ComboBoxAudioAlert_SelectedIndexChanged;
        comboBoxAudioAlert.SelectedIndexChanged += ComboBoxAudioAlert_SelectedIndexChanged;
        alertIntervalSeconds = config?.AlertIntervalSeconds ?? 60;
        pollIntervalSeconds = alertIntervalSeconds;
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
            if (!IsWithinBusinessHours())
            {
                SetTrayIconState(TrayIconState.Outside);
                return;
            }
            if (config?.Teamwork != null)
            {
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
                // Play nudge alert if not on the clock (ActiveOff) and at least 60 seconds since last alert
                if (!isRunning)
                {
                    PlayNudgeAlert();
                }
            }
            else
            {
                SetTrayIconState(TrayIconState.Disabled);
            }
        }
        catch (Exception)
        {
            // Optionally log or show error
        }
    }

    private void PlayNudgeAlert()
    {
        try
        {
            string mediaDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Media");
            string selectedPath = Path.Combine(mediaDir, selectedAudioAlert);
            if (File.Exists(selectedPath))
            {
                using var player = new SoundPlayer(selectedPath);
                player.Play();
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }
        catch { /* Optionally log or ignore errors */ }
    }

    private void InitializeAudioAlertComboBox()
    {
        string mediaDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Media");
        var available = Directory.GetFiles(mediaDir, "*.wav")
            .Select(Path.GetFileName)
            .OrderBy(f => f)
            .ToList();
        comboBoxAudioAlert.Items.Clear();
        foreach (var sound in available)
            if (!string.IsNullOrEmpty(sound))
                comboBoxAudioAlert.Items.Add(sound);
        // Ensure selectedAudioAlert is set to config value if available
        if (config != null && !string.IsNullOrEmpty(config.AudioAlertFile))
            selectedAudioAlert = config.AudioAlertFile;
        tempSelectedAudioAlert = selectedAudioAlert;
        // Set ComboBox selection
        if (available.Contains(tempSelectedAudioAlert))
            comboBoxAudioAlert.SelectedItem = tempSelectedAudioAlert;
        else if (available.Count > 0)
            comboBoxAudioAlert.SelectedIndex = 0;
    }

    private void ComboBoxAudioAlert_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboBoxAudioAlert.SelectedItem is string selected)
        {
            tempSelectedAudioAlert = selected;
            // Play the selected sound immediately for preview
            try
            {
                string mediaDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Media");
                string selectedPath = Path.Combine(mediaDir, tempSelectedAudioAlert);
                if (File.Exists(selectedPath))
                {
                    using var player = new SoundPlayer(selectedPath);
                    player.Play();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                }
            }
            catch { /* Optionally log or ignore errors */ }
        }
    }

    private void LoadConfig()
    {
        var sourceConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "config", "appsettings.json");
        var destConfigDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config");
        var destConfigPath = Path.Combine(destConfigDir, "appsettings.json");
        if (!Directory.Exists(destConfigDir))
            Directory.CreateDirectory(destConfigDir);
        // Only copy the default config if the destination does not exist
        if (!File.Exists(destConfigPath) && File.Exists(sourceConfigPath))
        {
            File.Copy(sourceConfigPath, destConfigPath, true);
            Log($"Copied default settings file from '{sourceConfigPath}' to '{destConfigPath}'");
        }
        var configPath = destConfigPath;
        if (File.Exists(configPath))
        {
            var json = File.ReadAllText(configPath);
            Log($"Read settings file at '{configPath}'");
            config = JsonConvert.DeserializeObject<AppConfig>(json);
            if (config != null)
            {
                // Log each setting value
                if (config.BusinessHours != null)
                {
                    Log($"BusinessHours.Enabled = {config.BusinessHours.Enabled}");
                    Log($"BusinessHours.DaysOfWeek = [{string.Join(", ", config.BusinessHours.DaysOfWeek ?? new List<string>())}]");
                    Log($"BusinessHours.StartTime = {config.BusinessHours.StartTime}");
                    Log($"BusinessHours.EndTime = {config.BusinessHours.EndTime}");
                }
                if (config.Teamwork != null)
                {
                    Log($"Teamwork.ApiToken = {config.Teamwork.ApiToken}");
                    Log($"Teamwork.BaseUrl = {config.Teamwork.BaseUrl}");
                }
                Log($"AudioAlertFile = {config.AudioAlertFile}");
                if (config.AlertIntervalSeconds.HasValue)
                    alertIntervalSeconds = config.AlertIntervalSeconds.Value;
                else
                    alertIntervalSeconds = 60;
                pollIntervalSeconds = alertIntervalSeconds;
            }
            if (config != null && !string.IsNullOrEmpty(config.AudioAlertFile))
            {
                selectedAudioAlert = config.AudioAlertFile;
                Log($"Loaded audio alert from settings: {selectedAudioAlert}");
            }
        }
    }

    private void SaveConfig()
    {
        if (config == null)
            config = new AppConfig();
        string oldAudioAlert = config.AudioAlertFile ?? "(none)";
        config.AudioAlertFile = selectedAudioAlert;
        var destConfigDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config");
        var destConfigPath = Path.Combine(destConfigDir, "appsettings.json");
        var json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(destConfigPath, json);
        if (oldAudioAlert != selectedAudioAlert)
        {
            Log($"Updated settings file at '{destConfigPath}': AudioAlertFile changed from '{oldAudioAlert}' to '{selectedAudioAlert}'");
        }
        else
        {
            Log($"Settings file at '{destConfigPath}' updated (no change to AudioAlertFile)");
        }
    }

    private void Log(string message)
    {
        try
        {
            File.AppendAllText(logFilePath, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}");
        }
        catch { /* Optionally handle logging errors */ }
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
    }

    // Event handler for Settings menu item
    private void settingsMenuItem_Click(object? sender, EventArgs e)
    {
        this.Show();
        this.WindowState = FormWindowState.Normal;
        this.ShowInTaskbar = false;
        this.BringToFront();
    }

    // Event handler for Exit menu item
    private void exitMenuItem_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.ApplicationExitCall)
        {
            e.Cancel = true;
            this.Hide();
        }
        else
        {
            Log("Application stopped");
            base.OnFormClosing(e);
        }
    }

    private void tabControlSettings_SelectedIndexChanged(object? sender, EventArgs e)
    {
        // If the Log tab is selected, load the log file contents
        if (tabControlSettings.SelectedTab == tabPageLog)
        {
            try
            {
                if (File.Exists(logFilePath))
                    textBoxLog.Text = File.ReadAllText(logFilePath);
                else
                    textBoxLog.Text = "(Log file not found)";
            }
            catch (Exception ex)
            {
                textBoxLog.Text = $"Error reading log file: {ex.Message}";
            }
        }
    }

    private void LoadSettingsToUI()
    {
        if (config?.BusinessHours != null)
        {
            checkBoxBusinessHoursEnabled.Checked = config.BusinessHours.Enabled;
            checkedListBoxDaysOfWeek.ClearSelected();
            for (int i = 0; i < checkedListBoxDaysOfWeek.Items.Count; i++)
            {
                var itemObj = checkedListBoxDaysOfWeek.Items[i];
                string? day = itemObj?.ToString();
                bool isChecked = false;
                if (!string.IsNullOrEmpty(day) && config.BusinessHours.DaysOfWeek != null)
                    isChecked = config.BusinessHours.DaysOfWeek.Contains(day);
                checkedListBoxDaysOfWeek.SetItemChecked(i, isChecked);
            }
            textBoxStartTime.Text = config.BusinessHours.StartTime ?? "";
            textBoxEndTime.Text = config.BusinessHours.EndTime ?? "";
        }
        if (config?.Teamwork != null)
        {
            textBoxApiToken.Text = config.Teamwork.ApiToken ?? "";
            textBoxBaseUrl.Text = config.Teamwork.BaseUrl ?? "";
        }
        // Audio alert
        if (config != null && !string.IsNullOrEmpty(config.AudioAlertFile))
            tempSelectedAudioAlert = config.AudioAlertFile;
        else
            tempSelectedAudioAlert = "Windows Message Nudge.wav";
        if (comboBoxAudioAlert.Items.Contains(tempSelectedAudioAlert))
            comboBoxAudioAlert.SelectedItem = tempSelectedAudioAlert;
        if (textBoxAlertInterval != null)
            textBoxAlertInterval.Text = (config?.AlertIntervalSeconds ?? 60).ToString();
    }

    private void SaveUIToSettings()
    {
        if (config == null) config = new AppConfig();
        if (config.BusinessHours == null) config.BusinessHours = new BusinessHoursConfig();
        config.BusinessHours.Enabled = checkBoxBusinessHoursEnabled.Checked;
        config.BusinessHours.DaysOfWeek = checkedListBoxDaysOfWeek.CheckedItems.Cast<string>().ToList();
        config.BusinessHours.StartTime = textBoxStartTime.Text.Trim();
        config.BusinessHours.EndTime = textBoxEndTime.Text.Trim();
        if (config.Teamwork == null) config.Teamwork = new TeamworkConfig();
        config.Teamwork.ApiToken = textBoxApiToken.Text.Trim();
        config.Teamwork.BaseUrl = textBoxBaseUrl.Text.Trim();
        // AudioAlertFile is now handled here
        config.AudioAlertFile = tempSelectedAudioAlert;
        selectedAudioAlert = tempSelectedAudioAlert;
        if (textBoxAlertInterval != null && int.TryParse(textBoxAlertInterval.Text.Trim(), out int interval) && interval > 0)
            config.AlertIntervalSeconds = interval;
        else
            config.AlertIntervalSeconds = 60;
        alertIntervalSeconds = config.AlertIntervalSeconds.Value;
        pollIntervalSeconds = alertIntervalSeconds;
    }

    private void ButtonSaveSettings_Click(object? sender, EventArgs e)
    {
        SaveUIToSettings();
        SaveConfig();
        LoadSettingsToUI();
        this.Hide();
    }

    private void ButtonCancelSettings_Click(object? sender, EventArgs e)
    {
        // Restore tempSelectedAudioAlert to match config
        if (config != null && !string.IsNullOrEmpty(config.AudioAlertFile))
            tempSelectedAudioAlert = config.AudioAlertFile;
        else
            tempSelectedAudioAlert = "Windows Message Nudge.wav";
        if (comboBoxAudioAlert.Items.Contains(tempSelectedAudioAlert))
            comboBoxAudioAlert.SelectedItem = tempSelectedAudioAlert;
        LoadSettingsToUI();
        this.Hide();
    }
}
