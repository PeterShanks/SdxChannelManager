using Newtonsoft.Json;

namespace SdxChannelSorter.Models
{
    public class WatchingProgObject
    {
        [JsonProperty("stProgNo")]
        public ServiceIdStruct? StProgNo { get; set; }

        [JsonProperty("usTransportStreamID")]
        public int UsTransportStreamID { get; set; }

        [JsonProperty("usOriginalNetworkID")]
        public int UsOriginalNetworkID { get; set; }

        [JsonProperty("usFavSelect")]
        public int[] UsFavSelect { get; set; }

        public WatchingProgObject()
        {
            UsFavSelect = new int[26];
        }
    }
}

