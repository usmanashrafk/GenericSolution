using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using System.Data;
using System.IO;

namespace GenericSolution
{
    public static class Tools
    {
     
        public static void WriteFormattedParagraphFromContent(ref Paragraph p, string content)
        {

            //replace the vars
            string moddedcontent = content;

            
                moddedcontent = content.Replace("%refference%", "b.bookingReference");

            string[] content_array = moddedcontent.Split('|');

            foreach (string s in content_array)
            {
                if (s != string.Empty)
                {
                    if (s.First().ToString() == "l")
                    {
                        p.AddLineBreak();

                        string s1 = s.Remove(0, 1);

                        if (s1.First().ToString() == "b")
                        {
                            p.AddFormattedText(s1.Remove(0, 1), TextFormat.Bold);
                        }
                        else if (s1.First().ToString() == "t")
                        {
                            p.AddFormattedText(s1.Remove(0, 1), StyleNames.Heading9);
                        }
                        else if (s1.First().ToString() == "r")
                        {
                            p.AddFormattedText(s1.Remove(0, 1), StyleNames.Heading6);
                        }
                        else if (s1.First().ToString() == "c")
                        {
                            p.AddFormattedText(s1.Remove(0, 1), TextFormat.Bold);
                        }

                        else if (s1.First().ToString() == "u")
                        {
                            p.AddFormattedText(s1.Remove(0, 1), StyleNames.Heading7);
                        }
                        else if (s1.First().ToString() == "o" && s1[1].ToString() == " ")
                        {
                            p.AddFormattedText(s1.Remove(0, 1), StyleNames.Heading4);
                        }
                        else if (s1.First().ToString() == "z")
                        {
                            p.AddFormattedText(s1.Remove(0, 1), StyleNames.Heading8);
                        }
                        else if (s1.First().ToString() == "")
                        {
                            // p.AddFormattedText(s1.Remove(0, 1), StyleNames.Heading4);
                        }

                        else if (s1.First().ToString() == "a")
                        {
                            p.AddFormattedText("  " + s1.Remove(0, 1), TextFormat.Bold);
                        }
                        else if (s1.First().ToString() == "h")
                        {
                            string hlinktext = s1.Remove(0, 1).Split('=').Last().Trim();

                            if (hlinktext.Length > 4)
                            {
                                if (hlinktext.Substring(0, 4).ToLower() != "http")
                                {
                                    hlinktext = "http://" + hlinktext;
                                }
                            }

                            Hyperlink hlink = p.AddHyperlink(hlinktext, HyperlinkType.Url);
                            hlink.Font.Color = new Color(24, 106, 207);
                            hlink.Font.Underline += 1;

                            hlink.AddFormattedText(s1.Remove(0, 1).Split('=').First());
                        }
                        else if (s1.First().ToString() == "e")
                        {
                            string hlinktext = "mailto:" + s1.Remove(0, 1);

                            Hyperlink hlink = p.AddHyperlink(hlinktext, HyperlinkType.Url);
                            hlink.Font.Color = new Color(24, 106, 207);
                            hlink.Font.Underline += 1;
                            hlink.AddFormattedText(s1.Remove(0, 1).ToUpper(), TextFormat.Bold);
                        }
                        else if (s1.First().ToString() == "s")
                        {
                            p.AddSpace(1);
                        }
                        else
                        {
                            p.AddText(s1);
                        }
                    }

                    else
                    {
                        if (s.First().ToString() == "b")
                        {
                            p.AddFormattedText(s.Remove(0, 1), TextFormat.Bold);
                        }
                        else if (s.First().ToString() == "t")
                        {
                            p.AddFormattedText(s.Remove(0, 1), StyleNames.Heading9);
                        }
                        else if (s.First().ToString() == "c")
                        {
                            p.AddFormattedText(s.Remove(0, 1), TextFormat.Bold);
                        }
                        else if (s.First().ToString() == "r")
                        {
                            p.AddFormattedText(s.Remove(0, 1), StyleNames.Heading6);
                        }
                        else if (s.First().ToString() == "u")
                        {
                            p.AddFormattedText(s.Remove(0, 1), StyleNames.Heading7);
                        }
                        else if (s.First().ToString() == "o" && s[1].ToString() == " ")
                        {
                            p.AddFormattedText(s.Remove(0, 1), StyleNames.Heading4);
                        }

                        else if (s.First().ToString() == "a")
                        {
                            p.AddFormattedText("  " + s.Remove(0, 1), TextFormat.Bold);
                        }
                        else if (s.First().ToString() == "h")
                        {
                            string hlinktext = s.Remove(0, 1).Split('=').Last().Trim();
                            if (hlinktext.Length > 4)
                            {
                                if (hlinktext.Substring(0, 4).ToLower() != "http")
                                {
                                    hlinktext = "http://" + hlinktext;
                                }
                            }

                            Hyperlink hlink = p.AddHyperlink(hlinktext, HyperlinkType.Url);
                            hlink.Font.Color = new Color(24, 106, 207);
                            hlink.Font.Underline += 1;

                            hlink.AddFormattedText(s.Remove(0, 1).Split('=').First());
                        }
                        else if (s.First().ToString() == "e")
                        {
                            string hlinktext = "mailto:" + s.Remove(0, 1);

                            Hyperlink hlink = p.AddHyperlink(hlinktext, HyperlinkType.Url);
                            hlink.Font.Color = new Color(24, 106, 207);
                            hlink.Font.Underline += 1;

                            hlink.AddFormattedText(s.Remove(0, 1).ToUpper(), TextFormat.Bold);
                        }
                        else if (s.First().ToString() == "s")
                        {
                            p.AddSpace(1);
                        }
                        else
                        {
                            p.AddText(s);
                        }
                    }
                }
            }
        }

