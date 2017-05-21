using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{
    class Program
    {
        static void Main(string[] args)
        {

            var mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var sb = new StringBuilder();

            Console.WriteLine("Aplicativo Registro Software");

            var arquivos = DirectoryHelper.GetFiles(@"C:\inetpub\wwwroot\projetos_git\siva\siva\slSiva", @"^.*\.(cs|cshtml|config|asax|csproj|pc)$", System.IO.SearchOption.AllDirectories);
            
            var quantidade = arquivos.Count();

            Console.WriteLine(string.Format("Quantidade de Arquivos Encontrados : {0}", quantidade.ToString()));            

            foreach (var arquivo in arquivos)
            {
                Console.WriteLine(string.Format("[{0}] PROCESSANDO ARQUIVO {1}", quantidade, arquivo));

                using (var sr = new StreamReader(arquivo))
                {
                    sb.Append(sr.ReadToEnd());
                    sb.AppendLine();
                    sb.AppendLine();
                }

                quantidade--;
               
            }

            using (var outfile = new StreamWriter(mydocpath + @"\siva-registro-software.txt"))
            {
                outfile.Write(sb.ToString());
            }

            Console.WriteLine("Processo de Registro Concluído!");

            Console.ReadKey();
        }
    }
}
