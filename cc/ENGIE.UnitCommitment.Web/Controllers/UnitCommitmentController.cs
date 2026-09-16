using ENGIE.UnitCommitment.Web.Models;
using ENGIE.UnitCommitment.Web.Solvers;

namespace ENGIE.UnitCommitment.Web.Controllers;

[ApiController]
[Route("/")]
public class UnitCommitmentController : ControllerBase {
    [HttpPost("productionplan")]
    public UnitCommitmentResponse[] ProductionPlan(UnitCommitmentPayload payload)
    {
        MeritOrderSolver meritOrderSolver = new();
        var meritOrder = meritOrderSolver.GetMeritOrder(payload);
        UnitCommitmentSolver unitCommitmentSolver = new();
        var unitCommitment = unitCommitmentSolver.GetUnitCommitment(payload, meritOrder);

        return unitCommitment;
    }
}
