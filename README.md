# Functional Programming in F#: labs

Course site (notes, slides, drills, labs): **https://poonna.github.io/fp-course/**

## Work in the browser with GitHub Codespaces (no installation)

1. Click **Code → Codespaces → Create codespace on main** (or the button below).
2. Wait a minute or two. VS Code opens in the browser with the .NET SDK and the Ionide F# extension ready.
3. Open a lab, for example `labs/week01/week01-lab.fsx`.
   - **Try a function:** select it and press **Alt+Enter** to send it to F# Interactive.
   - **Run all the tests:** in the terminal, run
     ```bash
     dotnet fsi labs/week01/week01-lab.fsx
     ```

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/Poonna/fp-course)

**Save your own work.** This repository belongs to the course, so you can't push to it. To keep your answers, either fork the repository first and create the codespace from your fork, or download your `.fsx` files before deleting the codespace.

**Free hours.** Every GitHub account gets some free Codespaces time each month, and verified students get more through the [GitHub Student Developer Pack](https://education.github.com/pack). Stop your codespace when you finish (it also stops by itself after 30 minutes idle) so you don't use up your hours.

## Work on your own computer

Install the [.NET SDK](https://dotnet.microsoft.com/download) (version 10 or later) and VS Code with the **Ionide-fsharp** extension, or JetBrains Rider. Then download a lab from the course site and run `dotnet fsi week01-lab.fsx`.
