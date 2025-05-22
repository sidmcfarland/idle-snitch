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

## Planned Features
See `development-tasks.md` for the full list of planned features and development progress.

---