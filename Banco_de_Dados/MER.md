
## ENTIDADES
**Pessoa** (idPessoa, nomePessoa, sexo, dataNascimento, {telefone})

**Fisioterapeuta** (idFisioterapeuta, crefito, regiao)

**Paciente** (idPaciente, observacoes)

**Movimento** (idMovimento, nomeMovimento, descricaoMovimento)

**Exercicio** (idExercicio, descricaoExercicio)

**Musculo** (idMusculo, nomeMusculo)

**Sessao** (idSessao, dataSessao, observacaoSessao)

**Pontos Movimento Fisioterapeuta** (idMovimentoFisioterapeuta, movimentoFisioPosX, movimentoFisioPosY)

**Pontos Rotulo Fisioterapeuta** (idRotuloFisioterapeuta, rotuloFisioPosXinicial, rotuloFisioPosYfinal, estagioMovimentoFisio)

**Pontos Movimento Paciente** (idMovimentoPaciente, movimentoPacientePosX, movimentoPacientePosY)

**Pontos Rotulo Paciente** (idRotuloPaciente, rotuloPacientePosXinicial, rotuloPacientePosYfinal, estagioMovimentoPaciente)

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

**movimento** -- gera -- **pontos movimento fisioterapeuta** <br />
_Um movimento gera n pontos nos eixos x e y._ (cardinalidade 1:n)

**movimento** -- gera -- **pontos rotulo fisioterapeuta** <br />
_Um movimento gera n pontos nos eixos x e y._ (cardinalidade 1:n)

**exercicio** -- gera -- **pontos movimento paciente** <br />
_Um exercicio gera n pontos nos eixos x e y._ (cardinalidade 1:n)

**exercicio** -- gera -- **pontos rotulo paciente** <br />
_Um exercicio gera n pontos nos eixos x e y._ (cardinalidade 1:n)
