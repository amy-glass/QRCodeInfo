using System;
using Drawing = System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Collections.Generic;
using System.Linq;
using QRCodeInfo.Services;

namespace QRCodeInfo.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            QRCodeModifier qrModifier = new QRCodeModifier();
            InitializeComponent();
            Drawing.Image qrImage1 = qrModifier.GetImage(@"E:\csharp\QRCodeInfo\qr_test\qr1.jpg");
            Drawing.Image qrImage2 = qrModifier.GetImage(@"E:\csharp\QRCodeInfo\qr_test\qr2.jpg");
            var decodedQr1 = qrModifier.DecodeImage(qrImage1);
            var decodedQr2 = qrModifier.DecodeImage(qrImage2);
            txtOne.Text = decodedQr1;
            txtTwo.Text = decodedQr2;
            txtdiff.Text = qrModifier.CompareDecodedCodes(decodedQr1, decodedQr2);

        }

        /*public Drawing.Image GetImage(string filename)
        {
            Drawing.Bitmap _qrImage = (Drawing.Bitmap)Drawing.Bitmap.FromFile(filename);
            img_qrCode.Source = new BitmapImage(new Uri(filename));
            return _qrImage;
        }

        public string DecodeImage(Drawing.Image image)
        {
            try
            {
                QRCodeDecoder qRDecoder = new QRCodeDecoder();
                var imageText = qRDecoder.Decode(new QRCodeBitmapImage(image as Drawing.Bitmap));
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

            var diff = set2.Count() > set1.Count() ? set2.Except(set1).ToList() : set1.Except(set2).ToList();

            return string.Join("", diff);
        }*/
    }
}
