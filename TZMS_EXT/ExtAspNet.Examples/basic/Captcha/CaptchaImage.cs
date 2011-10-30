using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;


namespace CaptchaImage
{
    /// <summary>
    /// FROM:http://www.codeproject.com/KB/aspnet/CaptchaImage.aspx
    /// Summary description for CaptchaImage.
    /// </summary>
    public class CaptchaImage
    {
        /// <summary>
        /// Text
        /// </summary>
        public string Text
        {
            get { return this.text; }
        }

        /// <summary>
        /// Image
        /// </summary>
        public Bitmap Image
        {
            get { return this.image; }
        }

        /// <summary>
        /// Width
        /// </summary>
        public int Width
        {
            get { return this.width; }
        }

        /// <summary>
        /// Height
        /// </summary>
        public int Height
        {
            get { return this.height; }
        }

        /// <summary>
        /// text
        /// </summary>
        private string text;

        /// <summary>
        /// width
        /// </summary>
        private int width;

        /// <summary>
        /// height
        /// </summary>
        private int height;

        /// <summary>
        /// familyName
        /// </summary>
        private string familyName;

        /// <summary>
        /// image
        /// </summary>
        private Bitmap image;

        /// <summary>
        /// For generating random numbers.
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the CaptchaImage class using the
        /// </summary>
        /// <param name="ss">ss</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        public CaptchaImage(string ss, int width, int height)
        {
            this.text = ss;
            this.SetDimensions(width, height);
            this.GenerateImage();
        }

        /// <summary>
        /// Initializes a new instance of the CaptchaImage class using the
        /// specified text, width, height and font family.
        /// </summary>
        /// <param name="ss">ss</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        /// <param name="familyName">familyName</param>
        public CaptchaImage(string ss, int width, int height, string familyName)
        {
            this.text = ss;
            this.SetDimensions(width, height);
            this.SetFamilyName(familyName);
            this.GenerateImage();
        }

        /// <summary>
        /// This member overrides Object.Finalize.
        /// </summary>
        ~CaptchaImage()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        /// <summary>
        /// Custom Dispose method to clean up unmanaged resources.
        /// </summary>
        /// <param name="disposing">disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of the bitmap.
                this.image.Dispose();
            }
        }

        /// <summary>
        /// Sets the image width and height.
        /// </summary>
        /// <param name="width">¿í¶È</param>
        /// <param name="height">¸ß¶È</param>
        private void SetDimensions(int width, int height)
        {
            // Check the width and height.
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", width, "Argument out of range, must be greater than zero.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height", height, "Argument out of range, must be greater than zero.");
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Sets the font used for the image text.
        /// </summary>
        /// <param name="familyName">familyName</param>
        private void SetFamilyName(string familyName)
        {
            // If the named font is not installed, default to a system font.
            try
            {
                Font font = new Font(this.familyName, 13F);
                this.familyName = familyName;
                font.Dispose();
            }
            catch (Exception)
            {
                this.familyName = System.Drawing.FontFamily.GenericSerif.Name;
            }
        }

        /// <summary>
        /// Creates the bitmap image.
        /// </summary>
        private void GenerateImage()
        {
            // Create a new 32-bit bitmap image.
            Bitmap bitmap = new Bitmap(this.width, this.height, PixelFormat.Format32bppArgb);

            // Create a graphics object for drawing.
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.width, this.height);

            // Fill in the background.
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.Green, Color.White);
            g.FillRectangle(hatchBrush, rect);

            // Set up the text font.
            SizeF size = new SizeF();
            float fontSize = rect.Height + 1;
            Font font;
            // Adjust the font size until the text fits within the image.
            do
            {
                fontSize--;
                font = new Font(this.familyName, fontSize, FontStyle.Bold);
                size = g.MeasureString(this.text, font);
            } 
            while (size.Width > rect.Width);

            // Set up the text format.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Create a path using the text and warp it randomly.
            GraphicsPath path = new GraphicsPath();
            path.AddString(this.text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            float v = 4F;
            PointF[] points =
			{
				new PointF(this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
				new PointF(rect.Width - this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
				new PointF(this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v),
				new PointF(rect.Width - this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v)
			};
            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

            // Draw the text.
            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, Color.Black, Color.Black);
            g.FillPath(hatchBrush, path);

            // Add some random noise.
            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = this.random.Next(rect.Width);
                int y = this.random.Next(rect.Height);
                int w = this.random.Next(m / 50);
                int h = this.random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            // Clean up.
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            // Set the image.
            this.image = bitmap;
        }
    }
}
