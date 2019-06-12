namespace CalculationLogic.Models

module TorqueState =

    type TorqueFromHP = {
        mutable hp: float32
        mutable rpm: float32
        mutable out: float32
    } with member self.Init =
            self.hp <-0.0f
            self.rpm <- 0.0f
            self.out <- 0.0f

    type TorqueFromGPM = {
        mutable gpm: float32
        mutable psi: float32
        mutable rpm: float32
        mutable out: float32
    } with member self.Init =
            self.gpm <- 0.0f
            self.psi <- 0.0f
            self.rpm <- 0.0f
            self.out <- 0.0f

    type Velocity = {
        mutable gpm: float32
        mutable id: float32
        mutable out: float32
    } with member self.Init =
            self.gpm <- 0.0f
            self.id <- 0.0f
            self.out <- 0.0f

    type T = {
        mutable torqueFromHP:TorqueFromHP
        mutable torqueFromGPM:TorqueFromGPM
        mutable velocity:Velocity
    }

    let Init= {
        torqueFromHP = {
            hp = 0.0f;
            rpm = 0.0f;
            out = 0.0f;
        };
        torqueFromGPM = {
            gpm = 0.0f;
            psi = 0.0f;
            rpm = 0.0f;
            out = 0.0f;
        };
        velocity = {
            gpm =  0.0f;
            id =  0.0f;
            out =  0.0f;
        }
    }