

Imports QRCoder


Public Class WiFi_QrcoderPlg



    Public Enum Authentication
        WEP
        WPA
        nopass
    End Enum

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Select Case ComboBox1.SelectedIndex
            Case 0
                Dim generator As New PayloadGenerator.WiFi(TextBox1.Text, TextBox2.Text, PayloadGenerator.WiFi.Authentication.nopass)
                Dim payload As String = generator.ToString()

                Dim qrGenerator As New QRCodeGenerator()
                Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q)
                Dim qrCode As New QRCode(qrCodeData)
                Dim qrCodeAsBitmap As Object = qrCode.GetGraphic(6)

                PictureBox1.Image = qrCodeAsBitmap
                PictureBox1.Update()
                Button2.Enabled = True
            Case 1
                Dim generator As New PayloadGenerator.WiFi(TextBox1.Text, TextBox2.Text, PayloadGenerator.WiFi.Authentication.WEP)
                Dim payload As String = generator.ToString()

                Dim qrGenerator As New QRCodeGenerator()
                Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q)
                Dim qrCode As New QRCode(qrCodeData)
                Dim qrCodeAsBitmap As Object = qrCode.GetGraphic(6)

                PictureBox1.Image = qrCodeAsBitmap
                PictureBox1.Update()
                Button2.Enabled = True
            Case 2
                Dim generator As New PayloadGenerator.WiFi(TextBox1.Text, TextBox2.Text, PayloadGenerator.WiFi.Authentication.WPA)
                Dim payload As String = generator.ToString()

                Dim qrGenerator As New QRCodeGenerator()
                Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q)
                Dim qrCode As New QRCode(qrCodeData)
                Dim qrCodeAsBitmap As Object = qrCode.GetGraphic(6)

                PictureBox1.Image = qrCodeAsBitmap
                PictureBox1.Update()
                Button2.Enabled = True
            Case Else
                MsgBox(e.ToString, MsgBoxStyle.OkOnly, MsgBoxStyle.Critical)
                Button2.Enabled = False
                Exit Select
        End Select



    End Sub

    Private Sub WiFi_QrcoderPlg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add(Authentication.nopass)
        ComboBox1.Items.Add(Authentication.WEP)
        ComboBox1.Items.Add(Authentication.WPA)
        Button2.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim savedimage As String = (Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)).ToString + "\" + TextBox1.Text + ".png"
            PictureBox1.Image.Save(savedimage, Imaging.ImageFormat.Png)
            MessageBox.Show("Immagine salvata in:" + savedimage)
            Button2.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MessageBox.Show("Si ringrazia l'utente GitHub codebude per la sua libreria QRCoder." & vbCrLf & vbCrLf & "Copyright 2019 hackerscrackers", "Ringraziamenti:")
    End Sub
End Class