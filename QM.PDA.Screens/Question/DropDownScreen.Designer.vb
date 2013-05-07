

Namespace Question

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DropDownScreen
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
            Me.cmbSelector = New System.Windows.Forms.ComboBox
            Me.pnlAnswerArea.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlAnswerArea
            '
            Me.pnlAnswerArea.Controls.Add(Me.cmbSelector)
            '
            'cmbSelector
            '
            Me.cmbSelector.DisplayMember = "Text"
            Me.cmbSelector.Location = New System.Drawing.Point(0, 0)
            Me.cmbSelector.Name = "cmbSelector"
            Me.cmbSelector.Size = New System.Drawing.Size(210, 22)
            Me.cmbSelector.TabIndex = 0
            Me.cmbSelector.ValueMember = "Value"
            '
            'DropDownScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "DropDownScreen"
            Me.Text = "DropDownScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlAnswerArea.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents cmbSelector As System.Windows.Forms.ComboBox

    End Class

End Namespace