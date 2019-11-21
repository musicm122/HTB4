namespace CalculationLogic.ViewModels

open ViewModelBase
open System
open Xamarin.Essentials
open Xamarin.Forms

type AboutViewModel() =
    inherit ViewModelBase()
    let mutable title : string = ""
    let mutable isBusy : bool = false
    let feedbackUrl = "https://trello.com/b/NDKBuLqs/hydraulic-toolbox"

    let openWebsite() =
        async { Launcher.OpenAsync(Uri(feedbackUrl)) |> ignore }
        |> Async.RunSynchronously
        |> ignore

    member self.Title
        with get () = title
        and set (v : string) =
            title <- v
            self.OnPropertyChanged(<@ self.Title @>)

    member self.IsBusy
        with get () = isBusy
        and set (v : bool) =
            isBusy <- v
            self.OnPropertyChanged(<@ self.IsBusy @>)

    member self.OpenWebCommand = Command(Action openWebsite)
