using System.Text.Json.Serialization;

namespace SdxChannelManager.Models
{
    public class ManualTime
    {
        [JsonPropertyName("bManualTime")]
        public int BManualTime { get; set; }

        [JsonPropertyName("ucHour")]
        public int UcHour { get; set; }

        [JsonPropertyName("ucMinu")]
        public int UcMinu { get; set; }

        [JsonPropertyName("ucDate")]
        public int UcDate { get; set; }

        [JsonPropertyName("ucMonth")]
        public int UcMonth { get; set; }

        [JsonPropertyName("iYear")]
        public int IYear { get; set; }
    }

    public class USBSetting
    {
        [JsonPropertyName("uiLoopMode")]
        public int UiLoopMode { get; set; }

        [JsonPropertyName("uiSlideShowInterval")]
        public int UiSlideShowInterval { get; set; }

        [JsonPropertyName("uiTimeShiftBufSize")]
        public int UiTimeShiftBufSize { get; set; }

        [JsonPropertyName("uiRecTimeMinHi")]
        public int UiRecTimeMinHi { get; set; }

        [JsonPropertyName("uiPhotoViewMode")]
        public int UiPhotoViewMode { get; set; }

        [JsonPropertyName("uiRecTimeMinLow")]
        public int UiRecTimeMinLow { get; set; }

        [JsonPropertyName("uiRecDriveNo")]
        public int UiRecDriveNo { get; set; }

        [JsonPropertyName("uiTimeShiftDriveNo")]
        public int UiTimeShiftDriveNo { get; set; }

        [JsonPropertyName("uiAlwaysTimeShift")]
        public int UiAlwaysTimeShift { get; set; }

        [JsonPropertyName("uiRecWholeTP")]
        public int UiRecWholeTP { get; set; }

        [JsonPropertyName("uiSubtitleFontColor")]
        public int UiSubtitleFontColor { get; set; }

        [JsonPropertyName("uiSubtitleBackColor")]
        public int UiSubtitleBackColor { get; set; }

        [JsonPropertyName("uiSubtitleEncodeType")]
        public int UiSubtitleEncodeType { get; set; }

        [JsonPropertyName("uiAutoUploadToFTP")]
        public int UiAutoUploadToFTP { get; set; }

        [JsonPropertyName("uiUSBFileSortType")]
        public int UiUSBFileSortType { get; set; }

        [JsonPropertyName("uiPVRStartLastPos")]
        public int UiPVRStartLastPos { get; set; }

        [JsonPropertyName("uiRecType")]
        public int UiRecType { get; set; }

        [JsonPropertyName("uiNeedSaveTMS")]
        public int UiNeedSaveTMS { get; set; }

        [JsonPropertyName("uiSetTmsToRecord")]
        public int UiSetTmsToRecord { get; set; }
    }

    public class IPConfig
    {
        [JsonPropertyName("bDisable")]
        public int BDisable { get; set; }

        [JsonPropertyName("bStaticIP")]
        public int BStaticIP { get; set; }

        [JsonPropertyName("IpAddress")]
        public string? IpAddress { get; set; }

        [JsonPropertyName("NetMask")]
        public string? NetMask { get; set; }

        [JsonPropertyName("GateWay")]
        public string? GateWay { get; set; }

        [JsonPropertyName("NetDNS1")]
        public string? NetDNS1 { get; set; }

        [JsonPropertyName("NetDNS2")]
        public string? NetDNS2 { get; set; }
    }

    public class CECConfig
    {
        [JsonPropertyName("cec_func_enable")]
        public int CecFuncEnable { get; set; }

        [JsonPropertyName("cec_feature_rcp_enable")]
        public int CecFeatureRcpEnable { get; set; }

        [JsonPropertyName("system_audio_mode_status")]
        public int SystemAudioModeStatus { get; set; }

        [JsonPropertyName("cec_device_standby_mode")]
        public int CecDeviceStandbyMode { get; set; }
    }

    public class BoxObject
    {
        [JsonPropertyName("uiTrans")]
        public int UiTrans { get; set; }

