using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SdxChannelManager.Models
{
    public class SdxDatabase
    {
        public ObservableCollection<SdxChannel> Channels { get; set; }
        public string FilePath { get; set; }
        
        // Strongly-typed objects - ALL SDX structures
        public List<SatelliteObject> SatelliteObjects { get; set; }
        public List<TransponderObject> TransponderObjects { get; set; }
        public BoxObject? BoxObject { get; set; }
        public WatchingProgObject? WatchingProgObject { get; set; }
        public List<FavListObject> FavListObjects { get; set; }
        public FavListInfoInBoxObject? FavListInfoInBoxObject { get; set; }
        public DatabaseHeaderObject? DatabaseHeaderObject { get; set; }
        public GlobalVariableObject? GlobalVariableObject { get; set; }
        
        public SdxDatabase()
        {
            Channels = new ObservableCollection<SdxChannel>();
            SatelliteObjects = new List<SatelliteObject>();
            TransponderObjects = new List<TransponderObject>();
            FavListObjects = new List<FavListObject>();
            FilePath = string.Empty;
        }
        
        /// <summary>
        /// Loads an SDX database file from disk
        /// </summary>
        public static SdxDatabase Load(string filePath)
        {
            var database = new SdxDatabase { FilePath = filePath };
            
            try
            {
                // Read the entire file content
                string content = File.ReadAllText(filePath, Encoding.UTF8);
                
                // Parse concatenated JSON objects
                var objects = ParseConcatenatedJson(content);
                
                foreach (var obj in objects)
                {
                    ParseObject(obj, database);
                }
                
                // Sort channels by index
                var sortedChannels = database.Channels.OrderBy(c => c.Index).ToList();
                database.Channels.Clear();
                foreach (var channel in sortedChannels)
                {
                    database.Channels.Add(channel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading SDX file: {ex.Message}", ex);
            }
            
            return database;
        }
        
        /// <summary>
        /// Saves this database to disk
        /// </summary>
        public void Save(string? filePath = null)
        {
            // Use provided path or default to the original FilePath
            string targetPath = filePath ?? FilePath;
            
            if (string.IsNullOrEmpty(targetPath))
            {
                throw new ArgumentException("File path must be specified");
            }
            
            try
            {
                var sb = new StringBuilder();
                
                // Configure JSON serializer to match original file format exactly
                var jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = false,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                
                // Separate TV and Radio channels
                var tvChannels = Channels.Where(c => !c.IsRadio).ToList();
                var radioChannels = Channels.Where(c => c.IsRadio).ToList();
                
                // Write Satellite objects with sequential indices starting from 0
                for (int i = 0; i < SatelliteObjects.Count; i++)
                {
                    string newKey = "satellite_object_" + i;
                    var satelliteJson = JsonSerializer.Serialize(SatelliteObjects[i], jsonOptions);
                    
                    sb.Append($"{{\"{newKey}\":{satelliteJson}}}");
                }
                
                // Write Transponder objects with sequential indices starting from 0
                for (int i = 0; i < TransponderObjects.Count; i++)
                {
                    string newKey = "transponder_object_" + i;
                    var transponderJson = JsonSerializer.Serialize(TransponderObjects[i], jsonOptions);
                    
                    sb.Append($"{{\"{newKey}\":{transponderJson}}}");
                }
                
                // Add comma after last transponder before TV programs (special case)
                if (TransponderObjects.Count > 0 && tvChannels.Count > 0)
                {
                    sb.Append(",");
                }
                
                // Write TV channels with sequential indices starting from 0
                // NOTE: TV program objects have commas between them (unlike satellites/transponders)
                for (int i = 0; i < tvChannels.Count; i++)
                {
                    var channel = tvChannels[i];
                    string newKey = "program_tv_object_" + i;
                    
                    // Update the RawData with the new key and any modified data from ChannelData
                    var channelDataJson = JsonSerializer.Serialize(channel.ChannelData, jsonOptions);
                    
                    sb.Append($"{{\"{newKey}\":{channelDataJson}}}");
                    
                    // Add comma after each TV program object (except the last one)
                    if (i < tvChannels.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                
                // Write Radio channels with sequential indices starting from 0
                // NOTE: Radio program objects do NOT have commas between them (same as satellites, transponders, fav lists)
                for (int i = 0; i < radioChannels.Count; i++)
                {
                    var channel = radioChannels[i];
                    string newKey = "program_radio_object_" + i;
                    
                    // Update the RawData with the new key and any modified data from ChannelData
                    var channelDataJson = JsonSerializer.Serialize(channel.ChannelData, jsonOptions);
                    
                    sb.Append($"{{\"{newKey}\":{channelDataJson}}}");
                    
                    // NO commas between radio program objects
                }
                
                // Write box_object (comes BEFORE favorite lists in this file format!)
                if (BoxObject != null)
                {
                    var boxJson = JsonSerializer.Serialize(BoxObject, jsonOptions);
                    sb.Append($"{{\"box_object\":{boxJson}}}");
                }
                
                // Write watching_prog_object (comes BEFORE favorite lists in this file format!)
                if (WatchingProgObject != null)
                {
                    var watchJson = JsonSerializer.Serialize(WatchingProgObject, jsonOptions);
                    sb.Append($"{{\"watching_prog_object\":{watchJson}}}");
                }
                
                // Write fav_list_objects (0-25)
                for (int i = 0; i < FavListObjects.Count && i < 26; i++)
                {
                    var favJson = JsonSerializer.Serialize(FavListObjects[i], jsonOptions);
                    sb.Append($"{{\"fav_list_object_{i}\":{favJson}}}");
                }
                
                // Write fav_list_info_in_box_object
                if (FavListInfoInBoxObject != null)
                {
                    var favInfoJson = JsonSerializer.Serialize(FavListInfoInBoxObject, jsonOptions);
                    sb.Append($"{{\"fav_list_info_in_box_object\":{favInfoJson}}}");
                }
                
                // Write database_header_object
                if (DatabaseHeaderObject != null)
                {
                    // Update counts before saving
                    DatabaseHeaderObject.STVNumber = tvChannels.Count;
                    DatabaseHeaderObject.SRadioNumber = radioChannels.Count;
                    DatabaseHeaderObject.SSatellite = SatelliteObjects.Count;
                    DatabaseHeaderObject.STransponder = TransponderObjects.Count;
                    
                    var headerJson = JsonSerializer.Serialize(DatabaseHeaderObject, jsonOptions);
                    sb.Append($"{{\"database_header_object\":{headerJson}}}");
                }
                
                // Write global_variable_object (MUST BE LAST!)
                if (GlobalVariableObject != null)
                {
                    var globalJson = JsonSerializer.Serialize(GlobalVariableObject, jsonOptions);
                    sb.Append($"{{\"global_variable_object\":{globalJson}}}");
                }
                
                // Write to file (UTF-8 WITHOUT BOM - critical for embedded systems!)
                var utf8WithoutBom = new UTF8Encoding(false); // false = no BOM
                
                // Fix Unicode escape sequences to lowercase (e.g., \u001F -> \u001f) to match original format
                var content = sb.ToString();
                content = System.Text.RegularExpressions.Regex.Replace(content, @"\\u([0-9A-F]{4})", 
                    m => $"\\u{m.Groups[1].Value.ToLower()}");
                
                File.WriteAllText(targetPath, content, utf8WithoutBom);
                
                // Update FilePath if we saved to a new location
                FilePath = targetPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving SDX file: {ex.Message}", ex);
            }
        }
        
        private static List<JsonElement> ParseConcatenatedJson(string content)
        {
            var objects = new List<JsonElement>();
            int depth = 0;
            int startIndex = -1;
            
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == '{')
                {
                    if (depth == 0)
                    {
                        startIndex = i;
                    }
                    depth++;
                }
                else if (content[i] == '}')
                {
                    depth--;
                    if (depth == 0 && startIndex != -1)
                    {
                        try
                        {
                            string jsonStr = content.Substring(startIndex, i - startIndex + 1);
                            var doc = JsonDocument.Parse(jsonStr);
                            objects.Add(doc.RootElement.Clone());
                        }
                        catch
                        {
                            // Skip invalid JSON
                        }
                        startIndex = -1;
                    }
                }
            }
            
            return objects;
        }
        
        private static void ParseObject(JsonElement obj, SdxDatabase database)
        {
            // Get the first property name which contains the object type and index
            if (obj.ValueKind != JsonValueKind.Object) return;
            
            var enumerator = obj.EnumerateObject();
            if (!enumerator.MoveNext()) return;
            
            var firstProperty = enumerator.Current;
            string key = firstProperty.Name;
            var value = firstProperty.Value;
            
            try
            {
                // Check if this is a TV or Radio channel object
                if (key.StartsWith("program_tv_object_") || key.StartsWith("program_radio_object_"))
                {
                    bool isRadio = key.StartsWith("program_radio_object_");
                    
                    // Extract the index from the key
                    var match = Regex.Match(key, @"(\d+)$");
                    if (match.Success && int.TryParse(match.Value, out int index))
                    {
                        // Extract service name
                        string serviceName = value.TryGetProperty("ServiceName", out var nameElement) 
                            ? nameElement.GetString() ?? "Unknown" 
                            : "Unknown";
                        
                        // Parse the channel data with all properties
                        var channelData = JsonSerializer.Deserialize<ProgramChannelData>(value.GetRawText()) ?? new ProgramChannelData();
                        
                        var channel = new SdxChannel
                        {
                            ObjectKey = key,
                            Index = index,
                            IsRadio = isRadio,
                            ServiceName = serviceName,
                            RawData = obj.Clone(),
                            ChannelData = channelData
                        };
                        
                        database.Channels.Add(channel);
                    }
                }
                else if (key.StartsWith("satellite_object_"))
                {
                    var satellite = JsonSerializer.Deserialize<SatelliteObject>(value.GetRawText());
                    if (satellite != null) database.SatelliteObjects.Add(satellite);
                }
                else if (key.StartsWith("transponder_object_"))
                {
                    var transponder = JsonSerializer.Deserialize<TransponderObject>(value.GetRawText());
                    if (transponder != null) database.TransponderObjects.Add(transponder);
                }
                else if (key == "box_object")
                {
                    var boxObj = JsonSerializer.Deserialize<BoxObject>(value.GetRawText());
                    if (boxObj != null) database.BoxObject = boxObj;
                }
                else if (key == "watching_prog_object")
                {
                    var watchObj = JsonSerializer.Deserialize<WatchingProgObject>(value.GetRawText());
                    if (watchObj != null) database.WatchingProgObject = watchObj;
                }
                else if (key.StartsWith("fav_list_object_"))
                {
                    var favList = JsonSerializer.Deserialize<FavListObject>(value.GetRawText());
                    if (favList != null) database.FavListObjects.Add(favList);
                }
                else if (key == "fav_list_info_in_box_object")
                {
                    var favInfoObj = JsonSerializer.Deserialize<FavListInfoInBoxObject>(value.GetRawText());
                    if (favInfoObj != null) database.FavListInfoInBoxObject = favInfoObj;
                }
                else if (key == "database_header_object")
                {
                    var headerObj = JsonSerializer.Deserialize<DatabaseHeaderObject>(value.GetRawText());
                    if (headerObj != null) database.DatabaseHeaderObject = headerObj;
                }
                else if (key == "global_variable_object")
                {
                    var globalObj = JsonSerializer.Deserialize<GlobalVariableObject>(value.GetRawText());
                    if (globalObj != null) database.GlobalVariableObject = globalObj;
                }
                else
                {
                    // Log unrecognized object type
                    Console.WriteLine($"Warning: Unrecognized object type: {key}");
                }
            }
            catch (Exception ex)
            {
                // Log parsing error
                Console.WriteLine($"Error parsing {key}: {ex.Message}");
            }
        }
    }
}

