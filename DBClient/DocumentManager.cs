using DBClient.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using DBClient.Properties;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using TsSoft.Orthography.Numbers;

namespace DBClient
{
    class DocumentManager
    {
        public async static System.Threading.Tasks.Task CreateProductReport()
        {
            Word._Application oWord;
            Word._Document oDoc;
            try
            {
                API api = API.GetInstance();
                List<Product> products = await api.AsyncGetCatalog<Product>();
                if (products.Count == 0)
                    throw new Exception("В БД нет записей о товарах");
                var categories = products.GroupBy(p => p.Category?.Name);
                int rows = 0;
                foreach (var c in categories)
                {
                    rows += 1 + c.Count();
                }

                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                //Start Word and create a new document.
                oWord = new Word.Application();
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                object start = 0, end = 0;
                Word.Range rng = oDoc.Range(ref start, ref end);
                rng.SetRange(rng.End, rng.End);

                // Header
                Paragraph header = oDoc.Content.Paragraphs.Add(ref oMissing);
                var rngReportHeader = header.Range;
                rngReportHeader.Text = "Отчет по остаткам";
                rngReportHeader.Font.Size = 15;
                rngReportHeader.Font.Name = "Verdana";
                rngReportHeader.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                rngReportHeader.InsertParagraphAfter();

                // Add the table.
                Paragraph table = oDoc.Content.Paragraphs.Add(ref oMissing);
                var rngTable = table.Range;
                rngTable.Tables.Add(rngTable, rows + 1, 6, ref oMissing, ref oMissing);

                // Format the table and apply a style. 
                Word.Table tbl = oDoc.Tables[1];
                tbl.Range.Font.Size = 12;
                tbl.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                tbl.Range.ParagraphFormat.SpaceAfter = 0.0f;
                tbl.Borders.Enable = 1;

                tbl.Cell(1, 1).Range.Text = "ИД";
                tbl.Cell(1, 2).Range.Text = "Название";
                tbl.Cell(1, 3).Range.Text = "Ед.";
                tbl.Cell(1, 4).Range.Text = "Цена";
                tbl.Cell(1, 5).Range.Text = "Количество";
                tbl.Cell(1, 6).Range.Text = "Сумма";
                for (int j = 1; j <= 6; j++)
                {
                    var cell = tbl.Cell(1, j);
                    cell.Range.Font.Bold = 1;
                    cell.Range.Font.Name = "Verdana";
                    cell.Range.Font.Size = 12;
                    cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                    //Center alignment for the Header cells
                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }
                int i = 2;
                foreach (var c in categories)
                {
                    tbl.Cell(i, 1).Range.Text = c.Key;
                    tbl.Rows[i].Cells.Merge();
                    i++;
                    foreach (var p in c)
                    {
                        tbl.Cell(i, 1).Range.Text = p.Id.ToString();
                        tbl.Cell(i, 2).Range.Text = p.Name;
                        tbl.Cell(i, 3).Range.Text = p.Unit?.ToString();
                        tbl.Cell(i, 4).Range.Text = p.Price.ToString() + " руб.";
                        tbl.Cell(i, 5).Range.Text = p.Quantity.ToString();
                        tbl.Cell(i, 6).Range.Text = (p.Price * (decimal)p.Quantity).ToString() + " руб.";
                        i++;
                    }
                }
                tbl.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
                tbl.TopPadding = 6f;
                tbl.RightPadding = 6f;
                tbl.LeftPadding = 6f;
                tbl.BottomPadding = 6f;
                tbl.Range.InsertParagraphAfter();

                // Footer
                Paragraph footer = oDoc.Content.Paragraphs.Add(ref oMissing);
                var rngReportFooter = footer.Range;
                rngReportFooter.Text = "\nНа дату: " + DateTime.Now.ToString();
                rngReportFooter.Font.Size = 10;
                rngReportFooter.Font.Name = "Verdana";
                rngReportFooter.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                rngReportFooter.InsertParagraphAfter();

                oWord.Visible = true;
                return;
            }
            catch
            {
                throw;
            }
            finally
            {
                oDoc = null;
                oWord = null;
            }
        }

