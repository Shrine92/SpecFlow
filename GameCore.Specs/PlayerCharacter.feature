﻿Feature: PlayerCharacter

In order to play the game
As a human player
I want my character attributes to be correctly represented
#
#@tag1
#Scenario: Taking no damage when hit doesn't affect health
#	Given I'm a new Player
#	When I take 0 damage
#	Then My health should be 100
#
#Scenario: Starting Health is reduce when hit
#Given I'm a new Player
#When I take 10 damage
#Then My health should be 90

Background: 
Given I'm a new Player

Scenario: Taking too much damage results in player death
When I take 100 damage
Then I should be dead

Scenario Outline: Health reduction
When I take <damage> damage
Then My health should be <remainingHealth>
Examples: 
| damage | remainingHealth |
| 0      | 100             |
| 40     | 60              |

Scenario: Elf race character get a 10 damage resistance
	And I have a damage resistance of 10
	And I'm an Elf
When I take 50 damage
Then My health should be 80

Scenario: Elf race character get a 10 damage resistance using data table
	And I have the following attributes
	| attribute        | value |
	| Race             | Elf   |
	| DamageResistance | 10    |
When I take 50 damage
Then My health should be 80

Scenario: Healers restore full health
Given My character class is set to Healer
When I take 40 damage
	And Cast a healing spell
Then My health should be 100

Scenario: Total magical power
Given I have the following magical items
| name   | value | power |
| Ring   | 200   | 100   |
| Amulet | 400   | 200   |
| Gloves | 100   | 400   |
Then My total magical power should be 700

Scenario: Reading a	restore health scroll when over tired has no effect
Given I last slept 3 days ago
When I take 40 damage
	And I read a restore health scroll
Then My health should be 60

Scenario: Weapons are worth money
Given I have the following weapons
| name  | value |
| Sword | 50    |
| Pick	| 40	|
| Knife | 10    |
Then my weapons should be worth 100

Scenario: Elf race characters don't lose magical item power
Given I'm an Elf
	And I have an Amulet with a power of 200
When I use a magical Amulet
Then My Amulet power should not be reduced
