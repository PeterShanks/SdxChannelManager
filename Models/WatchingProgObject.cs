using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class WatchingProgObject
    {
        [JsonPropertyName("stProgNo")]
        public ServiceIdStruct? StProgNo { get; set; }

        [JsonPropertyName("usTransportStreamID")]
        public int UsTransportStreamID { get; set; }

        [JsonPropertyName("usOriginalNetworkID")]
        public int UsOriginalNetworkID { get; set; }

        [JsonPropertyName("usFavSelect")]
        public int[] UsFavSelect { get; set; }

        public WatchingProgObject()
        {
            UsFavSelect = new int[26];
        }
    }
}

