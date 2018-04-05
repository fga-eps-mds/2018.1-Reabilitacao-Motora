#! /bin/sh
project="Reabilitacao-Motora"

echo "Initializing Build Script for $project"
echo "========================================"

cd Reabilitacao-Motora
ls

# echo "Opening in order to load Unity"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
# -batchmode \
# -nographics \
# -projectPath $(pwd)/$project \
# -logFile $(pwd)/$project/unity.log \
# -quit
# echo "========================================"

# echo 'Logs from opening'
# cat $(pwd)/$project/unity.log
# echo "========================================"

# echo "Opening in order to activate Unity"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
# -batchmode \
# -nographics \
# -serial $UNITY_KEY \
# -username $UNITY_LOGIN \
# -password $UNITY_PASSWORD \
# -logFile $(pwd)/$project/unity.log \
# -quit
# echo "========================================"

# echo 'Logs from activation'
# cat $(pwd)/$project/unity.log

echo "Attempting to activate Unity"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -serial $UNITY_KEY -username $UNITY_LOGIN -password $UNITY_PASSWORD -logFile /dev/stdout -quit

echo "Attempting to build $project for OSX"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -logFile /dev/stdout -projectPath $(pwd) -buildOSXUniversalPlayer "Build/osx/$project.exe" -quit

# echo "Attempting to build $project for OS X"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
# -nographics \
# -batchmode \
# -serial $UNITY_KEY \
# -username $UNITY_LOGIN \
# -password $UNITY_PASSWORD \
# -logFile $(pwd)/$project/unity.log \
# -projectPath $(pwd)/$project \
# -buildOSXUniversalPlayer "$(pwd)/$project/Build/osx/$project.app" \
# -quit

# echo 'Logs from build'
# cat $(pwd)/$project/unity.log

# echo "Attempting to build $project for Linux"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
# -nographics \
# -batchmode \
# -serial $UNITY_KEY \
# -username $UNITY_LOGIN \
# -password $UNITY_PASSWORD \
# -logFile $(pwd)/$project/unity.log \
# -projectPath $(pwd)/$project \
# -buildLinuxUniversalPlayer "$(pwd)/$project/Build/linux/$project.exe" \
# -quit

# echo 'Logs from build'
# cat $(pwd)/$project/unity.log

echo "Opening in order to deactivate Unity"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -returnlicense -logFile unity.log -quit
echo "========================================"

echo 'Logs from deactivation'
cat unity.log

echo 'Attempting to zip builds'
# zip -r $(pwd)/$project/Build/linux.zip $(pwd)/$project/Build/linux/
zip -r Build/mac.zip Build/osx/
# zip -r Build/windows.zip /Build/windows/