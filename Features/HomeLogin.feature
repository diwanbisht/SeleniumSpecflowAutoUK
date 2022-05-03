Feature: HomeLogin
	As a user of Adactin
	I want to login
	So that I can choose and book my hotel

Scenario Outline: Valid login 
	Given I navigate to '<Login>' page
	When I enter '<UserName>' and '<Password>' to login to web Application 	
	Then I am directed to the booking page
	
	Examples: 
	| Login                                | UserName  | Password     |
	| http://adactinhotelapp.com/index.php | Aghate123 | Testing@1234 |


	Scenario Outline: Valid login11 
	Given I navigate to 'Login' page
	When I enter 'UserName' in user name field
	And I enter 'Password' in password field
	And I click on Login button
	Then I am directed to the booking page
	
