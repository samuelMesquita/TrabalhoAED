using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.Class.Fila;
using TrabalhoAED.Class.Lista;

namespace TrabalhoAED.Class
{
    public class Candidato
    {
        private string Nome;
        private ListaSimples<int> Notas;
        private FilaFlexivel<int> Codigo;
        public Candidato(string nome, ListaSimples<int> notas, FilaFlexivel<int> codigo) { 
            Nome = nome;
            Notas = notas;
            Codigo = codigo;
        }

        public string nome { get => Nome; }

        public int[] GetNotas()
        {
            return Notas.Lista;
        }

        public int[] GetCodigo()
        {
            return Codigo.Mostrar();
        }

        public double CalcularMedia()
        {
            double somaNotas = 0;


            foreach(int nota in Notas.Lista)
            {
                somaNotas += nota;
            }

            return somaNotas / Notas.Lista.Length;
        }
    }
}
