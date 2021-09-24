Imports System

Module Program
    Property permutacao As Double
    Property contador As Integer = 0
    Sub Main(args As String())

        Dim palavra As String
        Dim qtd_letras As Integer

        Console.WriteLine("Digite uma palavra: ")
        palavra = Console.ReadLine()
        palavra = palavra.ToLower()
        qtd_letras = palavra.Length

        If Not palavra.Length > 1 Then
            Console.WriteLine("Não foi identificado nenhuma palavra")
            Exit Sub
        End If

        Dim alfa = Fatorial(qtd_letras)
        Dim dicionario = Percorrer_letras(palavra)
        Dim listDeltaFat = GetListDelta(dicionario)
        Dim delta As Double = 1

        For Each item In listDeltaFat
            delta *= item
        Next


        Dim palavraListada As New List(Of Char)
        For Each letras In palavra
            palavraListada.Add(letras)
        Next
        palavraListada.Sort()
        Dim leftLetters = 0
        Dim rightletterstr = palavraListada.Count - 1

        Dim datetick = Now.Ticks
        permutacao = 1000
        BubblesortPermute(palavraListada, leftLetters, rightletterstr, showMsg:=False)

        permutacao = alfa / delta
<<<<<<< HEAD
        Console.WriteLine($"A quantidade de permutações possiveis para a palavra {palavra.ToUpper} é igual a {permutacao.ToString("F2")}")

        Dim datetick1 = Now.Ticks
        Dim tempo1000ms = (datetick1 - datetick) / 10000
        Dim tempoGastoPermutaMs = (permutacao * tempo1000ms) / 1000
        Dim tempoGastoPermutaHora = tempoGastoPermutaMs / 3600000
        Dim tempoGastoPermutaDia = tempoGastoPermutaMs / 87400000
        Dim tempoGastoPermutaMes = tempoGastoPermutaMs / 2628000000
        Dim tempoGastoPermutaAno = tempoGastoPermutaMs / 31540000000

        Console.WriteLine($"O tempo gasto em media sera igual a : {tempoGastoPermutaMs.ToString("F2")} ms")

        If tempoGastoPermutaHora >= 1 Then
            Console.WriteLine($"O tempo gasto em media sera igual a : {tempoGastoPermutaHora.ToString("F2")} horas")
        End If

        If tempoGastoPermutaDia >= 1 Then
            Console.WriteLine($"O tempo gasto em media sera igual a : {tempoGastoPermutaDia.ToString("F2")} dias")
        End If

        If tempoGastoPermutaMes >= 1 Then
            Console.WriteLine($"O tempo gasto em media sera igual a : {tempoGastoPermutaMes.ToString("F2")} meses")
        End If

        If tempoGastoPermutaAno >= 1 Then
            Console.WriteLine($"O tempo gasto em media sera igual a : {tempoGastoPermutaAno.ToString("F2")} ano")
        End If

=======
        Console.WriteLine($"A quantidade de permutações possíveis para a palavra {palavra.ToUpper} é igual a {permutacao}")

        Dim datetick1 = Now.Ticks
        Dim tempo1000ms = (datetick1 - datetick) / 10000
        Dim tempoGastoPermuta = (permutacao * tempo1000ms) / 1000
        Console.WriteLine($"O tempo gasto em média será igual a : {tempoGastoPermuta} ms")
        Console.WriteLine($"O tempo gasto em média será igual a : {tempoGastoPermuta / 3600000} horas")
        Console.WriteLine($"O tempo gasto em média será igual a : {tempoGastoPermuta / 87400000 } dias")
        Console.WriteLine($"O tempo gasto em média será igual a : {tempoGastoPermuta / 2628000000} meses")
        Console.WriteLine($"O tempo gasto em média será igual a : {tempoGastoPermuta / 31540000000 } ano")
>>>>>>> main

        Console.WriteLine("Deseja imprimir todas as variações(y para sim / n para não): ")
        Dim escolha = Console.ReadLine()
        escolha = escolha.ToLower
        Dim showmsg As Boolean = False

        If escolha = "y" Then
            contador = 0
            Console.WriteLine("lista de todas as variações: ")
            BubblesortPermute(palavraListada, leftLetters, rightletterstr, showMsg:=True)
        End If

        If escolha = "n" Then
            Console.WriteLine("bye")
        End If

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

    Private Function GetListDelta(dicionario As Dictionary(Of String, Integer)) As List(Of Integer)

        Dim listDeltaRepetidos As New List(Of Integer)

        For Each item In dicionario

            If item.Value > 1 Then

                listDeltaRepetidos.Add(Fatorial(item.Value))
            Else
                listDeltaRepetidos.Add(1)
            End If

        Next

        Return listDeltaRepetidos

    End Function

    Public Sub BubblesortPermute(palavralistada As List(Of Char), leftletter As Integer, rightletterstr As Integer, showMsg As Boolean)
        Dim i As Integer
        If contador = permutacao Then
            Exit Sub
        End If

        If leftletter = rightletterstr Then
            contador += 1
            If showMsg Then Console.WriteLine(contador & " " & palavralistada.ToArray)
        Else
            i = leftletter
            While i <= rightletterstr
                swapstr(palavralistada, leftletter, i)
                BubblesortPermute(palavralistada, leftletter + 1, rightletterstr, showMsg)
                swapstr(palavralistada, leftletter, i)
                i += 1
            End While
        End If

    End Sub

    Private Sub swapstr(numeros As List(Of Char), leftLetter As Integer, rightLetterstr As Integer)

        Dim temp = numeros(leftLetter)
        numeros(leftLetter) = numeros(rightLetterstr)
        numeros(rightLetterstr) = temp

    End Sub


End Module
