using AnglingCompanion.Models.Abstractions;

namespace AnglingCompanion.Models;

public class Trip : Resource
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int TotalFishCaught { get; set; }
    public double AverageWaterTemperature { get; set; }
    public string Synopsis { get; set; }
    public string BodyOfWater { get; set; }
}