#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"

echo "${TEXTOAMARELO} Entering the project folder ${NORMAL}"
cd Reabilitacao-Motora

echo "${TEXTOAMARELO}Current folder contains:${NORMAL}"
ls
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

echo "${TEXTOAMARELO}Attempting to activate Unity${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -serial $UNITY_KEY -username $UNITY_LOGIN -password $UNITY_PASSWORD -logFile /dev/stdout -quit
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"
