using System.Drawing.Drawing2D;

namespace Garage.Common.Extension
{
    public class ImageRouded
    {
        public static Image CreateRoundedImage(Image originalImage, int borderRadius)
        {
            // Create a new bitmap with the same dimensions as the original image
            Bitmap roundedImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Create a Graphics object to draw on the new bitmap
            using (Graphics g = Graphics.FromImage(roundedImage))
            {
                // Set the graphics object quality
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent); // Set background as transparent

                // Create a rectangle with the same size as the image
                Rectangle rect = new Rectangle(0, 0, originalImage.Width, originalImage.Height);

                // Create a rounded rectangle path (ellipse or rounded corner rectangle)
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90); // Top-left corner
                    path.AddArc(rect.X + rect.Width - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90); // Top-right corner
                    path.AddArc(rect.X + rect.Width - borderRadius, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 0, 90); // Bottom-right corner
                    path.AddArc(rect.X, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 90, 90); // Bottom-left corner
                    path.CloseFigure();

                    // Set the clip region to the rounded rectangle
                    g.SetClip(path);

                    // Draw the original image inside the clipped region
                    g.DrawImage(originalImage, rect);
                }
            }

            return roundedImage;
        }
    }
}
