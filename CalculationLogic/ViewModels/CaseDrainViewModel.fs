namespace CalculationLogic.ViewModels

open ViewModelBase
open System
open Xamarin.Forms
open CalculationLogic
open CalculationLogic.Models
open System.Diagnostics

type CaseDrainViewModel() =
    inherit ViewModelBase()
    let mutable state = CaseDrainState.Init

    member self.Rpm
        with get () = state.rpm
        and set (v : decimal) =
            state.rpm <- v
            self.OnPropertyChanged(<@ self.Rpm @>)

    member self.CCRev
        with get () = state.cCRev
        and set (v : decimal) =
            state.cCRev <- v
            self.OnPropertyChanged(<@ self.CCRev @>)

    member self.Efficency
        with get () = state.efficency
        and set (v : decimal) =
            state.efficency <- v
            self.OnPropertyChanged(<@ self.Efficency @>)

    member self.CCMinOut
        with get () = state.cCMinOut
        and set (v : decimal) =
            state.cCMinOut <- v
            self.OnPropertyChanged(<@ self.CCMinOut @>)

    member self.LMinOut
        with get () = state.lMinOut
        and set (v : decimal) =
            state.lMinOut <- v
            self.OnPropertyChanged(<@ self.LMinOut @>)

    member self.CaseDrainGpmOut
        with get () = state.caseDrainGpmOut
        and set (v : decimal) =
            state.caseDrainGpmOut <- v
            self.OnPropertyChanged(<@ self.CaseDrainGpmOut @>)

    member self.CalculateCaseDrainCommand =
        let calculateCaseDrain() =
            self.CCMinOut <- CaseDrain.cubicCentilitersPerMinute self.Rpm self.CCRev self.Efficency
            self.LMinOut <- CaseDrain.cubicLitersPerMinute self.Rpm self.CCRev self.Efficency
            self.CaseDrainGpmOut <- CaseDrain.cubicGallonsPerMinute self.Rpm self.CCRev self.Efficency
        Command(Action calculateCaseDrain)

    member self.ClearCaseDrainCommand =
        let clearCaseDrain() =
            self.Rpm <- 0.0m
            self.CCRev <- 0.0m
            self.Efficency <- 0.0m
            self.CCMinOut <- 0.0m
            self.LMinOut <- 0.0m
            self.CaseDrainGpmOut <- 0.0m
        Command(Action clearCaseDrain)