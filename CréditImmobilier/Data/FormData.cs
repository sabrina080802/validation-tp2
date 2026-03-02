namespace CréditImmobilier.Data;

public struct FormData
{
     public int duration;
     public double capital;
     public InsuranceRate insuranceRate;
     public RateType rateType;

     public int DurationInMonths => duration * 12;
}