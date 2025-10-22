using Newtonsoft.Json;

namespace SdxChannelSorter.Models
{
    public class AudioPidInfo
    {
        [JsonProperty("PID")]
        public int PID { get; set; }

        [JsonProperty("Mode")]
        public int Mode { get; set; }

        [JsonProperty("Lang")]
        public int Lang { get; set; }

        [JsonProperty("Codec")]
        public int Codec { get; set; }
    }

    public class SubtitlePidInfo
    {
        [JsonProperty("PID")]
        public int PID { get; set; }

        [JsonProperty("Mode")]
        public int Mode { get; set; }

        [JsonProperty("Lang")]
        public int Lang { get; set; }

        [JsonProperty("Type")]
        public int Type { get; set; }

        [JsonProperty("CompPage")]
        public int CompPage { get; set; }

        [JsonProperty("AncPage")]
        public int AncPage { get; set; }
    }

    public class ServiceIdStruct
    {
        [JsonProperty("ServiceID")]
        public string? ServiceID { get; set; }

        [JsonProperty("unShort")]
        public UnShortStruct? UnShort { get; set; }
    }

    public class UnShortStruct
    {
        [JsonProperty("sLo16")]
        public int SLo16 { get; set; }

        [JsonProperty("sHi16")]
        public int SHi16 { get; set; }
    }

    public class UiSetStruct
    {
        [JsonProperty("uiBit")]
        public UiBitStruct? UiBit { get; set; }

        [JsonProperty("uiStatus")]
        public int UiStatus { get; set; }
    }

    public class UiBitStruct
    {
        [JsonProperty("Lock")]
        public int Lock { get; set; }

        [JsonProperty("TV")]
        public int TV { get; set; }

        [JsonProperty("Skip")]
        public int Skip { get; set; }

        [JsonProperty("CA")]
        public int CA { get; set; }

        [JsonProperty("VideoCodec")]
        public int VideoCodec { get; set; }

        [JsonProperty("HD")]
        public int HD { get; set; }

        [JsonProperty("Hide")]
        public int Hide { get; set; }

        [JsonProperty("NetNameSelected")]
        public int NetNameSelected { get; set; }
    }

    public class ProgramChannelData
    {
        [JsonProperty("uiStartCode")]
        public int UiStartCode { get; set; }

        [JsonProperty("ucNameLen")]
        public int UcNameLen { get; set; }

        [JsonProperty("ucAudioPID")]
        public int UcAudioPID { get; set; }

        [JsonProperty("ucSubPID")]
        public int UcSubPID { get; set; }

        [JsonProperty("VideoPID")]
        public int VideoPID { get; set; }

        [JsonProperty("PCRPID")]
        public int PCRPID { get; set; }

        [JsonProperty("PMTPID")]
        public int PMTPID { get; set; }

        [JsonProperty("TTXPID")]
        public int TTXPID { get; set; }

        [JsonProperty("stProgNo")]
        public ServiceIdStruct? StProgNo { get; set; }

        [JsonProperty("uiSet")]
        public UiSetStruct? UiSet { get; set; }

        [JsonProperty("TSID")]
        public int TSID { get; set; }

        [JsonProperty("ONID")]
        public int ONID { get; set; }

        [JsonProperty("SDTServiceType")]
        public int SDTServiceType { get; set; }

        [JsonProperty("t2mi_pg")]
        public int T2mi_pg { get; set; }

        [JsonProperty("t2mi_plp_id")]
        public int T2mi_plp_id { get; set; }

        [JsonProperty("t2mi_payload_pid")]
        public int T2mi_payload_pid { get; set; }

        [JsonProperty("FavBit")]
        public int FavBit { get; set; }

        [JsonProperty("ServiceName")]
        public string? ServiceName { get; set; }

        [JsonProperty("AudioSelected")]
        public int AudioSelected { get; set; }

        [JsonProperty("AudioArray")]
        public List<AudioPidInfo> AudioArray { get; set; }

        [JsonProperty("SubtSelected")]
        public int SubtSelected { get; set; }

        [JsonProperty("SubtArray")]
        public List<SubtitlePidInfo> SubtArray { get; set; }

        public ProgramChannelData()
        {
            AudioArray = new List<AudioPidInfo>();
            SubtArray = new List<SubtitlePidInfo>();
            ServiceName = string.Empty;
        }
    }
}

