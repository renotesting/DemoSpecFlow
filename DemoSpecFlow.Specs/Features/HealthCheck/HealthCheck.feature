Feature: HealthCheck

A short summary of the feature

@tagHigh @smoke @tagRegression
Scenario: Credit Check Health Check
	Given I send health check to the credit check endpoint
	When I receive and parse response
	Then I should see response resource status availability is true

Scenario: Credit Check Health Check 1
	Given I send health check to the credit check endpoint
	When I receive and parse response
	Then I should see response resource status availability is true
