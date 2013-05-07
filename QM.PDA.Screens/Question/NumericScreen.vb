Imports System.Windows.Forms


Namespace Question


    Public Class NumericScreen

#Region " Properties "

        Private _periodUsed As Boolean = False
        Private _userHasPressAnyButton As Boolean = False



        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return txtAnswer.Text.Length > 0
            End Get
        End Property


        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                Return CType(GetTypedUserInput(), IComparable)
            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get

                ' Get the user input and the initial value
                Dim inputValue As Object = GetTypedUserInput()
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

        Private Sub NumericScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Screen IsNot Nothing Then txtAnswer.Text = CStr(Screen.GetInitialValue())
            InputPanel.Enabled = False
        End Sub



        Private Sub pbxClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxClear.Click
            txtAnswer.Text = ""
            _periodUsed = False
        End Sub



        Private Sub btnNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click

            If Not _userHasPressAnyButton Then
                txtAnswer.Text = ""
                _userHasPressAnyButton = True
            End If

            txtAnswer.Text &= CType(sender, Button).Text

        End Sub



        Private Sub btnPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPeriod.Click

            If Not _periodUsed Then
                If String.IsNullOrEmpty(txtAnswer.Text) Then txtAnswer.Text = "0." Else txtAnswer.Text &= "."
                _periodUsed = True
            End If

        End Sub



        Private Sub btnPlusMinus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlusMinus.Click

            If txtAnswer.Text.StartsWith("-") Then
                txtAnswer.Text = txtAnswer.Text.Replace("-", "")
            Else
                txtAnswer.Text = "-" & txtAnswer.Text
            End If

        End Sub

#End Region

#Region " Protected Methods "

        Protected Overrides Sub ValidationFailed()
            _userHasPressAnyButton = False
        End Sub



        ''' <summary>
        ''' Returns the input from the user in an object of the same
        ''' type than the initial value, if there is an initial value.
        ''' </summary>
        ''' <remarks>
        ''' To keep the same source type is important because the comparison
        ''' between two objects of different numeric types is not supported
        ''' so the input from the user must be stored in the same type than
        ''' it was first stored. This way it can be determined if the initial
        ''' value has changed.
        ''' </remarks>
        ''' <returns>A variable of the same type of the initial value. If there
        ''' isn't an initial value then returns a variable of type <c>Decimal</c>.
        ''' If there isn't a user input then returns <c>Nothing</c>.</returns>

        Protected Function GetTypedUserInput() As Object

            Dim initialValue As Object = Screen.GetInitialValue()

            ' If there is an initial value.
            If Not initialValue Is Nothing Then

                If txtAnswer.Text.Trim.Length > 0 Then
                    Dim t As Type = initialValue.GetType
                    Select Case True
                        Case t Is GetType(Byte) : Return Byte.Parse(txtAnswer.Text)
                        Case t Is GetType(Int16) : Return Int16.Parse(txtAnswer.Text)
                        Case t Is GetType(Int32) : Return Int32.Parse(txtAnswer.Text)
                        Case t Is GetType(Int64) : Return Int64.Parse(txtAnswer.Text)
                        Case t Is GetType(Single) : Return Single.Parse(txtAnswer.Text)
                        Case t Is GetType(Double) : Return Double.Parse(txtAnswer.Text)
                        Case Else : Return Decimal.Parse(txtAnswer.Text)
                    End Select
                Else
                    Return Nothing
                End If

            Else ' If there is no initial value then use Decimal

                If txtAnswer.Text.Trim.Length > 0 Then Return Decimal.Parse(txtAnswer.Text) Else Return Nothing

            End If

        End Function

#End Region

    End Class

End Namespace