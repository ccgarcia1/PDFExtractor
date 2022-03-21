using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDFExtractor // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string file = @"C:/Users/cleit/Downloads/boleto (2) (1).pdf";
            using(PdfReader reader = new PdfReader(file))
            {
                for(int pageNo = 1; pageNo <=  reader.NumberOfPages; pageNo++)
                {

                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                    text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default,Encoding.UTF8,Encoding.Default.GetBytes(text)));
                    sb.Append(text);
                
                }
            }
            
            Console.WriteLine(sb.ToString());
            Console.ReadKey();

        }
    }
}