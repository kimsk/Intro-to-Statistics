(*** hide ***)
#I ".."
#load "packages/FsLab.0.0.13-beta/FsLab.fsx"
open FSharp.Charting
open Deedle
(**
Averages
========

F# code for [Averages] unit.

### MEAN

$\frac{1}{N}\sum_{i=1}^Nx_i$

#### House prices
*)
open MathNet.Numerics.Statistics
let mean = [190.;170.;165.;180.;165.] |> Seq.average
// or use MathNet.Numerics.Statistics
[190.;170.;165.;180.;165.].Mean()
(*** include-value: mean ***)
let mean' = [2400.;125.;148.;160.;110.;325.;180.] |> Seq.average
(*** include-value: mean' ***)
(**
### MEDIAN

Sort and pick one value in the middle.
*)
let median = [2400.;125.;148.;160.;110.;325.;180.].Median()
(*** include-value: median ***)


(**
### MODE


#### Children Birthday Party

Try using mean and median to calculate average ages.

*)
let ages = [4.;3.;32.;33.;4.;32.;3.;38.;4.]
ages.Mean()
(*** include-value: ages.Mean() ***)
(*** include-value: ages.Median() ***)
(**
[Averages]: https://www.udacity.com/course/viewer#!/c-st101/l-48736237
*)
