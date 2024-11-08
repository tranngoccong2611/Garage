using System;
using System.Drawing;
using System.Windows.Forms;

namespace Garage.Forms
{
    public static class ModernTheme
    {
        // Colors

        public static Color Primary => Color.FromArgb(52, 152, 219);
        public static Color Secondary => Color.FromArgb(41, 128, 185);
        public static Color Success => Color.FromArgb(46, 204, 113);
        public static Color Danger => Color.FromArgb(231, 76, 60);
        public static Color Warning => Color.FromArgb(241, 196, 15);
        public static Color Background => Color.FromArgb(245, 247, 250);
        public static Color CardBackground => Color.White;
        public static Color TextDark => Color.FromArgb(44, 62, 80);
        public static Color TextLight => Color.FromArgb(149, 165, 166);

        // Fonts
        public static Font HeaderFont => new Font("Segoe UI Semibold", 14F);
        public static Font SubHeaderFont => new Font("Segoe UI", 12F);
        public static Font BodyFont => new Font("Segoe UI", 10F);
        public static Padding StandardPadding = new Padding(10);
        public static int StandardButtonWidth = 120;
        public static int StandardButtonHeight = 40;
        // Button Style
        public static void ApplyButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Primary;
            button.ForeColor = Color.White;
            button.Font = BodyFont;
            button.Padding = new Padding(15, 8, 15, 8);
            button.Cursor = Cursors.Hand;

            button.MouseEnter += (s, e) => button.BackColor = Secondary;
            button.MouseLeave += (s, e) => button.BackColor = Primary;
        }

        // DataGridView Style
        public static void ApplyDataGridViewStyle(DataGridView dgv)
        {
            dgv.BackgroundColor = CardBackground;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = SubHeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgv.ColumnHeadersHeight = 50;

            dgv.DefaultCellStyle.BackColor = CardBackground;
            dgv.DefaultCellStyle.Font = BodyFont;
            dgv.DefaultCellStyle.Padding = new Padding(5);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 236, 248);
            dgv.DefaultCellStyle.SelectionForeColor = TextDark;

            dgv.RowTemplate.Height = 40;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 251, 253);
        }
    }
    public class ModernButton : Button
    {
        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = ModernTheme.Primary;
            ForeColor = ModernTheme.TextLight;
            Font = ModernTheme.BodyFont;
            Size = new Size(ModernTheme.StandardButtonWidth, ModernTheme.StandardButtonHeight);
            Cursor = Cursors.Hand;
        }
    }

    // Custom TextBox
    public class ModernTextBox : TextBox
    {
        public ModernTextBox()
        {
            BorderStyle = BorderStyle.FixedSingle;
            Font = ModernTheme.BodyFont;
            Size = new Size(200, 30);
        }
    }
}
