using FluentAssertions;
using Reqnroll;

namespace ReqnrollSampleProject.Steps;

[Binding]
public class StepDefinitions(ScenarioContext scenarioContext)
{
    [Given(@"^the first number is (.*)$")]
    public void GivenTheFirstNumberIs(int number)
    {
        Console.WriteLine(number);
        scenarioContext.Add("first_number", number);
    }

    [Given(@"the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        Console.WriteLine(number);
        scenarioContext.Add("second_number", number);
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        var numberOne = scenarioContext.Get<int>("first_number");
        var numberTwo = scenarioContext.Get<int>("second_number");
        var result = numberOne + numberTwo;
        Console.WriteLine(result);
        scenarioContext.Add("result", result);
    }

    [Then(@"^the result should be (.*)$")]
    public void ThenTheResultShouldBe(int expectedResult)
    {
        var actualResult = scenarioContext.Get<int>("result");
        Console.WriteLine(actualResult);
        actualResult.Should().Be(expectedResult);
    }
}