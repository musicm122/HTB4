namespace CalculationLogic.Models

module CylinderState =

    type Force = {
        mutable area:float32
        mutable psi:float32
        mutable out:float32
    } with member self.Init =
            self.area <- 0.0f
            self.psi <- 0.0f
            self.out <- 0.0f

    type Psi = {
        mutable force:float32
        mutable area:float32
        mutable out:float32
    } with member self.Init =
            self.force <- 0.0f
            self.area <- 0.0f
            self.out <- 0.0f

    type Speed = {
        mutable area:float32
        mutable gpm:float32
        mutable out:float32
    } with member self.Init =
            self.area <- 0.0f
            self.gpm <- 0.0f
            self.out <- 0.0f

    type T = {
        mutable force: Force
        mutable psi:Psi
        mutable speed:Speed
    }

    let Init = {
        force = {
            area = 0.0f;
            psi = 0.0f;
            out = 0.0f;
        };
        psi = {
            force = 0.0f;
            area = 0.0f;
            out = 0.0f;
        };
        speed = {
            area =  0.0f;
            gpm =  0.0f;
            out =  0.0f;
        }
    }

