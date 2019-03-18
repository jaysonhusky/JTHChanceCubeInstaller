@echo off
echo Welcome to JaysonHusky's SafeChanceCube Installer.
echo.
echo Please run this installer without Project Ozone 2: Reloaded running.
pause
echo.
cd "%USERPROFILE%\Documents\Curse\Minecraft\Instances\Project Ozone 2 Reloaded\config\ChanceCubes"
echo.
xcopy %USERPROFILE%\Downloads\JTHChanceCubeInstaller\chancecubes.cfg "%USERPROFILE%\Documents\Curse\Minecraft\Instances\Project Ozone 2 Reloaded\config\ChanceCubes" /s /q /y
echo.
pause
echo.
echo Operation Complete.
echo.
pause
exit