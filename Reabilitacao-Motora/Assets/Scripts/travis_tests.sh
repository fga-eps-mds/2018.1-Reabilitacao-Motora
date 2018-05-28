#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"

echo "${TEXTOAMARELO} Entrando na Pasta do Projeto - A Pasta do Projeto Contém : ${NORMAL}"
cd Reabilitacao-Motora
ls
echo "${TEXTOVERDE} ======================================================================================================== ${NORMAL}"

echo "${TEXTOAMARELO} Iniciando Script de PlayTest ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -logFile /dev/stdout -runTests -projectPath $(pwd) -testPlatform playmode -testResults /Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/test.xml
rc0=$?
echo "${TEXTOVERDE} ======================================= FIM DO SCRIPT PLAYTEST ======================================= ${NORMAL}"

echo " ${TEXTOAMARELO} Exibindo Log do Script de PlayTest ${NORMAL}"
python /Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/Assets/Scripts/test_log_converter.py
echo "${TEXTOVERDE} ======================================= FIM DOS LOGS DE TEST ======================================= ${NORMAL}"

if [ $rc0 -ne 0 ]; then { echo " PlayTest Falhando -- Consultar Log de Teste -- "; exit $rc0; } fi
