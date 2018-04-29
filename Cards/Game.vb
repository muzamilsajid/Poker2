Imports System.Windows.Forms
Imports Cards.Form1
Public Class Game
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
                    P1PicPos = FlopPicPosP1
                ElseIf Crd.rank > P1HighPair.rank Then
                    P1HighPair = Crd
                    P1PicPos = FlopPicPosP1
                End If
            End If

            If Card2.rank = Crd.rank Then
                If Card2.rank = Crd.rank Then
                    If IsNothing(P1HighPair) Then
                        P1HighPair = Crd
                        P1PairFound = True
                        P1PicPos = FlopPicPosP1
                    ElseIf Crd.rank > P1HighPair.rank Then
                        P1HighPair = Crd
                        P1PicPos = FlopPicPosP1
                    End If
                End If
            End If
            FlopPicPosP1 += 1
        Next


        For Each Crd In lstDeck
            If card3.rank = Crd.rank Then
                If IsNothing(P2HighPair) Then
                    P2HighPair = Crd
                    P2PairFound = True
                    P2PicPos = FlopPicPosP2
                ElseIf Crd.rank > P2HighPair.rank Then
                    P2HighPair = Crd
                    P2PicPos = FlopPicPosP2
                End If
            End If

            If card4.rank = Crd.rank Then
                If card4.rank = Crd.rank Then
                    If IsNothing(P2HighPair) Then
                        P2HighPair = Crd
                        P2PairFound = True
                        P2PicPos = FlopPicPosP2
                    ElseIf Crd.rank > P2HighPair.rank Then
                        P2HighPair = Crd
                        P2PicPos = FlopPicPosP2
                    End If
                End If
            End If
            FlopPicPosP2 += 1
        Next

    End Sub

    Sub ComparePairMsg()
        If P1PairFound = True And P2PairFound = True Then
            If P1HighPair.rank > P2HighPair.rank Then
                Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Pair of " & P1HighPair.rank.ToString())
                Form1.ListBox5.Items.Add(Player2.Name & " Has A Lower Pair of " & P2HighPair.rank.ToString())
                CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
            ElseIf P1HighPair.rank = P2HighPair.rank Then
                Form1.ListBox5.Items.Add("Both Players Have Same Pair of " & P2HighPair.rank.ToString())
            Else
                Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Pair of " & P2HighPair.rank.ToString())
                Form1.ListBox5.Items.Add(Player1.Name & " Has A Lower Pair of " & P1HighPair.rank.ToString())
                CType(Form1.Controls.Find("picturebox" + CStr(P2PicPos), True)(0), PictureBox).Top = CType(Form1.Controls.Find("picturebox" + CStr(P2PicPos), True)(0), PictureBox).Top - 10
            End If
        End If

        If P1PairFound = True And P2PairFound = False Then
            Form1.ListBox5.Items.Add(Player1.Name & " Has A Higher Pair of " & P1HighPair.rank.ToString())
            CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top = CType(Form1.Controls.Find("picturebox" + CStr(P1PicPos), True)(0), PictureBox).Top - 10
        End If

        If P1PairFound = False And P2PairFound = True Then
            Form1.ListBox5.Items.Add(Player2.Name & " Has A Higher Pair of " & P2HighPair.rank.ToString())
            CType(Form1.Controls.Find("picturebox" + CStr(P2PicPos), True)(0), PictureBox).Top = CType(Form1.Controls.Find("picturebox" + CStr(P2PicPos), True)(0), PictureBox).Top - 10
        End If

        If P1PairFound = False And P2PairFound = False Then

            Form1.ListBox5.Items.Add("No Pairs Found")

        End If
    End Sub

    Sub Straight(card1 As Integer, card2 As Integer, card3 As Integer, card4 As Integer)
        Dim lstFlop As New List(Of Integer)
        Dim Cnt As Integer

        lstFlop.Add(FlopCard1.rank)
        lstFlop.Add(FlopCard2.rank)
        lstFlop.Add(FlopCard3.rank)
        lstFlop.Add(TurnCard.rank)
        lstFlop.Add(RiverCard.rank)

        card1 = P1Card1.rank
        card2 = P1Card2.rank

        lstFlop.Add(card1)
        lstFlop.Add(card2)

        lstFlop.Sort()

        For i = 1 To lstFlop.Count - 1
            If i < lstFlop.Count Then
                If (lstFlop(i) - lstFlop(i - 1)) = 0 Then
                    lstFlop.RemoveAt(i)
                End If
            End If
        Next

        For i = 1 To lstFlop.Count - 1
            If (lstFlop(i) - lstFlop(i - 1)) = 1 Then
                Cnt += 1
            Else
                If Cnt < 4 Then
                    Cnt = 0
                End If
            End If
        Next


        If Cnt >= 4 Then
            MsgBox("Straight Found")
        Else
            MsgBox("Straight Not Found")
        End If

    End Sub

End Class