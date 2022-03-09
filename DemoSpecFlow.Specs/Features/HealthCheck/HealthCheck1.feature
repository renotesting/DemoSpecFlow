Feature: HealthCheck1

A short summary of the feature

@tagMedium @tagRegression
Scenario: Credit Check Health Check1-1
	Given I send health check to the credit check endpoint
	When I receive and parse response
	Then I should see response resource status availability is true

Scenario: Credit Check Health Check1-2
	Given I send health check to the credit check endpoint
	When I receive and parse response
	Then I should see response resource status availability is true