Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](DemoSpecFlow.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Subtract two numbers
	Given the first number is 120
	And the second number is 70
	When the two numbers are subtracted
	Then the result should be 50


Scenario Outline: Multiply two numbers
	Given I input the <First> number and the <Second> number
	When the two numbers are multiplied
	Then the result should be <Result>

Examples:
	| First | Second | Result |
	| 2     | 3      | 6      |
	| 1     | 9      | 9      |
	| 4     | 8      | 32     |