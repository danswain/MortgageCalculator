using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace MortgageCalulator.Tests.Steps
{
    [Binding]
    public class MortgageCalculatorSteps
    {
        private decimal _principalAmount;
        private int _loanTermInYears;
        private IEnumerable<Mortgage> _mortgageProducts;

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
            _mortgageProducts = mortgagesToCompare.Rows.Select(row => new Mortgage
            {
                MortgageProvider = row["MortgageProvider"],
                MortgageRate = row["MortgageRate"],
                MortgageTerm = row["MortgageTerm"],
                ProductFee = row["ProductFee"],
                MaximumAnnualOverpayments = row["MaximumAnnualOverpayments"],
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

    public class Mortgage
    {
        public string MortgageProvider { get; set; }
        public string MortgageRate { get; set; }
        public string MortgageTerm { get; set; }
        public string ProductFee { get; set; }
        public string MaximumAnnualOverpayments { get; set; }
    }
}
