using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace ShopKA.Models
{
    public class CovertImage
    {
        public static string convert64(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            string base64String = Convert.ToBase64String(xByte);
            return base64String;

        }

        
    }
}