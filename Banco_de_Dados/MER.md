
## ENTIDADES
**Fisioterapeuta** (idFisio, nomeFisio)

**Paciente** (idPaciente, cpfPaciente, nomePaciente, numeroSessoes, dataNascimento, {telefone})

**Movimento** (idMovimento, nomeMovimento, musculosTrabalhados, movimentoIdeal, graficoResultadoIdeal)

**Exercicio** (idExercicio,  movimentoPaciente, graficoResultadoExercicio, rotulos)

**Sessao** (idSessao, dataSessao)


## RELACIONAMENTOS
**fisioterapeuta** -- atende -- **paciente** <br />
_Um fisioterapeuta atende vários pacientes, assim como um paciente pode se consultar com vários
fisioterapeutas._ (cardinalidade n:m)  <br />

**fisioterapeuta** -- realiza -- **movimento**  <br />
_O fisioterapeuta é responsável por popular o banco de dados com os movimentos ideais_ (cardinalidade 1:n)  <br />

**exercicio** -- reproduz -- **movimento** <br />
_Vários exercícios, sendo estes realizados pelo paciente, reproduzem um mesmo movimento._ (cardinalidade 1:n)  <br />

**paciente** -- pratica -- **exercicio** <br />
_Um paciente, numa sessão, pratica um ou vários exercícios._ (cardinalidade 1:n)  <br />

**sessao** -- possui -- **exercicios** <br />
_Numa sessão, múltiplos exercícios são realizados_ (cardinalidade 1:n)

**sessao** -- possui -- **paciente** <br />
_Numa sessão, há necessariamente um paciente_ (cardinalidade 1:1)

**sessao** -- possui -- **fisioterapeuta** <br />
_Numa sessão, há necessariamente um fisioterapeuta_ (cardinalidade 1:1)
