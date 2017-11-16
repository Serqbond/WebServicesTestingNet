Feature: MixedSearchTest

@Selenium
@Client
Scenario: MixedSearchByText
	Given I have a CountryInfo object
	    | Abbr | Area | Capital | Country | LargestCity | Name |
	    | WA   | 184661SKM | Olympia | USA | Seattle | Washington |
	And I call service '/state/search/{country}?text={state}' with parameters 'USA' and 'wash'
	When I get response
	Then the response is equal to CountryInfo object
	Given I open page 'https://www.google.com.ua'
	And I have entered 'visual studio' into the search field
	When I press search button on google page
	Then the result should contain 'Visual Studio IDE, Code Editor, VSTS, & App Center'			