namespace CalculationLogic.ViewModels

open ViewModelBase
open CalculationLogic
open Xamarin.Forms
open System
open CalculationLogic.Models

type TorqueViewModel() =
    inherit ViewModelBase()

    let mutable state = TorqueState.Init

    member self.HpTorqueHP
        with get() = state.torqueFromHP.hp
        and set(v) =
            state.torqueFromHP.hp <- v
            self.OnPropertyChanged(<@self.HpTorqueHP@>)

    member self.HpTorqueRpm
        with get() = state.torqueFromHP.rpm
        and set(v) =
            state.torqueFromHP.rpm <- v
            self.OnPropertyChanged(<@self.HpTorqueRpm@>)

    member self.HpTorque
        with get() = state.torqueFromHP.out
        and set(v) =
            state.torqueFromHP.rpm <- v
            self.OnPropertyChanged(<@self.HpTorque@>)

    member self.GpmTorqueGpm
        with get() = state.torqueFromGPM.gpm
        and set(v) =
            state.torqueFromGPM.gpm<- v
            self.OnPropertyChanged(<@self.GpmTorque@>)

    member self.GpmTorquePsi
        with get() = state.torqueFromGPM.psi
        and set(v) =
            state.torqueFromGPM.psi <- v
            self.OnPropertyChanged(<@self.GpmTorquePsi@>)

    member self.GpmTorqueRpm
        with get() = state.torqueFromGPM.rpm
        and set(v) =
            state.torqueFromGPM.rpm <- v
            self.OnPropertyChanged(<@self.GpmTorqueRpm@>)

    member self.GpmTorque
        with get() = state.torqueFromGPM.out
        and set(v) =
            state.torqueFromGPM.out <- v
            self.OnPropertyChanged(<@self.GpmTorque@>)

    member self.VelocityGpm
        with get() = state.velocity.gpm
        and set(v) =
            state.velocity.gpm <- v
            self.OnPropertyChanged(<@self.VelocityGpm@>)

    member self.VelocityId
        with get() = state.velocity.id
        and set(v) =
            state.velocity.id <- v
            self.OnPropertyChanged(<@self.VelocityId@>)

    member self.Velocity
        with get() = state.velocity.out
        and set(v) =
            state.velocity.out <- v
            self.OnPropertyChanged(<@self.Velocity@>)

    member self.CalcHpTorqueCommand
        with get() =
            let calc() =
                state.torqueFromHP.out <-
                    Motor.torqueFromHP
                        state.torqueFromHP.hp
                        state.torqueFromHP.rpm
            new Command(Action calc)

    member self.ClearHpTorqueCommand
        with get() =
            let clear() =
                state.torqueFromHP.Init
            new Command(Action clear)

    member self.CalcGpmTorqueCommand
        with get() =
            let calc() =
                state.torqueFromGPM.out <-
                    Motor.torqueFromGPM
                        state.torqueFromGPM.gpm
                        state.torqueFromGPM.psi
                        state.torqueFromGPM.rpm
            new Command(Action calc)

    member self.ClearGpmTorqueCommand
        with get() =
            let clear() =
                state.torqueFromGPM.Init
            new Command(Action clear)

    member self.CalcVelocityCommand
        with get() =
            let calc() =
                state.velocity.out <-
                    Motor.velocityOfFluid
                        state.velocity.gpm
                        state.velocity.id
            new Command(Action calc)

    member self.ClearVelocityCommand
        with get() =
            let clear() =
                state.velocity.Init
            new Command(Action clear)