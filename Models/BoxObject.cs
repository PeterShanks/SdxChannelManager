using Newtonsoft.Json;

namespace SdxChannelSorter.Models
{
    public class ManualTime
    {
        [JsonProperty("bManualTime")]
        public int BManualTime { get; set; }

        [JsonProperty("ucHour")]
        public int UcHour { get; set; }

        [JsonProperty("ucMinu")]
        public int UcMinu { get; set; }

        [JsonProperty("ucDate")]
        public int UcDate { get; set; }

        [JsonProperty("ucMonth")]
        public int UcMonth { get; set; }

        [JsonProperty("iYear")]
        public int IYear { get; set; }
    }

    public class USBSetting
    {
        [JsonProperty("uiLoopMode")]
        public int UiLoopMode { get; set; }

        [JsonProperty("uiSlideShowInterval")]
        public int UiSlideShowInterval { get; set; }

        [JsonProperty("uiTimeShiftBufSize")]
        public int UiTimeShiftBufSize { get; set; }

        [JsonProperty("uiRecTimeMinHi")]
        public int UiRecTimeMinHi { get; set; }

        [JsonProperty("uiPhotoViewMode")]
        public int UiPhotoViewMode { get; set; }

        [JsonProperty("uiRecTimeMinLow")]
        public int UiRecTimeMinLow { get; set; }

        [JsonProperty("uiRecDriveNo")]
        public int UiRecDriveNo { get; set; }

        [JsonProperty("uiTimeShiftDriveNo")]
        public int UiTimeShiftDriveNo { get; set; }

        [JsonProperty("uiAlwaysTimeShift")]
        public int UiAlwaysTimeShift { get; set; }

        [JsonProperty("uiRecWholeTP")]
        public int UiRecWholeTP { get; set; }

        [JsonProperty("uiSubtitleFontColor")]
        public int UiSubtitleFontColor { get; set; }

        [JsonProperty("uiSubtitleBackColor")]
        public int UiSubtitleBackColor { get; set; }

        [JsonProperty("uiSubtitleEncodeType")]
        public int UiSubtitleEncodeType { get; set; }

        [JsonProperty("uiAutoUploadToFTP")]
        public int UiAutoUploadToFTP { get; set; }

        [JsonProperty("uiUSBFileSortType")]
        public int UiUSBFileSortType { get; set; }

        [JsonProperty("uiPVRStartLastPos")]
        public int UiPVRStartLastPos { get; set; }

        [JsonProperty("uiRecType")]
        public int UiRecType { get; set; }

        [JsonProperty("uiNeedSaveTMS")]
        public int UiNeedSaveTMS { get; set; }

        [JsonProperty("uiSetTmsToRecord")]
        public int UiSetTmsToRecord { get; set; }
    }

    public class IPConfig
    {
        [JsonProperty("bDisable")]
        public int BDisable { get; set; }

        [JsonProperty("bStaticIP")]
        public int BStaticIP { get; set; }

        [JsonProperty("IpAddress")]
        public string? IpAddress { get; set; }

        [JsonProperty("NetMask")]
        public string? NetMask { get; set; }

        [JsonProperty("GateWay")]
        public string? GateWay { get; set; }

        [JsonProperty("NetDNS1")]
        public string? NetDNS1 { get; set; }

        [JsonProperty("NetDNS2")]
        public string? NetDNS2 { get; set; }
    }

    public class CECConfig
    {
        [JsonProperty("cec_func_enable")]
        public int CecFuncEnable { get; set; }

        [JsonProperty("cec_feature_rcp_enable")]
        public int CecFeatureRcpEnable { get; set; }

        [JsonProperty("system_audio_mode_status")]
        public int SystemAudioModeStatus { get; set; }

        [JsonProperty("cec_device_standby_mode")]
        public int CecDeviceStandbyMode { get; set; }
    }

    public class BoxObject
    {
        [JsonProperty("uiTrans")]
        public int UiTrans { get; set; }

        [JsonProperty("uiTXTTrans")]
        public int UiTXTTrans { get; set; }

        [JsonProperty("uiVolLevel")]
        public int UiVolLevel { get; set; }

        [JsonProperty("uiSatSelect")]
        public int UiSatSelect { get; set; }

        [JsonProperty("bMuteState")]
        public int BMuteState { get; set; }

        [JsonProperty("bTVState")]
        public int BTVState { get; set; }

        [JsonProperty("bScanMode")]
        public int BScanMode { get; set; }

        [JsonProperty("bHelpMode")]
        public int BHelpMode { get; set; }

        [JsonProperty("bNetworkSearch")]
        public int BNetworkSearch { get; set; }

        [JsonProperty("uiAdjustTimeType")]
        public int UiAdjustTimeType { get; set; }

