using Newtonsoft.Json;

namespace SdxChannelSorter.Models
{
    public class DatabaseHeaderObject
    {
        [JsonProperty("szMark")]
        public string? SzMark { get; set; }

        [JsonProperty("szDatabaseName")]
        public string? SzDatabaseName { get; set; }

        [JsonProperty("uiOriginalSize")]
        public int UiOriginalSize { get; set; }

        [JsonProperty("sSatellite")]
        public int SSatellite { get; set; }

        [JsonProperty("sTransponder")]
        public int STransponder { get; set; }

        [JsonProperty("sTVNumber")]
        public int STVNumber { get; set; }

        [JsonProperty("sRadioNumber")]
        public int SRadioNumber { get; set; }

        [JsonProperty("sSatRecLen")]
        public int SSatRecLen { get; set; }

        [JsonProperty("sTPRecLen")]
        public int STPRecLen { get; set; }

        [JsonProperty("sProgRecLen")]
        public int SProgRecLen { get; set; }

        [JsonProperty("sBoxRecLen")]
        public int SBoxRecLen { get; set; }

        [JsonProperty("sWatchRecLen")]
        public int SWatchRecLen { get; set; }

        [JsonProperty("sMaxFavor")]
        public int SMaxFavor { get; set; }

        [JsonProperty("sFavorListLen")]
        public int SFavorListLen { get; set; }

        [JsonProperty("sDataBaseVer")]
        public int SDataBaseVer { get; set; }

        [JsonProperty("uiFileLength")]
        public int UiFileLength { get; set; }

        [JsonProperty("uiCRC32")]
        public int UiCRC32 { get; set; }
    }
}

