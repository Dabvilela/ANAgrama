 Dim index As Integer = 0
        Dim porcentagem As Double
        Dim permutacao As Integer = 720
        Dim hashtagindex As Integer = 0
        Dim palavra As String = "Andre"
        Dim s As String = ".........."
        Console.Write(s)
        Console.Write(palavra & "0%" & s & "100% " & porcentagem)
        While index <= permutacao
            Dim hashstr = "#".Concat(For each  )
            Dim res = s.Take(hashtagindex).Concat("#").Concat(s.Where(Function(c, i) i > hashtagindex))
            Console.Write(palavra & "0%" & res.ToArray & "100% " & porcentagem)
            Console.SetCursorPosition(palavra.Length + 1 + hashtagindex, Console.CursorTop)
            Console.Write("#")
            porcentagem = (index * 100) / permutacao

            If (porcentagem Mod 10) = 0 Then
                Thread.Sleep(300)
                Console.SetCursorPosition(palavra.Length + 1 + hashtagindex, Console.CursorTop)
                Console.Write("#")
                hashtagindex += 1
            End If

            index += 1
            Console.WriteLine("")
        End While