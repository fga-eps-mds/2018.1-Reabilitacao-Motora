## Histórico de Versões

Data|Versão|Descrição|Autor
-|-|-|-
08/03/2018|1.0.0| Criação do documento |Arthur Diniz

---

## 0. Summary

[1. Naming](#1-naming)

[2. Formatting](#2-formatting)


-----

## 1. Nomes

**1.1.** Use **CamelCase** para dar nome a atributos e parâmetros.

``` csharp

    // Bom exemplo
    string studentName;


    // Mau exemplo
    string student_name;

```

**1.2.** Use **PascalCase** para dar nome a métodos.

``` csharp

    // Bom exemplo
    void SetGameObject(int studentName)
    {
        this.studentName = studentName;
    }

    // Mau exemplo
    void setgameObject(int studentname)
    {
        this.student_name = studentname;
    }
```

**1.3.** Os nomes dos métodos devem bem representar o que é realizado.

``` csharp

    // Bom exemplo
    void RegisterGameObject(GameObject player)
    {
          print(player.name);
    }

    // Mau exemplo
    void game_object_registration(GameObject player)
    {
          print(player.name);
    }

```

**1.4.** Use **PascalCase** para dar nome a classes e interfaces.

``` csharp

    // Bom exemplo
    public class PlayerMovement
    {
      /*...*/
    }

    // Mau exemplo
    public class playermovement
    {
        /*...*/
    }
```

**1.5.** Use nomes significativos em atributos. Abreviações NÃO devem ser usadas.

``` csharp

    // Bom exemplo
    Vector3 playerVelocity;

    // Mau exemplo
    Vector3 pv;

```

**1.6.**  Não deve existir variáveis nomeadas com letras únicas, como `a`, `b`, `c`. A única exceção é o uso de `i` em estruturas de repetição (loop).

``` csharp

    // Bom exemplo
    Rigidbody rigidbody = GetComponent<Rigidbody>();

    // Mau exemplo
    Rigidbody r = GetComponent<Rigidbody>();

```

**1.7.** Constantes devem ser escritas no padrão SCREAMING_SNAKE_CASE.

``` csharp

    // Bom exemplo
    public const int MINIMUM_PASSWORD_HEIGHT = 6;

    // Mau exemplo
    public const int MINIMUMPASSWORDHEIGHT = 6;

```

**1.8.** Trate acrônimos como palavras.

``` csharp

    // Bom exemplo
    string urlPost = "https://google/api/save";

    // Mau exemplo
    string URLPost = "https://google/api/save";

```

**[[Voltar ao topo|Style-Sheet]]**

-----
## 2. Formatação

**2.1.** Use TABs para indentar.

``` csharp

    // Bom exemplo
    bool GetPlayerVelocity()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        return rigidBody.velocity;
    }

    // Mau exemplo
    bool GetPlayerVelocity()
    {
    Rigidbody rigidBody = GetComponent<Rigidbody>();
    return rigidBody.velocity;
    }
```

**2.2.** Pule uma linha para separar blocos lógicos.

``` csharp

    // Bom exemplo
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    if(transform.position.x > 0.0f)
    {
      transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    // Mau exemplo
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    if(transform.position.x > 0.0f)
    {
      transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

```

**2.3.** Cada linha não deve apresentar mais do que 80 caracteres.

``` csharp

    // Bom exemplo
    void RegisterGameObject(GameObject player)
    {
      print("omg im so happy that im going to write a giant
      bible here check this out guys omg i cant believe that
      i registered a player object!!!");
    }

    // Mau exemplo
    void RegisterGameObject(GameObject player)
    {
      print("omg im so happy that im going to write a giant bible here check this out guys omg i cant believe that i registered a player object!!!");
    }


```

**2.4.** Sempre pule uma linha para abrir o escopo de um método, estrutura de repetição ou estrutura condicional. A chave que fecha o escopo deve ter a mesma indentação daquela que o abriu.

``` csharp

    // Bom exemplo
    void MovePlayer ()
    {
      transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }

    // Mau exemplo
    void MovePlayer () {
      transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }

```

**2.5.** Deve haver espaços entre os operadores.

``` csharp

    // Bom exemplo
    void Update ()
    {
      float h = Input.GetAxis("Horizontal");
      float xPos = h * range;

      transform.position = new Vector3(xPos, 2f, 0);
      textOutput.text = "Value Returned: " + h.ToString("F2");
    }

    // Mau exemplo
    void Update ()
    {
      float h=Input.GetAxis("Horizontal");
      float xPos=h*range;

      transform.position=new Vector3(xPos, 2f, 0);
      textOutput.text="Value Returned: "+h.ToString("F2");
    }

```

**2.6.** Não deve haver espaço após `(`, `[` e antes de `)`, `]`, **exceto** após declarações de métodos.

``` csharp

    // Bom exemplo
    void Update ()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

    // Mau exemplo
    void Update ()
    {
        if( Input.GetKey ( KeyCode.Space ) )
        {
            Destroy(gameObject);
        }
    }

```

**2.7.** Em estruturas de repetição, Não deve haver quebra de linha após fechar o escopo com `}`.

``` csharp

    // Bom exemplo
    for (i = 0; i < players.size(); i++)
    {
        for (int j = 0; j < players.size() - 1; j++)
        {
            if (player.get(j) > player.Get(j + 1))
            {
	              Player auxiliarPlayer = player.Get(j);
	          }
	      }
    }

    // Mau exemplo
    for (i = 0; i < players.size(); i++)
    {
        for (int j = 0; j < players.size() - 1; j++)
        {
            if (player.get(j) > player.get(j + 1))
            {
	              Player auxiliarPlayer = player.get(j);
	          }

	      }

    }
```
**2.8.** Não deve haver espaço após `for`, `if`, `else if` e `switch`.

``` csharp

    // Bom exemplo
    void TemperatureTest ()
    {
        if(coffeeTemperature > hotLimitTemperature)
        {
            print("Coffee is too hot.");
        }
        else if(coffeeTemperature < coldLimitTemperature)
        {
            print("Coffee is too cold.");
        }
        else
        {
            print("Coffee is just right.");
        }
    }

    // Mau exemplo
    void TemperatureTest ()
    {
        if (coffeeTemperature > hotLimitTemperature)
        {
            print("Coffee is too hot.");
        }
        else if (coffeeTemperature < coldLimitTemperature)
        {
            print("Coffee is too cold.");
        }
        else
        {
            print("Coffee is just right.");
        }
    }


```


**[[Voltar ao topo|Style-Sheet]]**
