
[CmdletBinding()]

 param(

     [Parameter(Mandatory)]

     [pscredential]$Credential,

     [Parameter(Mandatory)]

     [string]$FilePath,

     [Parameter(Mandatory)]

     [string]$FtpServerHost

 ) 

git clone https://Mahesh92549254@bitbucket.org/maheshtest9254/test1.git
cd cd.
git switch master
dotnet restore
dotnet build
cd WMS.ServiceApp.Adani
dotnet publish
cd \bin\Debug\netcoreapp3.1\publish

$logFile = 'test.log'

$files = get-childitem -path "$path" -file -recurse -include *.config, appsettings.*

($files).fullname >> $logFile

$files | Remove-Item

$webclient = New-Object System.Net.WebClient

$ftpPassword = $Credential.GetNetworkCredential().Password

$webclient.Credentials = New-Object System.Net.NetworkCredential($Credential.Username, $ftpPassword)

$remoteFileName = $FilePath | Split-Path -Leaf
$uri = New-Object System.Uri("ftp://$FtpServerHost/$remoteFileName")
$webclient.UploadFile($uri, $FilePath)
$webclient.Dispose()