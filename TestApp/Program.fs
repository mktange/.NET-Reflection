
open System
open System.Reflection

open Microsoft.FSharp.Reflection

// Reflection method to invoke members without args
let (?) x prop =
    let flags = BindingFlags.GetProperty ||| BindingFlags.InvokeMethod
    x.GetType().InvokeMember(prop, flags, null, x, [||])


[<EntryPoint>]
let main argv = 
  
  let src = __SOURCE_DIRECTORY__
  let asm = 
    Assembly.LoadFile(src + @"\..\TestLibrary\bin\Debug\TestLibrary.dll")
  
  // Create a new object
  let ty = asm.GetType("TestLibrary.MainClass")
  let instance = Activator.CreateInstance(ty)

  // Get a string
  let func = ty.GetMethod("GetSomeString")
  let someStr = func.Invoke(instance, Array.empty) :?> string

  // Get an object
  let func = ty.GetMethod("GetSomeObject")
  let someObj = func.Invoke(instance, Array.empty)  

  // Print out all the values
  printfn "Simple String: %s" someStr
  printfn "Test: %s" (someObj?Test :?> string)
  printfn "Hmm: %s" (someObj?Hmm :?> string)
  printfn "blah: %d" (someObj?blah :?> int)
  printfn "pop: %d" (someObj?pop :?> int)

  Console.ReadKey() |> ignore
  0
