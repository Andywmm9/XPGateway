using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using XPGateway.Framework;
using XPGateway.Framework.Responses;

namespace XPGateway.Console
{
    class Program
    {
        public Program()
        {
            AirportCodePrefixes = new List<string>();
        }

        public static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        /// <summary>
        /// A list of airport code prefixes that only airports that have ICAO codes that begin with these codes will be downloaded.
        /// </summary>
        /// <example>A single string in this list with value "K" would only download airports in the United States.</example>
        [Option(Description = "A list of airport code prefixes that only airports that have ICAO codes that begin with these codes will be downloaded.")]
        public IList<string> AirportCodePrefixes { get; set; }
        [Option]
        public bool Verbose { get; set; }

        private void OnExecute()
        {
            ExecuteAsync().Wait();
        }

        private async Task ExecuteAsync()
        {
            var gatewayApiClient = new GatewayApiClient();
            var filteredAirports = new List<GetAllAirportsResponse.Airport>();

            OutputMessage("Beginning to download airports from the scenery gateway...");

            var airportsResponse = await gatewayApiClient.GetAllAirportsResponse();

            OutputMessage($"{ airportsResponse.Total} airports downloaded from the gateway.");

            // Filter the airports that the user wants.
            if (AirportCodePrefixes.Count > 0)
            {
                foreach (var airportCodePrefix in AirportCodePrefixes)
                {
                    foreach (var airport in airportsResponse.Airports)
                    {
                        if (airport.AirportCode.StartsWith(airportCodePrefix) && !filteredAirports.Contains(airport))
                            filteredAirports.Add(airport);
                    }
                }
            }
            else
                filteredAirports = airportsResponse.Airports.ToList();

            OutputMessage($"{ filteredAirports.Count} airports found that match the airport code prefixes set in options.");

            foreach (var airport in filteredAirports.Where(x => x.RecommendedSceneryId.HasValue && x.RecommendedSceneryId > 0))
            {
                var sceneryResponse = await gatewayApiClient.GetSceneryResponse(airport.RecommendedSceneryId.Value);

                OutputMessage(sceneryResponse.UserName);
            }
        }

        /// <summary>
        /// Outputs a message to display to a user.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="verboseOnly">If true, then the message is only shown when the Verbose option is set.</param>
        private void OutputMessage(string message, bool verboseOnly = true)
        {
            if (Verbose)
                System.Console.WriteLine(message);
        }
    }
}
