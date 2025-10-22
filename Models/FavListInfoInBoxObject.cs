using Newtonsoft.Json;

namespace SdxChannelSorter.Models
{
    public class FavListInfoInBoxObject
    {
        [JsonProperty("ucFavNameChangeMask")]
        public int UcFavNameChangeMask { get; set; }

        [JsonProperty("ucFavListTVMask_no_used")]
        public int UcFavListTVMask_no_used { get; set; }

        [JsonProperty("ucFavListRadioMask_no_used")]
        public int UcFavListRadioMask_no_used { get; set; }

        [JsonProperty("ucFavouriteType")]
        public int UcFavouriteType { get; set; }

        [JsonProperty("aucFavReName")]
        public List<string> AucFavReName { get; set; }

        public FavListInfoInBoxObject()
        {
            AucFavReName = new List<string>();
        }
    }
}

