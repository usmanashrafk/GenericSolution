using System;
using System.Linq;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using System.Xml;
using MigraDoc.DocumentObjectModel.Tables;
using System.Collections;
using System.Data;
using System.Xml.Linq;
using System.Globalization;
using MigraDoc.Rendering;
using System.IO;
using PdfSharp.Pdf;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace GenericSolution
{
    public class DocsMerge
    {

        #region Merging Docs
      
        public void MergeDocument()
        {
            List<string> files = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\PDFGenerator");

            foreach(var file in directoryInfo.GetFiles())
            {
                files.Add(file.FullName);
            }

            PdfReader reader = null;
            iTextSharp.text.Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = @"C:\PDFGenerator\newFile.pdf";

            sourceDocument = new iTextSharp.text.Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

            sourceDocument.Open();

            try
            {
                foreach (string file in files)
                {
                    int pages = get_pageCcount(file);

                    reader = new PdfReader(file);

                    for (int i = 1; i <= pages; i++)
                    {
                        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                        pdfCopyProvider.AddPage(importedPage);
                    }

                    reader.Close();
                }
                sourceDocument.Close();
            }

            
            catch (Exception ex)
            {
                throw ex;
            }

        }
           private int get_pageCcount(string file)
            {
                using (StreamReader sr = new StreamReader(File.OpenRead(file)))
                {
                    Regex regex = new Regex(@"/Type\s*/Page[^s]");
                    MatchCollection matches = regex.Matches(sr.ReadToEnd());

                    return matches.Count;
                }
            }
        

        #endregion

    }
}




