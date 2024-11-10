using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedPanel : Panel
{
    public int BorderRadius { get; set; } = 30; // Radius size for rounded corners
    public Color colorBorder;
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Create a GraphicsPath for rounded corners
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);                     // Top-left corner
        path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);  // Top-right corner
        path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90); // Bottom-right
        path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);  // Bottom-left
        path.CloseFigure();

        // Set the path as the panel's region to apply the rounded corners
        this.Region = new Region(path);

        // Optional: Draw border
        using (Pen pen = new Pen(Color.White, 2))
        {
            e.Graphics.DrawPath(pen, path);
        }
    }
}
