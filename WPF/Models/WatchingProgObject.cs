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

        private int[] _usFavSelect = new int[26];
        
        [JsonPropertyName("usFavSelect")]
        public int[] UsFavSelect 
        { 
            get => _usFavSelect;
            set
            {
                // Always ensure we have exactly 26 elements
                _usFavSelect = new int[26];
                if (value != null)
                {
                    Array.Copy(value, _usFavSelect, Math.Min(value.Length, 26));
                }
            }
        }

        public WatchingProgObject()
        {
            _usFavSelect = new int[26];
        }
    }
}

