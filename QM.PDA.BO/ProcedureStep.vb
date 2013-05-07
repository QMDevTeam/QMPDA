

''' <summary>
''' Represents a single step of a Procedure.
''' </summary>

Public Class ProcedureStep

#Region " Properties "

    Private _procedureID As Integer
    Private _order As Integer
    Private _methodName As String
    Private _methodArguments As String



    Public ReadOnly Property ProcedureID() As Integer
        Get
            Return _procedureID
        End Get
    End Property


    Public ReadOnly Property Order() As Integer
        Get
            Return _order
        End Get
    End Property


    Public ReadOnly Property MethodName() As String
        Get
            Return _methodName
        End Get
    End Property


    Public ReadOnly Property MethodArguments() As String
        Get
            Return _methodArguments
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Executes this Procedure Step.
    ''' </summary>

    Public Sub Execute()

        ' Create the Method object and invoke the execution of it.
        Dim method As New Method(_methodName)
        Dim parameters As Object() = Nothing
        If _methodArguments IsNot Nothing Then parameters = _methodArguments.Split(","c)

        method.Invoke(parameters)

    End Sub



    ''' <summary>
    ''' Gets a list of all the Procedure Steps of a specified Procedure.
    ''' </summary>
    ''' <param name="procedureID">The unique identifier of the Procedure.</param>
    ''' <returns>A <c>List</c> of <c>ProcedureStep</c> objects.</returns>

    Public Shared Function GetAll(ByVal procedureID As Integer) As List(Of ProcedureStep)

        Dim list As New List(Of ProcedureStep)

        For Each row As DataRow In DA.ProcedureStep.GetAll(procedureID).Rows
            list.Add(New ProcedureStep(row))
        Next

        Return list

    End Function

#End Region

#Region " Private Methods "

    Private Sub New(ByVal row As DataRow)
        PopulateProperties(row)
    End Sub



    ''' <summary>
    ''' Inicializates the properties values
    ''' </summary>
    ''' <param name="row">Is the DataRow with all the values</param>

    Private Sub PopulateProperties(ByVal row As DataRow)

        _procedureID = CInt(row("ProcedureID"))
        _order = CInt(row("Order"))
        _methodName = CStr(row("MethodName"))

        If TypeOf row("MethodArguments") Is DBNull Then _methodArguments = Nothing Else _methodArguments = CStr(row("MethodArguments"))

    End Sub

#End Region

End Class
