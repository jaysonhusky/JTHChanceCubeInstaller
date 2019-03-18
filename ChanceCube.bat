@echo off

echo Welcome to JaysonHusky's SafeChanceCube Installer.
echo Please run this installer without Project Ozone 2: Reloaded running.

pause

set /p UserInputPath=Please Enter your PC Username
cd C:\Users\%UserInputPath%\Documents\Curse\Minecraft\Instances\Project Ozone 2 Reloaded\config\ChanceCubes


xcopy /s C:\Users\%UserInputPath%\Downloads\JTHChanceCubeInstaller\config C:\Users\%UserInputPath%\Documents\Curse\Minecraft\Instances\Project Ozone 2 Reloaded\config\ChanceCubes


pause

echo Operation Complete.

pause
exit