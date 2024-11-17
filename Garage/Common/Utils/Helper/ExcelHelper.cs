using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace GaraOto.Common.Utilities.Helper
{
    public static class ExcelHelper
    {
        /// <summary>
        /// Xuất dữ liệu ra file Excel với tên file theo thời gian
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của collection</typeparam>
        /// <param name="data">Dữ liệu cần xuất</param>
        /// <param name="baseFileName">Tên cơ bản của file (không cần đuôi .xlsx)</param>
        /// <param name="folderPath">Đường dẫn thư mục lưu file</param>
        /// <param name="sheetName">Tên sheet trong Excel</param>
        /// <returns>Đường dẫn đầy đủ đến file Excel đã tạo</returns>
        public static string ExportToExcel<T>(
            IEnumerable<T> data,
            string baseFileName,
            string folderPath = null,
            string sheetName = "Sheet1")
        {
            // Tạo tên file với timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{baseFileName}_{timestamp}.xlsx";

            // Nếu không chỉ định folderPath, sử dụng thư mục Documents
            if (string.IsNullOrEmpty(folderPath))
            {
                folderPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "GarageExports"
                );
            }

            // Tạo thư mục nếu chưa tồn tại
            Directory.CreateDirectory(folderPath);

            // Đường dẫn đầy đủ đến file
            string fullPath = Path.Combine(folderPath, fileName);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                var properties = typeof(T).GetProperties();

                // Thiết lập tiêu đề cho các cột
                for (int i = 0; i < properties.Length; i++)
                {
                    var cell = worksheet.Cells[1, i + 1];
                    cell.Value = properties[i].Name;

                    // Định dạng tiêu đề
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // Xuất dữ liệu
                int row = 2;
                foreach (var item in data)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        var cell = worksheet.Cells[row, i + 1];
                        var value = properties[i].GetValue(item);

                        // Xử lý định dạng cho các kiểu dữ liệu khác nhau
                        if (value != null)
                        {
                            if (value is DateTime dateValue)
                            {
                                cell.Value = dateValue;
                                cell.Style.Numberformat.Format = "dd/MM/yyyy";
                            }
                            else if (value is decimal || value is double || value is float)
                            {
                                cell.Value = value;
                                cell.Style.Numberformat.Format = "#,##0.00";
                            }
                            else if (value is int || value is long)
                            {
                                cell.Value = value;
                                cell.Style.Numberformat.Format = "#,##0";
                            }
                            else
                            {
                                cell.Value = value;
                            }
                        }

                        // Thêm border cho cell
                        cell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                    row++;
                }

                // Tự động điều chỉnh độ rộng cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Lưu file
                File.WriteAllBytes(fullPath, package.GetAsByteArray());
            }

            return fullPath;
        }

        /// <summary>
        /// Tạo tên file theo định dạng: baseFileName_yyyyMMdd_HHmmss.xlsx
        /// </summary>
        public static string GenerateFileName(string baseFileName)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"{baseFileName}_{timestamp}.xlsx";
        }

        /// <summary>
        /// Xuất dữ liệu ra byte array (để trả về qua API hoặc download trực tiếp)
        /// </summary>
        public static byte[] ExportToExcelBytes<T>(
            IEnumerable<T> data,
            string sheetName = "Sheet1")
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                var properties = typeof(T).GetProperties();

                // Thiết lập tiêu đề và định dạng tương tự như trên
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                }

                // Xuất dữ liệu
                int row = 2;
                foreach (var item in data)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[row, i + 1].Value = properties[i].GetValue(item);
                    }
                    row++;
                }

                return package.GetAsByteArray();
            }
        }
    }
}