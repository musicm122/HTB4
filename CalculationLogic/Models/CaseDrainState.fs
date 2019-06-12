namespace CalculationLogic.Models

module CaseDrainState =

    type T = {
        mutable rpm : float32
        mutable cCRev :float32
        mutable efficency :float32
        mutable cCMinOut : float32
        mutable lMinOut : float32
        mutable area : float32
        mutable distance : float32
        mutable second : float32
        mutable caseDrainGpmOut : float32
        mutable cycleTimeGpmOut : float32
    }

    let Init = {
        rpm = 0.0f;
        cCRev = 0.0f;
        efficency = 0.0f;
        cCMinOut = 0.0f;
        lMinOut = 0.0f;
        area = 0.0f;
        distance = 0.0f;
        second = 0.0f;
        caseDrainGpmOut = 0.0f;
        cycleTimeGpmOut = 0.0f;
    }
