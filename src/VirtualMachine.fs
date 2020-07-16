namespace Hunter1266.Brainfuck

open System

type VirtualMachine() =
    let byteArray = Array.create<byte> 30000 0uy
    let mutable currentPointer = 0
    member this.Increment() = byteArray.[currentPointer] <- byteArray.[currentPointer] + 1uy
    member this.Decrement() = byteArray.[currentPointer] <- byteArray.[currentPointer] - 1uy
    member this.PointerIncrement() = currentPointer <- currentPointer + 1
    member this.PointerDecrement() = currentPointer <- currentPointer - 1
    member this.Assignment() = byteArray.[currentPointer] <- byte (Console.ReadLine().ToCharArray().[0])
    member this.VarDump() = printfn "%c" (char byteArray.[currentPointer])
