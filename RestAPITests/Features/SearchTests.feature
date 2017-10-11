Feature: SearchTests

@SearchTestsSuit
Scenario: SearchByTextInUsaBdd
	Given I have a CountryInfo object
	And I call service '/state/search/{country}?text={state}' with parameters 'USA' and 'wash'
	When I get response
	Then the response is equl to CountryInfo object


