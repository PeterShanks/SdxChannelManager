using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class SatelliteUiSetStruct
    {
        [JsonPropertyName("uiBit")]
        public SatelliteUiBitStruct? UiBit { get; set; }

        [JsonPropertyName("uiStatus")]
        public int UiStatus { get; set; }
    }

    public class SatelliteUiBitStruct
    {
        [JsonPropertyName("22Hz")]
        public int Hz22 { get; set; }

        [JsonPropertyName("V12")]
        public int V12 { get; set; }

        [JsonPropertyName("DiSEqC")]
        public int DiSEqC { get; set; }

        [JsonPropertyName("DiSEqC11")]
        public int DiSEqC11 { get; set; }

        [JsonPropertyName("IsUnicable")]
        public int IsUnicable { get; set; }

        [JsonPropertyName("UnicableType")]
        public int UnicableType { get; set; }

        [JsonPropertyName("FTAOnly")]
        public int FTAOnly { get; set; }

        [JsonPropertyName("Motor")]
        public int Motor { get; set; }

        [JsonPropertyName("SatDir")]
        public int SatDir { get; set; }

        [JsonPropertyName("LNBPower")]
        public int LNBPower { get; set; }

        [JsonPropertyName("SelectedTP")]
        public int SelectedTP { get; set; }

        [JsonPropertyName("NetWorkSearch")]
        public int NetWorkSearch { get; set; }

        [JsonPropertyName("Hide")]
        public int Hide { get; set; }
    }

    public class SatelliteObject
    {
        [JsonPropertyName("SatName")]
        public string? SatName { get; set; }

        [JsonPropertyName("LowLnbFreq")]
        public int LowLnbFreq { get; set; }

        [JsonPropertyName("HighLnbFreq")]
        public int HighLnbFreq { get; set; }

        [JsonPropertyName("SatAngle")]
        public int SatAngle { get; set; }

        [JsonPropertyName("iSatMotoPosition")]
        public int ISatMotoPosition { get; set; }

        [JsonPropertyName("TunerMask")]
        public int TunerMask { get; set; }

        [JsonPropertyName("UnicableFreq")]
        public int UnicableFreq { get; set; }

        [JsonPropertyName("DLNBMask")]
        public int DLNBMask { get; set; }

        [JsonPropertyName("DLNBUserBand")]
        public int DLNBUserBand { get; set; }

        [JsonPropertyName("DLNBType")]
        public int DLNBType { get; set; }

        [JsonPropertyName("UnicableCH")]
        public int UnicableCH { get; set; }

        [JsonPropertyName("uiSet")]
        public SatelliteUiSetStruct? UiSet { get; set; }

        [JsonPropertyName("sSaveCurSatPlayTVIndex")]
        public int SSaveCurSatPlayTVIndex { get; set; }

        [JsonPropertyName("sSaveCurSatPlayRadioIndex")]
        public int SSaveCurSatPlayRadioIndex { get; set; }
    }
}

