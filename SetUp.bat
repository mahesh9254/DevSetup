winget install Microsoft.VisualStudio.2022.Community --override "--quiet --add Microsoft.Net.Component.4.8.SDK --add Microsoft.NetCore.Component.Web"

powershell -c "Invoke-WebRequest -Uri 'https://dl.pstmn.io/download/latest/win64' -OutFile 'Postman-win64-Setup.exe'"
start Postman-win64-Setup.exe

powershell -c "Invoke-WebRequest -Uri 'https://dl4.cdn.filezilla-project.org/client/FileZilla_3.67.0_win64-setup.exe?h=iC30Fits2un4YM_skamoew&x=1715167521' -OutFile 'FileZilla_3.67.0_win64_sponsored2-setup.exe'"
start FileZilla_3.67.0_win64_sponsored2-setup.exe

Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

powershell -c "Invoke-WebRequest -Uri 'https://www.fortinet.com/support/product-downloads/forticlient' -OutFile 'forticlient.exe'"
start forticlient.exe


powershell -c "Invoke-WebRequest -Uri 'https://download.oracle.com/otn_software/nt/instantclient/2113000/instantclient-basic-windows.x64-21.13.0.0.0dbru.zip' -OutFile 'instantclient-basic-windows.x64-21.13.0.0.0dbru.zip'"
powershell Expand-Archive -Path instantclient-basic-windows.x64-21.13.0.0.0dbru.zip
cd instantclient-basic-windows.x64-21.13.0.0.0dbru
move "instantclient_21_13" "c:\"




