insert into PESSOA (nomePessoa, sexo, dataNascimento, telefoneCelular) values 
('Joao Marcelo', 'M', '1954-10-09', '9999-4456'),
('Marcela Queiroz', 'F', '1973-04-01'),
('Danerys Targueri', 'F', '1991-06-06'),
('Carlos Paraiba', 'M', '2003-01-11');

insert into TELEFONE (idPessoa, telefone) values 
(1, '+55 61 9999-4456'),
(1, '+55 61 8699-4374'),
(2, '+55 61 9489-4205'),
(4, '+55 61 9066-4195');

insert into FISIOTERAPEUTA (idPessoa, login, senha, regiao, crefito) values (1, 'abcdef', '12213', 'DF', '11234567');
insert into FISIOTERAPEUTA (idPessoa, login, senha) values (3, 'qwerty', 'uiops');

insert into PACIENTE (idPessoa, observacoes) values 
(2, 'paciente extremamente debilitado, musculos muito rigidos - espasticidade grau 5'),
(4, 'paciente possui certa autonomia; entretanto falta sutileza nos movimentos - espasticidade grau 2');

insert into MUSCULO (nomeMusculo) values 
('bíceps'),
('ombro'),
('triceps'),
('antebraço');

insert into SESSAO (idFisioterapeuta, idPaciente, dataSessao) values 
(1, 2, '2017-02-02'),
(1, 2, '2017-02-09'),
(1, 2, '2017-02-16'),
(1, 2, '2017-02-23'),
(1, 2, '2017-03-03'),
(1, 1, '2017-03-03'),
(2, 1, '2017-03-04'),
(2, 1, '2017-03-14'),
(2, 1, '2017-03-24'); 


insert into MOVIMENTO (idFisioterapeuta, nomeMovimento, pontosMovimento) values 
(1, 'rosca martelo com halteres', 'MVtest1.txt'),
(2, 'barra fixa', 'MVtest2.txt'),
(2, 'triceps frances', 'MVtest3.txt');

insert into EXERCICIO (idPaciente, idMovimento, idSessao, pontosExercicio) values 
(1, 1, 1, 'EXtest1.txt'),
(1, 1, 2, 'EXtest2.txt'),
(2, 3, 3, 'EXtest3.txt'),
(1, 2, 4, 'EXtext4.txt');

insert into MOVIMENTOMUSCULO (idMusculo, idMovimento) values 
(1, 1),
(4, 1),
(1, 2),
(2, 2),
(4, 2),
(3, 3),
(4, 3);

insert into PONTOSROTULOFISIOTERAPEUTA (idMovimento, estagioMovimentoFisio, tempoInicial, tempoFinal) values
(1, 'braço estendido', 0, 0),
(1, 'contraindo musculo', 0, 10),
(1, 'musculo contraido', 10, 20),
(1, 'estendendo braço', 20, 30),
(1, 'braço estendido', 30, 40);

insert into PONTOSROTULOPACIENTE (idExercicio, estagioMovimentoPaciente, tempoInicial, tempoFinal) values
(1, 'braço estendido', 0, 0),
(1, 'contraindo musculo', 0, 10),
(1, 'musculo contraido', 10, 20),
(1, 'estendendo braço', 20, 30),
(1, 'braço estendido', 30, 40);
