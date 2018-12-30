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
    Public PairOnTableFound As Boolean = False
    Public P2TwoPairsFound As Boolean = False
    Public P1ThreeofAKind As Boolean = False
    Public P2ThreeofAKind As Boolean = False
    Public TOKOnTablefound As Boolean = False
    Public P1StraightFound As Boolean = False
    Public P2StraightFound As Boolean = False
    Public StraightOnTableFound As Boolean = False
    Public FlushOnTableFound As Boolean = False
    Public P1FOK As Boolean = False
    Public P2FOK As Boolean = False
    Public FOKOnTableFound As Boolean = False
    Public P1FlushFound As Boolean = False
    Public P2FlushFound As Boolean = False
    Public P1FullHouseFound As Boolean = False
    Public P2FullHouseFound As Boolean = False
    Public P1RoyalFlushFound As Boolean = False
    Public P2RoyalFlushFound As Boolean = False
    Public TwoPairsOnTableFound As Boolean = False
    Public P1StraightTo5Found As Boolean = False
    Public P2StraightTo5Found As Boolean = False
    Public P1StraightFlushTo5Found As Boolean = False
    Public P2StraightFlushTo5Found As Boolean = False
    Public P1HighPair As Card
    Public P1LowPair As Card
    Public P2HighPair As Card
    Public P2LowPair As Card
    Public P1HighPairRank As Integer
    Public P2HighPairRank As Integer
    Public HighPair As Card
    Public P1Pair1 As Card
    Public P1Pair2 As Card
    Public P2Pair1 As Card
    Public P2Pair2 As Card
    Public TablePair1 As Card
    Public TablePair2 As Card
    Public FlushCard As Card

    Public MyPath As String = "C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards-master\Cards\"

    Public cnt As Integer

    Public Player1 As New Player
    Public Player2 As New Player

    'Public FlopPicPosP1 As Integer = 4
    'Public FlopPicPosP2 As Integer = 4
    Public P1PicPos As Integer
    Public P2PicPos As Integer

End Module

Public Class Form1

#Region "Clear All Variables"
    Sub ClearAll()
        P1HighPair = Nothing
        P2HighPair = Nothing
        P1LowPair = Nothing
        P2LowPair = Nothing
        P1Pair1 = Nothing
        P1Pair2 = Nothing
        P2Pair1 = Nothing
        P2Pair2 = Nothing
        HighPair = Nothing
        TablePair1 = Nothing
        TablePair2 = Nothing
        P1PairFound = False
        P2PairFound = False
        P1TwoPairsFound = False
        P2TwoPairsFound = False
        P1ThreeofAKind = False
        P2ThreeofAKind = False
        PairOnTableFound = False
        TOKOnTablefound = False
        FOKOnTableFound = False
        FlushOnTableFound = False
        StraightOnTableFound = False
        P1FOK = False
        P2FOK = False
        P1StraightFound = False
        P2StraightFound = False
        P1FlushFound = False
        P2FlushFound = False
        P1FullHouseFound = False
        P2FullHouseFound = False
        P1RoyalFlushFound = False
        P2RoyalFlushFound = False
        TwoPairsOnTableFound = False
        P1StraightTo5Found = False
        P2StraightTo5Found = False
        P1StraightFlushTo5Found = False
        P2StraightFlushTo5Found = False

        lstDeck.Clear()

        lstDeck.Add(FlopCard1)
        lstDeck.Add(FlopCard2)
        lstDeck.Add(FlopCard3)
        lstDeck.Add(TurnCard)
        lstDeck.Add(RiverCard)
        'PictureBox0.Top = 50
        'PictureBox1.Top = 50
        'PictureBox4.Top = 311
        'PictureBox5.Top = 311
        'PictureBox6.Top = 311
        'PictureBox7.Top = 311
        'PictureBox8.Top = 311
        'P1PicPos = 0
        'P2PicPos = 0
        'FlopPicPosP1 = 4
        'FlopPicPosP2 = 4
    End Sub
#End Region

#Region "Button For Adding All Cards In ListBox"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim myDeck As Deck = New Deck()
        MyDeck = New Deck
        MyDeck.shuffle()
        ListBox1.Items.Clear()
        For i As Integer = 0 To 52 - 1
            Dim tempCard As Card = MyDeck.getCard(i)
            'Write(tempCard.ToString())
            ListBox1.Items.Add(tempCard)
            'If i <> 51 Then Write(",") Else WriteLine()
        Next
        'Console.Read()
    End Sub
#End Region

#Region "Give Cards To All Players Test Button"
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
#End Region

