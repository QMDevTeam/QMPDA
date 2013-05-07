Imports System.Windows.Forms


Namespace Question


    Public Class RadioButtonsScreen

#Region " Properties "

        Private Const _radioButtonSeparation As Integer = 10
        Private Const _radioButtonHeight As Integer = 26
        Private Const _radioButtonWidth As Integer = 20
        Private Const _radioButtonLabelWidth As Integer = 184
        Private _radioButtonFont As Drawing.Font = New Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Regular)


        Private _selectedValue As Nullable(Of Integer)
        Private _radioButtons As New List(Of RadioButton)



        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return _selectedValue.HasValue
            End Get
        End Property


        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                If _selectedValue.HasValue Then Return _selectedValue.Value Else Return Nothing
            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get
                Return Not _selectedValue.Equals(Screen.GetInitialValue)
            End Get
        End Property

#End Region

#Region " Event Handlers "

        Private Sub RadioButtonsScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then

                Dim radioButton As RadioButton
                Dim radioButtonLabel As Controls.Label2
                Dim yPosition As Integer = 0
                Dim initialValue As Nullable(Of Integer) = CType(Screen.GetInitialValue(), Nullable(Of Integer))


                ' For each item in the Lookup Table, create a Radio Button
                Dim items As DataTable = Screen.GetLegalValueTableItems()
                If items IsNot Nothing Then
                    For Each row As DataRow In items.Rows
                        '
                        ' radioButton.
                        '
                        radioButton = New RadioButton
                        radioButton.Tag = CInt(row("Value"))
                        radioButton.Font = _radioButtonFont
                        radioButton.Top = yPosition
                        radioButton.Left = 0
                        radioButton.Width = _radioButtonWidth
                        radioButton.Height = _radioButtonHeight
                        AddHandler radioButton.Click, AddressOf RadioButton_Click
                        '
                        ' radioButtonLabel.
                        '
                        radioButtonLabel = New Controls.Label2
                        radioButtonLabel.Text = CStr(row("Text"))
                        radioButtonLabel.Tag = radioButton
                        radioButtonLabel.Font = _radioButtonFont
                        radioButtonLabel.Top = yPosition + 4
                        radioButtonLabel.Left = _radioButtonWidth
                        radioButtonLabel.Width = _radioButtonLabelWidth
                        radioButtonLabel.ResizeToFit()
                        AddHandler radioButtonLabel.Click, AddressOf RadioButtonLabel_Click

                        If initialValue.Equals(radioButton.Tag) Then
                            radioButton.Checked = True
                            _selectedValue = initialValue
                        End If

                        pnlAnswerArea.Controls.Add(radioButtonLabel)
                        pnlAnswerArea.Controls.Add(radioButton)
                        _radioButtons.Add(radioButton)
                        yPosition += _radioButtonSeparation + radioButtonLabel.Height
                    Next
                End If

            End If


            InputPanel.Enabled = False

        End Sub



        Private Sub RadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            If _selectedValue.HasValue AndAlso _selectedValue.Value = CInt(CType(sender, RadioButton).Tag) Then
                _selectedValue = Nothing
                CType(sender, RadioButton).Checked = False
                Me.Focus()
            Else
                _selectedValue = CInt(CType(sender, RadioButton).Tag)
                Me.Focus()
            End If

        End Sub



        Private Sub RadioButtonLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim radioButton As RadioButton = CType(CType(sender, Controls.Label2).Tag, RadioButton)

            If radioButton IsNot Nothing Then
                radioButton.Checked = True
                RadioButton_Click(radioButton, e)
            End If

        End Sub


#End Region

    End Class

End Namespace
