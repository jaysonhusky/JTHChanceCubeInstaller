@echo off
echo Welcome to JaysonHusky's SafeChanceCube Installer.
echo.
echo Please run this installer without Project Ozone 2: Reloaded running.
echo.
pause
echo.
cd "%USERPROFILE%\Documents\Curse\Minecraft\Instances\Project Ozone 2 Reloaded\config\ChanceCubes"
echo.
xcopy %USERPROFILE%\Downloads\JTHChanceCubeInstaller-master\chancecubes.cfg "%USERPROFILE%\Documents\Curse\Minecraft\Instances\Project Ozone 2 Reloaded\config\ChanceCubes" /s /q /y
echo.
echo.
pause
echo.
echo.
if ERRORLEVEL 5 goto diskerror
if ERRORLEVEL 4 goto filespaceerror
if ERRORLEVEL 4 goto filespaceerror
if ERRORLEVEL 2 goto noterminate
if ERRORLEVEL 1 goto fileerror
if ERRORLEVEL 0 goto completed
:completed
echo Operation Complete.
goto exit
:fileerror
echo Operation Failed.
goto exit
:noterminate
echo Operation Terminated By User.
goto exit
:filespaceerror
echo Operation cannot continue, disk space is insufficient or invalid syntax.
goto exit
:diskerror
echo Operation cannot continue, disk write error occured.
goto exit
:exit
echo.
echo.
pause
exit