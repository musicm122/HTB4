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

type CaseDrainViewModel() =
    inherit ViewModelBase()

    let mutable rpm : float32 = 0.0f
    let mutable cCRev : float32= 0.0f
    let mutable efficency : float32= 0.0f
    let mutable cCMinOut : float32 = 0.0f
    let mutable lMinOut : float32 = 0.0f
    let mutable area : float32 = 0.0f
    let mutable distance : float32 = 0.0f
    let mutable second : float32 = 0.0f
    let mutable caseDrainGpmOut : float32 = 0.0f
    let mutable cycleTimeGpmOut : float32 = 0.0f

    member self.Rpm
      with get() = rpm
      and set(v:float32) =
        rpm <- v
        self.OnPropertyChanged(<@self.Rpm@>)

    member self.CCRev
      with get() = cCRev
      and set(v:float32) =
        cCRev <- v
        self.OnPropertyChanged(<@self.CCRev@>)

    member self.Efficency
      with get() = efficency
      and set(v:float32) =
        efficency <- v
        self.OnPropertyChanged(<@self.Efficency@>)

    member self.CCMinOut
      with get() = cCMinOut
      and set(v:float32) =
        cCMinOut <- v
        self.OnPropertyChanged(<@self.CCMinOut@>)

    member self.LMinOut
      with get() = lMinOut
      and set(v:float32) =
        lMinOut <- v
        self.OnPropertyChanged(<@self.LMinOut@>)

    member self.Area
      with get() = area
      and set(v:float32) =
        area <- v
        self.OnPropertyChanged(<@self.Area@>)

    member self.Distance
      with get() = distance
      and set(v:float32) =
        distance <- v
        self.OnPropertyChanged(<@self.Distance@>)

    member self.Second
      with get() = second
      and set(v:float32) =
        second <- v
        self.OnPropertyChanged(<@self.Second@>)

    member self.CaseDrainGpmOut
      with get() = caseDrainGpmOut
      and set(v:float32) =
        caseDrainGpmOut <- v
        self.OnPropertyChanged(<@self.CaseDrainGpmOut@>)

    member self.CycleTimeGpmOut
      with get() = cycleTimeGpmOut
      and set(v:float32) =
        cycleTimeGpmOut <- v
        self.OnPropertyChanged(<@self.CycleTimeGpmOut@>)

    member self.CalculateCaseDrainCommand
      with get() =
        let calculateCaseDrain() =
            self.CCMinOut <- CaseDrain.cubicCentilitersPerMinute self.Rpm self.CCRev self.Efficency
            self.LMinOut <- CaseDrain.cubicLitersPerMinute self.Rpm self.CCRev self.Efficency
            self.CaseDrainGpmOut <- CaseDrain.cubicGallonsPerMinute self.Rpm self.CCRev self.Efficency

        new Command(Action calculateCaseDrain)

    member self.CalculateCycleTimeCommand
      with get() =
          let calculateCycleTime() =
              self.CycleTimeGpmOut <- CaseDrain.cycleTime self.Area self.Distance self.Second;
          new Command(Action calculateCycleTime)

    member self.ClearCaseDrainCommand
        with get() =
            let clearCaseDrain() =
                self.Rpm<- 0.0f
                self.CCRev<-0.0f
                self.Efficency<-0.0f
                self.CCMinOut<-0.0f
                self.LMinOut<-0.0f
                self.CaseDrainGpmOut <-0.0f
            new Command(Action clearCaseDrain)

    member self.ClearCycleTimeCommand
        with get() =
            let clearCycleTime() =
                self.Area<-0.0f
                self.Distance<-0.0f
                self.Second<-0.0f
                self.CycleTimeGpmOut<-0.0f
            new Command(Action clearCycleTime)
