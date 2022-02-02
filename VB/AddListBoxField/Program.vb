Imports DevExpress.Pdf
Imports System.Drawing

Namespace AddListBoxField

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Create an empty document. 
                processor.CreateEmptyDocument("..\..\Result.pdf")
                ' Create graphics and draw a list box field.
                Using graphics As PdfGraphics = processor.CreateGraphics()
                    DrawListBoxField(graphics)
                    ' Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics)
                End Using
            End Using
        End Sub

        Private Shared Sub DrawListBoxField(ByVal graphics As PdfGraphics)
            ' Create a list box field specifying its name and location.
            Dim listBox As PdfGraphicsAcroFormListBoxField = New PdfGraphicsAcroFormListBoxField("list box", New RectangleF(20, 20, 100, 120))
            ' Add values to the list box.
            listBox.AddValue("Blue")
            listBox.AddValue("Green")
            listBox.AddValue("Red")
            listBox.AddValue("Yellow")
            ' Specify list box appearance, text alignment, and select value. 
            listBox.Appearance.BackgroundColor = Color.Aqua
            listBox.TextAlignment = PdfAcroFormStringAlignment.Far
            listBox.SelectValue("Blue")
            ' Add the field to the document.
            graphics.AddFormField(listBox)
        End Sub
    End Class
End Namespace
