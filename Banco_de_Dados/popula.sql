USE fisiotech;

insert into PESSOA (nomePessoa, sexo, dataNascimento) values ('Joao Marcelo', 'M', '1954-10-09');
insert into PESSOA (nomePessoa, sexo, dataNascimento) values ('Marcela Queiroz', 'F', '1973-04-01');
insert into PESSOA (nomePessoa, sexo, dataNascimento) values ('Danerys Targueri', 'F', '1991-06-06');
insert into PESSOA (nomePessoa, sexo, dataNascimento) values ('Carlos Paraiba', 'M', '2003-01-11');

insert into TELEFONE (idPessoa, telefone) values (1, 6199994456);
insert into TELEFONE (idPessoa, telefone) values (1, 6186994374);
insert into TELEFONE (idPessoa, telefone) values (2, 6194894205);
insert into TELEFONE (idPessoa, telefone) values (4, 6190664195);

insert into FISIOTERAPEUTA (idPessoa, regiao, crefito) values (1, 'DF', 11234567);
insert into FISIOTERAPEUTA (idPessoa) values (3);

insert into PACIENTE (idPessoa, observacoes) values (2, 'paciente extremamente debilitado, musculos muito rigidos - espasticidade grau 5');
insert into PACIENTE (idPessoa, observacoes) values (4, 'paciente possui certa autonomia; entretanto falta sutileza nos movimentos - espasticidade grau 2');

insert into MUSCULO (nomeMusculo) values ('bíceps');
insert into MUSCULO (nomeMusculo) values ('ombro');
insert into MUSCULO (nomeMusculo) values ('triceps');
insert into MUSCULO (nomeMusculo) values ('antebraço');

insert into MOVIMENTO (idPessoa, nomeMovimento) values (1, 'rosca martelo com halteres');
insert into MOVIMENTO (idPessoa, nomeMovimento) values (1, 'barra fixa');
insert into MOVIMENTO (idPessoa, nomeMovimento) values (3, 'triceps frances');
insert into MOVIMENTO (idPessoa, idMovimentoPai) values (2, 1);
insert into MOVIMENTO (idPessoa, idMovimentoPai) values (2, 3);
insert into MOVIMENTO (idPessoa, idMovimentoPai) values (4, 2);

insert into MOVIMENTOMUSCULO (idMusculo, idMovimento) values (1, 1);
insert into MOVIMENTOMUSCULO (idMusculo, idMovimento) values (4, 1);
insert into MOVIMENTOMUSCULO (idMusculo, idMovimento) values (1, 2);
insert into MOVIMENTOMUSCULO (idMusculo, idMovimento) values (2, 2);
insert into MOVIMENTOMUSCULO (idMusculo, idMovimento) values (4, 2);
insert into MOVIMENTOMUSCULO (idMusculo, idMovimento) values (3, 3);
insert into MOVIMENTOMUSCULO (idMusculo, idMovimento) values (4, 3);

insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (1, 2, '2017-02-02'); 
insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (1, 2, '2017-02-09'); 
insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (1, 2, '2017-02-16'); 
insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (1, 2, '2017-02-23'); 
insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (1, 2, '2017-03-03'); 
insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (1, 1, '2017-03-03');
insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (2, 1, '2017-03-04'); 
insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (2, 1, '2017-03-14'); 
insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values (2, 1, '2017-03-24'); 
