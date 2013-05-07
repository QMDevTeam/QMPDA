

Namespace Question

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
        Partial Public Class QuestionScreen
        Inherits BaseScreen

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
            Me.btnHelp = New System.Windows.Forms.Button
            Me.pnlAnswerArea = New System.Windows.Forms.Panel
            Me.SuspendLayout()
            '
            'btnHelp
            '
            Me.btnHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.btnHelp.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
            Me.btnHelp.ForeColor = System.Drawing.Color.White
            Me.btnHelp.Location = New System.Drawing.Point(1, 52)
            Me.btnHelp.Name = "btnHelp"
            Me.btnHelp.Size = New System.Drawing.Size(16, 16)
            Me.btnHelp.TabIndex = 0
            Me.btnHelp.Text = "?"
            '
            'pnlAnswerArea
            '
            Me.pnlAnswerArea.Location = New System.Drawing.Point(20, 164)
            Me.pnlAnswerArea.Name = "pnlAnswerArea"
            Me.pnlAnswerArea.Size = New System.Drawing.Size(220, 130)
            Me.pnlAnswerArea.AutoScroll = True
            '
            'QuestionScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Controls.Add(Me.btnHelp)
            Me.Controls.Add(Me.pnlAnswerArea)
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "QuestionScreen"
            Me.Text = "QuestionScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents pnlAnswerArea As System.Windows.Forms.Panel
        Protected WithEvents btnHelp As System.Windows.Forms.Button
    End Class

End Namespace
