#! /bin/sh
project="Reabilitacao-Motora"

echo "Initializing Build Script for $project"
echo "========================================"

echo "The current path is $(pwd)/$project"
echo "========================================"
echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/$project/unity.log \
  -projectPath $(pwd)/$project \
  -buildWindowsPlayer "$(pwd)/$project/Build/windows/$project.exe" \
  -quit

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/$project/unity.log \
  -projectPath $(pwd)/$project \
  -buildOSXUniversalPlayer "$(pwd)/$project/Build/osx/$project.app" \
  -quit

echo "Attempting to build $project for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/$project/unity.log \
  -projectPath $(pwd)/$project \
  -buildLinuxUniversalPlayer "$(pwd)/$project/Build/linux/$project.exe" \
  -quit

echo 'Logs from build'
cat $(pwd)/$project/unity.log


echo 'Attempting to zip builds'
zip -r $(pwd)/$project/Build/linux.zip $(pwd)/$project/Build/linux/
zip -r $(pwd)/$project/Build/mac.zip $(pwd)/$project/Build/osx/
zip -r $(pwd)/$project/Build/windows.zip $(pwd)/$project/Build/windows/