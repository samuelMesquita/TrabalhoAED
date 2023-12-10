using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Class.Fila
{
    public class FilaFlexivel<T>
    {
        private Celula<T> ultimo, primeiro;
        private int Count;
        public FilaFlexivel() { 
            primeiro = new Celula<T>();
            ultimo = primeiro;
            Count = 0;
        }

        public void Inserir(T x)
        {
            ultimo.prox = new Celula<T>(x);
            ultimo = ultimo.prox;
            Count++;
        }

        public T Remover(T x)
        {
            if(ultimo == primeiro)
                throw new Exception("Não a elementos para serem removidos na fila.");

            Celula<T> tmp = primeiro;
            primeiro = primeiro.prox;
            var elemento = primeiro.elemento;
            tmp.prox = null;
            tmp = null;
            Count--;

            return elemento;
        }

        public T[] Mostrar()
        {
            T[] result = new T[Count];
            int contador = 0;

            for(var i = primeiro.prox; i != null; i = i.prox)
            {
                result[contador] = i.elemento;
                contador++;
            }

            return result;
        }
    }
}
