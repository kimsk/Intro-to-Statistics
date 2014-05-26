(*** hide ***)
#I ".."
#load "packages/FsLab.0.0.14-beta/FsLab.fsx"
open FSharp.Charting
open Deedle
open MathNet.Numerics.Statistics
(**
Programming Estimators
======================

F# code for [Programming Estimators] unit.

#### MEAN
*)
let mean l = (l |> Seq.sum |> float)/(l |> Seq.length |> float)

let data1 = [49.; 66.; 24.; 98.; 37.; 64.; 98.; 27.; 56.; 93.; 68.; 78.; 22.; 25.; 11.]
data1 |> mean
data1 |> Seq.average
data1.Mean() // Math.NET
(*** include-value: data1 |> mean ***)
(*** include-value: data1 |> Seq.average ***)
(*** include-value: data1.Mean() ***)
(**
#### MEDIAN
*)
let median l = 
    let len = l |> Seq.length
    let sorted = (l |> Array.ofSeq |> Array.sort)
    let pos = len/2
    if len%2 <> 0 then        
        sorted.[pos]
    else                
        (sorted.[pos-1]+sorted.[pos])/2.

[1.;1.;2.;5.;10.;-20.] |> median
[1.;1.;2.;5.;10.;-20.].Median() // Math.NET
(*** include-value: [1.;1.;2.;5.;10.;-20.] |> median ***)
(*** include-value: [1.;1.;2.;5.;10.;-20.].Median() ***)
(**
#### MODE

From unit 14: [Averages](14-Averages.html)

*do not support bimodal or multimodal*
*)
let mode l = l |> Seq.groupBy id |> Seq.maxBy (fun (k,v) -> v |> Seq.length) |> fst
    
[1.;1.;1.;2.;5.;10.;-20.;5.;5.] |> mode
(*** include-value: [1.;1.;1.;2.;5.;10.;-20.;5.;5.] |> mode ***)
(**
#### VARIANCE

Modify what we have in unit 15: [Variance](15-Variance.html)
*)
let variance (list:seq<float>) =    
    let mu = list |> mean
    list |> Seq.map (fun x -> (x-mu)**2.) |> mean

[13.04; 1.32; 22.65; 17.44; 29.54; 23.22; 17.65; 10.12; 26.73; 16.43]|> variance
[13.04; 1.32; 22.65; 17.44; 29.54; 23.22; 17.65; 10.12; 26.73; 16.43].PopulationVariance() // Math.NET
(*** include-value: [13.04; 1.32; 22.65; 17.44; 29.54; 23.22; 17.65; 10.12; 26.73; 16.43]|> variance ***)
(*** include-value: [13.04; 1.32; 22.65; 17.44; 29.54; 23.22; 17.65; 10.12; 26.73; 16.43].PopulationVariance() ***)

(**
#### STANDARD DEVIATION

From unit 15: [Variance](15-Variance.html)
*)
let std (list:seq<float>) = list |> variance |> sqrt

[13.04; 1.32; 22.65; 17.44; 29.54; 23.22; 17.65; 10.12; 26.73; 16.43]|> std
[13.04; 1.32; 22.65; 17.44; 29.54; 23.22; 17.65; 10.12; 26.73; 16.43].PopulationStandardDeviation() // Math.NET
(*** include-value: [13.04; 1.32; 22.65; 17.44; 29.54; 23.22; 17.65; 10.12; 26.73; 16.43]|> std ***)
(*** include-value: [13.04; 1.32; 22.65; 17.44; 29.54; 23.22; 17.65; 10.12; 26.73; 16.43].PopulationStandardDeviation() ***)
(**
[Programming Estimators]: https://www.udacity.com/course/viewer#!/c-st101/l-48750146
*)
