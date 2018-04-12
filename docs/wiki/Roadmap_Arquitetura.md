## Histórico de Revisão

|    Data    | Versão |                             Alteração                             |                    Autor                    |
|:----------:|:------:|:-----------------------------------------------------------------:|:-------------------------------------------:|
| 11/04/2018 |   0.1  | Criação do documento  | Vitor Falcão |

---

## Release 1

### Elaboração do documento de arquitetura

### Treinamento de arquitetura de componentes

- Com o objetivo de mitigar um risco de nível técnico, será feito um treinamento para o time de desenvolvimento sobre a arquitetura utilizada pelo Unity.

### Elaboração de uma arquitetura flexível

- A questão da elaboração da arquitetura flexível se refere à possibilidade de conexão do software em relação à conexão com os sensores específicos e o Kinect.

### Decisão da extensão/padrão de arquivo para store local dos movimentos

- Para evitar um overhead do banco de dados podendo gerar inconsistências nós utilizaremos arquivos binários para salvar os pontos (x, y) de um movimento, gerando uma função simples y = f(x) para gerar os gráficos de movimentação.

### Criação de um banco de dados local

- Criação de todos os níveis de um banco de dados, desde o conceitual ao físico. Níveis: ME-R, DE-R, Físico (criação do database e das tabelas), e o Seed (arquivo para popular o banco).

### Criação de um mock de dados de entrada

- A criação de um mock de dados que simulam os resultados vindos dos sensores utilizados e até mesmo o Kinect.

### Testes Unity

---

## Release 2

### Recebimento de dados reais

- Com a intenção de deixar o produto mais próximo de fase de produção final, faremos a integração do software com os sensores e poderemos testá-lo com dados advindos deles.

### Análise da arquitetura

- Neste ponto já teremos muitas coisas arquitetadas e implementadas, junto ao time de desenvolvimento o arquiteto fará uma análise com eles para identificar possíveis problemas e gargalos tendo como foco a expansibilidade e flexibilidade do software.

### Backup local dos dados

- Uma opção de backup dos dados locais, tanto do banco de dados quanto os movimentos salvos em arquivos binários, possibiltando uma maior confiança e segurançca do software e a possível transferência de dados entre duas máquinas.