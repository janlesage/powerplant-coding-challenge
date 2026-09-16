namespace ENGIE.UnitCommitment.Web.Models;

public class UnitCommitmentPowerplant {
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public UnitCommitmentPowerplantType Type { get; set; }

    [JsonPropertyName("efficiency")]
    public decimal Efficiency { get; set; }

    [JsonPropertyName("pmin")]
    public uint Pmin { get; set; }

    [JsonPropertyName("pmax")]
    public uint Pmax { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UnitCommitmentPowerplantType {
    Gasfired,
    Turbojet,
    WindTurbine
}
