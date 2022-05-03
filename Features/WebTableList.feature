Feature: WebTableList
	Simple calculator for adding two numbers


Scenario Outline: Valid login 
	Given I navigate to '<WebTable>' page
	When I want to read the table

	Examples: 
	| WebTable                                 | UserName  | Password     |
	| http://the-internet.herokuapp.com/tables | Aghate123 | Testing@1234 |
