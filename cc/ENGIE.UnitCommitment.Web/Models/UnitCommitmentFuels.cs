namespace ENGIE.UnitCommitment.Web.Models;

public class UnitCommitmentFuels {
    [JsonPropertyName("gas(euro/MWh)")]
    public decimal Gas { get; set; }

    [JsonPropertyName("kerosine(euro/MWh)")]
    public decimal Kerosine { get; set; }

    // This value would most likely be decimal also in production?
    [JsonPropertyName("co2(euro/ton)")]
    public uint CO2 { get; set; }

    [JsonPropertyName("wind(%)")]
    [Range(0, 100)]
    public uint Wind { get; set; }
}
