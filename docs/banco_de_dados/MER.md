
## ENTIDADES
**Fisioterapeuta** (idFisio, nomeFisio)

**Paciente** (idPaciente, cpfPaciente, nomePaciente, numeroSessoes, dataNascimento, {telefone})

**Movimento** (idMovimento, nomeMovimento, descricao, movimentoExecutor, graficoResultado, rotuloMovimento)

**Musculo** (idMusculo, nomeMusculo)

**Sessao** (idSessao, dataSessao)


## RELACIONAMENTOS
**fisioterapeuta** -- atende -- **paciente** <br />
_Um fisioterapeuta atende vários pacientes, assim como um paciente pode se consultar com vários
fisioterapeutas._ (cardinalidade n:m)  <br />

**movimento** -- trabalha -- **musculo** <br />
_Um movimento estimula, obrigatoriamente, um ou mais músculos._ (cardinalidade 1:n) <br />

**movimento** -- baseia -- **movimento** <br />
_O movimento, realizado pelo paciente, é baseado num movimento ideal, sendo este o cadastrado pelo fisioterapeuta._ (cardinalidade 1:1)  <br />

**pessoa** -- pratica -- **movimento** <br />
_Uma pessoa pratica, otimamente ou não, um ou vários movimentos._ (cardinalidade 1:n)  <br />

**sessao** -- possui -- **movimento** <br />
_Numa sessão, múltiplos movimentos são realizados_ (cardinalidade 1:n)

**sessao** -- possui -- **paciente** <br />
_Numa sessão, há necessariamente um paciente_ (cardinalidade 1:1)

**sessao** -- possui -- **fisioterapeuta** <br />
_Numa sessão, há necessariamente um fisioterapeuta_ (cardinalidade 1:1)
