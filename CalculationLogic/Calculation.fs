namespace CalculationLogic

open System

module CaseDrain =

    [<CompiledNameAttribute("CubicCentilitersPerMinute")>]
    let cubicCentilitersPerMinute (rpm:Decimal) ccir efficiency =
        rpm * ccir - rpm * ccir * efficiency

    [<CompiledNameAttribute("CubicLitersPerMinute")>]
    let cubicLitersPerMinute rpm ccir efficiency =
        cubicCentilitersPerMinute rpm ccir efficiency / 1000.0m

    [<CompiledNameAttribute("CubicGallonsPerMinute")>]
    let cubicGallonsPerMinute rpm ccir efficiency =
        cubicLitersPerMinute rpm ccir efficiency / 3.79m

    //j = g*h/231*60/i;
    [<CompiledNameAttribute("CubicGallonsPerMinuteNeededForCycleTime")>]
    let cycleTime area distance sec =
        area * distance / 231.0m * 60.0m/sec


module Cylinder =

    [<CompiledNameAttribute("Force")>]
    let force area psi:Decimal =
        area * psi

    [<CompiledNameAttribute("PSI")>]
    let psi force area:Decimal =
        force / area

    [<CompiledNameAttribute("InchesPerSecond")>]
    let inchesPerSecond gpm area:Decimal =
        231.0m * gpm / 60.0m * area


module Motor =
    [<CompiledNameAttribute("GPM")>]
    let gpm diameter rpm =
        diameter * rpm / 231.0m

    [<CompiledNameAttribute("MotorSpeed")>]
    let motorSpeed gpm disp =
        231.0m * gpm / disp

    [<CompiledNameAttribute("FluidMotorTorque")>]
    let fluidMotorTorque psi disp =
        psi * disp / 6.28m

    [<CompiledNameAttribute("TorqueFromHP")>]
    let torqueFromHP hp rpm =
        hp * 63025.0m / rpm

    [<CompiledNameAttribute("TorqueFromGPM")>]
    let torqueFromGPM gpm psi rpm =
        gpm * psi * 36.7m / rpm

    [<CompiledNameAttribute("VelocityOfFluid")>]
    let velocityOfFluid gpm id =
        0.3208m * gpm / id

module Pump =
    [<CompiledNameAttribute("HPRequired")>]
    let hPRequired gpm psi =
        gpm * psi * 0.0007m;

    [<CompiledNameAttribute("PumpOutputFlow")>]
    let pumpOutputFlow rpm disp =
        rpm * disp / 231.0m;

    [<CompiledNameAttribute("DisplacementNeededForGPM ")>]
    let displacementNeededForGPM rpm gpm =
        231.0m * gpm / rpm;
