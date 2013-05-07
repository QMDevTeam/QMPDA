Imports System.Drawing


Namespace Info

    Public Class SimpleInfoScreen

#Region " Event Handlers "

        Private Sub SimpleInfoScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then

                ' Parse the string.
                lblMessage.Text = Common.VariablesParse(Screen.MainText)

                ' Resize the label to fit the text of the info screen.
                Dim fontEx As New OpenNETCF.Drawing.FontEx(lblMessage.Font.Name, lblMessage.Font.Size, lblMessage.Font.Style)
                Dim graphicsEX As OpenNETCF.Drawing.GraphicsEx = OpenNETCF.Drawing.GraphicsEx.FromControl(Me)
                lblMessage.Height = CInt(graphicsEX.MeasureString(lblMessage.Text, fontEx, lblMessage.Width).Height)

                If Not String.IsNullOrEmpty(Screen.MainTextColor) Then
                    lblMessage.ForeColor = GetColor(Screen.MainTextColor)
                End If

                Screen.ExecuteOnLoadProcedure()

            End If

        End Sub



        Private Sub SimpleInfoScreen_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
            If Screen IsNot Nothing Then Screen.ExecuteOnUnloadProcedure()
        End Sub

#End Region

#Region " Private Methods "

        Private Function GetColor(ByVal colorName As String) As Color
            Return CType(GetType(Color).GetProperty(colorName).GetValue(Nothing, Nothing), Color)
        End Function

#End Region

    End Class

End Namespace
