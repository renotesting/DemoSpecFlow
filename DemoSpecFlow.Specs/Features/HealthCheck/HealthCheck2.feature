Feature: HealthCheck2

A short summary of the feature

@tag1
Scenario: Credit Check Health Check2-1
	Given I send health check to the credit check endpoint
	When I receive and parse response
	Then I should see response resource status availability is true

Scenario: Credit Check Health Check2-2
	Given I send health check to the credit check endpoint
	When I receive and parse response
	Then I should see response resource status availability is true