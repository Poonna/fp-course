// ===========================================================================
//  Week 2 Lab · Functions, Recursion, and Reading Types
// ===========================================================================
//
//  How to work:
//    1. Replace each  failwith "TODO"  with your own definition.
//    2. Run the whole file:   dotnet fsi week02-lab.fsx
//       (or select a function and press Alt+Enter to try it in FSI).
//    3. The tests at the bottom report which tasks pass.
//
//  Rules for this lab:
//    - Use recursion for repetition: no `mutable`, no `for` or `while` loops.
//    - Use `match` for case analysis. Every match must be complete: the
//      tests report an incomplete match (warning FS0025) as a failed task. (`if` is fine inside an expression, e.g.
//      in a boolean condition, but each recursive function's cases should be
//      the rules of a `match`.)
//    - For EVERY function, write the four recipe steps as a comment first:
//          // Type: ...   Base: ...   Recursive: ...   Check: ...
//      Your check-in will start from these comments.
//    - Some tasks use functions from the notes (`repeat`, `gcd`, `digitSum`);
//      these are provided, marked "Provided".
//    - Don't change the tests.
// ===========================================================================


// ---------------------------------------------------------------------------
// Task 1 · Sum of odd numbers
// sumOdds n = 1 + 3 + 5 + ... + (2n - 1), the first n odd numbers.
// sumOdds 0 = 0, sumOdds 3 = 1 + 3 + 5 = 9.  (Notice anything about the results?)
// ---------------------------------------------------------------------------
let rec sumOdds n =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 2 · Integer powers
// powerInt b n = b to the power n, for n >= 0, all ints.
// ---------------------------------------------------------------------------
let rec powerInt b n =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 3 · Partial application
// Define these WITHOUT writing any parameters: use partial application of
// powerInt. For example:  let powersOfTen = powerInt 10
// ---------------------------------------------------------------------------
let powersOfTwo : int -> int =
    fun _ -> failwith "TODO"

let powersOfThree : int -> int =
    fun _ -> failwith "TODO"


// ---------------------------------------------------------------------------
// Task 4 · Counting a digit
// countDigit d n = how many times the digit d (0-9) appears in n (n >= 0).
// countDigit 1 1101 = 3, countDigit 7 0 = 0, countDigit 0 0 = 1.
// Hint: n % 10 is the last digit, n / 10 is the rest. Watch the case n = 0.
// ---------------------------------------------------------------------------
let rec countDigit d n =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 5 · A triangle of stars
// triangle 3 should be the string  "*\n**\n***\n"  which prints as:
//     *
//     **
//     ***
// triangle 0 = "".  Use `repeat` (provided below).
// ---------------------------------------------------------------------------
// Provided (from the notes):
let rec repeat s n =
    match n with
    | 0 -> ""
    | n -> s + repeat s (n - 1)

let rec triangle n =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 6 · Collatz steps
// Start from n >= 1. If n is even, halve it; if odd, replace it by 3n + 1.
// collatzSteps n = the number of steps until you reach 1.
// collatzSteps 1 = 0, collatzSteps 6 = 8  (6 3 10 5 16 8 4 2 1).
// (Nobody has ever proved that this reaches 1 for every n! See the notes'
//  "Why does a recursive function stop?" box.)
// ---------------------------------------------------------------------------
let rec collatzSteps n =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 7 · Least common multiple
// lcm a b = the smallest positive number divisible by both a and b (a, b > 0).
// Use gcd (provided below):  lcm a b = a / gcd a b * b
// ---------------------------------------------------------------------------
// Provided (from the notes):
let rec gcd a b =
    match b with
    | 0 -> a
    | b -> gcd b (a % b)

let lcm a b =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 8 · Pascal's triangle
// choose n k = the number of ways to pick k things out of n (0 <= k <= n):
//     choose n 0 = 1
//     choose n n = 1
//     choose n k = choose (n - 1) (k - 1) + choose (n - 1) k
// choose 5 2 = 10, choose 10 5 = 252.
// Hint: the second equation needs a guard.
// ---------------------------------------------------------------------------
let rec choose n k =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 9 · Primes, with a helper
// Sometimes the function you need is not the one you were asked for.
// First write
//     hasDivisorFrom d n  =  does n have a divisor in d, d+1, d+2, ...
//                            (stopping once d * d > n)?
// Then isPrime is short: n >= 2, and n has no divisor from 2 upward.
// isPrime 2 = true, isPrime 1 = false, isPrime 91 = false (7 * 13).
// ---------------------------------------------------------------------------
let rec hasDivisorFrom d n =
    failwith "TODO"

