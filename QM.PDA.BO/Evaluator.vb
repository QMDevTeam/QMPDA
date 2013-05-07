

''' <summary>
''' Performes evaluations of logical conditions (true/false).
''' </summary>
''' <remarks>The conditions should be written in a .NET static method
''' (Shared in VB) that receives no parameters and returns a boolean
''' result (Boolean in VB).</remarks>

Public Class Evaluator


    ''' <summary>
    ''' Hash table to use as cache for the classes.
    ''' </summary>
    ''' <remarks></remarks>

    Private Shared classes As New Dictionary(Of String, Type)


    ''' <summary>
    ''' Locates and executes the specified Method.
    ''' </summary>
    ''' <returns>The logical (true/false) result of the evaluation.</returns>

    Public Shared Function EvaluateCondition(ByVal methodname As String, ByVal parameters As Object()) As Boolean

        ' Create the Method object and invoke the execution of it.
        Dim method As New Method(methodname)
        Dim result As Object = method.Invoke(parameters)

        ' Check the result of the execution, there must be a result and has to be a logical (true/false) result.
        If result Is Nothing Then Throw New ApplicationException(String.Format("The Method [{0}] must return a value.", methodname))
        If Not TypeOf result Is Boolean Then Throw New ApplicationException(String.Format("The result type of the Method [{0}] must be boolean.", methodname))

        Return CBool(result)

    End Function

    Public Shared Function EvaluateCondition() As Boolean

        Return CBool(EvaluateFunction(Context.ConditionsDotNETClassName, "Condition" & Context.MethodNameSufix, TypeCode.Boolean, Nothing))

    End Function

    Public Shared Function EvaluateFunction(ByVal dotNetClassName As String, ByVal methodName As String, ByVal outputType As TypeCode, ByVal parameters As Object()) As Object

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
        Try : result = Convert.ChangeType(methodInfo.Invoke(Nothing, values), outputType, Nothing)
        Catch ex As InvalidCastException

            Throw New ApplicationException(String.Format("Invalid cast exception on [{0}][{1}].", dotNetClassName, methodName), ex)

        End Try

        ' Make the call.
        Return result

    End Function
End Class
