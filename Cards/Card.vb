Imports Cards.CardHolder

Public Class Card
    Public ReadOnly suit As Suit
    Public ReadOnly rank As Rank


    Public Sub New(ByVal newSuit As Suit, ByVal newRank As Rank)
        suit = newSuit
        rank = newRank
    End Sub

    Public Overrides Function ToString() As String
        Return "The" & rank.ToString() & "of" & suit.ToString() & "s"
    End Function
End Class
