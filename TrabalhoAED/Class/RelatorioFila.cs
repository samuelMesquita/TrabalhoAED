using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.Class.Fila;
using TrabalhoAED.Class.Lista;

namespace TrabalhoAED.Class
{
    public class RelatorioFila
    {
        private string Path;
        private readonly int QuantidadeNotas = 3;
        public RelatorioFila(string caminho)
        {
            Path = caminho;
        }

        public StringBuilder LerRelatorio()
        {
            FilaDeEspera filaDeEspera = new FilaDeEspera();
            int count = 0;

            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();

                        if (count == 0)
                        {
                            var tamanhos = linha.Split(";");
                            int qntCurso = Convert.ToInt32(tamanhos[0]);
                            int qntCandidato = Convert.ToInt32(tamanhos[1]);

                            filaDeEspera.InserirQuantidades(qntCurso, qntCandidato + qntCurso);
                        }
                        else
                        {
                            if (count <= filaDeEspera.quantidadeCurso)
                            {
                                var materia = linha.Split(";");
                                filaDeEspera.InserirMaterias(Convert.ToInt32(materia[0]), materia[1], Convert.ToInt32(materia[2]));
                            }
                            else if(count > filaDeEspera.quantidadeCurso && count <= filaDeEspera.quantidadeCandidatos)
                            {
                                var candidatos = linha.Split(";");
                                ListaSimples<int> notas = new ListaSimples<int>(QuantidadeNotas);
                                FilaFlexivel<int> codigos = new FilaFlexivel<int>();

                                notas.inserirFim(Convert.ToInt32(candidatos[1]));
                                notas.inserirFim(Convert.ToInt32(candidatos[2]));
                                notas.inserirFim(Convert.ToInt32(candidatos[3]));

                                codigos.Inserir(Convert.ToInt32(candidatos[4]));
                                codigos.Inserir(Convert.ToInt32(candidatos[5]));

                                filaDeEspera.InserirCandidatos(candidatos[0], notas, codigos);
                            }

                        }

                        count++;
                    }
                }
            }
            filaDeEspera.VincularCandidatosMaterias();
            var relatorio = GerarRelatorio(filaDeEspera);
            return relatorio;
        }

        public StringBuilder GerarRelatorio(FilaDeEspera filaEspera)
        {
            StringBuilder relatorio = new StringBuilder();

            var materias = filaEspera.GetMaterias();

            foreach(var materia in materias.Values)
            {
                relatorio.AppendLine($"{materia.nome}: {materia.notaDeCorte.ToString("N2")}");
                relatorio.AppendLine("Selecionados");

                var candidatosSelecionados = materia.GetCandidatoPorStatus("Selecionado");

                foreach (var candidato in candidatosSelecionados.Mostrar())
                    relatorio.AppendLine($"{candidato.nome}: {candidato.CalcularMedia().ToString("N2")}");

                relatorio.AppendLine("Fila de Espera");

                var candidatosFilaDeEspera = materia.GetCandidatoPorStatus("Fila de Espera");

                foreach (var candidato in candidatosFilaDeEspera.Mostrar())
                    relatorio.AppendLine($"{candidato.nome}: {candidato.CalcularMedia().ToString("N2")}");

                relatorio.AppendLine();
                relatorio.AppendLine();
            }

            return relatorio;
        }
    }
}
