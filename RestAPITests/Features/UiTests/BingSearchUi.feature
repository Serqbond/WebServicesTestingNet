Feature: BingSearchUi

#@Selenium
#Scenario Outline: Search in Bing
#	Given I open page '<url>'
#	And I have entered '<searchedText>' into the bing search field
#	When I press search button on the bing page
#	Then the result should contain '<expectedText>' on the bing page
#	Examples: 
#	| url                 | searchedText  | expectedText         |
#	| http://www.bing.com | visual studio | www.visualstudio.com |
#	| http://www.bing.com | selenium      | docs.seleniumhq.org  |

@Selenium
Scenario: Search in Bing
	Given I open page 'http://www.bing.com'
	And I have entered 'visual studio' into the bing search field
	When I press search button on the bing page
	Then the result should contain 'www.visualstudio.com' on the bing page	