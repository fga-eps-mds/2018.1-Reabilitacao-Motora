#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"
project="Reabilitacao-Motora"

echo "${TEXTOAMARELO} Entrando na Pasta do Projeto - A Pasta do Projeto Contém : ${NORMAL}"
cd Reabilitacao-Motora
ls
echo "${TEXTOVERDE} ======================================================================================================== ${NORMAL}"

echo "${TEXTOAMARELO} Tentativa de Build do $project para OSX  ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -projectPath $(pwd) -buildOSXUniversalPlayer "Build/osx/$project.app" -quit
echo "${TEXTOVERDE} ======================================= BUILD CONCLUÍDA PARA OSX ======================================= ${NORMAL}"

echo "${TEXTOAMARELO} Tentativa de Build do $project para Linux  ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -projectPath $(pwd) -buildLinuxUniversalPlayer "Build/linux/$project.exe" -quit
echo "${TEXTOVERDE} ======================================= BUILD CONCLUÍDA PARA LINUX ======================================= ${NORMAL}"

echo "${TEXTOAMARELO} Tentativa de Build do $project para Windows ${NORMAL}"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -projectPath $(pwd) -buildWindowsPlayer "Build/windows/$project.exe" -quit
echo "${TEXTOVERDE} ======================================= BUILD CONCLUÍDA PARA WINDOWS ======================================= ${NORMAL}"

echo "${TEXTOAMARELO} Tentativa de Zip Builds ${NORMAL}"
zip -r Build/linux.zip Build/linux/
zip -r Build/mac.zip Build/osx/
zip -r Build/windows.zip Build/windows/
