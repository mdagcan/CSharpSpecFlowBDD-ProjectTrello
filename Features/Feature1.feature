Feature: Go to Trello page and use some API's

User go to Trello page and create board and card, invite user, delete card and board with API 

@Test
Scenario: Trello page steps
	Given Open the browser
	When Enter the URL
	Then Login with user name and password
	Then Send API requests