let isPrime n =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 10 · Digital root
// Add up the digits; if the result has more than one digit, do it again.
// digitalRoot 9875: 9+8+7+5 = 29, 2+9 = 11, 1+1 = 2.  So digitalRoot 9875 = 2.
// Use digitSum (provided below).
// ---------------------------------------------------------------------------
// Provided (from the notes):
let rec digitSum n =
    match n with
    | n when n < 10 -> n
    | n -> n % 10 + digitSum (n / 10)

let rec digitalRoot n =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 11 · Trace (not tested; bring it to your check-in)
// 1. Write the equation-style trace of  collatzSteps 6  using your definition.
// 2. For hasDivisorFrom, what gets "smaller" in each call? (Hint: it isn't d.)
// ---------------------------------------------------------------------------
//
//    collatzSteps 6 = ...
//


// ---------------------------------------------------------------------------
// Task 12 · (Challenge) Reversing digits
// reverseDigits 1234 = 4321, reverseDigits 120 = 21, reverseDigits 7 = 7.
// This is hard to do directly. Write a HELPER with an extra parameter that
// holds "the digits reversed so far":
//     revHelper acc n     e.g. revHelper 0 1234 = revHelper 4 123
//                                               = revHelper 43 12 = ...
// then  reverseDigits n = revHelper 0 n.
// (This "extra parameter" trick is the main topic of Week 7.)
// ---------------------------------------------------------------------------
let rec revHelper acc n =
    failwith "TODO"

let reverseDigits n =
    failwith "TODO"

// A number is a palindrome if it reads the same backwards: 12321, 7, 44.
let isPalindromeNumber n =
    failwith "TODO"


// <runner>
// ===========================================================================
//  Tests — no need to read or change anything below this line.
//  (The test runner itself uses a little mutation to count results. It is
//   the "imperative shell" around your functional code. More on that idea
//   in Week 10.)
// ===========================================================================

// --- Completeness check -----------------------------------------------------
// An incomplete match (warning FS0025) counts as a failed task, even if the
// tests pass. To find them, the runner compiles this file a second time in a
// separate FSI (which stops right here, so the tests don't run twice) and
// reads that FSI's warnings.
if System.Environment.GetEnvironmentVariable "LAB_COMPILE_ONLY" = "1" then exit 0

let private incompleteMatches : (int * string) list =
    try
        let file = System.IO.Path.Combine(__SOURCE_DIRECTORY__, __SOURCE_FILE__)
        let psi = System.Diagnostics.ProcessStartInfo("dotnet", $"fsi --nologo \"{file}\"")
        psi.RedirectStandardError <- true
        psi.RedirectStandardOutput <- true
        psi.Environment["LAB_COMPILE_ONLY"] <- "1"
        use proc = System.Diagnostics.Process.Start psi
        let stdout = proc.StandardOutput.ReadToEndAsync()
        let errors = proc.StandardError.ReadToEnd()
        proc.WaitForExit()
        stdout.Wait()
        let lines = System.IO.File.ReadAllLines file
        // "// Task 5 · ..." header lines, as (line number, "Task 5"), last first.
        let headers =
            [ for i in 0 .. lines.Length - 1 do
                let l = lines[i].Trim()
                if l.StartsWith "// Task " then
                    let words = l.Substring(3).Split(' ')
                    yield (i + 1, words[0] + " " + words[1].TrimEnd(':', '.')) ]
            |> List.rev
        let taskAt line =
            match headers |> List.tryFind (fun (h, _) -> h <= line) with
            | Some (_, name) -> name
            | None -> "Code outside the tasks"
        [ for l in errors.Split('\n') do
            if l.Contains "warning FS0025" && l.Contains(__SOURCE_FILE__) then
                let at = l.IndexOf(__SOURCE_FILE__ + "(") + __SOURCE_FILE__.Length + 1
                let lineNo = int (l.Substring(at).Split(',')[0])
                yield (lineNo, taskAt lineNo) ]
        |> List.distinct
    with ex ->
        printfn "  (completeness check skipped: %s)" ex.Message
        []

// --- Test helpers -----------------------------------------------------------
let mutable passed = 0
let mutable failed = 0
let mutable todo = 0

