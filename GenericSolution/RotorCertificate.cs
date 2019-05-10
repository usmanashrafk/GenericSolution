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
    public class RotorCertificate : IDocument<string>
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


        public RotorCertificate()
        {
            travelDocumentFolder = @"C:\PDFGenerator\";
        }


        public string GenerateDocument()
        {
            table_color = Tools.GetTableColorByRetailer("");
            document = new Document();
            document.Info.Title = "Certificate Of Insurance" ;
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


           
            Table t = sec.AddTable();
            Column c = t.AddColumn("95mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c = t.AddColumn("95mm");
            c.Format.Alignment = ParagraphAlignment.Right;

            Row r = t.AddRow();

          

            Paragraph p = r.Cells[0].AddParagraph();
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

            p = r.Cells[0].AddParagraph();
            //p.Style = "Heading2";
            r.Cells[0].MergeRight = 1;
            p.AddFormattedText("IT IS HEREBY CERTIFIED THAT:",TextFormat.Underline);
            p = sec.AddParagraph();
            AddClientDetails(sec);
           
            // AddGeographicalLimits(sec);

            sec = document.AddSection();

           Tools.AddNoFooter(ref sec);

            AddHeader(sec);
        
            AddClientDetailsPage2(sec);

            AddAircraftsSchedules(sec);

            AddLastParagraph(sec);

            return SaveDocument(document);
        }


        private string SaveDocument(Document document)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding)
            {
                Document = document
            };
