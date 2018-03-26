
## ENTIDADES
**Fisioterapeuta** (idFisio, nomeFisio)

**Paciente** (idPaciente, nomePaciente, numeroSessoe, dataNascimento, {telefone})

**Movimento** (idMovimento, nomeMovimento, musculosTrabalhados, movimentoIdeal, graficoResultadoIdeal)

**Exercicio** (idExercicio, movimentoPaciente, graficoResultadoExercicio)

**Sessao** (idSessao, dataSessao)


## RELACIONAMENTOS
**fisioterapeuta** -- atende -- **paciente** <br />
_Um fisioterapeuta atende vários pacientes, assim como um paciente pode se consultar com vários
fisioterapeutas._ (cardinalidade n:m)  <br />

**exercicio** -- reproduz -- **movimento** <br />
_Vários exercícios reproduzem um mesmo movimento._ (cardinalidade 1:n)  <br />

**paciente** -- pratica -- **exercicio** <br />
_Um paciente, numa sessão, pratica um ou vários exercícios._ (cardinalidade 1:n)  <br />

**sessao** -- possui -- **exercicios** <br />
_Numa sessão, múltiplos exercícios são realizados_ (cardinalidade 1:n)
