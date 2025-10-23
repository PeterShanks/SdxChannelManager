using System.Text.Json;

namespace SdxChannelManager.Models
{
    public class SdxChannel
    {
        public string ObjectKey { get; set; } // e.g., "program_tv_object_0"
        public int Index { get; set; } // The numeric part of the key
        public bool IsRadio { get; set; }
        public string ServiceName { get; set; }
        public JsonElement RawData { get; set; } // Store the complete JSON object
        
        // Typed channel data - use this for proper access to all properties
        public ProgramChannelData ChannelData { get; set; }
        
        // Display properties
        public string Type => IsRadio ? "Radio" : "TV";
        
        // Constructor
        public SdxChannel()
        {
            ServiceName = string.Empty;
            ObjectKey = string.Empty;
            RawData = JsonDocument.Parse("{}").RootElement.Clone();
            ChannelData = new ProgramChannelData();
        }
        
        public override string ToString()
        {
            return $"{Index}: {ServiceName} ({Type})";
        }
    }
}

