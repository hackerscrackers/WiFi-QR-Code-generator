Imports ZXing
Public Class Form1

    'https://github.com/micjahn/ZXing.Net
    'https://www.iprogrammatori.it/articoli/microsoft-net-framework/art_net-generare-un-codice-qrcode-vbnet-e-c_1346.aspx

    'https://stackoverflow.com/questions/52052380/using-visual-studio-code-for-vb-net-how-to-enable-vb-net-intellisense

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Dim Testo As String = TextBox1.Text + TextBox2.Text

        Dim GeneraBarcode As IBarcodeWriter = New BarcodeWriter() With {.Format = BarcodeFormat.QR_CODE}
        GeneraBarcode.Options.Height = 250
        GeneraBarcode.Options.Width = 290

        Dim bitmapBarcode As Bitmap

        Dim risultato = GeneraBarcode.Write(Testo)

        bitmapBarcode = New Bitmap(risultato)
        PictureBox1.Image = bitmapBarcode


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("WEP")
        ComboBox1.Items.Add("WPA / WPA2")

    End Sub
End Class
