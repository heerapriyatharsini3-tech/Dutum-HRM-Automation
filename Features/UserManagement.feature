Feature: User Management 

Background: 

	Given the user is on the homepage
	When Enter the valid Dutum Advancedbutton and click proceed
	Then the page should be navigated to Dutum Main page
	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page
	When Click on the user list button

@TC_User_EMP_001 @Module_User @Priority_High
Scenario: Navigate to User Management page
	
	Then click user list page will be display on the screen

@TC_User_EMP_002 @Module_User @Priority_High
Scenario: Verify Add_User button functionality
	When click on the Add_User button
	Then add user page will be display on screen

@TC_User_EMP_003 @Module_User @Priority_Medium
Scenario:Verify Search by Employee name functionality with first letter as capital
	
	When enter the Employee name in search field in first letter as capital
	Then the searched Name with first letter as capital will be displayed in the user list

@TC_User_EMP_004 @Module_User @Priority_Medium
Scenario: Verify Search by Employee name functionality with first letter as small

	When enter the Employee name in search field in first letter as small
	Then the searched Name with first letter as small will be displayed in the user list

@TC_User_EMP_005 @Module_User @Priority_Medium
Scenario: Verify Search by user Email functionality

	When enter the user Email in search field
	Then the entered user Email will be displayed in the user list

@TC_User_EMP_006 @Module_User @Priority_Medium
Scenario: Verify Search by user Mobile_Num functionality

	When enter the user Mobile_Num in search field
	Then the entered user Mobile_Num will be displayed in the user list
	

@TC_User_EMP_007 @Module_User @Priority_Medium
Scenario: Verify Search by user role functionality
	
	When select the user role in search field
	Then the searched user role will be displayed in the user list


@TC_User_EMP_008 @Module_User @Priority_Low

	Scenario: Verify the name field accept alphanumeric value

	Then click user list page will be display on the screen
	When click on the Add_User button
	Then add user page will be display on screen
	When enter the mandatory fields and with name field accept alphanumeric value

@TC_User_EMP_009 @Module_User @Priority_Low

	Scenario: Verify the name field accept numerical value

	Then click user list page will be display on the screen
	When click on the Add_User button
	Then add user page will be display on screen
	When enter the mandatory fields and with name field accept numerical value

@TC_User_EMP_010 @Module_User @Priority_High

	Scenario: Add user with mandatory fields

	Then click user list page will be display on the screen
	When click on the Add_User button
	Then add user page will be display on screen
	When enter the mandatory fields 
	| Name  | Email                | Mobile     | Assign_Client | Gender | Assign_Skill                      | Account_Name | Account_Email      | Designation             | Joined_Date | Reporting_To | Role     | Employee_Code | Salary | Account_Number | Account_Phone |
    | Heera | heerayatha@gmail.com | 9677185680 | Aarding       | Female | HiCAD Modeling (Machine Building) | Heera        | moti4462@gmail.com | Junior Project Engineer |          23 | superadmin   | IT Admin | EMP123        |  50000 |     1234567890 |    9876543210 |
	And click on the save button

@TC_User_EMP_011 @Module_User @Priority_High
Scenario: Verify employee details are saved successfully

	Then click user list page will be display on the screen
	When click on the Add_User button
	Then add user page will be display on screen
	When enter the mandatory fields 
	| Name  | Email                | Mobile     | Assign_Client | Gender | Assign_Skill                      | Account_Name | Account_Email      | Designation             | Joined_Date | Reporting_To | Role     | Employee_Code | Salary | Account_Number | Account_Phone |
    | Heera | heerayatha@gmail.com | 9677185680 | Aarding       | Female | HiCAD Modeling (Machine Building) | Heera        | moti4462@gmail.com | Junior Project Engineer |          23 | superadmin   | IT Admin | EMP123        |  50000 |     1234567890 |    9876543210 |
	And click on the save button
	And a success message should be displayed
	And the employee should appear in the employee list

@TC_USER_EMP_012 @Module_User @Priority_High
Scenario: Verify duplicate Employee ID is not allowed
    Then click user list page will be display on the screen
	When click on the Add_User button
	Then add user page will be display on screen
	When enter the mandatory fields with employee ID "EMP123"
	| Name  | Email                | Mobile     | Assign_Client | Gender | Assign_Skill                      | Account_Name | Account_Email      | Designation             | Joined_Date | Reporting_To | Role     | Employee_Code | Salary | Account_Number | Account_Phone |
    | Heera | heerayatha@gmail.com | 9677185680 | Aarding       | Female | HiCAD Modeling (Machine Building) | Heera        | moti4462@gmail.com | Junior Project Engineer |          23 | superadmin   | IT Admin | EMP123        |  50000 |     1234567890 |    9876543210 |
	And click on the save button
    Then an "Employee ID already exists" error message should be displayed
  

@TC_USER_EMP_013 @Module_User @Priority_High
Scenario: Verify duplicate Email is not allowed
    Then click user list page will be display on the screen
	When click on the Add_User button
	Then add user page will be display on screen
	When enter the mandatory fields with email "test@example.com" 
	| Name  | Email                | Mobile     | Assign_Client | Gender | Assign_Skill                      | Account_Name | Account_Email      | Designation             | Joined_Date | Reporting_To | Role     | Employee_Code | Salary | Account_Number | Account_Phone |
    | Heera | heerayatha@gmail.com | 9677185680 | Aarding       | Female | HiCAD Modeling (Machine Building) | Heera        | moti4462@gmail.com | Junior Project Engineer |          23 | superadmin   | IT Admin | EMP123        |  50000 |     1234567890 |    9876543210 |
	And click on the save button
    Then an "Email already exists" error message should be displayed

@TC_USER_EMP_014 @Module_User @Priority_High
Scenario: Verify duplicate Mobile Number is not allowed
	Then click user list page will be display on the screen
	When click on the Add_User button
	Then add user page will be display on screen
	When enter the mandatory fields with mobile number "9677185680"
		| Name | Email | Mobile | Assign_Client | Gender | Assign_Skill | Account_Name | Account_Email | Designation | Joined_Date | Reporting_To | Role | Employee_Code | Salary | Account_Number | Account_Phone |
    | Heera | heerayatha@gmail.com | 9677185680 | Aarding       | Female | HiCAD Modeling (Machine Building) | Heera        | moti4462@gmail.com | Junior Project Engineer |          23 | superadmin   | IT Admin | EMP123        |  50000 |     1234567890 |    9876543210 |
	And click on the save button
    Then an "Mobile number already exists" error message should be displayed
    






