<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        EnviarNombre = New Button()
        TextBoxNombre = New TextBox()
        LabelError = New Label()
        SuspendLayout()
        ' 
        ' EnviarNombre
        ' 
        EnviarNombre.Location = New Point(520, 237)
        EnviarNombre.Name = "EnviarNombre"
        EnviarNombre.Size = New Size(75, 23)
        EnviarNombre.TabIndex = 0
        EnviarNombre.Text = "Enviar"
        EnviarNombre.UseVisualStyleBackColor = True
        ' 
        ' TextBoxNombre
        ' 
        TextBoxNombre.Location = New Point(145, 237)
        TextBoxNombre.Name = "TextBoxNombre"
        TextBoxNombre.PlaceholderText = "Introduzca su nombre..."
        TextBoxNombre.Size = New Size(369, 23)
        TextBoxNombre.TabIndex = 1
        ' 
        ' LabelError
        ' 
        LabelError.AutoSize = True
        LabelError.ForeColor = Color.Red
        LabelError.Location = New Point(149, 263)
        LabelError.Name = "LabelError"
        LabelError.Size = New Size(112, 15)
        LabelError.TabIndex = 2
        LabelError.Text = "*Campo obligatorio"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(LabelError)
        Controls.Add(TextBoxNombre)
        Controls.Add(EnviarNombre)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents EnviarNombre As Button
    Friend WithEvents TextBoxNombre As TextBox
    Friend WithEvents LabelError As Label
End Class
