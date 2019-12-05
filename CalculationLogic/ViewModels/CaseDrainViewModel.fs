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

    member self.Area
        with get () = state.area
        and set (v : decimal) =
            state.area <- v
            self.OnPropertyChanged(<@ self.Area @>)

    member self.Distance
        with get () = state.distance
        and set (v : decimal) =
            state.distance <- v
            self.OnPropertyChanged(<@ self.Distance @>)

    member self.Second
        with get () = state.second
        and set (v : decimal) =
            state.second <- v
            self.OnPropertyChanged(<@ self.Second @>)

    member self.CaseDrainGpmOut
        with get () = state.caseDrainGpmOut
        and set (v : decimal) =
            state.caseDrainGpmOut <- v
            self.OnPropertyChanged(<@ self.CaseDrainGpmOut @>)

    member self.CycleTimeGpmOut
        with get () = state.cycleTimeGpmOut
        and set (v : decimal) =
            state.cycleTimeGpmOut <- v
            self.OnPropertyChanged(<@ self.CycleTimeGpmOut @>)

    member self.CalculateCaseDrainCommand =
        let calculateCaseDrain() =
            self.CCMinOut <- CaseDrain.cubicCentilitersPerMinute self.Rpm self.CCRev self.Efficency
            self.LMinOut <- CaseDrain.cubicLitersPerMinute self.Rpm self.CCRev self.Efficency
            self.CaseDrainGpmOut <- CaseDrain.cubicGallonsPerMinute self.Rpm self.CCRev self.Efficency
        Command(Action calculateCaseDrain)

    member self.CalculateCycleTimeCommand =
        let calculateCycleTime() =
            try
                self.CycleTimeGpmOut <- CaseDrain.cycleTime self.Area self.Distance self.Second
            with ex -> Debug.Write(ex.Message + ex.StackTrace)
        Command(Action calculateCycleTime)

    member self.ClearCaseDrainCommand =
        let clearCaseDrain() =
            self.Rpm <- 0.0m
            self.CCRev <- 0.0m
            self.Efficency <- 0.0m
            self.CCMinOut <- 0.0m
            self.LMinOut <- 0.0m
            self.CaseDrainGpmOut <- 0.0m
        Command(Action clearCaseDrain)

    member self.ClearCycleTimeCommand =
        let clearCycleTime() =
            self.Area <- 0.0m
            self.Distance <- 0.0m
            self.Second <- 0.0m
            self.CycleTimeGpmOut <- 0.0m
        Command(Action clearCycleTime)
