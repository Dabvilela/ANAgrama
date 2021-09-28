Public Class ProgressBar

    Public Property qtdeCombinacoesPossiveis As Long
    Public Property progress = New List(Of Char)

    Private Property index As Integer = 0

    Public Sub New()
        For i = 0 To 99
            progress.Add("."c)
        Next
    End Sub


    Public Function GetProgress(qtdCombinacaoAtual As Integer) As List(Of Char)

        Dim porcentagem As Double = (qtdCombinacaoAtual * 100) / qtdeCombinacoesPossiveis

        If (porcentagem Mod 1) = 0 Then
            progress(index) = "#"
            index += 1
        End If

        Return progress

    End Function


End Class