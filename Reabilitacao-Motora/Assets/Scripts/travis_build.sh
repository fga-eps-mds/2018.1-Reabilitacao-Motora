#! /bin/sh
project="Reabilitacao-Motora"
echo "========================================"
echo "Initializing Build Script for $project"
cd Reabilitacao-Motora
echo "========================================"
echo "Current folder contains:"
ls
echo "========================================"
echo "Attempting to activate Unity"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -serial $UNITY_KEY -username $UNITY_LOGIN -password $UNITY_PASSWORD -logFile /dev/stdout -quit
echo "========================================"
echo "Attempting to build $project for OSX"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -logFile /dev/stdout -projectPath $(pwd) -buildOSXUniversalPlayer "Build/osx/$project.app" -quit
echo "========================================"
echo "Attempting to build $project for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -logFile /dev/stdout -projectPath $(pwd) -buildLinuxUniversalPlayer "Build/linux/$project.exe" -quit
echo "========================================"
echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -logFile /dev/stdout -projectPath $(pwd) -buildWindowsPlayer "Build/windows/$project.exe" -quit
echo "========================================"
echo "Opening in order to deactivate Unity"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -returnlicense -logFile /dev/stdout -quit
echo "========================================"

echo 'Attempting to zip builds'
zip -r Build/linux.zip Build/linux/
zip -r Build/mac.zip Build/osx/
zip -r Build/windows.zip Build/windows/