// ===========================================================================
//  Week 4 Lab · Modeling Data: Records, Unions, and Option
// ===========================================================================
//
//  How to work:
//    1. Replace each  failwith "TODO"  with your own definition.
//    2. Run the whole file:   dotnet fsi week04-lab.fsx
//    3. The tests at the bottom report which tasks pass.
//
//  Rules for this lab:
//    - Still no List module (List.length, List.map, ...): write list
//      functions by recursion. :: and @ are fine.
//    - No `mutable`, no loops.
//    - EVERY match must be complete. An FS0025 warning ("Incomplete pattern
//      matches") counts as a failed task, even if the tests pass; the tests
//      report it for you.
//    - Avoid the wildcard `_` for union cases you could list by name: then the
//      compiler can tell you when a new case is added.
//    - Never return a magic value (0, -1, "") for "no answer": use option.
//    - Don't change the types or the tests.
// ===========================================================================


// ===========================================================================
//  Part 1 · Cards
// ===========================================================================

type Suit =
    | Clubs
    | Diamonds
    | Hearts
    | Spades

type Rank =
    | Number of int     // 2 to 10
    | Jack
    | Queen
    | King
    | Ace

type Card = { Rank: Rank; Suit: Suit }

// ---------------------------------------------------------------------------
// Task 1 · Naming a card
// cardText { Rank = Queen; Suit = Hearts } = "Queen of Hearts"
// cardText { Rank = Number 7; Suit = Spades } = "7 of Spades"
// Hint: write small helpers rankText and suitText first.
// ---------------------------------------------------------------------------
let rankText rank =
    failwith "TODO"

let suitText suit =
    failwith "TODO"

let cardText card =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 2 · A blackjack hand
// Number cards count their number; Jack, Queen, King count 10; Ace counts 11.
// handValue [ {Rank = Ace; ...}; {Rank = King; ...} ] = 21
// ---------------------------------------------------------------------------
let cardValue card =
    failwith "TODO"

let rec handValue cards =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 3 · Same suit?
// isFlush cards = do all the cards have the same suit?  isFlush [] = true
// ---------------------------------------------------------------------------
let rec isFlush cards =
    failwith "TODO"


// ===========================================================================
//  Part 2 · Shapes
// ===========================================================================

type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float
    | Square of side: float

// ---------------------------------------------------------------------------
// Task 4 · Area, and the largest shape
// area: the area of one shape.
// tryLargest: the shape with the largest area, or None for an empty list.
// (If two have the same area, return either.)
// ---------------------------------------------------------------------------
let area shape =
    failwith "TODO"

let rec tryLargest shapes =
    failwith "TODO"


// ===========================================================================
//  Part 3 · Months, and the Week 1 hack
// ===========================================================================

type Month =
    | January | February | March | April | May | June
    | July | August | September | October | November | December

// Provided (from the notes):
let isLeapYear year =
    (year % 4 = 0 && year % 100 <> 0) || year % 400 = 0

let daysIn year month =
    match month with
    | February -> if isLeapYear year then 29 else 28
    | April | June | September | November -> 30
    | January | March | May | July | August | October | December -> 31

let monthFromNumber n =
    match n with
    | 1 -> Some January | 2 -> Some February | 3 -> Some March
    | 4 -> Some April | 5 -> Some May | 6 -> Some June
    | 7 -> Some July | 8 -> Some August | 9 -> Some September
    | 10 -> Some October | 11 -> Some November | 12 -> Some December
    | _ -> None

// ---------------------------------------------------------------------------
// Task 5 · Next month
// nextMonth December = January. List the cases; no wildcard.
// ---------------------------------------------------------------------------
let nextMonth month =
    failwith "TODO"

// ---------------------------------------------------------------------------
// Task 6 · The Week 1 hack, fixed
// In Week 1, daysInMonth 2025 13 returned 0. Now write
//     daysInMonth : int -> int -> int option
// daysInMonth 2024 2 = Some 29,  daysInMonth 2025 13 = None
// Use monthFromNumber and daysIn.
// ---------------------------------------------------------------------------
let daysInMonth year monthNumber =
    failwith "TODO"


// ===========================================================================
//  Part 4 · The café register
// ===========================================================================

type Article = { Name: string; Price: int }

type Discount =
    | NoDiscount
    | PercentOff of percent: int
    | FixedOff of baht: int

type Payment =
    | Cash of received: int
    | Card of lastFour: string
    | PromptPay of phone: string

let menu =
    [ ("a1", { Name = "iced coffee"; Price = 45 })
      ("a2", { Name = "sandwich"; Price = 39 })
      ("a3", { Name = "water"; Price = 10 }) ]

// ---------------------------------------------------------------------------
// Task 7 · Looking up an article
// tryFindArticle "a2" menu = Some { Name = "sandwich"; Price = 39 }
// tryFindArticle "zz" menu = None
// ---------------------------------------------------------------------------
let rec tryFindArticle code register =
    failwith "TODO"

// ---------------------------------------------------------------------------
// Task 8 · Discounts
// discounted discount price = the price after the discount.
//   PercentOff 10 on 45 -> 40 (integer arithmetic: 45 * 90 / 100 = 40)
//   FixedOff 20 on 45 -> 25
//   A price can never go below 0: FixedOff 100 on 45 -> 0
// ---------------------------------------------------------------------------
let discounted discount price =
    failwith "TODO"

// ---------------------------------------------------------------------------
// Task 9 · A price rise
// raiseAll percent register = the register with every price raised by
// percent (integer arithmetic, like Task 8). Keep the codes; use
// { article with Price = ... }.
// ---------------------------------------------------------------------------
let rec raiseAll percent register =
    failwith "TODO"

