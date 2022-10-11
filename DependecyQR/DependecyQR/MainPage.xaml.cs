using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


namespace DependecyQR
{
    public partial class MainPage : ContentPage
    {
        ZXingBarcodeImageView qr;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGenerateQR_Clicked(object sender, EventArgs e)
        {
            qr = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            qr.BarcodeFormat=ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeValue = "https://www.youtube.com.mx";
            stkQR.Children.Add(qr);
        }
        private async void btnScannerQR_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Abrir camara para leer codigo QR
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Escanear Código QR";
                scanner.BottomText = "Listo";

                var result = await scanner.Scan();

                //Mostrar el resultado del Scanner
                if (result != null)
                {
                    txtResultado.Text = result.Text;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(),"OK");
            }
        }
    }
}
