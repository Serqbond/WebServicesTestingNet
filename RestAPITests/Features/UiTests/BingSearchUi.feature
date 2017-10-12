Feature: BingSearchUi

@Selenium
Scenario Outline: Search in Bing
	Given I open page '<url>'
	And I have entered '<searchedText>' into the bing search field
	When I press search button on the bing page
	Then the result should contain '<expectedText>' on the bing page
	Examples: 
	| url                       | searchedText  | expectedText |
	| http://www.bing.com | visual studio | www.visualstudio.com |
	| http://www.bing.com | selenium      | docs.seleniumhq.org |