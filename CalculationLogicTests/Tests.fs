module Tests

open System
open Xunit
open CalculationLogic
open CalculationLogic.Models
open CalculationLogic.ViewModels

[<Theory>]
[<InlineData(0.0, 0.0, 0.0, 0.0)>]
[<InlineData(0.0, 1.0, 0.0, 0.0)>]
[<InlineData(1.0, 1.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 2.0, -4.0)>]
[<InlineData(2.0, 2.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 10.0, -36.0)>]
[<InlineData(2.0, 2.0, 100.0, -396.0)>]
let ``Cubic Centimeter Per Minute Calculates Output Correctly `` (rpm, ccir, eff,
                                                                  expected) =
    let actual = CaseDrain.cubicCentilitersPerMinute rpm ccir eff
    Assert.Equal(expected, actual)

[<Theory>]
[<InlineData(2.0, 2.0, 2.0, -0.004)>]
[<InlineData(2.0, 2.0, 1.0, 0.0)>]
[<InlineData(2.0, 2.0, 10.0, -0.036)>]
[<InlineData(2.0, 2.0, 100.0, -0.396)>]
let ``Cubic Liters Per Minute Calculates Output Correctly`` (rpm, ccir, eff,
                                                             expected) =
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
let ``Case Drain View Model Populates Output CCMin Correctly`` (rpm, ccir, eff,
                                                                expected) =
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
let ``Case Drain View Model Populates Output LMinOut Correctly`` (rpm, ccir, eff,
                                                                  expected) =
    let vm = CaseDrainViewModel()
    vm.Rpm <- rpm
    vm.CCRev <- ccir
    vm.Efficency <- eff
    vm.CalculateCaseDrainCommand.Execute(null)
    Assert.Equal(expected, vm.LMinOut)
//[<Theory>]
//[<InlineData(1.0, 1.0, 1.0, 0.0)>]
//[<InlineData(2.0, 2.0, 1.0, 0.0)>]
//[<InlineData(120.0, 20.0, 2.0, -0.0010554089709762532981530343)>]
//[<InlineData(1020.0, 3200.0, 90.0, -7664.8021108179419525065963061)>]
//[<InlineData(3200.0, 200.0, 100.0, -0.1044854881266490765171503958)>]
//[<InlineData(200.0, 200.0, 100.0, -1044.8548812664907651715039578)>]
//let ``Case Drain View Model Populates Output GPM Correctly`` (rpm, ccir, eff, expected) =
//    let vm = new CaseDrainViewModel()
//    vm.Rpm<-rpm
//    vm.CCRev<-ccir
//    vm.Efficency<- eff
//    vm.CalculateCaseDrainCommand.Execute(null)
//    Assert.Equal(expected, vm.CaseDrainGpmOut)
// https://racingcalcs.com/air-mass-flow-of-engine-calculator/
// https://racingcalcs.com/menu-engine/
