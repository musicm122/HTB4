namespace CalculationLogic.Models

module PumpState =

    type HorsePower = {
        mutable gpm: float32
        mutable psi: float32
        mutable out: float32
    } with member self.Init =
            self.gpm <- 0.0f
            self.psi <- 0.0f
            self.out <- 0.0f

    type GPM = {
        mutable rpm: float32
        mutable displacement: float32
        mutable out: float32
    } with member self.Init =
            self.rpm <- 0.0f
            self.displacement <- 0.0f
            self.out <- 0.0f

    type Displacement = {
        mutable gpm: float32
        mutable rpm: float32
        mutable out: float32
    } with member self.Init =
            self.gpm <- 0.0f
            self.rpm <- 0.0f
            self.out <- 0.0f

    type T = {
        mutable horsePower:HorsePower
        mutable gpm:GPM
        mutable displacement:Displacement
    }

    let Init =
        {
            horsePower = {
                gpm = 0.0f;
                psi = 0.0f;
                out = 0.0f;
            };
            gpm = {
                rpm = 0.0f;
                displacement = 0.0f;
                out = 0.0f;
            };
            displacement = {
                rpm=  0.0f;
                gpm =  0.0f;
                out =  0.0f;
            }
        }

