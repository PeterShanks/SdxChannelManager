using Newtonsoft.Json;

namespace SdxChannelSorter.Models
{
    public class GlobalVariableObject
    {
        [JsonProperty("enable_max_fav_26")]
        public bool EnableMaxFav26 { get; set; }

        [JsonProperty("enable_save_last_watch_for_sat")]
        public bool EnableSaveLastWatchForSat { get; set; }

        [JsonProperty("cec_support")]
        public bool CecSupport { get; set; }

        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }

        [JsonProperty("chipset_type")]
        public int ChipsetType { get; set; }

        [JsonProperty("hardware_type")]
        public int HardwareType { get; set; }

        [JsonProperty("platform_support")]
        public int PlatformSupport { get; set; }

        [JsonProperty("max_service_name_length")]
        public int MaxServiceNameLength { get; set; }

        [JsonProperty("max_audio_pid")]
        public int MaxAudioPid { get; set; }

        [JsonProperty("max_subtitle_pid")]
        public int MaxSubtitlePid { get; set; }

        [JsonProperty("max_no_of_programs")]
        public int MaxNoOfPrograms { get; set; }

        [JsonProperty("max_no_of_transponders")]
        public int MaxNoOfTransponders { get; set; }

        [JsonProperty("max_no_of_satellites")]
        public int MaxNoOfSatellites { get; set; }
    }
}

