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
        int cont = 0;

        public Agente()
        {
            r = new Random();
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
                posX = x;
                posY = y;
                l.m[x, y] = "A";
                return true;
            }
        }

        public void ir(Labirinto l, Estado atual, Estado antigo, int Animacao)
        {
            if (Animacao == 1)
            {
                l.m[atual.posX, atual.posY] = "A";
                l.m[antigo.posX, antigo.posY] = cont.ToString();
            }
            this.posX = atual.posX;
            this.posY = atual.posY;
            cont++;
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
