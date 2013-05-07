Imports QM.PDA.BO.Context
Imports System.Windows.Forms


Namespace Question


    Public Class CheckBoxScreen

#Region " Properties "

        Private Const _checkBoxSeparation As Integer = 10
        Private Const _checkBoxHeight As Integer = 20
        Private Const _checkBoxWidth As Integer = 20
        Private Const _checkBoxLabelWidth As Integer = 184
        Private _checkBoxFont As Drawing.Font = New Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Regular)


        Private _checkBoxes As New List(Of CheckBox)
        Private _originalCode As String = ""



        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get

                ' Go through the CheckBox list, if any is checked, the screen has a value.
                For Each checkBox As CheckBox In _checkBoxes
                    If checkBox.Checked Then Return True
                Next

                ' If none of the CheckBoxes are checked, then the screen doesn't have a value.
                Return False

            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get

                ' Build the code for the current status of the CheckBoxes
                Dim inputCode As String = ""
                For Each checkBox As CheckBox In _checkBoxes
                    inputCode &= CStr(IIf(checkBox.Checked, "1", "0"))
                Next

                ' Compare the codes
                Return Not _originalCode.Equals(inputCode)

            End Get
        End Property

#End Region

#Region " Event Handlers "

        Private Sub CheckBoxScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


            If Screen IsNot Nothing Then

                Dim checkBox As CheckBox
                Dim checkBoxLabel As Controls.Label2
                Dim yPosition As Integer = 0

                ' For each value in the Lookup Table, create a CheckBox
                Dim items As DataTable = Screen.GetLegalValueTableItems()
                If items IsNot Nothing Then
                    For Each value As DataRow In items.Rows

                        '
                        ' checkBox
                        '
                        checkBox = New CheckBox
                        checkBox.Tag = CStr(value("ShortName"))
                        checkBox.Top = yPosition
                        checkBox.Left = 0
                        checkBox.Width = _checkBoxWidth
                        checkBox.Height = _checkBoxHeight
                        checkBox.Checked = CBool(Screen.GetInitialValue(Screen.VariableName + CStr(checkBox.Tag)))
                        _originalCode &= CStr(IIf(checkBox.Checked, "1", "0"))
                        '
                        ' checkBoxLabel
                        '
                        checkBoxLabel = New Controls.Label2
                        checkBoxLabel.Text = CStr(value("Text"))
                        checkBoxLabel.Tag = checkBox
                        checkBoxLabel.Font = _checkBoxFont
                        checkBoxLabel.Top = yPosition + 1
                        checkBoxLabel.Left = _checkBoxWidth
                        checkBoxLabel.Width = _checkBoxLabelWidth
                        checkBoxLabel.ResizeToFit()
                        AddHandler checkBoxLabel.Click, AddressOf CheckBoxLabel_Click

                        _checkBoxes.Add(checkBox)
                        pnlAnswerArea.Controls.Add(checkBoxLabel)
                        pnlAnswerArea.Controls.Add(checkBox)
                        yPosition += _checkBoxSeparation + checkBoxLabel.Height
                    Next
                End If

            End If


            InputPanel.Enabled = False

        End Sub

        Private Sub CheckBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim checkBox As CheckBox = CType(CType(sender, Controls.Label2).Tag, CheckBox)

            If checkBox IsNot Nothing Then
                checkBox.Checked = Not checkBox.Checked
            End If

        End Sub


#End Region

#Region " Protected Methods "

        Protected Overrides Sub StoreValue()

            For Each checkBox As CheckBox In _checkBoxes
                Screen.StoreValue(Screen.VariableName + CStr(checkBox.Tag), checkBox.Checked)
            Next

        End Sub

#End Region

    End Class

End Namespace