        [JsonPropertyName("uiTXTTrans")]
        public int UiTXTTrans { get; set; }

        [JsonPropertyName("uiVolLevel")]
        public int UiVolLevel { get; set; }

        [JsonPropertyName("uiSatSelect")]
        public int UiSatSelect { get; set; }

        [JsonPropertyName("bMuteState")]
        public int BMuteState { get; set; }

        [JsonPropertyName("bTVState")]
        public int BTVState { get; set; }

        [JsonPropertyName("bScanMode")]
        public int BScanMode { get; set; }

        [JsonPropertyName("bHelpMode")]
        public int BHelpMode { get; set; }

        [JsonPropertyName("bNetworkSearch")]
        public int BNetworkSearch { get; set; }

        [JsonPropertyName("uiAdjustTimeType")]
        public int UiAdjustTimeType { get; set; }

        [JsonPropertyName("uiSearchSpeed")]
        public int UiSearchSpeed { get; set; }

        [JsonPropertyName("uiTunerSelect")]
        public int UiTunerSelect { get; set; }

        [JsonPropertyName("uiFTASelect")]
        public int UiFTASelect { get; set; }

        [JsonPropertyName("bInstallLock")]
        public int BInstallLock { get; set; }

        [JsonPropertyName("bEditLock")]
        public int BEditLock { get; set; }

        [JsonPropertyName("bSystemLock")]
        public int BSystemLock { get; set; }

        [JsonPropertyName("bScart")]
        public int BScart { get; set; }

        [JsonPropertyName("bPatchEnable")]
        public int BPatchEnable { get; set; }

        [JsonPropertyName("uiTimeMode")]
        public int UiTimeMode { get; set; }

        [JsonPropertyName("uiFontType")]
        public int UiFontType { get; set; }

        [JsonPropertyName("bUsbtoRs232")]
        public int BUsbtoRs232 { get; set; }

        [JsonPropertyName("bUpdateFlag")]
        public int BUpdateFlag { get; set; }

        [JsonPropertyName("bDispRecIcon")]
        public int BDispRecIcon { get; set; }

        [JsonPropertyName("uiUsal")]
        public int UiUsal { get; set; }

        [JsonPropertyName("uiSupplyLnb")]
        public int UiSupplyLnb { get; set; }

        [JsonPropertyName("bStandbyClock")]
        public int BStandbyClock { get; set; }

        [JsonPropertyName("bSignalAudio")]
        public int BSignalAudio { get; set; }

        [JsonPropertyName("bNeedToDoUserGuide")]
        public int BNeedToDoUserGuide { get; set; }

        [JsonPropertyName("update_channel_name_auto")]
        public int UpdateChannelNameAuto { get; set; }

        [JsonPropertyName("temp_official_sw")]
        public int TempOfficialSw { get; set; }

        [JsonPropertyName("load_m3u_file_mode")]
        public int LoadM3uFileMode { get; set; }

        [JsonPropertyName("uiAPDtime")]
        public int UiAPDtime { get; set; }

        [JsonPropertyName("need_standby_after_ota_update")]
        public int NeedStandbyAfterOtaUpdate { get; set; }

        [JsonPropertyName("channel_color_switch_mode")]
        public int ChannelColorSwitchMode { get; set; }

        [JsonPropertyName("uiTuneOut")]
        public int UiTuneOut { get; set; }

        [JsonPropertyName("uiAudioOutputMode")]
        public int UiAudioOutputMode { get; set; }

        [JsonPropertyName("uiSelectFTP")]
        public int UiSelectFTP { get; set; }

        [JsonPropertyName("bAutoChSwitchMode")]
        public int BAutoChSwitchMode { get; set; }

        [JsonPropertyName("bAutoChExitMode")]
        public int BAutoChExitMode { get; set; }

        [JsonPropertyName("bMultiPicLoopMode")]
        public int BMultiPicLoopMode { get; set; }

        [JsonPropertyName("bShowRecallList")]
        public int BShowRecallList { get; set; }

