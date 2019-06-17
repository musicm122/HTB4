namespace CalculationLogic.Models

module PumpState =

    type HorsePower = {
        mutable gpm: decimal
        mutable psi: decimal
        mutable out: decimal
    } with member self.Init =
            self.gpm <- 0.0m
            self.psi <- 0.0m
            self.out <- 0.0m

    type GPM = {
        mutable rpm: decimal
        mutable displacement: decimal
        mutable out: decimal
    } with member self.Init =
            self.rpm <- 0.0m
            self.displacement <- 0.0m
            self.out <- 0.0m

    type Displacement = {
        mutable gpm: decimal
        mutable rpm: decimal
        mutable out: decimal
    } with member self.Init =
            self.gpm <- 0.0m
            self.rpm <- 0.0m
            self.out <- 0.0m

    type T = {
        mutable horsePower:HorsePower
        mutable gpm:GPM
        mutable displacement:Displacement
    }

    let Init =
        {
            horsePower = {
                gpm = 0.0m;
                psi = 0.0m;
                out = 0.0m;
            };
            gpm = {
                rpm = 0.0m;
                displacement = 0.0m;
                out = 0.0m;
            };
            displacement = {
                rpm=  0.0m;
                gpm =  0.0m;
                out =  0.0m;
            }
        }

