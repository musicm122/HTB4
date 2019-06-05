module Models

module CaseDrainStateModels =

    type CaseDrainState = {
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

module CylinderStateModels =

    type Force = {
        mutable area:float32
        mutable psi:float32
        mutable out:float32
    }

    type Psi = {
        mutable force:float32
        mutable area:float32
        mutable out:float32
    }

    type Speed = {
        mutable area:float32
        mutable gpm:float32
        mutable out:float32
    }

    type CylinderState = {
        mutable force: Force
        mutable psi:Psi
        mutable speed:Speed


}

module PumpStateModels =

    type HorsePower = {
        mutable gpm: float32
        mutable psi: float32
        mutable out: float32
    }

    type GPM = {
        mutable rpm: float32
        mutable displacement: float32
        mutable out: float32
    }

    type Displacement = {
        mutable gpm: float32
        mutable rpm: float32
        mutable out: float32
    }

    type PumpState = {
        mutable horsePower:HorsePower
        mutable gpm:GPM
        mutable displacement:Displacement
    }

