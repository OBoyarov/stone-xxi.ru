<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ReqDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Value = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Valute = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ReqDate
        '
        Me.ReqDate.Location = New System.Drawing.Point(12, 25)
        Me.ReqDate.Name = "ReqDate"
        Me.ReqDate.Size = New System.Drawing.Size(137, 20)
        Me.ReqDate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Дата:"
        '
        'Value
        '
        Me.Value.Location = New System.Drawing.Point(522, 25)
        Me.Value.Name = "Value"
        Me.Value.ReadOnly = True
        Me.Value.Size = New System.Drawing.Size(182, 20)
        Me.Value.TabIndex = 2
        Me.Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(519, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Курс:"
        '
        'Valute
        '
        Me.Valute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Valute.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Valute.FormattingEnabled = True
        Me.Valute.Location = New System.Drawing.Point(155, 25)
        Me.Valute.Name = "Valute"
        Me.Valute.Size = New System.Drawing.Size(361, 20)
        Me.Valute.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(152, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Валюта:"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(717, 162)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Valute)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Value)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReqDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ParseCBR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReqDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Value As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Valute As ComboBox
    Friend WithEvents Label3 As Label
End Class
