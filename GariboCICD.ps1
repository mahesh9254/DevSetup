
[CmdletBinding()]
 param(
     [Parameter(Mandatory)]

     [string]$RepositoryURL,

     [Parameter(Mandatory)]

     [pscredential]$Credential,

     [Parameter(Mandatory)]

     [string]$FilePath,

     [Parameter(Mandatory)]

     [string]$FtpServerHost

 )
git clone $RepositoryURL
cd test1
git switch master
cd WMS.ServiceApp.Adani
dotnet restore
dotnet build
dotnet publish
cd bin\Debug\netcoreapp3.1\publish


$files = get-childitem -path "$path" -file -recurse -include *.config, appsettings.*

$files | Remove-Item

$webclient = New-Object System.Net.WebClient

$ftpPassword = $Credential.GetNetworkCredential().Password

Write-Host $Credential.Username
Write-Host $ftpPassword
$webclient.Credentials = New-Object System.Net.NetworkCredential($Credential.Username, $ftpPassword)

#$remoteFileName = $FilePath | Split-Path -Leaf
$uri = New-Object System.Uri("ftp://$FtpServerHost/Testcd")

$files = Get-ChildItem -path "$path"  | Where-Object{!$_.PSIsContainer}

foreach ($file in $files)
{
    Write-Host "Uploading $file"
    $webclient.UploadFile("$uri/$file", $file.FullName)
} 
<#
$folders = $files | Where-Object{$_.PSIsContainer}

foreach ($folder in $folders)
{
	Write-Host "Uploading $folders"
	$files = Get-ChildItem -path "./$folders" 
	$uri = New-Object System.Uri("ftp://$FtpServerHost/$folder")
   foreach ($file in $files)
   {
    Write-Host "Uploading $file"
    $webclient.UploadFile("$uri/$file", $file.FullName)
   } 
    
}#>
#$webclient.UploadFile($uri, $FilePath)

$webclient.Dispose()