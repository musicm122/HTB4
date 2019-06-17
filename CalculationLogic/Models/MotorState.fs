namespace CalculationLogic.Models

module MotorState =

    type GPM = {
        mutable diameter: decimal
        mutable rpm: decimal
        mutable out: decimal
    } with member self.Init =
            self.diameter <- 0.0m
            self.rpm <- 0.0m
            self.out <- 0.0m

    type MotorSpeed = {
        mutable gpm: decimal
        mutable displacement : decimal
        mutable out: decimal
    } with member self.Init =
            self.gpm <- 0.0m
            self.displacement <- 0.0m
            self.out <- 0.0m

    type FluidMotionTorque= {
        mutable psi: decimal
        mutable displacement : decimal
        mutable out: decimal
    } with member self.Init =
            self.psi <- 0.0m
            self.displacement <- 0.0m
            self.out <- 0.0m

    type T = {
        mutable gpm:GPM
        mutable motorSpeed:MotorSpeed
        mutable fluidMotionTorque:FluidMotionTorque
    }

    let Init =
        {
            gpm = {
                diameter= 0.0m;
                rpm = 0.0m;
                out = 0.0m;
            };
            motorSpeed = {
                gpm = 0.0m;
                displacement = 0.0m;
                out = 0.0m;
            };
            fluidMotionTorque = {
                psi = 0.0m;
                displacement = 0.0m;
                out = 0.0m;
            }
        }

