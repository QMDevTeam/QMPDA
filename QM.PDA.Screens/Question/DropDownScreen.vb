Imports QM.PDA.BO.Context


Namespace Question


    Public Class DropDownScreen

#Region " Properties "

        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return cmbSelector.SelectedIndex > 0
            End Get
        End Property


        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                If cmbSelector.SelectedIndex = 0 Then Return Nothing
                Return CType(cmbSelector.SelectedItem, Item).Value
            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get
                Return Not CType(cmbSelector.SelectedItem, Item).Value.Equals(Screen.GetInitialValue)
            End Get
        End Property

#End Region

#Region " Event Handlers "

        Private Sub DropDownScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then

                cmbSelector.Items.Add(New Item("", -1)) ' Add first the "empty" item and select it.
                cmbSelector.SelectedIndex = 0

                Dim index As Integer
                Dim value As Integer

                ' This is the original line of code but for some unknown reason, when the Scree.GetInitialValue()
                ' function returns a String with an Integer value, there is an InvalidCastException.
                'Dim initialValue As Nullable(Of Integer) = CType(Screen.GetInitialValue(), Nullable(Of Integer))

                Dim initialValue As Nullable(Of Integer)
                If Screen.GetInitialValue() Is Nothing Then
                    initialValue = Nothing
                Else
                    initialValue = CInt(Screen.GetInitialValue())
                End If


                ' For each item in the Lookup Table, add an Item to the DropDownList
                Dim items As DataTable = Screen.GetLegalValueTableItems()
                If items IsNot Nothing Then
                    Dim row As DataRow
                    For idx As Integer = 0 To items.Rows.Count - 1
                        row = items.Rows(idx)
                        value = CInt(row("Value"))
                        index = cmbSelector.Items.Add(New Item(CStr(row("Text")), value))
                        If initialValue.Equals(value) Then cmbSelector.SelectedIndex = index
                    Next
                End If
                items.Dispose()

            End If


            InputPanel.Enabled = False

        End Sub

#End Region

#Region " Sub Classes "

        Public Class Item

            Private _text As String
            Private _value As Integer



            Public ReadOnly Property Text() As String
                Get
                    Return _text
                End Get
            End Property


            Public ReadOnly Property Value() As Integer
                Get
                    Return _value
                End Get
            End Property



            Public Sub New(ByVal Text As String, ByVal Value As Integer)
                _text = Text
                _value = Value
            End Sub

        End Class

#End Region

    End Class

End Namespace
