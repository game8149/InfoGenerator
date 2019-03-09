﻿using Spire.Pdf;
using Spire.Xls;
using Spire.Xls.Converter;
using System;
using System.Diagnostics;
using System.IO;

namespace Engines
{
    public class GeneratorReport
    {
        public string FolderPath { get; set; }
        public string FileSource { get; set; }
        public string FileTemplate { get; set; }


        public GeneratorReport()
        {
            FolderPath = "";
            FileSource = "Source.xlsx";
            FileTemplate = "Template.xlsx";
        }

        public void GeneratePDF(string codeStore, int month, int year)
        {
            SpreadsheetGear.IRange range = null;
            SpreadsheetGear.IWorksheet wsSource = null;
            SpreadsheetGear.IWorksheet wsTarget = null;
            SpreadsheetGear.Charts.IChart curentChart = null;
            Debug.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);
            SpreadsheetGear.IWorkbook wbSource = SpreadsheetGear.Factory.GetWorkbook($@"{System.AppDomain.CurrentDomain.BaseDirectory}\Resources\{FileSource}");
            SpreadsheetGear.IWorkbook wbTarget = SpreadsheetGear.Factory.GetWorkbook($@"{System.AppDomain.CurrentDomain.BaseDirectory}\Resources\{FileTemplate}");
            wbSource.WorkbookSet.Calculation = SpreadsheetGear.Calculation.Manual;
            wsSource = wbSource.Worksheets[0];

            SpreadsheetGear.Drawing.Color basicColor = SpreadsheetGear.Drawing.Color.FromArgb(89, 89, 89);
            SpreadsheetGear.Drawing.Color blueColor = SpreadsheetGear.Drawing.Color.FromArgb(0, 112, 192);
            SpreadsheetGear.Drawing.Color orangeColor = SpreadsheetGear.Drawing.Color.FromArgb(255, 153, 51);

            //Update Data from Excel
            range = wsSource.Cells["C3"];
            range.Value = codeStore;
            wbSource.WorkbookSet.Calculate();
            wbSource.Save();
            wsTarget = wbTarget.Worksheets[0];

            // C12, C13, C14
            int beforeMonth = month;
            int currentYear = year;
            int valueInt = 0;
            decimal valueDecimal = 0;
            for (int i = 14; i > 1; i--, beforeMonth--) // begin at Pos 14
            {
                if (beforeMonth == 0)
                {
                    currentYear -= 1;
                    beforeMonth = 12;
                }
                range = wsSource.Cells[12, i]; // Row 12
                range.Value = $"{beforeMonth}/{currentYear}";

            }

            var txtFrame = wsTarget.Shapes["INF_MONTH"].TextFrame;
            txtFrame.Characters.Text = FormatMonthYear(month, year);

