using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.Class.Fila;
using TrabalhoAED.Class.Lista;

namespace TrabalhoAED.Class
{
    public class FilaDeEspera
    {
        private int QuantidadeCurso;
        private int QuantidadeCandidatos;
        private IDictionary<int, Materia> materias;
        private FilaFlexivel<Candidato> candidatos;

        public FilaDeEspera(int qntCurso, int qntCandidatos)
        {
            QuantidadeCurso = qntCurso;
            QuantidadeCandidatos = qntCandidatos;
        }

        public FilaDeEspera(){

            materias = new Dictionary<int, Materia>();
            candidatos = new FilaFlexivel<Candidato>();
        }

        public void InserirQuantidades(int qntCurso, int qntCandidatos)
        {
            QuantidadeCurso = qntCurso;
            QuantidadeCandidatos = qntCandidatos;
        }

        public void InserirMaterias(int codigo, string nome, int vagas)
        {
            materias.Add(codigo, new Materia(nome, vagas));
        }

        public void InserirCandidatos(string nome, ListaSimples<int> notas, FilaFlexivel<int> codigos)
        {
            candidatos.Inserir(new Candidato(nome, notas, codigos));
        }

        public void VincularCandidatosMaterias()
        {
            var candidatosArr = candidatos.Mostrar();
            var MaioresNotas = candidatosArr.OrderByDescending(x => x.CalcularMedia()).ThenBy(x => x.GetNotas()[2]).ToList();

            bool aprovado = false;

            foreach (var maiorNota in MaioresNotas)
            {
                var cursos = maiorNota.GetCodigo();

                var curso = materias.Where(x => x.Key == cursos[0]).FirstOrDefault();

                if(curso.Value != null)
                {
                    aprovado = curso.Value.IncluirCandidato(maiorNota);

                    if (!aprovado)
                    {
                        curso = materias.Where(x => x.Key == cursos[1]).FirstOrDefault();
                        curso.Value.IncluirCandidato(maiorNota);
                    }
                }
            }
        }

        public IDictionary<int, Materia> GetMaterias() { return materias; }

        public int quantidadeCurso
        {
            get => QuantidadeCurso;
            set => QuantidadeCurso = value;
        }

        public int quantidadeCandidatos
        {
            get => QuantidadeCandidatos;
            set => QuantidadeCandidatos = value;
        }
    }
}
