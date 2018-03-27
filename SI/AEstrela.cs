using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class AEstrela
    {
        public List<Estado> Aberta;
        public List<Estado> Fechada;

        public AEstrela()
        {
            Aberta = new List<Estado>();
            Fechada = new List<Estado>();
        }

        public int distEuclidiana(Estado atual, Estado final)
        {
            return (int)Math.Floor(Math.Sqrt(Math.Pow(final.posX - atual.posX, 2) + Math.Pow(final.posY - atual.posY, 2)) * 10);
        }

        public void Pathfind(Agente agent, Estado inicial, Estado final, Labirinto maze)
        {
            inicial.h = distEuclidiana(inicial, final);
            Aberta.Add(inicial);
            Estado atual;
    
            while (Aberta.Any())
            {
                Aberta.Sort((x, y) => x.f.CompareTo(y.f)); // sort
                atual = Aberta[0];
                Aberta.RemoveAt(0);
                Fechada.Add(atual);

                if(atual.posX == final.posX && atual.posY == final.posY)
                {
                    break;
                }

                adicionaVizinhos(maze, atual, final, agent);
            }
        }

        public void adicionaVizinhos(Labirinto l, Estado atual, Estado final, Agente agent)
        {
            //Boolean flag = true;
            for (int x = agent.posX-1; x < agent.posX+1; x++)
            {
                for (int y = agent.posY - 1; y < agent.posX + 1; y++)
                {
                    if (x > 0 && x < l.linhas && y > 0 && y < l.colunas && l.m[x, y] != "X")
                    {
                        foreach (Estado e in Fechada) // verifica se já esta na lista fechada
                        {
                            if (e.posX == x && e.posY == y)
                            {
                               // flag = false;
                            }
                        }

                        foreach (Estado e in Aberta) // verifica se já não esta na lista aberta
                        {
                            if (e.posX != x && e.posY != y)
                            {
                                Estado estate = new Estado();
                                estate.posX = x;
                                estate.posY = y;
                                estate.pai = atual;
                                estate.g = (int)Math.Floor(Math.Sqrt(Math.Pow(x - atual.posX, 2) + Math.Pow(y - atual.posY, 2)) * 10);
                                estate.h = (int)Math.Floor(Math.Sqrt(Math.Pow(final.posX - x, 2) + Math.Pow(final.posY - y, 2)) * 10);
                                estate.f = estate.g + estate.h;
                                Aberta.Add(estate);
                            }
                            else
                            {
                                int k = (int)Math.Floor(Math.Sqrt(Math.Pow(x - atual.posX, 2) + Math.Pow(y - atual.posY, 2)) * 10);

                                if (k < atual.g)
                                {
                                    e.g = (int)Math.Floor(Math.Sqrt(Math.Pow(x - atual.posX, 2) + Math.Pow(y - atual.posY, 2)) * 10);
                                    e.f = e.g + e.h;
                                    e.pai = atual;
                                }
                            }
                        }
                        //flag = true;
                    }
                }
            }
        }
    }
}