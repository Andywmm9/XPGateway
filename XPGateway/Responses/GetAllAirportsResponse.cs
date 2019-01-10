using System;
using System.Collections.Generic;

namespace XPGateway.Responses
{
    public class GetAllAirportsResponse
    {
        public GetAllAirportsResponse()
        {
            Airports = new List<Airport>();
        }

        public int Total { get; set; }
        public IList<Airport> Airports { get; set; }

        public class Airport
        {
            public string AirportCode { get; set; }
            public string AirportName { get; set; }
            public string AirportClass { get; set; }
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }
            public double? Elevation { get; set; }
            public int AcceptedSceneryCount { get; set; }
            public int ApprovedSceneryCount { get; set; }
            public int RecommendSceneryId { get; set; }
            public string Status { get; set; }
            public int SceneryType { get; set; }
            public int SubmissionCount { get; set; }
            public string CheckedOutBy { get; set; }
            public DateTime? CheckOutEndDate { get; set; }
        }
    }
}
