#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"

echo "${TEXTOAMARELO} Entrando na Pasta do Projeto - A Pasta do Projeto Contém : ${NORMAL}"
cd Reabilitacao-Motora
ls
echo "${TEXTOVERDE} ======================================================================================================== ${NORMAL}"

echo "${TEXTOAMARELO} Iniciando Script de PlayTest ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -logFile /dev/stdout -runTests -projectPath $(pwd) -testPlatform playmode -testResults $(pwd)/test.xml
rc0=$?
echo "${TEXTOVERDE} ======================================= FIM DO SCRIPT PLAYTEST ======================================= ${NORMAL}"

echo " ${TEXTOAMARELO} Exibindo Log do Script de PlayTest ${NORMAL}"
cat $(pwd)/test.xml
echo "${TEXTOVERDE} ======================================= FIM DOS LOGS DE TEST ======================================= ${NORMAL}"

if [ $rc0 -ne 0 ]; then { echo " PlayTest Falhando -- Consultar Log de Teste -- "; exit $rc0; } fi