#pragma warning restore CS0618 // Type or member is obsolete

           // pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.RenderDocument();
            PdfSharp.Pdf.PdfDocument pdfdoc = pdfRenderer.PdfDocument;
            pdfdoc.ViewerPreferences.FitWindow = false;
            pdfdoc.PageLayout = PdfSharp.Pdf.PdfPageLayout.SinglePage;
            pdfdoc.PageMode = PdfSharp.Pdf.PdfPageMode.UseNone;

            if (!System.IO.Directory.Exists(travelDocumentFolder))
                System.IO.Directory.CreateDirectory(travelDocumentFolder);

            string fileName = travelDocumentFolder + "\\CertificateOfInsurance.pdf";

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
            Paragraph p = r.Cells[1].AddParagraph();
                      
         

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
          
            p = r.Cells[3].AddParagraph();
          //  r.Cells[3].Format.Alignment = ParagraphAlignment.Justify;
            p.AddText("Mr. T is/are insured as operator(s) in respect of the aircraft listed in the schedule of aircraft below for the period as stated hereunder for flights Worldwide, excluding the following countries and regions:");

            p.AddLineBreak();
            p.AddLineBreak();

            p.AddText("(a)");
            p.AddTab();
            p.AddText("Algeria, Burundi, Cabinda, Central African Republic, Congo, Democratic Republic of Congo, Eritrea, Ethiopia, Ivory Coast, Liberia, Mauritania, Nigeria, Somalia, The Republic of Sudan, South Sudan;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(b) ");
                p.AddTab();
            p.AddText("Colombia, Ecuador, Peru;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(c)");
                 p.AddTab();
            p.AddText("Afghanistan, Jammu&Kashmir, Myanmar, NorthKorea, Pakistan;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(d)");
                 p.AddTab();
            p.AddText("Georgia, Nagorno-Karabakh, North Caucasian Federal District, Ukraine;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(e)");
                 p.AddTab();
            p.AddText("Iran, Iraq, Libya, Syria, Yemen;");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(f)");
            p.AddTab();
            p.AddText("United States of America and Canada.");
            p.AddLineBreak();
            p.AddLineBreak();
            
            p.AddText("In addition coverage is granted:");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("(i)");
            p.AddTab();
            p.AddText("for the overflight of any excluded country or region where the flight is within an internationally recognised air corridor and is performed in accordance with I.C.A.O. recommendations; or");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("ii)");
            p.AddTab();
            p.AddText("in circumstances where an insured Aircraft has landed in an excluded country or region as a direct consequence and exclusively as a result of force majeure.");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("Notwithstanding the above,coverage is excluded for any flight into any country or region where such operation of the Aircraft is in breach of United Nations or European Union sanctions.");

            p.AddLineBreak();
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("RISKS INSURED:", TextFormat.Underline);

            p = r.Cells[3].AddParagraph();
           // r.Cells[3].Format.Alignment = ParagraphAlignment.Justify;
            p.AddFormattedText("Rotors in Motion and Rotors Not in Motion / Transported – Sections I, II and III",TextFormat.Bold);

            p.AddLineBreak();
            p.AddLineBreak();

            p.AddFormattedText("Hull \"All Risks\" Insurance",TextFormat.Bold);

            p.AddLineBreak();
            p.AddLineBreak();

            p.AddText("Hull Deductible    of Aircraft Value Each and Every Claim including Total Loss, subject to a maximum of GBP 30,000 (or currency equivalent) Each and Every Claim including Total Loss.");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("Includes the legal liability and/or as more fully described in the respective policies in respect of bodily injury and/or property damage to third parties including passengers up to the following limits of liability each aircraft.");

            p.AddText("Combined Single Limit (Third Party/Passenger Legal Liability)   any one accident, " +
                "but unlimited in all during the currency of this policy and " +
                "including GBP 7, 500, 000 any one accident in respect of Crown Indemnity.");
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

            c = t.AddColumn("9mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("150mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            Row r = t.AddRow();
           
            r = t.AddRow();
            r.Style = "Heading3";
            r.TopPadding = row_padding;
            r.BottomPadding = row_padding;

            r = t.AddRow();
            Paragraph p = r.Cells[1].AddParagraph();
           
            p = r.Cells[2].AddParagraph();
            r.Cells[2].MergeRight = 1;
            p.AddText("War and Allied Risks are also covered, in accordance with Special Provision 10 of the policy, which provides comparable coverage with Extended Coverage Endorsement (Aviation Liabilities) AVN52E for a limit of      any one accident and in the annual aggregate");

            p.AddLineBreak();
            p.AddLineBreak();

            p.AddText("The amounts of insurance stated herein are in accordance with the minimum insurance cover requirements of Articles 6 and 7 of Regulation (EC) No 785/2004 based on:");
            r = t.AddRow();
            p = r.Cells[2].AddParagraph();
            p.AddText("(a)");
            p = r.Cells[3].AddParagraph();
            p.AddText("The rates of exchange applicable to Special Drawing Rights at inception of the insurances,");
            r = t.AddRow();
            p = r.Cells[2].AddParagraph();
            p.AddText("(b)");
            p = r.Cells[3].AddParagraph();
            p.AddText("Third Party War, terrorism and allied perils being insured on an aggregate basis as above, as permissible in accordance with Article 7.1 of EC Regulation 785/2004.");
            r = t.AddRow();
            p = r.Cells[2].AddParagraph();
            p.AddText("(c)");
            p = r.Cells[3].AddParagraph();
            p.AddText("It being understood that such aggregate limits may be reduced or exhausted during the policy period by virtue of claims made against aircraft or other operational interest covered by the insurances.");

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("PERIOD:", TextFormat.Underline);

            p = r.Cells[2].AddParagraph();
            r.Cells[2].MergeRight = 1;
            p.AddText("11th March 2019 to 10th March 2020 both days inclusive local standard time at the Insureds address as stated");

            r = t.AddRow();

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            //p.AddSpace(1);
            p.AddFormattedText("PILOTS:", TextFormat.Underline);

            p = r.Cells[2].AddParagraph();
            r.Cells[2].MergeRight = 1;
            p.AddText("Mr. A");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("In addition, whilst giving instructions to the aforementioned pilots, any qualified flying instructor/examiner is automatically included as an approved pilot hereon");

            r = t.AddRow();

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            //p.AddSpace(1);
            p.AddFormattedText("USES:", TextFormat.Underline);

            p = r.Cells[2].AddParagraph();
            r.Cells[2].MergeRight = 1;
            p.AddText("      (as more fully defined in our Certificate Wording).");
          
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
            r.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                      
            p.AddFormattedText("COVERAGE IS AT ALL TIMES SUBJECT TO THE CERTIFICATE WORDING COVERAGE TERMS CONDITIONS LIMITATIONS AND EXCLUSIONS", "Heading4");

            r = t.AddRow();

            r = t.AddRow();
            r.Cells[1].MergeRight = 1;

            p = r.Cells[1].AddParagraph();

            p.AddText("For and on behalf of HAYWARD AVIATION (a trading name of JLT Specialty Limited)");



            r = t.AddRow();
            r = t.AddRow();


            p = r.Cells[1].AddParagraph();
            
            p.AddText("SIGNED  .................");
                        
            Image image = r.Cells[2].AddImage(@"C:\images\Signature.png");
            
            image.Width = "25mm";
            image.Height = "20mm";
            p.AddLineBreak();
            r = t.AddRow();
            r = t.AddRow();
            p.AddLineBreak();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("E.& O.E",TextFormat.Bold);
        }

        public void AddAircraftsSchedules(Section sec)
        {
            Table t = sec.AddTable();

            t.LeftPadding = "0mm";
            t.RightPadding = "0mm";
            t.TopPadding = "0mm";
            t.BottomPadding = "0mm";

            Column c = t.AddColumn("28mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("50mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("50mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("60mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("2mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            Row r = t.AddRow();

            r = t.AddRow();
            Paragraph p = p = r.Cells[0].AddParagraph(); 
            
            r.Cells[0].MergeRight = 3;

            r.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            p.AddFormattedText("SCHEDULE OF AIRCRAFT", TextFormat.Underline);


            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();

            r.Cells[1].Format.Alignment = ParagraphAlignment.Center;

            p.AddFormattedText("Aircraft Type", TextFormat.Underline);

            p = r.Cells[2].AddParagraph();
            r.Cells[2].Format.Alignment = ParagraphAlignment.Center;

            p.AddFormattedText("Registration", TextFormat.Underline);


            p = r.Cells[3].AddParagraph();
            r.Cells[3].Format.Alignment = ParagraphAlignment.Center;

            p.AddFormattedText("Passenger Seats", TextFormat.Underline);


           r = t.AddRow();

            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            r.Cells[1].Format.Alignment = ParagraphAlignment.Center;

            p.AddFormattedText("Acrosport 1");

            p = r.Cells[2].AddParagraph();
            r.Cells[2].Format.Alignment = ParagraphAlignment.Center;

            p.AddFormattedText("G-BSHY");


            p = r.Cells[3].AddParagraph();
            r.Cells[3].Format.Alignment = ParagraphAlignment.Center;

            p.AddFormattedText("2");



            r = t.AddRow();

            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("INSURER:", TextFormat.Underline);
            p.AddLineBreak();


            p = r.Cells[1].AddParagraph();
            r.Cells[1].MergeRight = 2;
            p.AddText("Great Lakes Insurance SE a wholly owned subsidiary of the group Munich RE");
            p.AddLineBreak();


            r = t.AddRow();

            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("POLICY NO:", TextFormat.Underline);

            p = r.Cells[1].AddParagraph();
            p.AddText("X09898 / ABZ453");
        }


        private void AddHeader(Section sec)
        {
            Image image = new Image();

            image = sec.AddImage(Tools.GetHeaderWithoutText());
            image.Left = ShapePosition.Center;
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
            style.Font.Color = new Color(0, 0, 0);//new Color(236, 178, 72);


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

        public void AddGeographicalLimits(Section sec)
        {
            Table t = sec.AddTable();

            t.LeftPadding = "0mm";
            t.RightPadding = "0mm";
            t.TopPadding = "0mm";
            t.BottomPadding = "0mm";

            Column c = t.AddColumn("10mm"); //0
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("10mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("102mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("66mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("2mm"); //3
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";


            Row r = t.AddRow();
            Paragraph p = r.Cells[3].AddParagraph();
            p.AddFormattedText("F186583 / 0448", TextFormat.Bold);
            p.Format.Alignment = ParagraphAlignment.Right;
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("8.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("GEOGRAPHICAL LIMITS:", TextFormat.Bold);
            r.Cells[1].MergeRight = 2;
            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            r.Cells[1].MergeRight = 2;
            p.AddText("Worldwide, excluding the following countries and regions:");
            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(a)");

            p = r.Cells[2].AddParagraph();
            p.AddText("Algeria, Burundi, Cabinda, Central African Republic, Congo, Democratic Republic of Congo, Eritrea, Ethiopia, Ivory Coast, Liberia, Mauritania, Nigeria, Somalia, The Republic of Sudan, South Sudan;");
            r.Cells[2].MergeRight = 2;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(b)");

            p = r.Cells[2].AddParagraph();
            p.AddText("Colombia, Ecuador, Peru;");
            r.Cells[2].MergeRight = 2;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(c)");

            p = r.Cells[2].AddParagraph();
            p.AddText("Afghanistan, Jammu&Kashmir, Myanmar, NorthKorea, Pakistan;");
            r.Cells[2].MergeRight = 2;


            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(d)");

            p = r.Cells[2].AddParagraph();
            p.AddText("Georgia, Nagorno-Karabakh, North Caucasian Federal District, Ukraine;");
            r.Cells[2].MergeRight = 2;


            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(e)");

            p = r.Cells[2].AddParagraph();
            p.AddText("Iran, Iraq, Libya, Syria, Yemen;");
            r.Cells[2].MergeRight = 2;


            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(f)");

            p = r.Cells[2].AddParagraph();
            p.AddText("United States of America and Canada.");
            r.Cells[2].MergeRight = 2;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("In addition coverage is granted:");

            r.Cells[1].MergeRight = 2;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(i)");

            p = r.Cells[2].AddParagraph();
            p.AddText("for the overflight of any excluded country or region where the flight is within an internationally recognised air corridor and is performed in accordance with I.C.A.O. recommendations; or");
            r.Cells[2].MergeRight = 2;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(ii)");

            p = r.Cells[2].AddParagraph();
            p.AddText("in circumstances where an insured Aircraft has landed in an excluded country or region as a direct consequence and exclusively as a result of force majeure.");
            r.Cells[2].MergeRight = 2;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("Notwithstanding the above,coverage is excluded for any flight into any country or region where such operation of the Aircraft is in breach of United Nations or European Union sanctions.");

            r.Cells[1].MergeRight = 3;

        }

    }
}
