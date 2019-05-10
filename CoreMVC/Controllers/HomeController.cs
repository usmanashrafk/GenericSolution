using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVC.Models;
using Spire.Xls;
using System.Drawing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Text.RegularExpressions;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           // SearchAndReplace(@"D:\Certificate.docx");
            //GenerateXLFile();
           // GetPDF();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public void GetPDF()
        {
            Models.Certificate cert = new Models.Certificate();
            cert.GenerateDocument();
        }

        public void GenerateXLFile()
        {

            Workbook workbook = new Workbook();
       
            workbook.LoadFromFile(@"D:\Fleet.xls");
         
            Worksheet sheet = workbook.Worksheets[0];

            CellRange[] ranges = sheet.FindAllString("~PolicyNumber~", false, false);

            foreach (CellRange range in ranges)
            {
                range.Text = "F1987654";
                range.Style.Color = Color.Yellow;
            }

            //sheet.Range["D2"].Text = "Kelly Cooper";
         
            //sheet.Range["D2"].Style.Font.FontName = "Arial Narrow";
         
            //sheet.Range["D2"].Style.Font.Color = Color.DarkBlue;

            //sheet.Range["E2"].Value = "00-1-285-7901742";
     
            //sheet.Range["E2"].Style.Font.FontName = "Book Antiqua";
        
            //sheet.Range["E2"].Style.Font.Color = Color.DarkOrange;

            workbook.SaveToFile(@"D:\EditSheet.xls", ExcelVersion.Version97to2003);
        }




        private static void SearchAndReplace(string document)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                Dictionary<string, string> str = new Dictionary<string, string>();// { "aaaaaa", "bbbbbb", "ccccccc" };

                Regex regexText = new Regex("~QuoteClientName~");
                docText = regexText.Replace(docText, "Usman");

                Regex regexText1 = new Regex("~HullDeductible~");
                docText = regexText1.Replace(docText, "700");

                Regex regexText2 = new Regex("~LiabilityLimit~");
                docText = regexText2.Replace(docText, "900");


                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }
    }
}
