namespace Hunter1266.Brainfuck

open System.IO

type Operation =
    | Increment
    | Decrement
    | PointerIncrement
    | PointerDecrement
    | Assignment
    | VarDump
    | LongJump
    | LoopEnd
    | NoOperation

type SourceReader(path: string) = 
    let src =
        try
            use file = File.OpenText path
            file.ReadToEnd()
        with
        | _ -> System.String.Empty
    let mutable currentPointer = 0
    member this.Exists
        with get() = not (System.String.IsNullOrEmpty src)
    member this.Eof
        with get() = src.Length >= currentPointer
    member this.Read() =
        match src.[currentPointer] with
        | '>' -> PointerIncrement
        | '<' -> PointerDecrement
        | '+' -> Increment
        | '-' -> Decrement
        | '.' -> VarDump
        | ',' -> Assignment
        | '[' -> LongJump
        | ']' -> LoopEnd
        | _ -> NoOperation
    member this.LongJump() =
        let mutable jumpCount = 1
        while not (jumpCount = 0) do
            currentPointer <- currentPointer + 1
            match src.[currentPointer] with
            | '[' -> jumpCount <- jumpCount + 1
            | ']' -> jumpCount <- jumpCount - 1
            | _ -> ()
    member this.LoopEnd() =
        let mutable jumpCount = 1
        while not (jumpCount = 0) do
            currentPointer <- currentPointer - 1
            match src.[currentPointer] with
            | ']' -> jumpCount <- jumpCount + 1
            | '[' -> jumpCount <- jumpCount - 1
            | _ -> ()
