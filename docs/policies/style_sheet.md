## Histórico de Versões

Data|Versão|Descrição|Autor
-|-|-|-
08/03/2018|1.0.0| Criação do documento |Arthur Diniz

---

## 0. Summary

[1. Naming](#1-naming)

[2. Formatting](#2-formatting)


-----

## 1. Naming

**1.1.** Use **CamelCase** to name attributes and parameters.

``` csharp

    // Good example
    string studentName;


    // Bad example
    string student_name;

```

**1.2.** Use **PascalCase** to name methods.

``` csharp

    // Good example
    void SetGameObject(int studentName)
    {
        this.studentName = studentName;
    }

    // Bad example
    void setgameObject(int studentname)
    {
        this.student_name = studentname;
    }
```

**1.3.** Every method name must express verbally what it does.

``` csharp

    // Good example
    void RegisterGameObject(GameObject player)
    {
          print(player.name);
    }

    // Bad example
    void game_object_registration(GameObject player)
    {
          print(player.name);
    }

```

**1.4.** Use **PascalCase** to name classes and interfaces.

``` csharp

    // Good example
    public class PlayerMovement
    {
      /*...*/
    }

    // Bad example
    public class playermovement
    {
        /*...*/
    }
```

**1.5.** Use significative names on attributes. Abbreviations must not be used.

``` csharp

    // Good example
    Vector3 playerVelocity;

    // Bad example
    Vector3 pv;

```

**1.6.**  There must not be attributes named with a single character, like `a`, `b`, `c`. The only exception is `i` on loops.

``` csharp

    // Good example
    Rigidbody rigidbody = GetComponent<Rigidbody>();

    // Bad example
    Rigidbody r = GetComponent<Rigidbody>();

```

**1.7.** Constants must be written on SCREAMING_SNAKE_CASE.

``` csharp

    // Good example
    public const int MINIMUM_PASSWORD_HEIGHT = 6;

    // Bad example
    public const int MINIMUMPASSWORDHEIGHT = 6;

```

**1.8.** Treat acronyms as words.

``` csharp

    // Good example
    string urlPost = "https://google/api/save";

    // Bad example
    string URLPost = "https://google/api/save";

```

**[[Back to top|Style-Sheet]]**

-----
## 2. Formatting

**2.1.** Use TABs to indent.

``` csharp

    // Good example
    bool GetPlayerVelocity()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        return rigidBody.velocity;
    }

    // Bad example
    bool GetPlayerVelocity()
    {
    Rigidbody rigidBody = GetComponent<Rigidbody>();
    return rigidBody.velocity;
    }
```

**2.2.** Skip a line to separate logical groups.

``` csharp

    // Good example
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    if(transform.position.x > 0.0f)
    {
      transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    // Bad example
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    if(transform.position.x > 0.0f)
    {
      transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

```

**2.3.** Single line expressions must not have more than 80 characters.

``` csharp

    // Good example

    // Bad example


```

**2.4.** Always skip a line to open a bracket that belongs to a method, loop or conditional structure. The closing bracket must have the same indentation level as its own structure.

``` csharp

    // Good example
    void MovePlayer ()
    {
      transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }

    // Bad example
    void MovePlayer () {
      transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }

```

**2.5.** There must be a space between operators.

``` csharp

    // Good example
    void Update () {
      float h = Input.GetAxis("Horizontal");
      float xPos = h * range;

      transform.position = new Vector3(xPos, 2f, 0);
      textOutput.text = "Value Returned: " + h.ToString("F2");
    }

    // Bad example
    void Update () {
      float h=Input.GetAxis("Horizontal");
      float xPos=h*range;

      transform.position=new Vector3(xPos, 2f, 0);
      textOutput.text="Value Returned: "+h.ToString("F2");
    }

```

**2.6.** There must not be any space after `(`, `[` and before `)`, `]`, **except** after funtions declarations.

``` csharp

    // Good example
    void Update ()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

    // Bad example
    void Update ()
    {
        if( Input.GetKey ( KeyCode.Space ) )
        {
            Destroy(gameObject);
        }
    }

```

**2.7.** In loops. there must not be a line after `}`.

``` csharp

    // Good example
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

    // Bad example
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
**2.8.** There must not be a space after a method name, `for`, `if`, `else if` and `switch`.

``` csharp

    // Good example
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

    // Bad example
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


**[[Back to top|Style-Sheet]]**
