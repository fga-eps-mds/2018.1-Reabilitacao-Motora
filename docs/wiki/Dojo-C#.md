# Histórico de Versões

Data|Versão|Descrição|Autor
-|-|-|-
08/03/2018|0.0.0|Criação da Introdução, Instalação, Scripts como Comportamento de Componentes e Criando Scripts no Unity |Arthur Diniz
09/03/2018|0.0.1| Criação de Variáveis, Funções, Estruturas Condicionais e Loops   ... |Arthur Diniz


## 0. Summary

[1. Introdução](#1-introdução)

[2. Instalação](#2-instalação)

[3. Script](#3-script)

-----

## 1. Introdução

<p align="justify"> &emsp;&emsp;Unity é um motor de jogo multi-plataforma desenvolvido pela Unity Technologies, que é usado principalmente para desenvolver jogos 3D e 2D e simulações para computadores, consoles e dispositivos móveis. Primeiro anunciado apenas para OS X na Conferência Mundial de Desenvolvedores da Apple em 2005, desde então foi estendido para atingir 27 plataformas. Foram lançadas seis versões principais do Unity.</p>

## 2. Instalação

[Download Unity](https://store.unity.com/download?ref=personal)

## 3. Script

![software](https://user-images.githubusercontent.com/18387694/37229367-7fba7af8-23c2-11e8-807d-d4d0b0ce31fa.jpg)

### 3.1 Scripts como Comportamento de Componentes

#### 3.1.1 Introdução a Scripts

<p align="justify"> &emsp;&emsp;Os scripts devem ser considerados como **componentes de comportamento**, assim como outros objetos no Unity eles podem aplicados em objetos no _inspector_. Com o script é possível acessar variáveis de rotação, translação, posição, entre outras de um objeto.</p>

<p align="justify"> &emsp;&emsp;No trecho de código abaixo podemos observar que quando uma tecla for apertada o objeto irá mudar de cor. Teclas correspondentes às seguintes cores: R =  red(vermelho), G = green(verde), B = blue(azul).</p>

<img src="https://user-images.githubusercontent.com/18387694/37173598-cbf5cc7c-22f2-11e8-8fb3-1a40f59f4bee.png">

#### 3.1.2 Criando Scripts no Unity
<p align="justify"> &emsp;&emsp;Existem várias maneiras de criar scripts no unity, a seguir mostraremos 3 delas.</p>

<div style="display: block;">
<h2>Pastas</h2>
  <img src="https://user-images.githubusercontent.com/18387694/37171802-cb8d2b7c-22ed-11e8-99ed-20107f49d29c.png"
  width= 400
  style="text-align: center; margin-top: 10px">
  <h2>Menu</h2>
  <img src="https://user-images.githubusercontent.com/18387694/37171803-cbbdb6c0-22ed-11e8-8375-5e443c051b41.png"
  width = 400
  style ="text-align: center; margin-top: 10px">
  <h2>Dentro do Objeto</h2>
  <img src="https://user-images.githubusercontent.com/18387694/37171805-cc21505e-22ed-11e8-8c4d-2b223345a508.png"
  width= 300
  style="text-align: center; margin-top: 10px">
  <img src="https://user-images.githubusercontent.com/18387694/37171804-cbed66cc-22ed-11e8-9d5c-9fb5ca480320.png"
  width= 200
  style="text-align: center; float: ">
  ]</div>


### 3.2 Variaveis e Funções
#### 3.2.1 Variaveis
<p align="justify"> &emsp;&emsp;Pense nas variáveis como caixas que contem informações e são necessárias tipos diferentes de caixa para diferentes tipos de informações.</p>

* Modelo
  > type nameOfVariable

  > type nameOfVariable = value;

* Exemplo

![playerlife](https://user-images.githubusercontent.com/18387694/37226089-9547a46e-23b7-11e8-92ec-c3090904e073.png)

#### 3.2.2 Funções
<p align="justify"> &emsp;&emsp;As funções normalmente server para executar alguma ação em cima de variáveis e parâmetros. Podem conter retorno. No caso da função conter um retorno terá que ser especificado o tipo de retorno em sua declaração antes de seu nome. Veja os modelos e exemplos abaixo.</p>

* Modelo
  > type nameOfFunction() {}

  > type FunctionName(type parameterName) {}

* Exemplo

![function](https://user-images.githubusercontent.com/18387694/37226356-68cfec2e-23b8-11e8-863a-73d60e6526e6.png)

#### 3.3 Estruturas Condicionais
#### 3.3.1 if
<p align="justify"> &emsp;&emsp;Normalmente em seu código, será necessário tomar decisões baseado em uma condição</p>

* Modelo
  > if (condition) {}

*  Example

![functions2](https://user-images.githubusercontent.com/18387694/37226989-74a8c74e-23ba-11e8-87e7-c08f2e03e429.png)



#### 3.3.2 else
<p align="justify"> &emsp;&emsp;O `else` normalmente é usado para tratar a condição oposta do `if`</p>

* Modelo
  > if (condition) { ... } else { ... }

*  Exemplo

![functions3](https://user-images.githubusercontent.com/18387694/37227141-f98364c4-23ba-11e8-948c-3a6b7c7f845b.png)

#### 3.3.3 else if
<p align="justify"> &emsp;&emsp;O `else if()` normalmente é usado para testar passar todos os casos de if testando assim todas as condições indentadas nele.</p>

* Modelo
  > if (condition) { ... } else if(condition){ ... }

*  Exemplo

![functions4](https://user-images.githubusercontent.com/18387694/37227273-83fb80c8-23bb-11e8-9905-07b213e1f2e8.png)


### 3.4 Loops
<p align="justify"> &emsp;&emsp;Loops em programação é um meio de repetir linhas de código, está sempre referenciado por um iterador</p>

#### 3.4.1 while
<p align="justify"> &emsp;&emsp;No `while` começamos com a palavra chave `while`, então nos parênteses `()` teremos a condição. O conteúdo do loop se repetirá  enquanto a condição se permanecer verdadeira. O código dentro das chaves `{}` representa o corpo do loop, será esse código que vai se repetir. </p>

*  Exemplo

![while](https://user-images.githubusercontent.com/18387694/37227731-0bfe7fb0-23bd-11e8-8b40-7d1ea66cc2bf.png)


#### 3.4.2 do while
<p align="justify"> &emsp;&emsp;No `do while` quase idêntico com o while loop com uma mudança. `while` loops testam a condição antes do corpo do loop, enquanto `do while` loops testam a condição no final do corpo do loop, isso garante que o corpo do loop execute pelo menos 1 vez.</p>

*  Exemplo

![do while](https://user-images.githubusercontent.com/18387694/37227955-b6ec43ee-23bd-11e8-86cb-53250034d345.png)

#### 3.4.3 for
<p align="justify"> &emsp;&emsp;No `for` começamos com a palavra chave `for`, então nos parênteses `()` teremos três específicas seções.A primeira seção é opcional e nos da um lugar para declarar e inicializar as variáveis que precisemos usar, essa seção irá rodar apenas uma vez no começo do loop. Na próxima seção temos a condição que tem que ser satisfeita, essa seção vai ser avaliada após cada iteração do loop. Finalmente na terceira seção que também é opcional, ela permite o decremento ou incrementação de qualquer variável que quisermos, essa seção vai rodar toda a iteração do loop.É importante notar que cada seção vai ser dividida por `;` e não `:`. O código dentro das chaves `{}` representa o corpo do loop, será esse código que se repetirá. </p>

*  Exemplo

 ![for](https://user-images.githubusercontent.com/18387694/37228397-459022c2-23bf-11e8-959c-a4b43c46cdf0.png)

#### 3.4.4 foreach
<p align="justify"> &emsp;&emsp;O `foreach` loop é muito útil para iterar coleções de dados como arrays. No exemplo iremos criar um array contendo 3 strings com devidos valores. O `foreach` basicamente faz o loop de uma coleção item por item até alcançar o final da coleção, quando chegar no final o loop para. Começamos com a palavra chave `foreach`, então nos parênteses `()` vamos declarar uma variável com o mesmo tipo da coleção que vamos fazer o loop. Seguimos os parentesis com a palavra `in` e o nome da coleção que desejamos fazer o loop. O código dentro das chaves `{}` representa o corpo do loop, será esse código que se repetirá. </p>

*  Exemplo

![foreach](https://user-images.githubusercontent.com/18387694/37228799-9f10dd68-23c0-11e8-84fe-abb88c9b34bf.png)


#### 3.5 Classes
<p align="justify"> &emsp;&emsp;No unity cada script contém uma definição de classe. As classes é um container que armazena funções e variáveis, é uma maneira de construir coisas que funcionam juntas, é uma ferramenta de organização conhecida como **Orientação a Objetos**. O nome do construtor deve ser o mesmo nome da classe, caso um seja alterado, tenha certeza que o outro também está de acordo com essa regra. Como exemplo podemos criar uma classe para cuidar do inventário do personagem e uma classe para mover. Assim o código fica mais organizado e facil de entender.</p>

```csharp
using UnityEngine;
using System.Collections;

public class MovementControls : MonoBehaviour
{
    public float speed;
    public float turnSpeed;


    void Update ()
    {
        Movement();
    }


    void Movement ()
    {
        float forwardMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turnMovement = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Rotate(Vector3.up * turnMovement);
    }
}
```

```csharp
using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public class Stuff
    {
        public int bullets;
        public int grenades;
        public int rockets;
        public float fuel;

        public Stuff(int bul, int gre, int roc)
        {
            bullets = bul;
            grenades = gre;
            rockets = roc;
        }

        public Stuff(int bul, float fu)
        {
            bullets = bul;
            fuel = fu;
        }

        // Constructor
        public Stuff ()
        {
            bullets = 1;
            grenades = 1;
            rockets = 1;
        }
    }


    // Creating an Instance (an Object) of the Stuff class
    public Stuff myStuff = new Stuff(50, 5, 5);

    public Stuff myOtherStuff = new Stuff(50, 1.5f);

    void Start()
    {
        Debug.Log(myStuff.bullets);
    }
}
```


#### 3.6 Scope and Access Modifiers
<p align="justify"> &emsp;&emsp;O escopo de uma variável é uma área no código em que a variável pode ser usada. A variável pode ser local ou global dentro de uma classe. Os códigos de blocos são oq normalmente definem o escopo da variável é são denotados por `{}`. Os estados `public` e `private` determinam se a variável vai poder ser acessada de outras classes ou apenas pela classe declarada. Variáveis sem tipo são locais</p>
<p align="justify"> &emsp;&emsp;No exemplo abaixo podemos ver que a  variável answer que está dentro da função Example() é local só para essa função e não pode ser acessada de outro lugar de código. Já as variáveis alpha, beta e gamma podem ser acessadas de qualquer lugar dentro dessa class. A exceção vai para a variável alpha que além de ser acessada de dentro da classe por ela ser pública, qualquer outra classe pode acessá-la</p>

```csharp
using UnityEngine;
using System.Collections;

public class ScopeAndAccessModifiers : MonoBehaviour
{
    public int alpha = 5;
    private int beta = 0;
    private int gamma = 5;

    private AnotherClass myOtherClass;

    void Start ()
    {
        alpha = 29;

        myOtherClass = new AnotherClass();
        myOtherClass.FruitMachine(alpha, myOtherClass.apples);
    }

    void Example (int pens, int crayons)
    {
        int answer;
        answer = pens * crayons * alpha;
        Debug.Log(answer);
    }


    void Update ()
    {
        Debug.Log("Alpha is set to: " + alpha);
    }
}
```

#### 3.7 Arrays
<p align="justify"> &emsp;&emsp;Os arrays são uma maneira de guardar uma coleção de dados do mesmo tipo juntas. A declaração de um array segue a seguinte forma `type[] nameOfArray = new   type[number of elements]`. Para acessar um índice de um array e inicializar basta fazer `nameOfArray[index] = value`</p>
<p align="justify"> &emsp;&emsp;No exemplo abaixo, vamos supor que precisamos guardar 5 inteiros. Ao invés de guardar individualmente em variáveis, podemos guardar em um array. Podemos iterar dentro de um array por meio de um `for` loop.</p>

```csharp
int[] myIntArray = new int[5]; // Declaration

int[] myIntArray = {12, 665, 41, 782, 198}; // Declaration and set

// Another type of Access and set value
myIntArray[0] = 12;
myIntArray[1] = 665;
myIntArray[2] = 41;
myIntArray[3] = 782;
myIntArray[4] = 198;

for(int i = 0; i < myIntArray.Lenght; i++)
{
  Debug.Log("Array number " + i + "is: " + myIntArray[i]);
}

```
#### 3.9 Enumeração
<p align="justify"> &emsp;&emsp;E alguns momentos precisamos de um tipo de variável que dentro dela tem uma série de constantes. Nesse caso usamos o `Enum`. São um tipo de dado especial, que tem um específico set de valores. Cada dado dentro de uma enumeração tem um valor default inteiro relativo a sua posição que começa em 0. Esses valores podem ser alterados atribuindo por meio de um `=`. </p>
<p align="justify"> &emsp;&emsp;Por exemplo considere os pontos em um compasso, podemos descrevê-lo usando inteiros, onde 0 = norte, 1 = leste, 2 = sul e 3 = oeste. Isso não seria muito fácil de se ler no código sendo que cada índice tem equivalência a um rumo. Então podemos criar uma enumeração.</p>

```csharp
enum Directions {North, East, South, West}; // Declaration

enum Directions {North = 0, East = 45, South = 90, West = 135}; // Declaration set values

enum Directions : short {North, East, South, West}; // Change type

Directions myDirection; // Access
myDirection = Directions.North;

```


#### 3.10 Switch
<p align="justify"> &emsp;&emsp;Quando fazemos decisões em código, normalmente usamos uma série de `if`s e `else`. Uma alternativa pode ser o `switch`. O `switch` é usado quando é necessário comparar um variavel a uma série de constantes. Um uso comum pode ser fazer uma decisão em cima de um `enum`. As constantes vamo ser colocadas depois de cada `case` e por padrão no final deve ter um caso `default` que vai ser usado se não entrar em nenhum dos outros casos.</p>

```csharp
public int intelligence = 5;


void Greet()
{
    switch (intelligence)
    {
    case 5:
        print ("Why hello there good sir! Let me teach you about Trigonometry!");
        break;
    case 4:
        print ("Hello and good day!");
        break;
    case 3:
        print ("Whadya want?");
        break;
    case 2:
        print ("Grog SMASH!");
        break;
    case 1:
        print ("Ulg, glib, Pblblblblb");
        break;
    default:
        print ("Incorrect intelligence level.");
        break;
    }
}
```

#### 3.11 DatatypeScript
<p align="justify"> &emsp;&emsp;Quando trabalhar com código inevitavelmente irá precisar trabalhar com vários tipos de variáveis. Todas as variáveis tem um **tipo de dado**. Os dois principais tipos de dados são de **Valor** e **Referência**.</p>
<p align="justify"> &emsp;&emsp;A diferença entre os dois é que tipos de **Valor** contém valores enquanto tipos de **Referência** contém um endereço de memória onde o valor está armazenado. O resultado é que se uma variável do tipo Valor mudar apenas aquela variável específica é afetada. Se um tipo Referência muda entretanto todas as variáveis que contêm naquele endereço de memória também vão ser afetados</p>

```csharp
// Valor

int
float
double
bool
char
Structs // Contain one or more variable
  * Vector3
  * Quaternion

// Referência

Classes
  * Transform
  * GameObject

```

```csharp
//Value type variable
Vector3 pos = transform.position;
pos = new Vector3(0, 2, 0);

//Reference type variable
Transform tran = transform;
tran.position = new Vector3(0, 2, 0);
```
