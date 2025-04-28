using System;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows;

namespace MipItemInfoPlugin
{
    internal static class BitmapExtensions
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        public static BitmapSource ToBitmapSource(this Bitmap bitmap)
        {
            var hBitmap = bitmap.GetHbitmap();
            var bmpSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
              hBitmap,
              IntPtr.Zero,
              Int32Rect.Empty,
              BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hBitmap);
            return bmpSource;
        }
    }
}
