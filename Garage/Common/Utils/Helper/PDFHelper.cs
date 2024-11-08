using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Data;


namespace Garage.Common.Utils.Helper
{
    public static class PdfHelper
    {
        public static void ExportToPdf(DataTable dataTable, string filePath)
        {
            // Tạo file PDF mới
            using (PdfWriter writer = new PdfWriter(filePath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Thêm tiêu đề
                    document.Add(new Paragraph("Dữ liệu từ DataTable").SetBold().SetFontSize(20));

                    // Tạo bảng
                    Table table = new Table(dataTable.Columns.Count);

                    // Thêm tiêu đề cột
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(column.ColumnName)).SetBold());
                    }

                    // Thêm dữ liệu vào bảng
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (var cell in row.ItemArray)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(cell.ToString())));
                        }
                    }

                    // Thêm bảng vào tài liệu
                    document.Add(table);
                }
            }
        }
    }
}
