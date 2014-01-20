using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace MortgageCalulator.Tests.Steps
{
    [Binding]
    public class MortgageCalculatorSteps
    {
        private decimal _principalAmount;
        private int _loanTermInYears;

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
        public void GivenIAmComparingTheFollowingMortgages(Table mortgagesToCompare)
        {
            mortgagesToCompare.Rows.Select(row => new
            {
                MortgageProvider = row["MortgageProvider"],

            });
        }

        [When(@"I click compare the mortgages")]
        public void WhenIClickCompareTheMortgages()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table mortgageComparisonResult)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
