Imports System.Windows.Forms
Imports Cards.Form1
Public Class Game

#Region "High Card On Table"
    Sub CompareHighCardOnTable()
        Dim lstFlop As New List(Of Card)

        Form1.ClearAll()

        lstFlop.Clear()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        lstFlop.Sort(Function(x, y) y.rank.CompareTo(x.rank))

        Player1.HighPair = lstFlop(0)

        lstFlop.RemoveAll(Function(x) x.rank = Player1.HighPair.rank)

        Player1.Kicker1 = lstFlop(0)
        Player1.Kicker2 = lstFlop(1)
        Player1.Kicker3 = lstFlop(2)
        Player1.Kicker4 = lstFlop(3)



        lstFlop.Clear()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        lstFlop.Sort(Function(x, y) y.rank.CompareTo(x.rank))

        Player2.HighPair = lstFlop(0)

        lstFlop.RemoveAll(Function(x) x.rank = Player2.HighPair.rank)

        Player2.Kicker1 = lstFlop(0)
        Player2.Kicker2 = lstFlop(1)
        Player2.Kicker3 = lstFlop(2)
        Player2.Kicker4 = lstFlop(3)

    End Sub

    Sub CompareHighcardMsgOnTable()


        If Player1.HighPair.rank > Player2.HighPair.rank Then
            Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Card of " & Player1.HighPair.rank.ToString())
        ElseIf Player2.HighPair.rank > Player1.HighPair.rank Then
            Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Card of " & Player2.HighPair.rank.ToString())
        ElseIf Player1.HighPair.rank = Player2.HighPair.rank Then
            If Player1.Kicker1.rank > Player2.Kicker1.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Card of " & Player1.HighPair.rank.ToString() & " With Kicker " & Player1.Kicker1.rank.ToString())
            ElseIf Player2.Kicker1.rank > Player1.Kicker1.rank Then
                Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Card of " & Player2.HighPair.rank.ToString() & " With Kicker " & Player2.Kicker1.rank.ToString())
            ElseIf Player1.Kicker1.rank = Player2.Kicker1.rank Then
                If Player1.Kicker2.rank > Player2.Kicker2.rank Then
                    Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Card of " & Player1.HighPair.rank.ToString() & " With Kicker " & Player1.Kicker2.rank.ToString())
                ElseIf Player2.Kicker2.rank > Player1.Kicker2.rank Then
                    Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Card of " & Player2.HighPair.rank.ToString() & " With Kicker " & Player2.Kicker2.rank.ToString())
                ElseIf Player1.Kicker2.rank = Player2.Kicker2.rank Then
                    If Player1.Kicker3.rank > Player2.Kicker3.rank Then
                        Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Card of " & Player1.HighPair.rank.ToString() & " With Kicker " & Player1.Kicker3.rank.ToString())
                    ElseIf Player2.Kicker3.rank > Player1.Kicker3.rank Then
                        Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Card of " & Player2.HighPair.rank.ToString() & " With Kicker " & Player2.Kicker3.rank.ToString())
                    ElseIf Player1.Kicker3.rank = Player2.Kicker3.rank Then
                        If Player1.Kicker4.rank > Player2.Kicker4.rank Then
                            Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Card of " & Player1.HighPair.rank.ToString() & " With Kicker " & Player1.Kicker4.rank.ToString())
                        ElseIf Player2.Kicker4.rank > Player1.Kicker4.rank Then
                            Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Card of " & Player2.HighPair.rank.ToString() & " With Kicker " & Player2.Kicker4.rank.ToString())
                        ElseIf Player1.Kicker4.rank = Player2.Kicker4.rank Then
                            Form1.ListBox5.Items.Add(Player1.Name & " and " & Player2.Name & " Both Have A Higher Card of " & Player1.HighPair.rank.ToString() & " With Kicker " & Player1.Kicker1.rank.ToString())
                        End If
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Pair"
    Sub ComparePair(card1 As Card, Card2 As Card, card3 As Card, card4 As Card)
        Form1.ClearAll()


        If card1.rank = Card2.rank Then
            P1PairFound = True
            P1HighPair = card1
        End If

        If card3.rank = card4.rank Then
            P2PairFound = True
            P2HighPair = card3
        End If

        For Each Crd In lstDeck
            If card1.rank = Crd.rank Then
                If IsNothing(P1HighPair) Then
                    P1HighPair = Crd
                    P1PairFound = True
                    'P1PicPos = FlopPicPosP1
                ElseIf Crd.rank > P1HighPair.rank Then
                    P1HighPair = Crd
                    'P1PicPos = FlopPicPosP1
                End If
            End If

            If Card2.rank = Crd.rank Then
                If Card2.rank = Crd.rank Then
                    If IsNothing(P1HighPair) Then
                        P1HighPair = Crd
                        P1PairFound = True
                        'P1PicPos = FlopPicPosP1
                    ElseIf Crd.rank > P1HighPair.rank Then
                        P1HighPair = Crd
                        'P1PicPos = FlopPicPosP1
                    End If
                End If
            End If
            'FlopPicPosP1 += 1
        Next


        For Each Crd In lstDeck
            If card3.rank = Crd.rank Then
                If IsNothing(P2HighPair) Then
                    P2HighPair = Crd
                    P2PairFound = True
                    'P2PicPos = FlopPicPosP2
                ElseIf Crd.rank > P2HighPair.rank Then
                    P2HighPair = Crd
                    'P2PicPos = FlopPicPosP2
                End If
            End If

            If card4.rank = Crd.rank Then
                If card4.rank = Crd.rank Then
                    If IsNothing(P2HighPair) Then
                        P2HighPair = Crd
                        P2PairFound = True
                        'P2PicPos = FlopPicPosP2
                    ElseIf Crd.rank > P2HighPair.rank Then
                        P2HighPair = Crd
                        'P2PicPos = FlopPicPosP2
                    End If
                End If
            End If
            'FlopPicPosP2 += 1
        Next

    End Sub

    Sub ComparePairMsg()
        If P1PairFound = True And P2PairFound = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Pair of " & P1HighPair.rank.ToString())
                Form1.ListBox5.Items.Add(Player2.Name & " Has A Lower Pair of " & P2HighPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            ElseIf P1HighPair.rank = P2HighPair.rank Then
                Form1.ListBox5.Items.Add("Both Players Have Same Pair of " & P2HighPair.rank.ToString())
            Else
                Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Pair of " & P2HighPair.rank.ToString())
                Form1.ListBox5.Items.Add(Player1.Name & " Has A Lower Pair of " & P1HighPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P2PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P2PicPos), True)(0), PictureBox).Top - 10
            End If
        End If

        If P1PairFound = True And P2PairFound = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Pair of " & P1HighPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        End If

        If P1PairFound = False And P2PairFound = True Then
            Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Pair of " & P2HighPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P2PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P2PicPos), True)(0), PictureBox).Top - 10
        End If

        If P1PairFound = False And P2PairFound = False Then

            Form1.ListBox5.Items.Add("No Pairs Found")

        End If
    End Sub
