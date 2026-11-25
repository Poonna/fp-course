// ===========================================================================
//  Week 1 Lab · Programs as Expressions
// ===========================================================================
//
//  How to work:
//    1. Replace each  failwith "TODO"  with your own expression.
//    2. Run the whole file:   dotnet fsi week01-lab.fsx
//       (or select a function and press Alt+Enter to try it in FSI).
//    3. The tests at the bottom report which tasks pass.
//
//  Rules for this lab:
//    - No `mutable` and no `<-` in your answers.
//    - Every `if` must have an `else`.
//    - Don't change the tests.
// ===========================================================================


// ---------------------------------------------------------------------------
// Task 1 · Temperature
// Convert degrees Celsius to degrees Fahrenheit:  F = C × 9/5 + 32
// ---------------------------------------------------------------------------
let celsiusToFahrenheit c =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 2 · Leap years
// A year is a leap year if it is divisible by 4, except years divisible by
// 100, which are leap years only if they are also divisible by 400.
// Write it WITHOUT `if`: use only comparisons, &&, || and not.
// ---------------------------------------------------------------------------
let isLeapYear year =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 3 · Days in a month
// Return the number of days in `month` (1–12) of `year`.
// Use isLeapYear. For a month outside 1–12, return 0.
// (Returning 0 for "invalid" is a bit of a hack. In Week 4 we will see a
//  much better way to say "there is no answer".)
// ---------------------------------------------------------------------------
let daysInMonth year month =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 4 · Letter grades
// Convert a score (0–100) to a letter grade:
//   80+ A | 75–79 B+ | 70–74 B | 65–69 C+ | 60–64 C | 55–59 D+ | 50–54 D | <50 F
// ---------------------------------------------------------------------------
let grade score =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 5 · Parking fee
// A car park charges by the minute you stayed:
//   - the first 60 minutes are free;
//   - after that, 20 baht for every hour or part of an hour;
//   - the fee never exceeds 300 baht.
// Examples: 45 min → 0, 61 min → 20, 150 min → 40, 2000 min → 300.
//
// Hint: with integer division, (n + 59) / 60 is n / 60 rounded UP.
// Use local `let` bindings to name the intermediate values.
// ---------------------------------------------------------------------------
let parkingFee minutes =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 6 · Refactor: electricity bill
// Here is a working function written in statement style. Rewrite it as
// `electricityBill`, giving the same result for every input, with no
// `mutable` and no `<-`. The tests compare your version against this one.
//
// The (simplified, made-up) tariff:
//   first 150 units:   3.00 baht/unit
//   next  250 units:   4.00 baht/unit
//   above 400 units:   5.00 baht/unit
//   plus a fixed service charge of 38.00 baht.
// ---------------------------------------------------------------------------
let electricityBillStatements units =
    let mutable bill = 38.0
    let mutable remaining = units
    if remaining > 400.0 then
        bill <- bill + (remaining - 400.0) * 5.0
        remaining <- 400.0
    if remaining > 150.0 then
        bill <- bill + (remaining - 150.0) * 4.0
        remaining <- 150.0
    bill <- bill + remaining * 3.0
    bill

let electricityBill units =
    failwith "TODO"


// ---------------------------------------------------------------------------
// Task 7 · Trace (not tested; bring it to your check-in)
// In the comment below, write the step-by-step evaluation of
//     parkingFee 150
// using YOUR definition from Task 5, and the substitution rules from the
// notes. Number each step with the rule you used.
// ---------------------------------------------------------------------------
//
//    parkingFee 150
//  ⇝ ...
//


// ---------------------------------------------------------------------------
// Task 8 · (Challenge) Formatting a duration
// Turn a number of seconds into text "Hh MMm SSs", with minutes and seconds
// always two digits. Examples:  3725 → "1h 02m 05s",   59 → "0h 00m 59s".
//
// Hint: inside an interpolated string, {n:D2} prints an int with at least
// two digits, e.g. $"{5:D2}" is "05".
// ---------------------------------------------------------------------------
let formatDuration seconds =
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

printfn "Week 1 lab"

checkClose "T1 freezing" (fun () -> celsiusToFahrenheit 0.0) 32.0
checkClose "T1 boiling" (fun () -> celsiusToFahrenheit 100.0) 212.0
checkClose "T1 body" (fun () -> celsiusToFahrenheit 37.0) 98.6
checkClose "T1 -40" (fun () -> celsiusToFahrenheit -40.0) -40.0

check "T2 2024" (fun () -> isLeapYear 2024) true
check "T2 2023" (fun () -> isLeapYear 2023) false
check "T2 1900" (fun () -> isLeapYear 1900) false
check "T2 2000" (fun () -> isLeapYear 2000) true

check "T3 Jan" (fun () -> daysInMonth 2025 1) 31
check "T3 Feb leap" (fun () -> daysInMonth 2024 2) 29
check "T3 Feb" (fun () -> daysInMonth 2025 2) 28
check "T3 Feb 1900" (fun () -> daysInMonth 1900 2) 28
check "T3 Apr" (fun () -> daysInMonth 2025 4) 30
check "T3 Nov" (fun () -> daysInMonth 2025 11) 30
check "T3 Dec" (fun () -> daysInMonth 2025 12) 31
check "T3 month 0" (fun () -> daysInMonth 2025 0) 0
check "T3 month 13" (fun () -> daysInMonth 2025 13) 0

check "T4 100" (fun () -> grade 100) "A"
check "T4 80" (fun () -> grade 80) "A"
check "T4 79" (fun () -> grade 79) "B+"
check "T4 70" (fun () -> grade 70) "B"
check "T4 65" (fun () -> grade 65) "C+"
check "T4 64" (fun () -> grade 64) "C"
check "T4 55" (fun () -> grade 55) "D+"
check "T4 50" (fun () -> grade 50) "D"
check "T4 49" (fun () -> grade 49) "F"
check "T4 0" (fun () -> grade 0) "F"

check "T5 45" (fun () -> parkingFee 45) 0
check "T5 60" (fun () -> parkingFee 60) 0
check "T5 61" (fun () -> parkingFee 61) 20
check "T5 120" (fun () -> parkingFee 120) 20
check "T5 121" (fun () -> parkingFee 121) 40
check "T5 150" (fun () -> parkingFee 150) 40
check "T5 cap" (fun () -> parkingFee 2000) 300
check "T5 edge" (fun () -> parkingFee (60 + 15 * 60)) 300

for u in [ 0.0; 1.0; 100.0; 150.0; 150.5; 200.0; 400.0; 400.25; 1000.0 ] do
    checkClose $"T6 {u} units" (fun () -> electricityBill u) (electricityBillStatements u)

check "T8 3725" (fun () -> formatDuration 3725) "1h 02m 05s"
check "T8 59" (fun () -> formatDuration 59) "0h 00m 59s"
check "T8 36000" (fun () -> formatDuration 36000) "10h 00m 00s"

report ()
