
## ENTIDADES
**Pessoa** (idPessoa, nomePessoa, sexo, dataNascimento, {telefone})

**Fisioterapeuta** (idFisioterapeuta, crefito, regiao)

**Paciente** (idPaciente, observacoes)

**Movimento** (idMovimento, nomeMovimento, descricaoMovimento, movimentoFisioterapeuta, graficoResultadoIdeal, rotuloMovimentoFisioterapeuta)

**Exercicio** (idExercicio, descricaoExercicio, movimentoPaciente, graficoResultadoPaciente, rotuloMovimentoPaciente)

**Musculo** (idMusculo, nomeMusculo)

**Sessao** (idSessao, dataSessao)


## RELACIONAMENTOS
**Pessoa** especializa totalmente em **Fisioterapeuta** ou **Paciente**, pois ambas as entidades compartilham vários atributos em comum.

**movimento** -- estimula -- **musculo** <br />
_Um movimento estimula, obrigatoriamente, um ou mais músculos; e, um musculo, é estimulado por vários tipos de movimentos._ (cardinalidade n:m) <br />

**movimento** -- baseia -- **exercicio** <br />
_O exercicio, realizado pelo paciente, é baseado num movimento ideal._ (cardinalidade 1:n)  <br />

**fisioterapeuta** -- cadastra -- **movimento** <br />
_Um fisioterapeuta cadastra um ou vários movimentos._ (cardinalidade 1:n)  <br />

**paciente** -- realiza -- **exercicio** <br />
_Um paciente realiza um ou vários movimentos._ (cardinalidade 1:n)  <br />

**sessao** -- possui -- **exercicio** <br />
_Numa sessão, múltiplos exercícios são realizados._ (cardinalidade 1:n)

**paciente** -- participa -- **sessao** <br />
_Um paciente participa de uma ou várias sessões._ (cardinalidade 1:n)

**fisioterapeuta** -- conduz -- **sessao** <br />
_Um fisioterapeuta conduz uma ou variás sessões._ (cardinalidade 1:n)
