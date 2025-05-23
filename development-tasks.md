# Development Task List for IDLE Snitch

This document tracks all development tasks required to deliver the MVP as described in the PRD.

## Project Setup
- [x] Create new .NET 8 WinForms project
- [x] Set up solution and project folders (e.g., src, config, assets)
- [x] Add initial README and LICENSE files
- [x] Configure .gitignore for .NET/WinForms
- [x] Set up initial NuGet dependencies (if any)
- [x] Verify WinForms app runs (empty form)
- [x] Add a 'Quick Start' section to the README with build/run instructions
- [x] Review .gitignore to ensure all build artifacts, user config, and secrets are ignored (added *.user, config/*.json, secrets.*)
- [x] Add all icon assets to the assets folder and ensure all are copied to output directory
- [x] Verify all solution folders (src, config, assets) are present and referenced as needed
- [x] Review project setup: assess if additional setup steps or tests are needed before moving to core features
- [x] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far

## Core Features
- [x] Implement tray icon with five state indications
    - [x] Define the five tray icon states and what each represents
    - [x] Prepare or collect five distinct icon assets and add to assets/
    - [x] Add NotifyIcon to the main form and load icons
    - [x] Implement logic to switch tray icon based on state
    - [x] Add temporary UI or debug code to manually trigger each state for testing
- [x] Detect and respect configurable business hours
    - [x] Add a configuration option (e.g., in a JSON or user.config file) for business hours (start/end time, days of week)
    - [x] Load business hours from configuration at app startup
    - [x] Implement a method to determine if the current time is within business hours
    - [x] Integrate this check into the main app logic (e.g., tray icon state, alerts)
- [x] Integrate with Teamwork API to check timer status
- [x] Handle API errors and reuse prior state
- [x] Add API activity indicator icon to UI that is visible only during Teamwork API requests
- [x] Play audio alert if not on the clock during business hours
    - [x] Use Windows "Message Nudge" system sound if available, fallback to Exclamation
    - [x] Show message box for debugging when alert is triggered
    - [x] Alert triggers only if not on the clock, within business hours
- [x] Allow user to select audio alert file from all available Windows system sounds
- [x] Implement snooze functionality (10, 30, 60 minutes)
- [x] Reflect snoozed state in tray icon
- [x] Provide settings UI (API token, business hours, audio file, enable/disable)
    - [x] Add Settings item to tray icon context menu
    - [x] Show main window only when Settings is selected from tray menu
    - [x] Main window is hidden by default and never appears in the taskbar
    - [x] Main window cannot be minimized or maximized; only closed (later restored to allow resizing)
    - [x] Closing the main window hides it (does not exit the app)
    - [x] Only the Exit menu item in the tray menu fully exits the application
    - [x] Add UI controls to set and save API token
    - [x] Add UI controls to set and save business hours (start/end time, days of week)
    - [x] Add UI controls to select and save audio alert file
    - [x] Add UI controls to enable/disable the app
    - [x] Load current settings from the application settings file into the UI on open
    - [x] Save changes from the UI back to the application settings file
    - [x] Validate user input and provide feedback for invalid settings
    - [x] Add a Save button and a Cancel button to the settings UI
    - [x] Optionally, add a Reset to Defaults button
    - [x] Add a tabbed interface to the settings form
    - [x] Add a Log tab that displays the contents of the log file
    - [x] Add setting for alert interval (seconds) with default 60
    - [x] Show alert interval in settings UI and save only on Save
    - [x] Refactor settings UI to be fully scalable and high-DPI friendly
    - [x] Ensure all settings (including audio alert) are only saved when Save is clicked; Cancel discards changes
- [x] Manual enable/disable toggle via tray menu
- [x] Register app to auto-start on Windows login
- [x] Review core features: assess if additional features, tests, or refactoring are needed before moving to non-functional tasks
- [x] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far
- [x] Remove temporary debug UI and code for manual tray icon state switching
- [x] Remove API activity indicator icon and all related code

## Non-Functional
- [x] Store config securely in user-accessible location
- [x] Ensure minimal resource usage (poll every 60 seconds)
- [x] Target .NET 8 and WinForms
- [x] Support Windows 10+
- [x] All icon and config files are reliably copied to output directory using PreserveNewest
- [x] Settings file is never overwritten after first run; user changes persist
- [x] Robust logging of all key events, settings changes, and application lifecycle
- [x] Review non-functional requirements: assess if additional requirements, tests, or optimizations are needed before moving to development notes
- [x] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far

## Development Notes
- [x] Use NotifyIcon and ContextMenuStrip for tray UI
- [x] Use System.Media.SoundPlayer for audio
- [x] Use System.Timers.Timer for polling
- [x] Store config in user.config or JSON in %APPDATA% (now stored in output directory for persistence)
- [x] Register auto-start in HKCU registry
- [x] Tabbed settings UI with log viewer
- [x] All assets and config files included in .csproj with PreserveNewest
- [x] Review development notes: assess if additional implementation notes, tests, or documentation are needed before moving to testing & QA
- [x] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far

## Testing & QA
- [x] Test all tray icon states
- [x] Test business hour detection and transitions
- [x] Test Teamwork API integration and error handling
    - [x] Update Teamwork API integration to use /me/timers.json?runningTimersOnly=true
    - [x] Check 'timers' array in response to determine running status
    - [x] Improved error reporting for API failures
- [x] Test audio alert and snooze
- [x] Test settings UI and persistence
- [x] Test auto-start on login
- [x] Test that manual snooze state is overridden by Teamwork polling after snooze expires
- [x] Review testing & QA: assess if additional test cases, automation, or manual QA steps are needed before moving to documentation
- [x] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far

## Documentation
- [x] Update README with setup and usage instructions
- [x] Document configuration and troubleshooting steps
- [x] Review documentation: assess if additional documentation, diagrams, or user guides are needed before project completion
- [x] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far

---
Add, update, or check off tasks as development progresses.
