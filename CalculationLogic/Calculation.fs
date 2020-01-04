namespace CalculationLogic

open System
open System.Diagnostics

module CaseDrain =
    [<CompiledNameAttribute("CubicCentilitersPerMinute")>]
    let cubicCentilitersPerMinute (rpm : Decimal) ccir efficiency =
        try
            rpm * ccir - rpm * ccir * efficiency |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("CubicLitersPerMinute")>]
    let cubicLitersPerMinute rpm ccir efficiency =
        try
            cubicCentilitersPerMinute rpm ccir efficiency / 1000.0m |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("CubicGallonsPerMinute")>]
    let cubicGallonsPerMinute rpm ccir efficiency =
        try
            cubicLitersPerMinute rpm ccir efficiency / 3.79m |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    //j = g*h/231*60/i;
    [<CompiledNameAttribute("CubicGallonsPerMinuteNeededForCycleTime")>]
    let cycleTime area distance sec =
        try
            area * distance / 231.0m * 60.0m / sec |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

module Cylinder =
    [<CompiledNameAttribute("Force")>]
    let force area psi : Decimal =
        try
            area * psi |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("PSI")>]
    let psi force area : Decimal =
        try
            force / area |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("InchesPerSecond")>]
    let inchesPerSecond gpm area : Decimal =
        try
            231.0m * gpm / 60.0m * area |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

module Motor =
    [<CompiledNameAttribute("GPM")>]
    let gpm diameter rpm =
        try
            diameter * rpm / 231.0m |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("MotorSpeed")>]
    let motorSpeed gpm disp =
        try
            231.0m * gpm / disp |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("FluidMotorTorque")>]
    let fluidMotorTorque psi disp =
        try
            psi * disp / 6.28m |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("TorqueFromHP")>]
    let torqueFromHP hp rpm =
        try
            hp * 63025.0m / rpm |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("TorqueFromGPM")>]
    let torqueFromGPM gpm psi rpm =
        try
            gpm * psi * 36.7m / rpm |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("VelocityOfFluid")>]
    let velocityOfFluid gpm id =
        try
            0.3208m * gpm / id |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

module Pump =
    [<CompiledNameAttribute("HPRequired")>]
    let hPRequired gpm psi =
        try
            gpm * psi * 0.0007m |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("PumpOutputFlow")>]
    let pumpOutputFlow rpm disp =
        try
            rpm * disp / 231.0m |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()

    [<CompiledNameAttribute("DisplacementNeededForGPM ")>]
    let displacementNeededForGPM rpm gpm =
        try
            231.0m * gpm / rpm |> Decimal.Round
        with
        | :? DivideByZeroException -> 0m
        | ex ->
            Debug.WriteLine ex.Message
            reraise()


module Common =
    let Rounder(num : Decimal) = Decimal.Round