        [JsonProperty("uiSearchSpeed")]
        public int UiSearchSpeed { get; set; }

        [JsonProperty("uiTunerSelect")]
        public int UiTunerSelect { get; set; }

        [JsonProperty("uiFTASelect")]
        public int UiFTASelect { get; set; }

        [JsonProperty("bInstallLock")]
        public int BInstallLock { get; set; }

        [JsonProperty("bEditLock")]
        public int BEditLock { get; set; }

        [JsonProperty("bSystemLock")]
        public int BSystemLock { get; set; }

        [JsonProperty("bScart")]
        public int BScart { get; set; }

        [JsonProperty("bPatchEnable")]
        public int BPatchEnable { get; set; }

        [JsonProperty("uiTimeMode")]
        public int UiTimeMode { get; set; }

        [JsonProperty("uiFontType")]
        public int UiFontType { get; set; }

        [JsonProperty("bUsbtoRs232")]
        public int BUsbtoRs232 { get; set; }

        [JsonProperty("bUpdateFlag")]
        public int BUpdateFlag { get; set; }

        [JsonProperty("bDispRecIcon")]
        public int BDispRecIcon { get; set; }

        [JsonProperty("uiUsal")]
        public int UiUsal { get; set; }

        [JsonProperty("uiSupplyLnb")]
        public int UiSupplyLnb { get; set; }

        [JsonProperty("bStandbyClock")]
        public int BStandbyClock { get; set; }

        [JsonProperty("bSignalAudio")]
        public int BSignalAudio { get; set; }

        [JsonProperty("bNeedToDoUserGuide")]
        public int BNeedToDoUserGuide { get; set; }

        [JsonProperty("update_channel_name_auto")]
        public int UpdateChannelNameAuto { get; set; }

        [JsonProperty("temp_official_sw")]
        public int TempOfficialSw { get; set; }

        [JsonProperty("load_m3u_file_mode")]
        public int LoadM3uFileMode { get; set; }

        [JsonProperty("uiAPDtime")]
        public int UiAPDtime { get; set; }

        [JsonProperty("need_standby_after_ota_update")]
        public int NeedStandbyAfterOtaUpdate { get; set; }

        [JsonProperty("channel_color_switch_mode")]
        public int ChannelColorSwitchMode { get; set; }

        [JsonProperty("uiTuneOut")]
        public int UiTuneOut { get; set; }

        [JsonProperty("uiAudioOutputMode")]
        public int UiAudioOutputMode { get; set; }

        [JsonProperty("uiSelectFTP")]
        public int UiSelectFTP { get; set; }

        [JsonProperty("bAutoChSwitchMode")]
        public int BAutoChSwitchMode { get; set; }

        [JsonProperty("bAutoChExitMode")]
        public int BAutoChExitMode { get; set; }

        [JsonProperty("bMultiPicLoopMode")]
        public int BMultiPicLoopMode { get; set; }

        [JsonProperty("bShowRecallList")]
        public int BShowRecallList { get; set; }

        [JsonProperty("bBlankMode")]
        public int BBlankMode { get; set; }

        [JsonProperty("bQuickSwitchChannel")]
        public int BQuickSwitchChannel { get; set; }

        [JsonProperty("bTimerOnMode")]
        public int BTimerOnMode { get; set; }

        [JsonProperty("bStandbyMode")]
        public int BStandbyMode { get; set; }

        [JsonProperty("uiAFD")]
        public int UiAFD { get; set; }

        [JsonProperty("bProviderSelect")]
        public int BProviderSelect { get; set; }

        [JsonProperty("uiProviderIndex")]
        public int UiProviderIndex { get; set; }

        [JsonProperty("bStartAutoTimeShiftDisp")]
        public int BStartAutoTimeShiftDisp { get; set; }

        [JsonProperty("bScrambleChannelDisp")]
        public int BScrambleChannelDisp { get; set; }

        [JsonProperty("uiOSDTimeout")]
        public int UiOSDTimeout { get; set; }

        [JsonProperty("ucCurTTXLanuage")]
        public int UcCurTTXLanuage { get; set; }

        [JsonProperty("bStandby")]
        public int BStandby { get; set; }

        [JsonProperty("bUSBWifiEnable")]
        public int BUSBWifiEnable { get; set; }

        [JsonProperty("bEnableScartOut")]
        public int BEnableScartOut { get; set; }

        [JsonProperty("bEMMBlocker")]
        public int BEMMBlocker { get; set; }

        [JsonProperty("bEMMUBlocker")]
        public int BEMMUBlocker { get; set; }

        [JsonProperty("bEMMSBlocker")]
        public int BEMMSBlocker { get; set; }

        [JsonProperty("bEMMGBlocker")]
        public int BEMMGBlocker { get; set; }

