Feature: MortgageCalculator
	In order Calculate the total cost of a Mortgage over time
	As a Existing homeowner who's up for a Remortgage
	I want to be able to compare 2 mortgage offers over time.

@mytag
Scenario: Add two numbers
	Given I want to borrow £228,000
	And I want to repay it over 22 years
	And I am comparing the following mortgages
	| MortgageProvider | MortgageRate | MortgageTerm | ProductFee | MaximumAnnualOverpayments         |
	| Nationwide       | 2.99%        | 22 years     | £995       | 10%                               |
	| Yorkshire        | 2.84%        | 22 years     | £295       | 10% or £10,000 which ever is less |
	When I click compare the mortgages
	Then the result should be
	| MortgageProvider | Year | Interest | Principal | Total    | Balance   |
	| Nationwide       | 2014 | 6164.66  | 6811.41   | 12976.07 | 221188.59 | 
	