        [JsonPropertyName("bBlankMode")]
        public int BBlankMode { get; set; }

        [JsonPropertyName("bQuickSwitchChannel")]
        public int BQuickSwitchChannel { get; set; }

        [JsonPropertyName("bTimerOnMode")]
        public int BTimerOnMode { get; set; }

        [JsonPropertyName("bStandbyMode")]
        public int BStandbyMode { get; set; }

        [JsonPropertyName("uiAFD")]
        public int UiAFD { get; set; }

        [JsonPropertyName("bProviderSelect")]
        public int BProviderSelect { get; set; }

        [JsonPropertyName("uiProviderIndex")]
        public int UiProviderIndex { get; set; }

        [JsonPropertyName("bStartAutoTimeShiftDisp")]
        public int BStartAutoTimeShiftDisp { get; set; }

        [JsonPropertyName("bScrambleChannelDisp")]
        public int BScrambleChannelDisp { get; set; }

        [JsonPropertyName("uiOSDTimeout")]
        public int UiOSDTimeout { get; set; }

        [JsonPropertyName("ucCurTTXLanuage")]
        public int UcCurTTXLanuage { get; set; }

        [JsonPropertyName("bStandby")]
        public int BStandby { get; set; }

        [JsonPropertyName("bUSBWifiEnable")]
        public int BUSBWifiEnable { get; set; }

        [JsonPropertyName("bEnableScartOut")]
        public int BEnableScartOut { get; set; }

        [JsonPropertyName("bEMMBlocker")]
        public int BEMMBlocker { get; set; }

        [JsonPropertyName("bEMMUBlocker")]
        public int BEMMUBlocker { get; set; }

        [JsonPropertyName("bEMMSBlocker")]
        public int BEMMSBlocker { get; set; }

        [JsonPropertyName("bEMMGBlocker")]
        public int BEMMGBlocker { get; set; }

        [JsonPropertyName("bDisplayHomeshareMenu")]
        public int BDisplayHomeshareMenu { get; set; }

        [JsonPropertyName("bDisplayYoupornMenu")]
        public int BDisplayYoupornMenu { get; set; }

        [JsonPropertyName("ch_list_multi_columns")]
        public int ChListMultiColumns { get; set; }

        [JsonPropertyName("uiFPDisplayMode")]
        public int UiFPDisplayMode { get; set; }

        [JsonPropertyName("fp_scroll_mode")]
        public int FpScrollMode { get; set; }

        [JsonPropertyName("bDolbyPriority")]
        public int BDolbyPriority { get; set; }

        [JsonPropertyName("ucUartOption")]
        public int UcUartOption { get; set; }

        [JsonPropertyName("bHideLockedChannel")]
        public int BHideLockedChannel { get; set; }

        [JsonPropertyName("uiAntennaConnectType")]
        public int UiAntennaConnectType { get; set; }

        [JsonPropertyName("uiRCUType")]
        public int UiRCUType { get; set; }

        [JsonPropertyName("uiV12")]
        public int UiV12 { get; set; }

        [JsonPropertyName("back_to_antenna_setting")]
        public int BackToAntennaSetting { get; set; }

        [JsonPropertyName("enable_auto_detect_updating")]
        public int EnableAutoDetectUpdating { get; set; }

        [JsonPropertyName("youtube_osd_style")]
        public int YoutubeOsdStyle { get; set; }

        [JsonPropertyName("uiSearchType")]
        public int UiSearchType { get; set; }

        [JsonPropertyName("uiEnableXTms")]
        public int UiEnableXTms { get; set; }

        [JsonPropertyName("bEnableSexChannel")]
        public int BEnableSexChannel { get; set; }

        [JsonPropertyName("sds_control_isp")]
        public int SdsControlIsp { get; set; }

        [JsonPropertyName("ota_update_auto")]
        public int OtaUpdateAuto { get; set; }

        [JsonPropertyName("ca_type")]
        public int CaType { get; set; }

