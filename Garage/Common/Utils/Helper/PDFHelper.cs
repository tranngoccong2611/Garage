using System;
using System.Data;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
public static class PdfHelper
{
    public static void ExportToPdf(DataTable dataTable, string filePath)
    {
        // Kiểm tra và tạo thư mục nếu chưa có
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        try
        {
            Console.WriteLine("Đang tạo PDF...");

            // Tạo PDF
            using (PdfWriter writer = new PdfWriter(filePath))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document document = new Document(pdf))
            {
                // Thêm tiêu đề
                document.Add(new Paragraph("Dữ liệu từ người dùng")
                    .SetBold()
                    .SetFontSize(20)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20));

                // Tạo bảng với các cột từ DataTable
                Table table = new Table(dataTable.Columns.Count, false);
                table.SetWidth(UnitValue.CreatePercentValue(100));

                // Thêm header cho các cột
                foreach (DataColumn column in dataTable.Columns)
                {
                    table.AddHeaderCell(new Cell()
                        .Add(new Paragraph(column.ColumnName))
                        .SetBold()
                        .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(5));
                }

                // Thêm dữ liệu vào bảng
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var cell in row.ItemArray)
                    {
                        table.AddCell(new Cell()
                            .Add(new Paragraph(cell.ToString()))
                            .SetPadding(5)
                            .SetTextAlignment(TextAlignment.LEFT));
                    }
                }

                // Thêm bảng vào tài liệu PDF
                document.Add(table);
            }

            Console.WriteLine("PDF đã được tạo thành công!");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine("Lỗi hệ thống tệp: " + ioEx.Message);
            Console.WriteLine(ioEx.StackTrace);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi tạo PDF: " + ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}