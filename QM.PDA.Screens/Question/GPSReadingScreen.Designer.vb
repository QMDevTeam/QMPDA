

Namespace Question

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GPSReadingScreen
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GPSReadingScreen))
            Me.pnlInfo = New System.Windows.Forms.Panel
            Me.lblLatitude = New System.Windows.Forms.Label
            Me.lblLongitude = New System.Windows.Forms.Label
            Me.lblPDOP = New System.Windows.Forms.Label
            Me.lblHDOP = New System.Windows.Forms.Label
            Me.lblSatallites = New System.Windows.Forms.Label
            Me.lblLatitudeValue = New System.Windows.Forms.Label
            Me.lblLongitudeValue = New System.Windows.Forms.Label
            Me.lblPDOPValue = New System.Windows.Forms.Label
            Me.lblHDOPValue = New System.Windows.Forms.Label
            Me.lblSatallitesValue = New System.Windows.Forms.Label
            Me.lblStatus = New System.Windows.Forms.Label
            Me.btnTakeReading = New System.Windows.Forms.Button
            Me.pnlAnswerArea.SuspendLayout()
            Me.pnlInfo.SuspendLayout()
            Me.SuspendLayout()
            '
            'pnlAnswerArea
            '
            resources.ApplyResources(Me.pnlAnswerArea, "pnlAnswerArea")
            Me.pnlAnswerArea.Controls.Add(Me.pnlInfo)
            Me.pnlAnswerArea.Controls.Add(Me.lblStatus)
            Me.pnlAnswerArea.Controls.Add(Me.btnTakeReading)
            '
            'btnHelp
            '
            resources.ApplyResources(Me.btnHelp, "btnHelp")
            '
            'btnNext
            '
            resources.ApplyResources(Me.btnNext, "btnNext")
            '
            'btnBack
            '
            resources.ApplyResources(Me.btnBack, "btnBack")
            '
            'mnuGPS
            '
            resources.ApplyResources(Me.mnuGPS, "mnuGPS")
            '
            'mnuTools
            '
            resources.ApplyResources(Me.mnuTools, "mnuTools")
            '
            'mnuToolsSeparator
            '
            resources.ApplyResources(Me.mnuToolsSeparator, "mnuToolsSeparator")
            '
            'mnuChangeSubject
            '
            resources.ApplyResources(Me.mnuChangeSubject, "mnuChangeSubject")
            '
            'mnuChangeQuestionnaire
            '
            resources.ApplyResources(Me.mnuChangeQuestionnaire, "mnuChangeQuestionnaire")
            '
            'mnuChangeStudy
            '
            resources.ApplyResources(Me.mnuChangeStudy, "mnuChangeStudy")
            '
            'mnuChangeBlockSeparator
            '
            resources.ApplyResources(Me.mnuChangeBlockSeparator, "mnuChangeBlockSeparator")
            '
            'mnuLogout
            '
            resources.ApplyResources(Me.mnuLogout, "mnuLogout")
            '
            'pnlInfo
            '
            resources.ApplyResources(Me.pnlInfo, "pnlInfo")
            Me.pnlInfo.Controls.Add(Me.lblLatitude)
            Me.pnlInfo.Controls.Add(Me.lblLongitude)
            Me.pnlInfo.Controls.Add(Me.lblPDOP)
            Me.pnlInfo.Controls.Add(Me.lblHDOP)
            Me.pnlInfo.Controls.Add(Me.lblSatallites)
            Me.pnlInfo.Controls.Add(Me.lblLatitudeValue)
            Me.pnlInfo.Controls.Add(Me.lblLongitudeValue)
            Me.pnlInfo.Controls.Add(Me.lblPDOPValue)
            Me.pnlInfo.Controls.Add(Me.lblHDOPValue)
            Me.pnlInfo.Controls.Add(Me.lblSatallitesValue)
            Me.pnlInfo.Name = "pnlInfo"
            '
            'lblLatitude
            '
            resources.ApplyResources(Me.lblLatitude, "lblLatitude")
            Me.lblLatitude.Name = "lblLatitude"
            '
            'lblLongitude
            '
            resources.ApplyResources(Me.lblLongitude, "lblLongitude")
            Me.lblLongitude.Name = "lblLongitude"
            '
            'lblPDOP
            '
            resources.ApplyResources(Me.lblPDOP, "lblPDOP")
            Me.lblPDOP.Name = "lblPDOP"
            '
            'lblHDOP
            '
            resources.ApplyResources(Me.lblHDOP, "lblHDOP")
            Me.lblHDOP.Name = "lblHDOP"
            '
            'lblSatallites
            '
            resources.ApplyResources(Me.lblSatallites, "lblSatallites")
            Me.lblSatallites.Name = "lblSatallites"
            '
            'lblLatitudeValue
            '
            resources.ApplyResources(Me.lblLatitudeValue, "lblLatitudeValue")
            Me.lblLatitudeValue.Name = "lblLatitudeValue"
            '
            'lblLongitudeValue
            '
            resources.ApplyResources(Me.lblLongitudeValue, "lblLongitudeValue")
            Me.lblLongitudeValue.Name = "lblLongitudeValue"
            '
            'lblPDOPValue
            '
            resources.ApplyResources(Me.lblPDOPValue, "lblPDOPValue")
            Me.lblPDOPValue.Name = "lblPDOPValue"
            '
            'lblHDOPValue
            '
            resources.ApplyResources(Me.lblHDOPValue, "lblHDOPValue")
            Me.lblHDOPValue.Name = "lblHDOPValue"
            '
            'lblSatallitesValue
            '
            resources.ApplyResources(Me.lblSatallitesValue, "lblSatallitesValue")
            Me.lblSatallitesValue.Name = "lblSatallitesValue"
            '
            'lblStatus
            '
            resources.ApplyResources(Me.lblStatus, "lblStatus")
            Me.lblStatus.ForeColor = System.Drawing.Color.Red
            Me.lblStatus.Name = "lblStatus"
            '
            'btnTakeReading
            '
            resources.ApplyResources(Me.btnTakeReading, "btnTakeReading")
            Me.btnTakeReading.Name = "btnTakeReading"
            '
            'GPSReadingScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            resources.ApplyResources(Me, "$this")
            Me.Name = "GPSReadingScreen"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlAnswerArea.ResumeLayout(False)
            Me.pnlInfo.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pnlInfo As System.Windows.Forms.Panel
        Friend WithEvents lblLatitude As System.Windows.Forms.Label
        Friend WithEvents lblLongitude As System.Windows.Forms.Label
        Friend WithEvents lblPDOP As System.Windows.Forms.Label
        Friend WithEvents lblHDOP As System.Windows.Forms.Label
        Friend WithEvents lblSatallites As System.Windows.Forms.Label
        Friend WithEvents lblLatitudeValue As System.Windows.Forms.Label
        Friend WithEvents lblLongitudeValue As System.Windows.Forms.Label
        Friend WithEvents lblPDOPValue As System.Windows.Forms.Label
        Friend WithEvents lblHDOPValue As System.Windows.Forms.Label
        Friend WithEvents lblSatallitesValue As System.Windows.Forms.Label
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents btnTakeReading As System.Windows.Forms.Button

    End Class

End Namespace