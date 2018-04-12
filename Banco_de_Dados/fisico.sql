
CREATE DATABASE IF NOT EXISTS fisiotech;
USE fisiotech;


CREATE TABLE IF NOT EXISTS PESSOA (
	idPessoa INTEGER primary key AUTOINCREMENT,
	nomePessoa VARCHAR (30) not null,
	sexo CHAR (1) not null,
	dataNascimento DATE not null
);


CREATE TABLE IF NOT EXISTS TELEFONE (
	idPessoa INTEGER not null,
	telefone VARCHAR (18) not null,
	foreign key (idPessoa) references PESSOA (idPessoa),
	primary key (idPessoa, telefone)
);


CREATE TABLE IF NOT EXISTS FISIOTERAPEUTA (
	idFisioterapeuta INTEGER primary key AUTOINCREMENT,
	idPessoa INTEGER not null,
	regiao VARCHAR (2),
	crefito VARCHAR (10),
	foreign key (idPessoa) references PESSOA (idPessoa),
	constraint crefito_regiao UNIQUE (crefito, regiao)
);


CREATE TABLE IF NOT EXISTS PACIENTE (
	idPaciente INTEGER primary key AUTOINCREMENT,
	idPessoa INTEGER not null,
	observacoes VARCHAR (300),
	foreign key (idPessoa) references PESSOA (idPessoa)
);


CREATE TABLE IF NOT EXISTS MUSCULO (
	idMusculo INTEGER primary key AUTOINCREMENT,
	nomeMusculo VARCHAR (20) not null
);


CREATE TABLE IF NOT EXISTS MOVIMENTO (
	idMovimento INTEGER primary key AUTOINCREMENT,
	idFisioterapeuta INTEGER not null,
	nomeMovimento VARCHAR (50) not null,
	descricaoMovimento VARCHAR (150),
	graficoResultadoFisioterapeuta VARCHAR (256),
	movimentoFisioterapeuta VARCHAR (256),
	rotuloMovimentoFisioterapeuta VARCHAR (256),
	foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta)
);

CREATE TABLE IF NOT EXISTS SESSAO (
	idSessao INTEGER primary key AUTOINCREMENT,
	idFisioterapeuta INTEGER not null,
	idPaciente INTEGER not null,
	dataSessao DATE not null,
	foreign key (idPaciente) references PACIENTE (idPaciente),
	foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta)
);

CREATE TABLE IF NOT EXISTS EXERCICIO (
	idExercicio INTEGER primary key AUTOINCREMENT,
	idPaciente INTEGER not null,
	idMovimento INTEGER not null,
	idSessao INTEGER not null,
	descricaoExercicio VARCHAR (150),
	graficoResultadoPaciente VARCHAR (256),
	movimentoPaciente VARCHAR (256),
	rotuloMovimentoPaciente VARCHAR (256),
	foreign key (idSessao) references SESSAO (idSessao),
	foreign key (idMovimento) references MOVIMENTO (idMovimento),
	foreign key (idPaciente) references PACIENTE (idPaciente)
);


CREATE TABLE IF NOT EXISTS MOVIMENTOMUSCULO (
	idMusculo INTEGER not null,
	idMovimento INTEGER not null, 
	foreign key (idMovimento) references MOVIMENTO (idMovimento),
	foreign key (idMusculo) references MUSCULO (idMusculo),
	primary key (idMusculo, idMovimento)
);

