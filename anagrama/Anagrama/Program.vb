Imports System

Module Program

    Private Function Fatorial(n As Integer) As Decimal

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

    Sub Main(args As String())

        Dim palavra As String
        Dim qtd_letras As Integer
        Dim permutacao As Decimal

        Console.WriteLine("digite uma palavra: ")
        palavra = Console.ReadLine()
        palavra = palavra.ToLower()
        qtd_letras = palavra.Length

        If Not palavra.Length > 1 Then
            Console.WriteLine("Nao foi identificado nenhuma palavra")
            Exit Sub
        End If

        Dim alfa = Fatorial(qtd_letras)
        Dim dicionario = Percorrer_letras(palavra)
        Dim listDeltaFat = GetListDelta(dicionario)
        Dim delta As Decimal = 1

        For Each item In listDeltaFat        
            delta *= item
        Next

        permutacao = alfa / delta

        Console.WriteLine($"A quantidade de permutações possiveis para a palavra {palavra.ToUpper} é igual a {permutacao}")

    End Sub

End Module
