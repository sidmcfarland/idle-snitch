# Product Requirements Document (PRD)
**Project:** Teamwork Timer Reminder  
**Platform:** Windows (.NET 8, WinForms preferred)  
**Status:** Final MVP Spec  

## 1. Overview
A lightweight Windows background app that alerts the user if no Teamwork timer is running during defined work hours. The app minimizes time lost due to forgetting to start a timer and supports snooze and customization of business hours and audio alerts.

## 2. Goals
- Keep users aware if they are not on the clock during work hours.
- Provide audio-based alerts and snoozing.
- Minimize disruptions while maintaining visibility.
- Auto-launch silently at login and live in the system tray.

## 3. User Roles
- Standard User (individual using the app locally)

## 4. Core Features

### Tray Icon with State Indication
- Tray icon reflects one of five states:
  1. 🟢 Active + On the Clock  
  2. 🔴 Active + Off the Clock  
  3. 🟡 Snoozed  
  4. ⚪ Outside Business Hours  
  5. ⚫ Disabled (via right-click menu)

### Work Hour Detection
- Configurable via settings:
  - Start Day: e.g., Tuesday
  - End Day: e.g., Friday
  - Start Time: e.g., 08:00
  - End Time: e.g., 16:00

### Teamwork API Integration
- Uses GET /me/time_entries/current.json
- Auth via API token (Basic Auth)
- If API call fails:
  - Reuse prior known state (e.g., "on clock" or "off clock")
  - Log error silently

### Audio Alert
- Triggered once every 60 seconds if:
  - It's within business hours AND
  - No timer is running AND
  - App is not snoozed or disabled
- User selects audio from available Windows system sounds (.wav files in system directory)

### Snooze Functionality
- Options: 10, 30, 60 minutes (via tray menu)
- Tray icon reflects snoozed state

### Settings UI
Accessible from the tray icon:
- Teamwork API token
- Business hours (start/end day and time)
- Select audio alert file from system
- Manual disable/enable toggle

### Auto-Start on Login
- App registers itself to start with Windows (in current user context)

## 5. Non-Functional Requirements
- Platform: Windows 10+
- Framework: .NET 8, WinForms (chosen for simplicity + LLM compatibility)
- Performance: Minimal resource usage; polling every 60 sec
- Security: API token stored in user-accessible local config, not accessible by other users

## 6. Out of Scope for MVP
- Per-day or multi-block scheduling
- External calendar integration
- Visual alerts (screen border, flashing overlay)
- API polling interval customization
- Multi-user or shared device support

## 7. Future Considerations
- Granular work schedules (multiple blocks per day)
- Visual reminders
- Slack/Teams integration
- Idle-time detection
- Smart reactivation of recent task

## 8. Development Notes
- Use NotifyIcon and ContextMenuStrip in WinForms
- Use System.Media.SoundPlayer to play system .wav files
- Use System.Timers.Timer for polling
- Store config in user.config or local JSON file in %APPDATA%
- Register auto-start in HKCU\Software\Microsoft\Windows\CurrentVersion\Run
