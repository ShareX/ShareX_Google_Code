using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelpersLib
{
    public static class ClipboardHelper
    {
        public static void SetImage(Image img)
        {
            MemoryStream ms = new MemoryStream();
            MemoryStream ms2 = new MemoryStream();
            Bitmap bmp = new Bitmap(img);
            bmp.Save(ms, ImageFormat.Bmp);
            byte[] b = ms.GetBuffer();
            ms2.Write(b, 14, (int)ms.Length - 14);
            ms.Position = 0;
            DataObject dataObject = new DataObject();
            dataObject.SetData(DataFormats.Bitmap, bmp);
            dataObject.SetData(DataFormats.Dib, ms2);
            Clipboard.SetDataObject(dataObject, true, 3, 1000);
        }
    }
}