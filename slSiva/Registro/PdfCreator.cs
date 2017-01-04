using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro
{
    public class PdfCreator
    {
        private static PdfCreator pdfCreator;
        private PdfWriter pdfWriter;
        public string Arquivo { get; set; }
        public Document Document { get; private set; }
        public StreamReader Reader { get; set; }
        private string diretorio = Environment.CurrentDirectory;


        private PdfCreator()
        {
            Document = new Document();            
        }

        public static PdfCreator GetInstance
        {
            get
            {
                if (pdfCreator == null)
                {
                    pdfCreator = new PdfCreator();
                }

                return pdfCreator;
            }            
        }

        public bool Adicionar()
        {
            Reader = new StreamReader(Arquivo);

            if (pdfWriter == null)
            {
                pdfWriter = PdfWriter.GetInstance(Document, new FileStream(string.Format(@"{0}\documento_registro.pdf", diretorio), FileMode.Create));
            }

            var fonte = FontFactory.GetFont("Arial", 10, Font.NORMAL);
            var fileInfo = new FileInfo(Arquivo);

            if (!Document.IsOpen())
            {
                Document.Open();
            }
            
            Document.Add(new Paragraph(fileInfo.Name, fonte));
            Document.Add(new Paragraph(Reader.ReadToEnd(), fonte));
                                                            
            return true;
        }

        public void Concluir()
        {
            Document.Close();
        }

        public void Imprimir()
        {
            System.Diagnostics.Process.Start(diretorio);
        }        
    }
}