        [JsonPropertyName("SortType")]
        public int SortType { get; set; }

        [JsonPropertyName("sid_number_disp")]
        public int SidNumberDisp { get; set; }

        [JsonPropertyName("ci_message_enable")]
        public int CiMessageEnable { get; set; }

        [JsonPropertyName("uiAspectRatio")]
        public int UiAspectRatio { get; set; }

        [JsonPropertyName("ad_service")]
        public int AdService { get; set; }

        [JsonPropertyName("ad_volume_offset")]
        public int AdVolumeOffset { get; set; }

        [JsonPropertyName("subtitle_control")]
        public int SubtitleControl { get; set; }

        [JsonPropertyName("sks_color_id")]
        public int SksColorId { get; set; }

        [JsonPropertyName("summer_time_setting")]
        public int SummerTimeSetting { get; set; }

        [JsonPropertyName("usb_3g_auto_detect_provider")]
        public int Usb3gAutoDetectProvider { get; set; }

        [JsonPropertyName("default_net_type")]
        public int DefaultNetType { get; set; }

        [JsonPropertyName("auto_change_channel_on_edit")]
        public int AutoChangeChannelOnEdit { get; set; }

        [JsonPropertyName("search_type_dvbt")]
        public int SearchTypeDvbt { get; set; }

        [JsonPropertyName("show_tivusat_channel_list")]
        public int ShowTivusatChannelList { get; set; }

        [JsonPropertyName("need_show_tivusat_channel_change")]
        public int NeedShowTivusatChannelChange { get; set; }

        [JsonPropertyName("search_in_standby_mode")]
        public int SearchInStandbyMode { get; set; }

        [JsonPropertyName("search_in_operate_mode")]
        public int SearchInOperateMode { get; set; }

        [JsonPropertyName("uiDispResolution")]
        public int UiDispResolution { get; set; }

        [JsonPropertyName("auto_ota_in_standby_mode")]
        public int AutoOtaInStandbyMode { get; set; }

        [JsonPropertyName("auto_ota_in_operate_mode")]
        public int AutoOtaInOperateMode { get; set; }

        [JsonPropertyName("sw_update_by_ota")]
        public int SwUpdateByOta { get; set; }

        [JsonPropertyName("need_messge_remind_sw_update")]
        public int NeedMessgeRemindSwUpdate { get; set; }

        [JsonPropertyName("vod_enable")]
        public int VodEnable { get; set; }

        [JsonPropertyName("cPassWord")]
        public string? CPassWord { get; set; }

        [JsonPropertyName("ucPassCtrlInfo")]
        public int UcPassCtrlInfo { get; set; }

        [JsonPropertyName("ucAgeRating")]
        public int UcAgeRating { get; set; }

        [JsonPropertyName("cTimeZone")]
        public int CTimeZone { get; set; }

        [JsonPropertyName("ucChannelState")]
        public int UcChannelState { get; set; }

        [JsonPropertyName("ucFavouriteType")]
        public int UcFavouriteType { get; set; }

        [JsonPropertyName("ucLanguage")]
        public int UcLanguage { get; set; }

        [JsonPropertyName("ucAudioLanguage")]
        public int UcAudioLanguage { get; set; }

        [JsonPropertyName("ucAudioLan2")]
        public int UcAudioLan2 { get; set; }

        [JsonPropertyName("ucSubLanguage")]
        public int UcSubLanguage { get; set; }

        [JsonPropertyName("ucCurEPGLanuage")]
        public int UcCurEPGLanuage { get; set; }

        [JsonPropertyName("ucTPFlag")]
        public int UcTPFlag { get; set; }

        [JsonPropertyName("ucCurSat")]
        public int UcCurSat { get; set; }

        [JsonPropertyName("ucFavListTVMask_no_used")]
        public int UcFavListTVMask_no_used { get; set; }

        [JsonPropertyName("ucFavListRadioMask_no_used")]
        public int UcFavListRadioMask_no_used { get; set; }

        [JsonPropertyName("aucFavReName")]
        public List<string> AucFavReName { get; set; }

