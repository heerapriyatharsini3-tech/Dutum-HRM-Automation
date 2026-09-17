Feature: Admin Navigation and Login functionality



	Background: 

	Given the user is on the homepage
	When Enter the valid Dutum Advancedbutton and click proceed
	Then the page should be navigated to Dutum Main page

@TC_LOGIN_001 @Module_Admin @Priority_Low
	Scenario: Verify navigation to admin page
	When Click on the Admin button
	
@TC_LOGIN_002 @Module_Login @Priority_High 
	Scenario: Verify Successful Admin login and navigating to Dashboard
	When Click on the Admin button
	When Enter the valid main username and password
	Then the page should be navigated to the dashboard

@TC_LOGIN_003 @Module_Login @Priority_Low 
	Scenario:Verify logged-in username is displayed

	When Click on the Admin button
	When Enter the valid main username and password
	Then The username should be displayed on the top right corner

@TC_LOGIN_004 @Module_Login @Priority_Low 
 
	Scenario:Verify Dashboard Url after successful login
	
	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page

@TC_LOGIN_005 @Module_Login @Priority_High
	Scenario: Validate session creation after successful login
	
	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page 
	And Logout button should be visible

@TC_LOGIN_006 @Module_invalidlogin @Priority_High
Scenario Outline: Invalid login with multiple Usernames and Passwords

	When Click on the Admin button
	When Enter the invalid username "<username>" and password "<password>"
	Then the error message should be displayed
	Examples: 
	
	| username | password |
	| user1    | pass1    |
	| user2    | pass2    |

@TC_LOGIN_007 @Module_invalidlogin @Priority_High

	Scenario: User clicks Dutum Login button with empty fields
	When Click on the Admin button
	When Enter the invalid username "" and password ""
	Then the error message should be displayed

@TC_LOGIN_008 @Module_invalidlogin @Priority_High 

	Scenario: User clicks Dutum Login button with empty username
	
	When Click on the Admin button
	When Enter the invalid username "" and password "pass123"
	Then the error message should be displayed

@TC_LOGIN_009 @Module_invalidlogin @Priority_High 
	Scenario: User clicks Dutum Login button with empty password
	
	When Click on the Admin button
	When Enter the invalid username "user123" and password ""
	Then the error message should be displayed

@TC_LOGIN_010 @Module_invalidlogin @Priority_Medium 
	Scenario: User clicks Dutum Login button with special characters
	
	When Click on the Admin button
	When Enter the invalid username "user!@#" and password "pass!@#"
	Then the error message should be displayed

@TC_LOGIN_011 @Module_invalidlogin @Priority_High 
	Scenario: User clicks Dutum Login button with SQL injection

	When Click on the Admin button
	When Enter the invalid username "admin' OR '1'='1" and password "password"
	Then the error message should be displayed

@TC_LOGIN_012 @Module_logout @Priority_High 
	Scenario: Successful logout after login

	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page
	When click the user image button on the top right corner
	Then In dropdown click on logout button
	Then the user should be redirected to the home page

@TC_LOGIN_013 @Module_logout @Priority_Medium
	Scenario: Back button functionality after logout
	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page
	When click the user image button on the top right corner
	Then In dropdown click on logout button
	Then the user should be redirected to the home page

@TC_LOGIN_014 @Module_Attendance @Priority_Medium
	Scenario: Verify Attendance page opens when Attendance menu is clicked

	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page
	When Click on the Attendance menu
	Then the attendance page will be displayed

@TC_LOGIN_015 @Module_Timesheet @Priority_Medium
	Scenario: Verify Timesheet page opens when Timesheet menu is clicked

	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page
	When Click on the Timesheet menu
	Then the timesheet page will be displayed

@TC_LOGIN_016 @Module_Resource @Priority_Medium
	Scenario: Verify Resource page opens when Resource menu is clicked
	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page
	When Click on the Resource menu
	Then the resource page will be displayed

@TC_LOGIN_017 @Module_Organisation @Priority_Medium
	Scenario: Verify Organisation page opens when Organisation menu is clicked
	When Click on the Admin button
	When Enter the valid main username and password
	Then the user should redirected to the dashboard page
	When Click on the Organisation menu
	Then the organisation page will be displayed

	




	


		

	
	



	

	

	