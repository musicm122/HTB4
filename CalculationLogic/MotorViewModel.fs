namespace CalculationLogic.ViewModels

open Models.MotorStateModel
open ViewModelBase
open CalculationLogic
open Xamarin.Forms
open System

type MotorViewModel() =
    inherit ViewModelBase()

    let mutable state:MotorState = {
        gpm = {
            diameter= 0.0f;
            rpm = 0.0f;
            out = 0.0f;
        };
        motorSpeed = {
            gpm = 0.0f;
            displacement = 0.0f;
            out = 0.0f;
        };
        fluidMotionTorque = {
            psi = 0.0f;
            displacement = 0.0f;
            out = 0.0f;
        }
    }

    member self.GpmDiameter
        with get() = state.gpm.diameter
        and set(v) =
            state.gpm.diameter<- v
            self.OnPropertyChanged(<@self.GpmDiameter@>)
    member self.GpmRpm
        with get() = state.gpm.rpm
        and set(v) =
            state.gpm.rpm<- v
            self.OnPropertyChanged(<@self.GpmRpm@>)
    member self.Gpm
        with get() = state.gpm.out
        and set(v) =
            state.gpm.out<- v
            self.OnPropertyChanged(<@self.Gpm@>)
