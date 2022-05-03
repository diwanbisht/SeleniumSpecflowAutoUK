Feature: HotelSearch
	Simple calculator for adding two numbers

@mytag
Scenario Outline: Validate Hotel Search Screen
	Given I navigate to 'http://adactinhotelapp.com/' page
	When I enter 'Aghate123' in user name field
	And I enter 'Testing@1234' in password field
	And I click on Login button
	When I select 'London' from the Location drop downbox
	And I select '<Hotel>' in Hotel dropdown list
	And  I select '<RoomType>' in Room type dropdown list
	And I select '<NumberofRoom>' in Number of Room dropdown list
	And I enter'<CheckinDate>' in the check in date field
	And I enter '<CheckoutDate>' in the check out date field
	And I select '<Numberofadultperroom>' in the Adult per room dropdown list
	And I select '<Numberofchildrenperroom>' in the Children per room dropdown list
	#And I click on the Search button
	Then I should be able to see a list of hotels matching my criteria

	Examples:
		| Hotel          | RoomType | NumberofRoom | CheckinDate | CheckoutDate | Numberofadultperroom | Numberofchildrenperroom |
		| Hotel Sunshine | Deluxe   | 2 - Two      | 10/04/2022  | 15/04/2022   | 2 - Two              | 3 - Three               |

@mytag
Scenario Outline: Validate Hotel Booking
	Given I navigate to 'http://adactinhotelapp.com/' page
	When I enter 'Aghate123' in user name field
	And I enter 'Testing@1234' in password field
	And I click on Login button
	When I select 'London' from the Location drop downbox
	And I select '<Hotel>' in Hotel dropdown list
	And  I select '<RoomType>' in Room type dropdown list
	And I select '<NumberofRoom>' in Number of Room dropdown list
	And I enter'<CheckinDate>' in the check in date field
	And I enter '<CheckoutDate>' in the check out date field
	And I select '<Numberofadultperroom>' in the Adult per room dropdown list
	And I select '<Numberofchildrenperroom>' in the Children per room dropdown list
	#And I click on the Search button
	And I click on the 'Search' button
	Then I should be able to see a list of hotels matching my criteria
	When I click on Select Hotel radio button
	And I click on the 'continue' button
	When I enter the 'Aghate' First Name
	And I enter the 'Nono'Last Name
	And I enter the 'B-178 Londoan'Billing Address
	And I enter the '4111111111111111'Card Number
	And I select 'Visa' CardType
	And I select 'April' Expiry Month
	And I select '2022' Expirty Year
	And I enter the '<CVV>' Number 
	And I click on the 'Book Now' button
	Then I shold see the random Order Number

	Examples:
		| Hotel          | RoomType | NumberofRoom | CheckinDate | CheckoutDate | Numberofadultperroom | Numberofchildrenperroom | CVV |
		| Hotel Sunshine | Deluxe   | 2 - Two      | 10/04/2022  | 15/04/2022   | 2 - Two              | 3 - Three               | 123 |