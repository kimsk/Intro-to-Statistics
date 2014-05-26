(*** hide ***)
#I ".."
#load "packages/FsLab.0.0.13-beta/FsLab.fsx"
open FSharp.Charting
open Deedle
(**
Probability Distributions
======================

F# code for [Probability Distributions] unit.

In *continuous distribution*, every outcome has probability **0**

### Density 

Like probability but for continuous spaces.

The second you were born. 

P(x) = 0

f(x) = 1/60

f(x<=noon) = 2*f(x>noon), find a and b.
*)
let ``f(x)`` = 1./12.
(*** include-value:``f(x)`` ***)
let b = (1./3.)*``f(x)``
(*** include-value:b ***)
let a = (1./3.)*``f(x)``*2.
(*** include-value:a ***)
(a*12.)+(b*12.)
(*** include-value:(a*12.)+(b*12.) ***)
(**

**Density** can be larger than 1 and always non-negative
*)
(**
[Probability Distributions]: https://www.udacity.com/course/viewer#!/c-st101/l-48748100
*)