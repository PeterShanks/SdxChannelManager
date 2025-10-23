using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class DatabaseHeaderObject
    {
        [JsonPropertyName("szMark")]
        public string? SzMark { get; set; }

        [JsonPropertyName("szDatabaseName")]
        public string? SzDatabaseName { get; set; }

        [JsonPropertyName("uiOriginalSize")]
        public int UiOriginalSize { get; set; }

        [JsonPropertyName("sSatellite")]
        public int SSatellite { get; set; }

        [JsonPropertyName("sTransponder")]
        public int STransponder { get; set; }

        [JsonPropertyName("sTVNumber")]
        public int STVNumber { get; set; }

        [JsonPropertyName("sRadioNumber")]
        public int SRadioNumber { get; set; }

        [JsonPropertyName("sSatRecLen")]
        public int SSatRecLen { get; set; }

        [JsonPropertyName("sTPRecLen")]
        public int STPRecLen { get; set; }

        [JsonPropertyName("sProgRecLen")]
        public int SProgRecLen { get; set; }

        [JsonPropertyName("sBoxRecLen")]
        public int SBoxRecLen { get; set; }

        [JsonPropertyName("sWatchRecLen")]
        public int SWatchRecLen { get; set; }

        [JsonPropertyName("sMaxFavor")]
        public int SMaxFavor { get; set; }

        [JsonPropertyName("sFavorListLen")]
        public int SFavorListLen { get; set; }

        [JsonPropertyName("sDataBaseVer")]
        public int SDataBaseVer { get; set; }

        [JsonPropertyName("uiFileLength")]
        public int UiFileLength { get; set; }

        [JsonPropertyName("uiCRC32")]
        public int UiCRC32 { get; set; }
    }
}

