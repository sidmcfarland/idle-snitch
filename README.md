# IDLE Snitch

IDLE Snitch is a lightweight Windows system tray application that helps you stay on track with your work hours by monitoring your Teamwork timer status. If you are within your configured business hours and not tracking time, the app will alert you with a customizable audio notification. It features a modern tabbed settings UI, robust logging, and ensures your preferences are always saved and never overwritten by updates or rebuilds. Designed for reliability and ease of use, IDLE Snitch keeps you accountable and productive throughout your workday.

IDLE Snitch is a Windows application built with .NET 8 and WinForms. The project setup is complete and verified (see `development-tasks.md` for checklist).

## Features
- System tray app with five icon states (Active On, Active Off, Snoozed, Outside, Disabled)
- Configurable business hours
- Teamwork API integration for timer status
- Audio alert if not on the clock during business hours (user-selectable from all Windows system sounds)
- **Configurable alert interval (seconds) for how often the app checks and alerts**
- Settings UI with tabbed interface
  - General tab: select audio notification, configure business hours, API token, alert interval, etc.
  - Log tab: view application log file
- **All settings changes (including audio alert) are only saved when you click Save. Cancel discards all changes.**
- Settings and log file are persisted in the output directory and not overwritten on rebuild
- All icon assets and config files are reliably copied to the output directory
- Robust logging of all key events, settings changes, and application lifecycle
- **Modern, scalable settings UI adapts to high-DPI and display scaling**

## Project Setup
- .NET 8 WinForms project
- Solution and project folders: src, config, assets
- All icon files and config/appsettings.json are included in the project with `PreserveNewest` so they are only copied if changed
- User settings are never overwritten on rebuild or publish

## Quick Start
1. Build and run the solution in Visual Studio or VS Code.
2. The app will appear in the system tray.
3. Right-click the tray icon and select Settings to open the tabbed settings window.
4. Configure your business hours, Teamwork API token, alert interval, and select your preferred audio notification.
5. View the application log in the Log tab.

## Configuration & Persistence
- All user settings are stored in `bin/Debug/net8.0-windows/config/appsettings.json` (or the equivalent output directory).
- The settings file is only copied from the source if it does not already exist, so user changes persist.
- The log file is stored as `IdleSnitch.log` in the output directory.
- `AlertIntervalSeconds`: How often (in seconds) the app checks and alerts if you are not on the clock (default: 60)

## Deployment
- All icon files and config are included in the output directory for reliable deployment.
- No settings or user data are overwritten on build or publish.

## Planned Features & Development Progress
See `development-tasks.md` for the full list of planned features and development progress.

## Troubleshooting
- If icons or config are missing, ensure all files are present in the output directory.
- Check the Log tab in Settings for detailed application events and errors.

---
For more details, see the PRD and development-tasks.md.