Feature: MortgageCalculator
	In order Calculate the total cost of a Mortgage over time
	As a Existing homeowner who's up for a Remortgage
	I want to know the amount of interest I will pay for a given mortgage product

@mytag
Scenario: Calculate Interest for a mortgage
	Given I want to borrow £228,000
	And I want to repay it over 22 years
	And I am considering the following mortgage product
	| MortgageProvider | MortgageRate | MortgageTerm | ProductFee | MaximumAnnualOverpayments         |
	| Nationwide       | 2.99%        | 22 years     | £995       | 10%                               |	
	When I click calculate
	Then the result should be
	| MortgageProvider | Year | Interest | Principal | Total    | Balance   |
	| Nationwide       | 2014 | 6164.66  | 6811.41   | 12976.07 | 221188.59 | 
	
