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
        int mostrarAnimacao;

        public AEstrela()
        {
            Aberta = new List<Estado>();
            Fechada = new List<Estado>();
        }

        public int distEuclidiana(Estado atual, Estado final)
        {
            int absX = Math.Abs(atual.posX - final.posX);
            int absY = Math.Abs(atual.posY - final.posY);
            int h;

            if(absX > absY)
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
            if(mostrarAnimacao == 1)
                maze.mostraLabirinto();

            inicial.h = distEuclidiana(inicial, final);
            inicial.g = 0;
            inicial.pai = null;
            Aberta.Add(inicial);
            Estado atual;
            Estado antigo;

            atual = inicial;

            while (Aberta.Any())
            {
                Console.Clear();
                Aberta.Sort((x, y) => x.f.CompareTo(y.f)); // sort
                antigo = atual;
                atual = Aberta[0];
                Aberta.RemoveAt(0);
                Fechada.Add(atual);
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
                adicionaVizinhos(maze, atual, final, agent);
            }
            maze.mostraCaminho(atual, maze);
            //Console.Clear();
            maze.mostraLabirinto();
        }

        public void adicionaVizinhos(Labirinto l, Estado atual, Estado final, Agente agent)
        {
            Boolean achouVizinhoAberta = false;
            Boolean achouVizinhoFechada = false;
            Estado auxiliar = new Estado();

            for (int x = agent.posX-1; x <= agent.posX+1; x++)
            {
                for (int y = agent.posY - 1; y <= agent.posY+1; y++)
                {
                    if (x > 0 && x < l.linhas && y > 0 && y < l.colunas && l.m[x, y] != "X" && (x != agent.posX || y != agent.posY))
                    {
                        foreach (Estado e in Aberta) // verifica se já não esta na lista aberta
                        {
                            if (e.posX == x && e.posY == y)
                            {
                                achouVizinhoAberta = true;
                                auxiliar = e;
                                break;
                            }
                        }
                        if (Fechada.Contains(auxiliar))
                            break;
                        if (!achouVizinhoAberta) // Nao achou vizinho na lista Aberta
                        {
                            Estado estate = new Estado();
                            estate.posX = x;
                            estate.posY = y;
                            estate.pai = atual;
                            estate.g = distEuclidiana(estate, atual) + atual.g;
                            estate.h = distEuclidiana(estate, final);
                            estate.f = estate.g + estate.h;
                            Aberta.Add(estate);
                        }                       
                        else
                        {
                            int k = distEuclidiana(auxiliar, atual);
                            int melhorCusto = k + atual.g;
  
                            if (melhorCusto < auxiliar.g)
                            {
                                auxiliar.g += melhorCusto;
                                auxiliar.f = auxiliar.g + auxiliar.h;
                                auxiliar.pai = atual;
                            }
                        } 
                    }
                    achouVizinhoAberta = false;
                    achouVizinhoFechada = false;
                }
            }
        }
    }
}