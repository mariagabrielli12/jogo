﻿

using jogo;
using System;
using System.Net.Mime;
using System.Security.Cryptography;

namespace JogoDaMemória
{
    public class Progam
    {
        private string _name;

        public static void PrintMatrix(int[,] tela)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write("  {0} ", j + 1);
            }
            Console.WriteLine("\n -----------------");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0} |", i + 1);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0} |", tela[i, j]);
                }
                Console.WriteLine("\n ----------------");
            }




        }

        public static void Main(String[] Args)
        {
            int[,] jogo = new int[4, 4];

            int[,] tela = new int[4, 4];

            Console.WriteLine("Entre com o player 1:");
            string nomeP1 = Console.ReadLine();

            Console.WriteLine("Entre com o player 2:");
            string nomeP2 = Console.ReadLine();


            Player p1 = new Player(nomeP1);
            Player p2 = new Player(nomeP2);

            Console.WriteLine(p1.Name);

            //Para criar números aleatórios
            Random gerador = new Random();

            for (int i = 1; i <= 8; i++) //Atribui os pares de números às posições
            {
                //Escolhe a posição do primeiro número do par
                int lin, col;
                for (int j = 0; j < 2; j++)
                {
                    do
                    {
                        lin = gerador.Next(0, 4);
                        col = gerador.Next(0, 4);

                    } while (jogo[lin, col] != 0);
                    jogo[lin, col] = i;
                }
            }




            int acertos = 0;
            do
            {
                Progam.PrintMatrix(tela);

                int jogador = gerador.Next(1,3);

                int lin1, col1;
                do
                {


                    // Chamar método de impressão
                    Progam.PrintMatrix(tela);

                    Console.WriteLine("{0} É SUA VEZ!",
                        jogador == 1 ? p1.Name: p2.Name);



                    //Pedir as posições do primeiro número
                    Console.WriteLine("Escolha uma linha para jogar [1, 4]: ");
                    lin1 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Escolha uma coluna para jogar [1, 4]: ");
                    col1 = int.Parse(Console.ReadLine());

                    lin1--;
                    col1--;
                } while (lin1 < 0 || lin1 >= 4 || col1 >= 4 || col1 < 0);


                tela[lin1, col1] = jogo[lin1, col1];

                Progam.PrintMatrix(tela);

                int lin2, col2;

                do
                {

                    //Pedir as posições do segundo número
                    Console.WriteLine("Escolha uma linha para jogar [1, 4]: ");
                    lin2 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Escolha uma coluna para jogar [1, 4]: ");
                    col2 = int.Parse(Console.ReadLine());

                    lin2--;
                    col2--;

                } while (lin2 < 0 || lin2 >= 4 || col2 >= 4 || col2 < 0);

                tela[lin2, col2] = jogo[lin2, col2];

                Progam.PrintMatrix(tela);

                if (jogo[lin1, col1] != jogo[lin2, col2])
                {
                    tela[lin1, col1] = 0;
                    tela[lin2, col2] = 0;
                }
                else
                {
                    if (jogador == 1)
                        p1.Score += 1;

                    else

                        p2.Score += 1;

                    acertos++;
                }
                Console.WriteLine("Digite 0 para sair ou qualquer outro número para continuar");
                int n = int.Parse(Console.ReadLine());

                if (n == 0)

                    break;

            } while (acertos < 8);

            Console.WriteLine(p1.ToString());

            Console.WriteLine();

            Console.WriteLine(p2.ToString());
        }
    }
}

