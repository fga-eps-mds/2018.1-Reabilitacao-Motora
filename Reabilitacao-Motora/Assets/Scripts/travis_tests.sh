#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"

echo "${TEXTOAMARELO} Entrando na Pasta do Projeto - A Pasta do Projeto Contém : ${NORMAL}"
cd Reabilitacao-Motora
ls
echo "${TEXTOVERDE} ======================================================================================================== ${NORMAL}"

echo "${TEXTOAMARELO} Iniciando Script de PlayTest ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -runTests -projectPath $(pwd) -testPlatform playmode -testResults /Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/playTest.xml
rc0=$?
echo " ${TEXTOAMARELO} Exibindo Log do Script de PlayTest ${NORMAL}"
python /Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/Assets/Scripts/playTest_log_converter.py
echo "${TEXTOVERDE} ======================================= FIM DOS LOGS DO PLAY TEST ======================================= ${NORMAL}"
if [ $rc0 -ne 0 ]; then { echo " PlayTest Falhando -- Consultar Log de Teste -- "; exit $rc0; } fi

echo "${TEXTOAMARELO} Iniciando Script de EditorTest ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode  -projectPath $(pwd) -runEditorTests -editorTestsResultFile /Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/editorTest.xml
rc1=$?
echo " ${TEXTOAMARELO} Exibindo Log do Script de EditorsTests ${NORMAL}"
python /Users/travis/build/fga-gpp-mds/2018.1-Reabilitacao-Motora/Reabilitacao-Motora/Assets/Scripts/editorTest_log_converter.py
echo "${TEXTOVERDE} ======================================= FIM DO SCRIPT EDITORS TEST ======================================= ${NORMAL}"
if [ $rc1 -ne 0 ]; then { echo " Editors Tests Falhando -- Consultar Log de Teste -- "; exit $rc0; } fi
