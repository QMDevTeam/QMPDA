

Namespace Question

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NameScreen
        Inherits PDA.Screens.Question.QuestionScreen

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
            Me.txtName = New System.Windows.Forms.TextBox
            Me.txtSecondName = New System.Windows.Forms.TextBox
            Me.lstbNames = New System.Windows.Forms.ListBox
            Me.pnlAnswerArea.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlAnswerArea
            '
            Me.pnlAnswerArea.Controls.Add(Me.txtName)
            Me.pnlAnswerArea.Controls.Add(Me.txtSecondName)
            '
            'txtName
            '
            Me.txtName.Location = New System.Drawing.Point(0, 0)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(210, 21)
            Me.txtName.TabIndex = 0
            '
            'txtSecondName
            '
            Me.txtSecondName.Location = New System.Drawing.Point(0, 26)
            Me.txtSecondName.Name = "txtSecondName"
            Me.txtSecondName.Size = New System.Drawing.Size(210, 21)
            Me.txtSecondName.TabIndex = 1
            '
            'lstbNames
            '
            Me.lstbNames.Location = New System.Drawing.Point(5, 84)
            Me.lstbNames.Name = "lstbNames"
            Me.lstbNames.Size = New System.Drawing.Size(210, 100)
            Me.lstbNames.TabIndex = 2
            '
            'NameScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Controls.Add(Me.lstbNames)
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "NameScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlAnswerArea.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtSecondName As System.Windows.Forms.TextBox
        Friend WithEvents lstbNames As System.Windows.Forms.ListBox

    End Class

End Namespace