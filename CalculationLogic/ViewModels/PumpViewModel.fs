namespace CalculationLogic.ViewModels

open CalculationLogic.Models
open ViewModelBase
open CalculationLogic
open Xamarin.Forms
open System

type PumpViewModel() =
    inherit ViewModelBase()
    let mutable state = PumpState.Init

    member self.HorsePowerGpm
        with get () = state.horsePower.gpm
        and set (v) =
            state.horsePower.gpm <- v
            self.OnPropertyChanged(<@ self.HorsePowerGpm @>)

    member self.HorsePowerPsi
        with get () = state.horsePower.psi
        and set (v) =
            state.horsePower.psi <- v
            self.OnPropertyChanged(<@ self.HorsePowerPsi @>)

    member self.HorsePower
        with get () = state.horsePower.out
        and set (v) =
            state.horsePower.out <- v
            self.OnPropertyChanged(<@ self.HorsePower @>)

    member self.GpmRpm
        with get () = state.gpm.rpm
        and set (v) =
            state.gpm.rpm <- v
            self.OnPropertyChanged(<@ self.GpmRpm @>)

    member self.GpmDisplacement
        with get () = state.gpm.displacement
        and set (v) =
            state.gpm.displacement <- v
            self.OnPropertyChanged(<@ self.GpmDisplacement @>)

    member self.Gpm
        with get () = state.gpm.out
        and set (v) =
            state.gpm.out <- v
            self.OnPropertyChanged(<@ self.Gpm @>)

    member self.DisplacementRpm
        with get () = state.displacement.rpm
        and set (v) =
            state.displacement.rpm <- v
            self.OnPropertyChanged(<@ self.DisplacementRpm @>)

    member self.DisplacementGpm
        with get () = state.displacement.gpm
        and set (v) =
            state.displacement.gpm <- v
            self.OnPropertyChanged(<@ self.DisplacementGpm @>)

    member self.Displacement
        with get () = state.displacement.out
        and set (v) =
            state.displacement.out <- v
            self.OnPropertyChanged(<@ self.Displacement @>)

    member self.CalcDisplacementCommand =
        let calcDisplacement() =
            self.Displacement <-
                            Pump.displacementNeededForGPM state.displacement.rpm
                                state.displacement.gpm
        new Command(Action calcDisplacement)

    member self.CalcHorsePowerCommand =
        let calcHorsePower() =
            self.HorsePower <-
                            Pump.hPRequired state.horsePower.gpm
                                state.horsePower.psi
        new Command(Action calcHorsePower)

    member self.CalcGpmCommand =
        let calcGpm() =
            self.Gpm <-
                            Pump.pumpOutputFlow state.gpm.rpm
                                state.gpm.displacement
        new Command(Action calcGpm)

    member self.ClearDisplacementCommand =
        let clear() =
            self.Displacement <- 0m
            self.DisplacementGpm <- 0m
            self.DisplacementRpm <- 0m
        new Command(Action clear)

    member self.ClearGpmCommand =
        let clear() =
            self.Gpm <- 0m
            self.GpmDisplacement <- 0m
            self.GpmRpm <- 0m
        new Command(Action clear)

    member self.ClearHorsePowerCommand =
        let clear() =
            self.HorsePower <- 0m
            self.HorsePowerGpm <- 0m
            self.HorsePowerPsi <- 0m
        new Command(Action clear)
