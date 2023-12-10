using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Class
{
    public class Materia
    {
        private int Codigo;
        private string Nome;
        private int Vaga;

        public Materia(int codigo, string nome, int vaga) { 
            Codigo = codigo;
            Nome = nome;
            Vaga = vaga;
        }

        public int codigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }

        public string nome
        {
            get { return Nome; }
            set { Nome = value; }
        }

        public int vaga
        {
            get { return Vaga; }
            set { Vaga = value; }
        }
    }
}
