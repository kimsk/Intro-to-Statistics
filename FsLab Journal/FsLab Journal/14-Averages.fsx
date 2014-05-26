(*** hide ***)
#I ".."
#load "packages/FsLab.0.0.14-beta/FsLab.fsx"
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
let ages' = [35.;36.;4.;3.;32.;33.;4.;32.;3.;38.;4.]
ages'.Median()
(*** include-value: ages'.Median() ***)
(**

Median changes from 4 to 32 after adding only couple more data.

Mode is a value that is most frequent. 

[Multi-modal and Bimodal distribution]

*)
let mode list = list |> Seq.groupBy id |> Seq.maxBy (fun (k,v) -> v |> Seq.length) |> fst

let values = [5.;9.;100.;9.;97.;6.;9.;98.;9.]
values.Mean()
values.Median()
values |> mode
(*** include-value: values.Mean() ***)
(*** include-value: values.Median() ***)
(*** include-value: values |> mode ***)

let values' = [3.;9.;3.;8.;2.;9.;1.;9.;2.;4.]
values'.Mean()
values'.Median()
values' |> mode
(**
[Averages]: https://www.udacity.com/course/viewer#!/c-st101/l-48736237
[Multi-modal and Bimodal distribution]: http://en.wikipedia.org/wiki/Multimodal_distribution
*)