#End Region

#Region "Pair On Table"
    Sub ComparePairOnTable()
        Dim lstFlop As New List(Of Card)
        Form1.ClearAll()

        lstDeck.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 1 To lstDeck.Count - 1
            If (lstDeck(i).rank - lstDeck(i - 1).rank) = 0 Then
                If Not IsNothing(HighPair) Then
                    If lstDeck(i).rank > HighPair.rank Then
                        HighPair = lstDeck(i)
                        PairOnTableFound = True
                    End If
                Else
                    HighPair = lstDeck(i)
                    PairOnTableFound = True
                End If
            End If
        Next

        For i = 1 To lstDeck.Count - 1
            If i <= lstDeck.Count - 1 Then
                If lstDeck(i).rank = lstDeck(i - 1).rank Then
                    lstDeck.RemoveAt(i)
                    lstDeck.RemoveAt(i - 1)
                    i -= 1
                    'If i = 0 Then i = 1

                End If
            End If
        Next

        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        For i = 0 To lstDeck.Count - 1
            lstFlop.Add(lstDeck(i))
        Next

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        P1HighPair = lstFlop(lstFlop.Count - 1)
        Player1.Kicker1 = lstFlop(lstFlop.Count - 2)
        Player1.Kicker2 = lstFlop(lstFlop.Count - 3)
        'Player1.Kicker3 = lstFlop(lstFlop.Count - 4)

        lstFlop.Clear()

        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        For i = 0 To lstDeck.Count - 1
            lstFlop.Add(lstDeck(i))
        Next

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        P2HighPair = lstFlop(lstFlop.Count - 1)
        Player2.Kicker1 = lstFlop(lstFlop.Count - 2)
        Player2.Kicker2 = lstFlop(lstFlop.Count - 3)
        'Player2.Kicker3 = lstFlop(lstFlop.Count - 4)

    End Sub

    Sub CoomparePairOnTableMsg()
        If P1HighPair.rank > P2HighPair.rank Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins With High Pair " & HighPair.rank.ToString() & " Kicker " & P1HighPair.rank.ToString())
        ElseIf P2HighPair.rank > P1HighPair.rank Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins With High Pair " & HighPair.rank.ToString() & " Kicker " & P2HighPair.rank.ToString())
        ElseIf P1HighPair.rank = P2HighPair.rank Then
            If Player1.Kicker1.rank > Player2.Kicker1.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Wins With High Pair " & HighPair.rank.ToString() & " Kicker " & Player1.Kicker1.rank.ToString())
            ElseIf Player2.Kicker1.rank > Player1.Kicker1.rank Then
                Form1.ListBox5.Items.Add(Player2.Name & " Wins With High Pair " & HighPair.rank.ToString() & " Kicker " & Player2.Kicker1.rank.ToString())
            ElseIf Player1.Kicker1.rank = Player2.Kicker1.rank Then
                If Player1.Kicker2.rank > Player2.Kicker2.rank Then
                    Form1.ListBox5.Items.Add(Player1.Name & " Wins With High Pair " & HighPair.rank.ToString() & " Kicker " & Player1.Kicker2.rank.ToString())
                ElseIf Player2.Kicker2.rank > Player1.Kicker2.rank Then
                    Form1.ListBox5.Items.Add(Player2.Name & " Wins With High Pair " & HighPair.rank.ToString() & " Kicker " & Player2.Kicker2.rank.ToString())
                ElseIf Player1.Kicker2.rank = Player2.Kicker2.rank Then
                    'If Player1.Kicker3.rank > Player2.Kicker3.rank Then
                    'Form1.ListBox5.Items.Add(Player1.Name & " Wins With High Pair " & HighPair.rank.ToString() & " Kicker " & Player1.Kicker3.rank.ToString())
                    'ElseIf Player2.Kicker3.rank > Player1.Kicker3.rank Then
                    'Form1.ListBox5.Items.Add(Player2.Name & " Wins With High Pair " & HighPair.rank.ToString() & " Kicker " & Player2.Kicker3.rank.ToString())
                    'ElseIf Player1.Kicker3.rank = Player2.Kicker3.rank Then
                    Form1.ListBox5.Items.Add(Player1.Name & " " & Player2.Name & " Win With High Pair " & HighPair.rank.ToString() & " Kicker " & P1HighPair.rank.ToString())
                End If

            End If
        End If
    End Sub
#End Region

