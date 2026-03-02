namespace CréditImmobilier.Data;

[Flags]
public enum InsuranceRate
{
    None = 0,
    IsAthletic = 1,
    IsSmoker = 2,
    IsEngineerComputerScience = 4,
    IsFighterPilot = 8,
    IsCardiac = 16
};