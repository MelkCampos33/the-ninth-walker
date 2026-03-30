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

                                                  |>>>
                                  |
                    |>>>      _  _|_  _         |>>>
                    |        |;| |;| |;|        |
                _  _|_  _    \\.    .  /    _  _|_  _
               |;|_|;|_|;|    \\:. ,  /    |;|_|;|_|;|
               \\..      /    ||;   . |    \\.    .  /
                \\.  ,  /     ||:  .  |     \\:  .  /
                 ||:   |_   _ ||_ . _ | _   _||:   |
                 ||:  .|||_|;|_|;|_|;|_|;|_|;||:.  |
                 ||:   ||.    .     .      . ||:  .|
                 ||: . || .     . .   .  ,   ||:   |       \,/
                 ||:   ||:  ,  _______   .   ||: , |            /`\
                 ||:   || .   /+++++++\    . ||:   |
                 ||:   ||.    |+++++++| .    ||: . |
              __ ||: . ||: ,  |+++++++|.  . _||_   |
     ____--`~    '--~~__|.    |+++++__|----~    ~`---,              ___
-~--~                   ~---__|,--~'                  ~~----_____-~'   `~----~~
            ");

// 1. Criar o herói
Heroi meuHeroi = new Heroi("Melkc");

Console.WriteLine("======= INÍCIO DA JORNADA =======");
Console.WriteLine($"Herói: {meuHeroi.Nome} | Nível: {meuHeroi.Nivel}");

// 2. Testar Ataques e Gastar Energia
Console.WriteLine("\n--- ⚔️ Testando Combate ---");
meuHeroi.AtaqueRapido();
meuHeroi.GolpePesado();
meuHeroi.GolpeFuria();

// 3. Testar TOMAR POÇÃO
Console.WriteLine("\n--- 🧪 Testando Poção ---");
meuHeroi.Vida = 30; // Simulamos que ele levou dano
Console.WriteLine($"Vida antes: {meuHeroi.Vida}/{meuHeroi.VidaMax}");

meuHeroi.UsarPocao(); // Vai usar a poção que ele ganha no construtor

Console.WriteLine($"Vida depois: {meuHeroi.Vida}/{meuHeroi.VidaMax}");



        
        }
    }
}


