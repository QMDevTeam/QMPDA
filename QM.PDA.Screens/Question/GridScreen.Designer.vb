

Namespace Question

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GridScreen
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
            Me.uxGrid = New System.Windows.Forms.DataGrid
            Me.pnlAnswerArea.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlAnswerArea
            '
            Me.pnlAnswerArea.Controls.Add(Me.uxGrid)
            Me.pnlAnswerArea.Left -= 3
            Me.pnlAnswerArea.Width += 3
            '
            'uxGrid
            '
            Me.uxGrid.Dock = Windows.Forms.DockStyle.Fill
            Me.uxGrid.Name = "uxDataGrid"
            Me.uxGrid.TabIndex = 4
            '
            'QueryScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "QueryScreen"
            Me.Text = "QueryScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlAnswerArea.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents uxGrid As System.Windows.Forms.DataGrid

    End Class

End Namespace