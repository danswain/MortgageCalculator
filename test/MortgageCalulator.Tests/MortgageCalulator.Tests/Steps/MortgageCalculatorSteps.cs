using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MortgageCalulator.Tests.Steps
{
    [Binding]
    public class MortgageCalculatorSteps
    {
        private decimal _principalAmount;
        private int _loanTermInYears;
        private IEnumerable<MortgageProducts> _mortgageProducts;
        private IEnumerable<MortgageComparisonResult> _mortgageComparisonResults;

        [Given(@"I want to borrow £(.*)")]
        public void GivenIWantToBorrow(Decimal principalAmount)
        {
            _principalAmount = principalAmount;            
        }

        [Given(@"I want to repay it over (.*) years")]
        public void GivenIWantToRepayItOverYears(int loanTermInYears)
        {
            _loanTermInYears = loanTermInYears;            
        }

        [Given(@"I am comparing the following mortgages")]
        [Given(@"I am considering the following mortgage product")]
        public void GivenIAmComparingTheFollowingMortgages(Table mortgagesToCompare)
        {
            _mortgageProducts = mortgagesToCompare.Rows.Select(row => new MortgageProducts
            {
                MortgageProvider = row["MortgageProvider"],
                MortgageRate = row["MortgageRate"],
                MortgageTerm = row["MortgageTerm"],
                ProductFee = row["ProductFee"],
                MaximumAnnualOverpayments = row["MaximumAnnualOverpayments"],
            });
        }

        [When(@"I click compare the mortgages")]
        [When(@"I click calculate")]
        public void WhenIClickCompareTheMortgages()
        {
            _mortgageComparisonResults = GetMortgageComparisonResults(_mortgageProducts);
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table mortgageComparisonResult)
        {
            var expected = ConvertToMortgageResult(mortgageComparisonResult).First();
            var actual = _mortgageComparisonResults.First();

            Assert.That(actual.Interest, Is.EqualTo(expected.Interest), "Interest is not the same");
        }

        private IEnumerable<MortgageComparisonResult> GetMortgageComparisonResults(IEnumerable<MortgageProducts> mortgageProducts)
        {
            var mortgageCalculator = new MortgageCalculator();
            var result = mortgageCalculator.Calculate(_principalAmount, _loanTermInYears, decimal.Parse(mortgageProducts.First().MortgageRate.Replace("%",string.Empty)));
            return new List<MortgageComparisonResult>{result};
        }

        private static IEnumerable<MortgageComparisonResult> ConvertToMortgageResult(Table mortgageComparisonResult)
        {
            var result = mortgageComparisonResult.Rows.Select(row => new MortgageComparisonResult
            {
                MortgageProvider = row["MortgageProvider"],
                Interest = row["Interest"],
                Year = Convert.ToInt32(row["Year"])
            });

            return result;
        }
    }
}
