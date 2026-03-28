using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Core.Service;

namespace API
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
                /| __________________________________________________
8===========O|===|___________________________________________________  >
                \|    THE NINTH WALKER - ALPHA VERSION
            ");

            // Teste de criação
            Heroi heroi = new Heroi("Melk");
            
            Console.WriteLine($"\nHerói {heroi.Nome} nível {heroi.Nivel} pronto para a jornada!");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}