#Region "Two Pairs"
    Sub CompareTwoPairs(card1 As Card, card2 As Card, card3 As Card, card4 As Card)
        Form1.ClearAll()

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
                Form1.ListBox5.Items.Add(Player1.Name & " Won By 2 Pairs of " & P1HighPair.rank.ToString() & " and " & P1LowPair.rank.ToString())
            Else
                Form1.ListBox5.Items.Add(Player2.Name & " Won By 2 Pairs of " & P2HighPair.rank.ToString() & " and " & P2LowPair.rank.ToString())
            End If
        End If

        If P1TwoPairsFound = True And P2TwoPairsFound = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Won By 2 Pairs of " & P1HighPair.rank.ToString() & " and " & P1LowPair.rank.ToString())
        End If

        If P1TwoPairsFound = False And P2TwoPairsFound = True Then
            Form1.ListBox5.Items.Add(Player2.Name & " Won By 2 Pairs of " & P2HighPair.rank.ToString() & " and " & P2LowPair.rank.ToString())
        End If
    End Sub
#End Region

#Region "Two Pairs On Table"
    Sub CompareTwoPairsOnTable()
        Dim lstFlop As New List(Of Card)

        Form1.ClearAll()

        lstDeck.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 1 To lstDeck.Count - 1
            If i <= lstDeck.Count - 1 Then
                If lstDeck(i).rank = lstDeck(i - 1).rank Then
                    If IsNothing(TablePair1) Then
                        TablePair1 = lstDeck(i)
                    Else
                        TablePair2 = lstDeck(i)
                    End If
                    lstDeck.RemoveAt(i)
                    lstDeck.RemoveAt(i - 1)
                    i -= 1

                End If
            End If
        Next

        If Not IsNothing(TablePair1) And Not IsNothing(TablePair2) Then
            TwoPairsOnTableFound = True
        End If

        If P1Card1.rank > P1Card2.rank Then
            Player1.Kicker1 = P1Card1
        Else
            Player1.Kicker1 = P1Card2
        End If

        If Player1.Kicker1.rank > lstDeck(lstDeck.Count - 1).rank Then
            P1HighPair = Player1.Kicker1
        Else
            P1HighPair = lstDeck(lstDeck.Count - 1)
        End If




        If P2Card1.rank > P2Card2.rank Then
            Player2.Kicker1 = P2Card1
        Else
            Player2.Kicker1 = P2Card2
        End If

        If Player2.Kicker1.rank > lstDeck(lstDeck.Count - 1).rank Then
            P2HighPair = Player2.Kicker1
        Else
            P2HighPair = lstDeck(lstDeck.Count - 1)
        End If

    End Sub

    Sub CompareTwoPairsOnTableMsg()
        If P1HighPair.rank > P2HighPair.rank Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins With Two Pairs Of " & TablePair1.rank.ToString() & " and " & TablePair2.rank.ToString() & " Kicker " & P1HighPair.rank.ToString())
        ElseIf P2HighPair.rank > P1HighPair.rank Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins With Two Pairs Of " & TablePair1.rank.ToString() & " and " & TablePair2.rank.ToString() & " Kicker " & P2HighPair.rank.ToString())
        Else
            Form1.ListBox5.Items.Add(Player1.Name & " and " & Player2.Name & " Win With Two Pairs Of " & TablePair1.rank.ToString() & " and " & TablePair2.rank.ToString() & " Kicker " & P1HighPair.rank.ToString())
        End If

    End Sub
#End Region

#Region "Three Of A Kind On Table"
    Sub CompareThreeOfAKindonTable(card1 As Card, card2 As Card, card3 As Card, card4 As Card, card5 As Card)
        Dim cnt As Integer

        Form1.ClearAll()

        For i = 1 To lstDeck.Count - 1
            If (lstDeck(i).rank - lstDeck(i - 1).rank) = 0 Then
                cnt += 1
                HighPair = lstDeck(i)
            Else
                If cnt < 2 Then
                    HighPair = Nothing
                    cnt = 0
                End If
            End If
        Next

        If cnt >= 2 Then
            TOKOnTablefound = True
        End If

    End Sub

    Sub CompareTOKonTableMsg()
        Form1.ListBox5.Items.Add("All Players Win With Three Of A Kind's of " & HighPair.rank.ToString())
    End Sub
#End Region

#Region "Three Of A Kind"
    Sub CompareThreeOfAKind()
        Dim lstFlop As New List(Of Card)
        Dim intTOK1 As Integer = 1
        Dim intTOK2 As Integer = 1

        Form1.ClearAll()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 0 To lstFlop.Count - 2
            If lstFlop(i).rank = lstFlop(i + 1).rank Then
                intTOK1 += 1
                If intTOK1 >= 3 Then
                    P1HighPair = lstFlop(i)
                    P1ThreeofAKind = True
                End If
            Else
                intTOK1 = 1
            End If
        Next

        If P1ThreeofAKind = True Then
            lstFlop.RemoveAll(Function(x) x.rank = P1HighPair.rank)
        End If

        lstFlop.Sort(Function(x, y) y.rank.CompareTo(x.rank))

        Player1.Kicker1 = lstFlop(0)
        Player1.Kicker2 = lstFlop(1)


        lstFlop.Clear()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 0 To lstFlop.Count - 2
            If lstFlop(i).rank = lstFlop(i + 1).rank Then
                intTOK2 += 1
                If intTOK2 >= 3 Then
                    P2HighPair = lstFlop(i)
                    P2ThreeofAKind = True
                End If
            Else
                intTOK2 = 1
            End If
        Next

        If P2ThreeofAKind = True Then
            lstFlop.RemoveAll(Function(x) x.rank = P2HighPair.rank)
        End If

        lstFlop.Sort(Function(x, y) y.rank.CompareTo(x.rank))

        Player2.Kicker1 = lstFlop(0)
        Player2.Kicker2 = lstFlop(1)

    End Sub

    Sub CompareThreeOfAKindMsg()
        If P1ThreeofAKind = True And P2ThreeofAKind = False Then
                Form1.ListBox5.Items.Add(Player1.Name & " Wins With Three of Kinds of " & P1HighPair.rank.ToString())
        ElseIf P2ThreeofAKind = True And P1ThreeofAKind = False Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins With Three of Kinds of " & P1HighPair.rank.ToString())
        ElseIf P2ThreeofAKind = True And P1ThreeofAKind = True Then
            If Player1.Kicker1.rank > Player2.Kicker1.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Wins With Three of Kinds of " & P1HighPair.rank.ToString() & " With Kicker " & Player1.Kicker1.rank.ToString())
            ElseIf Player2.Kicker1.rank > Player1.Kicker1.rank Then
                Form1.ListBox5.Items.Add(Player2.Name & " Wins With Three of Kinds of " & P2HighPair.rank.ToString() & " With Kicker " & Player2.Kicker1.rank.ToString())
            ElseIf Player1.Kicker1.rank = Player2.Kicker1.rank Then
                If Player1.Kicker2.rank > Player2.Kicker2.rank Then
                    Form1.ListBox5.Items.Add(Player1.Name & " Wins With Three of Kinds of " & P1HighPair.rank.ToString() & " With Kicker " & Player1.Kicker2.rank.ToString())
                ElseIf Player2.Kicker2.rank > Player1.Kicker2.rank Then
                    Form1.ListBox5.Items.Add(Player2.Name & " Wins With Three of Kinds of " & P2HighPair.rank.ToString() & " With Kicker " & Player2.Kicker2.rank.ToString())
                ElseIf Player1.Kicker2.rank = Player2.Kicker2.rank Then
                    Form1.ListBox5.Items.Add(Player1.Name & " and " & Player2.Name & " Both Win With Three of Kinds of " & P1HighPair.rank.ToString() & " With Kicker " & Player1.Kicker2.rank.ToString())
                End If
            End If
            End If
    End Sub
