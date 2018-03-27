using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho1
{
    class AEstrela
    {
        public List<Estado> Aberta  = new List<Estado>();
        public List<Estado> Fechada = new List<Estado>();

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

                adicionaVizinhos(maze, atual, final);


            }
            //Estado atual = inicial;
            //adicionaVizinhos(maze, atual, final);
        }


        public void adicionaVizinhos(Labirinto l, Estado atual, Estado final)
        {
            Boolean flag = true;

            for (int i = 0; i < l.linhas; i++)
            {
                for (int j = 0; j < l.colunas; j++)
                {
                    for (int x = i - (3 / 2); x <= i + (3 / 2); x++)
                    {
                        for (int y = j - (3 / 2); y <= j + (3 / 2); y++)
                        {
                            if (x > 0 && x < l.linhas && y > 0 && y < l.colunas && l.m[x, y] != "X")
                            {
                                foreach(Estado e in Fechada) // verifica se já esta na lista fechada
                                {
                                    if(e.posX == x && e.posY == y)
                                    {
                                        flag = false;
                                        break;
                                    }
                                }

                                if (flag)
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
                                flag = true;
                            }
                        }
                    }
                }
            }
        }
    }
}