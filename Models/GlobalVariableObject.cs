using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class GlobalVariableObject
    {
        [JsonPropertyName("enable_max_fav_26")]
        public bool EnableMaxFav26 { get; set; }

        [JsonPropertyName("enable_save_last_watch_for_sat")]
        public bool EnableSaveLastWatchForSat { get; set; }

        [JsonPropertyName("cec_support")]
        public bool CecSupport { get; set; }

        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("chipset_type")]
        public int ChipsetType { get; set; }

        [JsonPropertyName("hardware_type")]
        public int HardwareType { get; set; }

        [JsonPropertyName("platform_support")]
        public int PlatformSupport { get; set; }

        [JsonPropertyName("max_service_name_length")]
        public int MaxServiceNameLength { get; set; }

        [JsonPropertyName("max_audio_pid")]
        public int MaxAudioPid { get; set; }

        [JsonPropertyName("max_subtitle_pid")]
        public int MaxSubtitlePid { get; set; }

        [JsonPropertyName("max_no_of_programs")]
        public int MaxNoOfPrograms { get; set; }

        [JsonPropertyName("max_no_of_transponders")]
        public int MaxNoOfTransponders { get; set; }

        [JsonPropertyName("max_no_of_satellites")]
        public int MaxNoOfSatellites { get; set; }
    }
}

