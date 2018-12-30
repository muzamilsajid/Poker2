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

    Private mKicker1 As Card
    Public Property Kicker1() As Card
        Get
            Return mKicker1
        End Get
        Set(ByVal value As Card)
            mKicker1 = value
        End Set
    End Property

    Private mKicker2 As Card
    Public Property Kicker2() As Card
        Get
            Return mKicker2
        End Get
        Set(ByVal value As Card)
            mKicker2 = value
        End Set
    End Property

    Private mKicker3 As Card
    Public Property Kicker3() As Card
        Get
            Return mKicker3
        End Get
        Set(ByVal value As Card)
            mKicker3 = value
        End Set
    End Property

    Private mKicker4 As Card
    Public Property Kicker4() As Card
        Get
            Return mKicker4
        End Get
        Set(ByVal value As Card)
            mKicker4 = value
        End Set
    End Property

    Private mHighPair As Card
    Public Property HighPair() As Card
        Get
            Return mHighPair
        End Get
        Set(ByVal value As Card)
            mHighPair = value
        End Set
    End Property

    Private mHandCard1 As Card
    Public Property Handcard1() As Card
        Get
            Return mHandCard1
        End Get
        Set(ByVal value As Card)
            mHandCard1 = value
        End Set
    End Property

    Private mHandCard2 As Card
    Public Property Handcard2() As Card
        Get
            Return mHandCard2
        End Get
        Set(ByVal value As Card)
            mHandCard2 = value
        End Set
    End Property

End Class
