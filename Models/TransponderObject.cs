using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class TransponderFlagStruct
    {
        [JsonPropertyName("POL")]
        public int POL { get; set; }

        [JsonPropertyName("FEC")]
        public int FEC { get; set; }

        [JsonPropertyName("IQ")]
        public int IQ { get; set; }

        [JsonPropertyName("SatIndex")]
        public int SatIndex { get; set; }

        [JsonPropertyName("NetNameNo")]
        public int NetNameNo { get; set; }

        [JsonPropertyName("TPIndex")]
        public int TPIndex { get; set; }
    }

    public class TransponderObject
    {
        [JsonPropertyName("usStartCode")]
        public int UsStartCode { get; set; }

        [JsonPropertyName("usNetworkLen")]
        public int UsNetworkLen { get; set; }

        [JsonPropertyName("Freq")]
        public int Freq { get; set; }

        [JsonPropertyName("SR")]
        public int SR { get; set; }

        [JsonPropertyName("stFlag")]
        public TransponderFlagStruct? StFlag { get; set; }

        [JsonPropertyName("NetName")]
        public List<string> NetName { get; set; }

        public TransponderObject()
        {
            NetName = new List<string>();
        }
    }
}

