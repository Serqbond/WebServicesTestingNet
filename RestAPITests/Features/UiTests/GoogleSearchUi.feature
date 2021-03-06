﻿Feature: GoogleSearchUi

@Selenium
Scenario Outline: Search in google
	Given I open page '<url>'
	And I have entered '<searchedText>' into the search field
	When I press search button on google page
	Then the result should contain '<expectedText>'
	Examples: 
	| url                       | searchedText  | expectedText                                          |
	| https://www.google.com.ua | visual studio | Visual Studio IDE, Code Editor, VSTS, & App Center |
	| https://www.google.com.ua | selenium      | Selenium - Web Browser Automation                     |