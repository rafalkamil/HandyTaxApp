using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SelectPdf;

namespace HandyTaxApp.Controllers
{
    [Route("invoicePdf")]
    public class GeneratePdf : Controller
    {
        ICompositeViewEngine _compositeViewEngine;

        public GeneratePdf(ICompositeViewEngine compositeViewEngine)
        {
            _compositeViewEngine = compositeViewEngine;
        }

        [Route("invoice")]
        public async Task<IActionResult> InvoiceAsync()
        {
            using (var stringWriter = new StringWriter())
            {
                var viewResult = _compositeViewEngine.FindView(ControllerContext, "Home/Index", false);

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());

                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    viewDictionary,
                    TempData,
                    stringWriter,
                    new HtmlHelperOptions()
                    );

                await viewResult.View.RenderAsync(viewContext);

                var htmlToPdf = new HtmlToPdf(1000, 1414);
                htmlToPdf.Options.DrawBackground = true;

                var pdf = htmlToPdf.ConvertHtmlString(stringWriter.ToString());
                var pdfBytes = pdf.Save();

                return File(pdfBytes, "aplication/pdf");
            }
        }

        [Route("website")]
        public async Task<IActionResult> WebsiteInvoiceAsync()
        {
            
            var pdfView = new HtmlToPdf();

            pdfView.Options.WebPageWidth = 1920;

            var pdf = pdfView.ConvertUrl("https://www.handytax.co.uk/index.html");

            var pdfBytes = pdf.Save();

            return File(pdfBytes, "aplication/pdf");
        }
        
    }
}
