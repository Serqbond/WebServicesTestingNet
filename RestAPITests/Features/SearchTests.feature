Feature: SearchTests

@SearchTestsSuit
Scenario: SearchByTextInUsaBdd
	Given I have a CountryInfo object
	    | Abbr | Area | Capital | Country | LargestCity | Name |
	    | WA   | 184661SKM | Olympia | USA | Seattle | Washington |
	And I call service '/state/search/{country}?text={state}' with parameters 'USA' and 'wash'
	When I get response
	Then the response is equal to CountryInfo object

@SearchTestsSuit
Scenario: SearchByTextInINDBdd
	Given I have a CountryInfo object
	    | Abbr | Area | Capital | Country | LargestCity | Name |
	    | AP   | 49506799SKM | Hyderabad Amaravati | IND | Hyderabad Amaravati | Andhra Pradesh |
	And I call service '/state/search/{country}?text={state}' with parameters 'IND' and 'pradesh'
	When I get response
	Then the response is equal to CountryInfo object
