namespace CalculationLogic.Models

module CaseDrainState =

    type T = {
        mutable rpm : decimal
        mutable cCRev :decimal
        mutable efficency :decimal
        mutable cCMinOut : decimal
        mutable lMinOut : decimal
        mutable area : decimal
        mutable distance : decimal
        mutable second : decimal
        mutable caseDrainGpmOut : decimal
        mutable cycleTimeGpmOut : decimal
    }

    let Init = {
        rpm = 0.0m;
        cCRev = 0.0m;
        efficency = 0.0m;
        cCMinOut = 0.0m;
        lMinOut = 0.0m;
        area = 0.0m;
        distance = 0.0m;
        second = 0.0m;
        caseDrainGpmOut = 0.0m;
        cycleTimeGpmOut = 0.0m;
    }
