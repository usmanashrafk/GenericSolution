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
using iTextSharp.text.pdf;

namespace GenericSolution
{
    public class Certificate : IDocument<string>
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


        public Certificate()
        {
            travelDocumentFolder = @"C:\PDFGenerator\";
        }


        public string GenerateDocument()
        {
            table_color = Tools.GetTableColorByRetailer("");
            document = new Document();
            document.Info.Title = "Insurance Docs - " ;
            document.DefaultPageSetup.PageHeight = page_height;
            document.DefaultPageSetup.PageWidth = page_width;
            document.DefaultPageSetup.TopMargin = margin;
            document.DefaultPageSetup.LeftMargin = margin;
            document.DefaultPageSetup.RightMargin = margin;
            document.DefaultPageSetup.BottomMargin = bottom_margin;
          
         DefineStyle();

            Section sec = document.AddSection();

            Tools.AddMainFooter(ref sec);
            
            Image image = new Image();
            image = sec.AddImage(Tools.GetMainPageHeader());

            image.Width = "190mm";
            image.Height = "50mm";
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
            p.Style = "Heading2";
            p.AddText("X09898"); //Policy No.


            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            p.Style = "Heading2";
            p.AddText("TO WHOM IT MAY CONCERN");

            p = r.Cells[1].AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Right;
            p.Style = "Heading2";
            p.AddText("Date: "+System.DateTime.Today.Date.ToLongDateString());

            r = t.AddRow();

            r = t.AddRow();

            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            //p.Style = "Heading2";
            r.Cells[0].MergeRight = 1;
            p.AddFormattedText("IT IS HEREBY CERTIFIED THAT:",TextFormat.Underline);
            p.AddLineBreak();
         
            
            //sec.AddParagraph();
            p = sec.AddParagraph();

            AddClientDetails(sec);

            sec = document.AddSection();

           Tools.AddNoFooter(ref sec);

            image = sec.AddImage(Tools.GetHeaderWithText());

          //  image.Width = "190mm";
         //   image.Height = "25mm";
            image.Left = ShapePosition.Center;


            image = sec.AddImage("C:\\images\\transpix.gif");
            image.Height = "3mm";
            image.Width = table_width;

            AddClientDetailsPage2(sec);

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
            //pdfdoc.Info.Keywords = "HORIZON HOTEL & VILLAS, AGHIOS IOANN, AirportCode:  JMK,  37.418820 ,25.314735  , latitude: 37.418820 , longitude: 25.314735";
            //pdfdoc.Info.Subject = "HORIZON HOTEL & VILLAS, AGHIOS IOANN, AirportCode:  JMK,  37.418820 ,25.314735  , latitude: 37.418820 , longitude: 25.314735";
            //pdfdoc.Info.Title = "HORIZON HOTEL & VILLAS, AGHIOS IOANN, AirportCode:  JMK,  37.418820 ,25.314735  , latitude: 37.418820 , longitude: 25.314735";

            //pdfdoc.Info.Creator = "HORIZON HOTEL & VILLAS, AGHIOS IOANN, AirportCode:  JMK,  37.418820 ,25.314735  , latitude: 37.418820 , longitude: 25.314735";
            //pdfdoc.Info.Author = "HORIZON HOTEL & VILLAS, AGHIOS IOANN, AirportCode:  JMK,  37.418820 ,25.314735  , latitude: 37.418820 , longitude: 25.314735";

            if (!System.IO.Directory.Exists(travelDocumentFolder))
                System.IO.Directory.CreateDirectory(travelDocumentFolder);

            string fileName = travelDocumentFolder + "\\Certificate.pdf";

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

            c = t.AddColumn("29mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("158mm");
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
            p.AddText("Insurance Details");
            r.Cells[1].Shading.Color = table_color;
            r.Cells[0].Shading.Color = table_color;
            r.Cells[2].MergeRight = 2;
            r.Cells[1].MergeRight = 3;

            r = t.AddRow();
            r.Height = "1mm";
            r.Cells[0].AddImage("C:\\images\\transpix.gif").Height = "1mm";
            r.Cells[2].MergeRight = 2;
            r.Cells[2].AddImage("C:\\images\\transpix.gif").Height = "1mm";
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;
            p = r.Cells[3].AddParagraph();
            p.AddFormattedText("G-BSHY",TextFormat.Bold);
            p.AddTab();
            p.AddTab();
            p.AddTab();
            p.AddFormattedText("Acrosport 1",TextFormat.Bold);
            p.AddTab();
            p.AddTab();
            p.AddTab();
            p.AddFormattedText("MTOM 1000 kgs", TextFormat.Bold);
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("and a maximum of 1 passenger seats is engaged in Private Business and Pleasure Uses (as more fully defined in the Certificate Wording)");

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Insured By:", TextFormat.Bold);
            p.AddLineBreak();
           
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("Great Lakes Insurance SE a wholly owned subsidiary of the group Munich RE");
           // p.AddLineBreak();

          
            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Under Policy No:",TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("X09898");


            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("In the name of:", TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("Test 06");

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("For the period:",TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;
          
            p = r.Cells[3].AddParagraph();
            p.AddText("11th March 2019 to 10th March 2020 both days inclusive");

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            //p.AddSpace(1);
            p.AddFormattedText("With pilots:", TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("Mr. A");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("In addition, whilst giving instructions to the aforementioned pilots, any qualified flying instructor/examiner is automatically included as an approved pilot hereon");

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Against:", TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("The risks of accidental loss of or damage whilst the aircraft is in flight or on the ground anywhere Worldwide, excluding the following countries and regions:");
            p.AddLineBreak();
            p.AddLineBreak();

            p.AddText("(a) Algeria, Burundi, Cabinda, Central African Republic, Congo, Democratic Republic of Congo, Eritrea, Ethiopia, Ivory Coast, Liberia, Mauritania, Nigeria, Somalia, The Republic of Sudan, South Sudan;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(b) Colombia, Ecuador, Peru;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(c) Afghanistan, Jammu&Kashmir, Myanmar, NorthKorea, Pakistan;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(d) Georgia, Nagorno-Karabakh, North Caucasian Federal District, Ukraine;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(e) Iran, Iraq, Libya, Syria, Yemen;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(f) United States ofAmerica and Canada.");
            p.AddLineBreak();
           

            r.BottomPadding = row_top_padding;
            t.Rows[0].KeepWith = t.Rows.Count - 1;
            t.SetEdge(0, 1, t.Columns.Count, t.Rows.Count - 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, table_boarder, table_color);
        }

        public void AddClientDetailsPage2(Section sec)
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

            c = t.AddColumn("29mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("158mm");
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
            p.AddText("Insurance Details (Cont.)");
            r.Cells[1].Shading.Color = table_color;
            r.Cells[0].Shading.Color = table_color;
            r.Cells[2].MergeRight = 2;
            r.Cells[1].MergeRight = 3;

            r = t.AddRow();
            r.Height = "1mm";
            r.Cells[0].AddImage("C:\\images\\transpix.gif").Height = "1mm";
            r.Cells[2].MergeRight = 2;
            r.Cells[2].AddImage("C:\\images\\transpix.gif").Height = "1mm";
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;
            p = r.Cells[3].AddParagraph();
            p.AddText("In addition coverage is granted:");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(i) for the overflight of any excluded country or region where the flight is within an internationally recognised air corridor and is performed in accordance with I.C.A.O. recommendations; or");
            p.AddLineBreak();
            p.AddText("ii) in circumstances where an insured Aircraft has landed in an excluded country or region as a direct consequence and exclusively as a result of force majeure.");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("Notwithstanding the above,coverage is excluded for any flight into any country or region where such operation of the Aircraft is in breach of United Nations or European Union sanctions.");

            p.AddLineBreak();
            p.AddText("");
            r = t.AddRow();
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Coverage:", TextFormat.Bold);
            r.Cells[1].Borders.Right.Width = 0.5;
            r.Cells[1].Borders.Right.Color = table_color;

            p = r.Cells[3].AddParagraph();
            p.AddText("Includes Legal Liability to Third Parties and Passengers up to the following limit of indemnity in accordance withEC Regulation 785/2004");


            p.AddLineBreak();
            p.AddText("Combined Single Limit (Third PartyLiability and Passenger Liability) any oneaccident increasing to GBP 7,500,000 any one accident in respect of Crown Indemnity and including German Limits and in accordance with The Danish Act DKK 65,000,000 any one accident.");

            p.AddLineBreak();
            p.AddText("War and Allied Risks (Extended Coverage Endorsement AVN 52E) up to a limit of EUR 5000 any one accident and in the annual aggregate (except for passengers to whom the full policy limits shall apply).");


            r.BottomPadding = row_top_padding;
            t.Rows[0].KeepWith = t.Rows.Count - 1;
            t.SetEdge(0, 1, t.Columns.Count, t.Rows.Count - 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, table_boarder, table_color);
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

            c = t.AddColumn("35mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("153mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            Row r = t.AddRow();

            r = t.AddRow();
            r.Cells[1].MergeRight = 1;

            Paragraph p = r.Cells[1].AddParagraph();
           
            p.AddText("It is hereby understood and agreed, effective inception,cover is extended to include the following provisions of the Crown Indemnity Agreement in respect of which the liability limit hereon is increased to GBP 7,500,000 any one accident.");

            p.AddLineBreak();


            p.AddLineBreak();

            p.AddText("It is hereby declared and agreed that notwithstanding anything contained in this insurance or in any memorandum, condition, or schedule attached hereto or forming part of this insurance, this insurance covers all sums within the total sum insured which the Insured shall become liable to pay under an undertaking with the Crown, which includes the requirements of Indemnity 3.81 of Ministry of Defence Form4a");
            p.AddLineBreak();
            p.AddLineBreak();

            p.AddFormattedText("COVERAGE IS AT ALL TIMES SUBJECT TO THE CERTIFICATE WORDING COVERAGE TERMS CONDITIONS LIMITATIONS AND EXCLUSIONS", TextFormat.Bold);
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddLineBreak();

            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            
            p.AddText("SIGNED  .................");
                        
            Image image = r.Cells[2].AddImage(@"C:\images\Signature.png");
            
            //Image image = new Image();
           // image = sec.AddImage(@"C:\images\Signature.png");

            image.Width = "25mm";
            image.Height = "20mm";
            p.AddLineBreak();
            r = t.AddRow();
            r = t.AddRow();
            p.AddLineBreak();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("E.& O.E",TextFormat.Bold);
        }

        public void DefineStyle()
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Arial";
            style.Font.Size = 10;
            style.Font.Color = new Color(0,0,0);//new Color(97, 106, 116);               //new Color(91, 91, 92);

            style = document.Styles["Heading1"];
            style.Font.Name = "Calibri";
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.Font.Color = new Color(0, 0, 0);//new Color(91, 91, 92);  //flt grey


            style = document.Styles["Heading2"];
            style.Font.Name = "Calibri";
            style.Font.Size = 11;
            style.Font.Bold = false;
            style.Font.Color = new Color(0, 0, 0);////blue //color(0,0,0)

            style = document.Styles["Heading3"]; // All white for header headings.
            style.Font.Name = "Calibri";
            style.Font.Size = 13;
            style.Font.Bold = true;
            style.Font.Color = new Color(255, 255, 255);

            style = document.Styles["Heading4"];
            style.Font.Name = "Calibri";
            style.Font.Size = 10;
            style.Font.Underline += 0;
            style.Font.Bold = true;
            style.Font.Color = new Color(236, 178, 72);


            style = document.Styles["Heading5"];
            style.Font.Name = "Calibri";
            style.Font.Size = 9.5;
            style.Font.Underline += 1;
            style.Font.Bold = false;
            style.Font.Color = new Color(0, 0, 0);//new Color(91, 91, 92);


            style = document.Styles["Heading6"];
            style.Font.Name = "Calibri";
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.Font.Underline += 0;
            style.Font.Color = new Color(33, 69, 122);

            style = document.Styles["Heading7"];
            style.Font.Name = "Calibri";
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Underline += 0;
            style.Font.Color = new Color(33, 69, 122);


            style = document.Styles["Heading8"];
            style.Font.Name = "Calibri";
            style.Font.Size = 10;
            style.Font.Color = new Color(255, 255, 255);


            style = document.Styles["Heading9"];  //for footer.
            style.Font.Name = "Calibri";
            style.Font.Size = 8.5;
            style.Font.Bold = false;
            style.Font.Color = new Color(91, 91, 92);


        }

       
    }
}