// ---------------------------------------------------------------------------
// Task 10 · Paying
// changeDue total payment:
//   Cash received >= total  -> Some (received - total)
//   Cash received <  total  -> None  (not enough money)
//   Card or PromptPay       -> Some 0
// ---------------------------------------------------------------------------
let changeDue total payment =
    failwith "TODO"


// ===========================================================================
//  Part 5 · Counting and design (not tested; bring it to your check-in)
// ===========================================================================
// Task 11
//   (a) How many values does each type have?  Suit, Suit * bool,
//       Suit option, Discount (explain why the answer is "very many").
//   (b) A student modelled a café order's status as
//          { IsPaid: bool; IsServed: bool; IsRefunded: bool }
//       How many values? Which ones are nonsense? Write a union instead.
// ---------------------------------------------------------------------------


// ===========================================================================
//  Part 6 · (Challenge) A tiny calculator
// ===========================================================================
// A recursive union for arithmetic expressions. Week 6 builds on this.

type Expr =
    | Num of int
    | Add of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

// ---------------------------------------------------------------------------
// Task 12 · Evaluate an expression
// eval (Add (Num 1, Mul (Num 2, Num 3))) = Some 7
// Division by zero anywhere gives None: eval (Div (Num 1, Num 0)) = None
// Hint: evaluate both sides first; each result is an option.
// ---------------------------------------------------------------------------
let rec eval expr =
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

printfn "Week 4 lab"

let queenH = { Rank = Queen; Suit = Hearts }
let sevenS = { Rank = Number 7; Suit = Spades }
let aceH = { Rank = Ace; Suit = Hearts }
let twoH = { Rank = Number 2; Suit = Hearts }

check "T1 queen" (fun () -> cardText queenH) "Queen of Hearts"
check "T1 seven" (fun () -> cardText sevenS) "7 of Spades"
check "T1 ace" (fun () -> cardText { Rank = Ace; Suit = Diamonds }) "Ace of Diamonds"
check "T1 clubs" (fun () -> suitText Clubs) "Clubs"

check "T2 blackjack" (fun () -> handValue [ aceH; { Rank = King; Suit = Clubs } ]) 21
check "T2 numbers" (fun () -> handValue [ sevenS; twoH ]) 9
check "T2 empty" (fun () -> handValue []) 0
check "T2 jack" (fun () -> cardValue { Rank = Jack; Suit = Spades }) 10

check "T3 flush" (fun () -> isFlush [ queenH; aceH; twoH ]) true
check "T3 not" (fun () -> isFlush [ queenH; sevenS ]) false
check "T3 empty" (fun () -> isFlush []) true
check "T3 one" (fun () -> isFlush [ sevenS ]) true

checkClose "T4 circle" (fun () -> area (Circle 1.0)) System.Math.PI
checkClose "T4 rect" (fun () -> area (Rectangle (2.0, 3.0))) 6.0
checkClose "T4 square" (fun () -> area (Square 3.0)) 9.0
check "T4 largest" (fun () -> tryLargest [ Square 1.0; Circle 1.0; Rectangle (1.0, 2.0) ]) (Some (Circle 1.0))
check "T4 largest one" (fun () -> tryLargest [ Square 2.0 ]) (Some (Square 2.0))
check "T4 largest empty" (fun () -> tryLargest []) None

check "T5 jan" (fun () -> nextMonth January) February
check "T5 dec" (fun () -> nextMonth December) January
check "T5 jun" (fun () -> nextMonth June) July

check "T6 leap" (fun () -> daysInMonth 2024 2) (Some 29)
check "T6 feb" (fun () -> daysInMonth 2025 2) (Some 28)
check "T6 apr" (fun () -> daysInMonth 2025 4) (Some 30)
check "T6 13" (fun () -> daysInMonth 2025 13) None
check "T6 0" (fun () -> daysInMonth 2025 0) None

check "T7 found" (fun () -> tryFindArticle "a2" menu) (Some { Name = "sandwich"; Price = 39 })
check "T7 missing" (fun () -> tryFindArticle "zz" menu) None
check "T7 empty" (fun () -> tryFindArticle "a1" []) None

check "T8 none" (fun () -> discounted NoDiscount 45) 45
check "T8 percent" (fun () -> discounted (PercentOff 10) 45) 40
check "T8 fixed" (fun () -> discounted (FixedOff 20) 45) 25
check "T8 floor" (fun () -> discounted (FixedOff 100) 45) 0

check "T9 raise" (fun () -> raiseAll 10 menu)
    [ ("a1", { Name = "iced coffee"; Price = 49 })
      ("a2", { Name = "sandwich"; Price = 42 })
      ("a3", { Name = "water"; Price = 11 }) ]
check "T9 empty" (fun () -> raiseAll 10 []) []

check "T10 change" (fun () -> changeDue 55 (Cash 100)) (Some 45)
check "T10 exact" (fun () -> changeDue 55 (Cash 55)) (Some 0)
check "T10 short" (fun () -> changeDue 55 (Cash 50)) None
check "T10 card" (fun () -> changeDue 55 (Card "4242")) (Some 0)
check "T10 promptpay" (fun () -> changeDue 55 (PromptPay "0812345678")) (Some 0)

check "T12 num" (fun () -> eval (Num 5)) (Some 5)
check "T12 expr" (fun () -> eval (Add (Num 1, Mul (Num 2, Num 3)))) (Some 7)
check "T12 div" (fun () -> eval (Div (Num 7, Num 2))) (Some 3)
check "T12 div0" (fun () -> eval (Div (Num 1, Num 0))) None
check "T12 deep div0" (fun () -> eval (Add (Num 1, Div (Num 2, Add (Num 1, Num -1))))) None

report ()
