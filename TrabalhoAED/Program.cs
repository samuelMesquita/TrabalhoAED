using TrabalhoAED.Class;
using TrabalhoAED.Class.Fila;

namespace TrabalhoAED
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filaDeEspera = new RelatorioFila(@"C:\Users\samuel mesquita\Desktop\Trabalho\Trabalho.txt");

            filaDeEspera.LerRelatorio();
        }
    }
}
