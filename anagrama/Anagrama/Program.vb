Imports System

Module Program

    Property qtdeCombinacoesPossiveis As Long
    Property qtdCombinacaoAtual As Integer = 0
    Property palavra As String
    Property listCharPalavra As New List(Of Char)
    Property ProgressBar As ProgressBar = New ProgressBar()

    Sub Main(args As String())

        Print("")
        Console.WriteLine("digite uma palavra: ")
        palavra = Console.ReadLine()

        If Not ValidarPalavra() Then
            Exit Sub
        End If

        PopularVariaveisGlobais()

        PrintRelatorio1000Combinacoes()

        ImprimirTodasVariacoes()

    End Sub
    Private Sub PopularVariaveisGlobais()
        palavra = palavra.ToLower()
        setQtdeCombinacoesPossiveis(palavra)
        setListChar(palavra)
    End Sub

    Private Sub ImprimirTodasVariacoes()

        Print("Deseja imprimir todas as variacoes(y para sim / n para nao): ")
        Dim escolha = Console.ReadLine()
        escolha = escolha.ToLower

        If escolha = "y" Then
            qtdCombinacaoAtual = 0
            Console.WriteLine("lista de todas as variações: ")
            BubblesortPermute(listCharPalavra, leftletter:=0, rightletterstr:=listCharPalavra.Count - 1, showMsg:=True, qtdCombinacoesMaxima:=qtdeCombinacoesPossiveis)
        End If

    End Sub

    Public Sub BubblesortPermute(palavralistada As List(Of Char), leftletter As Integer, rightletterstr As Integer, showMsg As Boolean, qtdCombinacoesMaxima As Long)

        Dim i As Integer
        If qtdCombinacaoAtual = qtdCombinacoesMaxima Then
            Exit Sub
        End If

        If leftletter = rightletterstr Then
            qtdCombinacaoAtual += 1
            If showMsg Then

                Dim progresso = ProgressBar.GetProgress(qtdCombinacaoAtual).ToArray
                Dim porcentagem = (qtdCombinacaoAtual * 100) / qtdeCombinacoesPossiveis

                Console.WriteLine(qtdCombinacaoAtual & " " & palavralistada.ToArray & " " & progresso & " [" & porcentagem.ToString("F2") & "]% ")

            End If
        Else
            i = leftletter
            While i <= rightletterstr
                swapstr(palavralistada, leftletter, i)
                BubblesortPermute(palavralistada, leftletter + 1, rightletterstr, showMsg, qtdCombinacoesMaxima)
                swapstr(palavralistada, leftletter, i)
                i += 1
            End While
        End If

    End Sub

    Private Sub setListChar(palavra As String)

        Dim lista As New List(Of Char)
        For Each letras In palavra
            lista.Add(letras)
        Next

        lista.Sort()

        listCharPalavra = lista

    End Sub

    Private Sub setQtdeCombinacoesPossiveis(palavra As String)
        Dim alfa = Fatorial(palavra.Length)
        Dim delta = GetDeltaLetrasRepetidas(palavra)
        qtdeCombinacoesPossiveis = alfa / delta
        ProgressBar.qtdeCombinacoesPossiveis = qtdeCombinacoesPossiveis
    End Sub

    Private Function ValidarPalavra() As Boolean

        If Not palavra.Length > 1 Then
            Console.WriteLine("Não foi identificado nenhuma palavra")
            Return False
        End If

        If String.IsNullOrEmpty(palavra) Then
            Console.WriteLine("Nenhuma palavra foi digitada")
            Return False
        End If

        Return True

    End Function

    Private Sub PrintRelatorio1000Combinacoes()

        qtdCombinacaoAtual = 0

        Dim tempoAntesProcessar = Now.Ticks
        BubblesortPermute(listCharPalavra, leftletter:=0, rightletterstr:=listCharPalavra.Count - 1, showMsg:=False, qtdCombinacoesMaxima:=1000)
        Dim tempoTotalProcessamento = (Now.Ticks - tempoAntesProcessar)

        Dim tempo1000ms = tempoTotalProcessamento / 10000

        Dim tempoGastoPermutaMs = (qtdeCombinacoesPossiveis * tempo1000ms) / 1000
        Dim tempoGastoPermutaHora = tempoGastoPermutaMs / 3600000
        Dim tempoGastoPermutaDia = tempoGastoPermutaMs / 87400000
        Dim tempoGastoPermutaMes = tempoGastoPermutaMs / 2628000000
        Dim tempoGastoPermutaAno = tempoGastoPermutaMs / 31540000000

        Print($"Qtde de combinações possíveis para palavra: {palavra.ToUpper} é igual a: {qtdeCombinacoesPossiveis}")
        Print("O tempo gasto para imprimir todas as permutações será em média igual a: ")

        If tempoGastoPermutaAno >= 1 Then
            Console.WriteLine(Chr(9) & $"Ano {tempoGastoPermutaAno.ToString("F2")}")
            Exit Sub
        End If

        If tempoGastoPermutaMes >= 1 Then
            Console.WriteLine(Chr(9) & $"Meses {tempoGastoPermutaMes.ToString("F2")}")
            Exit Sub
        End If

        If tempoGastoPermutaDia >= 1 Then
            Console.WriteLine(Chr(9) & $"Dias {tempoGastoPermutaDia.ToString("F2")}")
            Exit Sub
        End If

        If tempoGastoPermutaHora >= 1 Then
            Console.WriteLine(Chr(9) & $"Horas {tempoGastoPermutaHora.ToString("F2")}")
            Exit Sub
        End If

        Console.WriteLine(Chr(9) & $"Ms {tempoGastoPermutaMs.ToString("F2")}")

    End Sub

    Private Sub Print(msg As String)
        Console.WriteLine("")
        Console.WriteLine(msg)
    End Sub

    Private Function Fatorial(n As Integer) As Double
        If n = 1 Then
            Return 1
        Else
            Return n * Fatorial(n - 1)
        End If
    End Function

    Function Percorrer_letras(palavra As String) As Dictionary(Of String, Integer)

        Dim index As Decimal
        Dim repetidos As New Dictionary(Of String, Integer)

        For index = 0 To palavra.Length - 1

            If repetidos.ContainsKey(palavra(index)) Then
                repetidos(palavra(index)) += 1

            Else
                repetidos.Add(palavra(index), 1)

            End If

        Next

        Return repetidos

    End Function

    Private Function GetDeltaLetrasRepetidas(palavra As String) As Double

        Dim dictListaLetrasComQtdeRepetidas = Percorrer_letras(palavra)

        Dim listaQtdeLetrasRepetidas As New List(Of Integer)
        Dim delta = 1
        For Each item In dictListaLetrasComQtdeRepetidas

            If item.Value > 1 Then
                listaQtdeLetrasRepetidas.Add(Fatorial(item.Value))
            Else
                listaQtdeLetrasRepetidas.Add(1)
            End If

        Next

        For Each qtdCadaLetra In listaQtdeLetrasRepetidas
            delta *= qtdCadaLetra
        Next

        Return delta

    End Function

    Private Sub swapstr(numeros As List(Of Char), leftLetter As Integer, rightLetterstr As Integer)

        Dim temp = numeros(leftLetter)
        numeros(leftLetter) = numeros(rightLetterstr)
        numeros(rightLetterstr) = temp

    End Sub


End Module
