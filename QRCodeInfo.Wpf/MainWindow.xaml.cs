using System;
using System.Collections.Generic;
using Drawing = System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace QRCodeInfo.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DecodeImage(GetImage(""));
        }

        public Drawing.Image GetImage(string filename)
        {
            return (Drawing.Bitmap)Drawing.Bitmap.FromFile(filename);
        }

        public void DecodeImage(Drawing.Image image) {

            QRCodeDecoder qRDecoder = new QRCodeDecoder();
            var imageText = qRDecoder.Decode(new QRCodeBitmapImage( image as Drawing.Bitmap));
            txtResults.Text = imageText;
        }
    }
}