#End Region

#Region "StraightTo5"
    Sub StraightTo5()
        Dim lstFlop As New List(Of Card)
        Dim Afound As Boolean = False
        Dim TwoFound As Boolean = False
        Dim ThreeFound As Boolean = False
        Dim FourFound As Boolean = False
        Dim FiveFound As Boolean = False

        Form1.ClearAll()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        For Each crd In lstFlop
            If crd.rank = CardHolder.Rank.Ace Then
                Afound = True
            ElseIf crd.rank = CardHolder.Rank.Deuce Then
                TwoFound = True
            ElseIf crd.rank = CardHolder.Rank.Three Then
                ThreeFound = True
            ElseIf crd.rank = CardHolder.Rank.Four Then
                FourFound = True
            ElseIf crd.rank = CardHolder.Rank.Five Then
                FiveFound = True
            End If
        Next

        If Afound = True And TwoFound = True And ThreeFound = True And FourFound = True And FiveFound = True Then
            P1StraightTo5Found = True
        End If

        lstFlop.Clear()

        Afound = False
        TwoFound = False
        ThreeFound = False
        FourFound = False
        FiveFound = False

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        For Each crd In lstFlop
            If crd.rank = CardHolder.Rank.Ace Then
                Afound = True
            ElseIf crd.rank = CardHolder.Rank.Deuce Then
                TwoFound = True
            ElseIf crd.rank = CardHolder.Rank.Three Then
                ThreeFound = True
            ElseIf crd.rank = CardHolder.Rank.Four Then
                FourFound = True
            ElseIf crd.rank = CardHolder.Rank.Five Then
                FiveFound = True
            End If
        Next

        If Afound = True And TwoFound = True And ThreeFound = True And FourFound = True And FiveFound = True Then
            P2StraightTo5Found = True
        End If

    End Sub

    Sub CompareStraightTo5Msg()

        If P1StraightTo5Found = True And P2StraightTo5Found = True Then
            Form1.ListBox5.Items.Add(Player1.Name & " and " & Player2.Name & " Both Win with Straight to Five")
        ElseIf P1StraightTo5Found = True And P2StraightTo5Found = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins with Straight to Five")
        ElseIf P2StraightTo5Found = True And P1StraightTo5Found = False Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins with Straight to Five")
        End If
    End Sub
#End Region

