$progressPreference = 'silentlyContinue'
Write-Information "Downloading WinGet and its dependencies..."
Invoke-WebRequest -Uri https://aka.ms/getwinget -OutFile Microsoft.DesktopAppInstaller_8wekyb3d8bbwe.msixbundle
Invoke-WebRequest -Uri https://aka.ms/Microsoft.VCLibs.x64.14.00.Desktop.appx -OutFile Microsoft.VCLibs.x64.14.00.Desktop.appx
Invoke-WebRequest -Uri https://github.com/microsoft/microsoft-ui-xaml/releases/download/v2.8.6/Microsoft.UI.Xaml.2.8.x64.appx -OutFile Microsoft.UI.Xaml.2.8.x64.appx
Add-AppxPackage Microsoft.VCLibs.x64.14.00.Desktop.appx
Add-AppxPackage Microsoft.UI.Xaml.2.8.x64.appx
Add-AppxPackage Microsoft.DesktopAppInstaller_8wekyb3d8bbwe.msixbundle





winget install Microsoft.VisualStudio.2022.Community --override "--quiet --add Microsoft.Net.Component.4.8.SDK --add Microsoft.NetCore.Component.Web"

winget install -e --id Postman.Postman

winget install --id=Fortinet.FortiClientVPN  -e

winget install -e --id WinSCP.WinSCP

<#Invoke-WebRequest -Uri 'https://dl.pstmn.io/download/latest/win64' -OutFile 'Postman-win64-Setup.exe'
start Postman-win64-Setup.exe

(Invoke-WebRequest -Uri 'https://download.filezilla-project.org/client/FileZilla_3.67.0_win64_sponsored2-setup.exe' -OutFile 'FileZilla_3.67.0_win64_sponsored2-setup.exe' -Method Post).Content

start FileZilla_3.67.0_win64_sponsored2-setup.exe

Invoke-WebRequest -Uri 'https://www.fortinet.com/support/product-downloads/forticlient' -OutFile 'forticlient.exe'

start forticlient.exe#>


Invoke-WebRequest -Uri 'https://download.oracle.com/otn_software/nt/instantclient/2113000/instantclient-basic-windows.x64-21.13.0.0.0dbru.zip' -OutFile 'instantclient-basic-windows.x64-21.13.0.0.0dbru.zip'
powershell Expand-Archive -Path instantclient-basic-windows.x64-21.13.0.0.0dbru.zip
cd instantclient-basic-windows.x64-21.13.0.0.0dbru
move "instantclient_21_13" "c:\"

