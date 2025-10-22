using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class FavListInfoInBoxObject
    {
        [JsonPropertyName("ucFavNameChangeMask")]
        public int UcFavNameChangeMask { get; set; }

        [JsonPropertyName("ucFavListTVMask_no_used")]
        public int UcFavListTVMask_no_used { get; set; }

        [JsonPropertyName("ucFavListRadioMask_no_used")]
        public int UcFavListRadioMask_no_used { get; set; }

        [JsonPropertyName("ucFavouriteType")]
        public int UcFavouriteType { get; set; }

        [JsonPropertyName("aucFavReName")]
        public List<string> AucFavReName { get; set; }

        public FavListInfoInBoxObject()
        {
            AucFavReName = new List<string>();
        }
    }
}

