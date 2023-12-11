using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.Class.Fila;
using TrabalhoAED.Class.Pilha;

namespace TrabalhoAED.Class
{
    public class Materia
    {
        private string Nome;
        private int Vaga;
        private int contadorVagas;
        private FilaFlexivel<StatusCandidato> StatusCandidato;
        private double NotaDeCorte;

        public Materia(string nome, int vaga) { 
            Nome = nome;
            Vaga = vaga;
            StatusCandidato = new FilaFlexivel<StatusCandidato>();
            contadorVagas = 0;
            NotaDeCorte = 0;
        }

        public string nome
        {
            get { return Nome; }
            set { Nome = value; }
        }

        public int vaga
        {
            get { return Vaga; }
        }

        public double notaDeCorte
        {
            get => NotaDeCorte;
        }

        public FilaFlexivel<Candidato> GetCandidatoPorStatus(string status)
        {
            var statusCandidatosArr = StatusCandidato.Mostrar();

            var candidatoSelecionado = new FilaFlexivel<Candidato>();

            foreach (var statusCandidato in statusCandidatosArr)
            {
                if (statusCandidato.status == status)
                    candidatoSelecionado.Inserir(statusCandidato.candidato);
            }

            return candidatoSelecionado;
        }

        public bool IncluirCandidato(Candidato candidato)
        {
            if(candidato != null && contadorVagas >= Vaga) {
                StatusCandidato.Inserir(new StatusCandidato("Fila de Espera", candidato));
                return false;
            }

            StatusCandidato.Inserir(new StatusCandidato("Selecionado" ,candidato));
            contadorVagas++;
            NotaDeCorte = candidato.CalcularMedia();
            return true;
        }
    }
}