let run name (compute: unit -> 'a) (isOk: 'a -> bool) (expected: string) =
    try
        let actual = compute ()
        if isOk actual then
            passed <- passed + 1
        else
            failed <- failed + 1
            printfn "  FAIL  %s: expected %s, got %A" name expected actual
    with
    | ex when ex.Message.StartsWith "TODO" ->
        todo <- todo + 1
    | ex ->
        failed <- failed + 1
        printfn "  FAIL  %s: raised %s" name ex.Message

let check name compute expected =
    run name compute (fun a -> a = expected) (sprintf "%A" expected)

let checkClose name compute (expected: float) =
    run name compute (fun a -> abs (a - expected) < 1e-9) (sprintf "%g" expected)

let raises name compute (message: string) =
    try
        compute () |> ignore
        failed <- failed + 1
        printfn "  FAIL  %s: expected an error" name
    with
    | ex when ex.Message.StartsWith "TODO" -> todo <- todo + 1
    | ex when ex.Message = message -> passed <- passed + 1
    | ex ->
        failed <- failed + 1
        printfn "  FAIL  %s: expected error %A, got %A" name message ex.Message

let report () =
    for (line, task) in incompleteMatches do
        failed <- failed + 1
        printfn "  FAIL  %s: incomplete match (FS0025) at line %d" task line
    printfn "Passed: %d   Failed: %d   Not done yet: %d" passed failed todo
// </runner>

printfn "Week 2 lab"

check "T1 0" (fun () -> sumOdds 0) 0
check "T1 1" (fun () -> sumOdds 1) 1
check "T1 3" (fun () -> sumOdds 3) 9
check "T1 10" (fun () -> sumOdds 10) 100

check "T2 2^0" (fun () -> powerInt 2 0) 1
check "T2 2^10" (fun () -> powerInt 2 10) 1024
check "T2 3^4" (fun () -> powerInt 3 4) 81
check "T2 7^1" (fun () -> powerInt 7 1) 7

check "T3 two" (fun () -> powersOfTwo 8) 256
check "T3 three" (fun () -> powersOfThree 3) 27

check "T4 1101" (fun () -> countDigit 1 1101) 3
check "T4 none" (fun () -> countDigit 7 1101) 0
check "T4 zero in 0" (fun () -> countDigit 0 0) 1
check "T4 7 in 0" (fun () -> countDigit 7 0) 0
check "T4 zeros" (fun () -> countDigit 0 1000) 3
check "T4 single" (fun () -> countDigit 5 5) 1

check "T5 0" (fun () -> triangle 0) ""
check "T5 1" (fun () -> triangle 1) "*\n"
check "T5 3" (fun () -> triangle 3) "*\n**\n***\n"

check "T6 1" (fun () -> collatzSteps 1) 0
check "T6 2" (fun () -> collatzSteps 2) 1
check "T6 6" (fun () -> collatzSteps 6) 8
check "T6 27" (fun () -> collatzSteps 27) 111

check "T7 4 6" (fun () -> lcm 4 6) 12
check "T7 3 5" (fun () -> lcm 3 5) 15
check "T7 same" (fun () -> lcm 7 7) 7
check "T7 multiple" (fun () -> lcm 6 3) 6

check "T8 5 0" (fun () -> choose 5 0) 1
check "T8 5 5" (fun () -> choose 5 5) 1
check "T8 5 2" (fun () -> choose 5 2) 10
check "T8 10 5" (fun () -> choose 10 5) 252
check "T8 20 3" (fun () -> choose 20 3) 1140

check "T9 1" (fun () -> isPrime 1) false
check "T9 2" (fun () -> isPrime 2) true
check "T9 9" (fun () -> isPrime 9) false
check "T9 13" (fun () -> isPrime 13) true
check "T9 91" (fun () -> isPrime 91) false
check "T9 97" (fun () -> isPrime 97) true
check "T9 helper" (fun () -> hasDivisorFrom 2 15) true

check "T10 7" (fun () -> digitalRoot 7) 7
check "T10 9875" (fun () -> digitalRoot 9875) 2
check "T10 99" (fun () -> digitalRoot 99) 9

check "T12 1234" (fun () -> reverseDigits 1234) 4321
check "T12 120" (fun () -> reverseDigits 120) 21
check "T12 7" (fun () -> reverseDigits 7) 7
check "T12 pal yes" (fun () -> isPalindromeNumber 12321) true
check "T12 pal no" (fun () -> isPalindromeNumber 1231) false
check "T12 pal single" (fun () -> isPalindromeNumber 7) true

report ()
