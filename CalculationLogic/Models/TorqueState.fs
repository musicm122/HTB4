namespace CalculationLogic.Models

module TorqueState =

    type TorqueFromHP = {
        mutable hp: decimal
        mutable rpm: decimal
        mutable out: decimal
    } with member self.Init =
            self.hp <-0.0m
            self.rpm <- 0.0m
            self.out <- 0.0m

    type TorqueFromGPM = {
        mutable gpm: decimal
        mutable psi: decimal
        mutable rpm: decimal
        mutable out: decimal
    } with member self.Init =
            self.gpm <- 0.0m
            self.psi <- 0.0m
            self.rpm <- 0.0m
            self.out <- 0.0m

    type Velocity = {
        mutable gpm: decimal
        mutable id: decimal
        mutable out: decimal
    } with member self.Init =
            self.gpm <- 0.0m
            self.id <- 0.0m
            self.out <- 0.0m

    type T = {
        mutable torqueFromHP:TorqueFromHP
        mutable torqueFromGPM:TorqueFromGPM
        mutable velocity:Velocity
    }

    let Init= {
        torqueFromHP = {
            hp = 0.0m;
            rpm = 0.0m;
            out = 0.0m;
        };
        torqueFromGPM = {
            gpm = 0.0m;
            psi = 0.0m;
            rpm = 0.0m;
            out = 0.0m;
        };
        velocity = {
            gpm =  0.0m;
            id =  0.0m;
            out =  0.0m;
        }
    }