using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;

namespace Core.Models
{
    public class Heroi
    {
        public string Nome { get; set; }
        public int Nivel { get; set; }
        public int Vida { get; set; }
        public int VidaMax { get; set; }
        public int Ataque { get; set; }
        public int Ouro { get; set; }

        public List<string> Inventario { get; set; } = new List<string>();
        public int QuantidadePorcoes => Inventario.Count(item => item == "poção");

        public Heroi(string nome)
        {
            Nome = nome;
            Nivel = 1;
            VidaMax = 100;
            Vida = 100;
            Ataque = 15;
            XP = 0;
            XPProximoNivel = 180;
            Ouro = 0;

            // Limites iniciias do golpe.
            // O jogador vai ter 3 ataques - um basico um pesado e o ataque de furia
            // o basico e infinito, mas os outros dois funcionam com limitadores tipo o PP em Pokemon
            MaxGolpePesado = 5;
            UsoGolpePesado = MaxGolpePesado;

            MaxGolpeFuria = 3;
            UsoGolpeFuria = MaxAtaqueFuria;

            // o player começar com uma porção
            Inventario.Add("Poção");
        }
            // Metados de ataque - |Rapido | Pesado | Furia|
            public int AtaqueRapido()
        {
            Console.WriteLine($"\n {Nome} usou Ataque Rápido!");
            Console.WriteLine(@"
    |
  \ | /
   \*/
--**O**--
   /*\
  / | \
    |
    ");
            return Ataque;
        }
            public int GolpePesado()
        {
            if(UsoGolpePesado > 0)
            {
                UsoGolpePesado--;
                int dano = (int)(Ataque * 1.5);
                Console.WriteLine(@"        .
      \ | /
    '-.;;;.-'
   -==;;;;;==-
    .-';;;'-.
      / | \
     '
");
                Console.WriteLine($"\n {Nome} usou golpe Pesado!");
                Console.WriteLine($"\n |{GolpePesado}|-|{MaxGolpePesado}|");
            }

            Console.WriteLine("Voce esta sem energia para usar esse golpe!");
            return 0;
        }
            public int GolpeFuria()
        {
            if(UsoGolpeFuria > 0)
            {
                UsoGolpeFuria--;
                int dano = Ataque * 2;
                Console.WriteLine(@"          |
          |   .
   `.  *  |     .'
     `. ._|_* .'  .
   . * .'   `.  *
-------|     |-------
   .  *`.___.' *  .
      .'  |* `.  *
    .' *  |  . `.
        . |
          | 
");
                Console.WriteLine($"\n {Nome} entrou em Fúria!");
                Console.WriteLine($"\n [{UsoGolpeFuria}] | [{MaxGolpeFuria}]");
            }

           Console.WriteLine("Voce esta sem energia para usar esse golpe!");
            return 0;
        }

        // Porção de vida
         public void UsarPocao()
        {
            if(Inventario.Contains("Poção"))
            {
                // Escalonamento de cura
                int cura = 30 + (Nivel * 5);
                Vida = Math.Min(Vida + cura, VidaMax); // Limita a cura ao valor maximo da vida do jogador

                Console.WriteLine(@"
 mmm
 )-(
(   )
|   |
|   |
|___|
   ");
                Inventario.Remove("Poção");
                Console.WriteLine($"\n {Nome} recuperou {cura} de HP!");
            }
            else
            {
                Console.WriteLine("\n [AVISO] Você não possui poções!");
            }
        }

        // Quando ele volta pro acampamento (base)
        public void Descansar()
        {
            Vida = VidaMax; // quando ele descansa recupera tudo de vida e os golpes
            UsoGolpePesado = MaxGolpePesado;
            UsoGolpeFuria = MaxGolpeFuria;
            Console.WriteLine(@"
        ______
       /     /\
      /     /  \
     /_____/----\_    (  
                     ).  
   _ ___          o (:') o   
  (@))_))        o ~/~~\~ o   
                  o  o  o

            ");
            Console.WriteLine("\n [ACAMPAMENTO] HP e energias restauras ao máximo!");
        }

        private void GanharRecopensa(int xpGanho, int ouroGanho)
        {
            XPathDocument += xpGanho;
            Ouro += ouroGanho;
            Console.WriteLine($"\n Ganhou {xpGanho} XP e {ouroGanho} Ouro");

            if (XP >= XPProximoNivel) SubirNivel();
        }


        private void SUbirNivel()
        {
            Nivel++;
            XP -= XPProximoNivel;
            XPProximoNivel = (int)(XPProximoNivel * 1.5);

            // atualizaçõa de stts ao subir de nivel
            int ganhoVida = 20 + (Nivel + 2);
            int ganhoAtaque = 5 + (Nivel / 2);

            VidaMax += ganhoVida;
            Vida = VidaMax; // preenche a vida total quado sobe de nivel
            Ataque += ganhoAtaque;

            if (Nivel % 5 == 0) // ve se divide por 5 pra nao sobrar resto e quebrar tudo
            {
                MaxGolpePesado++;
                MaxGolpeFuria++;
            }

            usoGolpePesado = MaxGolpePesado;
            UsoGolpePesadoFuria = MaxGOlpeFuria;

            Console.WriteLine($@"
            
                                            _______________________
   _______________________-------------------                       `\
 /:--__                                                              |
||< > |                                   ___________________________/
| \__/_________________-------------------                         |
|                                                                  |
 |                               ***                               |
 |                                                                  |
 |                   LEVEL UP (Nível {Nivel}) !!!                   |
|              Vida +{ganhoVida} | Ataque +{ganhoAtaque}            |
  |                                              ____________________|_
  |  ___________________-------------------------                      `\
  |/`--_                                                                 |
  ||[ ]||                                            ___________________/
   \===/___________________--------------------------

            ");
        }
   }
}
