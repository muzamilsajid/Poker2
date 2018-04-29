Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.IO
Imports System.Console
Imports Cards.CardHolder

Module VAR
    Public MyDeck As Deck
    Public Poker As New Game

    Public lstDeck As New List(Of Card)
    Public P1Card1 As Card
    Public P1Card2 As Card
    Public P2Card1 As Card
    Public P2Card2 As Card

    Public FlopCard1 As Card
    Public FlopCard2 As Card
    Public FlopCard3 As Card
    Public TurnCard As Card
    Public RiverCard As Card

    Public P1PairFound As Boolean = False
    Public P1TwoPairsFound As Boolean = False
    Public P2PairFound As Boolean = False
    Public P2TwoPairsFound As Boolean = False
    Public P1ThreeofAKind As Boolean = False
    Public P2ThreeofAKind As Boolean = False
    Public P1FlushFound As Boolean = False
    Public P2FlushFound As Boolean = False
    Public P1HighPair As Card
    Public P1LowPair As Card
    Public P2HighPair As Card
    Public P2LowPair As Card
    Public P1Pair1 As Card
    Public P1Pair2 As Card
    Public P2Pair1 As Card
    Public P2Pair2 As Card

    Public MyPath As String = "C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards-master\Cards\"

    Public cnt As Integer

    Public Player1 As New Player
    Public Player2 As New Player

    Public FlopPicPosP1 As Integer = 4
    Public FlopPicPosP2 As Integer = 4
    Public P1PicPos As Integer
    Public P2PicPos As Integer

