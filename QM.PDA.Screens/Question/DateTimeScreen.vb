

Namespace Question


    <CanValidateRange()> _
    Public Class DateTimeScreen

#Region " Properties "

        Private _hasValue As Boolean

        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return _hasValue
            End Get
        End Property


        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                If _hasValue Then Return dtpDateTime.Value Else Return Nothing
            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get
                ' Get the user input and the initial value
                Dim inputValue As Object = IIf(_hasValue, dtpDateTime.Value, Nothing)
                Dim initialValue As Object = Screen.GetInitialValue()

                ' Compare it with the original value
                If inputValue Is Nothing And initialValue Is Nothing Then Return False

                If inputValue Is Nothing And initialValue IsNot Nothing Then Return True
                If inputValue IsNot Nothing And initialValue Is Nothing Then Return True

                Return Not inputValue.Equals(initialValue)

            End Get
        End Property

#End Region

#Region " Event Handlers "

        Private Sub DateTimeScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then
                Dim currentValue As Object = Screen.GetInitialValue()

                If currentValue IsNot Nothing Then
                    dtpDateTime.Value = CDate(currentValue)
                    ShowDateTimeControl()
                Else
                    HideDateTimeControl()
                End If
            End If

            dtpDateTime.Format = Windows.Forms.DateTimePickerFormat.Custom
            Dim datePattern As String = Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern
            If datePattern.IndexOf("yyyy") = -1 Then datePattern = datePattern.Replace("yy", "yyyy")

            Dim timePattern As String = Globalization.DateTimeFormatInfo.CurrentInfo.ShortTimePattern

            If Me.Name = "DateScreen" Then
                dtpDateTime.CustomFormat = datePattern
            ElseIf Me.Name = "TimeScreen" Then
                dtpDateTime.CustomFormat = timePattern
            Else
                dtpDateTime.CustomFormat = String.Format("{0} {1}", datePattern, timePattern)
            End If

            dtpDateTime.Focus()
            InputPanel.Enabled = False

        End Sub



        Private Sub pnlAnswerArea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlAnswerArea.Click
            Dim keyPressed As String = GetKeyPressed()
            If Not keyPressed Is Nothing Then OpenNETCF.Windows.Forms.SendKeys.Send(keyPressed)
        End Sub



        Private Sub dtpDateTime_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDateTime.ValueChanged
            ShowDateTimeControl()
        End Sub



        Private Sub dtpDateTime_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDateTime.CloseUp
            ShowDateTimeControl()
        End Sub



        Private Sub pbxClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxClear.Click
            HideDateTimeControl()
        End Sub

#End Region

#Region " Private function "

        Private Sub ShowDateTimeControl()

            _hasValue = True
            pnlDateTime.Hide()

        End Sub



        Private Sub HideDateTimeControl()

            _hasValue = False
            pnlDateTime.Show()

        End Sub



        Private Function GetKeyPressed() As String

            Dim mouseX As Integer = Windows.Forms.Control.MousePosition.X - pnlAnswerArea.Bounds.X
            Dim mouseY As Integer = Windows.Forms.Control.MousePosition.Y - pnlAnswerArea.Bounds.Y

            Select Case True
                Case lblBtn0.Bounds.Contains(mouseX, mouseY) : Return "0"
                Case lblBtn1.Bounds.Contains(mouseX, mouseY) : Return "1"
                Case lblBtn2.Bounds.Contains(mouseX, mouseY) : Return "2"
                Case lblBtn3.Bounds.Contains(mouseX, mouseY) : Return "3"
                Case lblBtn4.Bounds.Contains(mouseX, mouseY) : Return "4"
                Case lblBtn5.Bounds.Contains(mouseX, mouseY) : Return "5"
                Case lblBtn6.Bounds.Contains(mouseX, mouseY) : Return "6"
                Case lblBtn7.Bounds.Contains(mouseX, mouseY) : Return "7"
                Case lblBtn8.Bounds.Contains(mouseX, mouseY) : Return "8"
                Case lblBtn9.Bounds.Contains(mouseX, mouseY) : Return "9"
            End Select

            Return Nothing

        End Function


#End Region

    End Class

End Namespace