        [JsonPropertyName("ucFavNameChangeMask")]
        public int UcFavNameChangeMask { get; set; }

        [JsonPropertyName("uiNDSBoxKey")]
        public int UiNDSBoxKey { get; set; }

        [JsonPropertyName("dLongitudeAngle")]
        public int DLongitudeAngle { get; set; }

        [JsonPropertyName("dLatitudeAngle")]
        public int DLatitudeAngle { get; set; }

        [JsonPropertyName("iRotating_speedMotor1")]
        public int IRotating_speedMotor1 { get; set; }

        [JsonPropertyName("uiGShareServerPort")]
        public int UiGShareServerPort { get; set; }

        [JsonPropertyName("aucSatIndex")]
        public string? AucSatIndex { get; set; }

        [JsonPropertyName("ucSharpNess")]
        public int UcSharpNess { get; set; }

        [JsonPropertyName("ucContrast")]
        public int UcContrast { get; set; }

        [JsonPropertyName("ucSaturation")]
        public int UcSaturation { get; set; }

        [JsonPropertyName("ucBrightness")]
        public int UcBrightness { get; set; }

        [JsonPropertyName("ucCASSelect")]
        public int UcCASSelect { get; set; }

        [JsonPropertyName("ucUartMode")]
        public int UcUartMode { get; set; }

        [JsonPropertyName("ucModulatorNo")]
        public int UcModulatorNo { get; set; }

        [JsonPropertyName("ucRFAudio")]
        public int UcRFAudio { get; set; }

        [JsonPropertyName("ucEPGStyle")]
        public int UcEPGStyle { get; set; }

        [JsonPropertyName("sTPFreq")]
        public int STPFreq { get; set; }

        [JsonPropertyName("sTPSymbol")]
        public int STPSymbol { get; set; }

        [JsonPropertyName("usInternalPort")]
        public int UsInternalPort { get; set; }

        [JsonPropertyName("gstManualTime")]
        public ManualTime? GstManualTime { get; set; }

        [JsonPropertyName("stUSBSetting")]
        public USBSetting? StUSBSetting { get; set; }

        [JsonPropertyName("stIPConfig")]
        public IPConfig? StIPConfig { get; set; }

        [JsonPropertyName("stWifiIPConfig")]
        public IPConfig? StWifiIPConfig { get; set; }

        [JsonPropertyName("ucSNChecked")]
        public int UcSNChecked { get; set; }

        [JsonPropertyName("uiSdsSat")]
        public int UiSdsSat { get; set; }

        [JsonPropertyName("ucSNStatus")]
        public int UcSNStatus { get; set; }

        [JsonPropertyName("ucCountry")]
        public int UcCountry { get; set; }

        [JsonPropertyName("weather_bar_enable")]
        public int WeatherBarEnable { get; set; }

        [JsonPropertyName("uiAPDStandBy")]
        public int UiAPDStandBy { get; set; }

        [JsonPropertyName("uiSDSMode")]
        public int UiSDSMode { get; set; }

        [JsonPropertyName("uiFPLightLevel")]
        public int UiFPLightLevel { get; set; }

        [JsonPropertyName("cur_channel_list_id")]
        public int CurChannelListId { get; set; }

        [JsonPropertyName("ucLCNOn")]
        public int UcLCNOn { get; set; }

        [JsonPropertyName("global_nit_tp_freq")]
        public int GlobalNitTpFreq { get; set; }

        [JsonPropertyName("cec_config")]
        public CECConfig? CecConfig { get; set; }

        [JsonPropertyName("ms_tp")]
        public int MsTp { get; set; }

        [JsonPropertyName("ms_tp_isid")]
        public int MsTpIsid { get; set; }

        [JsonPropertyName("tsn_tp")]
        public int TsnTp { get; set; }

        [JsonPropertyName("tsn_tp_id")]
        public int TsnTpId { get; set; }

        public BoxObject()
        {
            AucFavReName = new List<string>();
        }
    }
}

