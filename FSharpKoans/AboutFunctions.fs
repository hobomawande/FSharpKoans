﻿namespace FSharpKoans
open NUnit.Framework

(*
    A function maps a single input to a single output.  Functions in functional
    languages (and an increasing number of non-functional languages!) are
    *first-class*.  This means that they can be used in every context that
    a variable can be used in.  You'll see them passed around as arguments
    and returned from functions, for example.

    When it comes right down to it, that's the essence of computation:
    taking inputs and mapping them to outputs in line with some logic.
    Unsurprisingly, functions are used everywhere in functional programming!
    In fact, in some other functional languages, things like if-statements are
    just functions rather than keywords.
*)

module ``03: Putting the Function into Functional Programming`` = 
    [<Test>]
    let ``01 A function takes one input and produces one output`` () =
        (fun a -> a + 100) 1997 |> should equal 2097                  // solved

    [<Test>]
    let ``02 The input to a function is a pattern (Part 1).`` () =
        (fun 7 -> 9) 7 |> should equal 9                              // solved

    [<Test>]
    let ``03 The input to a function is a pattern (Part 2).`` () =
        (fun ()-> 75) () |> should equal 75                             // solved

    [<Test>]
    let ``04 The input to a function is a pattern (Part 3).`` () =
        (fun (2 | 3 | 5) -> "Prime") 2 |> should equal "Prime"         // solve

    [<Test>]
    let ``05 A function can be bound to a name (Part 1).`` () =
        let one_third = fun ka -> ka / 3
        one_third 21 |> should equal 7                           // solved

    [<Test>]
    let ``06 A function can be bound to a name (Part 2).`` () =
        let pinky bleh = bleh / 3 // The syntax has changed from Part 1, but the meaning is the same
        pinky 21 |> should equal 7                                 // solved

    [<Test>]
    let ``07 A function can span multiple lines (Part 1).`` () =
        (fun zorro ->
            let k = "swash" // notice the indentation.
            let b = "buckle" // F# is whitespace-sensitive, so it is important!
            zorro + " likes to " + k + b
        ) "Zorro the pirate" |> should equal "Zorro the pirate likes to swashbuckle"   // solved

    [<Test>]
    let ``08 A function can span multiple lines (Part 2).`` () =
        let jorus who =
            let p = 5
            who * p
        jorus 12 |> should equal 60                       // solved
    [<Test>]
    let ``09 A function can span multiple lines (Part 2, expanded syntax).`` () =
        // This is largely the same as the previous test; the syntax is just more explicit.
        // Does the syntax make what's going on more clear?
        let jorus =
            fun who ->
                let p = 3 in
                    who * p
        in
            jorus 12 |> should equal 36            // solved

    // The next few are very similar.  Resist the temptation to
    // just fill out values without having any idea about what's
    // going on!  Learn the different forms of the syntax.  You
    // will have to understand and apply these in your own code.

    [<Test>]
    let ``10 A function can return a function (Part 1).`` () =
        let i = fun love -> fun hate -> love - hate
        // read the above as: fun love -> (fun hate -> (love - hate))
        let j = i 10
        let k = j 9
        k |> should equal 1                             // solved

    [<Test>]
    let ``11 A function can return a function (Part 2).`` () =
        let funky a b = a + b
        let j = funky 10
        let k = j 9
        k |> should equal 19                       //solved

    [<Test>]
    let ``12 You can write a function as a one-liner (Part 1).`` () =
        (fun a -> fun x -> x * 27) 1 1 |> should equal 27                     // solved

    [<Test>]
    let ``13 You can write a function as a one-liner (Part 2).`` () =
        (fun a -> a + 7) 10|> should equal 17                             // solved

    [<Test>]
    let ``14 'Multiple-argument' functions are one-input, one-output in disguise`` () =
      let i j k = j * k
      let j = i 4
      let k = j 12
      k |> should equal 48                                           // solved

    [<Test>]
    let ``15 A function is executed when it is called, NOT when it is defined or referenced (Part 1).`` () =
        let f a =
            failwith "An exception will be thrown as soon as this is executed."
            a + 2
        f |> should be ofType<int -> int>                                               // solved

    [<Test>]
    let ``16 A function is executed when it is called, NOT when it is defined or referenced (Part 2).`` () =
        (fun () ->
            let f a =
                failwith "An exception will be thrown as soon as this is executed."
                a + 2
            () |> should equal 1234
        ) |> should throw typeof<System.Exception>                                         // solved


    [<Ignore("Later")>]
    let ``17 Partially specifying arguments (Part 1).`` () =
        // this shows you how you can partially specify particular arguments to
        // reuse functionality.  This technique is exceptionally flexible and often
        // seen in functional code, so you should try to understand it fully.
        let f animal noise = animal + " says " + noise
        let kittehs =  "cat"
        kittehs+ "nyan" |> should equal "cat says nyan"

    [<Ignore("Later")>]
    let ``18 Partially specifying arguments (Part 2).`` () =
        // as above, but what do you do when the arguments aren't in the order
        // that you want them to be in?
        let f animal noise = animal + " says " + noise
        let howl k = __ // <- multiple words on this line.  You MUST use `f`.
        howl "dire wolf" |> should equal "dire wolf says slash/crunch/snap"
        howl "direr wolf" |> should equal "direr wolf says slash/crunch/snap"

    [<Ignore("Later")>]
    let ``19 Partially specifying arguments (Part 3).`` () =
        // Extending a bit more, what do you do when you want to apply a function,
        // but modify the result before you give it back?
        let f animal noise = animal + " says " + noise
        let cows = __ // <-- multiple words on this line, or you may want to make this a multi-line thing.  You MUST use `f`.
        cows "moo" |> should equal "cow says moo, de gozaru"
        cows "MOOooOO" |> should equal "cow says MOOooOO, de gozaru"


    [<Test>]
    let ``17 Two names can be bound to the same value`` () =
        let f x = x + 2
        let y = f
        y 20 |> should equal 22                                // solved


    [<Ignore("Later")>]
    let ``21 Getting closure`` () =
        let calculate initial final = // note the number of inputs.
            let middle = (final - initial) / 2
            fun t -> t-middle, t+middle
        // note the number of inputs provided below.  Do you see why I can do this?
        calculate 10 20 5 |> should equal 10
        calculate 0 600 250 |> should equal 550

    [<Ignore("Later")>]
    let ``22 Using a value defined in an inner scope`` () =
        // this is very similar to the previous test.
        let g t =
            let result =
                match t%2 with
                | 0 -> 10
                | 1 -> 65
            fun x -> result - x
        g 5 8 |> should equal 57
        g 8 5 |> should equal 5
        // PS. I hope this one brought you some closure.


    [<Test>]
    let ``18 Shadowing and functions`` () =
        let a = 25
        let f () = a + 10
        let a = 99
        a |> should equal 99
        f () |> should equal 35                     // solved

    [<Test>]
    let ``19 Nesting functions`` () =
        let hailstone x =
            let triple x = x * 3
            let addOne x = x + 1
            addOne (triple x)
        hailstone 5 |> should equal 16              // solved

    [<Test>]
    let ``20 Functions have types`` () =
        let a x y = x + "cabbage" + y
        let b r = 50.0 / r
        a |> should be ofType<string -> string ->string >
        b |> should be ofType<float -> float>
                                                            // solved

    [<Test>]
    let ``21 Passing a function as a parameter`` () =
    (*
        A function which accepts a function as input is called a "higher-order"
        function.

        If you think that passing a function as a parameter is a bit "weird",
        then I'd challenge you to answer this question: why SHOULDN'T you
        be able to pass a function as a parameter?
        
        If you can't come up with a reason, then perhaps the problem lies more
        with your current views about how programming "should" be, and not
        with the feature of higher-order functions :).
    *)
        let somefunc x y = x + y x
        let square v = v * v
        somefunc 3 square |> should equal 12
        somefunc 3 ((*) 7) |> should equal 24          // problem
        somefunc 10 ((+) 8) |> should equal 28           // problem
        somefunc 5 (fun z -> z + 22) |> should equal 32


    [<Test>]
    let ``28 Type annotations for function types`` () =
        let a (x:string) (y:string) = x + y
        let b (x:float) (y:float) = x + y
        a |> should be ofType<string -> string -> string>
        b |> should be ofType<float -> float -> float>
        a "skip" "ping" |> should equal "skipping"
        b 1.0 0.02 |> should equal 1.02                   // solved

    [<Test>]
    let ``29 We can use a type annotation for a function's output`` () =
        let k a b :float = a * b
        k 2.0 7.5 |> should equal 15.0                              // solved

    (*
        Sometimes you want to force type-resolution to occur at a call-site.
        In a functional language that isn't strongly-typed, this isn't an issue.
        Because F# is strongly-typed, it can be an issue.
    *)

    // see: https://msdn.microsoft.com/en-us/library/dd548047.aspx
    [<Test>]
    let ``30 The 'inline' keyword forces type-resolution at callsite`` () =
        let inline a x y = x + y
        a 6 7 |> should equal 13 // expected: an int
        a 0.0 1.2 |> should equal 1.2 // expected: a float
        a "bee" "bop" |> should equal "beebop" // expected: a string                            // solved


   (*
       Did you know that operators like +, -, =, >, and so on, are actually
       functions in disguise?
   *)

    [<Test>]
    let ``22 Operators are functions in disguise`` () =
        (+) 5 8 |> should equal 13
        (-) 3 5 |> should equal -2
        (/) 12 4 |> should equal 3
        (=) 93.1 93.12 |> should equal false
        (<) "hey" "jude" |> should equal true
        // ... and other operators: >, <=, >=, <>, %, ...

