Imports QM.PDA.BO.Context
Imports System.Windows.Forms


''' <summary>
''' This is the root template to use as a base class for all the
''' forms in the project. Provides a graphic uniformity for a
''' consistent look and feel of the forms. It contains the Next
''' and Back buttons as well as the Main Menu.
''' </summary>

Public Class BaseForm

#Region " Properties "

    Protected FormResult As FormResult = Screens.FormResult.Skip

#End Region

#Region " Event Handlers "

    Private Sub BaseForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mnuChangeStudy.Enabled = BO.Study.GetAll.Count > 1
        CorrectDateTime.CheckDate()

        ' REMOVE the change questionnaire button from the menu.
        Me.MainContextMenu.MenuItems.Remove(Me.mnuChangeQuestionnaire)
    End Sub



    Private Sub btnMainMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMainMenu.Click
        MainContextMenu.Show(btnMainMenu, New Drawing.Point(0, 0))
    End Sub



    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        If CanGoBack() Then
            GoBack()
            FormResult = FormResult.Back
            Me.Close()
        End If

    End Sub



    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If CanGoNext() Then
            GoNext()
            FormResult = FormResult.Next
            Me.Close()
        End If

    End Sub



    Private Sub mnuGPS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGPS.Click

        Dim gpsScreen As New GPSReading
        gpsScreen.ShowDialog()
        gpsScreen.Dispose()

    End Sub



    Private Sub mnuTimer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTimer.Click

        Dim timerScreen As New TimerScreen
        timerScreen.ShowDialog()
        timerScreen.Dispose()

    End Sub



    Private Sub mnuChangeSubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeSubject.Click

        If CanInterrupt() Then
            Interrupt()
            FormResult = FormResult.ChangeSubject
            Me.Close()
        End If

    End Sub



    Private Sub mnuChangeQuestionnaire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeQuestionnaire.Click

        If CanInterrupt() Then
            Interrupt()
            FormResult = FormResult.ChangeQuestionnaire
            Me.Close()
        End If

    End Sub



    Private Sub mnuChangeStudy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuChangeStudy.Click

        If CanInterrupt() Then
            Interrupt()
            FormResult = FormResult.ChangeStudy
            Me.Close()
        End If

    End Sub



    Private Sub mnuLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogout.Click

        If CanInterrupt() Then
            Interrupt()
            FormResult = FormResult.Logout
            Me.Close()
        End If

    End Sub

#End Region

#Region " Public Methods "

    Public Function ShowForm() As FormResult
        Me.ShowDialog()
        Return FormResult
    End Function

#End Region

#Region " Protected Methods "

    Protected Overridable Function CanGoNext() As Boolean
        Return True
    End Function



    Protected Overridable Function CanGoBack() As Boolean
        Return True
    End Function



    Protected Overridable Function CanInterrupt() As Boolean
        Return True
    End Function



    Protected Overridable Sub GoNext()
    End Sub



    Protected Overridable Sub GoBack()
    End Sub



    Protected Overridable Sub Interrupt()
    End Sub

#End Region

End Class