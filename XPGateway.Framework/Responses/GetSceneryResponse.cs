using System;

namespace XPGateway.Framework.Responses
{
    public class GetSceneryResponse
    {
        public int SceneryId { get; set; }
        public int ParentId { get; set; }
        public string Icao { get; set; }
        public string AptName { get; set; }
        public string UserName { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime DateAccepted { get; set; }
        public DateTime DateApproved { get; set; }
        public DateTime? DateDeclined { get; set; }
        public string Type { get; set; }
        public string Features { get; set; }
        public string ArtistComments { get; set; }
        public string ModeratorComments { get; set; }
        public string MasterZipBlog { get; set; }
    }
}