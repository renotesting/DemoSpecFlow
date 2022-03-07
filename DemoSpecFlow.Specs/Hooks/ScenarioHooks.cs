using TechTalk.SpecFlow;
using System.Net.Http;
using System.Net.Http.Headers;
using SpecFlowPOC.Specs.Support;

namespace SpecFlowPOC.Specs.Hooks
{
    [Binding]
    public class ScenarioHooks : Steps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HttpClientRequest _httpClientRequest;
        private readonly dynamic _actualData;

        public ScenarioHooks(ScenarioContext scenarioContext, 
                             HttpClientRequest httpClientRequest,
                             dynamic actualData)
        {
            _scenarioContext = scenarioContext;
            _httpClientRequest = httpClientRequest;
            _actualData = actualData;
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            _scenarioContext["HttpClientRequest"] = _httpClientRequest;
            _scenarioContext["ActualObject"] = _actualData;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            //HttpClientRequest httpClientRequest = (HttpClientRequest)_scenarioContext["HttpClientRequest"];
            //httpClientRequest.httpClient.Dispose();
        }
    }
}