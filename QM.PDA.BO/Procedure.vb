

''' <summary>
''' Represents a Procedure or Action to perform.
''' </summary>

Public Class Procedure


#Region " Properties "

    ''' <summary>
    ''' Hash table to use as cache for the classes.
    ''' </summary>
    ''' <remarks></remarks>

    Private Shared classes As New Dictionary(Of String, Type)

#End Region


#Region " Public Methods "

    ''' <summary>
    ''' Execute the specified Procedure.
    ''' </summary>
    ''' <param name="procedureID">The unique identifier of the Procedure to execute.</param>

    Public Overloads Shared Sub Execute(ByVal procedureID As Integer)

        ' Execute every step of the Procedure
        For Each procedureStep As ProcedureStep In procedureStep.GetAll(procedureID)
            procedureStep.Execute()
        Next

    End Sub


    ''' <summary>
    ''' Execute the specified Procedure.
    ''' </summary>
    ''' <param name="dotNetclassName">Name of the class containing the method.</param>
    ''' <param name="methodName">The name of the method within the class.</param>
    ''' <param name="parameters">Parameters of the method.</param>
    ''' <remarks></remarks>

    Public Overloads Shared Sub Execute(ByVal dotNetclassName As String, ByVal methodName As String, ByVal parameters As Object())

        Dim methodInfo As Reflection.MethodInfo
        Dim methodParameters As Reflection.ParameterInfo()
        Dim providedParametersCount As Integer = 0
        Dim expectedParametersCount As Integer = 0
        Dim t As Type
        Dim result As Object = Nothing

        ' Get the method info.
        If Not classes.ContainsKey(dotNetClassName) Then
            t = Type.GetType(dotNetClassName)
            If t Is Nothing Then Throw New ApplicationException(String.Format("The class [{0}] was not found .", dotNetClassName))
            classes.Add(dotNetClassName, t)
        End If
        methodInfo = classes(dotNetClassName).GetMethod(methodName)
        If methodInfo Is Nothing Then Throw New ApplicationException(String.Format("The method [{0}] was not found in class [{1}].", methodName, dotNetClassName))

        ' Validate the parameters.
        methodParameters = methodInfo.GetParameters

        If parameters IsNot Nothing Then providedParametersCount = parameters.Length
        If methodParameters IsNot Nothing Then expectedParametersCount = methodParameters.Length

        If providedParametersCount <> expectedParametersCount Then Throw New ApplicationException(String.Format("The amount of parameters provided [{0}] does not match the amount of expected parameters [{1}].", providedParametersCount, expectedParametersCount))

        Dim values() As Object = Nothing
        If expectedParametersCount > 0 Then

            ReDim values(expectedParametersCount - 1)

            For idx As Integer = 0 To parameters.Length - 1
                If parameters(idx) IsNot Nothing Then values(idx) = Convert.ChangeType(parameters(idx), methodParameters(idx).ParameterType, Nothing)
            Next
        End If

        ' Try to evaluate the function and cast to the expected output type.
        Try : methodInfo.Invoke(Nothing, values)
        Catch ex As Exception

            Throw New ApplicationException(String.Format("Exception during external call [{0}][{1}].", dotNetclassName, methodName), ex)

        End Try

    End Sub


#End Region

End Class
