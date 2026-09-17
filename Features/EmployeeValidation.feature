Feature: EmployeeValidation

Background: 

	Given the user is on the homepage
	When Enter the valid Dutum Advancedbutton and click proceed
	Then the page should be navigated to Dutum Main page
	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page
	When Click on the user list button

@TC_EmpVD_001 @Module_EmpVD @Priority_low
Scenario: Read Employee details form the website
	Given I am on the Employee page
	When I Read all employee details
	Then Employee details should be displayed on the Excel sheet

@TC_EmpVD_002 @Module_EmpVD @Priority_medium
Scenario: Verify duplicate Employee ID
    Given I am on the Employee page
    When I Read all employee details
    Then Employee ID should not be duplicated

@TC_EmpVD_003 @Module_EmpVD @Priority_medium
Scenario: Verify duplicate Employee Email
	Given I am on the Employee page
	When I Read all employee details
	Then Employee Email should not be duplicated

@TC_EmpVD_004 @Module_EmpVD @Priority_low
Scenario: Verify duplicate Employee Mobile Number
	Given I am on the Employee page
	When I Read all employee details
	Then Employee Mobile Number should not be duplicated

@TC_EmpVD_005 @Module_EmpVD @Priority_low
Scenario: Verify Employee ID is not null
	Given I am on the Employee page
	When I Read all employee details
	Then Employee ID should not be null

@TC_EmpVD_006 @Module_EmpVD @Priority_low
Scenario: Verify Employee Name is not null
	Given I am on the Employee page
	When I Read all employee details
	Then Employee Name should not be null

@TC_EmpVD_007 @Module_EmpVD @Priority_medium
Scenario: Verify Employee Department is not null
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Department should not be null

@TC_EmpVD_008 @Module_EmpVD @Priority_medium
Scenario: Verify Employee Designation is not null
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Designation should not be null

@TC_EmpVD_009 @Module_EmpVD @Priority_medium
Scenario: Verify Employee Email format is valid
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Email should have valid format

@TC_EmpVD_010 @Module_EmpVD @Priority_medium
Scenario: Verify Employee Mobile Number format is valid
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Mobile Number should have valid format

@TC_EmpVD_011 @Module_EmpVD @Priority_low
Scenario: Verify Employee Name is not empty
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Name should not be empty

@TC_EmpVD_012 @Module_EmpVD @Priority_low
Scenario: Verify Employee Email is not null
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Email should not be null

@TC_EmpVD_013 @Module_EmpVD @Priority_low
Scenario: Verify Employee Mobile Number is not null
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Mobile Number should not be null

@TC_EmpVD_014 @Module_EmpVD @Priority_medium
Scenario: Verify Employee ID is unique
    Given I am on the Employee page
    When I Read all employee details
    Then Employee ID should be unique

@TC_EmpVD_015 @Module_EmpVD @Priority_medium
Scenario: Verify Employee Name does not contain special characters
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Name should contain only valid characters

@TC_EmpVD_016 @Module_EmpVD @Priority_medium
Scenario: Verify Employee Mobile Number contains only digits
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Mobile Number should contain only digits

@TC_EmpVD_017 @Module_EmpVD @Priority_low
Scenario: Verify Employee ID does not contain spaces
    Given I am on the Employee page
    When I Read all employee details
    Then Employee ID should not contain spaces

@TC_EmpVD_018 @Module_EmpVD @Priority_low
Scenario: Verify Employee Email does not contain spaces
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Email should not contain spaces

@TC_EmpVD_019 @Module_EmpVD @Priority_medium
Scenario: Verify Employee Mobile Number has correct length
    Given I am on the Employee page
    When I Read all employee details
    Then Employee Mobile Number should have valid length

@TC_EmpVD_020 @Module_EmpVD @Priority_medium
Scenario: Verify Employee details contain all mandatory fields
    Given I am on the Employee page
    When I Read all employee details
    Then All mandatory Employee fields should be populated