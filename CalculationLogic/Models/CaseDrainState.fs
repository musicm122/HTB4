namespace CalculationLogic.Models

module CaseDrainState =
    type T =
        { mutable rpm : decimal
          mutable cCRev : decimal
          mutable efficency : decimal
          mutable cCMinOut : decimal
          mutable lMinOut : decimal
          mutable caseDrainGpmOut : decimal }

    let Init =
        { rpm = 0.0m
          cCRev = 0.0m
          efficency = 0.0m
          cCMinOut = 0.0m
          lMinOut = 0.0m
          caseDrainGpmOut = 0.0m }
