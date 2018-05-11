#! /bin/sh

TEXTOAZUL=`echo "\033[01;34m"`
TEXTOVERMELHO=`echo "\033[01;31m"`
TEXTOAMARELO=`echo "\033[01;33m"`
TEXTOVERDE=`echo "\033[01;32m"`
NORMAL=`echo "\033[m"`

echo "${TEXTOAMARELO}Initializing Testing Script for Reabilitacao Motora ${NORMAL}"
cd Reabilitacao-Motora
echo "${TEXTOAMARELO}Current folder contains:${NORMAL}"
ls
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"


echo "${TEXTOAMARELO}Attempting to activate Unity${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -serial $UNITY_KEY -username $UNITY_LOGIN -password $UNITY_PASSWORD -logFile /dev/stdout -quit
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"


echo "${TEXTOAMARELO} Attempting to Test Reabilitacao Motora ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -logFile /dev/stdout -runTests -projectPath $(pwd) -testPlatform playmode -testResults $(pwd)/test.xml
rc0=$?
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

echo " ${TEXTOAMARELO}Untiy test Logs"
cat $(pwd)/test.xml
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

echo "${TEXTOAMARELO}Opening in order to deactivate Unity${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -returnlicense -logFile /dev/stdout -quit
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

if [ $rc0 -ne 0 ]; then { echo "Failed unit tests"; exit $rc0; } fi
