using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Refit;
using System.Drawing;

namespace PDFExtractor // Note: actual namespace depends on the project name.
{
    internal class Program
    {
       // public static object RestService { get; private set; }

        static async Task Main(string[] args)
        {
            //try
            //{
            //    var CategoriaDocumentoClient = RestService.For <ICategoriaDocumentoAPIService>("https://kufvqkxyedf7vml-db202003022030.adb.sa-saopaulo-1.oraclecloudapps.com/ords/cgarcia/hr");
            //    Console.WriteLine("Consultando API");
            //    var CategoriaDocumento = await CategoriaDocumentoClient.GetCategoriaDocumentoAsync();


            //    Console.Write($"\nFirstName:{CategoriaDocumento.FirstName}");
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine("Erro na consulta " + e.Message);
            //}
            string folderPath = @"C:\documentos_exportar";
            int cont = 0;

            //string file = @"C:\documentos_exportar\55014476 - THAYNA DEAMICI SIMAO0001.pdf";

            foreach (string file in Directory.EnumerateFiles(folderPath, "*.pdf"))
            {
                StringBuilder sb = new StringBuilder();

                using (PdfReader reader = new PdfReader(file))
                {
                    cont++;
                    for(int pageNo = 1; pageNo <=  reader.NumberOfPages; pageNo++)
                    {

                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                        text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default,Encoding.UTF8,Encoding.Default.GetBytes(text)));
                        sb.Append(text);

                    }
                    Console.WriteLine($"{cont}-------------------------------------------------------------------------------------------");
                    Console.WriteLine(file);
                    Console.WriteLine(sb.ToString());
                   // Console.ReadKey();
                   //string contents = File.ReadAllText(file);
                }

            }

        }

    }
}