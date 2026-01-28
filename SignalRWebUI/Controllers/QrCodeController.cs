using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;

namespace SignalRWebUI.Controllers
{
    public class QrCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(memoryStream,ImageFormat.Png);
                    ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult DecodeQrCode(IFormFile qrImage)
        {
            if (qrImage != null && qrImage.Length > 0)
            {
                try
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        qrImage.CopyTo(memoryStream);
                        memoryStream.Position = 0;

                        using (var bitmap = new Bitmap(memoryStream))
                        {
                            var reader = new BarcodeReader();
                            var result = reader.Decode(bitmap);

                            if (result != null)
                            {
                                ViewBag.DecodedText = result.Text;
                                ViewBag.UploadedImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                            }
                            else
                            {
                                ViewBag.ErrorMessage = "QR kod okunamadı. Lütfen geçerli bir QR kod resmi yükleyin.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Hata: " + ex.Message;
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Lütfen bir resim dosyası seçin.";
            }

            return View("Index");
        }
    }
}
