Feature: TMFeatureFile

A short summary of the feature

@regression @CreateTimeRecord
Scenario: Create Time Record with Valid Data
	Given  I Login to the Portal Successfully
	When   I navigate to Time and Material Page
	When   I create the time record successfully
	Then   Reecord should be created successfully

@regression  @EditTimeRecord
Scenario Outline: Edit existing time record with Valid Data
         Given    I Login to the Portal Successfully
		 When     I navigate to Time and Material Page
		 When     I update the '<Code>' on an existing Time Record
		 Then     the record should have the updated '<Code>'
		 Examples: 
		 | Code  |
		 | alpha |
		 | beta  |
		 | gamma |