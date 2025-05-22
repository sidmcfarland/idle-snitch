# IDLE Snitch

IDLE Snitch is a Windows application built with .NET 8 and WinForms. The project is currently in its initial setup phase.

## Current Features
- Project initialized as a .NET 8 WinForms application
- Solution and folder structure created: `src`, `config`, `assets`
- .gitignore configured for .NET/WinForms
- NuGet dependencies installed: `Newtonsoft.Json`, `System.Configuration.ConfigurationManager`, `Microsoft.Windows.Compatibility`
- Basic empty form launches successfully

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
2. Open `idle-snitch.sln` in Visual Studio.
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
   dotnet run --project src/IdleSnitch.csproj
   ```

## Planned Features
See `development-tasks.md` for the full list of planned features and development progress.

---