        [JsonProperty("bDisplayHomeshareMenu")]
        public int BDisplayHomeshareMenu { get; set; }

        [JsonProperty("bDisplayYoupornMenu")]
        public int BDisplayYoupornMenu { get; set; }

        [JsonProperty("ch_list_multi_columns")]
        public int ChListMultiColumns { get; set; }

        [JsonProperty("uiFPDisplayMode")]
        public int UiFPDisplayMode { get; set; }

        [JsonProperty("fp_scroll_mode")]
        public int FpScrollMode { get; set; }

        [JsonProperty("bDolbyPriority")]
        public int BDolbyPriority { get; set; }

        [JsonProperty("ucUartOption")]
        public int UcUartOption { get; set; }

        [JsonProperty("bHideLockedChannel")]
        public int BHideLockedChannel { get; set; }

        [JsonProperty("uiAntennaConnectType")]
        public int UiAntennaConnectType { get; set; }

        [JsonProperty("uiRCUType")]
        public int UiRCUType { get; set; }

        [JsonProperty("uiV12")]
        public int UiV12 { get; set; }

        [JsonProperty("back_to_antenna_setting")]
        public int BackToAntennaSetting { get; set; }

        [JsonProperty("enable_auto_detect_updating")]
        public int EnableAutoDetectUpdating { get; set; }

        [JsonProperty("youtube_osd_style")]
        public int YoutubeOsdStyle { get; set; }

        [JsonProperty("uiSearchType")]
        public int UiSearchType { get; set; }

        [JsonProperty("uiEnableXTms")]
        public int UiEnableXTms { get; set; }

        [JsonProperty("bEnableSexChannel")]
        public int BEnableSexChannel { get; set; }

        [JsonProperty("sds_control_isp")]
        public int SdsControlIsp { get; set; }

        [JsonProperty("ota_update_auto")]
        public int OtaUpdateAuto { get; set; }

        [JsonProperty("ca_type")]
        public int CaType { get; set; }

        [JsonProperty("SortType")]
        public int SortType { get; set; }

        [JsonProperty("sid_number_disp")]
        public int SidNumberDisp { get; set; }

        [JsonProperty("ci_message_enable")]
        public int CiMessageEnable { get; set; }

        [JsonProperty("uiAspectRatio")]
        public int UiAspectRatio { get; set; }

        [JsonProperty("ad_service")]
        public int AdService { get; set; }

        [JsonProperty("ad_volume_offset")]
        public int AdVolumeOffset { get; set; }

        [JsonProperty("subtitle_control")]
        public int SubtitleControl { get; set; }

        [JsonProperty("sks_color_id")]
        public int SksColorId { get; set; }

        [JsonProperty("summer_time_setting")]
        public int SummerTimeSetting { get; set; }

        [JsonProperty("usb_3g_auto_detect_provider")]
        public int Usb3gAutoDetectProvider { get; set; }

        [JsonProperty("default_net_type")]
        public int DefaultNetType { get; set; }

        [JsonProperty("auto_change_channel_on_edit")]
        public int AutoChangeChannelOnEdit { get; set; }

        [JsonProperty("search_type_dvbt")]
        public int SearchTypeDvbt { get; set; }

        [JsonProperty("show_tivusat_channel_list")]
        public int ShowTivusatChannelList { get; set; }

        [JsonProperty("need_show_tivusat_channel_change")]
        public int NeedShowTivusatChannelChange { get; set; }

        [JsonProperty("search_in_standby_mode")]
        public int SearchInStandbyMode { get; set; }

        [JsonProperty("search_in_operate_mode")]
        public int SearchInOperateMode { get; set; }

        [JsonProperty("uiDispResolution")]
        public int UiDispResolution { get; set; }

        [JsonProperty("auto_ota_in_standby_mode")]
        public int AutoOtaInStandbyMode { get; set; }

        [JsonProperty("auto_ota_in_operate_mode")]
        public int AutoOtaInOperateMode { get; set; }

        [JsonProperty("sw_update_by_ota")]
        public int SwUpdateByOta { get; set; }

        [JsonProperty("need_messge_remind_sw_update")]
        public int NeedMessgeRemindSwUpdate { get; set; }

        [JsonProperty("vod_enable")]
        public int VodEnable { get; set; }

        [JsonProperty("cPassWord")]
        public string? CPassWord { get; set; }

        [JsonProperty("ucPassCtrlInfo")]
        public int UcPassCtrlInfo { get; set; }

        [JsonProperty("ucAgeRating")]
        public int UcAgeRating { get; set; }

        [JsonProperty("cTimeZone")]
        public int CTimeZone { get; set; }

        [JsonProperty("ucChannelState")]
        public int UcChannelState { get; set; }

        [JsonProperty("ucFavouriteType")]
        public int UcFavouriteType { get; set; }

