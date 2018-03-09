<p align="justify"> &emsp;&emsp; </p>

## Blocos de comentários para linguagens C-like (C/C++/C#/Objective-C/PHP/Java)

<p align="justify"> &emsp;&emsp;Para cada entidade no código, existem dois (ou três, em alguns casos) tipos de descrição que, juntas, formam a documentação para aquela entidade:  uma breve descrição e uma descrição detalhada, ambas opcionais. Para métodos e funções também existe um terceiro tipo, que consiste na concatenação de todos os blocos de comentário encontrados entro do corpo do método ou da função.</p>

<p align="justify"> &emsp;&emsp;Ter mais de uma breve descrição ou descrição detalhada é permitido mas não recomendado, pois a ordem na qual as descrições vão ser dispostas não é especificada.</p>

<p align="justify"> &emsp;&emsp;Como o nome sugere, uma descrição breve deve ser curta, preferencialmente não excedendo uma linha, já que a descrição detalhada vai fornecer documentação mais detalhada. Uma descrição dentro do corpo do método ou função também pode ter características de uma descrição detalhada ou descrever um detalhe de implementação. No output HTML, breves descrições também são usadas para prover informações onde o item é referenciado.</p>

#### Existem diversos modos de marcar um comentário como uma descrição detalhada, mas vamos mostrar apenas um:

* Você pode usar o estilo JavaDoc, que consiste em um bloco de comentário C-style começando com dois asteriscos, como:
``` C++
/**
 * ... texto ...
 */
```

#### Para a descrição breve, existem várias possibilidades:

<p align="justify"> &emsp;&emsp;É possível usar o comando @brief com a possibilidade acima. Este comando termina com o fim do parágrafo, então a descrição detalhada segue após uma linha em branco.</p>

Por exemplo:
```C++
/** @brief Breve descrição.
 *         Breve descrição continua.
 *
 *  Descrição detalhada começa aqui.
 */
```
Se JAVADOC_AUTOBRIEF é setada para YES nos arquivos de configuração, então usar o estilo de comentário de bloco JavaDoc irá iniciar automaticamente uma breve descrição que termina no primeiro ponto final seguido de um espaço ou quebra de linha. Exemplo:

```C++
/** Breve descrição começa aqui e termina aqui. Descrição detalhada começa aqui
 *  e continua aqui.
 */
```

Aqui está o mesmo trecho de código mostrado acima, mas, dessa vez, documentado utilizando o estilo JavaDoc e com JAVADOC_AUTOBRIEF setado para YES:
```C++
/**
 *  Uma classe de testes. Uma descrição mais elaborada da classe de testes.
 */
class Javadoc_Test
{
  public:
    /**
     * Um enum.
     * Mais detalhes sobre o enum.
     */
    enum TEnum {
          TVal1, /**< valor TVal1. do enum */
          TVal2, /**< valor TVal2. do enum */
          TVal3  /**< valor TVal3. do enum */
         }
       *enumPtr, /**< Ponteiro do enum. Detalhes. */
       enumVar;  /**< Variável enum. Detalhes. */

      /**
       * Um construtor.
       * Uma desrição mais elaborada do construtor.
       */
      Javadoc_Test();
      /**
       * Um destrutor.
       * Uma descrição mais elaborada do destrutor.
       */
     ~Javadoc_Test();

      /**
       * Um membro normal pegando dois argumentos e retornando um valor inteiro.
       * @param a, um argumento int.
       * @param s, um ponteiro para const char.
       * @see Javadoc_Test()
       * @see ~Javadoc_Test()
       * @see testMeToo()
       * @see publicVar()
       * @return The test results
       */
       int testMe(int a,const char *s);

      /**
       * Um membro virtual puro.
       * @see testMe()
       * @param c1, o primeiro argumento.
       * @param c2, o segundo argumento.
       */
       virtual void testMeToo(char c1,char c2) = 0;

      /**
       * Uma variável pública.
       * Detalhes.
       */
       int publicVar;

      /**
       * Uma variável de função.
       * Detalhes.
       */
       int (*handler)(int a,int b);
};
```

#### Documentação em outros lugares

<p align="justify"> &emsp;&emsp;Nos exemplos da seção anterior, os blocos de comentário estavam sempre localizados na frente da declaração ou da definição de um arquivo, classe ou namespace ou na frente de um de seus membros. Entretanto, isso pode causar desconforto, já que há vezes em que há razões para se colocar a documentação em outro lugar. Para documentar um arquivos, isto é um requerimento, já que não existe como colocar um comentário "na frente de um arquivo".</p>

<p align="justify"> &emsp;&emsp;O Doxygen permite com que seja possível colocar seus blocos de documentação praticamente em qualquer lugar (a exceção é: dentro dos corpos das funções ou dentro de um bloco de comentário C-like).</p>

<p align="justify"> &emsp;&emsp;O preço que você paga por não colocar o bloco de documentação diretamente antes (ou depois) de um item é a necessidade de colocar um comando estrutural dentro do bloco de documentação, o que levaria a redundância de informação. Então, na prática, você deve evitar utilizar comandos estruturais a não ser que forças maiores exijam que isso seja feito.</p>

