using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Class
{
    public class Materia
    {
        private string Nome;
        private int Vaga;

        public Materia(string nome, int vaga) { 
            Nome = nome;
            Vaga = vaga;
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
