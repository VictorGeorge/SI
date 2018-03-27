using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class Agente
    {
        public int posX, posY, total = 0;
        public Random r;
        public char[] direcoes;
        public char k;

        public Agente()
        {
            posX = 1;
            posY = 1;
            r = new Random();

            direcoes = new char[] { 'c', 'b', 'd', 'e', 'q', 'w', 'r', 't' };
            /*
             c -> cima
             b -> baixo
             d -> direita
             e -> esquerda
             q -> diagonal superior esquerda
             w -> diagonal superior direita
             r -> diagonal inferior esquerda
             t -> diagonal inferior direita
            */
        }

        public Boolean entraLabirinto(Labirinto l, int x, int y)
        {
            if (l.m[x, y] == "X" || x < 0 || x > l.linhas || y < 0 || y > l.colunas)
            {
                Console.WriteLine("Posição fora do labirinto\n");
                return false;
            }
            else
            {
                l.m[x, y] = "A";
                return true;
            }
        }

        public int deliberar(Labirinto l)
        {
            if (chegou(l) == 1)
            {
                return 0;
            }
            k = direcoes[r.Next(direcoes.Length)];
            switch (k)
            {

                case 'c':
                    if (l.m[posX - 1, posY] == "X")
                    {
                        break;
                    }
                    else if (l.m[posX - 1, posY] == ".")
                    {
                        l.m[posX, posY] = ".";
                        l.m[posX - 1, posY] = "A";
                        posX--;
                        Console.WriteLine("\n");
                        l.mostraLabirinto();
                        return 1;
                    }
                    break;
                case 'b':
                    if (posX + 1 >= l.linhas)
                    {
                        break;
                    }
                    else if (l.m[posX + 1, posY] == "X")
                    {
                        break;
                    }
                    else if (l.m[posX + 1, posY] == ".")
                    {
                        l.m[posX, posY] = ".";
                        l.m[posX + 1, posY] = "A";
                        posX++;
                        Console.WriteLine("\n");
                        l.mostraLabirinto();
                        return 1;
                    }
                    break;
                case 'e':
                    if (l.m[posX, posY - 1] == "X")
                    {
                        break;
                    }
                    else if (l.m[posX, posY - 1] == ".")
                    {
                        l.m[posX, posY] = ".";
                        l.m[posX, posY - 1] = "A";
                        posY--;
                        Console.WriteLine("\n");
                        l.mostraLabirinto();
                        return 1;
                    }
                    break;
                case 'd':
                    if (posY + 1 >= l.colunas)
                    {
                        break;
                    }
                    else if (l.m[posX, posY + 1] == "X")
                    {
                        break;
                    }
                    else if (l.m[posX, posY + 1] == ".")
                    {
                        l.m[posX, posY] = ".";
                        l.m[posX, posY + 1] = "A";
                        posY++;
                        Console.WriteLine("\n");
                        l.mostraLabirinto();
                        return 1;
                    }
                    break;
                case 'q':
                    if (l.m[posX - 1, posY - 1] == "X")
                    {
                        break;
                    }
                    else if (l.m[posX - 1, posY - 1] == ".")
                    {
                        l.m[posX, posY] = ".";
                        l.m[posX - 1, posY - 1] = "A";
                        posY--;
                        posX--;
                        Console.WriteLine("\n");
                        l.mostraLabirinto();
                        return 1;
                    }
                    break;
                case 'w':
                    if (posY + 1 >= l.colunas)
                    {
                        break;
                    }
                    else if (l.m[posX - 1, posY + 1] == "X")
                    {
                        break;
                    }
                    else if (l.m[posX - 1, posY + 1] == ".")
                    {
                        l.m[posX, posY] = ".";
                        l.m[posX - 1, posY + 1] = "A";
                        posY++;
                        posX--;
                        Console.WriteLine("\n");
                        l.mostraLabirinto();
                        return 1;
                    }
                    break;
                case 't':
                    if (posY + 1 >= l.colunas || posX + 1 >= l.linhas)
                    {
                        break;
                    }
                    else if (l.m[posX + 1, posY + 1] == "X")
                    {
                        break;
                    }
                    else if (l.m[posX + 1, posY + 1] == ".")
                    {
                        l.m[posX, posY] = ".";
                        l.m[posX + 1, posY + 1] = "A";
                        posY++;
                        posX++;
                        Console.WriteLine("\n");
                        l.mostraLabirinto();
                        return 1;
                    }
                    break;
                case 'r':
                    if (posX + 1 >= l.linhas)
                    {
                        break;
                    }
                    else if (l.m[posX + 1, posY - 1] == "X")
                    {
                        break;
                    }
                    else if (l.m[posX + 1, posY - 1] == ".")
                    {
                        l.m[posX, posY] = ".";
                        l.m[posX + 1, posY - 1] = "A";
                        posX++;
                        posY--;
                        Console.WriteLine("\n");
                        l.mostraLabirinto();
                        return 1;
                    }
                    break;
            }
            return 1;
        }

        public void verificaVizinhos(Labirinto l, Agente a)
        {
            for (int i = 0; i < l.linhas; i++)
            {
                for (int j = 0; j < l.colunas; j++)
                {

                    for (int y = i - (3 / 2); y <= i + (3 / 2); y++)
                    {
                        for (int x = j - (3 / 2); x <= j + (3 / 2); x++)
                        {
                            //ignora as bordas
                            if (y > 0 && y < l.linhas && x > 0 && x < l.colunas)
                            {

                                //l.m[y][x] = 
                            }
                        }
                    }
                }
            }
        }

        public int chegou(Labirinto l)
        {
            if (posX + 1 >= l.linhas || posY + 1 >= l.colunas)
            {
                return 0;
            }
            else if (l.m[posX + 1, posY] == "$" || l.m[posX - 1, posY] == "$" || l.m[posX, posY + 1] == "$" || l.m[posX, posY - 1] == "$" ||
            l.m[posX + 1, posY + 1] == "$" || l.m[posX + 1, posY - 1] == "$" || l.m[posX - 1, posY - 1] == "$" || l.m[posX - 1, posY + 1] == "$") // diagonais
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}
