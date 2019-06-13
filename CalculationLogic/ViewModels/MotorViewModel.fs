namespace CalculationLogic.ViewModels

open ViewModelBase
open CalculationLogic
open Xamarin.Forms
open System
open CalculationLogic.Models

type MotorViewModel() =
    inherit ViewModelBase()

    let mutable state = MotorState.Init

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

    member self.MotorSpeedGpm
        with get() = state.motorSpeed.gpm
        and set(v) =
            state.motorSpeed.gpm<-v
            self.OnPropertyChanged(<@self.MotorSpeedGpm@>)

    member self.MotorSpeedDisplacement
        with get() = state.motorSpeed.displacement
        and set(v) =
            state.motorSpeed.displacement<-v
            self.OnPropertyChanged(<@self.MotorSpeedDisplacement@>)

    member self.MotorSpeed
        with get() = state.motorSpeed.out
        and set(v) =
            state.motorSpeed.out<-v
            self.OnPropertyChanged(<@self.MotorSpeed@>)

    member self.FluidMotionPsi
        with get() = state.fluidMotionTorque.psi
        and set(v) =
            state.fluidMotionTorque.psi <- v
            self.OnPropertyChanged(<@self.FluidMotionPsi@>)

    member self.FluidMotionDisplacement
        with get() = state.fluidMotionTorque.displacement
        and set(v) =
            state.fluidMotionTorque.displacement <- v
            self.OnPropertyChanged(<@self.FluidMotionDisplacement@>)

    member self.FluidMotion
        with get() = state.fluidMotionTorque.out
        and set(v) =
            state.fluidMotionTorque.out <- v
            self.OnPropertyChanged(<@self.FluidMotion@>)

    member self.CalcFluidMotionCommand
        with get() =
            let calc() =
                state.fluidMotionTorque.out <-
                    Motor.fluidMotorTorque
                        state.fluidMotionTorque.psi
                        state.fluidMotionTorque.displacement
            new Command(Action calc)

    member self.ClearFluidMotionCommand
        with get() =
            let clear() =
                state.fluidMotionTorque.Init
            new Command(Action clear)

    member self.CalcGpmCommand
        with get() =
            let calc() =
                state.gpm.out <-
                    Motor.gpm
                        state.gpm.diameter
                        state.gpm.rpm
            new Command(Action calc)

    member self.ClearGpmCommand
        with get() =
            let clear() =
                state.gpm.Init
            new Command(Action clear)

    member self.CalcSpeedCommand
        with get() =
            let calc() =
                state.motorSpeed.out <-
                    Motor.motorSpeed
                        state.motorSpeed.gpm
                        state.motorSpeed.displacement
            new Command(Action calc)

    member self.ClearSpeedCommand
        with get() =
            let clear() =
                state.motorSpeed.Init
            new Command(Action clear)