namespace CalculationLogic.ViewModels

open ViewModelBase
open System
open System.Collections.ObjectModel
open System.ComponentModel
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.Patterns
open System.Windows.Input
open Xamarin.Forms
open CalculationLogic
open CalculationLogic.Models

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
                self.Force<-
                    Cylinder.force state.force.area state.force.psi
            new Command(Action calc)

    member self.CalcPsiCommand
        with get() =
            let calc() =
                self.Psi <-
                    Cylinder.psi state.psi.force state.psi.area
            new Command(Action calc)

    member self.CalcSpeedCommand
        with get() =
            let calc() =
                self.Speed <-
                    Cylinder.inchesPerSecond state.speed.gpm state.speed.area
            new Command(Action calc)


    member self.ClearForceCommand
        with get() =
            let clear() =
                self.Force <- 0m;
                self.ForceArea<-0m;
                self.ForcePsi<-0m;
            new Command(Action clear)

    member self.ClearPsiCommand
        with get() =
            let clear() =
                self.Psi<-0m
                self.PsiArea<-0m
                self.PsiForce<-0m
            new Command(Action clear)

    member self.ClearSpeedCommand
        with get() =
            let clear() =
                self.Speed<-0m
                self.SpeedArea<-0m
                self.SpeedGpm <-0m

            new Command(Action clear)
