(*** hide ***)
#I ".."
#load "packages/FsLab.0.0.14-beta/FsLab.fsx"
open FSharp.Charting
(**
Estimation
==========

F# code for [Estimation] unit.

#### [Emprirical]

Empirical evidence (also empirical data, sense experience, empirical knowledge, or the a posteriori) is a source of knowledge acquired by means of observation or experimentation.

#### Maximum Likelihood Estimator (MLE)

Estimation problem is: Data -> p -> P(DATA)

**101**
*)
let ``list of p`` = [|1./2.;1./3.;2./3.;1.|]

let ``list of P(data)`` = ``list of p`` |> Array.map (fun p ->  p, (p*(1.-p)*p))
(*** include-value: ``list of P(data)``.[0]|>snd ***)
(*** include-value: ``list of P(data)``.[1]|>snd ***)
(*** include-value: ``list of P(data)``.[2]|>snd ***)
(*** include-value: ``list of P(data)``.[3]|>snd ***)
(*** define-output:chart1 ***)
Chart.Point(``list of P(data)``)
(*** include-it:chart1 ***)
(**

2/3 is MLE. 

#### Laplacian Estimator

Laplacian Estimator improves estimation by adding fake data to limited observation data.

#### Dices examples
*)

let data = [1;2;3;2]
let data' = [1;2;3;4;5;6]

let ``MLE P(n)`` n = float(data|> Seq.filter ((=)n) |> Seq.length)/float(data |> Seq.length)
let ``LE P(n)`` n = float(data@data'|> Seq.filter ((=)n) |> Seq.length)/float(data@data' |> Seq.length)         

let ``MLE vs. LE`` = 
    [1;2;3;4;5;6]
    |> List.map (fun n -> ``MLE P(n)`` n, ``LE P(n)`` n)
(*** include-value: ``MLE vs. LE`` ***)

(**

**MLE**: $\frac{1}{N}\sum_{i=1}^Nx_i$

**LE**: $\frac{1}{N+K}(1+\sum_{i=1}^Nx_i)$

### When there is not much data, **FAKE IT**
*)
(**
[Estimation]: https://www.udacity.com/course/viewer#!/c-st101/l-48727700
[Emprirical]: http://en.wikipedia.org/wiki/Empirical
[Maximum likelihood]: http://en.wikipedia.org/wiki/Maximum-likelihood_estimation
*)

