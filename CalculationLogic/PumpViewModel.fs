﻿namespace CalculationLogic.ViewModels

open Models.PumpStateModels
open ViewModelBase
open CalculationLogic
open Xamarin.Forms
open System


type PumpViewModel() =
    inherit ViewModelBase()

    let mutable state = {
        horsePower = {
            gpm = 0.0f;
            psi = 0.0f;
            out = 0.0f;
        };
        gpm = {
            rpm = 0.0f;
            displacement = 0.0f;
            out = 0.0f;
        };
        displacement = {
            rpm=  0.0f;
            gpm =  0.0f;
            out =  0.0f;
        }
    }

    member self.HorsePowerGpm
        with get() = state.horsePower.gpm
        and set(v) =
            state.horsePower.gpm <- v
            self.OnPropertyChanged(<@self.HorsePowerGpm@>)

    member self.HorsePowerPsi
        with get() = state.horsePower.psi
        and set(v) =
            state.horsePower.psi <- v
            self.OnPropertyChanged(<@self.HorsePowerPsi@>)

    member self.HorsePower
        with get() = state.horsePower.out
        and set(v) =
            state.horsePower.out<- v
            self.OnPropertyChanged(<@self.HorsePower@>)

    member self.GpmRpm
        with get()  = state.gpm.rpm
        and set(v) =
            state.gpm.rpm <- v
            self.OnPropertyChanged(<@self.GpmRpm@>)

    member self.GpmDisplacement
        with get() = state.gpm.displacement
        and set(v) =
            state.gpm.displacement <- v
            self.OnPropertyChanged(<@self.GpmDisplacement@>)

    member self.Gpm
        with get() = state.gpm.out
        and set(v) =
            state.gpm.out <- v
            self.OnPropertyChanged(<@self.Gpm@>)

    member self.DisplacementRpm
        with get() = state.displacement.rpm
        and set(v) =
            state.displacement.rpm <- v
            self.OnPropertyChanged(<@self.DisplacementRpm@>)

    member self.DisplacementGpm
        with get() = state.displacement.gpm
        and set(v) =
            state.displacement.gpm <- v
            self.OnPropertyChanged(<@self.DisplacementGpm@>)

    member self.Displacement
        with get() = state.displacement.out
        and set(v) =
            state.displacement.out <- v
            self.OnPropertyChanged(<@self.Displacement@>)

    member self.CalculateDisplacementCommand
      with get() =
          let calcDisplacement() =
              self.Displacement <-  Pump.displacementNeededForGPM self.DisplacementRpm self.DisplacementGpm
          new Command(Action calcDisplacement)

    member self.CalculateHorsePowerCommand
      with get() =
          let calcHorsePower() =
              self.HorsePower <-  Pump.hPRequired self.HorsePowerGpm self.HorsePowerPsi
          new Command(Action calcHorsePower)

    member self.CalculateGpmCommand
      with get() =
          let calcGpm() =
              self.Gpm <-  Pump.pumpOutputFlow self.GpmDisplacement self.GpmDisplacement
          new Command(Action calcGpm)

    member self.ClearDisplacementCommand
        with get() =
            let clearDisplacement() =
                self.Displacement <- 0.0f
                self.DisplacementRpm <- 0.0f
                self.DisplacementGpm <- 0.0f
            new Command(Action clearDisplacement)

    member self.ClearGpmCommand
        with get() =
            let clearGpm() =
                self.Gpm <- 0.0f
                self.GpmRpm <- 0.0f
                self.GpmDisplacement <- 0.0f
            new Command(Action clearGpm)

    member self.ClearHorsePowerCommand
        with get() =
            let clearHorsePower() =
                self.HorsePower <- 0.0f
                self.HorsePowerGpm <- 0.0f
                self.HorsePowerPsi <- 0.0f
            new Command(Action clearHorsePower)