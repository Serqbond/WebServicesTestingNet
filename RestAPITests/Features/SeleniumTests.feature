Feature: SeleniumTests

@Selenium
Scenario: Search in google
	Given I open page 'https://www.google.com.ua'
	And I have entered 'selenium' into the search field
	When I press search button
	Then the result should contain 'Selenium - Web Browser Automation'
