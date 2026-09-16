namespace ENGIE.UnitCommitment.Web.Models;

public class UnitCommitmentPayload {
    [JsonPropertyName("load")]
    public decimal Load { get; set; }

    [JsonPropertyName("fuels")]
    public UnitCommitmentFuels Fuels { get; set; }

    [JsonPropertyName("powerplants")]
    public UnitCommitmentPowerplant[] Powerplants { get; set; } = [];
}
