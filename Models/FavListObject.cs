using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class FavListObject
    {
        [JsonPropertyName("uiMark")]
        public long UiMark { get; set; }

        [JsonPropertyName("stProgNo")]
        public List<ServiceIdStruct> StProgNo { get; set; }

        [JsonPropertyName("sNoOfTVFavor")]
        public int SNoOfTVFavor { get; set; }

        [JsonPropertyName("sNoOfRadioFavor")]
        public int SNoOfRadioFavor { get; set; }

        [JsonPropertyName("sTailOfFavor")]
        public int STailOfFavor { get; set; }

        [JsonPropertyName("bUpdateFavor")]
        public int BUpdateFavor { get; set; }

        [JsonPropertyName("cHide")]
        public int CHide { get; set; }

        public FavListObject()
        {
            StProgNo = new List<ServiceIdStruct>();
        }
    }
}

