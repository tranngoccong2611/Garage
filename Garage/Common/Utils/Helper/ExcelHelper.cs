using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Data;
using System.IO;
 

    namespace GaraOto.Common.Utilities.Helper
    {
        public static class ExcelHelper
        {
            public static byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName = "Sheet1")
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Tạo một worksheet mới
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetName);

                    // Thiết lập tiêu đề cho các cột
                    var properties = typeof(T).GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = properties[i].Name; // Tiêu đề cột
                    }

                    // Xuất dữ liệu
                    int row = 2; // Bắt đầu từ dòng thứ hai
                    foreach (var item in data)
                    {
                        for (int i = 0; i < properties.Length; i++)
                        {
                            worksheet.Cells[row, i + 1].Value = properties[i].GetValue(item); // Xuất giá trị
                        }
                        row++;
                    }

                    // Trả về tệp Excel dưới dạng byte[]
                    return package.GetAsByteArray();
                }
            }
        }
    
}