#Region "Straight"
    Sub Straight(card1 As Card, card2 As Card, card3 As Card, card4 As Card)
        Dim lstFlop As New List(Of Card)
        Dim Cnt As Integer

        Form1.ClearAll()



        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 1 To lstFlop.Count - 1
            If i < lstFlop.Count Then
                If (lstFlop(i).rank - lstFlop(i - 1).rank) = 0 Then
                    lstFlop.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next

        For i = 1 To lstFlop.Count - 1
            If (lstFlop(i).rank - lstFlop(i - 1).rank) = 1 Then
                Cnt += 1
                If Cnt >= 4 Then
                    P1HighPair = lstFlop(i)
                End If
            Else
                'If Cnt < 4 Then
                Cnt = 0
                'End If
            End If
        Next


        If Cnt >= 4 Then
            'MsgBox(Player1.Name & " Straight to " & P1HighPair & " Found")
            P1StraightFound = True
        End If

        Cnt = 0
        lstFlop.Clear()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 1 To lstFlop.Count - 1
            If i < lstFlop.Count Then
                If (lstFlop(i).rank - lstFlop(i - 1).rank) = 0 Then
                    lstFlop.RemoveAt(i)
                    i -= 1
                End If
            End If
        Next

        For i = 1 To lstFlop.Count - 1
            If (lstFlop(i).rank - lstFlop(i - 1).rank) = 1 Then
                Cnt += 1
                If Cnt >= 4 Then
                    P2HighPair = lstFlop(i)
                End If
            Else
                'If Cnt < 4 Then
                Cnt = 0
                'End If
            End If
        Next


        If Cnt >= 4 Then
            'MsgBox(Player2.Name & " Straight to " & P2HighPair & " Found")
            P2StraightFound = True
        End If

    End Sub

    Sub CompareStraightMsg()

        If P1StraightFound = True And P2StraightFound = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Wins with Straight to " & P1HighPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            ElseIf P2HighPair.rank > P1HighPair.rank Then
                Form1.ListBox5.Items.Add(Player2.Name & " Wins with Straight to " & P2HighPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            ElseIf P1HighPair.rank = P2HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " & " & Player2.Name & " Wins with Straight to " & P1HighPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            End If
        ElseIf P1StraightFound = True And P2StraightFound = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins with Straight to " & P1HighPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        ElseIf P2StraightFound = True And P1StraightFound = False Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins with Straight to " & P2HighPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        End If
    End Sub
#End Region

#Region "Straight On Table"
    Sub StraightOnTable(card1 As Card, card2 As Card, card3 As Card, card4 As Card, card5 As Card)
        Dim lstFlop As New List(Of Card)
        Dim Cnt As Integer

        Form1.ClearAll()



        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 1 To lstFlop.Count - 1
            If (lstFlop(i).rank - lstFlop(i - 1).rank) = 1 Then
                Cnt += 1
                If Cnt >= 4 Then
                    HighPair = lstFlop(i)
                End If
            Else
                Cnt = 0
            End If
        Next


        If Cnt >= 4 Then
            StraightOnTableFound = True
        End If

    End Sub

    Sub CompareStraightOntableMsg()
        Form1.ListBox5.Items.Add("Both Players Win With Straight To " & HighPair.rank.ToString())
    End Sub
#End Region

#Region "Flush"
    Sub CompareFlush(card1 As Card, card2 As Card, card3 As Card, card4 As Card)
        Dim lstFlop As New List(Of Card)
        Dim Cnt As Integer
        Dim intFlushP1 As Integer = 0
        Dim intFlushP2 As Integer = 0
        Dim Diamonds As Integer
        Dim Clubs As Integer
        Dim Hearts As Integer
        Dim Spades As Integer

        Form1.ClearAll()


        lstFlop.Add(FlopCard3)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard1)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))
        lstFlop.Sort(Function(x, y) x.suit.CompareTo(y.suit))

        For Each crd In lstFlop
            If crd.suit = CardHolder.Suit.Diamond Then
                Diamonds += 1
            ElseIf crd.suit = CardHolder.Suit.Club Then
                Clubs += 1
            ElseIf crd.suit = CardHolder.Suit.Spade Then
                Spades += 1
            Else
                Hearts += 1
            End If
        Next

        If Diamonds >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Diamond)
            P1FlushFound = True
        End If
        If Clubs >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Club)
            P1FlushFound = True
        End If
        If Spades >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Spade)
            P1FlushFound = True
        End If
        Hearts += 1
        If Hearts >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Heart)
            P1FlushFound = True
        End If

        lstFlop.Sort(Function(x, y) y.rank.CompareTo(x.rank))

        Player1.HighPair = lstFlop(0)

        Cnt = 0
        lstFlop.Clear()

        Diamonds = 0
        Spades = 0
        Clubs = 0
        Hearts = 0

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        lstFlop.Sort(Function(x, y) x.suit.CompareTo(y.suit))
        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For Each crd In lstFlop
            If crd.suit = CardHolder.Suit.Diamond Then
                Diamonds += 1
            ElseIf crd.suit = CardHolder.Suit.Club Then
                Clubs += 1
            ElseIf crd.suit = CardHolder.Suit.Spade Then
                Spades += 1
            Else
                Hearts += 1
            End If
        Next

        If Diamonds >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Diamond)
            P2FlushFound = True
        End If
        If Clubs >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Club)
            P2FlushFound = True
        End If
        If Spades >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Spade)
            P2FlushFound = True
        End If
        Hearts += 1
        If Hearts >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Heart)
            P2FlushFound = True
        End If

        lstFlop.Sort(Function(x, y) y.rank.CompareTo(x.rank))

        Player2.HighPair = lstFlop(0)

    End Sub

    Sub CompareFlushMsg()
        If P1FlushFound = True And P2FlushFound = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins With Flush " & Player1.HighPair.rank.ToString() & " High")
        ElseIf P2FlushFound = True And P1FlushFound = False Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins With Flush " & Player2.HighPair.rank.ToString() & " High")
        ElseIf P1FlushFound = True And P2FlushFound = True Then
            If Player1.HighPair.rank > Player2.HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Wins With Flush " & Player1.HighPair.rank.ToString() & " High")
            ElseIf Player2.HighPair.rank > Player1.HighPair.rank Then
                Form1.ListBox5.Items.Add(Player2.Name & " Wins With Flush " & Player2.HighPair.rank.ToString() & " High")
            ElseIf Player1.HighPair.rank = Player2.HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " and " & Player2.Name & " Both Win With Flush " & Player1.HighPair.rank.ToString() & " High")
            End If
        End If
    End Sub
#End Region

#Region "Flush On Table"
    Sub CompareFlushOnTable(card1 As Card, card2 As Card, card3 As Card, card4 As Card, card5 As Card)
        Dim intFlush As Integer = 0

        Form1.ClearAll()

        For Each Crd In lstDeck
            If card1.suit = Crd.suit Then
                If Not IsNothing(HighPair) Then
                    If Crd.rank > HighPair.rank Then
                        HighPair = Crd
                    End If
                Else
                    HighPair = Crd
                End If
                intFlush += 1
            End If
        Next

        If intFlush > 4 Then
            FlushOnTableFound = True
        End If

    End Sub

    Sub CompareFlushOnTableMsg()
        Form1.ListBox5.Items.Add("All Players Win With Flush " & HighPair.rank.ToString() & "High")
    End Sub
#End Region

