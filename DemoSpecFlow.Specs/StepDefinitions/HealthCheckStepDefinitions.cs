using SpecFlowPOC.Specs.Support;
using SpecFlowPOC.Specs.Constants;
using SpecFlowPOC.Specs.Hooks;
using Newtonsoft.Json.Linq;

namespace SpecFlowCalculator.Specs.StepDefinitions
{
    [Binding]
    public class HealthCheckStepDefinitions
    {
        //context injection
        private ScenarioContext _scenarioContext;

        public HealthCheckStepDefinitions(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"I send health check to the credit check endpoint")]
        public void GivenISendHealthCheckToTheCreditCheckEndpoint()
        {
            var url = MachineConfig.DevUrl + MachineConfig.CreditCheckHealthCheck;
            var mediaType = ProjectConstants.MediaType;
            var urlParameters = ""; //this one will be changed upon the specific api request test
            HttpClientRequest request = (HttpClientRequest)_scenarioContext["HttpClientRequest"];
            _scenarioContext["ActualObject"] = request.GetResponse(url, mediaType, urlParameters);
        }

        [When(@"I receive and parse response")]
        public void WhenIReceiveAndParseResponse()
        {
            HttpClientRequest request = (HttpClientRequest)_scenarioContext["HttpClientRequest"];
            dynamic response = (dynamic)_scenarioContext["ActualObject"];
            request.ResponseToString(response);
            request.ResponseToJsonObject(request.ResponseStr);
            System.Threading.Thread.Sleep(2000);
        }


        [Then(@"I should see response resource status availability is true")]
        public void ThenIShouldSeeResponseResourceStatusAvailabilityIsTrue()
        {
            HttpClientRequest request = (HttpClientRequest)_scenarioContext["HttpClientRequest"];

            string expectedStr = "{\"version\":{\"versionNumber\":\"1.0.33+3\",\"environment\":\"DEV\",\"ipAddress\":\"" + MachineConfig.VersionIPAddress + "\"},\"resourceStatuses\":[{\"name\":\"Venafi Server\",\"description\":\"Certificate store server\",\"serverUri\":\"" + MachineConfig.CertificationStoreServerUri + "\",\"isAvailable\":true},{\"name\":\"ESB\",\"description\":\"ESB Endpoint\",\"serverUri\":\"" + MachineConfig.ESBEndPointServerUri + "\",\"isAvailable\":true}]}";

            //This assersion satisfies validate whole response as a string, no need to parse as JObject
            string actualStr = request.ResponseStr;
            actualStr.Should().Be(expectedStr);

            //This assersion satisfies validate specific element inside of Json Object
            dynamic expectedObject = JObject.Parse(expectedStr);
            dynamic actualObject = request.ResponseObj;
            JArray ExpResourceStatuses = (JArray)expectedObject["resourceStatuses"];
            JArray ActResourceStatuses = (JArray)actualObject["resourceStatuses"];

            //This is prove Should().BeEquivalentTo() validate the value of two JArray objects.
            ActResourceStatuses.Should().BeEquivalentTo(ExpResourceStatuses, "Because they are identical");

            //validate certain key - value in the JArray object as string
            ActResourceStatuses.ToString().Should().Be(ExpResourceStatuses.ToString());

            ActResourceStatuses[0]["name"].ToString().Should().Be(ExpResourceStatuses[0]["name"].ToString());
            ActResourceStatuses[1]["name"].ToString().Should().Be(ExpResourceStatuses[1]["name"].ToString());

            //validate certain key in the Jarray  object
            for (int i = 0; i < ActResourceStatuses.Count; i++)
            {
                ActResourceStatuses[i]["name"].ToString().Should().Be(ExpResourceStatuses[i]["name"].ToString());
            }
        }
    }
}
