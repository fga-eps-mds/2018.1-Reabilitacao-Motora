#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"

echo "${TEXTOAMARELO} Entrando na Pasta do Projeto ${NORMAL}"
cd Reabilitacao-Motora

echo "${TEXTOAMARELO} A Pasta do Projeto Contém :${NORMAL}"
ls
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

echo "${TEXTOAMARELO} Tentativa de Ativação do Unity${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -serial $UNITY_KEY -username $UNITY_LOGIN -password $UNITY_PASSWORD -logFile /dev/stdout -quit
echo "${TEXTOVERDE} ======================================= ATIVAÇÃO CONCLUÍDA ======================================= ${NORMAL}"
