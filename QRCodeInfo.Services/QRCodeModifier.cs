using System;
using System.Drawing;
using System.Windows;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Collections.Generic;
using System.Linq;

namespace QRCodeInfo.Services
{
    public class QRCodeModifier
    {
        public Image GetImage(string filename) => Image.FromFile(filename);

        public string DecodeImage(Image image)
        {
            try
            {
                QRCodeDecoder qRDecoder = new QRCodeDecoder();
                var imageText = qRDecoder.Decode(new QRCodeBitmapImage(image as Bitmap));
                return imageText;
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}. {Environment.NewLine}{ex.InnerException}";
            }
        }

        public string CompareDecodedCodes(string str1, string str2)
        {
            if (str1 == null)
            {
                return str2;
            }
            if (str2 == null)
            {
                return str1;
            }

            List<string> set1 = str1.Split(' ').Distinct().ToList();
            List<string> set2 = str2.Split(' ').Distinct().ToList();

            var diff1 = set1.Count() > set2.Count() ? set1.Except(set2).ToList() : set2.Except(set1).ToList();
            var diff2 = set2.Count() > set1.Count() ? set2.Except(set1).ToList() : set1.Except(set2).ToList();

            return $"{string.Join("",diff1)}, {string.Join("", diff2)}";
        }

    }
}
