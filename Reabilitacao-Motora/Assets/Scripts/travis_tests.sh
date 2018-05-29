#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"

echo "${TEXTOAMARELO} Entrando na Pasta do Projeto - A Pasta do Projeto Contém : ${NORMAL}"
cd Reabilitacao-Motora
ls
echo "${TEXTOVERDE} ======================================================================================================== ${NORMAL}"

echo "${TEXTOAMARELO} Iniciando Script de PlayTest ${NORMAL}"
#/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -runTests -projectPath $(pwd) -testPlatform playmode -testResults /Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/playTest.xml
rc0=$?
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -runEditorTests -projectPath $(pwd) -editorTestsResultFile $(pwd)/test.xml
rc1=$?
echo "${TEXTOVERDE} ======================================= FIM DO SCRIPT PLAYTEST ======================================= ${NORMAL}"

echo " ${TEXTOAMARELO} Exibindo Log do Script de PlayTest ${NORMAL}"
cat $(pwd)/test.xml
#python /Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/Assets/Scripts/test_log_converter.py
echo "${TEXTOVERDE} ======================================= FIM DOS LOGS DE TEST ======================================= ${NORMAL}"

if [ $rc0 -ne 0 ]; then { echo " PlayTest Falhando -- Consultar Log de Teste -- "; exit $rc0; } fi
if [ $rc1 -ne 0 ]; then { echo " Editors Tests Falhando -- Consultar Log de Teste -- "; exit $rc0; } fi


#/Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/editorTest.xml
