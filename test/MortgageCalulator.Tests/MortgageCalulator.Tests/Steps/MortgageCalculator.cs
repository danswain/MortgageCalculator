namespace MortgageCalulator.Tests.Steps
{
    public class MortgageCalculator
    {
        public MortgageComparisonResult Calculate(decimal principalAmount, int loanTermInYears, decimal mortgageRate)
        {
            return new MortgageComparisonResult {Interest = "1234.66", MortgageProvider = "Nationwide", Year = 2014};
        }
    }
}