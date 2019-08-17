namespace CalculationLogic.ViewModels

open ViewModelBase
open System
open Xamarin.Forms


type AboutViewModel() =
    inherit ViewModelBase()
    let mutable title : string = ""
    let mutable isBusy : bool = false
    let feedbackUrl = "https://trello.com/b/NDKBuLqs/hydraulic-toolbox"
    let openWebsite() = Device.OpenUri(new Uri(feedbackUrl))

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

    member self.OpenWebCommand = new Command(Action openWebsite)
