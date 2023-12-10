using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Class.Fila
{
    public class Celula<T>
    {
        private T Elemento;
        private Celula<T> Prox;
        public Celula()
        {
            Elemento = default(T);
            Prox = null;
        }

        public Celula(T elemento)
        {
            Elemento = elemento;
            Prox = null;
        }

        public T elemento
        {
            get { return Elemento; }
            set { Elemento = value; }
        }

        public Celula<T> prox
        {
            get { return  Prox; }
            set { Prox = value; }
        }
    }
}
