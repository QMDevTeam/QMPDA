Imports System.Windows.Forms


Namespace Question


    Public Class NameScreen

#Region " Properties "

        Private _misconfigurationErrorMsg As String

        Private _names As New List(Of String)
        Private _textBoxWithFocus As TextBox



        Protected Overrides ReadOnly Property HasValue() As Boolean
            Get
                Return Not String.IsNullOrEmpty(txtName.Text.Trim & txtSecondName.Text.Trim)
            End Get
        End Property


        Protected Overrides ReadOnly Property InputValue() As System.IComparable
            Get
                Return String.Concat(txtName.Text.Trim, ",", txtSecondName.Text.Trim).Trim(","c).ToUpper
            End Get
        End Property


        Protected Overrides ReadOnly Property OriginalValueChanged() As Boolean
            Get

                Dim initialValue As String = CStr(Screen.GetInitialValue)
                If initialValue IsNot Nothing Then initialValue = initialValue.ToUpper

                Return Not CStr(InputValue).Equals(initialValue)

            End Get
        End Property

#End Region

#Region " Event Handlers "

        Private Sub NameScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then

                ' Verify the screen configuration
                If Not VerifyScreenConfiguration() Then Throw New ApplicationException(_misconfigurationErrorMsg)


                ' Load the list of names
                For Each row As DataRow In Screen.GetLegalValueTableItems.Rows
                    _names.Add(CStr(row("Text")))
                Next
                _names.Sort()


                ' Load current value
                Dim currentValue As String = CStr(Screen.GetInitialValue())
                If Not String.IsNullOrEmpty(currentValue) Then

                    Dim currentValueComponents() As String = currentValue.Split(","c)
                    txtName.Text = currentValueComponents(0)
                    If currentValueComponents.Length > 1 Then txtSecondName.Text = currentValueComponents(1)

                End If


                'InputPanel.Enabled = True

            End If


            Me.Controls.SetChildIndex(lstbNames, 0) ' Put the Names list in front of all the controls.
            lstbNames.Hide()
            txtName.Focus()

        End Sub



        Private Sub NameScreen_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
            Me.InputPanel.Enabled = False
        End Sub



        Private Sub lbNames_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstbNames.SelectedValueChanged
            _textBoxWithFocus.Text = lstbNames.SelectedItem.ToString
            lstbNames.Hide()
            _textBoxWithFocus.Focus()
        End Sub



        Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged, txtSecondName.TextChanged
            _textBoxWithFocus = CType(sender, TextBox)
            Autocomplete(_textBoxWithFocus)
        End Sub



        Private Sub TextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.GotFocus, txtSecondName.GotFocus
            Me.InputPanel.Enabled = True
        End Sub

#End Region

#Region " Public Methods "

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager("QM.PDA.Screens.Resources", Me.GetType.Assembly)
            Me._misconfigurationErrorMsg = resources.GetString("name_misconfigurationErrorMsg")

        End Sub

#End Region

#Region " Protected Methods "

        Protected Overrides Sub StoreValue()

            MyBase.StoreValue()

            If Not String.IsNullOrEmpty(txtName.Text.Trim) AndAlso Not _names.Contains(txtName.Text.Trim.ToUpper) Then
                Screen.InsertLegalValueTableItem(Screen.LegalValueTable, 0, 0, txtName.Text.Trim.ToUpper)
                _names.Add(txtName.Text.Trim.ToUpper)
            End If

            If Not String.IsNullOrEmpty(txtSecondName.Text.Trim) AndAlso Not _names.Contains(txtSecondName.Text.Trim.ToUpper) Then
                Screen.InsertLegalValueTableItem(Screen.LegalValueTable, 0, 0, txtSecondName.Text.Trim.ToUpper)
                _names.Add(txtSecondName.Text.Trim.ToUpper)
            End If

        End Sub

#End Region

#Region " Private Methods "

        ''' <summary>
        ''' This screen requires a specific configuration. This
        ''' function verifies if that configurarion is ok.
        ''' </summary>
        ''' <returns><c>True</c> if the confituration is complete, <c>False</c> otherwise.</returns>

        Private Function VerifyScreenConfiguration() As Boolean

            Return Not Screen.LegalValueTable Is Nothing

        End Function



        ''' <summary>
        ''' Fills a ListBox with all the posible names, based on the text typed in the TextBox.
        ''' </summary>
        ''' <param name="targetTextBox">The TextBox where the autocomplete is going to act.</param>

        Private Sub Autocomplete(ByRef targetTextBox As Windows.Forms.TextBox)

            ' Clear and place the list with the names.
            lstbNames.Items.Clear()
            lstbNames.Location = New System.Drawing.Point(targetTextBox.Left + pnlAnswerArea.Left, targetTextBox.Top + pnlAnswerArea.Top - lstbNames.Height + 1)



            ' If nothing has been typed, add all the names to the list
            If targetTextBox.Text = "" Then
                For Each name As String In _names
                    lstbNames.Items.Add(name)
                Next

            Else ' Else, add only the names that starts with the typed string.
                For Each name As String In _names
                    If name.ToUpper.StartsWith(targetTextBox.Text.ToUpper.Trim) Then
                        lstbNames.Items.Add(name)
                    End If
                Next
            End If


            ' Show the names list only if contains at least one name.
            lstbNames.Visible = lstbNames.Items.Count > 0
            targetTextBox.Focus()

        End Sub

#End Region

    End Class

End Namespace