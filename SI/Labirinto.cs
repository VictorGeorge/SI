using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class Labirinto
    {
        public String[,] m;
        public int linhas, colunas;

        public Labirinto(int x, int y)
        {
            linhas = x;
            colunas = y;
            m = new String[x, y];
        }

        public void preencheLabirinto()
        {
            int i, j;

            for (i = 0; i < linhas; i++)
            {
                m[i, 0] = Convert.ToString(i);
            }

            for (j = 0; j < colunas; j++)
            {
                m[0, j] = Convert.ToString(j);
            }

            for (i = 1; i < linhas; i++)
            {
                for (j = 1; j < colunas; j++)
                {
                    m[i, j] = ".";
                }
            }
        }

        public int geraObstatuloHoriz(int x1, int y1, int x2, int y2)
        {
            if (x1 != x2)
            {
                Console.WriteLine("Entrada invalida, coordenadas precisam do mesmo x");
                return 0;
            }
            else
            {
                for (int i = y1; i <= y2; i++)
                {
                    if (x1 < 0 || x1 > (linhas - 1) || y1 < 0 || y2 < 0 || y1 > (colunas - 1) || y2 > (colunas - 1))
                    {
                        Console.WriteLine("Entrada invalida, coordenadas fora do labirinto\n");
                        return 0;
                    }
                    else
                    {
                        m[x1, i] = "X";
                    }

                }

            }
            return 1;
        }

        public int geraObstatuloVertical(int x1, int y1, int x2, int y2)
        {
            if (y1 != y2)
            {
                Console.WriteLine("Entrada invalida, coordenadas precisam do mesmo y");
                return 0;
            }
            else
            {
                for (int i = x1; i <= x2; i++)
                {
                    if (x1 < 0 || x1 > (linhas - 1) || y1 < 0 || y2 < 0 || y1 > (colunas - 1) || y2 > (colunas - 1))
                    {
                        Console.WriteLine("Entrada invalida, coordenadas fora do labirinto\n");
                        return 0;
                    }
                    else
                    {
                        m[i, y1] = "X";
                    }

                }

            }
            return 1;
        }

        public void mostraLabirinto()
        {
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (m[i, j].Equals("A"))
                        Console.ForegroundColor = ConsoleColor.Red;
                    if (m[i, j].Equals("$"))
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (m[i, j].Equals("X"))
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("{0}  ", m[i, j], i);
                }
                Console.Write("\n");
            }
        }

        public bool posicionaChegada(int x, int y)
        {
            if (m[x, y] == "X" || x < 0 || x > linhas || y < 0 || y > colunas)
            {
                Console.WriteLine("Posição fora do labirinto\n");
                return false;
            }
            else
            {
                m[x, y] = "$";
                return true;
            }
        }
    }
}
