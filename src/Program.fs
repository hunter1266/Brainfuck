open System
open Hunter1266.Brainfuck

[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let src = SourceReader(argv.[1])
        Effect(src, VirtualMachine()).Start()
        0
    else
        1