End Module

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim myDeck As Deck = New Deck()
        MyDeck = New Deck
        MyDeck.shuffle()
        ListBox1.Items.Clear()
        For i As Integer = 0 To 52 - 1
            Dim tempCard As Card = myDeck.getCard(i)
            'Write(tempCard.ToString())
            ListBox1.Items.Add(tempCard)
            'If i <> 51 Then Write(",") Else WriteLine()
        Next
        'Console.Read()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MyDeck = New Deck()


        MyDeck.shuffle()

        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()

        For i = 0 To 16 - 1

            Dim tmpCard As Card = MyDeck.getCard(i)

            Select Case i
                Case 0 To 3
                    ListBox2.Items.Add(tmpCard)
                Case 4 To 7
                    ListBox3.Items.Add(tmpCard)
                Case 8 To 11
                    ListBox4.Items.Add(tmpCard)
                Case 12 To 15
                    ListBox5.Items.Add(tmpCard)
            End Select

        Next



        For i As Integer = 0 To ListBox2.Items.Count - 1
            ListBox2.SelectedIndex = i
            If File.Exists(MyPath & ListBox2.Text & ".png") Then
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Load(MyPath & ListBox2.Text & ".png")
            Else
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Image = Nothing
            End If

        Next

        Dim a As Integer = 0

        For i As Integer = 4 To 7

            ListBox3.SelectedIndex = a

            If File.Exists(MyPath & ListBox3.Text & ".png") Then
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Load(MyPath & ListBox3.Text & ".png")
            Else
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Image = Nothing
            End If
            a = a + 1
        Next

        a = 0

        For i As Integer = 8 To 11

            ListBox4.SelectedIndex = a

            If File.Exists(MyPath & ListBox4.Text & ".png") Then
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Load(MyPath & ListBox4.Text & ".png")
            Else
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Image = Nothing
            End If
            a = a + 1
        Next

        a = 0

        For i As Integer = 12 To 15

            ListBox5.SelectedIndex = a

            If File.Exists(MyPath & ListBox5.Text & ".png") Then
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Load(MyPath & ListBox5.Text & ".png")
            Else
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Image = Nothing
            End If
            a = a + 1
        Next
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click

        ListBox5.Items.Clear()

        CompareFlush(P1Card1, P1Card2, P2Card1, P2Card2)

        If P1FlushFound = True Or P2FlushFound = True Then
            CompareFlushMsg()
        Else
            CompareThreeOfAKind(P1Card1, P1Card2, P2Card1, P2Card2)
            If P1ThreeofAKind = True Or P2ThreeofAKind = True Then
                CompareThreeOfAKindMsg()
            Else
                CompareTwoPairs(P1Card1, P1Card2, P2Card1, P2Card2)
                If P1TwoPairsFound = True Or P2TwoPairsFound = True Then
                    CompareTwoPairsMsg()
                Else
                    Poker.ComparePair(P1Card1, P1Card2, P2Card1, P2Card2)
                    Poker.ComparePairMsg()
                End If
            End If
        End If
    End Sub

    Private Sub btnDeal_Click(sender As Object, e As EventArgs) Handles btnDeal.Click
        Dim rand As New Random
        MyDeck = New Deck

        ClearImages()
        ClearAll()
        MyDeck.shuffle()

        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        lstDeck.Clear()
        cnt = 0


        FlopCard1 = MyDeck.getCard(cnt)
        lstDeck.Add(FlopCard1)
        ListBox4.Items.Add(FlopCard1)
        PictureBox4.Load(MyPath & FlopCard1.ToString() & ".png")
        cnt += 1

        FlopCard2 = MyDeck.getCard(cnt)
        lstDeck.Add(FlopCard2)
        ListBox4.Items.Add(FlopCard2)
        PictureBox5.Load(MyPath & FlopCard2.ToString() & ".png")
        cnt += 1

        FlopCard3 = MyDeck.getCard(cnt)
        lstDeck.Add(FlopCard3)
        ListBox4.Items.Add(FlopCard3)
        PictureBox6.Load(MyPath & FlopCard3.ToString() & ".png")
        cnt += 1



        P1Card1 = MyDeck.getCard(cnt)
        ListBox2.Items.Add(P1Card1)
        PictureBox0.Load(MyPath & P1Card1.ToString() & ".png")
        cnt += 1

        P1Card2 = MyDeck.getCard(cnt)
        ListBox2.Items.Add(P1Card2)
        PictureBox1.Load(MyPath & P1Card2.ToString() & ".png")
        cnt += 1

        P2Card1 = MyDeck.getCard(cnt)
        ListBox3.Items.Add(P2Card1)
        PictureBox2.Load(MyPath & P2Card1.ToString() & ".png")
        cnt += 1

        P2Card2 = MyDeck.getCard(cnt)
        ListBox3.Items.Add(P2Card2)
        PictureBox3.Load(MyPath & P2Card2.ToString() & ".png")
        cnt += 1

        Player1.Turn = True
        'btnCompare_Click(sender, New System.EventArgs)
    End Sub

    Sub openCards()
        If cnt = 7 Then
            TurnCard = MyDeck.getCard(cnt)
            lstDeck.Add(TurnCard)
            ListBox4.Items.Add(TurnCard)
            PictureBox7.Load(MyPath & TurnCard.ToString() & ".png")
        End If

        If cnt = 8 Then
            RiverCard = MyDeck.getCard(cnt)
            lstDeck.Add(RiverCard)
            ListBox4.Items.Add(RiverCard)
            PictureBox8.Load(MyPath & RiverCard.ToString() & ".png")
        End If
    End Sub

    Sub ClearAll()
        P1HighPair = Nothing
        P2HighPair = Nothing
        P1LowPair = Nothing
        P2LowPair = Nothing
        P1Pair1 = Nothing
        P1Pair2 = Nothing
        P2Pair1 = Nothing
        P2Pair2 = Nothing
        P1PairFound = False
        P2PairFound = False
        P1TwoPairsFound = False
        P2TwoPairsFound = False
        P1ThreeofAKind = False
        P2ThreeofAKind = False
        P1FlushFound = False
        P2FlushFound = False
        PictureBox4.Top = 311
        PictureBox5.Top = 311
        PictureBox6.Top = 311
        PictureBox7.Top = 311
        PictureBox8.Top = 311
        P1PicPos = 0
        P2PicPos = 0
        FlopPicPosP1 = 4
        FlopPicPosP2 = 4
    End Sub

    Sub ClearImages()

        PictureBox0.Image = Nothing
        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PictureBox5.Image = Nothing
        PictureBox6.Image = Nothing
        PictureBox7.Image = Nothing
        PictureBox8.Image = Nothing
    End Sub

    
    Sub CompareTwoPairs(card1 As Card, card2 As Card, card3 As Card, card4 As Card)
        ClearAll()

        For Each Crd In lstDeck
            If card1.rank = Crd.rank Then
                If IsNothing(P1Pair1) Then
                    P1Pair1 = Crd
                End If
            End If

            If card2.rank = Crd.rank Then
                If card2.rank = Crd.rank Then
                    If IsNothing(P1Pair2) Then
                        P1Pair2 = Crd
                    End If
                End If
            End If
        Next

        If Not IsNothing(P1Pair1) And Not IsNothing(P1Pair2) Then
            P1TwoPairsFound = True
            If P1Pair1.rank > P1Pair2.rank Then
                P1HighPair = P1Pair1
                P1LowPair = P1Pair2
            Else
                P1HighPair = P1Pair2
                P1LowPair = P1Pair1
            End If
        End If

        For Each Crd In lstDeck
            If card3.rank = Crd.rank Then
                If IsNothing(P2Pair1) Then
                    P2Pair1 = Crd
                End If
            End If

            If card4.rank = Crd.rank Then
                If card4.rank = Crd.rank Then
                    If IsNothing(P2Pair2) Then
                        P2Pair2 = Crd
                    End If
                End If
            End If
        Next

        If Not IsNothing(P2Pair1) And Not IsNothing(P2Pair2) Then
            P2TwoPairsFound = True
            If P2Pair1.rank > P2Pair2.rank Then
                P2HighPair = P2Pair1
                P2LowPair = P2Pair2
            Else
                P2HighPair = P2Pair2
                P2LowPair = P2Pair1
            End If
        End If

    End Sub

    Sub CompareTwoPairsMsg()
        If P1TwoPairsFound = True And P2TwoPairsFound = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                ListBox5.Items.Add(Player1.Name & " Won By 2 Pairs of " & P1HighPair.rank.ToString() & " and " & P1LowPair.rank.ToString())
            Else
                ListBox5.Items.Add(Player2.Name & " Won By 2 Pairs of " & P2HighPair.rank.ToString() & " and " & P2LowPair.rank.ToString())
            End If
        End If

        If P1TwoPairsFound = True And P2TwoPairsFound = False Then
            ListBox5.Items.Add(Player1.Name & " Won By 2 Pairs of " & P1HighPair.rank.ToString() & " and " & P1LowPair.rank.ToString())
        End If

        If P1TwoPairsFound = False And P2TwoPairsFound = True Then
            ListBox5.Items.Add(Player2.Name & " Won By 2 Pairs of " & P2HighPair.rank.ToString() & " and " & P2LowPair.rank.ToString())
        End If
    End Sub

    Sub CompareThreeOfAKind(card1 As Card, card2 As Card, card3 As Card, card4 As Card)
        Dim intTOK1 As Integer = 1
        Dim intTOK2 As Integer = 1
        Dim intTOK3 As Integer = 1
        Dim intTOK4 As Integer = 1

        ClearAll()

        If card1.rank = card2.rank Then
            intTOK1 += 1
            intTOK2 += 1
        End If

        For Each Crd In lstDeck
            If card1.rank = Crd.rank Then
                P1Pair1 = Crd
                intTOK1 += 1
            End If

            If card2.rank = Crd.rank Then
                P1Pair2 = Crd
                intTOK2 += 1
            End If
        Next

        If intTOK1 > 2 Then
            P1HighPair = P1Pair1
            P1ThreeofAKind = True
        End If

        If intTOK2 > 2 Then
            If Not IsNothing(P1HighPair) Then
                If P1Pair2.rank < P1HighPair.rank Then
                    P1HighPair = P1Pair1
                    P1ThreeofAKind = True
                Else
                    P1HighPair = P1Pair2
                    P1ThreeofAKind = True
                End If
            Else
                P1HighPair = P1Pair2
                P1ThreeofAKind = True
            End If
        End If

        If card3.rank = card4.rank Then
            intTOK3 += 1
            intTOK4 += 1
        End If

        For Each Crd In lstDeck
            If card3.rank = Crd.rank Then
                P2Pair1 = Crd
                intTOK3 += 1
            End If

            If card4.rank = Crd.rank Then
                P2Pair2 = Crd
                intTOK4 += 1
            End If
        Next

        If intTOK3 > 2 Then
            P2HighPair = P2Pair1
            P2ThreeofAKind = True
        End If

        If intTOK4 > 2 Then
            If Not IsNothing(P2HighPair) Then
                If P2Pair1.rank < P2HighPair.rank Then
                    P2HighPair = P2Pair1
                    P2ThreeofAKind = True
                Else
                    P2HighPair = P2Pair2
                    P2ThreeofAKind = True
                End If
            Else
                P2HighPair = P2Pair2
                P2ThreeofAKind = True
            End If
        End If

    End Sub

    Sub CompareThreeOfAKindMsg()
        If P1ThreeofAKind = True And P2ThreeofAKind = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                ListBox5.Items.Add(Player1.Name & " Wins With Three of Kinds of " & P1HighPair.rank.ToString())
            Else
                ListBox5.Items.Add(Player2.Name & " Wins With Three of Kinds of " & P2HighPair.rank.ToString())
            End If
            If P1HighPair.rank = P2HighPair.rank Then
                ListBox5.Items.Add(Player1.Name & " and P2 Both Have " & P1HighPair.rank.ToString())
            End If
        ElseIf P1ThreeofAKind = True Then
            ListBox5.Items.Add(Player1.Name & " Wins With Three of Kinds of " & P1HighPair.rank.ToString())
        ElseIf P2ThreeofAKind = True Then
            ListBox5.Items.Add(Player2.Name & " Wins With Three of Kinds of " & P2HighPair.rank.ToString())
        End If
    End Sub

    Sub CompareFlush(card1 As Card, card2 As Card, card3 As Card, card4 As Card)
        Dim intFlushP1 As Integer = 0
        Dim intFlushP2 As Integer = 0

        ClearAll()

        'If card1.suit = card2.suit Then
        '    intFlushP1 += 1
        'End If
        If P1Card1.rank > P1Card2.rank Then
            P1HighPair = P1Card1
        Else
            P1HighPair = P1Card2
        End If

        For Each Crd In lstDeck
            If card1.suit = Crd.suit Then
                If Crd.rank > P1HighPair.rank Then
                    P1HighPair = Crd
                End If
                intFlushP1 += 1
            End If
        Next

        For Each Crd In lstDeck
            If card2.suit = Crd.suit Then
                If Crd.rank > P1HighPair.rank Then
                    P1HighPair = Crd
                End If
                intFlushP1 += 1
            End If
        Next

        If intFlushP1 > 4 Then
            P1FlushFound = True
        End If

        'If card3.suit = card4.suit Then
        '    intFlushP2 += 1
        'End If
        If P2Card1.rank > P2Card2.rank Then
            P2HighPair = P2Card1
        Else
            P2HighPair = P2Card2
        End If

        For Each Crd In lstDeck
            If card3.suit = Crd.suit Then
                If Crd.rank > P2HighPair.rank Then
                    P2HighPair = Crd
                End If
                intFlushP2 += 1
            End If
        Next

        For Each Crd In lstDeck
            If card4.suit = Crd.suit Then
                If Crd.rank > P2HighPair.rank Then
                    P2HighPair = Crd
                End If
                intFlushP2 += 1
            End If
        Next

        If intFlushP2 > 4 Then
            P2FlushFound = True
        End If
    End Sub

    Sub CompareFlushMsg()
        If P1FlushFound = True And P2FlushFound = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                ListBox5.Items.Add(Player1.Name & " Wins With Flush " & P1HighPair.rank.ToString() & " High")
            Else
                ListBox5.Items.Add(Player2.Name & " Wins With Flush " & P2HighPair.rank.ToString() & " High")
            End If
            If P1HighPair.rank = P2HighPair.rank Then
                ListBox5.Items.Add(Player1.Name & " and " & Player2.Name & " Both Have flush " & P1HighPair.rank.ToString() & " High")
            End If
        ElseIf P1FlushFound = True Then
            ListBox5.Items.Add(Player1.Name & " Wins With Flush " & P1HighPair.rank.ToString() & " High")
        ElseIf P2FlushFound = True Then
            ListBox5.Items.Add(Player2.Name & " Wins With Flush " & P2HighPair.rank.ToString() & " High")
        End If
    End Sub

    Private Sub BtnP1Check_Click(sender As Object, e As EventArgs) Handles BtnP1Check.Click
        If Player1.Turn = True Then
            Player1.Checked = True
            If Player1.Checked = True And Player2.Checked = True Then
                openCards()
                cnt += 1
                Player1.Checked = False
                Player2.Checked = False
            End If
            Player2.Turn = True
            Player1.Turn = False
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Player1.Name = txtP1Name.Text
        Player2.Name = txtP2Name.Text
        Player1.Turn = False
        Player2.Turn = False
        Player1.Checked = False
        Player2.Checked = False
        lblPlayer1.Text = Player1.Name
        lblPlayer2.Text = Player2.Name
    End Sub

    Private Sub btnP2Check_Click(sender As Object, e As EventArgs) Handles btnP2Check.Click
        If Player2.Turn = True Then
            If Player2.Turn = True Then
                Player2.Checked = True
                If Player1.Checked = True And Player2.Checked = True Then
                    openCards()
                    cnt += 1
                    Player1.Checked = False
                    Player2.Checked = False
                End If
            End If
            Player1.Turn = True
            Player2.Turn = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Poker.Straight(P1Card1.rank, P1Card2.rank, P2Card1.rank, P2Card2.rank)
    End Sub
End Class

Public Class CardHolder
    Public Enum Suit
        Club
        Diamond
        Heart
        Spade
    End Enum

    Public Enum Rank
        Ace = 1
        Deuce
        Three
        Four
        Five
        Six
        Seven
        Eight
        Nine
        Ten
        Jack
        Queen
        King
    End Enum

End Class

