// ===========================================================================
//  Week 3 Lab · Lists, Tuples, and Recursion Patterns
// ===========================================================================
//
//  How to work:
//    1. Replace each  failwith "TODO"  with your own definition.
//    2. Run the whole file:   dotnet fsi week03-lab.fsx
//    3. The tests at the bottom report which tasks pass.
//
//  Rules for this lab:
//    - Write list functions yourself, by recursion: don't use the List
//      module (List.length, List.rev, List.map, ...), except List.ofSeq where
//      a task says so. The operators :: and @ are fine.
//    - No `mutable`, no loops. Use `match` for the cases. Every match must
//      be complete: the tests report an incomplete match (warning FS0025)
//      as a failed task.
//    - For every function, write the recipe as a comment first, AND name its
//      shape: transform each / keep some / combine all / stop early /
//      each to many (or a combination).
//    - Don't change the tests.
// ===========================================================================


// ---------------------------------------------------------------------------
// Task 1 · Counting
// countOf x xs = how many times x occurs in xs.
// countOf 2 [2; 1; 2; 3] = 2
// ---------------------------------------------------------------------------
let rec countOf x xs =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 2 · Two shapes in one
// squaresOfOdds xs = the squares of the odd elements, in order.
// squaresOfOdds [1; 2; 3; 4; 5] = [1; 9; 25]
// (Watch out: the remainder of a negative odd number is -1 in F#, not 1.)
// ---------------------------------------------------------------------------
let rec squaresOfOdds xs =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 3 · Compress
// Remove ADJACENT duplicates: compress [1; 1; 2; 3; 3; 3; 1] = [1; 2; 3; 1]
// Hint: the pattern x :: y :: rest looks at two elements at once.
// ---------------------------------------------------------------------------
let rec compress xs =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 4 · Is it sorted?
// isSorted xs = is every element <= the next one?
// isSorted [1; 2; 2; 5] = true, isSorted [3; 1] = false, isSorted [] = true
// ---------------------------------------------------------------------------
let rec isSorted xs =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 5 · Building a list from a number
// countdownList n = [n; n-1; ...; 1], for n >= 0.  countdownList 0 = []
// Build it by recursion on n: DON'T use a range [n .. -1 .. 1].
// ---------------------------------------------------------------------------
let rec countdownList n =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 6 · Position of an element
// indexOf x xs = the position of the first x in xs (counting from 0),
//                or -1 if x isn't there.
// indexOf 'c' ['a'; 'b'; 'c'] = 2,  indexOf 9 [1; 2] = -1
// Hint: trust indexOf x rest. If it is -1, so is the answer. Otherwise...?
// ---------------------------------------------------------------------------
let rec indexOf x xs =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 7 · Smallest and largest, in one pass
// minMax xs = (smallest, largest) for a NON-EMPTY list.
// minMax [3; 9; 2; 7] = (2, 9),  minMax [5] = (5, 5)
// For an empty list: failwith "minMax: empty list"
// Hint: like sumProd in the notes, take apart the recursive call's result.
// ---------------------------------------------------------------------------
let rec minMax xs =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 8 · A small bill
// A price table and an order are both lists of pairs:
//     table : (string * int) list     item name, price in baht
//     order : (string * int) list     item name, quantity
// billTotal table order = the total price of the order.
// Use lookup (provided) to find each price.
// ---------------------------------------------------------------------------

// Provided (from the notes):
let rec lookup key table =
    match table with
    | [] -> failwith ("lookup: no entry for " + key)
    | (k, v) :: _ when k = key -> v
    | _ :: rest -> lookup key rest

let menu = [ ("coffee", 55); ("tea", 45); ("cake", 80); ("water", 15) ]

let rec billTotal table order =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 9 · Insertion sort
// insert x sorted  puts x in its place in an already sorted list:
//     insert 4 [1; 3; 5] = [1; 3; 4; 5]
// insertionSort xs  sorts a list, using insert.
//     insertionSort [3; 1; 2] = [1; 2; 3]
// ---------------------------------------------------------------------------
let rec insert x sorted =
    failwith "TODO"

let rec insertionSort xs =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 10 · Text
// Use List.ofSeq to turn a string into a list of characters.
// isPalindrome s = does s read the same backwards?  (use reverse, provided)
//     isPalindrome "level" = true, isPalindrome "lever" = false
// countVowels s = how many of a, e, i, o, u (lower case) are in s.
//     countVowels "functional" = 4
// Hint for countVowels: a helper on char lists, then apply it to List.ofSeq s.
// ---------------------------------------------------------------------------

// Provided (from the notes; slow for long lists, fine for words):
let rec reverse xs =
    match xs with
    | [] -> []
    | x :: rest -> reverse rest @ [ x ]

let isPalindrome (s: string) =
    failwith "TODO"

let rec countVowelsIn (cs: char list) =
    failwith "TODO"

let countVowels (s: string) =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 11 · Trace and shapes (not tested; bring it to your check-in)
// 1. Write the equation-style trace of  compress [1; 1; 2]
// 2. For Tasks 1-7, name the shape of each function.
// ---------------------------------------------------------------------------
//
//    compress [1; 1; 2] = ...
//


// ---------------------------------------------------------------------------
// Task 12 · (Challenge) Merge sort and run-length encoding
// (a) mergeSort: split the list in two, sort each half, merge the results.
//     split and merge are provided.
// (b) runLength: count runs of equal adjacent elements.
//     runLength ['a'; 'a'; 'b'; 'c'; 'c'; 'c'] = [('a', 2); ('b', 1); ('c', 3)]
//     Hint: trust runLength rest. Does its first run continue yours?
// ---------------------------------------------------------------------------

