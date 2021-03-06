@echo off

echo.
echo Shim NuGet package builder
echo ==========================
echo. 
echo This Windows batch file uses NuGet to automatically
echo build the Shim NuGet package.
echo. 

timeout /T 5

:: Set version info
call version.cmd
set output=.\bin\nupkg

:: Create output directory
IF NOT EXIST %output%\nul (
    mkdir %output%
)

:: Remove old files
forfiles /p %output% /m *.nupkg /c "cmd /c del @file"


echo.
echo Creating packages...

forfiles /m shim.android.nuspec /c "cmd /c nuget.exe pack @File -Version %version% -OutputDirectory %output%"

:eof