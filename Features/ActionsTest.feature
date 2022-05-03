Feature: ActionsTest
	Simple calculator for adding two numbers
	
Scenario Outline: ValidateActionTest 
	Given I navigate to '<Uploads>' page
	When I click on ChooseFile button
	And I selects the file
	And I click on upload button
	
	
	Examples: 
	| Uploads                                    | UserName  | Password     |
	| https://the-internet.herokuapp.com/upload | Aghate123 | Testing@1234 |

	Scenario Outline: DragandDrop 
	Given I navigate to '<DragandDrop>' page
	When I drag from Sourse to distination location
		
	Examples: 
	| DragandDrop                                      | UserName  | Password     |
	| https://the-internet.herokuapp.com/drag_and_drop | Aghate123 | Testing@1234 |