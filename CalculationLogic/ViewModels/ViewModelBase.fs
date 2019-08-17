module ViewModelBase

open System
open System.Collections.ObjectModel
open System.ComponentModel
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.Patterns
open System.Windows.Input
open Xamarin.Forms

type ViewModelBase() =
    let propertyChanged = new Event<_, _>()

    let toPropName (query : Expr) =
        match query with
        | PropertyGet(a, b, list) -> b.Name
        | _ -> ""

    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member x.PropertyChanged = propertyChanged.Publish

    abstract OnPropertyChanged : string -> unit
    override x.OnPropertyChanged(propertyName : string) =
        propertyChanged.Trigger(x, PropertyChangedEventArgs(propertyName))
    member x.OnPropertyChanged(expr : Expr) =
        let propName = toPropName (expr)
        x.OnPropertyChanged(propName)

[<AbstractClass>]
type BaseCalculationViewModel() =
    inherit ViewModelBase()
    abstract Clear : unit -> unit
    member self.ClearCommand = Command(self.Clear)
