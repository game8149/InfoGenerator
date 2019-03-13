using iText.Kernel.Pdf;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Engines
{
    public class GeneratorReport
    {
        Font font = new Font("Trade Gothic LT Std", 1);
        Font fontBold = new Font("Trade Gothic LT Std Bold", 1);
        public enum MethodReport
        {
            Random = 0,
            Code = 1
        }

        public string FolderPath { get; set; }
        public string FileSource { get; set; }
        public string FileTemplate { get; set; }

        public string CodeStore { get; set; }
        public int RandomNumber { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public MethodReport Method { get; set; }

        public bool WorkFinished { get; set; }
        public int ProgressFinished { get; set; }
        public string NameActual { get; set; }
        public int TotalWork { get; set; }

        public GeneratorReport()
        {
            FolderPath = "";
            FileSource = "Source.xlsx";
            FileTemplate = "TemplateNew.xlsx";
        }

        public void Generate()
        {
            string ruc = string.Empty;
            string name = string.Empty;
            string email = string.Empty;
            int beforeMonth = Month;
            int currentYear = Year;
            int valueInt = 0;
            decimal valueDecimal = 0;

            int counterWorked = 0;

            SpreadsheetGear.IRange range = null;
            SpreadsheetGear.IWorksheet wsSource = null;
            SpreadsheetGear.IWorksheet wsTarget = null;

            //Retrieving Template and Source
            SpreadsheetGear.IWorkbook wbSource = SpreadsheetGear.Factory.GetWorkbook($@"{FileSource}");

            List<string> codesSelected = new List<string>();
            wsSource = wbSource.Worksheets[1];

            if (Method == MethodReport.Random)
            {
                for (int i= 1;i<= RandomNumber;i++)
                    codesSelected.Add(wsSource.Cells[i, 0].Value.ToString());

                //while (codesSelected.Count < RandomNumber)
                //{
                //    int randonRowIndex = new Random().Next(1, 617);

                //    if (!codesSelected.Contains(wsSource.Cells[randonRowIndex, 0].Value.ToString()))
                //}
            }
            else codesSelected.Add(CodeStore);

            wsSource = wbSource.Worksheets[0];
            wsSource.Cells["G3"].Formula = wsSource.Cells["D3"].Formula.Replace("4", "3");
            wsSource.Cells["H3"].Formula = wsSource.Cells["D3"].Formula.Replace("4", "36");

            SpreadsheetGear.Drawing.Color basicColor = SpreadsheetGear.Drawing.Color.FromArgb(89, 89, 89);
            SpreadsheetGear.Drawing.Color blueColor = SpreadsheetGear.Drawing.Color.FromArgb(0, 112, 192);
            SpreadsheetGear.Drawing.Color orangeColor = SpreadsheetGear.Drawing.Color.FromArgb(255, 153, 51);

            this.TotalWork = codesSelected.Count;
            this.ProgressFinished = counterWorked;

            foreach (string code in codesSelected)
            {
                SpreadsheetGear.IWorkbook wbTarget = SpreadsheetGear.Factory.GetWorkbook($@"{System.AppDomain.CurrentDomain.BaseDirectory}\Resources\{FileTemplate}");
                wbSource.WorkbookSet.Calculation = SpreadsheetGear.Calculation.Manual;
                wsSource = wbSource.Worksheets[0];
                 
                //Update Data from Excel 
                range = wsSource.Cells["C3"];
                range.Value = code;
                wbSource.WorkbookSet.Calculate();
                wbSource.Save();
                ruc = wsSource.Cells["G3"].Value?.ToString();
                name = wsSource.Cells["D3"].Value?.ToString().Replace(".", string.Empty);
                email = wsSource.Cells["H3"].Value?.ToString();
                NameActual = name;

                wsTarget = wbTarget.Worksheets[0];
                   
                wsTarget.Shapes["MAIN_WARNING1"].TextFrame.Characters.Font.Color = basicColor;
                wsTarget.Shapes["MAIN_WARNING2"].TextFrame.Characters.Font.Color = basicColor;
 
                // C12, C13, C14
                beforeMonth = Month;
                currentYear = Year;
                valueInt = 0;
                valueDecimal = 0;

                for (int i = 14; i > 1; i--, beforeMonth--) // begin at Pos 14
                {
                    if (beforeMonth == 0)
                    {
                        currentYear -= 1;
                        beforeMonth = 12;
                    }
                    range = wsSource.Cells[11, i]; // Row 11
                    range.Value = $"{beforeMonth}/{currentYear}";
                }

                #region Setting Info 
                wsTarget.Cells["AT7"].Value = FormatMonthYear(Month, Year);

                wsTarget.Cells["J9"].Value = wsSource.Cells["D3"].Value.ToString();
                wsTarget.Cells["J10"].Value = wsSource.Cells["E3"].Value.ToString() + ", " + wsSource.Cells["F3"].Value.ToString();
                wsTarget.Cells["J11"].Value = $"Comercio: {code}";

                #endregion

                #region MainData
                // Main
                int index = 2;

                valueDecimal = 0;
                Decimal.TryParse(wsSource.Cells[5, 3].Value.ToString(), out valueDecimal);
                wsTarget.Cells["P24"].Value = (valueDecimal).ToString("N0");

                Decimal.TryParse(wsSource.Cells[8, 3].Value.ToString(), out valueDecimal);
                wsTarget.Cells["P28"].Value = (valueDecimal).ToString("N0");

                valueDecimal = 0;
                Decimal.TryParse(wsSource.Cells[5, 4].Value.ToString(), out valueDecimal);
                wsTarget.Cells["Y24"].Value = (valueDecimal).ToString("N0");

                Decimal.TryParse(wsSource.Cells[8, 4].Value.ToString(), out valueDecimal);
                wsTarget.Cells["Y28"].Value = (valueDecimal).ToString("N0");

                valueDecimal = 0;
                Decimal.TryParse(wsSource.Cells[5, 5].Value.ToString(), out valueDecimal);
                wsTarget.Cells["AH24"].Value = (valueDecimal).ToString("N0");

                Decimal.TryParse(wsSource.Cells[8, 5].Value.ToString(), out valueDecimal);
                wsTarget.Cells["AH28"].Value = (valueDecimal).ToString("N0");

                valueDecimal = 0;
                Decimal.TryParse(wsSource.Cells[5, 6].Value.ToString(), out valueDecimal);
                wsTarget.Cells["AQ24"].Value = (valueDecimal).ToString("N0");

                Decimal.TryParse(wsSource.Cells[8, 6].Value.ToString(), out valueDecimal);
                wsTarget.Cells["AQ28"].Value = (valueDecimal).ToString("N0");

                wsTarget = wbTarget.Worksheets[2];
                wbSource.WorkbookSet.Calculate();
                wbSource.Save();

                #endregion

                #region Graphic 2  
                wsTarget = wbTarget.Worksheets[0];

                wsTarget = wbTarget.Worksheets[2];
                decimal lastYearmonth = 0;
                decimal actualMonth = 0;
                decimal sum3PreviousMonths = 0;
                DateTime? dateValue = null;
                for (var i = 2; i < 15; i++)
                {
                    dateValue = ParseDateXlsToDateTime(int.Parse(wsSource.Cells[11, i].Value.ToString()));
                    wsTarget.Cells[4, i].Value = FormatMonthYear(dateValue.Value.Month, dateValue.Value.Year, true); // headerDates

                    valueDecimal = 0;
                    range = wsSource.Cells[12, i];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);

                    wsTarget.Cells[5, i].Value = valueDecimal;
                    if (i == 2)
                        lastYearmonth = valueDecimal;
                    else if (i == 14)
                        actualMonth = valueDecimal;
                    else if (i >= 11 && i < 14)
                        sum3PreviousMonths += valueDecimal; // sum of 3 previous months 

                    valueDecimal = 0;
                    range = wsSource.Cells[13, i];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);
                    wsTarget.Cells[6, i].Value = valueDecimal;
                }

                wsTarget = wbTarget.Worksheets[0];

                var advices2 = EvalueAdviceG2(wsTarget.Cells["AT7"].Value.ToString()
                    , sum3PreviousMonths, actualMonth, lastYearmonth, wsTarget.Cells["E48"].Value.ToString());
                wsTarget.Cells["E48"].Value = advices2.Item1;
                wsTarget.Cells["E51"].Value = advices2.Item2;

                #endregion

                #region Graphic 3

                wsTarget = wbTarget.Worksheets[2];

                lastYearmonth = 0;
                actualMonth = 0;
                sum3PreviousMonths = 0;
                for (var i = 2; i < 15; i++)
                {
                    dateValue = ParseDateXlsToDateTime(int.Parse(wsSource.Cells[11, i].Value.ToString()));
                    wsTarget.Cells[9, i].Value = FormatMonthYear(dateValue.Value.Month, dateValue.Value.Year, true); // headerDates

                    valueDecimal = 0;
                    range = wsSource.Cells[14, i];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);

                    wsTarget.Cells[10, i].Value = valueDecimal;
                    if (i == 2)
                        lastYearmonth = valueDecimal;
                    else if (i == 14)
                        actualMonth = valueDecimal;
                    else if (i >= 11 && i < 14)
                        sum3PreviousMonths += valueDecimal; // sum of 3 previous months 

                    valueDecimal = 0;
                    range = wsSource.Cells[15, i];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);
                    wsTarget.Cells[11, i].Value = valueDecimal;
                }

                wsTarget = wbTarget.Worksheets[0];

                var advices3 = EvalueAdviceG3(wsTarget.Cells["AT7"].Value.ToString()
                    , sum3PreviousMonths, actualMonth, lastYearmonth, wsTarget.Cells["AD48"].Value.ToString());
                wsTarget.Cells["AD48"].Value = advices3.Item1;
                wsTarget.Cells["AD51"].Value = advices3.Item2;
                #endregion

                #region Graphic 4

                index = 1;
                for (var i = 19; i < 24; i++, index++)
                {
                    range = wsSource.Cells[19, 2];
                    int.TryParse(range.Value.ToString(), out valueInt);
                    wsTarget.Cells["E59"].Value = valueInt.ToString();

                    range = wsSource.Cells[19, 3];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);
                    wsTarget.Cells["H59"].Value = $"({(int)(valueDecimal * 100)}%)";

                    range = wsSource.Cells[20, 2];
                    int.TryParse(range.Value.ToString(), out valueInt);
                    wsTarget.Cells["E61"].Value = valueInt.ToString();

                    range = wsSource.Cells[20, 3];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);
                    wsTarget.Cells["H61"].Value = $"({(int)(valueDecimal * 100)}%)";

                    range = wsSource.Cells[21, 2];
                    int.TryParse(range.Value.ToString(), out valueInt);
                    wsTarget.Cells["E63"].Value = valueInt.ToString();

                    range = wsSource.Cells[21, 3];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);
                    wsTarget.Cells["H63"].Value = $"({(int)(valueDecimal * 100)}%)";

                    range = wsSource.Cells[22, 2];
                    int.TryParse(range.Value.ToString(), out valueInt);
                    wsTarget.Cells["E65"].Value = valueInt.ToString();

                    range = wsSource.Cells[22, 3];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);
                    wsTarget.Cells["H65"].Value = $"({(int)(valueDecimal * 100)}%)";

                    range = wsSource.Cells[23, 2];
                    int.TryParse(range.Value.ToString(), out valueInt);
                    wsTarget.Cells["E67"].Value = valueInt.ToString();

                    range = wsSource.Cells[23, 3];
                    decimal.TryParse(range.Value.ToString(), out valueDecimal);
                    wsTarget.Cells["H67"].Value = $"({(int)(valueDecimal * 100)}%)";

                }

                wsTarget = wbTarget.Worksheets[0];

                #endregion

                #region Graphic 5  

                wsTarget = wbTarget.Worksheets[2];
                wbSource.WorkbookSet.Calculate();

                List<(int, int)> mayor_days = new List<(int, int)>();
                index = 7; // Begins on Sunday
                int lessValueIndex = 0;
                for (var i = 2; i < 9; i++, index--)
                {
                    lessValueIndex = -1;
                    valueInt = 0;
                    int.TryParse(wsSource.Cells[33, i].Value.ToString(), out valueInt);
                    wsTarget.Cells[15, i].Value = valueInt;

                    if (valueInt > 0)
                    {
                        if (mayor_days.Count == 0)
                            mayor_days.Add((index, valueInt));
                        else
                        {
                            if (mayor_days.Count < 3)
                                mayor_days.Add(ValueTuple.Create(index, valueInt));
                            else
                            {
                                for (var pos = 0; pos < mayor_days.Count; pos++)
                                    if (valueInt > mayor_days[pos].Item2)
                                        lessValueIndex = pos;

                                if (lessValueIndex != -1)
                                    mayor_days[lessValueIndex] = (index, valueInt);
                            }

                        }
                    }
                }

                wsTarget = wbTarget.Worksheets[0];

                var advices5 = EvalueAdviceG5(mayor_days, wsTarget.Cells["AD70"].Value.ToString());
                wsTarget.Cells["AD70"].Value = advices5.Item1;

                #endregion

                string nameTarget = $"{name}~{ruc}~{email}.xlsx";

                using (MemoryStream file = new MemoryStream())
                {
                    wbTarget.SaveToStream(file, SpreadsheetGear.FileFormat.OpenXMLWorkbook);
                    wbTarget.SaveAs($@"{FolderPath}\{nameTarget}", SpreadsheetGear.FileFormat.OpenXMLWorkbook);
                    GeneratePDF(file, $@"{FolderPath}\{nameTarget}", ruc.Trim());
                }
                counterWorked++;
                this.ProgressFinished = counterWorked;
            }

            this.ProgressFinished = counterWorked;

            this.WorkFinished = true;
        }

        private void GeneratePDF(MemoryStream file, string ruta, string password)
        {
            string rutapdf = Path.ChangeExtension(ruta, ".pdf");
            Workbook workbook = new Workbook();

            workbook.LoadFromStream(file, ExcelVersion.Version2016);

            using (MemoryStream stream = new MemoryStream())
            {
                workbook.SaveToStream(stream, Spire.Xls.FileFormat.PDF);

                PdfReader reader = new PdfReader(stream);
                WriterProperties props = new WriterProperties().SetStandardEncryption(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(password), EncryptionConstants.ALLOW_PRINTING,
                                EncryptionConstants.ENCRYPTION_AES_128 | EncryptionConstants.DO_NOT_ENCRYPT_METADATA);
                PdfWriter writer = new PdfWriter(rutapdf, props);
                PdfDocument pdfDoc = new PdfDocument(reader, writer);
                pdfDoc.Close();
            }
        }

        private (string, string) EvalueAdviceG2(string currentTitleMonth, decimal sum3PreviousMonths, decimal currentMonth, decimal lastYearMonth, string baseFormat)
        {
            string[] parts = baseFormat.Split('/');
            string verb = string.Empty;
            string percent = string.Empty;
            string finalAdvice = string.Empty;
            if (lastYearMonth + sum3PreviousMonths + currentMonth > 0)
            {
                parts[0] = parts[0].Replace("{MONTH}", currentTitleMonth);
                if (sum3PreviousMonths / 3 < currentMonth)
                {
                    verb = "han incrementado";
                    percent = $"en {(int)(Math.Abs(((sum3PreviousMonths / 3) / currentMonth) * 100 - 100))}%";
                    finalAdvice = "¡Sigue así!";
                }
                else if (sum3PreviousMonths / 3 > currentMonth)
                {
                    verb = "han reducido";
                    percent = $"en {(int)(Math.Abs((currentMonth > 0 ? (sum3PreviousMonths / 3) / currentMonth : 0) * 100 - 100))}%";
                    finalAdvice = "Puedes realizar actividades de marketing para reactivar tus ventas.";
                }
                else
                {
                    verb = "mantienen";
                    finalAdvice = "Vas bien, pero puedes mejorar.";
                }

                parts[0] = parts[0].Replace("{VERB_1}", verb).Replace("{PER_1}", percent);

                if (lastYearMonth < currentMonth)
                {
                    verb = "hubo un incremento";
                    percent = $"del {(int)(Math.Abs((lastYearMonth / currentMonth) * 100 - 100))}%";
                }
                else if (lastYearMonth > currentMonth)
                {
                    verb = "hubo una reducción";
                    percent = $"del {(int)(Math.Abs((currentMonth > 0 ? lastYearMonth / currentMonth : 0) * 100 - 100))}%";
                }
                else verb = "hay un equilibrio";

                parts[1] = parts[1].Replace("{VERB_2}", verb).Replace("{PER_2}", percent);
                baseFormat = parts[0] + parts[1];
            }
            else baseFormat = "¡No has tenido actividad en mucho tiempo!";
            return (baseFormat, finalAdvice);
        }

        private (string, string) EvalueAdviceG3(string currentTitleMonth, decimal sum3PreviousMonths, decimal currentMonth, decimal lastYearMonth, string baseFormat)
        {
            string[] parts = baseFormat.Split('/');
            string verb = string.Empty;
            string percent = string.Empty;
            string finalAdvice = string.Empty;
            if (lastYearMonth + sum3PreviousMonths + currentMonth > 0)
            {
                if (sum3PreviousMonths / 3 < currentMonth)
                {
                    verb = "han incrementado";
                    percent = $"en {(int)(Math.Abs(((sum3PreviousMonths / 3) / currentMonth) * 100 - 100))}%";
                    finalAdvice = "¡Sigue así!";
                }
                else if (sum3PreviousMonths / 3 > currentMonth)
                {
                    verb = "han reducido";
                    percent = $"en {(int)(Math.Abs((currentMonth > 0 ? (sum3PreviousMonths / 3) / currentMonth : 0) * 100 - 100))}%";
                    finalAdvice = "Puedes realizar actividades de marketing para reactivar tus ventas.";
                }
                else
                {
                    verb = "mantienen";
                    finalAdvice = "Vas bien, pero puedes mejorar.";
                }

                parts[0] = parts[0].Replace("{VERB_1}", verb).Replace("{PER_1}", percent);

                if (lastYearMonth < currentMonth)
                {
                    verb = "un incremento";
                    percent = $"del {(int)(Math.Abs((lastYearMonth / currentMonth) * 100 - 100))}%";
                }
                else if (lastYearMonth > currentMonth)
                {
                    verb = "una reducción";
                    percent = $"del {(int)(Math.Abs((currentMonth > 0 ? lastYearMonth / currentMonth : 0) * 100 - 100))}%";
                }
                else verb = "un equilibrio";

                parts[1] = parts[1].Replace("{VERB_2}", verb).Replace("{PER_2}", percent);
                baseFormat = parts[0] + parts[1];
            }
            else baseFormat = "¡No has tenido actividad en mucho tiempo!";

            return (baseFormat, finalAdvice);
        }

        private (string, string) EvalueAdviceG5(List<(int, int)> hitDays, string baseFormat)
        {
            string[] parts = baseFormat.Split('/');
            string days = string.Empty;

            if (hitDays.Count > 0)
            {
                for (var pos = 0; pos < hitDays.Count; pos++)
                    days += (hitDays.Count > 1 && pos == hitDays.Count - 1 ? " y " : string.Empty) + (FormatDays(hitDays[pos].Item1) + (pos != hitDays.Count - 1 ? ", " : string.Empty));

                parts[0] = parts[0].Replace("{DAYS}", days);
                baseFormat = parts[0] + parts[1];
            }
            else baseFormat = parts[1];
            return (baseFormat, string.Empty);
        }

        private string FormatDays(int day)
        {
            switch (day)
            {
                case 1:
                    return "lunes";
                case 2:
                    return "martes";
                case 3:
                    return "miércoles";
                case 4:
                    return "jueves";
                case 5:
                    return "viernes";
                case 6:
                    return "sábados";
                case 7:
                    return "domingos";
            }
            return string.Empty;

        }

        private string FormatMonthYear(int month, int year, bool includeSimbol = false)
        {
            string slipper = (includeSimbol ? "-" : " ");
            switch (month)
            {
                case 1:
                    return $"Ene{slipper}{year}";
                case 2:
                    return $"Feb{slipper}{year}";
                case 3:
                    return $"Mar{slipper}{year}";
                case 4:
                    return $"Abr{slipper}{year}";
                case 5:
                    return $"May{slipper}{year}";
                case 6:
                    return $"Jun{slipper}{year}";
                case 7:
                    return $"Jul{slipper}{year}";
                case 8:
                    return $"Ago{slipper}{year}";
                case 9:
                    return $"Set{slipper}{year}";
                case 10:
                    return $"Oct{slipper}{year}";
                case 11:
                    return $"Nov{slipper}{year}";
                case 12:
                    return $"Dic{slipper}{year}";
            }
            return string.Empty;

        }

        private DateTime ParseDateXlsToDateTime(int SerialDate)
        {
            if (SerialDate > 59) SerialDate -= 1; //Excel/Lotus 2/29/1900 bug   
            return new DateTime(1899, 12, 31).AddDays(SerialDate);
        }

    }
}