<p align="justify"> &emsp;&emsp;Comandos estruturais, tais como todos os outros comandos, começam com "\" ou "@", se você preferir o estilo JavaDoc, seguido do nome do comando e de um ou mais parâmetros. Por exemplo, se você deseja documentar a classe Test no exemplo acima, é possível inserir o bloco de documentação em qualquer outro lugar, desde que este sirva de input para ser lido pelo Doxygen:</p>

```C++
/** @class Test
 *  @brief Uma classe de testes.
 *
 *  Descrição mais detalhada sobre a classe.
 */
```
<p align="justify"> &emsp;&emsp;Aqui, o comando especial \class é usado para indicar que o bloco de comentário contém documentação para a classe Test. Outros comandos estuturais são:</p>

* **@struct** para documentar uma struct C.
* **@union** para documentar uma union.
* **@enum** para documentar uma implementação enum.
* **@fn** para documentar uma função.
* **@var** para documentar uma variável ou typedef ou valor de enum.
* **@def** para documentar um #define.
* **@typedef** para documentar um typedef.
* **@file** para documentar um arquivo.
* **@namespace** para documentar um namespace.
* **@package** para documentar um pacote java.
* **@interface** para documentar uma interface IDL.

<p align="justify"> &emsp;&emsp;Veja a seção de Special Commands do Doxygen para mais informações sobre esses e outros comandos.</p>

<p align="justify"> &emsp;&emsp;Para documentar um membro de uma classe C++, você deve também documentar a classe inteira. O mesmo ocorre com namespaces. Para documentar uma função global do C, typedef, enum ou definição de preprocessor, você deve primeiro documentar o arquivo que a contém (normalmente isso será o header file, já que este é o arquivo que contém toda a informação que é exportada para outros arquivos fonte).</p>


#### Atenção

<p align="justify"> &emsp;&emsp;Let's repeat that, because it is often overlooked: to document global objects (functions, typedefs, enum, macros, etc), you must document the file in which they are defined. In other words, there must at least be a</p>

<p align="justify"> &emsp;&emsp; Vamos repetir isso, já que é comumente mal lido: para documentar um objeto global (funções, typedefs, enum, macros, etc), você deve documentar o arquivo no qual ele está definido. Em outras palavras, deve haver pelo menos um</p>

```C++
/** @file */
```

no arquivo.

<p align="justify"> &emsp;&emsp;Segue um exemplo de um header em C nomeado structcmd.h que é documentado pelo uso de comandos estruturais:</p>


```C++

/** @file structcmd.h
 *  @brief Um arquivo documentado.
 *
 *  Detalhes.
 */

/** @def MAX(a,b)
 *  @brief Uma macro que retorna o valor máximo de  "a" e "b".
 *
 *  Detalhes.
 */

/** @var typedef unsigned int UINT32
 *  @brief Uma breve descrição de "a" .
 *
 *  Details.
 */

/** @var int errno
 *  @brief Contém o último código de erro.
 *  @warning Não é seguro usar com threads!
 */

/** @fn int open(const char *pathname,int flags)
 *  @brief Abre um arquivo.
 *  @param pathname Nome/caminho do arquivo.
 *  @param flags Flags de abertura.
 */

/** @fn int close(int fd)
 *  @brief Fecha o arquivo e encerra sua leitura.
 *  @param fd referência ao arquivo que deve ser fechado.
 */

/** @fn size_t write(int fd,const char *buf, size_t count)
 *  @brief escreve "count" bytes de um buffer "buf" em um arquivo referenciado por "fd".
 *  @param fd Qual arquivo que será modificado.
 *  @param buf Buffer de dados a ser escrito.
 *  @param count Número de bytes a ser coletado do buffer e escrito no arquivo.
 */

/** @fn int read(int fd,char *buf,size_t count)
 *  @brief Lê bytes de um arquivo.
 *  @param fd Referência do arquivo a ser lido.
 *  @param buf Buffer a ser usado para manter os dados.
 *  @param count Número de bytes a serem lidos.
 */
#define MAX(a,b) (((a)>(b))?(a):(b))
typedef unsigned int UINT32;
int errno;
int open(const char *,int);
int close(int);
size_t write(int,const char *, size_t);
int read(int,char *,size_t);
```

<p align="justify"> &emsp;&emsp;Quando você coloca um bloco de comentário em um arquivo com uma das seguinte extensões: .dox, .txt ou .doc, o Doxygen irá remover este arquivo da lista de arquivos.</p>


<p align="justify"> &emsp;&emsp;If you have a file that doxygen cannot parse but still would like to document it, you can show it as-is using \verbinclude, e.g.</p>

<p align="justify"> &emsp;&emsp;Se você possui arquivos que o Doxygen não consegue identificar mas, mesmo assim, deseja documentá-lo, você pode mostrá-lo com o comando \verbinclude, por exemplo:</p>


```C++
/** @file myscript.sh
 *  Olhe este script interessante:
 *  @verbinclude myscript.sh
 */
```
