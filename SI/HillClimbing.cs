using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class HillClimbing
    {
        public List<Estado> Vizinhos;
        int mostrarAnimacao;

        public HillClimbing()
        {
            Vizinhos = new List<Estado>();
        }
        public int distEuclidiana(Estado atual, Estado final)
        {
            int absX = Math.Abs(atual.posX - final.posX);
            int absY = Math.Abs(atual.posY - final.posY);
            int h;

            if (absX > absY)
            {
                h = 14 * absY + 10 * (absX - absY);
            }
            else
            {
                h = 14 * absX + 10 * (absY - absX);
            }
            return h;
        }

        public void Pathfind(Agente agent, Estado inicial, Estado final, Labirinto maze)
        {
            Console.WriteLine("Você quer ver a animação? 0 pra não E 1 pra sim");
            mostrarAnimacao = Convert.ToInt32(Console.ReadLine());
            if (mostrarAnimacao == 1)
                maze.mostraLabirinto();

            inicial.h = distEuclidiana(inicial, final);
            inicial.g = 0;
            inicial.f = inicial.g + inicial.h;
            inicial.pai = null;
            Estado atual;
            Estado antigo;
            Estado auxiliar;
            atual = inicial;
            antigo = atual;

            while (atual.posX != final.posX || atual.posY != final.posY)
            {
                Console.Clear();
                

                agent.ir(maze, atual, antigo, mostrarAnimacao);
                if (mostrarAnimacao == 1)
                {
                    maze.mostraLabirinto();
                    System.Threading.Thread.Sleep(150);
                    Console.Clear();
                }
                if (atual.posX == final.posX && atual.posY == final.posY)
                {
                    break;
                }
                Vizinhos = olhaVizinhos(maze, atual, final, agent);
                Vizinhos.Sort((x, y) => x.f.CompareTo(y.f)); // sort
                
                auxiliar = Vizinhos[0];
                if (auxiliar.f <= atual.f)
                {
                    antigo = atual; // pega a posição anterior
                    atual = Vizinhos[0];           
                }
                Vizinhos.Clear();
            }
            maze.mostraCaminho(atual, maze);
            //Console.Clear();
            maze.mostraLabirinto();
        }

        public List<Estado> olhaVizinhos(Labirinto l, Estado atual, Estado final, Agente agent)
        {
            List<Estado> vizinhos;
            vizinhos = new List<Estado>();
            for (int x = agent.posX - 1; x <= agent.posX + 1; x++)
            {
                for (int y = agent.posY - 1; y <= agent.posY + 1; y++)
                {
                    if (x > 0 && x < l.linhas && y > 0 && y < l.colunas && l.m[x, y] != "X" && (x != agent.posX || y != agent.posY))
                    {
                        Estado estate = new Estado();
                        estate.posX = x;
                        estate.posY = y;
                        estate.pai = atual;
                        estate.g = distEuclidiana(estate, atual);
                        estate.h = distEuclidiana(estate, final);
                        estate.f = estate.g + estate.h;
                        vizinhos.Add(estate);
                    }
                }
            }
            return vizinhos;
        }
    }
}