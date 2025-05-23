# Publish IdleSnitch as a portable Windows app

# Variables
$project = "./IdleSnitch.csproj"
$output = "./publish"
$runtime = "win-x64"

# Clean previous publish
if (Test-Path $output) { Remove-Item $output -Recurse -Force }

# Publish self-contained build
Write-Host "Publishing self-contained build..."
dotnet publish $project -c Release -r $runtime --self-contained true -o $output

# Copy config and assets
Write-Host "Copying config and assets..."
Copy-Item -Recurse -Force ./config $output/
Copy-Item -Recurse -Force ./assets $output/

# Zip the publish folder
$zipPath = "./IdleSnitch-portable.zip"
if (Test-Path $zipPath) { Remove-Item $zipPath -Force }
Compress-Archive -Path "$output/*" -DestinationPath $zipPath

Write-Host "Done! Distributable zip created at $zipPath"
