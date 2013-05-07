

''' <summary>
''' Gets the transitions a screen can have
''' </summary>

Public Class Transition

#Region " Properties "

    Private _screenID As Integer
    Private _order As Integer
    Private _destinationScreenID As Integer
    Private _onTransitionProcedureID As Nullable(Of Integer)
    Private _condition As Boolean

    Private _destinationScreen As Screen



    Public ReadOnly Property ScreenID() As Integer
        Get
            Return _screenID
        End Get
    End Property


    Public ReadOnly Property Order() As Integer
        Get
            Return _order
        End Get
    End Property


    Public ReadOnly Property DestinationScreenID() As Integer
        Get
            Return _destinationScreenID
        End Get
    End Property


    Public ReadOnly Property OnTransitionProcedureID() As Nullable(Of Integer)
        Get
            Return _onTransitionProcedureID
        End Get
    End Property


    Public ReadOnly Property Condition() As Boolean
        Get
            Return _condition
        End Get
    End Property


    Public ReadOnly Property DestinationScreen() As Screen
        Get
            If _destinationScreen Is Nothing Then _destinationScreen = New Screen(_destinationScreenID)
            Return _destinationScreen
        End Get
    End Property

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Get all the transitions a specific screen can have
    ''' </summary>
    ''' <param name="screenID">Is the screen id</param>
    ''' <returns>A <c>List</c> of screen transitions</returns>

    Public Shared Function GetAll(ByVal screenID As Integer) As List(Of Transition)

        Dim list As New List(Of Transition)

        For Each row As DataRow In DA.Transition.GetAll(screenID).Rows
            list.Add(New Transition(row))
        Next

        Return list

    End Function



    ''' <summary>
    ''' Evaluates the OnValidateCondition and returns the result.
    ''' </summary>
    ''' <returns>The result of the evaluation of OnValidateCondition.</returns>

    Public Function EvaluateCondition() As Boolean
        Return Not _condition OrElse Evaluator.EvaluateCondition()
    End Function



    Public Sub ExecuteOnTransitionProcedure()
        If _onTransitionProcedureID.HasValue Then Procedure.Execute(_onTransitionProcedureID.Value)
    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="row">DataRow with all the information</param>

    Private Sub New(ByVal row As DataRow)
        PopulateProperties(row)
    End Sub



    ''' <summary>
    ''' Sets the properties values
    ''' </summary>
    ''' <param name="row">DataRow with all the information</param>

    Private Sub PopulateProperties(ByVal row As DataRow)

        _screenID = CInt(row("ScreenID"))
        _order = CInt(row("Order"))
        _destinationScreenID = CInt(row("DestinationScreenID"))

        If TypeOf row("OnTransitionProcedureID") Is DBNull Then _onTransitionProcedureID = Nothing Else _onTransitionProcedureID = CInt(row("OnTransitionProcedureID"))
        If TypeOf row("Condition") Is DBNull Then _condition = Nothing Else _condition = CBool(row("Condition"))

    End Sub

#End Region

End Class