namespace CalculationLogic.ViewModels

open Models
open ViewModelBase
open System
open System.Collections.ObjectModel
open System.ComponentModel
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.Patterns
open System.Windows.Input
open Xamarin.Forms
open CalculationLogic

type CylinderViewModel() =
    inherit ViewModelBase()

    let mutable state = CylinderState.Init

    member self.ForceArea
        with get() = state.force.area
        and set(v) =
            state.force.area <- v
            self.OnPropertyChanged(<@self.ForceArea@>)

    member self.ForcePsi
        with get() = state.force.psi
        and set(v) =
            state.force.psi <- v
            self.OnPropertyChanged(<@self.ForcePsi@>)

    member self.Force
        with get() = state.force.out
        and set(v) =
            state.force.out <- v
            self.OnPropertyChanged(<@self.Force@>)

    member self.PsiForce
        with get() = state.psi.force
        and set(v) =
            state.psi.force<- v
            self.OnPropertyChanged(<@self.PsiForce@>)

    member self.Psi
        with get() = state.psi.out
        and set(v) =
            state.psi.out<- v
            self.OnPropertyChanged(<@self.Psi@>)


    member self.PsiArea
        with get() = state.psi.area
        and set(v) =
            state.psi.area <- v
            self.OnPropertyChanged(<@self.PsiArea@>)

    member self.SpeedArea
        with get() = state.speed.area
        and set(v) =
            state.speed.area <- v
            self.OnPropertyChanged(<@self.SpeedArea@>)

    member self.SpeedGpm
        with get() = state.speed.gpm
        and set(v) =
            state.speed.gpm <- v
            self.OnPropertyChanged(<@self.SpeedGpm@>)

    member self.Speed
        with get() = state.speed.out
        and set(v) =
            state.speed.out<- v
            self.OnPropertyChanged(<@self.Speed@>)


    member self.CalcForceCommand
        with get() =
            let calc() =
                state.force.out <-
                    Cylinder.force state.force.area state.force.psi
            new Command(Action calc)

    member self.CalcPsiCommand
        with get() =
            let calc() =
                state.psi.out <-
                    Cylinder.psi state.psi.force state.psi.area
            new Command(Action calc)

    member self.CalcSpeedCommand
        with get() =
            let calc() =
                state.speed.out <-
                    Cylinder.inchesPerSecond state.speed.gpm state.speed.area
            new Command(Action calc)


    member self.ClearForceCommand
        with get() =
            let clear() =
                state.force.Init
            new Command(Action clear)

    member self.ClearPsiCommand
        with get() =
            let clear() =
                state.psi.Init
            new Command(Action clear)

    member self.ClearSpeedCommand
        with get() =
            let clear() =
                state.speed.Init
            new Command(Action clear)
