using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace GenericSolution
{
    public class Invoice :IDocument<string>
    {
   
        private const string page_height = "297mm";
        private const string page_width = "210mm";
        private const string margin = "10mm";
        private const string bottom_margin = "22mm";
        private const string table_width = "190mm";
        private const string table_boarder = "0.1mm";
        private const string row_padding = "0.2mm";
        private const string row_top_padding = "2mm";
        private const string row_bottom_padding = "0.3mm";
        private const string table_indent = "0mm";

        private Document document;
        private Color table_color;
        private Color acomm_sep_color = new Color(251, 251, 251);

        private string travelDocumentFolder;
        const PdfFontEmbedding embedding = PdfFontEmbedding.Always;

        const bool unicode = false;


        public Invoice()
        {
            travelDocumentFolder = @"C:\PDFGenerator\";
        }


        public string GenerateDocument()
        {
            table_color = Tools.GetTableColorByRetailer("");
            document = new Document();
            document.Info.Title = "Invoice - ";
            document.DefaultPageSetup.PageHeight = page_height;
            document.DefaultPageSetup.PageWidth = page_width;
            document.DefaultPageSetup.TopMargin = margin;
            document.DefaultPageSetup.LeftMargin = margin;
            document.DefaultPageSetup.RightMargin = margin;
            document.DefaultPageSetup.BottomMargin = bottom_margin;

            DefineStyle();

            Section sec = document.AddSection();

            Tools.AddInvoiceFooter(ref sec);

            Image image = new Image();
            image = sec.AddImage(Tools.GetMainPageHeader());

            image.Width = "190mm";
            image.Height = "40mm";
            image.Left = ShapePosition.Center;


            image = sec.AddImage("C:\\images\\transpix.gif");
            image.Height = "3mm";
            image.Width = table_width;

            Table t = sec.AddTable();
            Column c = t.AddColumn("95mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c = t.AddColumn("95mm");
            c.Format.Alignment = ParagraphAlignment.Right;
            Row r = t.AddRow();

            Paragraph p = r.Cells[0].AddParagraph();
            p.Style = "Heading1";
            p.AddText("Invoice");
            p.Format.Alignment = ParagraphAlignment.Center;
            r.Cells[0].MergeRight = 1;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
        
            //p.Style = "Heading2";
            //p.AddText("Date: " + System.DateTime.Today.Date.ToLongDateString());
            p.AddText("Sportcruiser Aviation");
            p.AddLineBreak();
            p.AddText("157 Viewmount Park");
            p.AddLineBreak();
            p.AddText("Dunmore Road");
            p.AddLineBreak();
            p.AddText("Waterford");
            p.AddLineBreak();
            p.AddText("Ireland");
            p.AddLineBreak();


            p = r.Cells[1].AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Right;

            p.AddText("Hayward Aviation");
            p.AddLineBreak();
            p.AddText("The St Botolph Building");
            p.AddLineBreak();
            p.AddText("138 Houndsditch");
            p.AddLineBreak();
            p.AddText("London EC3A 7AW");
            p.AddLineBreak();
            p.AddText("Telephone:    0207 902 7800");
            p.AddLineBreak();
            p.AddText("Fax:    0207 928 8040");
            p.AddLineBreak();

            r = t.AddRow();
         
            p = r.Cells[0].AddParagraph();
            p.AddText("Date: " + System.DateTime.Today.Date.ToLongDateString());

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            
            p.AddFormattedText("Policy Number F186583", TextFormat.NotBold);
            p.AddLineBreak();

            p = r.Cells[1].AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Right;
            p.AddText("Invoice Number F186583001RN");

            AddClientDetails(sec);
                       
            AddMiddleParagraph(sec);

            AddBankDetails(sec);

            AddLastParagraph(sec);
            return SaveDocument(document);
        }


        private string SaveDocument(Document document)
        {
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            PdfSharp.Pdf.PdfDocument pdfdoc = pdfRenderer.PdfDocument;
            pdfdoc.ViewerPreferences.FitWindow = false;
            pdfdoc.PageLayout = PdfSharp.Pdf.PdfPageLayout.SinglePage;
            pdfdoc.PageMode = PdfSharp.Pdf.PdfPageMode.UseNone;
          
            if (!System.IO.Directory.Exists(travelDocumentFolder))
                System.IO.Directory.CreateDirectory(travelDocumentFolder);

            string fileName = travelDocumentFolder + "\\Invoice.pdf";

            pdfRenderer.PdfDocument.Save(fileName);

            System.Diagnostics.Process.Start(fileName);

            return fileName;
        }
        public void AddClientDetails(Section sec)
        {
            Table t = sec.AddTable();

            t.LeftPadding = "0mm";
            t.RightPadding = "0mm";
            t.TopPadding = "0mm";
            t.BottomPadding = "0mm";

            Column c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("34mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("49mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("75mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("30mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            Row r = t.AddRow();
            r.Height = "2mm";
            r.Cells[0].AddImage("C:\\images\\transpix.gif").Height = "1mm";
            // r.Cells[1].MergeDown = 2;
            r.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            Image icn = new Image();

            r = t.AddRow();
            r.Style = "Heading3";
            r.TopPadding = row_padding;
            r.BottomPadding = row_padding;

            Paragraph p = r.Cells[1].AddParagraph();
            p.AddSpace(4);
            p.AddText("Policy Details");
            r.Cells[1].Shading.Color = table_color;
            r.Cells[0].Shading.Color = table_color;
            r.Cells[2].MergeRight = 4;
            r.Cells[1].MergeRight = 5;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddText("With regards to your policy below we set out details of the following transactions effected on your behalf: -");
            r.Cells[1].MergeRight = 5;
            r.Cells[1].Format.Alignment = ParagraphAlignment.Center;

            r = t.AddRow();
           // r = t.AddRow();


            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Assured", TextFormat.Bold);
            p.AddLineBreak();

            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("Sportcruiser Aviation &/or the Irish Light Aviation Society (ILAS) for their respective rights and interests");
            r.Cells[3].MergeRight = 3;

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Policy Period:", TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("11th March 2019 to 10th March 2020 both days inclusive");
            r.Cells[3].MergeRight = 3;

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Type of Business", TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("Munich RE Hull and Liability Insurance");
            r.Cells[3].MergeRight = 3;

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Regarding", TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("Original Premium 2018/19");
            r.Cells[3].MergeRight = 3;

         
            //r = t.AddRow();
            //r.Cells[1].Borders.Right.Width = 0.5;
            //r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[4].AddParagraph();
            //p.AddSpace(1);
            p.AddFormattedText("Gross Premium", TextFormat.Bold);

            p = r.Cells[5].AddParagraph();
            p.AddText("GBP      1,947.12");
            p.AddLineBreak();
          
            r = t.AddRow();
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("Plus Customer Service Charge", TextFormat.Bold);
          
            p = r.Cells[5].AddParagraph();
            p.AddText("GBP      31.50");

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("Premium Due", TextFormat.Bold);
            p = r.Cells[5].AddParagraph();
            p.AddFormattedText("GBP      1,978.62","Heading4");
            p.AddLineBreak();

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("THIS PREMIUM IS DUE AND PAYABLE BY RETURN","Heading4");
            r.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            r.Cells[1].MergeRight = 5;



            r.BottomPadding = row_top_padding;
            t.Rows[0].KeepWith = t.Rows.Count - 1;
            t.SetEdge(0, 1, t.Columns.Count, t.Rows.Count - 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, table_boarder, table_color);
        }

        public void AddMiddleParagraph(Section sec)
        {
            Table t = sec.AddTable();

            t.LeftPadding = "0mm";
            t.RightPadding = "0mm";
            t.TopPadding = "0mm";
            t.BottomPadding = "0mm";

            Column c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("188mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            Row r = t.AddRow();

            r = t.AddRow();

            Paragraph p = r.Cells[1].AddParagraph();

            p.AddText("If you have any queries with this invoice or with any other accounting query please do not hesitate to contact us on 020 7902 7800");
            
            p.AddLineBreak();

            p.AddLineBreak();

            p.AddText("For BACS transfers our bank details are as follows, alternatively if you could make cheques payable to, Hayward Aviation, at the address below:-");
            p.AddLineBreak();
           
            //p.AddText("SIGNED ..................................");

            //p.AddLineBreak();
            //p.AddLineBreak();
            //p.AddLineBreak();
            //p.AddLineBreak();

            //p.AddFormattedText("E.& O.E", TextFormat.Bold);
        }

        public void AddLastParagraph(Section sec)
        {
            Table t = sec.AddTable();

            t.LeftPadding = "0mm";
            t.RightPadding = "0mm";
            t.TopPadding = "0mm";
            t.BottomPadding = "0mm";

            Column c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("25mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("163mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            Row r = t.AddRow();

            Paragraph p = r.Cells[1].AddParagraph();
            p.AddLineBreak();
            r.Cells[1].MergeRight = 1;

            p.AddFormattedText("This insurance may have been declared from a facility which may produce an additional commission to the coverholder dependent upon the profitability of that facility", "Heading7");

            p.AddLineBreak();
            
            p.AddFormattedText("E.& O.E", TextFormat.Bold);

            p.AddLineBreak();
            r = t.AddRow();

            Image image = r.Cells[2].AddImage(@"C:\images\Signature.png");
           // Image image = new Image();
          //  image = sec.AddImage(@"C:\images\Signature.png");

            image.Width = "25mm";
            image.Height = "20mm";
            //image.Left = ShapePosition.Center;

        }

        public void DefineStyle()
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Arial";
            style.Font.Size = 10;
            style.Font.Color = new Color(0, 0, 0);//new Color(97, 106, 116);               //new Color(91, 91, 92);

            style = document.Styles["Heading1"];
            style.Font.Name = "Arial";
            style.Font.Size = 13;
            style.Font.Bold = true;
            style.Font.Color = new Color(0, 0, 0);//new Color(91, 91, 92);  //flt grey


            style = document.Styles["Heading2"];
            style.Font.Name = "Arial";
            style.Font.Size = 11;
            style.Font.Bold = false;
            style.Font.Color = new Color(0, 0, 0);////blue //color(0,0,0)

            style = document.Styles["Heading3"]; // All white for header headings.
            style.Font.Name = "Arial";
            style.Font.Size = 13;
            style.Font.Bold = true;
            style.Font.Color = new Color(255, 255, 255);

            style = document.Styles["Heading4"];
            style.Font.Name = "Arial";
            style.Font.Size = 10;
            style.Font.Underline += 1;
            style.Font.Bold = true;
            style.Font.Color = new Color(0,0,0);//new Color(236, 178, 72);


            style = document.Styles["Heading5"];
            style.Font.Name = "Arial";
            style.Font.Size = 9;
            style.Font.Bold = true;
            style.Font.Color = new Color(255, 255, 255);
            style.Font.Underline += 0;

            style = document.Styles["Heading6"];
            style.Font.Name = "Arial";
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.Font.Underline += 0;
            style.Font.Color = new Color(33, 69, 122);

            style = document.Styles["Heading7"];
            style.Font.Name = "Arial";
            style.Font.Size = 8;
            style.Font.Bold = false;
            style.Font.Color = new Color(0, 0, 0);


            style = document.Styles["Heading8"];
            style.Font.Name = "Arial";
            style.Font.Size = 10;
            style.Font.Color = new Color(255, 255, 255);


            style = document.Styles["Heading9"];  //for footer.
            style.Font.Name = "Arial";
            style.Font.Size = 8.5;
            style.Font.Bold = false;
            style.Font.Color = new Color(91, 91, 92);


        }

        public void AddBankDetails(Section sec)
        {
            Table t = sec.AddTable();

            t.LeftPadding = "0mm";
            t.RightPadding = "0mm";
            t.TopPadding = "0mm";
            t.BottomPadding = "0mm";

            Column c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("30mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("35mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("20mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("24mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("53mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("27mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            Row r = t.AddRow();
            r.Height = "2mm";
            r.Cells[0].AddImage("C:\\images\\transpix.gif").Height = "1mm";
            // r.Cells[1].MergeDown = 2;
            r.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            Image icn = new Image();

            r = t.AddRow();
            r.Style = "Heading5";
            r.TopPadding = row_padding;
            r.BottomPadding = row_padding;

            Paragraph p = r.Cells[1].AddParagraph();
            p.AddText("Bank");
            r.Cells[1].Shading.Color = table_color;
            r.Cells[0].Shading.Color = table_color;
            //r.Cells[2].MergeRight = 4;
            // r.Cells[1].MergeRight = 5;

            p = r.Cells[2].AddParagraph();
            p.AddText("Currency");
            r.Cells[2].Shading.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("Sort Code");
            r.Cells[3].Shading.Color = table_color;

            p = r.Cells[4].AddParagraph();
            p.AddText("Account Code");
            r.Cells[4].Shading.Color = table_color;

            p = r.Cells[5].AddParagraph();
            p.AddText("IBAN Code");
            r.Cells[5].Shading.Color = table_color;

            p = r.Cells[6].AddParagraph();
            p.AddText("BIC Code");
            r.Cells[6].Shading.Color = table_color;


            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddText("Barclays Bank");
           

            p = r.Cells[2].AddParagraph();
            p.AddText("Sterling");
           
            p = r.Cells[3].AddParagraph();
            p.AddText("20-00-00");
           
            p = r.Cells[4].AddParagraph();
            p.AddText("03148521");
          
            p = r.Cells[5].AddParagraph();
            p.AddText("GB15 BARC 2000 0003 1485 21");
           
            p = r.Cells[6].AddParagraph();
            p.AddText("BARCGB22");

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddText("Barclays Bank");


            p = r.Cells[2].AddParagraph();
            p.AddText("Sterling");

            p = r.Cells[3].AddParagraph();
            p.AddText("20-00-00");

            p = r.Cells[4].AddParagraph();
            p.AddText("03148521");

            p = r.Cells[5].AddParagraph();
            p.AddText("GB15 BARC 2000 0003 1485 21");

            p = r.Cells[6].AddParagraph();
            p.AddText("BARCGB22");

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddText("Barclays Bank");


            p = r.Cells[2].AddParagraph();
            p.AddText("Sterling");

            p = r.Cells[3].AddParagraph();
            p.AddText("20-00-00");

            p = r.Cells[4].AddParagraph();
            p.AddText("03148521");

            p = r.Cells[5].AddParagraph();
            p.AddText("GB15 BARC 2000 0003 1485 21");

            p = r.Cells[6].AddParagraph();
            p.AddText("BARCGB22");

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddText("Barclays Bank");


            p = r.Cells[2].AddParagraph();
            p.AddText("Sterling");

            p = r.Cells[3].AddParagraph();
            p.AddText("20-00-00");

            p = r.Cells[4].AddParagraph();
            p.AddText("03148521");

            p = r.Cells[5].AddParagraph();
            p.AddText("GB15 BARC 2000 0003 1485 21");

            p = r.Cells[6].AddParagraph();
            p.AddText("BARCGB22");

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddText("Barclays Bank");


            p = r.Cells[2].AddParagraph();
            p.AddText("Sterling");

            p = r.Cells[3].AddParagraph();
            p.AddText("20-00-00");

            p = r.Cells[4].AddParagraph();
            p.AddText("03148521");

            p = r.Cells[5].AddParagraph();
            p.AddText("GB15 BARC 2000 0003 1485 21");

            p = r.Cells[6].AddParagraph();
            p.AddText("BARCGB22");


            r.BottomPadding = row_top_padding;
            t.Rows[0].KeepWith = t.Rows.Count - 1;
            t.SetEdge(0, 1, t.Columns.Count, t.Rows.Count - 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, table_boarder, table_color);
        }


    }
}
