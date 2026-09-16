namespace ENGIE.UnitCommitment.Web.Models;

public class UnitCommitmentResponse {
    [JsonPropertyName("name")]
    [JsonPropertyOrder(0)]
    public string Name { get; set; }

    [JsonPropertyName("p")]
    [JsonPropertyOrder(1)]
    public decimal P { get; set; }
}
