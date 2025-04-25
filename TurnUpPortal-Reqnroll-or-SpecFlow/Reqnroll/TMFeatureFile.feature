Feature: TMFeatureFile

A short summary of the feature

@tag1
Scenario: Create Time Record with Valid Data
	Given  I Login to the Portal Successfully
	When   I namvigete to Time andd Material Page
	When   I create the time record successfully
	Then   Reecord should be created successfully
