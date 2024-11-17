using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Forms.Style
{
    public class CustomPanel : Panel
    {
        public int BorderRadius { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var path = new GraphicsPath())
            {
                var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                path.AddRoundedRectangle(rect, BorderRadius);
                this.Region = new Region(path);
                using (var pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}
public class CustomPanelColor : Panel
{
    // Thuộc tính để lưu trữ màu viền của các cạnh
    public Color LeftRightBorderColor { get; set; } = Color.Blue;
    public Color TopBottomBorderColor { get; set; } = Color.Red;

    // Thuộc tính để thiết lập màu từ giá trị RGB
    public void SetBorderColors(int leftRightR, int leftRightG, int leftRightB, int topBottomR, int topBottomG, int topBottomB)
    {
        LeftRightBorderColor = Color.FromArgb(leftRightR, leftRightG, leftRightB);
        TopBottomBorderColor = Color.FromArgb(topBottomR, topBottomG, topBottomB);
        Invalidate(); // Gọi lại vẽ lại panel
    }

    // Phương thức vẽ viền tùy chỉnh
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Tạo các bút vẽ với màu sắc đã thiết lập từ người dùng
        Pen leftRightPen = new Pen(LeftRightBorderColor, 1); // Màu cho cạnh trái và phải
        Pen topBottomPen = new Pen(TopBottomBorderColor, 1);  // Màu cho cạnh trên và dưới

        // Vẽ các đường viền của panel
        e.Graphics.DrawLine(leftRightPen, 0, 0, 0, this.Height);  // Cạnh trái
        e.Graphics.DrawLine(leftRightPen, this.Width - 1, 0, this.Width - 1, this.Height);  // Cạnh phải
        e.Graphics.DrawLine(topBottomPen, 0, 0, this.Width, 0);  // Cạnh trên
        e.Graphics.DrawLine(topBottomPen, 0, this.Height - 1, this.Width, this.Height - 1);  // Cạnh dưới
    }
}