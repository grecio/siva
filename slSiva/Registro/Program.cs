using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aplicativo Registro Software");

            var arquivos = DirectoryHelper.GetFiles(@"C:\inetpub\wwwroot\projetos_git\siva\siva\slSiva", @"^.*\.(cs|cshtml|config|asax|csproj|pc)$", System.IO.SearchOption.AllDirectories);
            
            var quantidade = arquivos.Count();

            Console.WriteLine(string.Format("Quantidade de Arquivos Encontrados : {0}", quantidade.ToString()));

            var pdf = PdfCreator.GetInstance;

            foreach (var arquivo in arquivos)
            {
                Console.WriteLine(string.Format("[{0}] PROCESSANDO ARQUIVO {1}", quantidade, arquivo));

                pdf.Arquivo = arquivo;

                if (pdf.Adicionar())
                {
                    quantidade--;
                    continue;
                }
            }

            pdf.Concluir();
            pdf.Imprimir();

            Console.WriteLine("Processo de Registro Concluído!");

            Console.ReadKey();
        }
    }
}
