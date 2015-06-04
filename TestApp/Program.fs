
open System
open System.Reflection

open Microsoft.FSharp.Reflection

// Reflection method to invoke members without args
let (?) x prop =
    let flags = BindingFlags.GetProperty ||| BindingFlags.InvokeMethod
    x.GetType().InvokeMember(prop, flags, null, x, [||])



/// Get a simple string
let testString (ty:Type) instance =
  let func = ty.GetMethod("GetSomeString")
  let someStr = func.Invoke(instance, Array.empty) :?> string

  printfn "Simple String: %s" someStr
  


/// Get an object
let testObject (ty:Type) instance =
  let func = ty.GetMethod("GetSomeObject")
  let someObj = func.Invoke(instance, Array.empty)  
  
  printfn "Test: %s" (someObj?Test :?> string)
  printfn "Hmm: %s" (someObj?Hmm :?> string)
  printfn "blah: %d" (someObj?blah :?> int)
  printfn "pop: %d" (someObj?pop :?> int)



/// Get a tuple and extract the items
let testTuple (ty:Type) instance =
  let func = ty.GetMethod("GetSomeTuple")
  let someTuple = func.Invoke(instance, Array.empty)
  
  let someStr = someTuple?Item1 :?> string
  let someObj = someTuple?Item2

  printfn "Simple String: %s" someStr
  printfn "Test: %s" (someObj?Test :?> string)
  printfn "Hmm: %s" (someObj?Hmm :?> string)
  printfn "blah: %d" (someObj?blah :?> int)
  printfn "pop: %d" (someObj?pop :?> int)





// Main and helper methods

let waitForKey () =
  printfn "Press any key to continue..."
  Console.ReadKey() |> ignore

[<EntryPoint>]
let main argv = 
  
  let src = __SOURCE_DIRECTORY__
  let asm = 
    Assembly.LoadFile(src + @"\..\TestLibrary\bin\Debug\TestLibrary.dll")  

  // Create a new object
  let ty = asm.GetType("TestLibrary.MainClass")
  let instance = Activator.CreateInstance(ty)


  testString ty instance
  waitForKey()

  testObject ty instance
  waitForKey()
  
  testTuple ty instance
  waitForKey()

  0














