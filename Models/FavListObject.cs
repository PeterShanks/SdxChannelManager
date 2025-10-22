using Newtonsoft.Json;

namespace SdxChannelSorter.Models
{
    public class FavListObject
    {
        [JsonProperty("uiMark")]
        public long UiMark { get; set; }

        [JsonProperty("stProgNo")]
        public List<ServiceIdStruct> StProgNo { get; set; }

        [JsonProperty("sNoOfTVFavor")]
        public int SNoOfTVFavor { get; set; }

        [JsonProperty("sNoOfRadioFavor")]
        public int SNoOfRadioFavor { get; set; }

        [JsonProperty("sTailOfFavor")]
        public int STailOfFavor { get; set; }

        [JsonProperty("bUpdateFavor")]
        public int BUpdateFavor { get; set; }

        [JsonProperty("cHide")]
        public int CHide { get; set; }

        public FavListObject()
        {
            StProgNo = new List<ServiceIdStruct>();
        }
    }
}

