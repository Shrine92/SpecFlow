Feature: PlayerCharacter

In order to play the game
As a human player
I want my character attributes to be correctly represented

@tag1
Scenario: Taking no damage when hit doesn't affect health
	Given I'm a new Player
	When I take 0 damage
	Then My health should be 100

Scenario: Starting Health is reduce when hit
Given I'm a new Player
When I take 10 damage
Then My health should be 90

Scenario: Taking too much damage results in player death
Given I'm a new Player
When I take 100 damage
Then I should be dead
