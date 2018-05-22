
namespace NCD.Infrastructure.Helpers
{
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    using System;
    using System.IO;

    public static class iTextSharpHelper
    {
        /// <summary>
        /// iTextSharp - HTML code to Pdf data 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] Convert(string content)
        {
            using (var ms = new MemoryStream())
            {

                using (var doc = new Document())
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();
                        using (var htmlWorker = new HTMLWorker(doc))
                        {
                            using (var sr = new StringReader(content))
                            {
                                htmlWorker.Parse(sr);
                            }
                        }
                        doc.Close();
                    }
                }

                return ms.ToArray();
            }
        }
    }
}
