using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace SpecFlowPOC.Specs.Support
{
    public class HttpClientRequest
    {
        private ScenarioContext _scenarioContext;
        //private static HttpClient httpClient = new HttpClient();
        private HttpClient httpClient = new HttpClient();
        public string ResponseStr { get; set; }
        public dynamic ResponseObj { get; set; }

        public HttpClientRequest(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        public HttpResponseMessage GetResponse(string URL, string mediaType, string urlParameters)
        {
            HttpClientRequest httpClientRequest = (HttpClientRequest)_scenarioContext["HttpClientRequest"];
            httpClient.BaseAddress = new Uri(URL);
            // Add an Accept header for JSON format.
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            // Blocking call! Program will wait here until a response is received or a timeout occurs.
            HttpResponseMessage httpResponse = httpClient.GetAsync(urlParameters).Result;
            return httpResponse;
        }

        public void ResponseToString(dynamic response)
        {
            if (response.IsSuccessStatusCode)
            {
                //convert response to a string
                this.ResponseStr = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("The response returned status code false.");
            }
        }

        public void ResponseToJsonObject(string ResponseStr)
        {   
            if(ResponseStr != null)
            {
                this.ResponseObj = JObject.Parse(ResponseStr);
                //var version = responseObj.version.versionNumber;
            }
            else
            {
                Console.WriteLine("The response string was null when passed in");
            }
        }
    }
}