// Provided (from the notes):
let rec split xs =
    match xs with
    | [] -> ([], [])
    | [ x ] -> ([ x ], [])
    | x :: y :: rest ->
        let (odds, evens) = split rest
        (x :: odds, y :: evens)

let rec merge xs ys =
    match xs, ys with
    | [], ys -> ys
    | xs, [] -> xs
    | x :: xs', y :: ys' ->
        if x <= y then x :: merge xs' ys
        else y :: merge xs ys'

let rec mergeSort xs =
    failwith "TODO"

let rec runLength xs =
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

printfn "Week 3 lab"

check "T1 two" (fun () -> countOf 2 [ 2; 1; 2; 3 ]) 2
check "T1 none" (fun () -> countOf 9 [ 2; 1 ]) 0
check "T1 empty" (fun () -> countOf 'a' []) 0
check "T1 strings" (fun () -> countOf "x" [ "x"; "x" ]) 2

check "T2 mixed" (fun () -> squaresOfOdds [ 1; 2; 3; 4; 5 ]) [ 1; 9; 25 ]
check "T2 evens" (fun () -> squaresOfOdds [ 2; 4 ]) []
check "T2 negative" (fun () -> squaresOfOdds [ -3; -2 ]) [ 9 ]
check "T2 empty" (fun () -> squaresOfOdds []) []

check "T3 runs" (fun () -> compress [ 1; 1; 2; 3; 3; 3; 1 ]) [ 1; 2; 3; 1 ]
check "T3 none" (fun () -> compress [ 1; 2; 3 ]) [ 1; 2; 3 ]
check "T3 all same" (fun () -> compress [ 'a'; 'a'; 'a' ]) [ 'a' ]
check "T3 empty" (fun () -> compress ([]: int list)) []

check "T4 sorted" (fun () -> isSorted [ 1; 2; 2; 5 ]) true
check "T4 unsorted" (fun () -> isSorted [ 3; 1 ]) false
check "T4 late" (fun () -> isSorted [ 1; 2; 3; 0 ]) false
check "T4 empty" (fun () -> isSorted ([]: int list)) true
check "T4 single" (fun () -> isSorted [ 7 ]) true

check "T5 3" (fun () -> countdownList 3) [ 3; 2; 1 ]
check "T5 1" (fun () -> countdownList 1) [ 1 ]
check "T5 0" (fun () -> countdownList 0) []

check "T6 found" (fun () -> indexOf 'c' [ 'a'; 'b'; 'c' ]) 2
check "T6 first" (fun () -> indexOf 1 [ 1; 1 ]) 0
check "T6 missing" (fun () -> indexOf 9 [ 1; 2 ]) -1
check "T6 empty" (fun () -> indexOf 9 []) -1
check "T6 later dup" (fun () -> indexOf 2 [ 1; 2; 2 ]) 1

check "T7 mixed" (fun () -> minMax [ 3; 9; 2; 7 ]) (2, 9)
check "T7 single" (fun () -> minMax [ 5 ]) (5, 5)
check "T7 negative" (fun () -> minMax [ -1; -8 ]) (-8, -1)
raises "T7 empty" (fun () -> minMax ([]: int list)) "minMax: empty list"

check "T8 order" (fun () -> billTotal menu [ ("coffee", 2); ("cake", 1) ]) 190
check "T8 empty" (fun () -> billTotal menu []) 0
check "T8 single" (fun () -> billTotal menu [ ("water", 3) ]) 45
raises "T8 unknown" (fun () -> billTotal menu [ ("juice", 1) ]) "lookup: no entry for juice"

check "T9 insert middle" (fun () -> insert 4 [ 1; 3; 5 ]) [ 1; 3; 4; 5 ]
check "T9 insert front" (fun () -> insert 0 [ 1; 3 ]) [ 0; 1; 3 ]
check "T9 insert end" (fun () -> insert 9 [ 1; 3 ]) [ 1; 3; 9 ]
check "T9 insert empty" (fun () -> insert 1 []) [ 1 ]
check "T9 sort" (fun () -> insertionSort [ 3; 1; 2 ]) [ 1; 2; 3 ]
check "T9 sort dups" (fun () -> insertionSort [ 2; 1; 2; 1 ]) [ 1; 1; 2; 2 ]
check "T9 sort strings" (fun () -> insertionSort [ "pear"; "apple"; "fig" ]) [ "apple"; "fig"; "pear" ]

check "T10 level" (fun () -> isPalindrome "level") true
check "T10 lever" (fun () -> isPalindrome "lever") false
check "T10 empty" (fun () -> isPalindrome "") true
check "T10 vowels" (fun () -> countVowels "functional") 4
check "T10 none" (fun () -> countVowels "rhythm") 0

check "T12 msort" (fun () -> mergeSort [ 5; 2; 9; 1; 5; 6 ]) [ 1; 2; 5; 5; 6; 9 ]
check "T12 msort empty" (fun () -> mergeSort ([]: int list)) []
check "T12 msort one" (fun () -> mergeSort [ 4 ]) [ 4 ]
check "T12 rle" (fun () -> runLength [ 'a'; 'a'; 'b'; 'c'; 'c'; 'c' ]) [ ('a', 2); ('b', 1); ('c', 3) ]
check "T12 rle empty" (fun () -> runLength ([]: char list)) []
check "T12 rle repeat" (fun () -> runLength [ 1; 2; 1 ]) [ (1, 1); (2, 1); (1, 1) ]

report ()
