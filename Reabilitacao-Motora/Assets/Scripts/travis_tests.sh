#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"

echo "${TEXTOAMARELO}Entering the project folder to start test script ${NORMAL}"
cd Reabilitacao-Motora

echo "${TEXTOAMARELO}Current folder contains:${NORMAL}"
ls
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

echo "${TEXTOAMARELO} Attempting to Test Reabilitacao Motora ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -logFile /dev/stdout -runTests -projectPath $(pwd) -testPlatform playmode -testResults $(pwd)/test.xml
rc0=$?
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

echo " ${TEXTOAMARELO}Untiy test Logs"
cat $(pwd)/test.xml
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

if [ $rc0 -ne 0 ]; then { echo "Failed unit tests"; exit $rc0; } fi
