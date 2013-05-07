Imports System.Windows.Forms
Imports System.Drawing


Namespace Question

    Public Class QuestionScreen

#Region " Properties "

        Private _msbRequiredCap As String
        Private _msbRequiredMsg As String

        Private _msbAbsMinCap As String
        Private _msbAbsMinMsg As String
        Private _msbAbsMaxCap As String
        Private _msbAbsMaxMsg As String

        Private _msbPromptUnderCap As String
        Private _msbPromptUnderMsg As String
        Private _msbPromptOverCap As String
        Private _msbPromptOverMsg As String

        Private _msbConfirmCap As String
        Private _msbConfirmChangeMsg As String
        Private _msbConfirmNextMsg As String
        Private _msbConfirmBackMsg As String

        Private _msbInputExceptionCap As String
        Private _msbInputExceptionMsg As String

        Private _msbCustomValidationCap As String

        Private Const labelsBaseHorizontalPosition As Integer = 20
        Private Const labelsBaseVerticalPosition As Integer = 52


        ''' <summary>
        ''' Indicates if the user has specified some input into the screen.
        ''' </summary>
        ''' <returns><c>True</c> if there is input, <c>False</c> otherwise.</returns>
        ''' <remarks>
        ''' Every screen derived from Question has to override this Property since
        ''' it is used to decide if the 'Required' message box should be displayed.
        ''' </remarks>

        Protected Overridable ReadOnly Property HasValue() As Boolean
            Get
                Return True
            End Get
        End Property


        ''' <summary>
        ''' The input from the user.
        ''' </summary>
        ''' <returns>An object that implements <c>IComparable</c> containing the input from the user.</returns>
        ''' <remarks>
        ''' Every screen derived from Question has to override this Property since
        ''' it is used store the input from the user to the data base. If the screen
        ''' is too specialized or includes more than one variable then it has to override
        ''' the StoreValue method instead.
        ''' </remarks>

        Protected Overridable ReadOnly Property InputValue() As IComparable
            Get
                Return Nothing
            End Get
        End Property


        ''' <summary>
        ''' Indicates if the input from the user is different from what was already stored.
        ''' </summary>
        ''' <returns><c>True</c> if the input from the user is different from what was already stored,
        ''' <c>False</c> otherwise.</returns>
        ''' <remarks>
        ''' Every screen derived from Question has to override this Property since
        ''' it is used to decide if the 'Required' message box should be displayed.
        ''' </remarks>

        Protected Overridable ReadOnly Property OriginalValueChanged() As Boolean
            Get
                Return False
            End Get
        End Property

#End Region

#Region " Event Handlers "

        Private Sub QuestionScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            If Screen IsNot Nothing Then

                Dim lblOtherText2 As Label = Nothing
                Dim lblOtherText1 As Label = Nothing
                Dim lblMainText As Label = Nothing
                Dim font As New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)


                If Not String.IsNullOrEmpty(Screen.OtherText2) Then

                    ' Create three labels
                    '------------------------------------------
                    '(baseHorizontalPosition,baseVerticalPosition) [point1] .--------------------------------------------.
                    '                                                       | Segment 1 (segmentsWidth x segment1height) |
                    '                                                       |               3 text lines                 |
                    '                                                       |                OtherText1                  |
                    '                                              [point2] |--------------------------------------------|
                    '                                                       | Segment 2 (segmentsWidth x segment2height) |
                    '                                                       |               3 text lines                 |
                    '                                                       |                OtherText2                  |
                    '                                              [point3] |--------------------------------------------|
                    '                                                       | Segment 3 (segmentsWidth x segment3height) |
                    '                                                       |         2 text lines - MainText            |
                    '                                                       '--------------------------------------------'

                    Dim segment1height As Integer = 42
                    Dim segment2height As Integer = 28
                    Dim segment3height As Integer = 42
                    Dim segmentsWidth As Integer = 220

                    Dim point1 As New Point(labelsBaseHorizontalPosition, labelsBaseVerticalPosition)
                    Dim point2 As New Point(labelsBaseHorizontalPosition, labelsBaseVerticalPosition + segment1height)
                    Dim point3 As New Point(labelsBaseHorizontalPosition, labelsBaseVerticalPosition + segment1height + segment2height)


                    lblOtherText2 = New Label
                    lblOtherText1 = New Label
                    lblMainText = New Label

                    lblOtherText2.Location = point1
                    lblOtherText2.Size = New Size(segmentsWidth, segment1height)
                    lblOtherText2.Font = font
                    lblOtherText2.Text = Common.VariablesParse(Screen.OtherText2)

                    lblOtherText1.Location = point2
                    lblOtherText1.Size = New Size(segmentsWidth, segment2height)
                    lblOtherText1.Font = font
                    lblOtherText1.Text = Common.VariablesParse(Screen.OtherText1)

                    lblMainText.Location = point3
                    lblMainText.Size = New Size(segmentsWidth, segment3height)
                    lblMainText.Font = font
                    lblMainText.Text = Common.VariablesParse(Screen.MainText)

                    Me.Controls.Add(lblOtherText2)
                    Me.Controls.Add(lblOtherText1)
                    Me.Controls.Add(lblMainText)


                ElseIf Not String.IsNullOrEmpty(Screen.OtherText1) Then

                    ' Create two labels
                    '------------------------------------------
                    '(baseHorizontalPosition,baseVerticalPosition) [point1] .--------------------------------------------.
                    '                                                       | Segment 1 (segmentsWidth x segment1height) |
                    '                                                       |               4 text lines                 |
                    '                                                       |                OtherText1                  |
                    '                                                       |                                            |
                    '                                              [point2] |--------------------------------------------|
                    '                                                       | Segment 2 (segmentsWidth x segment2height) |
                    '                                                       |               4 text lines                 |
                    '                                                       |                 MainText                   |
                    '                                                       |                                            |
                    '                                                       '--------------------------------------------'

                    Dim segment1height As Integer = 56
                    Dim segment2height As Integer = 56
                    Dim segmentsWidth As Integer = 220

                    Dim point1 As New Point(labelsBaseHorizontalPosition, labelsBaseVerticalPosition)
                    Dim point2 As New Point(labelsBaseHorizontalPosition, labelsBaseVerticalPosition + segment1height)


                    lblOtherText1 = New Label
                    lblMainText = New Label

                    lblOtherText1.Location = point1
                    lblOtherText1.Size = New Size(segmentsWidth, segment1height)
                    lblOtherText1.Font = font
                    lblOtherText1.Text = Common.VariablesParse(Screen.OtherText1)

                    lblMainText.Location = point2
                    lblMainText.Size = New Size(segmentsWidth, segment2height)
                    lblMainText.Font = font
                    lblMainText.Text = Common.VariablesParse(Screen.MainText)

                    Me.Controls.Add(lblOtherText1)
                    Me.Controls.Add(lblMainText)


                Else

                    ' Create one label
                    '------------------------------------------
                    '(baseHorizontalPosition,baseVerticalPosition) [point1] .--------------------------------------------.
                    '                                                       | Segment 1 (segmentsWidth x segment1height) |
                    '                                                       |               8 text lines                 |
                    '                                                       |                 MainText                   |
                    '                                                       |                                            |
                    '                                                       |                                            |
                    '                                                       |                                            |
                    '                                                       |                                            |
                    '                                                       |                                            |
                    '                                                       '--------------------------------------------'

                    Dim segment1height As Integer = 112
                    Dim segmentsWidth As Integer = 220

                    Dim point1 As New Point(labelsBaseHorizontalPosition, labelsBaseVerticalPosition)


                    lblMainText = New Label

                    lblMainText.Location = point1
                    lblMainText.Size = New Size(segmentsWidth, segment1height)
                    lblMainText.Font = font
                    lblMainText.Text = Common.VariablesParse(Screen.MainText)

                    Me.Controls.Add(lblMainText)

                End If



                If Not String.IsNullOrEmpty(Screen.OtherText2Color) Then _
                    lblOtherText2.ForeColor = GetColor(Screen.OtherText2Color)


                If Not String.IsNullOrEmpty(Screen.OtherText1Color) Then _
                    lblOtherText1.ForeColor = GetColor(Screen.OtherText1Color)


                If Not String.IsNullOrEmpty(Screen.MainTextColor) Then
                    lblMainText.ForeColor = GetColor(Screen.MainTextColor)
                Else
                    If Screen.Required.GetValueOrDefault(False) Then
                        lblMainText.ForeColor = Drawing.Color.Red
                    Else
                        lblMainText.ForeColor = Drawing.Color.Black
                    End If
                End If



                ' If there is no Help Text for this Screen, then disable the Help Text button.
                If String.IsNullOrEmpty(Screen.HelpText) Then
                    btnHelp.Enabled = False
                    btnHelp.BackColor = System.Drawing.Color.LightGray
                End If


                Screen.ExecuteOnLoadProcedure()

            End If

        End Sub



        Private Sub QuestionScreen_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
            If Screen IsNot Nothing Then Screen.ExecuteOnUnloadProcedure()
        End Sub



        Private Sub btnHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHelp.Click
            If Not String.IsNullOrEmpty(Screen.HelpText) Then MessageBox.Show(Screen.HelpText)
        End Sub

#End Region

#Region " Public Methods "

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager("QM.PDA.Screens.Resources", Me.GetType.Assembly)
            Me._msbRequiredCap = resources.GetString("question_msbRequiredCap")
            Me._msbRequiredMsg = resources.GetString("question_msbRequiredMsg")

            Me._msbAbsMinCap = resources.GetString("question_msbAbsMinCap")
            Me._msbAbsMinMsg = resources.GetString("question_msbAbsMinMsg")
            Me._msbAbsMaxCap = resources.GetString("question_msbAbsMaxCap")
            Me._msbAbsMaxMsg = resources.GetString("question_msbAbsMaxMsg")

            Me._msbPromptUnderCap = resources.GetString("question_msbPromptUnderCap")
            Me._msbPromptUnderMsg = resources.GetString("question_msbPromptUnderMsg")
            Me._msbPromptOverCap = resources.GetString("question_msbPromptOverCap")
            Me._msbPromptOverMsg = resources.GetString("question_msbPromptOverMsg")

            Me._msbConfirmCap = resources.GetString("question_msbConfirmCap")
            Me._msbConfirmChangeMsg = resources.GetString("question_msbConfirmChangeMsg")
            Me._msbConfirmNextMsg = resources.GetString("question_msbConfirmNextMsg")
            Me._msbConfirmBackMsg = resources.GetString("question_msbConfirmBackMsg")

            Me._msbInputExceptionCap = resources.GetString("question_msbInputExceptionCap")
            Me._msbInputExceptionMsg = resources.GetString("question_msbInputExceptionMsg")

            Me._msbCustomValidationCap = resources.GetString("question_msbCustomValidationCap")

        End Sub

#End Region

#Region " Protected Methods "

        ''' <summary>
        ''' Indicates if the conditions to go to the previous screen are fulfilled.
        ''' </summary>
        ''' <returns><c>True</c> if the conditions are fulfilled,<c>Flase</c> otherwise.</returns>

        Protected Overrides Function CanGoBack() As Boolean

            ' If the user input is not valid, then the screen can't go back.
            If Not Validate(False) Then Return False

            ' If a user confirmation is needed, let the user decide
            If Screen.ConfirmBack.GetValueOrDefault(False) Then
                Return ShowConfirmBackMessage()
            End If

            ' If everithing is ok to this point, the screen can go back.
            Return True

        End Function



        ''' <summary>
        ''' Indicates if the conditions to go to the next screen are fulfilled.
        ''' </summary>
        ''' <returns><c>True</c> if the conditions are fulfilled,<c>Flase</c> otherwise.</returns>

        Protected Overrides Function CanGoNext() As Boolean

            ' If the user input is not valid, then the screen can't go forward.
            If Not Validate(True) Then Return False

            ' If a user confirmation is needed, let the user decide
            If Screen.ConfirmNext.GetValueOrDefault(False) Then
                Return ShowConfirmNextMessage()
            End If

            ' If everithing is ok to this point, the screen can go forward.
            Return True

        End Function



        ''' <summary>
        ''' Indicates if the conditions to interrupt the screen secuence are fulfilled.
        ''' </summary>
        ''' <returns><c>True</c> if the conditions are fulfilled,<c>Flase</c> otherwise.</returns>

        Protected Overrides Function CanInterrupt() As Boolean

            ' If the user input is not valid, then the screen can't allow to interrupt the secuence.
            If Not Validate(False) Then Return False

            ' If everithing is ok to this point, the screen can allow to interrupt the secuence.
            Return True

        End Function



        ''' <summary>
        ''' Performs the actions needed when the screen goes back.
        ''' </summary>

        Protected Overrides Sub GoBack()

            ' If the original value has changed, execute the On Change Procedure after storing the value.
            Dim tempOriginalValueChanged As Boolean = OriginalValueChanged

            ' Store the value in the database
            StoreValue()

            If tempOriginalValueChanged Then Screen.ExecuteOnChangeProcedure()

        End Sub



        ''' <summary>
        ''' Performs the actions needed when the screen goes next.
        ''' </summary>

        Protected Overrides Sub GoNext()

            ' If the original value has changed, execute the On Change Procedure after storing the value.
            Dim tempOriginalValueChanged As Boolean = OriginalValueChanged

            ' Store the value in the database
            StoreValue()

            If tempOriginalValueChanged Then Screen.ExecuteOnChangeProcedure()

        End Sub



        ''' <summary>
        ''' Performs the actions needed when the user wants to interrupt the screen secuence.
        ''' </summary>

        Protected Overrides Sub Interrupt()

            ' If the original value has changed, execute the On Change Procedure after storing the value.
            Dim tempOriginalValueChanged As Boolean = OriginalValueChanged

            ' Store the value in the database
            StoreValue()

            If tempOriginalValueChanged Then Screen.ExecuteOnChangeProcedure()

        End Sub



        ''' <summary>
        ''' Stores the user input in the data base.
        ''' </summary>
        ''' <remarks>
        ''' This method can be overridden to do screen specific actions or transformations 
        ''' for storing the inpunt.
        ''' </remarks>

        Protected Overridable Sub StoreValue()
            Screen.StoreValue(InputValue)
        End Sub



        ''' <summary>
        ''' Validates the user input.
        ''' </summary>
        ''' <remarks>
        ''' This method can be overridden to do screen specific validations.
        ''' </remarks>

        Protected Overridable Function ValidateInput() As Boolean
            Return True
        End Function



        ''' <summary>
        ''' Invoked when the Validate function fails at any point.
        ''' </summary>
        ''' <remarks>
        ''' This method can be overridden to perform screen specific actions when the validation fails.
        ''' </remarks>

        Protected Overridable Sub ValidationFailed()
        End Sub

#End Region

#Region " Private Methods "

        ''' <summary>
        ''' Shows the 'Input Exception' message
        ''' </summary>
        ''' <param name="message">A message to override the default message.</param>

        Private Sub ShowInputExceptionMessage(Optional ByVal message As String = Nothing)

            If String.IsNullOrEmpty(message) Then
                MessageBox.Show(_msbInputExceptionMsg, _msbInputExceptionCap)
            Else
                MessageBox.Show(message, _msbInputExceptionCap)
            End If

        End Sub



        ''' <summary>
        ''' Shows the 'Required' message box.
        ''' </summary>
        ''' <param name="message">A message to override the default message.</param>

        Private Sub ShowRequiredMessage(Optional ByVal message As String = Nothing)

            If String.IsNullOrEmpty(message) Then
                MessageBox.Show(_msbRequiredMsg, _msbRequiredCap)
            Else
                MessageBox.Show(message, _msbRequiredCap)
            End If

        End Sub


        ''' <summary>
        ''' Shows a message box telling the user that the input should be greater than a certain limit.
        ''' </summary>
        ''' <param name="value">The value for the limit.</param>
        ''' <param name="message">A message to override the default message.</param>

        Private Sub ShowAbsMinMessage(ByVal value As Object, Optional ByVal message As String = Nothing)

            If String.IsNullOrEmpty(message) Then
                MessageBox.Show(String.Format(_msbAbsMinMsg, value), _msbAbsMinCap)
            Else
                MessageBox.Show(message, _msbAbsMinCap)
            End If

        End Sub



        ''' <summary>
        ''' Shows a message box telling the user that the input should be lesser than a certain limit.
        ''' </summary>
        ''' <param name="value">The value for the limit.</param>
        ''' <param name="message">A message to override the default message.</param>

        Private Sub ShowAbsMaxMessage(ByVal value As Object, Optional ByVal message As String = Nothing)

            If String.IsNullOrEmpty(message) Then
                MessageBox.Show(String.Format(_msbAbsMaxMsg, value), _msbAbsMaxCap)
            Else
                MessageBox.Show(message, _msbAbsMaxCap)
            End If

        End Sub


        ''' <summary>
        ''' Shows a message box containing the custom validation message provided by the screen.
        ''' </summary>
        ''' <remarks></remarks>

        Private Sub ShowCustomValidationFailMessage()

            MessageBox.Show(Common.VariablesParse(Me.Screen.CustomValidationFailMessage), Me._msbCustomValidationCap)

        End Sub


        ''' <summary>
        ''' Asks the user to confirm if the entered value is ok.
        ''' </summary>
        ''' <param name="value">The value etered by the user.</param>
        ''' <param name="message">A message to override the default message.</param>
        ''' <returns><c>True</c> if the user agrees, <c>False</c> otherwise.</returns>

        Private Function ShowPromptUnderMessage(ByVal value As Object, Optional ByVal message As String = Nothing) As Boolean

            If String.IsNullOrEmpty(message) Then
                Return MessageBox.Show(String.Format(_msbPromptUnderMsg, value), _msbPromptUnderCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes
            Else
                Return MessageBox.Show(message, _msbPromptUnderCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes
            End If

        End Function



        ''' <summary>
        ''' Asks the user to confirm if the entered value is ok.
        ''' </summary>
        ''' <param name="value">The value etered by the user.</param>
        ''' <param name="message">A message to override the default message.</param>
        ''' <returns><c>True</c> if the user agrees, <c>False</c> otherwise.</returns>

        Private Function ShowPromptOverMessage(ByVal value As Object, Optional ByVal message As String = Nothing) As Boolean

            If String.IsNullOrEmpty(message) Then
                Return MessageBox.Show(String.Format(_msbPromptOverMsg, value), _msbPromptOverCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes
            Else
                Return MessageBox.Show(message, _msbPromptOverCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes
            End If

        End Function


        ''' <summary>
        ''' Asks the user to confirm if it's ok to change the value.
        ''' </summary>
        ''' <param name="message">A message to override the default message.</param>
        ''' <returns><c>True</c> if the user agrees, <c>False</c> otherwise.</returns>

        Private Function ShowConfirmChangeMessage(Optional ByVal message As String = Nothing) As Boolean

            If String.IsNullOrEmpty(message) Then
                Return MessageBox.Show(_msbConfirmChangeMsg, _msbConfirmCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes
            Else
                Return MessageBox.Show(message, _msbConfirmCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes
            End If

        End Function



        ''' <summary>
        ''' Asks the user to confirm if it's ok to go to the next screen.
        ''' </summary>
        ''' <param name="message">A message to override the default message.</param>
        ''' <returns><c>True</c> if the user agrees, <c>False</c> otherwise.</returns>

        Private Function ShowConfirmNextMessage(Optional ByVal message As String = Nothing) As Boolean

            If String.IsNullOrEmpty(message) Then
                Return MessageBox.Show(_msbConfirmNextMsg, _msbConfirmCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes
            Else
                Return MessageBox.Show(message, _msbConfirmCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes
            End If

        End Function



        ''' <summary>
        ''' Asks the user to confirm if it's ok to go to the previous screen.
        ''' </summary>
        ''' <param name="message">A message to override the default message.</param>
        ''' <returns><c>True</c> if the user agrees, <c>False</c> otherwise.</returns>

        Private Function ShowConfirmBackMessage(Optional ByVal message As String = Nothing) As Boolean

            If String.IsNullOrEmpty(message) Then
                Return MessageBox.Show(_msbConfirmBackMsg, _msbConfirmCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes
            Else
                Return (MessageBox.Show(message, _msbConfirmCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes)
            End If

        End Function



        ''' <summary>
        ''' Performs the basic validations over the user input.
        ''' </summary>
        ''' <param name="validateRequiredValue">Indicates if the validation should check if a value is required.</param>
        ''' <returns><c>True</c> if all the validations are ok, <c>False</c> otherwise.</returns>

        Private Function Validate(ByVal validateRequiredValue As Boolean) As Boolean

            ' Check if the screen requires a value.
            If validateRequiredValue AndAlso Screen.Required.GetValueOrDefault(False) AndAlso Not HasValue Then
                ShowRequiredMessage()
                ValidationFailed()
                Return False
            End If



            ' Test if the screen can deliver its value.
            Try : Dim value As Object = InputValue
            Catch
                ShowInputExceptionMessage()
                ValidationFailed()
                Return False
            End Try


            ' If there is an input value and the screen template can validate range then check it.
            If InputValue IsNot Nothing AndAlso CanValidateRange() AndAlso Not ValidateRange() Then
                ValidationFailed()
                Return False
            End If


            ' If there is an input value then perform the Screen Template validation and the Screen custom validation
            If InputValue IsNot Nothing AndAlso (Not ValidateInput() Or Not Screen.EvaluateCustomValidation(InputValue)) Then
                If Not String.IsNullOrEmpty(Screen.CustomValidationFailMessage) Then ShowCustomValidationFailMessage()
                ValidationFailed()
                Return False
            End If



            ' If the original value has changed...
            If OriginalValueChanged Then

                ' If there was a previous value and a user confirmation is needed, ask for user confirmation. If the confirmation is negative, this input is invalid.
                If Screen.GetInitialValue IsNot Nothing AndAlso Screen.ConfirmChange.GetValueOrDefault(False) AndAlso Not ShowConfirmChangeMessage() Then
                    ValidationFailed()
                    Return False
                End If

            End If


            ' If everithing is ok to this point, the validation is ok.
            Return True

        End Function



        ''' <summary>
        ''' Determines if the screen has the ability to validate range limits for the input value.
        ''' </summary>
        ''' <returns><c>True</c> if the screen can validate range limits, <c>False</c> otherwise.</returns>
        ''' <remarks>This method looks for the <c>CanValidateRange</c> attribute, if it is present then
        ''' the screen can validate range limits.</remarks>

        Private Function CanValidateRange() As Boolean

            ' Look for the CanValidateRange Attribute.
            Dim canValidateRangeAttribute As CanValidateRangeAttribute
            canValidateRangeAttribute = CType(Attribute.GetCustomAttribute(Me.GetType, GetType(CanValidateRangeAttribute), False), CanValidateRangeAttribute)

            Return Not canValidateRangeAttribute Is Nothing

        End Function



        ''' <summary>
        ''' Performs range limits validation.
        ''' </summary>
        ''' <returns><c>True</c> if the input value is inside the specified limits, <c>False</c> otherwise.</returns>

        Private Function ValidateRange() As Boolean

            ' If there is input from the user
            If HasValue Then

                ' Get the type for the user input
                Dim inputType As TypeCode = Convert.GetTypeCode(InputValue)

                ' Absolute Minimun
                If Screen.AbsMin Then
                    Dim absMin As Object = BO.Evaluator.EvaluateFunction(BO.Context.ValidationsDotNETClassName, "AbsMin" & BO.Context.MethodNameSufix, inputType, Nothing)
                    If InputValue.CompareTo(absMin) < 0 Then ' If InputValue < absMin
                        ShowAbsMinMessage(absMin)
                        Return False
                    End If
                End If


                ' Absolute Maximun
                If Screen.AbsMax Then
                    Dim absMax As Object = BO.Evaluator.EvaluateFunction(BO.Context.ValidationsDotNETClassName, "AbsMax" & BO.Context.MethodNameSufix, inputType, Nothing)
                    If InputValue.CompareTo(absMax) > 0 Then ' If InputValue > absMax
                        ShowAbsMaxMessage(absMax)
                        Return False
                    End If
                End If


                ' Prompt Under
                If Screen.PromptUnder Then
                    Dim promptUnder As Object = BO.Evaluator.EvaluateFunction(BO.Context.ValidationsDotNETClassName, "PromptUnder" & BO.Context.MethodNameSufix, inputType, Nothing)
                    If InputValue.CompareTo(promptUnder) < 0 Then ' If InputValue < promptUnder
                        If Not ShowPromptUnderMessage(InputValue) Then Return False
                    End If
                End If


                ' Prompt Over
                If Screen.PromptOver Then
                    Dim promptOver As Object = BO.Evaluator.EvaluateFunction(BO.Context.ValidationsDotNETClassName, "PromptOver" & BO.Context.MethodNameSufix, inputType, Nothing)
                    If InputValue.CompareTo(promptOver) > 0 Then ' If InputValue > promptOver
                        If Not ShowPromptOverMessage(InputValue) Then Return False
                    End If
                End If

            End If


            ' If everithing is ok to this point, the value is inside the specified range.
            Return True

        End Function



        Private Function GetColor(ByVal colorName As String) As Color
            Return CType(GetType(Color).GetProperty(colorName).GetValue(Nothing, Nothing), Color)
        End Function

#End Region

    End Class

End Namespace