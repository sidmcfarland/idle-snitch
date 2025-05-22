# IDLE Snitch

IDLE Snitch is a Windows application built with .NET 8 and WinForms. The project setup is complete and verified (see `development-tasks.md` for checklist).

## Current Features
- Project initialized as a .NET 8 WinForms application
- Solution and folder structure created: `src`, `config`, `assets`
- .gitignore configured for .NET/WinForms
- NuGet dependencies installed: `Newtonsoft.Json`, `System.Configuration.ConfigurationManager`, `Microsoft.Windows.Compatibility`
- Basic empty form launches successfully
- Placeholder app icon added and embedded as a resource

## Project Setup

The following setup steps have been completed:
- .NET 8 WinForms project created
- Solution and project folders: `src`, `config`, `assets`
- .gitignore configured for .NET/WinForms, user config, and secrets
- NuGet dependencies installed: `Newtonsoft.Json`, `System.Configuration.ConfigurationManager`, `Microsoft.Windows.Compatibility`
- Placeholder app icon added in `assets/icon.ico`
- All solution folders present and referenced
- Initial README and LICENSE files added
- Quick Start instructions provided below

## Quick Start

### Prerequisites
- Windows 10 or later
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later (with ".NET Desktop Development" workload)

### Build & Run (Visual Studio)
1. Clone this repository:
   ```sh
   git clone https://github.com/yourusername/idle-snitch.git
   ```
2. Open `IdleSnitch.csproj` in Visual Studio.
3. Restore NuGet packages (should happen automatically on open).
4. Press `F5` to build and run the application.

### Build & Run (Command Line)
1. Open a terminal and navigate to the project folder:
   ```sh
   cd idle-snitch
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build the project:
   ```sh
   dotnet build
   ```
4. Run the application:
   ```sh
   dotnet run --project IdleSnitch.csproj
   ```

## Tray Icon States

IDLE Snitch uses a tray icon with five distinct states to indicate your current status:

- **Active & On the Clock:** User is within business hours and actively tracking time (`icon-active-on.ico`)
- **Active & Off the Clock:** User is within business hours but not tracking time (`icon-active-off.ico`)
- **Snoozed:** Alerts are temporarily snoozed (`icon-snoozed.ico`)
- **Outside Business Hours:** User is outside configured business hours (`icon-outside.ico`)
- **Disabled:** App is manually disabled or not monitoring (`icon-disabled.ico`)

The tray icon updates automatically based on your status. All icon assets are located in the `assets/` folder.

## Tray Icon State Switching

The application supports five tray icon states:
- ActiveOn
- ActiveOff
- Snoozed
- Outside
- Disabled

The tray icon state is managed automatically by the application logic. There is no manual or debug UI for changing the tray icon state.

## System Tray Integration

The application uses the Windows system tray (via `NotifyIcon`) to display status and provide quick access to controls. Icons are loaded at startup and the tray icon is always visible while the app is running.

## Business Hours Configuration

IDLE Snitch supports configurable business hours. To set business hours:

1. Edit `config/appsettings.json`:
   ```json
   {
     "BusinessHours": {
       "Enabled": true,
       "DaysOfWeek": ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"],
       "StartTime": "09:00",
       "EndTime": "17:00"
     }
   }
   ```
2. The app will automatically copy this file to the output directory if needed, so you only need to edit the source file in `config/`.
3. The tray icon and the main form icon will reflect whether you are inside or outside business hours at startup.

- The icon updates automatically at startup and whenever the state changes.
- If an icon asset is missing, an error message will be shown.
- If the config file is missing or invalid, a message box will appear with details.

## Configuration

The application uses a configuration file at `config/appsettings.json` with the following structure:

```json
{
  "BusinessHours": {
    "Enabled": true,
    "DaysOfWeek": ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"],
    "StartTime": "09:00",
    "EndTime": "15:45"
  },
  "Teamwork": {
    "ApiToken": "<your_teamwork_api_token>",
    "BaseUrl": "https://<your_teamwork_domain>.teamwork.com"
  }
}
```

- **BusinessHours**: Defines the days and times considered business hours. The end time is now set to 3:45 PM Eastern (`15:45`).
- **Teamwork**: Add your Teamwork API token and base URL to enable timer status integration.

## Tray Icon Polling

- The app polls the Teamwork API every 10 seconds to check your timer status and updates the tray icon accordingly.
- If the Teamwork API is not configured or returns an error, the tray icon will show as Disabled.
- If you manually set the tray icon to Snoozed, it will remain in that state until further logic is implemented to allow polling to override it after snooze expires (see development tasks).

## Development & Testing Notes

- The config file is now always copied to the output directory on build, ensuring the latest settings are used.
- The business day end time is set to 3:45 PM Eastern.
- There is a development test to ensure that the manual snooze state is overridden by Teamwork polling after snooze expires.

## Troubleshooting
- If the tray icon disappears or the app crashes, ensure all icon files exist in the `assets/` folder and the config file is valid.
- The form's icon now always matches the tray icon state.
- The app copies `config/appsettings.json` to the output directory if not present, so runtime config issues are minimized.

## Planned Features
See `development-tasks.md` for the full list of planned features and development progress.

## Audio Alert Improvements
- The app now plays the Windows "Message Nudge" system sound (if available) when you are within business hours but not on the clock. If the sound file is not found, it falls back to the Exclamation system sound.
- A message box appears for debugging whenever the nudge alert is triggered, so you can verify alert timing even if the sound is not audible.
- The alert is triggered only once per polling interval if you are not on the clock.

## Teamwork API Integration Update
- The Teamwork timer check now uses the correct endpoint: `/me/timers.json?runningTimersOnly=true`.
- The app checks the `timers` array in the response to determine if any timers are running.
- Improved error reporting for API failures.

---