#! /bin/sh
project="Reabilitacao-Motora"

echo "Initializing Build Script for $project"
echo "========================================"

cd Reabilitacao-Motora

echo "Opening $project in order to update meta files"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -nographics -logFile unity.log -projectPath . -runEditorTests -editorTestsResultFile test.xml rc0=$?

echo "========================================"
echo "Unity logs"
cat unity.log
echo "========================================"
echo "Test logs"
cat test.xml
# exit if tests failed
if [ $rc0 -ne 0 ]; then { echo "Failed unit tests"; exit $rc0; } fi

# echo "Attempting to build $project for Windows"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
# -force-free \
# -batchmode \
# -silent-crashes \
# -logFile $(pwd)/$project/unity.log \
# -projectPath $(pwd)/$project \
# -executeMethod TravisBuildSceneSelector.Perform \
# -buildWindowsPlayer "$(pwd)/$project/Build/windows/$project.exe" \
# -quit

# echo 'Logs from build'
# cat $(pwd)/$project/unity.log

# echo "Attempting to build $project for OS X"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
# -force-free \
# -batchmode \
# -silent-crashes \
# -logFile $(pwd)/$project/unity.log \
# -projectPath $(pwd)/$project \
# -executeMethod TravisBuildSceneSelector.Perform \
# -buildOSXUniversalPlayer "$(pwd)/$project/Build/osx/$project.app" \
# -quit

# echo 'Logs from build'
# cat $(pwd)/$project/unity.log

# echo "Attempting to build $project for Linux"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
# -force-free \
# -batchmode \
# -silent-crashes \
# -logFile $(pwd)/$project/unity.log \
# -projectPath $(pwd)/$project \
# -executeMethod TravisBuildSceneSelector.Perform \
# -buildLinuxUniversalPlayer "$(pwd)/$project/Build/linux/$project.exe" \
# -quit

# echo 'Logs from build'
# cat $(pwd)/$project/unity.log


# echo 'Attempting to zip builds'
# zip -r $(pwd)/$project/Build/linux.zip $(pwd)/$project/Build/linux/
# zip -r $(pwd)/$project/Build/mac.zip $(pwd)/$project/Build/osx/
# zip -r $(pwd)/$project/Build/windows.zip $(pwd)/$project/Build/windows/