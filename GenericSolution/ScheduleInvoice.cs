using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace GenericSolution
{
    public class ScheduleInvoice : IDocument<string>
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


        public ScheduleInvoice()
        {
            travelDocumentFolder = @"C:\PDFGenerator\";
        }


        public string GenerateDocument()
        {
            table_color = Tools.GetTableColorByRetailer();
            document = new Document();
            document.Info.Title = "ScheduleInvoice - ";
            document.DefaultPageSetup.PageHeight = page_height;
            document.DefaultPageSetup.PageWidth = page_width;
            document.DefaultPageSetup.TopMargin = margin;
            document.DefaultPageSetup.LeftMargin = margin;
            document.DefaultPageSetup.RightMargin = margin;
            document.DefaultPageSetup.BottomMargin = bottom_margin;

            DefineStyle();

            Section sec = document.AddSection();
            
            AddHeader(sec);
           
            Table t = sec.AddTable();
            Column c = t.AddColumn("120mm");
            c.Format.Alignment = ParagraphAlignment.Left;
            c = t.AddColumn("70mm");
            c.Format.Alignment = ParagraphAlignment.Right;
            Row r = t.AddRow();
            Paragraph p = r.Cells[1].AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Right;
            p.AddFormattedText("F186583 / 0448",TextFormat.Bold);
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.Style = "Heading1";
            p.AddText("SCHEDULE");
            p.Format.Alignment = ParagraphAlignment.Center;
            r.Cells[0].MergeRight = 1;

            Paragraph paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            sec.Footers.Primary.Add(paragraph);

            AddClientDetails(sec);

            AddAircraftDetails(sec);

            AddLastParagraph(sec);

            sec = document.AddSection();
          
            AddHeader(sec);

            AddGeographicalLimits(sec);
            AddAircraftAndPilotDetails(sec);
            AddEndorsementsDetails(sec);

            sec = document.AddSection();

            AddHeader(sec);

            AddPage3Details(sec);

            sec = document.AddSection();

            AddHeader(sec);

            AddPage4Details(sec);


            sec = document.AddSection();

            AddHeader(sec);

            AddPage5Details(sec);

            sec = document.AddSection();

            AddHeader(sec);

            AddPage6Details(sec);


            return SaveDocument(document);
        }

        private void AddHeader(Section sec)
        {
            Image image = new Image();

            image = sec.AddImage(Tools.GetHeaderWithoutText());

            image.Width = "190mm";
            image.Height = "25mm";
            image.Left = ShapePosition.Center;
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

            string fileName = travelDocumentFolder + "\\Schedule.pdf";

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

            Column c = t.AddColumn("5mm"); //0
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("35mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("16mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("40mm");  //3
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("44mm");  //4
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("35mm"); //5
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("14mm"); //6
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("1mm"); //7
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            Row r = t.AddRow();
            Paragraph p = r.Cells[1].AddParagraph();
            //p.AddSpace(4);
            //p.AddText("SCHEDULE");
            //r.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            //r.Cells[1].Shading.Color = table_color;
            //r.Cells[0].Shading.Color = table_color;
            //r.Cells[2].MergeRight = 5;
            //r.Cells[1].MergeRight = 6;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();

            p.AddFormattedText("ITEM", "Heading4");
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("1.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("AGREEMENT NO.:", TextFormat.Bold);
            p = r.Cells[2].AddParagraph();
            p.AddFormattedText("B0433F156315", TextFormat.Bold);
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("UNIQUE MARKET REFERENCE NO.:", TextFormat.Bold);
            r.Cells[1].MergeRight = 2;
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("CERTIFICATE NO:", TextFormat.Bold);
            r.Cells[4].MergeRight = 1;
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("B1612F186315", TextFormat.Bold);
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("F186583/448", TextFormat.Bold);
            p.AddLineBreak();

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("2.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("NAME AND ADDRESS OF THE INSURED:", TextFormat.Bold);
            r.Cells[1].MergeRight = 2;
            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("Sportcruiser Aviation &/or the Irish Light Aviation Society (ILAS) for their respective rights and interests");
            r.Cells[1].MergeRight = 4;
            p.AddLineBreak();
            p.AddText("157 Viewmount Park");
            p.AddLineBreak();
            p.AddText("Dunmore Road");
            p.AddLineBreak();
            p.AddText("Waterford");
            p.AddLineBreak();
            p.AddText("Ireland");
            p.AddLineBreak();

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("3.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("PERIOD OF INSURANCE:", TextFormat.Bold);
            r.Cells[1].MergeRight = 1;
            p = r.Cells[3].AddParagraph();
            p.AddFormattedText("From:",TextFormat.Bold);
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("24th September 2018", TextFormat.Bold);
            r = t.AddRow();
            p = r.Cells[3].AddParagraph();
            p.AddFormattedText("To:", TextFormat.Bold);
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("23rd September 2019", TextFormat.Bold);

            r = t.AddRow();
            p = r.Cells[3].AddParagraph();
            r.Cells[3].MergeRight = 3;

            p.AddFormattedText("Both days inclusive local standard time at the address of the Insured as stated.", TextFormat.Bold);

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("4.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("RISKS COVERED:", TextFormat.Bold);
            r.Cells[1].MergeRight = 1;

            p = r.Cells[3].AddParagraph();
            p.AddFormattedText("Flight, Taxiing, Ground and Transported (as more fully defined in the Certificate).", TextFormat.NotBold);
            r.Cells[3].MergeRight = 3;

           

        }

        public void AddAircraftDetails(Section sec)
        {
            Table t = sec.AddTable();

            t.LeftPadding = "0mm";
            t.RightPadding = "0mm";
            t.TopPadding = "0mm";
            t.BottomPadding = "0mm";

            Column c = t.AddColumn("5mm"); //0
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("37mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("40mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("70mm");  //3
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("36mm");  //4
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("2mm"); //5
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";
                       

            Row r = t.AddRow();
            Paragraph p = r.Cells[1].AddParagraph();
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("5.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("SCHEDULE OF AIRCRAFT INSURED:", TextFormat.Bold);
            r.Cells[1].MergeRight = 2;
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("MAKE & TYPE", "Heading4");

            p = r.Cells[2].AddParagraph();
            p.AddFormattedText("REGISTRATION MARKS", "Heading4");

            p = r.Cells[3].AddParagraph();
            p.AddFormattedText("DECLARED MAXIMUM NUMBER OF PASSENGERS CARRIED AT ONE TIME", "Heading4");

            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("AGREED VALUE", "Heading4");

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("Sportcruiser", TextFormat.Bold);

            p = r.Cells[2].AddParagraph();
            p.AddFormattedText("EI-EMV", TextFormat.Bold);

            p = r.Cells[3].AddParagraph();
            p.AddFormattedText("1", TextFormat.Bold);
            r.Cells[3].Format.Alignment = ParagraphAlignment.Center;


            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("GBP 70,000", TextFormat.Bold);
        }

        public void AddLastParagraph(Section sec)
        {
            Table t = sec.AddTable();

            t.LeftPadding = "0mm";
            t.RightPadding = "0mm";
            t.TopPadding = "0mm";
            t.BottomPadding = "0mm";

            Column c = t.AddColumn("5mm"); //0
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("117mm");    //1
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
            Paragraph p = r.Cells[1].AddParagraph();

            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("6.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("DEDUCTIBLES: (Applicable to Section I only)", TextFormat.Bold);

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("GBP 1,000 each and every claim excluding total loss.");

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            p.AddText("7.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("LIMITS OF INDEMNITY:", TextFormat.Bold);

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("SECTIONS II, III AND IV (LEGAL LIABILITY TO THIRD PARTIES, PASSENGERS, BAGGAGE / PERSONAL EFFECTS, CARGO, MAIL AND AIRCREW) COMBINED:", TextFormat.Bold);
            r.Cells[1].MergeRight = 1;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("GBP 2,000,000 (or equivalent in other currencies) any one accident, but increasing to GBP 7,500,000 (or equivalent in other currencies) any one accident in respect of Crown Indemnity");
            r.Cells[1].MergeRight = 1;

        }

        #region Page2
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
            p.AddText("United States ofAmerica and Canada.");
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

        public void AddAircraftAndPilotDetails(Section sec)
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

            c = t.AddColumn("45mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("67mm");    //1
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

            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("9.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("PURPOSES FOR WHICH THE AIRCRAFT WILL BE USED:", TextFormat.Bold);
            r.Cells[1].MergeRight = 2;
            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            r.Cells[1].MergeRight = 2;
            p.AddText("Private Business and Pleasure (as more fully defined in the Certificate).");

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            p.AddText("10.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("PILOTS", TextFormat.Bold);
                  

            p = r.Cells[2].AddParagraph();
            r.Cells[2].MergeRight = 2;
            p.AddText("Any pilot as approved by the Insured, subject to each pilot having at least a minimum of 100 Fixed Wing Piston Engine hours.");

            p.AddLineBreak();
            p.AddLineBreak();

            p.AddText("In addition, whilst giving instruction to the aforementioned pilots, any qualified flying instructor / examiner is automatically included as an approved pilot hereon.");


            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            p.AddText("11.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("PREMIUM:", TextFormat.Bold);


            p = r.Cells[2].AddParagraph();
            r.Cells[2].MergeRight = 2;
            p.AddText("GBP 1,947.12");
        }

        public void AddEndorsementsDetails(Section sec)
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

            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("12.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("ENDORSEMENTS APPLICABLE:", "Heading4");
            r.Cells[1].MergeRight = 2;
            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(a)");

            p = r.Cells[2].AddParagraph();
            p.AddFormattedText("Applicable to Certificate:",TextFormat.Bold);
            r.Cells[2].MergeRight = 2;

            p.AddLineBreak();
            p.AddLineBreak();

            p.AddText("(8)");
            p.AddSpace(5);
            p.AddText("Overseas Jurisdication Clause BREXIT Continuity Endorsement");

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[1].AddParagraph();
            p.AddText("(b)");

            p = r.Cells[2].AddParagraph();
            p.AddFormattedText("Applicable to Individual Aircraft:",TextFormat.Bold);
            r.Cells[2].MergeRight = 2;
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("None");
        }

        #endregion

        #region Page3

        public void AddPage3Details(Section sec)
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

            c = t.AddColumn("33mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("33mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("2mm"); //3
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";


            Row r = t.AddRow();
            Paragraph p = r.Cells[4].AddParagraph();
            p.AddFormattedText("F186583 / 0448",TextFormat.Bold);
            r.Cells[4].Format.Alignment = ParagraphAlignment.Right;
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("13.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("ANY ENQUIRY OR COMPLAINT RELATING TO THIS CERTIFICATE SHOULD BE ADDRESSED IN THE FIRST INSTANCE TO:", TextFormat.Bold);
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("Hayward Aviation, (The Broker)");
            p.AddLineBreak();
            p.AddText("The St Botolph Building,");
            p.AddLineBreak();
            p.AddText("138 Houndsditch,");
            p.AddLineBreak();
            p.AddText("London,");
            p.AddLineBreak();
            p.AddText("EC3A 7AW.");
            r.Cells[1].MergeRight = 4;

            r = t.AddRow();
            r = t.AddRow();

            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("14.");
            p = r.Cells[1].AddParagraph();
            r.Cells[1].MergeRight = 4;
            p.AddFormattedText("GREAT LAKES INSURANCE SE IS A GERMAN INSURANCE COMPANY WITH ITS HEADQUARTERS AT KÖNIGINSTRASSE 107, 80802 MUNICH.UK BRANCH OFFICE: PLANTATION PLACE, 30 FENCHURCH STREET, LONDON, EC3M 3AJ", TextFormat.Bold);
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            r.Cells[1].MergeRight = 4;
            r.Cells[1].Format.Alignment = ParagraphAlignment.Justify;
            p.AddFormattedText("GREAT LAKES INSURANCE SE, UK BRANCH, IS AUTHORISED BY BUNDESANSTALT FÜR FINANZDIENSTLEISTUNGSAUFSICHT AND SUBJECT TO LIMITED REGULATION BY THE FINANCIAL CONDUCT AUTHORITY AND PRUDENTIAL REGULATION AUTHORITY.DETAILS ABOUT THE EXTENT OF THEIR REGULATION BY THE FINANCIAL CONDUCT AUTHORITY AND PRUDENTIAL REGULATION AUTHORITY ARE AVAILABLE FROM THEM ON REQUEST.", TextFormat.Bold);
            p.AddLineBreak();
                                          
            r = t.AddRow();
           
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("15.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("INSURERS:", "Heading4");
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddText("Insurers comprising of Great Lakes Insurance SE");
            r.Cells[1].MergeRight = 2;

            p = r.Cells[4].AddParagraph();
            p.AddText("100%");
           
            r = t.AddRow();
            p = r.Cells[3].AddParagraph();
            p.AddFormattedText("Total:", TextFormat.Bold);
          
            p = r.Cells[4].AddParagraph();
            p.AddText("100%");

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("For and on behalf of,");
            p.AddLineBreak();
            p.AddText("HAYWARD AVIATION (a trading name of JLT Specialty Limited)");
            r.Cells[0].MergeRight = 3;

            r = t.AddRow();
            r = t.AddRow();
            r = t.AddRow();

            Image image = r.Cells[1].AddImage(@"C:\images\Signature.png");

            image.Width = "25mm";
            image.Height = "20mm";
            r.Cells[1].MergeRight = 2;


            r = t.AddRow();
            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            p.AddText("AUTHORISED SIGNATORY");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("Date 19 September 2018");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("Created by DO");
            r.Cells[0].MergeRight = 3;



        }




        #endregion

        #region Page4

        public void AddPage4Details(Section sec)
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

            c = t.AddColumn("33mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("33mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("2mm"); //3
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";


            Row r = t.AddRow();
            Paragraph p = r.Cells[4].AddParagraph();
            p.AddFormattedText("F186583 / 0448", TextFormat.Bold);
            r.Cells[4].Format.Alignment = ParagraphAlignment.Right;


            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("ENDORSEMENT (8)", "Heading4");
            r.Cells[0].MergeRight = 4;
            r.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            r = t.AddRow();
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("(Only applicable if shown in Item 12 of the Schedule)", TextFormat.Bold);
            r.Cells[0].MergeRight = 4;
            r.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("OVERSEAS JURISDICTION CLAUSE", "Heading4");
            r.Cells[0].MergeRight = 4;
            r.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("It is hereby agreed that:");
            r.Cells[0].MergeRight = 4;
           

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("1.");
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("this insurance shall be governed by the law of Ireland whose Courts shall have jurisdiction in any dispute arising hereunder; and ");
            p.AddLineBreak();
           
            r.Cells[1].MergeRight = 4;

            r = t.AddRow();
            r = t.AddRow();

            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddText("2.");
            p = r.Cells[1].AddParagraph();
            r.Cells[1].MergeRight = 4;
           // r.Cells[1].Format.Alignment = ParagraphAlignment.Justify;
            p.AddFormattedText("any summons, notice or process to be served upon the Insurers for the purpose of instituting any legal proceedings against them in connection with this insurance may be served upon: ");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddFormattedText("Great Lakes Insurance SE");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddFormattedText("At the following address:.");
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddFormattedText("Plantation Place,");
            p.AddLineBreak();
            p.AddFormattedText("30 Fenchurch Street,");
            p.AddLineBreak();
            p.AddFormattedText("London,");
            p.AddLineBreak();
            p.AddFormattedText("EC3M 3AJ.");

            r = t.AddRow();


        }


        #endregion

        #region Page5

        public void AddPage5Details(Section sec)
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

            c = t.AddColumn("11mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("3mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("88mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("33mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("33mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("2mm"); //3
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";


            Row r = t.AddRow();
            Paragraph p = r.Cells[0].AddParagraph();
            p.AddFormattedText("F186583 / 0448", TextFormat.Bold);
            r.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            r.Cells[0].MergeRight = 7;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("BREXIT CONTINUITY ENDORSEMENT", "Heading4");
            r.Cells[0].MergeRight = 6;
            r.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            r = t.AddRow();
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("Additional General Condition", TextFormat.Bold);
            r.Cells[0].MergeRight = 6;
            r.Cells[0].Format.Alignment = ParagraphAlignment.Center;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("Notice of Cancellation", TextFormat.Bold);
            r.Cells[0].MergeRight =6;
           
            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            r.Cells[0].MergeRight = 6;

            r.Cells[0].Format.Alignment = ParagraphAlignment.Justify;

            p.AddFormattedText("Notwithstanding anything contained in this Contract to the contrary, if a 'Default Event' occurs in relation to any(Re)Insurer, the(Re)Insured shall have the right to give revocable notice of cancellation of the participation of that(Re)Insurer in this Contract.In the event of such notice being given then cancellation shall be effective from the ‘’Final Brexit Date’’ as hereinafter defined unless revoked earlier by the (Re)Insured.To be effective, any notice of cancellation by the(Re)Insured(or by JLT Specialty Limited on its behalf) under this General Condition shall be deemed delivered and effective if delivered in writing to the addressee set out in the notice provisions of this Contract, or in the absence of such provision to the registered office of the (Re) Insurer whose participation is being cancelled. Within fourteen (14) days of the effective date of any cancellation:");
           

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[2].AddParagraph();
            p.AddText("(a)");
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("the relevant (Re)Insurer shall return any paid but unearned premium; and");
            p.AddLineBreak();
            r.Cells[4].MergeRight = 2;

            r = t.AddRow();
            p = r.Cells[2].AddParagraph();
            p.AddText("(b)");
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("the (Re)Insured shall pay any unpaid but earned premium,");
            p.AddLineBreak();
            r.Cells[4].MergeRight = 2;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            r.Cells[0].MergeRight = 6;

            r.Cells[0].Format.Alignment = ParagraphAlignment.Justify;

            p.AddFormattedText("and unearned premium shall be calculated as expressly provided in the relevant cancellation or termination provisions of this Contract or, if there are no such cancellation or termination provisions, on a pro-rata basis for the time on risk.Such(Re)Insurer shall, notwithstanding cancellation hereunder, remain liable for the payment of all claims arising under this Contract prior to the date of cancellation and shall use its best endeavours to pay such claims prior to the Final Brexit Date.");

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            r.Cells[0].MergeRight = 6;

            p.AddFormattedText("A Default Event",TextFormat.Bold);

            p.AddLineBreak();
            p.AddLineBreak();

            p.AddText("A ‘Default Event’ shall be deemed to be and to have occurred in respect of a (Re)Insurer participating in this Contract if, 45 calendar days prior to the later of: ");
                       
            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            p.AddText("(a)");

            p = r.Cells[2].AddParagraph();
            p.AddText("the 29th March 2019; or");

            r.Cells[2].MergeRight = 4;

            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            p.AddText("(b)");

            p = r.Cells[2].AddParagraph();
            r.Cells[2].Format.Alignment = ParagraphAlignment.Justify;
            p.AddText("where a Brexit transition agreement has been effected pursuant to which (Re)Insurers remain able to conduct business as its relates to this Contract, such subsequent date as may be specified for the full departure of the United Kingdom from the European Union under such transition agreement");

            r.Cells[2].MergeRight = 5;


            //r = t.AddRow();
            //r = t.AddRow();
            //p = r.Cells[0].AddParagraph();
            //p.AddFormattedText("Notice of Cancellation", TextFormat.Bold);
            //r.Cells[0].MergeRight = 6;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            r.Cells[0].MergeRight = 6;

            r.Cells[0].Format.Alignment = ParagraphAlignment.Justify;

            p.AddFormattedText("(such later date being the “Final Brexit Date”), that (Re)Insurer has not provided written confirmation to JLT Specialty Limited that either(i) its relevant licence to conduct business as it relates to this Contract will remain valid beyond the Final Brexit Date, or(ii) a transfer of its participation to a replacement(Re)Insurer pursuant to the Transfer Option below has been completed. ");

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("Transfer Option", TextFormat.Bold);
            r.Cells[0].MergeRight = 6;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            r.Cells[0].MergeRight = 6;
            r.Cells[0].Format.Alignment = ParagraphAlignment.Justify;

            p.AddFormattedText("It is an obligation of each individual subscribing (Re)Insurer (hereinafter referred to as the “Exiting (Re)Insurer”) to this Contract to ensure that the(re)insurance protection afforded to the(Re)Insured is unaffected by a Default Event. ");

            p.AddLineBreak();

            p.AddLineBreak();

            p.AddText("An Exiting (Re)Insurer shall, to avoid a Default Event, have the right, and obligation to use its best endeavours, to transfer its participation to a suitable replacement(Re)Insurer holding all necessary licences and permissions to grant(re)insurance coverage provided that the replacement(Re)Insurer: ");

        }


        #endregion

        #region Page6

        public void AddPage6Details(Section sec)
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

            c = t.AddColumn("11mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("3mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("88mm");    //1
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("33mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("33mm");  //2
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";

            c = t.AddColumn("2mm"); //3
            c.Format.Alignment = ParagraphAlignment.Left;
            c.Format.LeftIndent = "0mm";
            c.Format.RightIndent = "0mm";


            Row r = t.AddRow();
            Paragraph p = r.Cells[0].AddParagraph();
            p.AddFormattedText("F186583 / 0448", TextFormat.Bold);
            r.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            r.Cells[0].MergeRight = 7;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("1)");
            p = r.Cells[2].AddParagraph();
            r.Cells[2].MergeRight = 4;
            r.Cells[2].Format.Alignment = ParagraphAlignment.Justify;
            p.AddText("must accept the full participation of the Exiting (Re)Insurer on the same terms (including premium), conditions, limitations and exclusions; and");

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("2)");
            p = r.Cells[2].AddParagraph();
            p.AddText("must have a security grading not less than that of the Exiting (Re)Insurer as issued by Standard & Poor’s Insurance Rating(a division of the Mcgraw - Hill Companies) or successor thereof or Moody’s or AM Best Company Inc.or successor thereof unless agreed otherwise by the (Re)Insured; and");
            r.Cells[2].MergeRight = 4;
            r.Cells[2].Format.Alignment = ParagraphAlignment.Justify;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("3)");
            p = r.Cells[2].AddParagraph();
            p.AddText("such transfer is to be completed at least 45 calendar days prior to the Final Brexit Date; and");
            r.Cells[2].MergeRight = 4;
            r.Cells[2].Format.Alignment = ParagraphAlignment.Justify;

            r = t.AddRow();
            p = r.Cells[1].AddParagraph();
            p.AddFormattedText("4)");
            p = r.Cells[2].AddParagraph();
            p.AddText("accepts responsibility for the payment of all claims arising under this Contract other than those settled prior to the date of replacement of the Exiting(Re)Insurer.");
            r.Cells[2].MergeRight = 4;
            r.Cells[2].Format.Alignment = ParagraphAlignment.Justify;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("The (Re)Insured shall cooperate reasonably to enable the Exiting (Re)Insurer to effect a transfer on the above terms. ");
            r.Cells[0].MergeRight = 6;


            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            p.AddFormattedText("(Re)Insurers’ Duty", TextFormat.Bold);
            r.Cells[0].MergeRight = 6;

            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[0].AddParagraph();
            r.Cells[0].MergeRight = 6;

            r.Cells[0].Format.Alignment = ParagraphAlignment.Justify;

            p.AddFormattedText("If any (Re)Insurer is affected by a Default Event it shall:");


            r = t.AddRow();
            r = t.AddRow();
            p = r.Cells[2].AddParagraph();
            p.AddText("(a)");
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("at its own expense ensure compliance with this General Condition. Such expense shall take into account the general market conditions at the time of any such transfer or cancellation along with any additional fees for additional work incurred by the(Re)Insured and JLT Specialty Limited; ");

            p.AddLineBreak();
            r.Cells[4].MergeRight = 2;

            r = t.AddRow();
            p = r.Cells[2].AddParagraph();
            p.AddText("(b)");
            p = r.Cells[4].AddParagraph();
            p.AddFormattedText("not to use the doctrine of Frustration of Contract as a mechanism to avoid its obligation to provide a suitable, lawful alternative(re)insurance protection to the(Re)Insured.");
            p.AddLineBreak();
            r.Cells[4].MergeRight = 2;

            r = t.AddRow();
            r = t.AddRow();

            p = r.Cells[0].AddParagraph();
            r.Cells[0].MergeRight = 6;

            p.AddFormattedText("(Re)Insurers liability to the (Re)Insured under this General Condition shall remain several and not joint.");

            r = t.AddRow();
           
        }



        #endregion


        public void DefineStyle()
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Arial";
            style.Font.Size = 10;
            style.Font.Color = new Color(0, 0, 0);

            style = document.Styles["Heading1"];
            style.Font.Name = "Arial";
            style.Font.Size = 13;
            style.Font.Bold = true;
            style.Font.Color = new Color(0, 0, 0);


            style = document.Styles["Heading2"];
            style.Font.Name = "Arial";
            style.Font.Size = 11;
            style.Font.Bold = false;
            style.Font.Color = new Color(0, 0, 0);

            style = document.Styles["Heading3"]; 
            style.Font.Name = "Arial";
            style.Font.Size = 13;
            style.Font.Bold = true;
            style.Font.Color = new Color(255, 255, 255);

            style = document.Styles["Heading4"];
            style.Font.Name = "Arial";
            style.Font.Size = 10;
            style.Font.Underline += 1;
            style.Font.Bold = true;
            style.Font.Color = new Color(0, 0, 0);


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


            style = document.Styles["Heading9"]; 
            style.Font.Name = "Arial";
            style.Font.Size = 8.5;
            style.Font.Bold = false;
            style.Font.Color = new Color(91, 91, 92);


        }

       

    }
}
