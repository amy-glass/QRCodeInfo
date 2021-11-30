using System;
using System.Text;
using System.Drawing;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using QRCodeInfo.Services;

namespace QRCodeInfo.ConsoleApp
{
    public class QRCodeInfo
    {
        public static void Main()
        {
            QRCodeModifier qrModifier = new QRCodeModifier();
            Image qrImage1 = qrModifier.GetImage(@"E:\csharp\QRCodeInfo\qr_test\qr1.jpg");
            Image qrImage2 = qrModifier.GetImage(@"E:\csharp\QRCodeInfo\qr_test\qr2.jpg");
            var decodedQr1 = qrModifier.DecodeImage(qrImage1);
            var decodedQr2 = qrModifier.DecodeImage(qrImage2);
            Console.WriteLine($"Code One: {decodedQr1}");
            Console.WriteLine($"Code Two: {decodedQr2}");
            Console.WriteLine($"Difference: {qrModifier.CompareDecodedCodes(decodedQr1, decodedQr2)}");
            Console.ReadLine();

        }

    }
}