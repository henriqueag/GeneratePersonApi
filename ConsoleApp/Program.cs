using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // troca de valores
            int velocidade1 = 100;
            int velocidade2 = 120;
            int aux;

            Console.WriteLine(velocidade1);
            Console.WriteLine(velocidade2);
            Console.WriteLine();
            aux = velocidade1;
            velocidade1 = velocidade2;
            velocidade2 = aux;

            Console.WriteLine(velocidade1);
            Console.WriteLine(velocidade2);

            
        }
    }
}

//Algoritmo abc

//Var

//     a, b, c: inteiro

//Início

//   a <- 12

//   b <- 5

//   c <- a

//   b <- c

//   a <- b

//  Escreva (a)

//  Escreva(b)

//  Escreva(c)

//Fim