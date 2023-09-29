Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Private textBox1 As Object

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles EnviarNombre.Click

        Dim textoIngresado As String = textBox1.Text

        If String.IsNullOrWhiteSpace(textoIngresado) Then
            LabelError.Text = "*Campo obligatorio"
        Else
            ' Aquí puedes realizar otras acciones con el texto ingresado
            ' por ejemplo, mostrarlo en un MessageBox o procesarlo de alguna manera.
            MessageBox.Show("Texto ingresado: " & textoIngresado)
            ' Limpia el mensaje de error si se ingresó texto correctamente.
            LabelError.Text = ""
        End If

    End Sub

    Private Sub TextBoxNombre_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNombre.TextChanged

    End Sub
End Class
