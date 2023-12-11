using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TrabalhoAED.Class.Pilha
{
    public class PilhaFlexivel<T>
    {
        private Celula<T> topo;
        private int Count;
        public PilhaFlexivel()
        {
            topo = null;
            Count = 0;
        }

        public void Inserir(T x)
        {
            Celula<T> tmp = new Celula<T>(x);
            tmp.prox = topo;
            topo = tmp;
            tmp = null;
        }

        public T Remover(T x)
        {
            if (topo == null)
                throw new Exception("Erro!");
            T elemento = topo.elemento;
            Celula<T> tmp = topo;
            topo = topo.prox;
            tmp.prox = null;
            tmp = null;
            return elemento;
        }


        public T[] Mostrar()
        {
            T[] result = new T[Count];
            int contador = 0;

            for (var i = topo; i != null; i = i.prox)
            {
                result[contador] = i.elemento;
                contador++;
            }

            return result;
        }
    }
}
