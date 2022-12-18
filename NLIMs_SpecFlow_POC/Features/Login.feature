Feature: Login 
In order to test login functionality 
As a User
I want to test login functionality is working

Background: Pre-Condition
	Given User navigates to NLIMs login Page


Scenario: Login with Valid Username and Valid Password
	When User enters Valid Username
	And User enters Valid Password
	And Click on Login Button
	Then User should be logged in to the system

Scenario: Login with Invalid Username and Invalid Password
	When User enters Invalid Username
	And User enters Invalid Password
	And Click on Login Button
	Then An error Msg should be displayed

Scenario: Login with Valid Username and Invalid Password
	When User enters Valid Username
	And User enters Invalid Password
	And Click on Login Button
	Then An error Msg should be displayed

Scenario: Login with Invalid Username and Valid Password
	When User enters Invalid Username
	And User enters Valid Password
	And Click on Login Button
	Then An error Msg should be displayed
