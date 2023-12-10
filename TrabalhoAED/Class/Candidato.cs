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
        private ListaSimples<int> Codigo;
        public Candidato(string nome, ListaSimples<int> notas, ListaSimples<int> codigo) { 
            Nome = nome;
            Notas = notas;
            Codigo = codigo;
        }

        public int[] GetNotas()
        {
            return Notas.Lista;
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