#Region "All Methods Comparison"
    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click

        If MyDeck.River = False Then
            MsgBox("Game Not Over Yet")
            Exit Sub
        End If

        ListBox5.Items.Clear()

        Poker.RoyalFlush()

        If P1RoyalFlushFound = True Or P2RoyalFlushFound = True Then
            Poker.CompareRoyalFlushMsg()
        Else

            Poker.StraightFlush(FlopCard1, FlopCard2, FlopCard3, TurnCard, RiverCard, P1Card1, P1Card2, P2Card1, P2Card2)

            If (P1FlushFound = True And P1StraightFound = True) Or (P2FlushFound = True And P2StraightFound = True) Then
                Poker.CompareStraightFlushMsg()
            Else
                Poker.StraightFlushTo5()
                If P1StraightFlushTo5Found = True Or P2StraightFlushTo5Found = True Then
                    Poker.CompareStraightFlushTo5Msg()
                Else

                    Poker.CompareFOK(P1Card1, P1Card2, P2Card1, P2Card2) 'Compare Four of a KKind

                    If P1FOK = True Or P2FOK = True Then 'If FOK is True for any player then call FOK msg.
                        Poker.CompareFOKMsg()
                    Else

                        Poker.CompareFOKonTable(FlopCard1, FlopCard2, FlopCard3, TurnCard, RiverCard)

                        If FOKOnTableFound = True Then
                            Poker.CompareFOKonTableMsg()
                        Else

                            Poker.FullHouse()

                            If P1FullHouseFound = True Or P2FullHouseFound = True Then
                                Poker.CompareFullHouseMsg()
                            Else

                                Poker.CompareFlush(P1Card1, P1Card2, P2Card1, P2Card2)

                                If P1FlushFound = True Or P2FlushFound = True Then
                                    Poker.CompareFlushMsg()
                                Else

                                    Poker.CompareFlushOnTable(FlopCard1, FlopCard2, FlopCard3, TurnCard, RiverCard)

                                    If FlushOnTableFound = True Then
                                        Poker.CompareFlushOnTableMsg()
                                    Else

                                        Poker.Straight(P1Card1, P1Card2, P2Card1, P2Card2)

                                        If P1StraightFound = True Or P2StraightFound = True Then
                                            Poker.CompareStraightMsg()
                                        Else

                                            Poker.StraightOnTable(FlopCard1, FlopCard2, FlopCard3, TurnCard, RiverCard)

                                            If StraightOnTableFound = True Then
                                                Poker.CompareStraightOntableMsg()
                                            Else
                                                Poker.StraightTo5()
                                                If P1StraightTo5Found = True Or P1StraightTo5Found = True Then
                                                    Poker.CompareStraightTo5Msg()
                                                Else

                                                    Poker.CompareThreeOfAKind()

                                                    If P1ThreeofAKind = True Or P2ThreeofAKind = True Then
                                                        Poker.CompareThreeOfAKindMsg()
                                                    Else

                                                        Poker.CompareThreeOfAKindonTable(FlopCard1, FlopCard2, FlopCard3, TurnCard, RiverCard)

                                                        If TOKOnTablefound = True Then
                                                            Poker.CompareTOKonTableMsg()
                                                        Else

                                                            Poker.CompareTwoPairs(P1Card1, P1Card2, P2Card1, P2Card2)

                                                            If P1TwoPairsFound = True Or P2TwoPairsFound = True Then

                                                                Poker.CompareTwoPairsMsg()
                                                            Else
                                                                Poker.CompareTwoPairsOnTable()
                                                                If TwoPairsOnTableFound = True Then
                                                                    Poker.CompareTwoPairsOnTableMsg()

                                                                Else

                                                                    Poker.ComparePair(P1Card1, P1Card2, P2Card1, P2Card2)

                                                                    If P1PairFound = True Or P2PairFound = True Then
                                                                        Poker.ComparePairMsg()

                                                                    Else

                                                                        Poker.ComparePairOnTable()

                                                                        If PairOnTableFound = True Then

                                                                            Poker.CoomparePairOnTableMsg()

                                                                        Else

                                                                            Poker.CompareHighCardOnTable()
                                                                            Poker.CompareHighcardMsgOnTable()
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Deal"
    Private Sub btnDeal_Click(sender As Object, e As EventArgs) Handles btnDeal.Click
        Dim rand As New Random
        MyDeck = New Deck
        Dim PicCnt As Integer = 0

        ClearImages()
        ClearAll()
        'MyDeck.shuffle()

        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        lstDeck.Clear()
        cnt = 0


        FlopCard1 = MyDeck.getCard(0)
        lstDeck.Add(FlopCard1)
        ListBox4.Items.Add(FlopCard1)
        PictureBox4.Load(MyPath & FlopCard1.ToString() & ".png")
        cnt += 1

        FlopCard2 = MyDeck.getCard(2)
        lstDeck.Add(FlopCard2)
        ListBox4.Items.Add(FlopCard2)
        PictureBox5.Load(MyPath & FlopCard2.ToString() & ".png")
        cnt += 1

        FlopCard3 = MyDeck.getCard(4)
        lstDeck.Add(FlopCard3)
        ListBox4.Items.Add(FlopCard3)
        PictureBox6.Load(MyPath & FlopCard3.ToString() & ".png")
        cnt += 1

        'MyDeck.Turn = True
        'TurnCard = MyDeck.getCard(19)
        'lstDeck.Add(TurnCard)
        'ListBox4.Items.Add(TurnCard)
        'PictureBox7.Load(MyPath & TurnCard.ToString() & ".png")
        'cnt += 1

        'MyDeck.River = True
        'RiverCard = MyDeck.getCard(24)
        'lstDeck.Add(RiverCard)
        'ListBox4.Items.Add(RiverCard)
        'PictureBox8.Load(MyPath & RiverCard.ToString() & ".png")
        'cnt += 1

        '/////////////////////////////////////////////



        P1Card1 = MyDeck.getCard(8)
        ListBox2.Items.Add(P1Card1)
        PictureBox0.Load(MyPath & P1Card1.ToString() & ".png")
        cnt += 1

        P1Card2 = MyDeck.getCard(48)
        ListBox2.Items.Add(P1Card2)
        PictureBox1.Load(MyPath & P1Card2.ToString() & ".png")
        cnt += 1

        P2Card1 = MyDeck.getCard(49)
        ListBox3.Items.Add(P2Card1)
        PictureBox2.Load(MyPath & P2Card1.ToString() & ".png")
        cnt += 1

        P2Card2 = MyDeck.getCard(9)
        ListBox3.Items.Add(P2Card2)
        PictureBox3.Load(MyPath & P2Card2.ToString() & ".png")
        cnt += 1


        Player1.Turn = True
        'btnCompare_Click(sender, New System.EventArgs)
    End Sub

    Sub openCards()
        If cnt = 7 Then
            MyDeck.Turn = True
            TurnCard = MyDeck.getCard(cnt)
            lstDeck.Add(TurnCard)
            ListBox4.Items.Add(TurnCard)
            PictureBox7.Load(MyPath & TurnCard.ToString() & ".png")
        End If

        If cnt = 8 Then
            MyDeck.River = True
            RiverCard = MyDeck.getCard(cnt)
            lstDeck.Add(RiverCard)
            ListBox4.Items.Add(RiverCard)
            PictureBox8.Load(MyPath & RiverCard.ToString() & ".png")
        End If

        If cnt > 8 Then
            btnCompare.PerformClick()
            btnStart.PerformClick()
            cnt = 6
        End If
        lblCntMeter.Text = cnt
    End Sub
