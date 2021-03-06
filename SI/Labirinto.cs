﻿using System;
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
        int acao;

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
                    if (m[i, j].Equals("@"))
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (m[i, j].Equals("."))
                    {
                        Console.Write("|     ");
                    }
                    else
                    {   if(Console.ForegroundColor == ConsoleColor.Green)
                        {
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("  {0}  ", m[i, j]);
                            Console.ResetColor();
                        }
                        else if(Console.ForegroundColor == ConsoleColor.Red)
                        {
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("  {0}  ", m[i, j]);
                            Console.ResetColor();
                        }
                        else if (Console.ForegroundColor == ConsoleColor.DarkGray)
                        {
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("|");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("  {0}  ", m[i, j]);
                        }
                        else
                        {
                            if(m[i, j].Length > 1)
                                Console.Write("|  {0} ", m[i, j]);
                            else
                                Console.Write("|  {0}  ", m[i, j]);
                        }
                    }
                }
                Console.Write("|\n");

                for (int k = 0; k<=colunas*6; k++)
                {
                    if(k%6 == 0 || k == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("+");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("-");
                    }
                }
                Console.Write("\n");
            }
        }

        public void mostraCaminho(Estado state, Labirinto maze)
        {
            List<Estado> Invertida;
            Invertida = new List<Estado>();
            Estado atual, ondeEstou;
            while (state.pai != null)
            {
                Invertida.Add(state);
                //m[state.posX, state.posY] = "@";
                state = state.pai;
            }
            Invertida.Add(state);
            //m[state.posX, state.posY] = "@";
            Invertida.Reverse();
            while (Invertida.Any())
            {
                Console.WriteLine("Deseja andar ou ver posição? 0 - Andar  1 - Ver Posição");
                acao = Convert.ToInt32(Console.ReadLine());
                if(acao == 0)
                {
                    Console.Clear();
                    atual = Invertida[0];
                    Invertida.RemoveAt(0);
                    if (Invertida.Any())
                        ondeEstou = Invertida[0];
                    else
                        break;
                    m[ondeEstou.posX, ondeEstou.posY] = "A";
                    m[atual.posX, atual.posY] = "@";
                    maze.mostraLabirinto();
                }
                else{
                    Console.Clear();
                    atual = Invertida[0];
                    m[atual.posX, atual.posY] = "A";
                    Console.WriteLine("Posição: X: {0}, Y: {1}", atual.posX, atual.posY);
                    maze.mostraLabirinto();
                }
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
