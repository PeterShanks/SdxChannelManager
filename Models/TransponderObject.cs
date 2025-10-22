using Newtonsoft.Json;

namespace SdxChannelSorter.Models
{
    public class TransponderFlagStruct
    {
        [JsonProperty("POL")]
        public int POL { get; set; }

        [JsonProperty("FEC")]
        public int FEC { get; set; }

        [JsonProperty("IQ")]
        public int IQ { get; set; }

        [JsonProperty("SatIndex")]
        public int SatIndex { get; set; }

        [JsonProperty("NetNameNo")]
        public int NetNameNo { get; set; }

        [JsonProperty("TPIndex")]
        public int TPIndex { get; set; }
    }

    public class TransponderObject
    {
        [JsonProperty("usStartCode")]
        public int UsStartCode { get; set; }

        [JsonProperty("usNetworkLen")]
        public int UsNetworkLen { get; set; }

        [JsonProperty("Freq")]
        public int Freq { get; set; }

        [JsonProperty("SR")]
        public int SR { get; set; }

        [JsonProperty("stFlag")]
        public TransponderFlagStruct? StFlag { get; set; }

        [JsonProperty("NetName")]
        public List<string> NetName { get; set; }

        public TransponderObject()
        {
            NetName = new List<string>();
        }
    }
}

