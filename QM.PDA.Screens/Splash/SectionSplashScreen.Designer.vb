

Namespace Splash

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SectionSplashScreen
        Inherits PDA.Screens.BaseScreen

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
            Me.lblVersion = New System.Windows.Forms.Label
            Me.lblSectionShortName = New System.Windows.Forms.Label
            Me.lblSectionName = New System.Windows.Forms.Label
            Me.lblQuestionnaireName = New System.Windows.Forms.Label
            Me.SuspendLayout()
            '
            'lblVersion
            '
            Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
            Me.lblVersion.ForeColor = System.Drawing.Color.Gray
            Me.lblVersion.Location = New System.Drawing.Point(70, 248)
            Me.lblVersion.Name = "lblVersion"
            Me.lblVersion.Size = New System.Drawing.Size(100, 20)
            Me.lblVersion.Text = "Version"
            Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblSectionShortName
            '
            Me.lblSectionShortName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblSectionShortName.ForeColor = System.Drawing.Color.Red
            Me.lblSectionShortName.Location = New System.Drawing.Point(70, 228)
            Me.lblSectionShortName.Name = "lblSectionShortName"
            Me.lblSectionShortName.Size = New System.Drawing.Size(100, 20)
            Me.lblSectionShortName.Text = "S ShortName"
            Me.lblSectionShortName.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblSectionName
            '
            Me.lblSectionName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
            Me.lblSectionName.ForeColor = System.Drawing.Color.Black
            Me.lblSectionName.Location = New System.Drawing.Point(3, 124)
            Me.lblSectionName.Name = "lblSectionName"
            Me.lblSectionName.Size = New System.Drawing.Size(234, 71)
            Me.lblSectionName.Text = "Section Name"
            Me.lblSectionName.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblQuestionnaireName
            '
            Me.lblQuestionnaireName.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
            Me.lblQuestionnaireName.ForeColor = System.Drawing.Color.Navy
            Me.lblQuestionnaireName.Location = New System.Drawing.Point(3, 66)
            Me.lblQuestionnaireName.Name = "lblQuestionnaireName"
            Me.lblQuestionnaireName.Size = New System.Drawing.Size(234, 48)
            Me.lblQuestionnaireName.Text = "Questionnaire Name"
            Me.lblQuestionnaireName.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'SectionSplashScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Controls.Add(Me.lblVersion)
            Me.Controls.Add(Me.lblSectionShortName)
            Me.Controls.Add(Me.lblSectionName)
            Me.Controls.Add(Me.lblQuestionnaireName)
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "SectionSplashScreen"
            Me.Text = "SectionSplashScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblVersion As System.Windows.Forms.Label
        Friend WithEvents lblSectionShortName As System.Windows.Forms.Label
        Friend WithEvents lblSectionName As System.Windows.Forms.Label
        Friend WithEvents lblQuestionnaireName As System.Windows.Forms.Label

    End Class

End Namespace