        public async static System.Threading.Tasks.Task CreateOrderReport(DateTime first, DateTime second)
        {
            Word._Application oWord;
            Word._Document oDoc;
            try
            {
                API api = API.GetInstance();
                var list = await api.AsyncGetCatalog<Order>();
                var completedOrders = list.Where(o => o.IsComplete & o.Date >= first & o.Date <= second).ToList();
                if (completedOrders.Count == 0)
                    throw new Exception("В БД нет записей о завершенных заказах за данный период");

                int rows = 0;
                foreach (var order in completedOrders)
                {
                    rows += 2 + order.OrderProducts.Count;
                }

                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                // Start Word and create a new document.
                oWord = new Word.Application();
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                object start = 0, end = 0;
                Word.Range rng = oDoc.Range(ref start, ref end);
                rng.SetRange(rng.End, rng.End);

                // Header
                Paragraph header = oDoc.Content.Paragraphs.Add(ref oMissing);
                var rngReportHeader = header.Range;
                rngReportHeader.Text = $"Отчет по завершенным заказам\nза период {first.ToShortDateString()} – {second.ToShortDateString()}";
                rngReportHeader.Font.Size = 14;
                rngReportHeader.Font.Name = "Verdana";
                rngReportHeader.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                rngReportHeader.InsertParagraphAfter();

                // Add the table.
                Paragraph table = oDoc.Content.Paragraphs.Add(ref oMissing);
                var rngTable = table.Range;
                rngTable.Tables.Add(rngTable, rows + 1, 4, ref oMissing, ref oMissing);

                // Format the table and apply a style. 
                Word.Table tbl = oDoc.Tables[1];
                tbl.Range.Font.Size = 12;
                tbl.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                tbl.Range.ParagraphFormat.SpaceAfter = 0.0f;
                tbl.Borders.Enable = 1;

                tbl.Cell(1, 1).Range.Text = "ИД";
                tbl.Cell(1, 2).Range.Text = "Заказчик";
                tbl.Cell(1, 3).Range.Text = "Дата";
                tbl.Cell(1, 4).Range.Text = "Сумма";
                for (int j = 1; j <= 4; j++)
                {
                    var cell = tbl.Cell(1, j);
                    cell.Range.Font.Bold = 1;
                    cell.Range.Font.Name = "Verdana";
                    cell.Range.Font.Size = 12;
                    cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                    //Center alignment for the Header cells
                    cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                }
                int i = 2;
                foreach (var o in completedOrders)
                {
                    tbl.Cell(i, 1).Range.Text = o.Id.ToString();
                    tbl.Cell(i, 2).Range.Text = o.Customer.Name;
                    tbl.Cell(i, 3).Range.Text = o.Date.ToShortDateString();
                    tbl.Cell(i, 4).Range.Text = o.OrderProducts.Sum(op => op.Product.Price * (decimal)op.Quantity).ToString() + " руб.";
                    tbl.Rows[i].Borders[WdBorderType.wdBorderTop].LineWidth = WdLineWidth.wdLineWidth300pt;
                    i++;
                    tbl.Cell(i, 2).Range.Text = "Товар";
                    tbl.Cell(i, 3).Range.Text = "Кол-во";
                    tbl.Cell(i, 4).Range.Text = "Сумма";
                    tbl.Rows[i].Range.Font.Bold = 1;
                    i++;
                    foreach (var op in o.OrderProducts)
                    {
                        tbl.Cell(i, 1).Borders[WdBorderType.wdBorderTop].Visible = false;
                        tbl.Cell(i, 2).Range.Text = op.Product.Name;
                        tbl.Cell(i, 3).Range.Text = op.Quantity.ToString();
                        tbl.Cell(i, 4).Range.Text = (op.Product.Price * (decimal)op.Quantity).ToString() + " руб.";
                        i++;
                    }
                }
                tbl.Columns.First.AutoFit();
                tbl.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
                tbl.TopPadding = 6f;
                tbl.RightPadding = 6f;
                tbl.LeftPadding = 6f;
                tbl.BottomPadding = 6f;

                // Footer
                Paragraph footer = oDoc.Content.Paragraphs.Add(ref oMissing);
                var rngReportFooter = footer.Range;
                rngReportFooter.Text = "\nОтчет создан: " + DateTime.Now.ToString();
                rngReportFooter.Font.Size = 10;
                rngReportFooter.Font.Name = "Verdana";
                rngReportFooter.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                rngReportFooter.InsertParagraphAfter();

                oWord.Visible = true;
                return;
            }
            catch
            {
                throw;
            }
            finally
            {
                oDoc = null;
                oWord = null;
            }
        }
    
