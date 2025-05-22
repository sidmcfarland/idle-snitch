# Development Task List for IDLE Snitch

This document tracks all development tasks required to deliver the MVP as described in the PRD.

## Project Setup
- [x] Create new .NET 8 WinForms project
- [x] Set up solution and project folders (e.g., src, config, assets)
- [x] Add initial README and LICENSE files
- [x] Configure .gitignore for .NET/WinForms
- [ ] Set up initial NuGet dependencies (if any)
- [ ] Verify WinForms app runs (empty form)

## Core Features
- [ ] Implement tray icon with five state indications
- [ ] Detect and respect configurable business hours
- [ ] Integrate with Teamwork API to check timer status
- [ ] Handle API errors and reuse prior state
- [ ] Play audio alert if not on the clock during business hours
- [ ] Allow user to select audio alert file from system sounds
- [ ] Implement snooze functionality (10, 30, 60 minutes)
- [ ] Reflect snoozed state in tray icon
- [ ] Provide settings UI (API token, business hours, audio file, enable/disable)
- [ ] Manual enable/disable toggle via tray menu
- [ ] Register app to auto-start on Windows login

## Non-Functional
- [ ] Store config securely in user-accessible location
- [ ] Ensure minimal resource usage (poll every 60 seconds)
- [ ] Target .NET 8 and WinForms
- [ ] Support Windows 10+

## Development Notes
- [ ] Use NotifyIcon and ContextMenuStrip for tray UI
- [ ] Use System.Media.SoundPlayer for audio
- [ ] Use System.Timers.Timer for polling
- [ ] Store config in user.config or JSON in %APPDATA%
- [ ] Register auto-start in HKCU registry

## Testing & QA
- [ ] Test all tray icon states
- [ ] Test business hour detection and transitions
- [ ] Test Teamwork API integration and error handling
- [ ] Test audio alert and snooze
- [ ] Test settings UI and persistence
- [ ] Test auto-start on login

## Documentation
- [ ] Update README with setup and usage instructions
- [ ] Document configuration and troubleshooting steps

---
Add, update, or check off tasks as development progresses.
