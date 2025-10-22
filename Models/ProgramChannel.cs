using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class AudioPidInfo
    {
        [JsonPropertyName("PID")]
        public int PID { get; set; }

        [JsonPropertyName("Mode")]
        public int Mode { get; set; }

        [JsonPropertyName("Lang")]
        public int Lang { get; set; }

        [JsonPropertyName("Codec")]
        public int Codec { get; set; }
    }

    public class SubtitlePidInfo
    {
        [JsonPropertyName("PID")]
        public int PID { get; set; }

        [JsonPropertyName("Mode")]
        public int Mode { get; set; }

        [JsonPropertyName("Lang")]
        public int Lang { get; set; }

        [JsonPropertyName("Type")]
        public int Type { get; set; }

        [JsonPropertyName("CompPage")]
        public int CompPage { get; set; }

        [JsonPropertyName("AncPage")]
        public int AncPage { get; set; }
    }

    public class ServiceIdStruct
    {
        [JsonPropertyName("ServiceID")]
        public string? ServiceID { get; set; }

        [JsonPropertyName("unShort")]
        public UnShortStruct? UnShort { get; set; }
    }

    public class UnShortStruct
    {
        [JsonPropertyName("sLo16")]
        public int SLo16 { get; set; }

        [JsonPropertyName("sHi16")]
        public int SHi16 { get; set; }
    }

    public class UiSetStruct
    {
        [JsonPropertyName("uiBit")]
        public UiBitStruct? UiBit { get; set; }

        [JsonPropertyName("uiStatus")]
        public int UiStatus { get; set; }
    }

    public class UiBitStruct
    {
        [JsonPropertyName("Lock")]
        public int Lock { get; set; }

        [JsonPropertyName("TV")]
        public int TV { get; set; }

        [JsonPropertyName("Skip")]
        public int Skip { get; set; }

        [JsonPropertyName("CA")]
        public int CA { get; set; }

        [JsonPropertyName("VideoCodec")]
        public int VideoCodec { get; set; }

        [JsonPropertyName("HD")]
        public int HD { get; set; }

        [JsonPropertyName("Hide")]
        public int Hide { get; set; }

        [JsonPropertyName("NetNameSelected")]
        public int NetNameSelected { get; set; }
    }

    public class ProgramChannelData
    {
        [JsonPropertyName("uiStartCode")]
        public int UiStartCode { get; set; }

        [JsonPropertyName("ucNameLen")]
        public int UcNameLen { get; set; }

        [JsonPropertyName("ucAudioPID")]
        public int UcAudioPID { get; set; }

        [JsonPropertyName("ucSubPID")]
        public int UcSubPID { get; set; }

        [JsonPropertyName("VideoPID")]
        public int VideoPID { get; set; }

        [JsonPropertyName("PCRPID")]
        public int PCRPID { get; set; }

        [JsonPropertyName("PMTPID")]
        public int PMTPID { get; set; }

        [JsonPropertyName("TTXPID")]
        public int TTXPID { get; set; }

        [JsonPropertyName("stProgNo")]
        public ServiceIdStruct? StProgNo { get; set; }

        [JsonPropertyName("uiSet")]
        public UiSetStruct? UiSet { get; set; }

        [JsonPropertyName("TSID")]
        public int TSID { get; set; }

        [JsonPropertyName("ONID")]
        public int ONID { get; set; }

        [JsonPropertyName("SDTServiceType")]
        public int SDTServiceType { get; set; }

        [JsonPropertyName("t2mi_pg")]
        public int T2mi_pg { get; set; }

        [JsonPropertyName("t2mi_plp_id")]
        public int T2mi_plp_id { get; set; }

        [JsonPropertyName("t2mi_payload_pid")]
        public int T2mi_payload_pid { get; set; }

        [JsonPropertyName("FavBit")]
        public int FavBit { get; set; }

        [JsonPropertyName("ServiceName")]
        public string? ServiceName { get; set; }

        [JsonPropertyName("AudioSelected")]
        public int AudioSelected { get; set; }

        [JsonPropertyName("AudioArray")]
        public List<AudioPidInfo> AudioArray { get; set; }

        [JsonPropertyName("SubtSelected")]
        public int SubtSelected { get; set; }

        [JsonPropertyName("SubtArray")]
        public List<SubtitlePidInfo> SubtArray { get; set; }

        public ProgramChannelData()
        {
            AudioArray = new List<AudioPidInfo>();
            SubtArray = new List<SubtitlePidInfo>();
            ServiceName = string.Empty;
        }
    }
}

