Feature: SearchTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: SearchByTextInUsaBdd
	Given I have a CountryInfo object
	And I call service '/state/search/{country}?text={state}' with parameters 'USA' and 'wash'
	When I get response
	Then the response is equl to CountryInfo object


