#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"

echo "${TEXTOAMARELO} Entrando na Pasta do Projeto - A Pasta do Projeto Contém : ${NORMAL}"
cd Reabilitacao-Motora
ls
echo "${TEXTOVERDE}========================================================================================================${NORMAL}"

echo "${TEXTOAMARELO} Tentativa de desativação do Unity${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -returnlicense -logFile /dev/stdout -quit
echo "${TEXTOVERDE} ======================================= DESATIVAÇÃO CONCLUÍDA ======================================= ${NORMAL}"