        public static void AddMainFooter(ref Section sec)
        {
            sec.PageSetup.DifferentFirstPageHeaderFooter = true;
            sec.PageSetup.StartingNumber = 1;

            HeaderFooter MainFooter = sec.Footers.FirstPage;
            Table FooterTable = MainFooter.AddTable();
            FooterTable.TopPadding = "1mm";
            Column c = FooterTable.AddColumn("160mm");
            c = FooterTable.AddColumn("10mm");
            c = FooterTable.AddColumn("20mm");

            Row r = null;
            Image img = null;

            r = FooterTable.AddRow();
            r.Cells[0].MergeRight = 2;
            img = r.Cells[0].AddImage("C:\\images\\transpix.gif");
            img.Width = "190mm";
            img.Height = "1mm";

            r = FooterTable.AddRow();

          
                r.TopPadding = "0.2mm";
                img = r.Cells[0].AddImage("C:\\images\\HalFooter.jpg");
                img.Width = "190mm"; //"45mm";
            img.Height = "30mm";
                img.LockAspectRatio = true;


                HeaderFooter MainFooterPmy = sec.Footers.Primary;
                MainFooterPmy.AddImage("C:\\images\\transpix.gif");
           
        }

        public static void AddInvoiceFooter(ref Section sec)
        {
            sec.PageSetup.DifferentFirstPageHeaderFooter = true;
            sec.PageSetup.StartingNumber = 1;

            HeaderFooter MainFooter = sec.Footers.FirstPage;
            Table FooterTable = MainFooter.AddTable();
            FooterTable.TopPadding = "1mm";
            Column c = FooterTable.AddColumn("160mm");
            c = FooterTable.AddColumn("10mm");
            c = FooterTable.AddColumn("20mm");

            Row r = null;
            Image img = null;

            r = FooterTable.AddRow();
            r.Cells[0].MergeRight = 2;
            img = r.Cells[0].AddImage("C:\\images\\transpix.gif");
            img.Width = "190mm";
            img.Height = "1mm";

            r = FooterTable.AddRow();


            r.TopPadding = "0.2mm";
            img = r.Cells[0].AddImage("C:\\images\\HalFooter.jpg");
            img.Width = "190mm"; //"45mm";
            img.Height = "25mm";
            img.LockAspectRatio = true;


            HeaderFooter MainFooterPmy = sec.Footers.Primary;
            MainFooterPmy.AddImage("C:\\images\\transpix.gif");

        }

