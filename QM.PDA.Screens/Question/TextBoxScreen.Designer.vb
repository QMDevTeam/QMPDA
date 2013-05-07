

Namespace Question

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TextBoxScreen
        Inherits QuestionScreen

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.txtAnswer = New System.Windows.Forms.TextBox
            Me.pnlAnswerArea.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlAnswerArea
            '
            Me.pnlAnswerArea.Controls.Add(Me.txtAnswer)
            '
            'txtAnswer
            '
            Me.txtAnswer.Location = New System.Drawing.Point(0, 0)
            Me.txtAnswer.Name = "txtAnswer"
            Me.txtAnswer.Size = New System.Drawing.Size(210, 21)
            Me.txtAnswer.TabIndex = 4
            Me.txtAnswer.MaxLength = 50
            '
            'TextBoxScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "TextBoxScreen"
            Me.Text = "TextBoxScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlAnswerArea.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents txtAnswer As System.Windows.Forms.TextBox

    End Class

End Namespace