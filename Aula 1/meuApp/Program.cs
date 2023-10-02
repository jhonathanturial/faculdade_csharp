using System;

namespace meuApp;

class Program
{

    // Os types podem ser declarados fora da função principal do programa
    char c1 = 'C';

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World! ----- Aula 1");
        Console.WriteLine("-------- Declarando Tipos --------");

        // Declarando inteiro 
         int inteiro = 10;
         Console.WriteLine($"{inteiro}");

        // Declarando um booleano

        bool verdadeiro = true;
        bool falso = false ;

        Console.WriteLine($"{verdadeiro}");
        Console.WriteLine($"{falso}");

        // Declarando um double, float, decimal e long

        double duplo = 3.14321321;
        decimal decimais = 1233.432M;
        float flutuante = 3.13f;
        long longo = 123213141421;

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Tipos reference types - Declarando objetos");

        // Reference types sempre acompanhados da palavra new, sempre é preciso instanciar

        object obj1 = new object();
        var obj2 = new object();

        var obj3 = obj2;

        Console.WriteLine("Comparando objs");
        Console.WriteLine($"{obj1.GetType().Name} | {obj2.GetType().Name} | {obj3.GetType().Name}" );
        Console.WriteLine($"{obj2 == obj3}");

        // Maneiras de declarar strings

        var s1 = new string('a', 5); // Declarando um array com 5 char
        string s2 = new string(new char[5] {'a', 'a', 'a', 'a', 'a'}); // Declarando um array com 5 char

        Console.WriteLine($"{s1 == s2}");

        string s3 = string.Concat((new char[5]{'a', 'a', 'a', 'a', 'a'}).AsEnumerable());
    }
}
