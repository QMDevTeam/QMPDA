Imports QM.PDA.BO.Context


Public Class ReportList

#Region " Properties "

    Private _reportsLoaded As Boolean
    Private _subjectSelected As Boolean

#End Region

#Region " Event Handlers "

    Private Sub Subject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If CurrentStudy IsNot Nothing Then

            _reportsLoaded = False
            lstbReports.DataSource = CurrentStudy.Reports(CurrentSite.Code)
            lstbReports.SelectedIndex = -1
            _reportsLoaded = True

            btnNext.Enabled = False
            _subjectSelected = False

            Me.mnuChangeSubject.Enabled = True

        End If

    End Sub



    Private Sub lstbReports_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstbReports.SelectedIndexChanged

        If _reportsLoaded AndAlso lstbReports.SelectedIndex >= 0 Then

            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()

            Dim report As BO.Report = CType(lstbReports.SelectedItem, BO.Report)
            Dim reportForm As Form

            If String.IsNullOrEmpty(report.FormTypeName) Then
                reportForm = New Screens.Reports.SimpleReport()
            Else
                reportForm = CType(Activator.CreateInstance(Type.GetType(report.FormTypeName, True)), Form)
            End If

            Cursor.Current = Cursors.Default

            CurrentReport = report
            If reportForm.ShowDialog() = Windows.Forms.DialogResult.Abort Then Me.Close()
            CurrentReport = Nothing

        End If

    End Sub

#End Region

End Class
