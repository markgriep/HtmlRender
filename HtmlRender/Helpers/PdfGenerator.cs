
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;



namespace HtmlRender.Helpers
{
    public class PdfGenerator
    {
        public byte[] GenerateHelloWorldPdf()
        {

            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Inch);
                    page.DefaultTextStyle(x => x.FontSize(12));
                    page.Content().Text("Hello World").FontSize(20).Bold();
                });
            });



            var x = document.GeneratePdf(); // Returns PDF as byte array

            return x;
        }
    }
}