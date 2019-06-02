namespace CalculationLogic

module CaseDrain =

    [<CompiledNameAttribute("CubicCentilitersPerMinute")>]
    let cubicCentilitersPerMinute rpm ccir efficiency =
        rpm * ccir - rpm * ccir * efficiency

    [<CompiledNameAttribute("CubicLitersPerMinute")>]
    let cubicLitersPerMinute rpm ccir efficiency =
        cubicCentilitersPerMinute rpm ccir efficiency / 1000.0f

    [<CompiledNameAttribute("CubicGallonsPerMinute")>]
    let cubicGallonsPerMinute rpm ccir efficiency =
        cubicLitersPerMinute rpm ccir efficiency / 3.79f

    //j = g*h/231*60/i;
    [<CompiledNameAttribute("CubicGallonsPerMinuteNeededForCycleTime")>]
    let cycleTime area distance sec =
        area * distance / 231.0f * 60.0f/sec


module Cylinder =

    [<CompiledNameAttribute("Force")>]
    let force area psi =
        area * psi

    [<CompiledNameAttribute("PSI")>]
    let psi force area =
        force / area

    [<CompiledNameAttribute("InchesPerSecond")>]
    let inchesPerSecond gpm area =
        231.0f * gpm / 60.0f * area


module Motor =
    [<CompiledNameAttribute("GPM")>]
    let gpm diameter rpm =
        diameter * rpm / 231.0f

    [<CompiledNameAttribute("MotorSpeed")>]
    let motorSpeed gpm disp =
        231.0f * gpm / disp

    [<CompiledNameAttribute("FluidMotorTorque")>]
    let fluidMotorTorque psi disp =
        psi * disp / 6.28f

    [<CompiledNameAttribute("TorqueFromHP")>]
    let torqueFromHP hp rpm =
        hp * 63025.0f / rpm

    [<CompiledNameAttribute("TorqueFromGPM")>]
    let torqueFromGPM gpm psi rpm =
        gpm * psi * 36.7f / rpm

    [<CompiledNameAttribute("VelocityOfFluid")>]
    let velocityOfFluid gpm id =
        0.3208f * gpm / id

module Pump =
    [<CompiledNameAttribute("HPRequired")>]
    let hPRequired gpm psi =
        gpm * psi * 0.0007f;

    [<CompiledNameAttribute("PumpOutputFlow")>]
    let pumpOutputFlow rpm disp =
        rpm * disp / 231.0f;

    [<CompiledNameAttribute("DisplacementNeededForGPM ")>]
    let displacementNeededForGPM rpm gpm =
        231.0f * gpm / rpm;
