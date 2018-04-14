using System;
using UnityEngine;

namespace DataBaseTables {
    /**
    * Essa classe nomeia as colunas da relação
    */
    public class TableNameColumn
    {
        [System.Serializable]
        public class MultiDimensionalString
        {
            public string tableName;
            public string[] colName;
            public int Length {
                get {return colName.Length;}
            }
        }

        public MultiDimensionalString[] TABLES = new MultiDimensionalString[11];

        /**
        * Cada coluna da relação recebe um respectivo nome.
        */
        public TableNameColumn()
        {
            TABLES[0] = new MultiDimensionalString();
            TABLES[0].colName = new string[4];
            TABLES[0].tableName = "PESSOA";
            TABLES[0].colName[0] = "idPessoa";
            TABLES[0].colName[1] = "nomePessoa";
            TABLES[0].colName[2] = "sexo";
            TABLES[0].colName[3] = "dataNascimento";

            TABLES[1] = new MultiDimensionalString();
            TABLES[1].colName = new string[2];
            TABLES[1].tableName = "TELEFONE";
            TABLES[1].colName[0] = "idPessoa";
            TABLES[1].colName[1] = "telefone";

            TABLES[2] = new MultiDimensionalString();
            TABLES[2].colName = new string[4];
            TABLES[2].tableName = "FISIOTERAPEUTA";
            TABLES[2].colName[0] = "idFisioterapeuta";
            TABLES[2].colName[1] = "idPessoa";
            TABLES[2].colName[2] = "regiao";
            TABLES[2].colName[3] = "crefito";

            TABLES[3] = new MultiDimensionalString();
            TABLES[3].colName = new string[3];
            TABLES[3].tableName = "PACIENTE";
            TABLES[3].colName[0] = "idPaciente";
            TABLES[3].colName[1] = "idPessoa";
            TABLES[3].colName[2] = "observacoes";

            TABLES[4] = new MultiDimensionalString();
            TABLES[4].colName = new string[2];
            TABLES[4].tableName = "MUSCULO";
            TABLES[4].colName[0] = "idMusculo";
            TABLES[4].colName[1] = "nomeMusculo";

            TABLES[5] = new MultiDimensionalString();
            TABLES[5].colName = new string[5];
            TABLES[5].tableName = "MOVIMENTO";
            TABLES[5].colName[0] = "idMovimento";
            TABLES[5].colName[1] = "idFisioterapeuta";
            TABLES[5].colName[2] = "nomeMovimento";
            TABLES[5].colName[3] = "descricaoMovimento";
            TABLES[5].colName[4] = "pontosMovimento";

            TABLES[6] = new MultiDimensionalString();
            TABLES[6].colName = new string[5];
            TABLES[6].tableName = "SESSAO";
            TABLES[6].colName[0] = "idSessao";
            TABLES[6].colName[1] = "idFisioterapeuta";
            TABLES[6].colName[2] = "idPaciente";
            TABLES[6].colName[3] = "dataSessao";
            TABLES[6].colName[4] = "observacaoSessao";

            TABLES[7] = new MultiDimensionalString();
            TABLES[7].colName = new string[6];
            TABLES[7].tableName = "EXERCICIO";
            TABLES[7].colName[0] = "idExercicio";
            TABLES[7].colName[1] = "idPaciente";
            TABLES[7].colName[2] = "idMovimento";
            TABLES[7].colName[3] = "idSessao";
            TABLES[7].colName[4] = "descricaoExercicio";
            TABLES[7].colName[5] = "pontosExercicio";

            TABLES[8] = new MultiDimensionalString();
            TABLES[8].colName = new string[2];
            TABLES[8].tableName = "MOVIMENTOMUSCULO";
            TABLES[8].colName[0] = "idMusculo";
            TABLES[8].colName[1] = "idMovimento";

            TABLES[9] = new MultiDimensionalString();
            TABLES[9].colName = new string[5];
            TABLES[9].tableName = "PONTOSROTULOFISIOTERAPEUTA";
            TABLES[9].colName[0] = "idRotuloFisioterapeuta";
            TABLES[9].colName[1] = "idMovimento";
            TABLES[9].colName[2] = "estagioMovimentoFisio";
            TABLES[9].colName[3] = "tempoInicial";
            TABLES[9].colName[4] = "tempoFinal";

            TABLES[10] = new MultiDimensionalString();
            TABLES[10].colName = new string[5];
            TABLES[10].tableName = "PONTOSROTULOPACIENTE";
            TABLES[10].colName[0] = "idRotuloPaciente";
            TABLES[10].colName[1] = "idExercicio";
            TABLES[10].colName[2] = "estagioMovimentoPaciente";
            TABLES[10].colName[3] = "tempoInicial";
            TABLES[10].colName[4] = "tempoFinal";
        }
    }
}
