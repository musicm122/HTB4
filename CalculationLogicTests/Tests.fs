module Tests

open Xunit
open CalculationLogic
open CalculationLogic.ViewModels

[<Theory>]
[<InlineData(0.0, 0.0, 0.0, 0.0)>]
[<InlineData(0.0, 1.0, 0.0, 0.0)>]
[<InlineData(1.0, 1.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 2.0, -4.0)>]
[<InlineData(2.0, 2.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 10.0, -36.0)>]
[<InlineData(2.0, 2.0, 100.0, -396.0)>]
let ``Cubic Centimeter Per Minute Calculates Output Correctly `` (rpm, ccir, eff, expected) =
    let actual = CaseDrain.cubicCentilitersPerMinute rpm ccir eff
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData(2.0, 2.0, 2.0, -0.004)>]
[<InlineData(2.0, 2.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 10.0, -0.036)>]
[<InlineData(2.0, 2.0, 100.0, -0.396)>]
let ``Cubic Liters Per Minute Calculates Output Correctly`` (rpm, ccir, eff, expected) =
    let actual = CaseDrain.cubicLitersPerMinute rpm ccir eff
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData(0.0, 0.0, 0.0, 0.0)>]
[<InlineData(0.0, 1.0, 0.0, 0.0)>]
[<InlineData(1.0, 1.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 2.0, -4.0)>]
[<InlineData(2.0, 2.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 10.0, -36.0)>]
[<InlineData(2.0, 2.0, 100.0, -396.0)>]
let ``Case Drain View Model Populates Output CCMin Correctly`` (rpm, ccir, eff, expected) =
    let vm = CaseDrainViewModel()
    vm.Rpm <- rpm
    vm.CCRev <- ccir
    vm.Efficency <- eff
    vm.CalculateCaseDrainCommand.Execute(null)
    Assert.Equal(expected, vm.CCMinOut)

[<Theory>]
[<InlineData(1.0, 1.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 2.0, -0.004)>]
[<InlineData(2.0, 2.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 10.0, -0.036)>]
[<InlineData(2.0, 2.0, 100.0, -0.396)>]
let ``Case Drain View Model Populates Output LMinOut Correctly`` (rpm, ccir, eff, expected) =
    let vm = CaseDrainViewModel()
    vm.Rpm <- rpm
    vm.CCRev <- ccir
    vm.Efficency <- eff
    vm.CalculateCaseDrainCommand.Execute(null)
    Assert.Equal(expected, vm.LMinOut)
(*
[<Fact>]
let ``Calculations should be rounded to the nearest hundredths place`` =
    let vm CaseDrainViewModel = CaseDrainViewModel()
*)


[<Theory>]
[<InlineData(1.0, 1.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 1.0, 0.0)>]
[<InlineData(120.0, 20.0, 2.0, -0.001055408971)>]
[<InlineData(1020.0, 3200.0, 90.0, -7664.802111)>]
[<InlineData(3200.0, 200.0, 100.0, -0.1044854881)>]
[<InlineData(200.0, 200.0, 100.0, -1044.854881)>]
let ``Case Drain View Model Populates Output GPM Correctly`` (rpm, ccir, eff, expected) =
    let vm = new CaseDrainViewModel()
    vm.Rpm <- rpm
    vm.CCRev <- ccir
    vm.Efficency <- eff
    vm.CalculateCaseDrainCommand.Execute(null)
    Assert.Equal(expected, vm.CaseDrainGpmOut)
//https://racingcalcs.com/air-mass-flow-of-engine-calculator/
// https://racingcalcs.com/menu-engine/