        public static void AddNoFooter(ref Section sec)
        {
            sec.PageSetup.DifferentFirstPageHeaderFooter = true;
            sec.PageSetup.StartingNumber = 1;

            HeaderFooter MainFooter = sec.Footers.FirstPage;
            Table FooterTable = MainFooter.AddTable();
            FooterTable.TopPadding = "1mm";
            Column c = FooterTable.AddColumn("160mm");
            c = FooterTable.AddColumn("10mm");
            c = FooterTable.AddColumn("20mm");

            Row r = null;
            Image img = null;

            r = FooterTable.AddRow();
            r.Cells[0].MergeRight = 2;
            img = r.Cells[0].AddImage("C:\\images\\transpix.gif");
            img.Width = "190mm";
            img.Height = "1mm";

            r = FooterTable.AddRow();


            r.TopPadding = "0.2mm";
            img = r.Cells[0].AddImage("C:\\images\\footerplain.jpg");
            img.Width = "190mm"; //"45mm";
            img.Height = "25mm";
            img.LockAspectRatio = true;


            HeaderFooter MainFooterPmy = sec.Footers.Primary;
            MainFooterPmy.AddImage("C:\\images\\transpix.gif");

        }
        public static void AddPrimaryFooter(ref Section sec, bool includedVirginBanner)
        {
            sec.PageSetup.DifferentFirstPageHeaderFooter = true;
            sec.PageSetup.StartingNumber = 1;

            HeaderFooter MainFooter = sec.Footers.Primary;
            Table FooterTable = MainFooter.AddTable();
            FooterTable.TopPadding = "1mm";
            Column c = FooterTable.AddColumn("90mm");
            c = FooterTable.AddColumn("90mm");
            c = FooterTable.AddColumn("10mm");

            Row r = null;
            Image img = null;
            Hyperlink h = null;
            Paragraph p = null;

            r = FooterTable.AddRow();
            r.TopPadding = "0.2mm";



            img = r.Cells[0].AddImage("C:\\images\\footer.jfif");
            img.Width = "190mm"; 
            img.LockAspectRatio = true;
           
            HeaderFooter MainFooterPmy = sec.Footers.Primary;
            MainFooterPmy.AddImage("C:\\images\\footer.jfif");
     }
       

        public static string ConvertString(string text)
        {
            if (text != string.Empty)
            {
                string proceedText = string.Empty;

                foreach (string word in text.Split(' '))
                {
                    foreach (string s in word.Split('/'))
                        if (s != string.Empty)
                            // proceedText += s.ToUpper().Take(1).First().ToString() + s.ToLower().Remove(0, 1).ToLower() + " ";
                            proceedText += s.ToUpper().ToString() + " ";
                }

                return proceedText.Trim();
            }
            return text;
        }
    
      
        public static string GetMainPageHeader()
        {
                return "C:\\images\\HeaderWithLongTextPNG.png";
        }

        public static string GetHeaderWithText()
        {
            return "C:\\images\\HeaderWithTextPNG.png";
        }


        public static string GetHeaderWithoutText()
        {
            return "C:\\images\\HalLogo.jpg";
        }

        public static string GetSecondPageHeader()
        {
            return "C:\\images\\HalHeader2.jpg";
        }

        public static Color GetTableColorByRetailer(string retailer = "")
        {
            if (retailer.Trim().ToUpper() == "SF")
            {
                return Color.FromCmyk(76.65, 10.15, 0, 22.75);
            }
            else
            {
                //Color myRgb = new Color(236, 178, 72); //for golden color. 

                Color myRgb = new Color(12, 35, 64);
                return myRgb;
            }
        }

        public static string ConvertPrice(decimal price)
        {
            string formattedcash = string.Empty;
            if (price < 1000)
                formattedcash = string.Format("{0:0.00}", price);
            else if (price < 100000)
                formattedcash = string.Format("{0:0,0.00}", price);
            return formattedcash;
        }

        public static string ConvertDoubleToTime(double value)
        {
            string[] doubleValues = value.ToString().Split('.');

            if (doubleValues.Count() == 2)
                return doubleValues.First().PadLeft(2, '0') + ":" + doubleValues.Last().PadRight(2, '0');
            else
                return doubleValues.First().PadLeft(2, '0') + ":00";

        }

        public static string CalculateCheckInTime(double value)
        {
            double checkInTime = 0.00;

            if (value > 3.0)
                checkInTime = value - 3;
            else
            {
                value = value + 24;
                checkInTime = value - 3;
            }

            string checkTime = ConvertDoubleToTime(checkInTime);


            return checkTime;
        }

      
    }
}
