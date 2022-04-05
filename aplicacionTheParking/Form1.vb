
Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Conexiones.AbrirConexion()
        Conexiones.Cnn.Open()

        Dim result As Integer
        Dim fecha As Date
        Dim porcentaje As Integer
        Dim Llantas_2 As Integer
        Dim Llantas_4 As Integer
        Dim Llantas_8 As Integer
        Dim recibo As Integer
        Dim iva As Single


        fecha = Now
        recibo = TextPaga.Text
        Llantas_2 = 12000
        Llantas_4 = 18000
        Llantas_8 = 32000
        iva = 0.19


        result = Llantas_2 + porcentaje

        If result < recibo Then


            If (ComboBox1.Text = "2 LLANTAS") And (txtSi.Checked = True) Then

                porcentaje = Llantas_2 * iva
                result = Llantas_2 + porcentaje


                TextIva.Text = porcentaje
                TextValor.Text = result
                TextDevolver.Text = result - recibo

            End If

            If (ComboBox1.Text = "2 LLANTAS") And (txtNo.Checked = True) Then


                result = Llantas_2

                TextIva.Text = "0"
                TextValor.Text = result
                TextDevolver.Text = result - recibo

            End If

            If (ComboBox1.Text = "4 LLANTAS") And (txtSi.Checked = True) Then

                porcentaje = Llantas_4 * iva
                result = Llantas_4 + porcentaje

                TextIva.Text = porcentaje
                TextValor.Text = result
                TextDevolver.Text = result - recibo

            End If

            If (ComboBox1.Text = "4 LLANTAS") And (txtNo.Checked = True) Then


                result = Llantas_4

                TextIva.Text = "0"
                TextValor.Text = result
                TextDevolver.Text = result - recibo

            End If

            If (ComboBox1.Text = "8 LLANTAS") And (txtSi.Checked = True) Then

                porcentaje = Llantas_8 * iva
                result = Llantas_8 + porcentaje

                TextIva.Text = porcentaje
                TextValor.Text = result
                TextDevolver.Text = result - recibo

            End If

            If (ComboBox1.Text = "8 LLANTAS") And (txtNo.Checked = True) Then


                result = Llantas_8

                TextIva.Text = "0"
                TextValor.Text = result
                TextDevolver.Text = result - recibo

            End If

            If TextPlaca.Text <> "" Then
                Dim cmd As New SqlClient.SqlCommand("insert into dbo.aplicativo ( placa, pago_recibo , iva, valor_pagar, devuelta, fecha) values('" & TextPlaca.Text & "','" & TextPaga.Text & "','" & TextIva.Text & "','" & TextValor.Text & "','" & TextDevolver.Text & "','" & fecha & "')", Conexiones.Cnn)
                cmd.ExecuteNonQuery()
            End If
        Else

            MsgBox("El valor ingresado es inferior al cobrado")

        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextPaga.Text = ""
        TextPlaca.Text = ""
        TextIva.Text = ""
        TextValor.Text = ""
        TextDevolver.Text = ""
        ComboBox1.Text = "Seleccionar"
        txtSi.Checked = False
        txtNo.Checked = False

    End Sub
End Class
