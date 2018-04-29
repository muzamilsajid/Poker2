Public Class Player
    Private nName As String
    Public Property Name() As String
        Get
            Return nName
        End Get
        Set(ByVal value As String)
            nName = value
        End Set
    End Property

    Private nChips As Integer
    Public Property Chips() As Integer
        Get
            Return nChips
        End Get
        Set(ByVal value As Integer)
            nChips = value
        End Set
    End Property

    Private nTurn As Boolean
    Public Property Turn() As Boolean
        Get
            Return nTurn
        End Get
        Set(ByVal value As Boolean)
            nTurn = value
        End Set
    End Property

    Private mChecked As Boolean
    Public Property Checked() As Boolean
        Get
            Return mChecked
        End Get
        Set(ByVal value As Boolean)
            mChecked = value
        End Set
    End Property
End Class
