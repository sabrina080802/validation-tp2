using Microsoft.Maui.Graphics;

namespace CréditImmobilier.Data;

public class AmortizationRow
{
    public int Month { get; set; }
    public double Payment { get; set; }
    public double Principal { get; set; }
    public double Interest { get; set; }
    public double Insurance { get; set; }
    public double RemainingBalance { get; set; }
    public double RepaidCapital { get; set; }
    public Color RowBackground { get; set; } = Color.FromArgb("#233247");
}
