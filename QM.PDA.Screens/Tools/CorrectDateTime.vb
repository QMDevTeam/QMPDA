Public Class CorrectDateTime

#Region "Properties"

    Private OVERRIDE_NOTE As String
    Private _msbWrongCode As String

    Private gOverrideKeys() As String = {"28A4E", "UX974", "X35E8", "2X8U7", "7A68E", "73XU3", "9A356", "3E24A", "X85U9", "E5U76"}
    Private gSelectedKeyIndex As Integer

    Public Version As String
    Public LastExecutionDateTime As DateTime
    Public OverrideDateTime As Boolean = False
    Public AskForDateTimeChangeConfirmationCode As Boolean


    Private Shared gMaxDateAlertDifferenceDays As Integer = 10
    Private Shared gAskForDateTimeChangeConfirmationCode As Boolean = True
    Private Shared regDate As Nullable(Of DateTime) = Nothing
    Private Shared mut As New Threading.Mutex()

#End Region



#Region "Event handlers"

    Private Sub CorrectDateTime_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        lblCurrentDateTime.Text = Now.ToString()

    End Sub



    Private Sub CorrectDateTime_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        pnlOverride.Hide()
        pnlOverride.BringToFront()
        lblVersion.Text = "v" & Version
        lblLastBackupDateTime.Text = LastExecutionDateTime.ToString("yyyyMMddHHmm")

    End Sub



    Private Sub btnCorrectDateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorrectDateTime.Click

        ' Call the adjust date and time utility
        Process.Start("clock.exe", Nothing).WaitForExit()
        Me.Close()

    End Sub



    Private Sub btnDateTimeOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateTimeOK.Click

        If AskForDateTimeChangeConfirmationCode Then

            ' Select a random key
            Dim lRandom As New Random(Now.Minute + Now.Second + Now.Millisecond)
            gSelectedKeyIndex = lRandom.Next Mod 10

            ' Prompt the user for the random key
            pnlOverride.Show()
            txtOverrideCode.Text = ""
            lblOverrideNote.Text = String.Format(OVERRIDE_NOTE, (gSelectedKeyIndex + 1).ToString)
            txtOverrideCode.Focus()

        Else
            OverrideDateTime = True
            Me.Close()

        End If

    End Sub



    Private Sub btnOverrideContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverrideContinue.Click

        ' If the typed key is OK then hide this dialog,
        ' else show a message to the user and hide the prompt.
        If txtOverrideCode.Text.Trim.ToUpper = gOverrideKeys(gSelectedKeyIndex) Then
            OverrideDateTime = True
            Me.Close()
        Else
            Windows.Forms.MessageBox.Show(Me._msbWrongCode)
            pnlOverride.Hide()
        End If

    End Sub



    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer.Tick

        lblCurrentDateTime.Text = Now.ToString()
        Timer.Enabled = True

    End Sub

#End Region



#Region "Shared Public Methods"

    Public Shared Sub CheckDate()

        ' If regDate is nothing...
        If Not regDate.HasValue Then

            ' Read date from registry.
            Dim dateObject As Object = Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\QM", "DateTime", Nothing)

        End If

        ' Check If the date is correct.
        If regDate.HasValue Then

            regDate = DateTime.ParseExact(regDate.Value.ToString, "yyyyMMddHHmm", Nothing)
            CheckTodayDateTime(regDate.Value, Now)

        End If

        ' Save the new date.
        Threading.ThreadPool.QueueUserWorkItem(New Threading.WaitCallback(AddressOf WriteRegDate), Now)

    End Sub

#End Region



#Region " Public Methods "


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager("QM.PDA.Screens.Resources", Me.GetType.Assembly)
        Me.OVERRIDE_NOTE = resources.GetString("correctDateTime_overrideNote")
        Me._msbWrongCode = resources.GetString("correctDateTime_msbWrongCode")


    End Sub

#End Region


#Region "Shared Private Methods"

    Private Shared Sub CheckTodayDateTime(ByVal pLastExecutionDataTime As DateTime, ByRef pStartDateTime As DateTime)

        ' If the Start date and time is not OK, show the user the
        ' Correct date and time dialog until an acceptable one is set.

        If Not IsPDADateTimeOK(pLastExecutionDataTime, pStartDateTime) Then
            Dim lCorrectDateTime As New CorrectDateTime
            lCorrectDateTime.Version = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
            lCorrectDateTime.LastExecutionDateTime = pLastExecutionDataTime
            lCorrectDateTime.AskForDateTimeChangeConfirmationCode = gAskForDateTimeChangeConfirmationCode
            Do
                lCorrectDateTime.ShowDialog()
                pStartDateTime = Now
            Loop Until IsPDADateTimeOK(pLastExecutionDataTime, pStartDateTime) Or lCorrectDateTime.OverrideDateTime
        End If

    End Sub


    Private Shared Function IsPDADateTimeOK(ByVal pLastExecutionDataTime As DateTime, ByVal pDateTime As DateTime) As Boolean

        ' If the specified date and time is in the past or it's been a while since
        ' the last backup was executed then there is a problem with the PDA's
        ' current date and time.

        Dim lElapsedTime As TimeSpan = pDateTime.Subtract(pLastExecutionDataTime)
        Return lElapsedTime.TotalDays >= 0 And lElapsedTime.TotalDays <= gMaxDateAlertDifferenceDays

    End Function


    Private Shared Sub WriteRegDate(ByVal state As Object)

        mut.WaitOne()
        Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\QM", "DateTime", CType(state, DateTime).ToString("yyyyMMddHHmm"))
        mut.ReleaseMutex()

    End Sub

#End Region

End Class