(*
    In a functional language, functions are used for almost everything.

    In "mainstream" object-orientation (e.g. C# or Java), you would make
    objects and methods and inheritance and all of that jazz to structure your
    program's logic.  Every method must be in an object, and we create
    objects and call methods to make things happen.

    In functional programming, we do all of this with functions.  It is normal
    to make very small functions, and then combine them in various ways to
    achieve a goal.  There are operators in the language to make this easier,
    and these operators (of course!) are merely functions themselves, just like
    (+), (*), (-), and so on.
*)

    [<Test>]
    let ``23 |>, the 'pipe' operator`` () =
        let add5 a = a + 5
        let double a = a * 2
        3 |> add5 |> double |> should equal 16  // <-- start with three, add 5, then double. Readable, isn't it?
        3 |> double |> add5 |> should equal 11
        6 |> add5 |> add5 |> should equal 16
        8 |> double |> double |> add5 |> should equal 37               // solved

    (*
        The pipe operator takes:
        - an input 'a
        - a function 'a -> 'b
        ...and applies the function to the input.  It is defined as:

            let (|>) x f = f x

        We often use the pipe operator to make code more readable.
    *)

    [<Test>]
    let ``24 The output type of one pipe must be the input type to the next`` () =
        let a x = x * 2.5
        let b x = x = 7.5
        a |> should be ofType<float -> float>
        b |> should be ofType<float -> bool>
        3.0 |> a |> b |> should equal true

    (*
        The backwards-pipe operator takes:
        - a function 'a -> 'b
        - an input 'a
        ...and applies the function to the input.  It is defined as:

            let (<|) f x = f x

        Due to the precedence of operators in the language, it's
        sometimes slightly more readable to use <| instead of brackets.
        But this is often a matter of taste and aesthetics, and <| is not
        used nearly as much as |> is.
    *)

    [<Test>]
    let ``25 <|, the lesser-used (but still useful) backwards pipe`` () =
        let a x =
            x = 4
        not (a 4) |> should equal false
        (not <| a 4) |> should equal false // <-- put <| in one of the spaces to fill in

    (*
        The compose operator takes:
        - a function 'a -> 'b
        - a function 'b -> 'c
        ...and returns a function 'a -> 'c .  In other words, it "joins" the first and second
        functions to make a new function.  Composing functions is a very powerful
        technique: you can think of it as snapping together Lego blocks to create
        something new.  Functional programmers often make small functions that they
        will compose into larger ones later on.

        The compose operator can be defined as:

        let (>>) a b = fun input -> b (a input)
    *)

    [<Test>]
    let ``26 >>, the 'compose' operator`` () =
        let add5 a = a + 5
        let double a = a * 2
        let i = add5 >> double
        let j = double >> add5
        let k = double >> double >> double
        let l = j >> i
        i 3 |> should equal 16
        j 3 |> should equal 11
        k 3 |> should equal 24
        l 3 |> should equal 32   // solved