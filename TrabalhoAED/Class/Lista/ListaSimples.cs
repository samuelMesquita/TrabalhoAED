using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Class.Lista
{
    public class ListaSimples<T>
    {
        T[] lista;
        int n;

        public ListaSimples(int tamanho) {
            lista = new T[tamanho];
            n = 0;
        }

        public void InserirInicio(T x)
        {
            if (n >= lista.Length)
                throw new Exception("Lista não possui mais tamanho");

            for(int i = n; i > 0; i--)
                lista[i] = lista[i - 1];

            lista[0] = x;
            n++;
        }

        public void inserirFim(T x)
        {
            if (n >= lista.Length)
                throw new Exception("Lista não possui mais tamanho");

            lista[n] = x;
            n++;
        }

        public void inserirPos(T x, int pos)
        {
            if (n >= lista.Length || pos > n || pos < 0)
                throw new Exception("Erro ao inserir");

            for (int i = n; i > pos; i--)
                lista[i] = lista[i - 1];

            lista[pos] = x;

            n++;
        }

        public T RemoverInicio()
        {
            if(n == 0)
                throw new Exception("Não possui elementos na lista");

            T elemento = lista[0];
            n--;
            
            for (int i = n; i >= 0; i--)
                lista[i] = lista[i - 1];

            return elemento;
        }

        public T RemoverFim()
        {
            if (n == 0)
                throw new Exception("Não possui elementos na lista");

            n--;

            return lista[n];
        }

        public T RemoverPos(int pos)
        {
            if (n == 0 || pos < 0 || pos >= n)
                throw new Exception("Erro!");

            T resp = lista[pos];
            n--;

            for (int i = pos; i < n; i++)
                lista[i] = lista[i + 1];

            return resp;
        }

        public T[] Lista
        {
            get { return lista; }
        }
    }
}
