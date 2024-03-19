using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados.Anticorruption.DataStructures.Pilha
{
    public class Pilha
    {
        public int Quantidade { get; private set; }
        private object[] Elementos;
        public Pilha(int maximo)
        {
            Elementos = new object[maximo];
        }
        public object Desempilha()
        {
            if (isVazia())
                throw new PilhaVaziaException("Não é possível desempilhar com uma pilha vazia.");
            object topo = Topo();
            Quantidade--;
            return topo;
        }

        public void Empilhar(object elemento)
        {
            if (Quantidade == Elementos.Length)
                throw new PilhaCheiaException("Não é possível empilhar com uma pilha cheia.");
            Elementos[Quantidade] = elemento;
            Quantidade++;
        }

        public bool isVazia()
        {
            return Quantidade == 0;
        }

        public object Topo()
        {
            return Elementos[Quantidade - 1];
        }
    }
}
