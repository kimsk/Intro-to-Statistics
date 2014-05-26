(*** hide ***)
#I ".."
#load "packages/FsLab.0.0.14-beta/FsLab.fsx"
open FSharp.Charting
open MathNet.Numerics.Statistics
(**
Variance
========

F# code for [Variance] and [Standard deviation] unit.
*)
let friends = [17.;19.;18.;17.;19.]
let family = [7.;38.;4.;23.;18.]
friends.Mean()
family.Mean()
(*** include-value: friends.Mean() ***)
(*** include-value: family.Mean() ***)
let variance (list:seq<float>) =    
    let mean = list.Mean()
    (list |> Seq.map (fun x -> (x-mean)*(x-mean))).Mean()


friends |> variance // or friends.PopulationVariance()
family |> variance // or family.PopulationVariance()
(*** include-value: friends |> variance ***)
(*** include-value: family |> variance ***)
let std (list:seq<float>) = list |> variance |> sqrt
friends |> std // or friends.PopulationStandardDeviation()
family |> std // or family.PopulationStandardDeviation()
(*** include-value: friends |> std  ***)
(*** include-value: family |> std ***)
[3.;4.;5.;6.;7.] |> Seq.average
[3.;4.;5.;6.;7.] |> variance
[3.;4.;5.;6.;7.] |> std
(**

**MEAN** = $ \mu = \frac{1}{N}\sum_{i=1}^Nx_i$

**VARIANCE** = $ \sigma^2 = \frac{1}{N}\sum_{i=1}^N(x_i-\mu)^2 $

**STANDARD DEVIATION** = $ \sigma = \sqrt{VARIANCE} $

Let's simplify how to calculate $ \sigma^2 $:

$ \frac{1}{N}\sum_{i=1}^N(x_i-\mu)^2 $

$ \frac{1}{N}\sum_{i=1}^N(x_i-\mu)(x_i-\mu) $

$ \frac{1}{N}\sum_{i=1}^N[x_i^2-2x_i\mu+\mu^2] $

$ \frac{1}{N}\sum_{i=1}^Nx_i^2-\frac{2\mu}{N}\sum_{i=1}^Nx_i + \mu^2 $
 
$ \frac{1}{N}\sum_{i=1}^Nx_i^2-2\mu\mu + \mu^2 $
 
$ \frac{1}{N}\sum_{i=1}^Nx_i^2- \mu^2 $
 
$ \frac{1}{N}\sum_{i=1}^Nx_i^2- \frac{1}{N^2}(\sum_{i=1}^Nx_i)^2 $

So we need to calculate only the following to get $ \sigma^2 $

- N
- $ \sum_{i=1}^Nx_i $
- $ \sum_{i=1}^Nx_i^2 $

*)
let N = [3.;4.;5.;6.;7.] |> Seq.length |> float
let sumXi = [3.;4.;5.;6.;7.] |> Seq.sum
let sumXi2 = [3.;4.;5.;6.;7.] |> Seq.fold (fun acc x -> (x*x) + acc) 0.
(*** include-value: N ***)
(*** include-value: sumXi ***)
(*** include-value: sumXi2 ***)

let mu = sumXi/N
let var = sumXi2/N - (sumXi*sumXi)/(N*N)
(*** include-value: mu ***)
(*** include-value: var ***)

let variance' list = 
    let N = list |> Seq.length |> float
    let sumXi = list |> Seq.sum
    let sumXi2 = list |> Seq.fold (fun acc x -> (x*x) + acc) 0.

    sumXi2/N - (sumXi*sumXi)/(N*N)

[3.;4.;5.;6.;7.] |> variance
[3.;4.;5.;6.;7.] |> variance'
(*** include-value: [3.;4.;5.;6.;7.] |> variance ***)
(*** include-value: [3.;4.;5.;6.;7.] |> variance' ***)
(**

#### raising salary
- +$1000 
    - $ \mu' = \mu + 1000 $
    - $ \sigma' = \sigma $
- +20%
    - $ \mu' = 1.2\mu $
    - $ \sigma' = 1.2\sigma $

#### [Standard Score]

$ z = \frac{x-\mu}{\sigma} $
*)
(**
[Variance]: https://www.udacity.com/course/viewer#!/c-st101/l-48684863
[Standard deviation]: http://en.wikipedia.org/wiki/Standard_deviation
[Standard Score]: http://en.wikipedia.org/wiki/Standard_score
*)