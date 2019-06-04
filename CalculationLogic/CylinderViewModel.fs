namespace CalculationLogic.ViewModels

open Models.CylinderStateModels
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

    let mutable state = {
        force = {
            area = 0.0f;
            psi = 0.0f;
            out = 0.0f;
        };
        psi = {
            force = 0.0f;
            area = 0.0f;
            out = 0.0f;
        };
        speed = {
            area =  0.0f;
            gpm =  0.0f;
            out =  0.0f;
        }
    }

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

