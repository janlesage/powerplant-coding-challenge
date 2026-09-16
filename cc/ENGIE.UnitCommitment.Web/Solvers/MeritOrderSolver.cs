using ENGIE.UnitCommitment.Web.Models;

namespace ENGIE.UnitCommitment.Web.Solvers;

public class MeritOrderSolver {
    public MeritOrderPowerplant[] GetMeritOrder(UnitCommitmentPayload payload)
    {
        var meritOrder = new List<MeritOrderPowerplant>();

        // Calculate with efficiency kept in mind
        foreach (var powerplant in payload.Powerplants)
        {
            switch (powerplant.Type)
            {
                case UnitCommitmentPowerplantType.Gasfired:
                    meritOrder.Add(new() { Powerplant = powerplant, Cost = payload.Fuels.Gas / powerplant.Efficiency });
                    break;
                case UnitCommitmentPowerplantType.Turbojet:
                    meritOrder.Add(new() { Powerplant = powerplant, Cost = payload.Fuels.Kerosine / powerplant.Efficiency });
                    break;
                case UnitCommitmentPowerplantType.WindTurbine:
                    meritOrder.Add(new() { Powerplant = powerplant, Cost = 0 });
                    break;
                default:
                    throw new ApplicationException("Powerplant type is not known to the implementation of this coding challenge");
            }
        }

        // Now we should have cost included merit order
        return [.. meritOrder.OrderBy(x => x.Cost)];
    }
}
