using System;
using System.Collections.Generic;
using System.Threading;
using Core.Models;

namespace API
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(@"
                 /| __________________________________________________
  8===========O|===|___________________________________________________  >
                 \|    THE NINTH WALKER - ALPHA VERSION

                                                   |>>>
                                   |>>>
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

            // Introdução Estilo Senhor dos Anéis
            Console.ForegroundColor = ConsoleColor.Cyan;
            Heroi.Escrever("O mundo mudou...", 80);
            Heroi.Escrever("Eu o sinto na terra. Eu o sinto na água. Eu o cheiro no ar.", 70);
            Heroi.Escrever("Muito do que existia se perdeu, pois não há mais ninguém vivo que se lembre.", 60);
            Console.ResetColor();

            Console.Write("\nDigite o nome do seu herói: ");
            string nome = Console.ReadLine() ?? "Viajante";
            Heroi jogador = new Heroi(nome);

            bool jogando = true;

            while (jogando)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine($"    ACAMPAMENTO - Herói: {jogador.Nome}");
                Console.WriteLine("========================================");
                Console.WriteLine("1 - Explorar o Mundo");
                Console.WriteLine("2 - Descansar (Recuperar HP e Energias)");
                Console.WriteLine("3 - Inventario");
                Console.WriteLine("4 - Ver Perfil do Jogador");
                Console.WriteLine("5 - Mercador de items");
                Console.WriteLine("6 - Sair do Jogo");
                Console.WriteLine("----------------------------------------");
                Console.Write("O que deseja fazer? ");

                string opcaoPrincipal = Console.ReadLine();

                switch (opcaoPrincipal)
                        {
                            case "1":
                                MenuExploracao(jogador);
                                break;

                            case "2":
                                jogador.Descansar();
                                Console.WriteLine("\n[Pressione qualquer tecla para continuar]");
                                Console.ReadKey();
                                break;

                            case "3":
                                jogador.VerInventario(); 
                                break;

                            case "4":
                                ExibirPerfil(jogador); 
                                break;

                            case "5":
                                Console.WriteLine("\nO Mercador ainda está viajando...");
                                Thread.Sleep(1500);
                                break;

                            case "6":
                                Heroi.Escrever("\nObrigado por jogar! Até a próxima aventura...", 40);
                                jogando = false;
                                break;

                            default:
                                Console.WriteLine("\nOpção inválida! Tente novamente.");
                                Thread.Sleep(1000);
                                break;
                        }
            }
        }

        static void MenuExploracao(Heroi jogador)
        {
            bool voltando = false;
            while (!voltando)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("       ESCOLHA O SEU DESTINO");
                Console.WriteLine("========================================");
                Console.WriteLine("1 - Floresta Sombria (Fácil)");
                Console.WriteLine("2 - Caverna de Gelo (Médio)");
                Console.WriteLine("3 - Castelo Abandonado (Difícil)");
                Console.WriteLine("4 - Voltar ao Acampamento");
                Console.WriteLine("----------------------------------------");
                Console.Write("Escolha: ");

                string escolha = Console.ReadLine();

                if (escolha == "1" || escolha == "2" || escolha == "3")
                {
                    ExplorarLugar(int.Parse(escolha), jogador);
                    voltando = true; 
                }
                else if (escolha == "4")
                {
                    voltando = true;
                }
                
                else
                {
                    Console.WriteLine("\nLocal desconhecido...");
                    Thread.Sleep(1000);
                }
            }
        }

        static void ExibirPerfil(Heroi h)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine($"      STATUS DE {h.Nome.ToUpper()}");
            Console.WriteLine("========================================");
            Console.WriteLine($"> Nível:       {h.Nivel}");
            Console.WriteLine($"> Vida:        {h.Vida} / {h.VidaMax}");
            Console.WriteLine($"> Ataque:      {h.Ataque}");
            Console.WriteLine($"> Ouro:        {h.Ouro} moedas");
            Console.WriteLine($"> Experiência: {h.XP} / {h.XPProximoNivel}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"> Golpe Pesado: [{h.UsoGolpePesado}/{h.MaxGolpePesado}]");
            Console.WriteLine($"> Golpe Fúria:  [{h.UsoGolpeFuria}/{h.MaxGolpeFuria}]");
            Console.WriteLine($"> Poções:       {h.QuantidadePorcoes}");
            Console.WriteLine("========================================");
            Console.WriteLine("\n[Pressione qualquer tecla para voltar]");
            Console.ReadKey();
        }

        static void ExplorarLugar(int lugarId, Heroi heroi)
        {
            Console.Clear();
            Inimigo monstro = new Inimigo(lugarId, heroi.Nivel);
            Heroi.Escrever($"\nCaminhando em direção ao perigo...", 50);
            Heroi.Escrever($"CUIDADO! Um {monstro.Nome} surge das sombras!", 40);

            while (heroi.Vida > 0 && monstro.Vida > 0)
            {
                Console.WriteLine($"\n----------------------------------------");
                Console.WriteLine($"{heroi.Nome}: {heroi.Vida} HP | {monstro.Nome}: {monstro.Vida} HP");
                Console.WriteLine("1-Ataque Rápido | 2-Golpe Pesado | 3-Fúria | 4-Poção");
                Console.Write("Ação: ");

                string acao = Console.ReadLine();
                int danoCausado = 0;

              
                switch (acao)
                {
                    case "1": danoCausado = heroi.AtaqueRapido(); break;
                    case "2": danoCausado = heroi.GolpePesado(); break;
                    case "3": danoCausado = heroi.GolpeFuria(); break;
                    case "4": heroi.UsarPocao(); break;
                    default: Console.WriteLine("Você hesitou!"); break;
                }

                if (danoCausado > 0) 
                    monstro.ReceberDano(danoCausado);

                if (monstro.Vida > 0)
                {
                    int danoRecebido = monstro.Atacar();
                    heroi.Vida -= danoRecebido;
                    Heroi.Escrever($"{heroi.Nome} recebeu {danoRecebido} de dano!", 20);
                }
            }

            if (heroi.Vida <= 0)
            {
                Console.Clear();
                Heroi.Escrever("========================================");
                Heroi.Escrever("        VOCÊ CAIU EM COMBATE...", 60);
                Heroi.Escrever("========================================");

                int penalidadeMorteOuro = heroi.Ouro / 2; // ele perde metade do ouro
                heroi.Ouro -= penalidadeMorteOuro;
                Console.WriteLine($"Voce perdeu {penalidadeMorteOuro} moedas de ouro... ");

                return;
            }
            else
            {
                Heroi.Escrever($"\nO {monstro.Nome} foi derrotado!", 40);
                heroi.GanharRecompensa(monstro.XpDrop, monstro.OuroDrop);
                Console.WriteLine("\nVoltando ao acampamento...");
                Thread.Sleep(3000);
            }
        }
    }
}