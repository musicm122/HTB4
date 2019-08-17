namespace CalculationLogic.Models

module CylinderState =
    type Force =
        { mutable area : decimal
          mutable psi : decimal
          mutable out : decimal }
        member self.Init =
            self.area <- 0.0m
            self.psi <- 0.0m
            self.out <- 0.0m

    type Psi =
        { mutable force : decimal
          mutable area : decimal
          mutable out : decimal }
        member self.Init =
            self.force <- 0.0m
            self.area <- 0.0m
            self.out <- 0.0m

    type Speed =
        { mutable area : decimal
          mutable gpm : decimal
          mutable out : decimal }
        member self.Init =
            self.area <- 0.0m
            self.gpm <- 0.0m
            self.out <- 0.0m

    type T =
        { mutable force : Force
          mutable psi : Psi
          mutable speed : Speed }

    let Init =
        { force =
              { area = 0.0m
                psi = 0.0m
                out = 0.0m }
          psi =
              { force = 0.0m
                area = 0.0m
                out = 0.0m }
          speed =
              { area = 0.0m
                gpm = 0.0m
                out = 0.0m } }
