Public Class ProgressBar

    Public Property qtdeCombinacoesPossiveis As Long
    Public Property progress = New List(Of Char)

    Private Property index As Integer = 0
    Property tamanhoProgress As Integer = 10
    Public Sub New()
        For i = 0 To tamanhoProgress
            progress.Add("."c)
        Next
    End Sub

    Public Function GetProgress(qtdCombinacaoAtual As Integer) As List(Of Char)

        Dim porcentagem As Integer = CInt(Math.Ceiling((qtdCombinacaoAtual * 100) / qtdeCombinacoesPossiveis - 1))
        index = CInt(Math.Ceiling((porcentagem * tamanhoProgress) / 100))
        If (index - 1) >= 0 Then
            progress(index - 1) = "#"
        End If

        If index = tamanhoProgress Then
            progress(index) = "#"
        End If


        Return progress

    End Function


End Class