        [JsonProperty("ucLanguage")]
        public int UcLanguage { get; set; }

        [JsonProperty("ucAudioLanguage")]
        public int UcAudioLanguage { get; set; }

        [JsonProperty("ucAudioLan2")]
        public int UcAudioLan2 { get; set; }

        [JsonProperty("ucSubLanguage")]
        public int UcSubLanguage { get; set; }

        [JsonProperty("ucCurEPGLanuage")]
        public int UcCurEPGLanuage { get; set; }

        [JsonProperty("ucTPFlag")]
        public int UcTPFlag { get; set; }

        [JsonProperty("ucCurSat")]
        public int UcCurSat { get; set; }

        [JsonProperty("ucFavListTVMask_no_used")]
        public int UcFavListTVMask_no_used { get; set; }

        [JsonProperty("ucFavListRadioMask_no_used")]
        public int UcFavListRadioMask_no_used { get; set; }

        [JsonProperty("aucFavReName")]
        public List<string> AucFavReName { get; set; }

        [JsonProperty("ucFavNameChangeMask")]
        public int UcFavNameChangeMask { get; set; }

        [JsonProperty("uiNDSBoxKey")]
        public int UiNDSBoxKey { get; set; }

        [JsonProperty("dLongitudeAngle")]
        public int DLongitudeAngle { get; set; }

        [JsonProperty("dLatitudeAngle")]
        public int DLatitudeAngle { get; set; }

        [JsonProperty("iRotating_speedMotor1")]
        public int IRotating_speedMotor1 { get; set; }

        [JsonProperty("uiGShareServerPort")]
        public int UiGShareServerPort { get; set; }

        [JsonProperty("aucSatIndex")]
        public string? AucSatIndex { get; set; }

        [JsonProperty("ucSharpNess")]
        public int UcSharpNess { get; set; }

        [JsonProperty("ucContrast")]
        public int UcContrast { get; set; }

        [JsonProperty("ucSaturation")]
        public int UcSaturation { get; set; }

        [JsonProperty("ucBrightness")]
        public int UcBrightness { get; set; }

        [JsonProperty("ucCASSelect")]
        public int UcCASSelect { get; set; }

        [JsonProperty("ucUartMode")]
        public int UcUartMode { get; set; }

        [JsonProperty("ucModulatorNo")]
        public int UcModulatorNo { get; set; }

        [JsonProperty("ucRFAudio")]
        public int UcRFAudio { get; set; }

        [JsonProperty("ucEPGStyle")]
        public int UcEPGStyle { get; set; }

        [JsonProperty("sTPFreq")]
        public int STPFreq { get; set; }

        [JsonProperty("sTPSymbol")]
        public int STPSymbol { get; set; }

        [JsonProperty("usInternalPort")]
        public int UsInternalPort { get; set; }

        [JsonProperty("gstManualTime")]
        public ManualTime? GstManualTime { get; set; }

        [JsonProperty("stUSBSetting")]
        public USBSetting? StUSBSetting { get; set; }

        [JsonProperty("stIPConfig")]
        public IPConfig? StIPConfig { get; set; }

        [JsonProperty("stWifiIPConfig")]
        public IPConfig? StWifiIPConfig { get; set; }

        [JsonProperty("ucSNChecked")]
        public int UcSNChecked { get; set; }

        [JsonProperty("uiSdsSat")]
        public int UiSdsSat { get; set; }

        [JsonProperty("ucSNStatus")]
        public int UcSNStatus { get; set; }

        [JsonProperty("ucCountry")]
        public int UcCountry { get; set; }

        [JsonProperty("weather_bar_enable")]
        public int WeatherBarEnable { get; set; }

        [JsonProperty("uiAPDStandBy")]
        public int UiAPDStandBy { get; set; }

        [JsonProperty("uiSDSMode")]
        public int UiSDSMode { get; set; }

        [JsonProperty("uiFPLightLevel")]
        public int UiFPLightLevel { get; set; }

        [JsonProperty("cur_channel_list_id")]
        public int CurChannelListId { get; set; }

        [JsonProperty("ucLCNOn")]
        public int UcLCNOn { get; set; }

        [JsonProperty("global_nit_tp_freq")]
        public int GlobalNitTpFreq { get; set; }

        [JsonProperty("cec_config")]
        public CECConfig? CecConfig { get; set; }

        [JsonProperty("ms_tp")]
        public int MsTp { get; set; }

        [JsonProperty("ms_tp_isid")]
        public int MsTpIsid { get; set; }

        [JsonProperty("tsn_tp")]
        public int TsnTp { get; set; }

        [JsonProperty("tsn_tp_id")]
        public int TsnTpId { get; set; }

        public BoxObject()
        {
            AucFavReName = new List<string>();
        }
    }
}

