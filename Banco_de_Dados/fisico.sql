
CREATE DATABASE IF NOT EXISTS fisiotech;
USE fisiotech;


CREATE TABLE IF NOT EXISTS PESSOA (
	idPessoa BIGINT not null AUTO_INCREMENT,
	nomePessoa VARCHAR (30) not null,
	sexo CHAR (1) not null,
	dataNascimento DATE not null, 
	constraint PESSOA_PK primary key (idPessoa)
) ENGINE = innoDB;


CREATE TABLE IF NOT EXISTS TELEFONE (
	idPessoa BIGINT not null,
	telefone BIGINT not null,
	constraint TELEFONE_PK primary key (idPessoa),
	constraint TELEFONE_PESSOA_FK foreign key (idPessoa) references PESSOA (idPessoa)
) ENGINE = innoDB;


CREATE TABLE IF NOT EXISTS FISIOTERAPEUTA (
	idFisioterapeuta BIGINT not null AUTO_INCREMENT,
	idPessoa BIGINT not null,
	regiao VARCHAR (30),
	crefito VARCHAR (30),
	constraint FISIOTERAPEUTA_PK primary key (idFisioterapeuta),
	constraint FISIOTERAPEUTA_PESSOA_FK foreign key (idPessoa) references PESSOA (idPessoa)
) ENGINE = innoDB;


CREATE TABLE IF NOT EXISTS PACIENTE (
	idPaciente BIGINT not null AUTO_INCREMENT,
	idPessoa BIGINT not null,
	observacoes VARCHAR (300) not null,
	constraint PACIENTE_PK primary key (idPaciente),
	constraint PACIENTE_PESSOA_FK foreign key (idPessoa) references PESSOA (idPessoa)
) ENGINE = innoDB;


CREATE TABLE IF NOT EXISTS MUSCULO (
	idMusculo BIGINT not null AUTO_INCREMENT,
	nomeMusculo VARCHAR (20) not null,
	constraint MUSCULO_PK primary key (idMusculo)
) ENGINE = innoDB;


CREATE TABLE IF NOT EXISTS MOVIMENTO (
	idMovimento BIGINT not null AUTO_INCREMENT,
	idPessoa BIGINT not null,
	nomeMovimento VARCHAR (50) not null,
	graficoResultado VARCHAR (256) not null,
	movimentoExecutor VARCHAR (256) not null,
	rotuloMovimento VARCHAR (256) not null,
	constraint MOVIMENTO_PK primary key (idMovimento),
	constraint MOVIMENTO_PESSOA_FK foreign key (idPessoa) references PESSOA (idPessoa)
) ENGINE = innoDB;


CREATE TABLE IF NOT EXISTS MOVIMENTOMUSCULO (
	idMusculo BIGINT not null,
	idMovimento BIGINT not null,
	constraint MOVIMENTOMUSCULO_PK primary key (idMusculo, idMovimento),
	constraint MOVIMENTOMUSCULO_MOVIMENTO_FK foreign key (idMovimento) references MOVIMENTO (idMovimento),
	constraint MOVIMENTOMUSCULO_MUSCULO_FK foreign key (idMusculo) references MUSCULO (idMusculo)
) ENGINE = innoDB;


CREATE TABLE IF NOT EXISTS SESSAO (
	idSessao BIGINT not null AUTO_INCREMENT,
	idFisioterapeuta BIGINT not null,
	idPaciente BIGINT not null,
	dataSessao DATE not null,
	constraint SESSAO_PK primary key (idSessao),
	constraint SESSAO_PACIENTE_FK foreign key (idPaciente) references PACIENTE (idPaciente),
	constraint SESSAO_FISIOTERAPEUTA_FK foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta)
) ENGINE = innoDB;

/*
CREATE TABLE IF NOT EXISTS possui (
	idSessao BIGINT not null,
	idPaciente BIGINT not null,
	constraint possui_SESSAO_FK foreign key (idSessao) references SESSAO (idSessao),
	constraint possui_PACIENTE_FK foreign key (idPaciente) references PACIENTE (idPaciente)
) ENGINE = innoDB;

CREATE TABLE IF NOT EXISTS possui (
	idSessao BIGINT not null,
	idFisioterapeuta BIGINT not null,
	constraint possui_SESSAO_FK foreign key (idSessao) references SESSAO (idSessao),
	constraint possui_FISIOTERAPEUTA_FK foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta)
) ENGINE = innoDB;

CREATE TABLE IF NOT EXISTS possui (
	idSessao BIGINT not null,
	idMovimento BIGINT not null,
	constraint possui_SESSAO_FK foreign key (idSessao) references SESSAO (idSessao),
	constraint possui_MOVIMENTO_FK foreign key (idMovimento) references MOVIMENTO (idMovimento)
) ENGINE = innoDB;

CREATE TABLE IF NOT EXISTS cadastra (
	idFisioterapeuta BIGINT not null,
	idMovimento BIGINT not null,
	constraint cadastra_FISIOTERAPEUTA_FK foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta),
	constraint cadastra_MOVIMENTO_FK foreign key (idMovimento) references MOVIMENTO (idMovimento)
) ENGINE = innoDB;

CREATE TABLE IF NOT EXISTS pratica (
	idPaciente BIGINT not null,
	idMovimento BIGINT not null,
	constraint pratica_PACIENTE_FK foreign key (idPaciente) references PACIENTE (idPaciente),
	constraint pratica_MOVIMENTO_FK foreign key (idMovimento) references MOVIMENTO (idMovimento)
) ENGINE = innoDB;

CREATE TABLE IF NOT EXISTS atende (
	idFisioterapeuta BIGINT not null,
	idPaciente BIGINT not null,
	constraint atende_FISIOTERAPEUTA_FK foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta),
	constraint atende_PACIENTE_FK foreign key (idPaciente) references PACIENTE (idPaciente)
) ENGINE = innoDB;

CREATE TABLE IF NOT EXISTS baseia (
	idMovimento BIGINT not null,
	constraint atende_FISIOTERAPEUTA_FK foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta),
	constraint atende_PACIENTE_FK foreign key (idPaciente) references PACIENTE (idPaciente)
) ENGINE = innoDB;
*/