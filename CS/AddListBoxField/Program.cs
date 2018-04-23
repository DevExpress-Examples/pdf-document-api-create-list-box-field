using DevExpress.Pdf;
using System.Drawing;

namespace AddListBoxField {
    class Program {
        static void Main(string[] args) {
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Create an empty document. 
                processor.CreateEmptyDocument("..\\..\\Result.pdf");

                // Create graphics and draw a list box field.
                using (PdfGraphics graphics = processor.CreateGraphics()) {
                    DrawListBoxField(graphics);

                    // Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics);
                }
            }

        }

        static void DrawListBoxField(PdfGraphics graphics) {

            // Create a list box field specifying its name and location.
            PdfGraphicsAcroFormListBoxField listBox = new PdfGraphicsAcroFormListBoxField("list box", new RectangleF(20, 20, 100, 120));

            // Add values to the list box.
            listBox.AddValue("Blue");
            listBox.AddValue("Green");
            listBox.AddValue("Red");
            listBox.AddValue("Yellow");

            // Specify list box appearance, text alignment, and select value. 
            listBox.Appearance.BackgroundColor = Color.Aqua;
            listBox.TextAlignment = PdfAcroFormStringAlignment.Far;
            listBox.SelectValue("Blue");

            // Add the field to the document.
            graphics.AddFormField(listBox);
        }
    }
}
