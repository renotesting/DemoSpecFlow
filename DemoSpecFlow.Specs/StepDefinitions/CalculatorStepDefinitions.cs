
using SpecFlowCalculator;

namespace DemoSpecFlow.Specs.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly Calculator _calculator = new Calculator();
        private int _result;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
            //System.Threading.Thread.Sleep(2000);
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _result = _calculator.Substract();
        }


        //Scenario Outline
        [Given(@"I input the (.*) number and the (.*) number")]
        public void GivenIInputTheNumberAndTheNumber(int p0, int p1)
        {
            _calculator.FirstNumber = p0;
            _calculator.SecondNumber = p1;
        }

        [When(@"the two numbers are multiplied")]
        public void WhenTheTwoNumbersAreMultiplied()
        {
            _result = _calculator.Multiply();
        }
    }
}