#Region "Full House"
    Sub FullHouse()
        Dim lstFlop As New List(Of Card)
        Dim Cnt As Integer = 1

        Form1.ClearAll()


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

        If Not IsNothing(P1HighPair) And Not IsNothing(P1LowPair) Then
            P1FullHouseFound = True
        End If


        Cnt = 1
        lstFlop.Clear()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 0 To lstFlop.Count - 1
            If i <= 5 Then
                If lstFlop(i).rank - lstFlop(i + 1).rank = 0 Then
                    Cnt += 1
                Else
                    If Cnt >= 3 Then
                        If Not IsNothing(P2HighPair) Then
                            If lstFlop(i - 1).rank > P2HighPair.rank Then
                                P2LowPair = P2HighPair
                                P2HighPair = lstFlop(i - 1)
                            End If
                        Else
                            P2HighPair = lstFlop(i - 1)
                        End If
                    ElseIf Cnt = 2 Then
                        If Not IsNothing(P2LowPair) Then
                            If lstFlop(i - 1).rank > P2LowPair.rank Then
                                P2LowPair = lstFlop(i - 1)
                            End If
                        Else
                            P2LowPair = lstFlop(i - 1)
                        End If
                    End If
                    Cnt = 1
                End If
            End If

            If i > 5 Then
                If Cnt >= 3 Then
                    If Not IsNothing(P2HighPair) Then
                        If lstFlop(i - 1).rank > P2HighPair.rank Then
                            P2LowPair = P2HighPair
                            P2HighPair = lstFlop(i - 1)
                        End If
                    Else
                        P2HighPair = lstFlop(i - 1)
                    End If
                ElseIf Cnt = 2 Then
                    If Not IsNothing(P2LowPair) Then
                        If lstFlop(i - 1).rank > P2LowPair.rank Then
                            P2LowPair = lstFlop(i - 1)
                        End If
                    Else
                        P2LowPair = lstFlop(i - 1)
                    End If
                End If
            End If
        Next

        If Not IsNothing(P2HighPair) And Not IsNothing(P2LowPair) Then
            P2FullHouseFound = True
        End If

    End Sub

    Sub CompareFullHouseMsg()

        If P1FullHouseFound = True And P2FullHouseFound = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Wins with Full House " & P1HighPair.rank.ToString() & " Full of " & P1LowPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            ElseIf P2HighPair.rank > P1HighPair.rank Then
                Form1.ListBox5.Items.Add(Player2.Name & " Wins with Full House " & P2HighPair.rank.ToString() & " Full of " & P2LowPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            ElseIf P1HighPair.rank = P2HighPair.rank Then
                If P1LowPair.rank > P2LowPair.rank Then
                    Form1.ListBox5.Items.Add(Player1.Name & " Wins with Full House " & P1HighPair.rank.ToString() & " Full of " & P1LowPair.rank.ToString())
                    'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
                ElseIf P2LowPair.rank > P1LowPair.rank Then
                    Form1.ListBox5.Items.Add(Player2.Name & " Wins with Full House " & P2HighPair.rank.ToString() & " Full of " & P2LowPair.rank.ToString())
                    'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
                Else
                    Form1.ListBox5.Items.Add(Player1.Name & " and " & Player2.Name & " Win with Full House " & P2HighPair.rank.ToString() & " Full of " & P2LowPair.rank.ToString())
                End If
            End If
        ElseIf P1FullHouseFound = True And P2FullHouseFound = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins with Full House " & P1HighPair.rank.ToString() & " Full of " & P1LowPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        ElseIf P2FullHouseFound = True And P1FullHouseFound = False Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins with Full House " & P2HighPair.rank.ToString() & " Full of " & P2LowPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        End If
    End Sub
#End Region

#Region "Four Of A Kind On Table"
    Sub CompareFOKonTable(card1 As Card, card2 As Card, card3 As Card, card4 As Card, card5 As Card)
        Dim cnt As Integer

        Form1.ClearAll()

        For i = 1 To lstDeck.Count - 1
            If (lstDeck(i).rank - lstDeck(i - 1).rank) = 0 Then
                cnt += 1
                If cnt = 3 Then
                    HighPair = lstDeck(i)
                    FOKOnTableFound = True
                End If
            Else
                cnt = 0
            End If
        Next

        'If cnt = 3 Then
        'FOKOnTableFound = True
        'End If

    End Sub

    Sub CompareFOKonTableMsg()
        Form1.ListBox5.Items.Add("All Players Win With Four Of A Kind's of " & HighPair.rank.ToString())
    End Sub
#End Region

#Region "Four Of A Kind"
    Sub CompareFOK(card1 As Card, card2 As Card, card3 As Card, card4 As Card)
        Dim intTOK1 As Integer = 1
        Dim intTOK2 As Integer = 1
        Dim intTOK3 As Integer = 1
        Dim intTOK4 As Integer = 1

        Form1.ClearAll()

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

        If intTOK1 > 3 Then
            P1HighPair = P1Pair1
            P1FOK = True
        End If

        If intTOK2 > 3 Then
            If Not IsNothing(P1HighPair) Then
                If P1Pair2.rank < P1HighPair.rank Then
                    P1HighPair = P1Pair1
                    P1FOK = True
                Else
                    P1HighPair = P1Pair2
                    P1FOK = True
                End If
            Else
                P1HighPair = P1Pair2
                P1FOK = True
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

        If intTOK3 > 3 Then
            P2HighPair = P2Pair1
            P2FOK = True
        End If

        If intTOK4 > 3 Then
            If Not IsNothing(P2HighPair) Then
                If P2Pair1.rank < P2HighPair.rank Then
                    P2HighPair = P2Pair1
                    P2FOK = True
                Else
                    P2HighPair = P2Pair2
                    P2FOK = True
                End If
            Else
                P2HighPair = P2Pair2
                P2FOK = True
            End If
        End If

    End Sub

    Sub CompareFOKMsg()
        If P1FOK = True And P2FOK = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Wins With Four of A Kind of " & P1HighPair.rank.ToString())
            Else
                Form1.ListBox5.Items.Add(Player2.Name & " Wins With Four of A Kind of " & P2HighPair.rank.ToString())
            End If
            If P1HighPair.rank = P2HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " and P2 Both Have " & P1HighPair.rank.ToString())
            End If
        ElseIf P1FOK = True Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins With Four of A Kind of " & P1HighPair.rank.ToString())
        ElseIf P2FOK = True Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins With Four of A Kind of " & P2HighPair.rank.ToString())
        End If
    End Sub
