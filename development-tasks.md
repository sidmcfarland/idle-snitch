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
- [x] Add a placeholder app icon to the assets folder
- [ ] Verify all solution folders (src, config, assets) are present and referenced as needed
- [ ] Review project setup: assess if additional setup steps or tests are needed before moving to core features
- [ ] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far
- [ ] Update README with all project setup changes

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
- [ ] Review core features: assess if additional features, tests, or refactoring are needed before moving to non-functional tasks
- [ ] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far
- [ ] Update README with all core feature changes

## Non-Functional
- [ ] Store config securely in user-accessible location
- [ ] Ensure minimal resource usage (poll every 60 seconds)
- [ ] Target .NET 8 and WinForms
- [ ] Support Windows 10+
- [ ] Review non-functional requirements: assess if additional requirements, tests, or optimizations are needed before moving to development notes
- [ ] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far
- [ ] Update README with all non-functional requirement changes

## Development Notes
- [ ] Use NotifyIcon and ContextMenuStrip for tray UI
- [ ] Use System.Media.SoundPlayer for audio
- [ ] Use System.Timers.Timer for polling
- [ ] Store config in user.config or JSON in %APPDATA%
- [ ] Register auto-start in HKCU registry
- [ ] Review development notes: assess if additional implementation notes, tests, or documentation are needed before moving to testing & QA
- [ ] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far
- [ ] Update README with all development notes changes

## Testing & QA
- [ ] Test all tray icon states
- [ ] Test business hour detection and transitions
- [ ] Test Teamwork API integration and error handling
- [ ] Test audio alert and snooze
- [ ] Test settings UI and persistence
- [ ] Test auto-start on login
- [ ] Review testing & QA: assess if additional test cases, automation, or manual QA steps are needed before moving to documentation
- [ ] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far
- [ ] Update README with all testing & QA changes

## Documentation
- [ ] Update README with setup and usage instructions
- [ ] Document configuration and troubleshooting steps
- [ ] Review documentation: assess if additional documentation, diagrams, or user guides are needed before project completion
- [ ] Add or update any tasks in any section to reflect new or modified tasks based on the work completed so far
- [ ] Update README with all documentation changes

---
Add, update, or check off tasks as development progresses.
