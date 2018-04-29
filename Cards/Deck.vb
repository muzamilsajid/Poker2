Imports Cards.CardHolder
Public Class Deck
    Private cards As Card()

    Public Sub New()
        cards = New Card(51) {}
        Dim j As Integer = 0

        For suitval As Integer = 0 To 4 - 1
            For rankval As Integer = 1 To 14 - 1

                cards(j) = New Card(CType(suitval, Suit), CType(rankval, Rank))
                j = j + 1
                'cards(suitval * 13 + rankval - 1) = New Card(CType(suitval, Suit), CType(rankval, Rank))
            Next
        Next
    End Sub

    Public Function getCard(ByVal cardNum As Integer) As Card
        If cardNum >= 0 AndAlso cardNum <= 51 Then
            Return cards(cardNum)
        Else
            Throw (New System.ArgumentOutOfRangeException("CardNum", cardNum, "Value Must be between 0 adn 51."))
        End If
    End Function


    Public Sub shuffle()
        Dim newDecks As Card() = New Card(51) {}
        Dim assigend As Boolean() = New Boolean(51) {}
        Dim sourceGen As Random = New Random()

        For i As Integer = 0 To 52 - 1
            Dim destCard As Integer = 0
            Dim foundCard As Boolean = False
            While foundCard = False
                destCard = sourceGen.[Next](52)
                If assigend(destCard) = False Then foundCard = True
            End While

            assigend(destCard) = True
            newDecks(destCard) = cards(i)
        Next

        newDecks.CopyTo(cards, 0)
    End Sub
End Class
