#! /bin/sh

TEXTOAMARELO="\033[01;33m"
NORMAL="\033[m"

#Declaração das variáveis de validação
validaKey=1
validateste=1
validaBuild=1

  echo "${TEXTOAMARELO} Iniciando Script de Validação de Build. ${NORMAL}"
  ./Reabilitacao-Motora/Assets/Scripts/travis_unity_key.sh
  validaKey=$?

  if [ $validaKey -eq 0 ]; then
    echo "${TEXTOAMARELO} Iniciando PlayTest do Unity ! ${NORMAL}"
    ./Reabilitacao-Motora/Assets/Scripts/travis_tests.sh
    validateste=$?
  else
    echo "${TEXTOAMARELO} Erro Na Ativação do Unity ${NORMAL}"
    ./Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh
    exit $validaKey
  fi

 if [ $validaKey -eq 0 ] && [ $validateste -eq 0 ]; then
   echo "${TEXTOAMARELO} Ativação e Testes concluídos com êxito ... Iniciando Build do Projeto ! ${NORMAL}"
   #./Reabilitacao-Motora/Assets/Scripts/travis_build.sh
   validaBuild=$?
  else
    echo "${TEXTOAMARELO} Erro nos Testes do Unity... Iniciando a desativação da Máquina Virtual ${NORMAL} "
    ./Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh
    exit $validateste
  fi

  if [ $validaBuild -eq 0 ]; then
    echo "${TEXTOAMARELO} Iniciando a desativação da Máquina Virtual ${NORMAL} "
    ./Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh
    exit $validaBuild
  else
    echo "${TEXTOAMARELO} Erro na Build .... Iniciando a desativação da Máquina Virtual ${NORMAL} "
    ./Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh
    exit $validaBuild
  fi
