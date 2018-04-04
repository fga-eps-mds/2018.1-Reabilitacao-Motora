
CREATE DATABASE IF NOT EXISTS fisiotech;
USE fisiotech;


CREATE TABLE IF NOT EXISTS PESSOA (
	idPessoa INTEGER PRIMARY KEY AUTOINCREMENT,
	nomePessoa VARCHAR (30) not null,
	sexo CHAR (1) not null,
	dataNascimento DATE not null
);


CREATE TABLE IF NOT EXISTS TELEFONE (
	idPessoa INTEGER not null,
	telefone INTEGER not null,
	primary key (idPessoa, telefone),
	foreign key (idPessoa) references PESSOA (idPessoa)
);


CREATE TABLE IF NOT EXISTS FISIOTERAPEUTA (
	idFisioterapeuta INTEGER PRIMARY KEY AUTOINCREMENT,
	idPessoa INTEGER not null,
	regiao VARCHAR (2),
	crefito INTEGER,
	foreign key (idPessoa) references PESSOA (idPessoa)
);


CREATE TABLE IF NOT EXISTS PACIENTE (
	idPaciente INTEGER PRIMARY KEY AUTOINCREMENT,
	idPessoa INTEGER not null,
	observacoes VARCHAR (300) not null,
	foreign key (idPessoa) references PESSOA (idPessoa)
);


CREATE TABLE IF NOT EXISTS MUSCULO (
	idMusculo INTEGER PRIMARY KEY AUTOINCREMENT,
	nomeMusculo VARCHAR (20) not null
);


CREATE TABLE IF NOT EXISTS MOVIMENTO (
	idMovimento INTEGER PRIMARY KEY AUTOINCREMENT,
	idMovimentoPai INTEGER,
	idPessoa INTEGER not null,
	nomeMovimento VARCHAR (50),
	graficoResultado VARCHAR (256),
	movimentoExecutor VARCHAR (256),
	rotuloMovimento VARCHAR (256),
	foreign key (idMovimentoPai) references MOVIMENTO (idMovimento),
	foreign key (idPessoa) references PESSOA (idPessoa)
);


CREATE TABLE IF NOT EXISTS MOVIMENTOMUSCULO (
	idMusculo INTEGER not null,
	idMovimento INTEGER not null, 
	primary key (idMusculo, idMovimento),
	foreign key (idMovimento) references MOVIMENTO (idMovimento),
	foreign key (idMusculo) references MUSCULO (idMusculo)
);


CREATE TABLE IF NOT EXISTS SESSAO (
	idSessao INTEGER PRIMARY KEY AUTOINCREMENT,
	idFisioterapeuta INTEGER not null,
	idPaciente INTEGER not null,
	dataSessao DATE not null,
	foreign key (idPaciente) references PACIENTE (idPaciente),
	foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta)
);
