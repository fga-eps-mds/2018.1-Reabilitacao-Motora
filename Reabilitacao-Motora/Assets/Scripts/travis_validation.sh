#! /bin/sh

TEXTOAMARELO="\033[01;33m"
TEXTOVERDE="\033[01;32m"
NORMAL="\033[m"
validaTravis = 1
validaKey = 1
validateste= 1
validaBuild = 1

  echo "${TEXTOAMARELO} Iniciando Script de Validação de Build ${NORMAL}"
  ./Reabilitacao-Motora/Assets/Scripts/travis_unity_key.sh
  validaKey = $?

  if [[ $validaKey == 0 ]]; then
    ./Reabilitacao-Motora/Assets/Scripts/travis_tests.sh
    validateste= $?
  else
    echo "${TEXTOAMARELO} Erro Na Ativação do Unity ${NORMAL}"
  fi

 if [[ $validaKey && $validateste == 0 ]]; then
   ./Reabilitacao-Motora/Assets/Scripts/travis_build.sh
   validaBuild = $?
   ./Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh
  else
    echo "${TEXTOAMARELO} Erro nos Testes do Unity... Iniciando a desativação da Máquina Virtual ${NORMAL} "
    ./Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh
  fi

  echo "${TEXTOAMARELO} Iniciando a desativação da Máquina Virtual ${NORMAL} "
    ./Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh

    if [[ ($validaKey || $validateste || $validaBuild) != 0 ]]; then
      echo "${TEXTOAMARELO} Build com problemas ${NORMAL} "
        ./Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh
      exit $validaTravis
    fi
