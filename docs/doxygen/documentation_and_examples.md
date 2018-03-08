<p align="justify"> &emsp;&emsp; </p>

## Comment blocks for C-like languages (C/C++/C#/Objective-C/PHP/Java)

<p align="justify"> &emsp;&emsp;For each entity in the code there are two (or in some cases three) types of descriptions, which together form the documentation for that entity; a brief description and detailed description, both are optional. For methods and functions there is also a third type of description, the so called in body description, which consists of the concatenation of all comment blocks found within the body of the method or function.</p>

<p align="justify"> &emsp;&emsp;Having more than one brief or detailed description is allowed (but not recommended, as the order in which the descriptions will appear is not specified).</p>

<p align="justify"> &emsp;&emsp;As the name suggest, a brief description is a short one-liner, whereas the detailed description provides longer, more detailed documentation. An "in body" description can also act as a detailed description or can describe a collection of implementation details. For the HTML output brief descriptions are also used to provide tooltips at places where an item is referenced.</p>

#### There are several ways to mark a comment block as a detailed description:

* You can use the JavaDoc style, which consist of a C-style comment block starting with two *'s, like this:
``` C++
/**
 * ... text ...
 */
```

#### For the brief description there are also several possibilities:

<p align="justify"> &emsp;&emsp;One could use the @brief command with one of the above comment blocks. This command ends at the end of a paragraph, so the detailed description follows after an empty line.</p>

Here is an example:
```C++
/** @brief Brief description.
 *         Brief description continued.
 *
 *  Detailed description starts here.
 */
```
If JAVADOC_AUTOBRIEF is set to YES in the configuration file, then using JavaDoc style comment blocks will automatically start a brief description which ends at the first dot followed by a space or new line. Here is an example:

```C++
/** Brief description which ends at this dot. Details follow
 *  here.
 */
```


Here is the same piece of code as shown above, this time documented using the JavaDoc style and JAVADOC_AUTOBRIEF set to YES:
```C++
/**
 *  A test class. A more elaborate class description.
 */
class Javadoc_Test
{
  public:
    /**
     * An enum.
     * More detailed enum description.
     */
    enum TEnum {
          TVal1, /**< enum value TVal1. */
          TVal2, /**< enum value TVal2. */
          TVal3  /**< enum value TVal3. */
         }
       *enumPtr, /**< enum pointer. Details. */
       enumVar;  /**< enum variable. Details. */

      /**
       * A constructor.
       * A more elaborate description of the constructor.
       */
      Javadoc_Test();
      /**
       * A destructor.
       * A more elaborate description of the destructor.
       */
     ~Javadoc_Test();

      /**
       * a normal member taking two arguments and returning an integer value.
       * @param a an integer argument.
       * @param s a constant character pointer.
       * @see Javadoc_Test()
       * @see ~Javadoc_Test()
       * @see testMeToo()
       * @see publicVar()
       * @return The test results
       */
       int testMe(int a,const char *s);

      /**
       * A pure virtual member.
       * @see testMe()
       * @param c1 the first argument.
       * @param c2 the second argument.
       */
       virtual void testMeToo(char c1,char c2) = 0;

      /**
       * a public variable.
       * Details.
       */
       int publicVar;

      /**
       * a function variable.
       * Details.
       */
       int (*handler)(int a,int b);
};
```

#### Documentation at other places

<p align="justify"> &emsp;&emsp;In the examples in the previous section the comment blocks were always located in front of the declaration or definition of a file, class or namespace or in front or after one of its members. Although this is often comfortable, there may sometimes be reasons to put the documentation somewhere else. For documenting a file this is even required since there is no such thing as "in front of a file".</p>

<p align="justify"> &emsp;&emsp;Doxygen allows you to put your documentation blocks practically anywhere (the exception is inside the body of a function or inside a normal C style comment block).</p>

