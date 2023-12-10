using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Class
{
    public class RelatorioFila
    {
        private string Path;
        public RelatorioFila(string caminho)
        {
            Path = caminho;
        }

        public StringBuilder GerarRelatorio()
        {
            StringBuilder relatorio = new StringBuilder();
            FilaDeEspera filaDeEspera;
            int count = 0;

            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();

                        if(count == 0)
                        {
                            var tamanhos = linha.Split(";");
                            int qntCurso = Convert.ToInt32(tamanhos[0]);
                            int qntCandidato = Convert.ToInt32(tamanhos[1]);
                            
                            filaDeEspera = new FilaDeEspera(qntCurso, qntCandidato);
                        }
                        else
                        {

                        }

                        count++;
                    }
                }
            }
        }
    }
}
