namespace Hunter1266.Brainfuck

open System.IO

type Effect(src: SourceReader, vm: VirtualMachine) =
    let src = src
    let vm = vm
    member this.Start() =
        while not src.Eof do
            match src.Read() with
            | Increment -> vm.Increment()
            | Decrement -> vm.Decrement()
            | PointerIncrement -> vm.PointerIncrement()
            | PointerDecrement -> vm.PointerDecrement()
            | Assignment -> vm.Assignment()
            | VarDump -> vm.VarDump()
            | LongJump -> src.LongJump()
            | LoopEnd -> src.LoopEnd()
            | NoOperation -> ()
