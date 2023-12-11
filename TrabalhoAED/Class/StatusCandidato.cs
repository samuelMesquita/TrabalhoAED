using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Class
{
    public class StatusCandidato
    {
        private string _status;
        private Candidato _candidato;
        public StatusCandidato(string status, Candidato candidato) { 
            _status = status;
            _candidato = candidato;
        }

        public string status
        {
            get { return _status; }
        }

        public Candidato candidato { get { return _candidato; } }
    }
}
