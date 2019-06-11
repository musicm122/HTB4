module Models

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