#End Region

#Region "Sub For Clearing All Card Images"
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
#End Region

#Region "PLAYING BUTTONS"
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

        btnDeal_Click(sender, New EventArgs())

        MyDeck.Flop = True
        MyDeck.Turn = False
        MyDeck.River = False

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
#End Region

#Region "Test Button For Testing Methods"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim lstFlop As New List(Of Card)
        Dim Cnt As Integer = 1


        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 0 To lstFlop.Count - 1
            If i <= 5 Then
                If lstFlop(i).rank - lstFlop(i + 1).rank = 0 Then
                    Cnt += 1
                Else
                    If Cnt >= 3 Then
                        If Not IsNothing(P1HighPair) Then
                            If lstFlop(i - 1).rank > P1HighPair.rank Then
                                P1LowPair = P1HighPair
                                P1HighPair = lstFlop(i - 1)
                            End If
                        Else
                            P1HighPair = lstFlop(i - 1)
                        End If
                    ElseIf Cnt = 2 Then
                        If Not IsNothing(P1LowPair) Then
                            If lstFlop(i - 1).rank > P1LowPair.rank Then
                                P1LowPair = lstFlop(i - 1)
                            End If
                        Else
                            P1LowPair = lstFlop(i - 1)
                        End If
                    End If
                    Cnt = 1
                End If
            End If

            If i > 5 Then
                If Cnt >= 3 Then
                    If Not IsNothing(P1HighPair) Then
                        If lstFlop(i - 1).rank > P1HighPair.rank Then
                            P1LowPair = P1HighPair
                            P1HighPair = lstFlop(i - 1)
                        End If
                    Else
                        P1HighPair = lstFlop(i - 1)
                    End If
                ElseIf Cnt = 2 Then
                    If Not IsNothing(P1LowPair) Then
                        If lstFlop(i - 1).rank > P1LowPair.rank Then
                            P1LowPair = lstFlop(i - 1)
                        End If
                    Else
                        P1LowPair = lstFlop(i - 1)
                    End If
                End If
            End If
        Next
    End Sub
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPlayer1.Parent = PictureBox16
        lblPlayer2.Parent = PictureBox16
        Label1.Parent = PictureBox16
        Label2.Parent = PictureBox16
        Label3.Parent = PictureBox16
        lblPotValue.Parent = PictureBox16

        PictureBox4.Load(MyPath & "\Card Deck Back Side.png")
        PictureBox5.Load(MyPath & "\Card Deck Back Side.png")
        PictureBox6.Load(MyPath & "\Card Deck Back Side.png")
        PictureBox7.Load(MyPath & "\Card Deck Back Side.png")
        PictureBox8.Load(MyPath & "\Card Deck Back Side.png")
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
        Deuce = 1
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
        Ace
    End Enum

End Class

