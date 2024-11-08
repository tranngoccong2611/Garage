using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Garage.Forms.Style
{
    public class CustomButton : Button
    {
        // Properties for customizations
        public Color BackgroundColor { get; set; } = Color.LightBlue;
        public Color BorderColor { get; set; } = Color.Blue;
        public int BorderWidth { get; set; } = 2;
        public int BorderRadius { get; set; } = 15;
        public Color TextColor { get; set; } = Color.White;
        public FontStyle FontWeight { get; set; } = FontStyle.Bold;

        public CustomButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.MiddleCenter;
            ForeColor = TextColor;
            BackColor = BackgroundColor;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create rounded rectangle path
            using (GraphicsPath path = CreateRoundedRectanglePath(ClientRectangle, BorderRadius))
            {
                // Set the button's region to match the rounded rectangle, clipping its edges
                this.Region = new Region(path);

                // Draw button background
                using (SolidBrush brush = new SolidBrush(BackgroundColor))
                {
                    pevent.Graphics.FillPath(brush, path);
                }

                // Draw border
                if (BorderWidth > 0)
                {
                    using (Pen pen = new Pen(BorderColor, BorderWidth))
                    {
                        pevent.Graphics.DrawPath(pen, path);
                    }
                }
            }

            // Draw text
            TextRenderer.DrawText(
                pevent.Graphics,
                Text,
                new Font(Font.FontFamily, Font.Size, FontWeight),
                ClientRectangle,
                TextColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
