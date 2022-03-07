using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowPOC.Specs.Constants
{
    public static class MachineConfig
    {
        public static readonly string Dev = "DEV";
        public static readonly string Test = "TEST";
        public static readonly string Pre = "PRE";
        public static readonly string Perf = "PERF";
        public static readonly string Prod = "PROD";

        public static readonly string DevUrl = "https://host.ca";
        public static readonly string TestUrl = "https://host.ca";
        public static readonly string PreUrl = "https://host.ca";
        public static readonly string PerfUrl = "https://host.ca";
        public static readonly string ProdUrl = "https://host.ca";

        public static readonly string CreditCheckHealthCheck = "/api/v1.0/HealthCheck";
        public static readonly string CreditCheckURL = "/api/v1/CreditCheck/creditcheck";
        public static readonly string CertificationStoreServerUri = "https://host.ca";
        public static readonly string ESBEndPointServerUri = "https://host.ca";
        public static readonly string VersionIPAddress = "xx.xx.xx.xx";
    }
}