        public async static System.Threading.Tasks.Task CreateSupplyDocument(int docId, object supplyObj)
        {
            Supply supply = (Supply)supplyObj;
            Employee employee = supply.Employee;
            var products = supply.SupplyProducts;
            var rowsCount = supply.SupplyProducts.Count;
            var columnsCount = 6;
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            object oMissing = System.Reflection.Missing.Value;

            try
            {
                API api = API.GetInstance();
                CompanyDetails companyDetails = await api.GetCompanyDetails();
                List<Unit> units = await api.AsyncGetCatalog<Unit>();
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string resourceFolder = Path.Combine(currentDirectory, "Resources");
                string file = Path.Combine(resourceFolder, "supplyDoc.xls");
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(file));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                oSheet.get_Range("D2", "I2").Value2 = companyDetails.Name;
                oSheet.get_Range("D3", "F3").Value2 = companyDetails.INN;
                oSheet.get_Range("H4").Value2 = docId;
                oSheet.get_Range("F5", "G5").Value2 = DateTime.Now.ToShortDateString();
                oSheet.get_Range("E15").Value2 = $"{employee}";
                for (int i = 1; i < rowsCount; i++)
                    oSheet.get_Range("B10:I10").EntireRow.Insert(oMissing, XlInsertFormatOrigin.xlFormatFromRightOrBelow);
                for (int i = 0; i < rowsCount; i++)
                {
                    var range = (Excel.Range)oSheet.Range[oSheet.Cells[10 + i, 3], oSheet.Cells[10 + i, 5]];
                    range.Merge();
                }
                var tableRange = (Excel.Range)oSheet.Range[oSheet.Cells[10, 2], oSheet.Cells[10, 9]];
                tableRange = tableRange.get_Resize(rowsCount, columnsCount);

                for (int row = 10, i; row < 10 + rowsCount; row++)
                {
                    i = row - 10;
                    oSheet.Cells[row, 2].Value2 = (i + 1);
                    oSheet.Cells[row, 3].Value2 = products[i].Product.ToString();
                    oSheet.Cells[row, 6].Value2 = units
                        .Where(u => u.Id == products[i].Product.UnitId)
                        .FirstOrDefault()
                        .ToString();
                    oSheet.Cells[row, 7].Value2 = products[i].Product.Price;
                    oSheet.Cells[row, 8].Value2 = products[i].Quantity;
                    oSheet.Cells[row, 9].Value2 = (products[i].Product.Price * (decimal)products[i].Quantity);
                }
                decimal sum = products.Sum(p => (decimal)p.Quantity * p.Product.Price);
                oSheet.Cells[10 + rowsCount, 9].Value2 = sum;

                INumberToWordConverter numberToWordsConverter = NumbersToWordsConverterFactory.CreateRussianConverter();
                string convertResult = numberToWordsConverter.ConvertCurrency(sum);
                oSheet.Cells[10 + rowsCount + 2, 2].Value2 = convertResult;

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception)
            { 
                throw;
            }
        }
        public async static System.Threading.Tasks.Task CreateOrderDocument(int docId, object orderObj)
        {
            Order order = (Order)orderObj;
            var products = order.OrderProducts;
            var rowsCount = products.Count;
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            object oMissing = System.Reflection.Missing.Value;

            try
            {
                API api = API.GetInstance();
                CompanyDetails companyDetails = await api.GetCompanyDetails();
                List<Unit> units = await api.AsyncGetCatalog<Unit>();
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string resourceFolder = Path.Combine(currentDirectory, "Resources");
                string file = Path.Combine(resourceFolder, "orderDoc.xls");
                oWB = (Excel._Workbook)(oXL.Workbooks.Add(file));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                oSheet.Cells[6, 45].Value2 = docId;
                string[] date = $"{DateTime.Now:dd MMMM yyyy года}".Split(new char[] { ' ' }, 2);
                oSheet.Cells[6, 58].Value2 = date[0];
                oSheet.Cells[6, 66].Value2 = date[1];
                oSheet.Cells[9, 13].Value2 = companyDetails.Name;
                oSheet.Cells[10, 9].Value2 = $"{companyDetails.PostalCode}, {companyDetails.Address}";
                oSheet.Cells[11, 25].Value2 = $"{companyDetails.INN} / {companyDetails.KPP}";
                oSheet.Cells[15, 15].Value2 = $"{order.Customer.Name}";
                oSheet.Cells[16, 9].Value2 = $"{order.Customer.PostalCode}, {order.Customer.Address}";
                oSheet.Cells[17, 27].Value2 = $"{order.Customer.INN} / {order.Customer.KPP}";
                for (int i = 3; i < rowsCount; i++)
                {
                    (oSheet.Range[oSheet.Cells[23, 1], oSheet.Cells[23, 150]] as Excel.Range)
                       .EntireRow
                       .Insert(oMissing, XlInsertFormatOrigin.xlFormatFromRightOrBelow);
                    (oSheet.Range[oSheet.Cells[23, 1], oSheet.Cells[23, 22]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 23], oSheet.Cells[23, 26]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 27], oSheet.Cells[23, 40]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 41], oSheet.Cells[23, 48]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 41], oSheet.Cells[23, 48]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 49], oSheet.Cells[23, 59]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 60], oSheet.Cells[23, 74]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 75], oSheet.Cells[23, 84]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 85], oSheet.Cells[23, 95]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 96], oSheet.Cells[23, 107]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 108], oSheet.Cells[23, 126]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 127], oSheet.Cells[23, 136]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 137], oSheet.Cells[23, 149]] as Excel.Range)
                        .Merge();
                    (oSheet.Range[oSheet.Cells[23, 150], oSheet.Cells[23, 161]] as Excel.Range)
                        .Merge();
                }
                var tableRange = (Excel.Range)oSheet.Range[oSheet.Cells[23, 1], oSheet.Cells[23, 150]];
                tableRange = tableRange.get_Resize(rowsCount, oMissing);

                decimal totalSumWithoutTax = 0;
                decimal totalTax = 0;
                for (int row = 23, i; row < 23 + rowsCount; row++)
                {
                    i = row - 23;
                    decimal sumWithoutTax = (products[i].Product.Price * (decimal)products[i].Quantity);
                    decimal tax = sumWithoutTax * products[i].Product.VAT;
                    totalSumWithoutTax += sumWithoutTax;
                    totalTax += tax;
                    oSheet.Cells[row, 1].Value2 = products[i].Product.ToString();
                    oSheet.Cells[row, 23].Value2 = products[i].Product.UnitId;
                    oSheet.Cells[row, 27].Value2 = units
                        .Where(u => u.Id == products[i].Product.UnitId)
                        .FirstOrDefault()
                        .ToString();
                    oSheet.Cells[row, 41].Value2 = products[i].Quantity;
                    oSheet.Cells[row, 49].Value2 = products[i].Product.Price;
                    oSheet.Cells[row, 60].Value2 = sumWithoutTax;
                    oSheet.Cells[row, 75].Value2 = "Без акциза";
                    oSheet.Cells[row, 85].Value2 = $"{products[i].Product.VAT * 100}%";
                    oSheet.Cells[row, 96].Value2 = tax;
                    oSheet.Cells[row, 108].Value2 = sumWithoutTax + tax;
                    oSheet.Cells[row, 127].Value2 = "–";
                    oSheet.Cells[row, 137].Value2 = "–";
                    oSheet.Cells[row, 150].Value2 = "–";
                }

                int offset = rowsCount > 3 ? 1 : 4 - rowsCount;
                oSheet.Cells[23 + offset + rowsCount, 60].Value2 = totalSumWithoutTax;
                oSheet.Cells[23 + offset + rowsCount, 96].Value2 = totalTax;
                oSheet.Cells[23 + offset + rowsCount, 108].Value2 = totalTax + totalSumWithoutTax;

                //Make sure Excel is visible and give the user control
                //of Microsoft Excel's lifetime.
                oXL.Visible = true;
                oXL.UserControl = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