            wsTarget.Shapes["NAME_STORE"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["NAME_STORE"].TextFrame.AutoSize = false;
            wsTarget.Shapes["ADDRESS_STORE"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["ADDRESS_STORE"].TextFrame.AutoSize = false;
            wsTarget.Shapes["CODE_STORE"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["CODE_STORE"].TextFrame.AutoSize = false;


            wsTarget.Shapes["NAME_STORE"].TextFrame.Characters.Text = wsSource.Cells["D3"].Value.ToString();
            wsTarget.Shapes["ADDRESS_STORE"].TextFrame.Characters.Text = wsSource.Cells["E3"].Value.ToString() + ", " + wsSource.Cells["F3"].Value.ToString();
            wsTarget.Shapes["CODE_STORE"].TextFrame.Characters.Text = $"Comercio: {codeStore}";

            wsTarget.Shapes["VEN_TITLE"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["NVENT_TITLE"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["CCOM_TITLE"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["CVISIT_TITLE"].TextFrame.Characters.Font.Color = basicColor;

            wsTarget.Shapes["MN_MAIN"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["NP_MAIN"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["MAIN_WARNING1"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["MAIN_WARNING2"].TextFrame.Characters.Font.Color = basicColor;

            wsTarget.Shapes["MN_MAIN"].TextFrame.AutoSize = false;
            wsTarget.Shapes["MN_MAIN"].TextFrame.HorizontalAlignment = SpreadsheetGear.HAlign.Left;
            wsTarget.Shapes["MN_MAIN"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["NP_MAIN"].TextFrame.AutoSize = false;
            wsTarget.Shapes["NP_MAIN"].TextFrame.HorizontalAlignment = SpreadsheetGear.HAlign.Left;
            wsTarget.Shapes["MN_MAIN"].TextFrame.Characters.Font.Color = basicColor;

            // Main
            int index = 2;
            SpreadsheetGear.Shapes.ITextFrame txtFrameMN = null;
            SpreadsheetGear.Shapes.ITextFrame txtFrameNP = null;
            for (var i = 3; i < 7; i++, index++)
            {
                txtFrameMN = wsTarget.Shapes[$"MN_{index}"].TextFrame;
                txtFrameNP = wsTarget.Shapes[$"NP_{index}"].TextFrame;

                if (index == 2 || index == 4 || index == 6)
                {
                    valueDecimal = 0;
                    Decimal.TryParse(wsSource.Cells[5, i].Value.ToString(), out valueDecimal);
                    txtFrameMN.Characters.Text = "S/ " + (valueDecimal).ToString("F");

                    Decimal.TryParse(wsSource.Cells[8, i].Value.ToString(), out valueDecimal);
                    txtFrameNP.Characters.Text = "S/ " + (valueDecimal).ToString("F");
                }
                else
                {
                    valueInt = 0;
                    int.TryParse(wsSource.Cells[5, i].Value.ToString(), out valueInt);
                    txtFrameMN.Characters.Text = (valueInt).ToString();

                    int.TryParse(wsSource.Cells[8, i].Value.ToString(), out valueInt);
                    txtFrameNP.Characters.Text = (valueInt).ToString();
                }

                txtFrameMN.Characters.Font.Color = basicColor;
                txtFrameNP.Characters.Font.Color = basicColor;
            }

            wsTarget = wbTarget.Worksheets[2];
            wbSource.WorkbookSet.Calculate();
            wbSource.Save();

            wsTarget = wbTarget.Worksheets[0];
            // Graphic 2
            wsTarget.Shapes["G2_ADVICE"].TextFrame.AutoSize = false;
            wsTarget.Shapes["G2_ADVICE"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["GRAPHIC1_LBL1"].TextFrame.AutoSize = false;
            wsTarget.Shapes["GRAPHIC1_LBL1"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["GRAPHIC1_LBL2"].TextFrame.AutoSize = false;
            wsTarget.Shapes["GRAPHIC1_LBL2"].TextFrame.Characters.Font.Color = basicColor;

            wsTarget = wbTarget.Worksheets[2];
            decimal lastYearmonth = 0;
            decimal actualMonth = 0;
            decimal sum3PreviousMonths = 0;
            for (var i = 2; i < 15; i++)
            {
                wsTarget.Cells[4, i].Value = wsSource.Cells[12, i].Value; // headerDates

                valueDecimal = 0;
                range = wsSource.Cells[13, i];
                decimal.TryParse(range.Value.ToString(), out valueDecimal);

                wsTarget.Cells[5, i].Value = valueDecimal;
                if (i == 2)
                    lastYearmonth = valueDecimal;
                else if (i == 14)
                    actualMonth = valueDecimal;
                else if (i >= 11 && i < 14)
                    sum3PreviousMonths += valueDecimal; // sum of 3 previous months 

                valueDecimal = 0;
                range = wsSource.Cells[14, i];
                decimal.TryParse(range.Value.ToString(), out valueDecimal);
                wsTarget.Cells[6, i].Value = valueDecimal;
            }
            var advices2 = EvalueAdviceG2(sum3PreviousMonths, actualMonth, lastYearmonth, wsTarget.Shapes["G2_ADVICE"].TextFrame.Characters.Text);
            wsTarget.Shapes["G2_ADVICE"].TextFrame.Characters.Text = advices2.Item1;

            wsTarget = wbTarget.Worksheets[0];
            // Graphic 3
            wsTarget.Shapes["G3_ADVICE"].TextFrame.AutoSize = false;
            wsTarget.Shapes["G3_ADVICE"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["GRAPHIC2_LBL1"].TextFrame.AutoSize = false;
            wsTarget.Shapes["GRAPHIC2_LBL1"].TextFrame.Characters.Font.Color = basicColor;
            wsTarget.Shapes["GRAPHIC2_LBL2"].TextFrame.AutoSize = false;
            wsTarget.Shapes["GRAPHIC2_LBL2"].TextFrame.Characters.Font.Color = basicColor;

            wsTarget = wbTarget.Worksheets[2];
            for (var i = 2; i < 15; i++)
            { 
                wsTarget.Cells[9, i].Value = wsSource.Cells[12, i].Value; // headerDates
                 
                valueDecimal = 0;
                range = wsSource.Cells[15, i];
                decimal.TryParse(range.Value.ToString(), out valueDecimal);

                wsTarget.Cells[10, i].Value = valueDecimal;
                if (i == 2)
                    lastYearmonth = valueDecimal;
                else if (i == 14)
                    actualMonth = valueDecimal;
                else if (i >= 11 && i < 14)
                    sum3PreviousMonths += valueDecimal; // sum of 3 previous months 

                valueDecimal = 0;
                range = wsSource.Cells[16, i];
                decimal.TryParse(range.Value.ToString(), out valueDecimal);
                wsTarget.Cells[11, i].Value = valueDecimal; 
            }

            var advices3 = EvalueAdviceG2(sum3PreviousMonths, actualMonth, lastYearmonth, wsTarget.Shapes["G2_ADVICE"].TextFrame.Characters.Text);
            wsTarget.Shapes["G3_ADVICE"].TextFrame.Characters.Text = advices3.Item1;
              
            wsTarget = wbTarget.Worksheets[0];
            // Graphic 4
            wsTarget.Shapes["G4_ADVICE"].TextFrame.AutoSize = false;
            wsTarget.Shapes["G4_ADVICE"].TextFrame.Characters.Font.Color = basicColor;

            index = 1;
            for (var i = 20; i < 25; i++, index++)
            {
                range = wsSource.Cells[i, 2];
                int.TryParse(range.Value.ToString(), out valueInt);
                wsTarget.Shapes[$"G4_{index}_COUNT"].TextFrame.AutoSize = false;
                wsTarget.Shapes[$"G4_{index}_COUNT"].TextFrame.Characters.Font.Color = basicColor;
                wsTarget.Shapes[$"G4_{index}_COUNT"].TextFrame.Characters.Text = valueInt.ToString();

                range = wsSource.Cells[i, 3];
                decimal.TryParse(range.Value.ToString(), out valueDecimal);
                wsTarget.Shapes[$"G4_{index}_PERC"].TextFrame.AutoSize = false;
                wsTarget.Shapes[$"G4_{index}_PERC"].TextFrame.Characters.Font.Color = blueColor;
                wsTarget.Shapes[$"G4_{index}_PERC"].TextFrame.Characters.Text = $"({(int)(valueDecimal * 100)}%)";

                wsTarget.Shapes[$"G4_CVISIT_{index}"].TextFrame.AutoSize = false;
                wsTarget.Shapes[$"G4_CVISIT_{index}"].TextFrame.Characters.Font.Color = blueColor;

                wsTarget.Shapes[$"G4_TIME_{index}"].TextFrame.AutoSize = false;
                wsTarget.Shapes[$"G4_TIME_{index}"].TextFrame.Characters.Font.Color = orangeColor;
            }

            wsTarget = wbTarget.Worksheets[0];
            // Graphic 5 
            wsTarget.Shapes["G5_ADVICE"].TextFrame.AutoSize = false;
            wsTarget.Shapes["G5_ADVICE"].TextFrame.Characters.Font.Color = basicColor;

            wsTarget = wbTarget.Worksheets[2];
            for (var i = 2; i < 9; i++)
            {
                valueInt = 0;
                int.TryParse(wsSource.Cells[15, i].Value.ToString(), out valueInt);
                wsTarget.Cells[15, i].Value = valueInt;
            }

            string nameTarget = $"{codeStore}_{DateTime.Now.Ticks}.xlsx";
            wbTarget.SaveAs(nameTarget, SpreadsheetGear.FileFormat.OpenXMLWorkbook);

            this.GeneratePDF($@"{System.AppDomain.CurrentDomain.BaseDirectory}\{nameTarget}");
        }

        private string FormatMonthYear(int month, int year)
        {
            switch (month)
            {
                case 1:
                    return $"Ene {year}";
                case 2:
                    return $"Feb {year}";
                case 3:
                    return $"Mar {year}";
                case 4:
                    return $"Abr {year}";
                case 5:
                    return $"May {year}";
                case 6:
                    return $"Jun {year}";
                case 7:
                    return $"Jul {year}";
                case 8:
                    return $"Ago {year}";
                case 9:
                    return $"Set {year}";
                case 10:
                    return $"Oct {year}";
                case 11:
                    return $"Nov {year}";
                case 12:
                    return $"Dic {year}";
            }
            return string.Empty;

        }

        private void GeneratePDF(string rutaExcel)
        {
            string rutapdf = Path.ChangeExtension(rutaExcel, ".pdf");
            //spire.xls.workbook workbook = new spire.xls.workbook();
            //workbook.loadfromfile(rutaexcel);
            //workbook.convertersetting.sheetfittopage = true;
            //workbook.savetofile(rutapdf, spire.xls.fileformat.pdf);

            //var workbook = new Workbook();
            //workbook.LoadFromFile(rutaExcel);
            ////' Set PDF template 
            //var pdfDocument = new PdfDocument();
            //pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
            //pdfDocument.PageSettings.Width = 970;
            //pdfDocument.PageSettings.Height = 850; 
            ////'Convert Excel to PDF using the template above 
            //var pdfConverter = new PdfConverter(workbook);
            //var settings = new PdfConverterSettings();

            //workbook.SaveToFile("HOLASD.pdf",Spire.Xls.FileFormat.PDF);



            //System.Diagnostics.Process.Start("sample.pdf");



            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            //ExcelFile excel = ExcelFile.Load(rutaExcel);
            //excel.Save(rutapdf);
        }

        private Tuple<string, string> EvalueAdviceG2(decimal sum3PreviousMonths, decimal currentMonth, decimal lastYearMonth, string baseFormat)
        {

            return new Tuple<string, string>(baseFormat, string.Empty);
        }

        private Tuple<string, string> EvalueAdviceG3(decimal sum3PreviousMonths, decimal currentMonth, decimal lastYearMonth, string baseFormat)
        {

            return new Tuple<string, string>(baseFormat, string.Empty);
        }

    }
}