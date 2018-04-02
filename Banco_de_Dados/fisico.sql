
CREATE DATABASE IF NOT EXISTS fisiotech;
USE fisiotech;

CREATE TABLE IF NOT EXISTS PESSOA (
	idPessoa BIGINT 		NOT NULL,
	nomePessoa VARCHAR(30) 		NOT NULL,
	sexo CHAR(1) 			NOT NULL,
	dataNascimento DATE 		NOT NULL, 
	constraint PESSOA_PK PRIMARY KEY (idPessoa)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS TELEFONE (
	idPessoa BIGINT 		NOT NULL,
	telefone BIGINT 		NOT NULL,
	constraint TELEFONE_PK PRIMARY KEY (idPessoa),
	constraint TELEFONE_PESSOA_FK FOREIGN KEY (idPessoa) REFERENCES PESSOA (idPessoa)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS FISIOTERAPEUTA (
	idFisioterapeuta BIGINT 	NOT NULL,
	regiao VARCHAR(30) 		NOT NULL,
	crefito VARCHAR(30) 		NOT NULL,
	constraint FISIOTERAPEUTA_PK PRIMARY KEY (idFisioterapeuta),
	constraint FISIOTERAPEUTA_PESSOA_FK FOREIGN KEY (idPessoa) REFERENCES PESSOA (idPessoa)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS PACIENTE (
	idPaciente BIGINT 		NOT NULL,
	observacoes VARCHAR(30) 	NOT NULL,
	constraint PACIENTE_PK PRIMARY KEY (idPaciente),
	constraint PACIENTE_PESSOA_FK FOREIGN KEY (idPessoa) REFERENCES PESSOA (idPessoa)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS MOVIMENTO (
	idMovimento BIGINT 		NOT NULL,
	nomeMovimento VARCHAR(50) 	NOT NULL,
	graficoResultado VARCHAR(256) 	NOT NULL,
	movimentoExecutor VARCHAR(256) 	NOT NULL,
	rotuloMovimento VARCHAR(256) 	NOT NULL,
	musculosTrabalhados VARCHAR(50) NOT NULL,
	constraint MOVIMENTO_PK PRIMARY KEY (idMovimento)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS SESSAO (
	idSessao BIGINT		 	NOT NULL,
	dataSessao DATE 		NOT NULL,
	constraint SESSAO_PK PRIMARY KEY (idSessao)
)ENGINE=innoDB;

/*
CREATE TABLE IF NOT EXISTS possui (
	idSessao BIGINT 	NOT NULL,
	idPaciente BIGINT 	NOT NULL,
	constraint possui_SESSAO_FK FOREIGN KEY (idSessao) REFERENCES SESSAO (idSessao),
	constraint possui_PACIENTE_FK FOREIGN KEY (idPaciente) REFERENCES PACIENTE (idPaciente)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS possui (
	idSessao BIGINT		  NOT NULL,
	idFisioterapeuta BIGINT	  NOT NULL,
	constraint possui_SESSAO_FK FOREIGN KEY (idSessao) REFERENCES SESSAO (idSessao),
	constraint possui_FISIOTERAPEUTA_FK FOREIGN KEY (idFisioterapeuta) REFERENCES FISIOTERAPEUTA (idFisioterapeuta)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS possui (
	idSessao BIGINT		  NOT NULL,
	idMovimento BIGINT	  NOT NULL,
	constraint possui_SESSAO_FK FOREIGN KEY (idSessao) REFERENCES SESSAO (idSessao),
	constraint possui_MOVIMENTO_FK FOREIGN KEY (idMovimento) REFERENCES MOVIMENTO (idMovimento)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS cadastra (
	idFisioterapeuta BIGINT 	NOT NULL,
	idMovimento BIGINT 		NOT NULL,
	constraint cadastra_FISIOTERAPEUTA_FK FOREIGN KEY (idFisioterapeuta) REFERENCES FISIOTERAPEUTA (idFisioterapeuta),
	constraint cadastra_MOVIMENTO_FK FOREIGN KEY (idMovimento) REFERENCES MOVIMENTO (idMovimento)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS pratica (
	idPaciente BIGINT	  NOT NULL,
	idMovimento BIGINT  	  NOT NULL,
	constraint pratica_PACIENTE_FK FOREIGN KEY (idPaciente) REFERENCES PACIENTE (idPaciente),
	constraint pratica_MOVIMENTO_FK FOREIGN KEY (idMovimento) REFERENCES MOVIMENTO (idMovimento)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS atende (
	idFisioterapeuta BIGINT	  NOT NULL,
	idPaciente BIGINT	  NOT NULL,
	constraint atende_FISIOTERAPEUTA_FK FOREIGN KEY (idFisioterapeuta) REFERENCES FISIOTERAPEUTA (idFisioterapeuta),
	constraint atende_PACIENTE_FK FOREIGN KEY (idPaciente) REFERENCES PACIENTE (idPaciente)
)ENGINE=innoDB;

CREATE TABLE IF NOT EXISTS baseia (
	idMovimento BIGINT	  NOT NULL,
	constraint atende_FISIOTERAPEUTA_FK FOREIGN KEY (idFisioterapeuta) REFERENCES FISIOTERAPEUTA (idFisioterapeuta),
	constraint atende_PACIENTE_FK FOREIGN KEY (idPaciente) REFERENCES PACIENTE (idPaciente)
)ENGINE=innoDB;
*/