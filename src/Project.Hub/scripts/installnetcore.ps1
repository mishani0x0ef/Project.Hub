$localPath = 'C:\dotnet-sdk-2.1.4-win-x64.exe'

if(!(Test-Path $localPath))
{
    Invoke-WebRequest -Uri 'https://download.microsoft.com/download/1/1/5/115B762D-2B41-4AF3-9A63-92D9680B9409/dotnet-sdk-2.1.4-win-x64.exe' -OutFile $localPath
    & $localPath /quiet /log c:\InstallNetCore20.log
}