namespace CalculationLogic.ViewModels


open ViewModelBase
open CalculationLogic
open Xamarin.Forms
open System
open Models

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