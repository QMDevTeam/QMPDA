

Namespace Question


    Public Class TextBoxScreen

#Region " Properties "

        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return txtAnswer.Text.Length > 0
            End Get
        End Property


        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                If String.IsNullOrEmpty(txtAnswer.Text.Trim) Then
                    Return Nothing
                Else
                    Return txtAnswer.Text.Trim
                End If
            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get
                Return Not txtAnswer.Text.Equals(Screen.GetInitialValue())
            End Get
        End Property

#End Region

#Region " Event Handlers "

        Private Sub TextBoxScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then

                txtAnswer.Text = CStr(Screen.GetInitialValue())
                'InputPanel.Enabled = True

            End If

            txtAnswer.Focus()

        End Sub



        Private Sub TextBoxScreen_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
            Me.InputPanel.Enabled = False
        End Sub



        Private Sub txtAnswer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAnswer.GotFocus
            Me.InputPanel.Enabled = True
        End Sub

#End Region

    End Class

End Namespace
