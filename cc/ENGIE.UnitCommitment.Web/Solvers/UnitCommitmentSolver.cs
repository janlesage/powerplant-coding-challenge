using ENGIE.UnitCommitment.Web.Models;

namespace ENGIE.UnitCommitment.Web.Solvers;

public class UnitCommitmentSolver {
    public UnitCommitmentResponse[] GetUnitCommitment(UnitCommitmentPayload payload, MeritOrderPowerplant[] meritOrder)
    {
        var unitCommitment = new List<UnitCommitmentResponse>();
        var remainingLoadToDistribute = payload.Load;

        // We shouldn't iterate directly on Select
        var powerplants = meritOrder.Select(s => s.Powerplant);

        foreach (var powerplant in powerplants)
        {
            var multiplier = powerplant.Type == UnitCommitmentPowerplantType.WindTurbine ? (decimal)payload.Fuels.Wind / 100 : 1.0m;
            var assignedLoad = CalculateLoad(powerplant, remainingLoadToDistribute, multiplier);

            unitCommitment.Add(new() { Name = powerplant.Name, P = assignedLoad, });
            remainingLoadToDistribute -= assignedLoad;
        }

        return [.. unitCommitment];
    }

    private decimal CalculateLoad(UnitCommitmentPowerplant powerplant, decimal remainingLoadToDistribute, decimal multiplier)
    {
        var calculatedPmax = (decimal)(powerplant.Pmax * multiplier);

        return remainingLoadToDistribute > calculatedPmax
            ? calculatedPmax
            : remainingLoadToDistribute > powerplant.Pmin
                ? remainingLoadToDistribute
                : 0.0m;
    }
}