#End Region

#Region "Straight Flush To 5"
    '///////////////////////////STRAIGHT FLUSH\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Sub StraightFlushTo5()
        Dim lstFlop As New List(Of Card)
        Dim Cnt As Integer
        Dim intFlushP1 As Integer = 0
        Dim intFlushP2 As Integer = 0
        Dim Afound As Boolean = False
        Dim TwoFound As Boolean = False
        Dim ThreeFound As Boolean = False
        Dim FourFound As Boolean = False
        Dim FiveFound As Boolean = False
        Dim Diamonds As Integer
        Dim Clubs As Integer
        Dim Hearts As Integer
        Dim Spades As Integer

        Form1.ClearAll()


        lstFlop.Add(FlopCard3)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard1)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))
        lstFlop.Sort(Function(x, y) x.suit.CompareTo(y.suit))

        For Each crd In lstFlop
            If crd.suit = CardHolder.Suit.Diamond Then
                Diamonds += 1
            ElseIf crd.suit = CardHolder.Suit.Club Then
                Clubs += 1
            ElseIf crd.suit = CardHolder.Suit.Spade Then
                Spades += 1
            Else
                Hearts += 1
            End If
        Next

            If Diamonds >= 4 Then
                lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Diamond)
            End If
            If Clubs >= 4 Then
                lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Club)
            End If
            If Spades >= 4 Then
                lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Spade)
            End If
            Hearts += 1
            If Hearts >= 4 Then
                lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Heart)
            End If


        For Each crd In lstFlop
            If crd.rank = CardHolder.Rank.Ace Then
                Afound = True
            ElseIf crd.rank = CardHolder.Rank.Deuce Then
                TwoFound = True
            ElseIf crd.rank = CardHolder.Rank.Three Then
                ThreeFound = True
            ElseIf crd.rank = CardHolder.Rank.Four Then
                FourFound = True
            ElseIf crd.rank = CardHolder.Rank.Five Then
                FiveFound = True
            End If
        Next

        If Afound = True And TwoFound = True And ThreeFound = True And FourFound = True And FiveFound = True Then
            P1StraightFlushTo5Found = True
        End If


        Cnt = 0
        lstFlop.Clear()

        Afound = False
        TwoFound = False
        ThreeFound = False
        FourFound = False
        FiveFound = False
        Diamonds = 0
        Spades = 0
        Clubs = 0
        Hearts = 0

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        lstFlop.Sort(Function(x, y) x.suit.CompareTo(y.suit))
        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For Each crd In lstFlop
            If crd.suit = CardHolder.Suit.Diamond Then
                Diamonds += 1
            ElseIf crd.suit = CardHolder.Suit.Club Then
                Clubs += 1
            ElseIf crd.suit = CardHolder.Suit.Spade Then
                Spades += 1
            Else
                Hearts += 1
            End If
        Next

        If Diamonds >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Diamond)
        End If
        If Clubs >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Club)
        End If
        If Spades >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Spade)
        End If
        Hearts += 1
        If Hearts >= 4 Then
            lstFlop.RemoveAll(Function(x) x.suit <> CardHolder.Suit.Heart)
        End If


        For Each crd In lstFlop
            If crd.rank = CardHolder.Rank.Ace Then
                Afound = True
            ElseIf crd.rank = CardHolder.Rank.Deuce Then
                TwoFound = True
            ElseIf crd.rank = CardHolder.Rank.Three Then
                ThreeFound = True
            ElseIf crd.rank = CardHolder.Rank.Four Then
                FourFound = True
            ElseIf crd.rank = CardHolder.Rank.Five Then
                FiveFound = True
            End If
        Next

        If Afound = True And TwoFound = True And ThreeFound = True And FourFound = True And FiveFound = True Then
            P2StraightFlushTo5Found = True
        End If

    End Sub

    Sub CompareStraightFlushTo5Msg()
        If P1StraightFlushTo5Found = True And P2StraightFlushTo5Found = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins with StraightFlush to 5")
        ElseIf P2StraightFlushTo5Found = True And P1StraightFlushTo5Found = False Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins with StraightFlush to 5")
        ElseIf P1StraightFlushTo5Found = True And P2StraightFlushTo5Found = True Then
            Form1.ListBox5.Items.Add(Player1.Name & " and " & Player2.Name & " Both Win with StraightFlush to 5")
        End If
    End Sub
#End Region

