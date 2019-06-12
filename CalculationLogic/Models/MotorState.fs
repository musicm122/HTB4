namespace CalculationLogic.Models

module MotorState =

    type GPM = {
        mutable diameter: float32
        mutable rpm: float32
        mutable out: float32
    } with member self.Init =
            self.diameter <- 0.0f
            self.rpm <- 0.0f
            self.out <- 0.0f

    type MotorSpeed = {
        mutable gpm: float32
        mutable displacement : float32
        mutable out: float32
    } with member self.Init =
            self.gpm <- 0.0f
            self.displacement <- 0.0f
            self.out <- 0.0f

    type FluidMotionTorque= {
        mutable psi: float32
        mutable displacement : float32
        mutable out: float32
    } with member self.Init =
            self.psi <- 0.0f
            self.displacement <- 0.0f
            self.out <- 0.0f

    type T = {
        mutable gpm:GPM
        mutable motorSpeed:MotorSpeed
        mutable fluidMotionTorque:FluidMotionTorque
    }

    let Init =
        {
            gpm = {
                diameter= 0.0f;
                rpm = 0.0f;
                out = 0.0f;
            };
            motorSpeed = {
                gpm = 0.0f;
                displacement = 0.0f;
                out = 0.0f;
            };
            fluidMotionTorque = {
                psi = 0.0f;
                displacement = 0.0f;
                out = 0.0f;
            }
        }

