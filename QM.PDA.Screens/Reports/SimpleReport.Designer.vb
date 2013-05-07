

Namespace Reports

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SimpleReport
        Inherits BaseForm

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
            Me.InputPanel = New Microsoft.WindowsCE.Forms.InputPanel
            Me.lblTitle = New System.Windows.Forms.Label
            Me.dgData = New System.Windows.Forms.DataGrid
            Me.SuspendLayout()
            '
            'mnuChangeStudy
            '
            Me.mnuChangeStudy.Enabled = False
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.Location = New System.Drawing.Point(2, 2)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(236, 20)
            Me.lblTitle.Text = "Sujetos pendientes"
            '
            'dgData
            '
            Me.dgData.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.dgData.Location = New System.Drawing.Point(0, 24)
            Me.dgData.Name = "dgData"
            Me.dgData.Size = New System.Drawing.Size(240, 270)
            Me.dgData.TabIndex = 2
            '
            'ReporteSujetosPendientes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Controls.Add(Me.lblTitle)
            Me.Controls.Add(Me.dgData)
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "SimpleReport"
            Me.Text = "SimpleReport"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.Controls.SetChildIndex(Me.dgData, 0)
            Me.Controls.SetChildIndex(Me.lblTitle, 0)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents dgData As System.Windows.Forms.DataGrid

    End Class

End Namespace