<p align="justify"> &emsp;&emsp;The price you pay for not putting the documentation block directly before (or after) an item is the need to put a structural command inside the documentation block, which leads to some duplication of information. So in practice you should avoid the use of structural commands unless other requirements force you to do so.</p>

<p align="justify"> &emsp;&emsp;Structural commands (like all other commands) start with a backslash (\), or an at-sign (@) if you prefer JavaDoc style, followed by a command name and one or more parameters. For instance, if you want to document the class Test in the example above, you could have also put the following documentation block somewhere in the input that is read by doxygen:</p>

```C++
/** @class Test
 *  @brief A test class.
 *
 *  A more detailed class description.
 */
```
<p align="justify"> &emsp;&emsp;Here the special command \class is used to indicate that the comment block contains documentation for the class Test. Other structural commands are:</p>

* **@struct** to document a C-struct.
* **@union** to document a union.
* **@enum** to document an enumeration type.
* **@fn** to document a function.
* **@var** to document a variable or typedef or enum value.
* **@def** to document a #define.
* **@typedef** to document a type definition.
* **@file** to document a file.
* **@namespace** to document a namespace.
* **@package** to document a Java package.
* **@interface** to document an IDL interface.

<p align="justify"> &emsp;&emsp;See section Special Commands for detailed information about these and many other commands.</p>

<p align="justify"> &emsp;&emsp;To document a member of a C++ class, you must also document the class itself. The same holds for namespaces. To document a global C function, typedef, enum or preprocessor definition you must first document the file that contains it (usually this will be a header file, because that file contains the information that is exported to other source files).</p>

#### Attention

<p align="justify"> &emsp;&emsp;Let's repeat that, because it is often overlooked: to document global objects (functions, typedefs, enum, macros, etc), you must document the file in which they are defined. In other words, there must at least be a</p>

```C++
/** @file */
```

line in this file.

<p align="justify"> &emsp;&emsp;Here is an example of a C header named structcmd.h that is documented using structural commands:</p>

```C++

/** @file structcmd.h
 *  @brief A Documented file.
 *
 *  Details.
 */

/** @def MAX(a,b)
 *  @brief A macro that returns the maximum of \a a and \a b.
 *
 *  Details.
 */

/** @var typedef unsigned int UINT32
 *  @brief A type definition for a .
 *
 *  Details.
 */

/** @var int errno
 *  @brief Contains the last error code.
 *  @warning Not thread safe!
 */

/** @fn int open(const char *pathname,int flags)
 *  @brief Opens a file descriptor.
 *  @param pathname The name of the descriptor.
 *  @param flags Opening flags.
 */

/** @fn int close(int fd)
 *  @brief Closes the file descriptor \a fd.
 *  @param fd The descriptor to close.
 */

/** @fn size_t write(int fd,const char *buf, size_t count)
 *  @brief Writes \a count bytes from \a buf to the filedescriptor \a fd.
 *  @param fd The descriptor to write to.
 *  @param buf The data buffer to write.
 *  @param count The number of bytes to write.
 */

/** @fn int read(int fd,char *buf,size_t count)
 *  @brief Read bytes from a file descriptor.
 *  @param fd The descriptor to read from.
 *  @param buf The buffer to read into.
 *  @param count The number of bytes to read.
 */
#define MAX(a,b) (((a)>(b))?(a):(b))
typedef unsigned int UINT32;
int errno;
int open(const char *,int);
int close(int);
size_t write(int,const char *, size_t);
int read(int,char *,size_t);
```

<p align="justify"> &emsp;&emsp;When you place a comment block in a file with one of the following extensions .dox, .txt, or .doc then doxygen will hide this file from the file list.</p>

<p align="justify"> &emsp;&emsp;If you have a file that doxygen cannot parse but still would like to document it, you can show it as-is using \verbinclude, e.g.</p>

```C++
/** @file myscript.sh
 *  Look at this nice script:
 *  @verbinclude myscript.sh
 */
```
