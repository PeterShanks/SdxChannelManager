using Newtonsoft.Json;

namespace SdxChannelManager.Models
{
    public class SatelliteUiSetStruct
    {
        [JsonProperty("uiBit")]
        public SatelliteUiBitStruct? UiBit { get; set; }

        [JsonProperty("uiStatus")]
        public int UiStatus { get; set; }
    }

    public class SatelliteUiBitStruct
    {
        [JsonProperty("22Hz")]
        public int Hz22 { get; set; }

        [JsonProperty("V12")]
        public int V12 { get; set; }

        [JsonProperty("DiSEqC")]
        public int DiSEqC { get; set; }

        [JsonProperty("DiSEqC11")]
        public int DiSEqC11 { get; set; }

        [JsonProperty("IsUnicable")]
        public int IsUnicable { get; set; }

        [JsonProperty("UnicableType")]
        public int UnicableType { get; set; }

        [JsonProperty("FTAOnly")]
        public int FTAOnly { get; set; }

        [JsonProperty("Motor")]
        public int Motor { get; set; }

        [JsonProperty("SatDir")]
        public int SatDir { get; set; }

        [JsonProperty("LNBPower")]
        public int LNBPower { get; set; }

        [JsonProperty("SelectedTP")]
        public int SelectedTP { get; set; }

        [JsonProperty("NetWorkSearch")]
        public int NetWorkSearch { get; set; }

        [JsonProperty("Hide")]
        public int Hide { get; set; }
    }

    public class SatelliteObject
    {
        [JsonProperty("SatName")]
        public string? SatName { get; set; }

        [JsonProperty("LowLnbFreq")]
        public int LowLnbFreq { get; set; }

        [JsonProperty("HighLnbFreq")]
        public int HighLnbFreq { get; set; }

        [JsonProperty("SatAngle")]
        public int SatAngle { get; set; }

        [JsonProperty("iSatMotoPosition")]
        public int ISatMotoPosition { get; set; }

        [JsonProperty("TunerMask")]
        public int TunerMask { get; set; }

        [JsonProperty("UnicableFreq")]
        public int UnicableFreq { get; set; }

        [JsonProperty("DLNBMask")]
        public int DLNBMask { get; set; }

        [JsonProperty("DLNBUserBand")]
        public int DLNBUserBand { get; set; }

        [JsonProperty("DLNBType")]
        public int DLNBType { get; set; }

        [JsonProperty("UnicableCH")]
        public int UnicableCH { get; set; }

        [JsonProperty("uiSet")]
        public SatelliteUiSetStruct? UiSet { get; set; }

        [JsonProperty("sSaveCurSatPlayTVIndex")]
        public int SSaveCurSatPlayTVIndex { get; set; }

        [JsonProperty("sSaveCurSatPlayRadioIndex")]
        public int SSaveCurSatPlayRadioIndex { get; set; }
    }
}

