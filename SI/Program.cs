using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class Program
    {
        static void Main(string[] args)
        {
            int linhas, colunas, x1, y1, x2, y2, pos1, pos2, obstaculo;
            bool fechou1 = false;
            bool fechou2 = false;
            Agente a = new Agente();

            Console.WriteLine("Numero de Linhas: ");
            linhas = Convert.ToInt32(Console.ReadLine()) + 1;
            Console.WriteLine("Numero de Colunas: ");
            colunas = Convert.ToInt32(Console.ReadLine()) + 1;

            Labirinto maze = new Labirinto(linhas, colunas);

            maze.preencheLabirinto();
            while (!fechou1)
            {
                Console.Clear();
                maze.mostraLabirinto();
                Console.WriteLine("\nDeseja inserir um obstáculo na horizontal ou na vertical? horizontal(1) vertical(0)\n");
                Console.WriteLine("\n(1) Horizontal\n");
                Console.WriteLine("\n(2) Vertical\n");
                obstaculo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nInsira as coordenadas do obstaculo, uma de cada vez, no formato (x1,y1), (x2,y2)\n");
                Console.WriteLine("X1: ");
                x1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Y1: ");
                y1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("X2: ");
                x2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Y2: ");
                y2 = Convert.ToInt32(Console.ReadLine());

                if (obstaculo == 1)
                {
                    if (maze.geraObstatuloHoriz(x1, y1, x2, y2) == 1)
                    {
                        Console.Clear();
                        maze.mostraLabirinto();
                        Console.WriteLine("Deseja inserir outro obstaculo? sim(1) não(0)\n");
                        if (Convert.ToInt32(Console.ReadLine()) == 0)
                        {
                            fechou1 = true;
                        }
                    }
                }
                else if (obstaculo == 2)
                {
                    if (maze.geraObstatuloVertical(x1, y1, x2, y2) == 1)
                    {
                        Console.Clear();
                        maze.mostraLabirinto();
                        Console.WriteLine("Deseja inserir outro obstaculo? sim(1) não(0)\n");
                        if (Convert.ToInt32(Console.ReadLine()) == 0)
                        {
                            fechou1 = true;
                        }
                    }
                }
            }
            Console.WriteLine();

            while (!fechou2)
            {
                Console.WriteLine("Posição de chegada (x,y): ");
                Console.WriteLine("PosX: ");
                pos1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("PosY: ");
                pos2 = Convert.ToInt32(Console.ReadLine());

                if (maze.posicionaChegada(pos1, pos2))
                {
                    fechou2 = true;
                }

            }

            a.entraLabirinto(maze);
            maze.mostraLabirinto();

            bool achou = false;
            int k;

            while (!achou)
            {
                k = a.deliberar(maze);
                if (k == 0)
                {
                    achou = true;
                    
                }
                else
                {
                    System.Threading.Thread.Sleep(150);
                    Console.Clear();
                }
                    
            }
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\n ACHOOOOOOOOOOOOOOOOOOOO\n");
            System.Threading.Thread.Sleep(10000);
        }
    }
}
