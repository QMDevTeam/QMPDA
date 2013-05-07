

Namespace Question


    Public Class GridScreen

#Region " Properties "

        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return True
            End Get
        End Property


        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                Return Nothing
            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get
                Return False
            End Get
        End Property

#End Region

#Region " Event Handlers "

        Private Sub GridScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then

                uxGrid.DataSource = DA.Data.ExecuteQuery(Common.VariablesParse(BO.Context.CurrentScreen.ArgumentsString))

            End If

            InputPanel.Enabled = False

        End Sub

#End Region

    End Class

End Namespace
