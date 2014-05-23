(*** hide ***)
#I ".."
#load "packages/FsLab.0.0.13-beta/FsLab.fsx"
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
    let count = list |> Seq.length
    let mean = list.Mean()

    (list |> Seq.map (fun x -> (x-mean)*(x-mean)) |> Seq.sum)/(float(count))


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

MEAN = $ \mu = \frac{1}{N}\sum_{i=1}^Nx_i$

VARIANCE = $ \sigma^2 = \frac{1}{N}\sum_{i=1}^N(x_i-\mu)^2 $

STANDARD DEVIATION = $ \sigma = \sqrt{VARIANCE} $

Let's simplify how to calculate $ \sigma^2 $:

$ \sigma^2 = \frac{1}{N}\sum_{i=1}^N(x_i-\mu)^2 $

$ \sigma^2 = \frac{1}{N}\sum_{i=1}^N(x_i-\mu)(x_i-\mu) $

$ \sigma^2 = \frac{1}{N}\sum_{i=1}^N[x_i^2-2x_i\mu+\mu^2] $

$ \sigma^2 = \frac{1}{N}\sum_{i=1}^Nx_i^2-\frac{2\mu}{N}\sum_{i=1}^Nx_i + \mu^2 $
 
$ \sigma^2 = \frac{1}{N}\sum_{i=1}^Nx_i^2-2\mu\mu + \mu^2 $
 
$ \sigma^2 = \frac{1}{N}\sum_{i=1}^Nx_i^2- \mu^2 $
 
$ \sigma^2 = \frac{1}{N}\sum_{i=1}^Nx_i^2- \frac{1}{N^2}(\sum_{i=1}^Nx_i)^2 $

So we need to calculate only the following to get $ \sigma^2 $

- N
- $ \sum_{i=1}^Nx_i $
- $ \sum_{i=1}^Nx_i^2 $

*)

(**
[Variance]: https://www.udacity.com/course/viewer#!/c-st101/l-48684863
[Standard deviation]: http://en.wikipedia.org/wiki/Standard_deviation
*)