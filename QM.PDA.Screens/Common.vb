

Class Common

#Region " Properties "

    Private Shared StartIdentifier As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_-"
    Private Shared MiddleItentifier As String = StartIdentifier & "0123456789"

#End Region


#Region " Public Methods "

    ''' <summary>
    ''' Replaces the aperances of variableNames with it's value.
    ''' </summary>
    ''' <param name="expresion">Expresion to parse.</param>
    ''' <returns>The parsed string.</returns>
    ''' <remarks></remarks>

    Public Shared Function VariablesParse(ByVal expresion As String) As String

        ' Add a space at the end to handle a variable name at the end of the MainText.
        Dim expressionText As New Text.StringBuilder(expresion & " ")

        ' Parse the text for variables or scaped @'s.
        Dim i As Integer = 0
        While i < expressionText.Length
            If expressionText(i) = "@"c Then

                If expressionText(i + 1) = "@"c Then
                    ' Scaped @'s
                    expressionText.Remove(i, 1)
                    i += 1

                ElseIf StartIdentifier.IndexOf(expressionText(i + 1)) <> -1 Then
                    ' Read variableName.
                    Dim j As Integer = i + 1
                    Dim varName As String = ""
                    While MiddleItentifier.IndexOf(expressionText(j)) <> -1
                        varName &= expressionText(j)
                        j += 1
                    End While

                    expressionText.Remove(i, j - i)

                    ' Get the value from the data.
                    Dim value As String = ""
                    If BO.Context.CurrentSection.DataRecord IsNot Nothing AndAlso BO.Context.CurrentSection.DataRecord.VariableExists(varName) Then

                        If QM.PDA.BO.Context.CurrentSection(varName) IsNot Nothing Then
                            value = QM.PDA.BO.Context.CurrentSection(varName).ToString
                        End If

                    ElseIf BO.Context.CurrentQuestionnaire.DataRecord IsNot Nothing AndAlso BO.Context.CurrentQuestionnaire.DataRecord.VariableExists(varName) Then

                        If QM.PDA.BO.Context.CurrentQuestionnaire(varName) IsNot Nothing Then
                            value = QM.PDA.BO.Context.CurrentQuestionnaire(varName).ToString
                        End If

                    ElseIf BO.Context.CurrentSubject.DataRecord IsNot Nothing AndAlso BO.Context.CurrentSubject.DataRecord.VariableExists(varName) Then

                        If QM.PDA.BO.Context.CurrentSubject(varName) IsNot Nothing Then
                            value = QM.PDA.BO.Context.CurrentSubject(varName).ToString
                        End If

                    Else

                        value = "@" + varName

                    End If

                    ' Insert the value into the label.
                    expressionText.Insert(i, value)
                    i += value.Length
                End If

            Else
                ' If character is not @ then skip.
                i += 1
            End If
        End While


        ' Remove the space at the end and return the parsed string.
        expressionText.Remove(expressionText.Length - 1, 1)
        Return expressionText.ToString

    End Function

#End Region

End Class