#Region "Straight Flush"
    '///////////////////////////STRAIGHT FLUSH\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Sub StraightFlush(card1 As Card, card2 As Card, card3 As Card, card4 As Card, card5 As Card, card6 As Card, card7 As Card, card8 As Card, card9 As Card)
        Dim lstFlop As New List(Of Card)
        Dim Cnt As Integer
        Dim intFlushP1 As Integer = 0
        Dim intFlushP2 As Integer = 0

        Form1.ClearAll()



        lstFlop.Add(FlopCard3)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard1)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))
        lstFlop.Sort(Function(x, y) x.suit.CompareTo(y.suit))

        For i = 1 To lstFlop.Count - 1
            If i < lstFlop.Count Then
                If (lstFlop(i).rank - lstFlop(i - 1).rank) = 1 Then
                    If lstFlop(i).suit = lstFlop(i - 1).suit Then
                        intFlushP1 += 1
                        FlushCard = lstFlop(i)
                    Else
                        intFlushP1 = 0
                    End If
                    Cnt += 1
                    If Cnt >= 4 And intFlushP1 >= 4 Then
                        P1HighPair = lstFlop(i)
                        If lstFlop(i).rank < lstFlop(i - 1).rank Then
                            P1HighPair = lstFlop(i - 1)
                        End If
                        P1FlushFound = True
                        P1StraightFound = True
                    End If

                ElseIf (lstFlop(i).rank - lstFlop(i - 1).rank) <> 1 Then
                    lstFlop.RemoveAt(i - 1)
                    i -= 1
                    intFlushP1 = 0
                End If
            End If
        Next


        Cnt = 0
        lstFlop.Clear()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        lstFlop.Sort(Function(x, y) x.suit.CompareTo(y.suit))
        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 1 To lstFlop.Count - 1
            If i < lstFlop.Count Then
                If (lstFlop(i).rank - lstFlop(i - 1).rank) = 1 Then
                    If lstFlop(i).suit = lstFlop(i - 1).suit Then
                        intFlushP2 += 1
                        FlushCard = lstFlop(i)
                    Else
                        intFlushP2 = 0
                    End If
                    Cnt += 1
                    If Cnt >= 4 And intFlushP2 >= 4 Then
                        P2HighPair = lstFlop(i)
                        If lstFlop(i).rank < lstFlop(i - 1).rank Then
                            P2HighPair = lstFlop(i - 1)
                        End If
                        P2FlushFound = True
                        P2StraightFound = True
                    End If

                ElseIf (lstFlop(i).rank - lstFlop(i - 1).rank) <> 1 Then
                    lstFlop.RemoveAt(i - 1)
                    i -= 1
                    intFlushP2 = 0
                End If
            End If
        Next

    End Sub

    Sub CompareStraightFlushMsg()
        If P1FlushFound = True And P1StraightFound = True And P2FlushFound = True And P2StraightFound = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Wins with StraightFlush to " & P1HighPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            ElseIf P1HighPair.rank = P2HighPair.rank Then
                Form1.ListBox5.Items.Add("Both players have StraightFlush to " & P1HighPair.rank.ToString())
            Else
                Form1.ListBox5.Items.Add(Player2.Name & " Wins with StraightFlush to " & P2HighPair.rank.ToString())
                'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            End If
        ElseIf P1FlushFound = True And P1StraightFound = True Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins with StraightFlush to " & P1HighPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        ElseIf P2FlushFound = True And P2StraightFound = True Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins with StraightFlush to " & P2HighPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        End If
    End Sub
#End Region

#Region "Royal Flush"
    '///////////////////////////STRAIGHT FLUSH\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Sub RoyalFlush()
        Dim lstFlop As New List(Of Card)
        Dim Cnt As Integer
        Dim intFlushP1 As Integer = 0
        Dim intFlushP2 As Integer = 0

        Form1.ClearAll()



        lstFlop.Add(FlopCard3)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard1)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P1Card1)
        lstFlop.Add(P1Card2)

        lstFlop.Sort(Function(x, y) x.suit.CompareTo(y.suit))
        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))


        For i = 1 To lstFlop.Count - 1
            If i < lstFlop.Count Then
                If (lstFlop(i).rank - lstFlop(i - 1).rank) = 1 Then
                    If lstFlop(i).suit = lstFlop(i - 1).suit Then
                        intFlushP1 += 1
                        FlushCard = lstFlop(i)
                    Else
                        intFlushP1 = 0
                    End If
                    Cnt += 1
                    If Cnt >= 4 And intFlushP1 >= 4 Then
                        P1HighPair = lstFlop(i)
                        If P1HighPair.rank = CardHolder.Rank.Ace Then
                            P1RoyalFlushFound = True
                        End If
                    End If
                    'ElseIf (lstFlop(i).rank - lstFlop(i - 1).rank) <> 1 Then
                    'lstFlop.RemoveAt(i)
                    'i -= 1
                Else
                    Cnt = 0
                End If
            End If
        Next


        Cnt = 0
        lstFlop.Clear()

        lstFlop.Add(FlopCard1)
        lstFlop.Add(FlopCard2)
        lstFlop.Add(FlopCard3)
        lstFlop.Add(TurnCard)
        lstFlop.Add(RiverCard)
        lstFlop.Add(P2Card1)
        lstFlop.Add(P2Card2)

        lstFlop.Sort(Function(x, y) x.suit.CompareTo(y.suit))
        lstFlop.Sort(Function(x, y) x.rank.CompareTo(y.rank))

        For i = 1 To lstFlop.Count - 1
            If i < lstFlop.Count Then
                If (lstFlop(i).rank - lstFlop(i - 1).rank) = 1 Then
                    If lstFlop(i).suit = lstFlop(i - 1).suit Then
                        intFlushP2 += 1
                        FlushCard = lstFlop(i)
                        If lstFlop(i).rank > FlushCard.rank Then
                            FlushCard = lstFlop(i)
                        End If
                    Else
                        intFlushP2 = 0
                    End If
                    Cnt += 1
                    If Cnt >= 4 And intFlushP2 >= 4 Then
                        P2HighPair = FlushCard
                        If P2HighPair.rank = CardHolder.Rank.Ace Then
                            P2RoyalFlushFound = True
                        End If
                    End If
                ElseIf (lstFlop(i).rank - lstFlop(i - 1).rank) <> 1 Then
                    lstFlop.RemoveAt(i)
                    i -= 1
                Else
                    Cnt = 0
                End If
            End If
        Next

    End Sub

    Sub CompareRoyalFlushMsg()
        If P1RoyalFlushFound = True And P2RoyalFlushFound = True Then
            Form1.ListBox5.Items.Add(Player1.Name & Player2.Name & " Both Win with RoyalFlush")
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        ElseIf P1RoyalFlushFound = True And P2RoyalFlushFound = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Wins with RoyalFlush")
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        ElseIf P2RoyalFlushFound = True And P1RoyalFlushFound = False Then
            Form1.ListBox5.Items.Add(Player2.Name & " Wins with StraightFlush to " & P2HighPair.rank.ToString())
            'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = 'CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        End If
    End Sub
#End Region


End Class

