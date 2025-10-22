using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SdxChannelSorter.Models
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
        
        public ObservableCollection<SdxChannel> GetTvChannels()
        {
            var tvChannels = new ObservableCollection<SdxChannel>();
            foreach (var channel in Channels)
            {
                if (!channel.IsRadio)
                {
                    tvChannels.Add(channel);
                }
            }
            return tvChannels;
        }
        
        public ObservableCollection<SdxChannel> GetRadioChannels()
        {
            var radioChannels = new ObservableCollection<SdxChannel>();
            foreach (var channel in Channels)
            {
                if (channel.IsRadio)
                {
                    radioChannels.Add(channel);
                }
            }
            return radioChannels;
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
                
                // Separate TV and Radio channels
                var tvChannels = Channels.Where(c => !c.IsRadio).ToList();
                var radioChannels = Channels.Where(c => c.IsRadio).ToList();
                
                // Write Satellite objects with sequential indices starting from 0
                for (int i = 0; i < SatelliteObjects.Count; i++)
                {
                    string newKey = "satellite_object_" + i;
                    var satelliteJson = JObject.FromObject(SatelliteObjects[i]);
                    
                    var updatedObj = new JObject
                    {
                        [newKey] = satelliteJson
                    };
                    
                    sb.Append(updatedObj.ToString(Formatting.None));
                }
                
                // Write Transponder objects with sequential indices starting from 0
                for (int i = 0; i < TransponderObjects.Count; i++)
                {
                    string newKey = "transponder_object_" + i;
                    var transponderJson = JObject.FromObject(TransponderObjects[i]);
                    
                    var updatedObj = new JObject
                    {
                        [newKey] = transponderJson
                    };
                    
                    sb.Append(updatedObj.ToString(Formatting.None));
                }
                
                // Write TV channels with sequential indices starting from 0
                for (int i = 0; i < tvChannels.Count; i++)
                {
                    var channel = tvChannels[i];
                    string newKey = "program_tv_object_" + i;
                    
                    // Update the RawData with the new key and any modified data from ChannelData
                    var channelDataJson = JObject.FromObject(channel.ChannelData);
                    
                    var updatedObj = new JObject
                    {
                        [newKey] = channelDataJson
                    };
                    
                    sb.Append(updatedObj.ToString(Formatting.None));
                }
                
                // Write Radio channels with sequential indices starting from 0
                for (int i = 0; i < radioChannels.Count; i++)
                {
                    var channel = radioChannels[i];
                    string newKey = "program_radio_object_" + i;
                    
                    // Update the RawData with the new key and any modified data from ChannelData
                    var channelDataJson = JObject.FromObject(channel.ChannelData);
                    
                    var updatedObj = new JObject
                    {
                        [newKey] = channelDataJson
                    };
                    
                    sb.Append(updatedObj.ToString(Formatting.None));
                }
                
                // Write box_object
                if (BoxObject != null)
                {
                    var boxObj = new JObject
                    {
                        ["box_object"] = JObject.FromObject(BoxObject)
                    };
                    sb.Append(boxObj.ToString(Formatting.None));
                }
                
                // Write watching_prog_object
                if (WatchingProgObject != null)
                {
                    var watchObj = new JObject
                    {
                        ["watching_prog_object"] = JObject.FromObject(WatchingProgObject)
                    };
                    sb.Append(watchObj.ToString(Formatting.None));
                }
                
                // Write fav_list_objects (0-25)
                for (int i = 0; i < FavListObjects.Count && i < 26; i++)
                {
                    var favObj = new JObject
                    {
                        [$"fav_list_object_{i}"] = JObject.FromObject(FavListObjects[i])
                    };
                    sb.Append(favObj.ToString(Formatting.None));
                }
                
                // Write fav_list_info_in_box_object
                if (FavListInfoInBoxObject != null)
                {
                    var favInfoObj = new JObject
                    {
                        ["fav_list_info_in_box_object"] = JObject.FromObject(FavListInfoInBoxObject)
                    };
                    sb.Append(favInfoObj.ToString(Formatting.None));
                }
                
                // Write database_header_object
                if (DatabaseHeaderObject != null)
                {
                    // Update counts before saving
                    DatabaseHeaderObject.STVNumber = tvChannels.Count;
                    DatabaseHeaderObject.SRadioNumber = radioChannels.Count;
                    DatabaseHeaderObject.SSatellite = SatelliteObjects.Count;
                    DatabaseHeaderObject.STransponder = TransponderObjects.Count;
                    
                    var headerObj = new JObject
                    {
                        ["database_header_object"] = JObject.FromObject(DatabaseHeaderObject)
                    };
                    sb.Append(headerObj.ToString(Formatting.None));
                }
                
                // Write global_variable_object
                if (GlobalVariableObject != null)
                {
                    var globalObj = new JObject
                    {
                        ["global_variable_object"] = JObject.FromObject(GlobalVariableObject)
                    };
                    sb.Append(globalObj.ToString(Formatting.None));
                }
                
                // Write to file
                File.WriteAllText(targetPath, sb.ToString(), Encoding.UTF8);
                
                // Update FilePath if we saved to a new location
                FilePath = targetPath;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving SDX file: {ex.Message}", ex);
            }
        }
        
        private static List<JObject> ParseConcatenatedJson(string content)
        {
            var objects = new List<JObject>();
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
                            var obj = JObject.Parse(jsonStr);
                            objects.Add(obj);
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
        
        private static void ParseObject(JObject obj, SdxDatabase database)
        {
            // Get the first property name which contains the object type and index
            var firstProperty = obj.Properties().FirstOrDefault();
            if (firstProperty == null) return;
            
            string key = firstProperty.Name;
            var value = firstProperty.Value as JObject;
            if (value == null) return;
            
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
                        string serviceName = value["ServiceName"]?.ToString() ?? "Unknown";
                        
                        // Parse the channel data with all properties
                        var channelData = value.ToObject<ProgramChannelData>() ?? new ProgramChannelData();
                        
                        var channel = new SdxChannel
                        {
                            ObjectKey = key,
                            Index = index,
                            IsRadio = isRadio,
                            ServiceName = serviceName,
                            RawData = obj,
                            ChannelData = channelData
                        };
                        
                        database.Channels.Add(channel);
                    }
                }
                else if (key.StartsWith("satellite_object_"))
                {
                    var satellite = value.ToObject<SatelliteObject>();
                    if (satellite != null) database.SatelliteObjects.Add(satellite);
                }
                else if (key.StartsWith("transponder_object_"))
                {
                    var transponder = value.ToObject<TransponderObject>();
                    if (transponder != null) database.TransponderObjects.Add(transponder);
                }
                else if (key == "box_object")
                {
                    var boxObj = value.ToObject<BoxObject>();
                    if (boxObj != null) database.BoxObject = boxObj;
                }
                else if (key == "watching_prog_object")
                {
                    var watchObj = value.ToObject<WatchingProgObject>();
                    if (watchObj != null) database.WatchingProgObject = watchObj;
                }
                else if (key.StartsWith("fav_list_object_"))
                {
                    var favList = value.ToObject<FavListObject>();
                    if (favList != null) database.FavListObjects.Add(favList);
                }
                else if (key == "fav_list_info_in_box_object")
                {
                    var favInfoObj = value.ToObject<FavListInfoInBoxObject>();
                    if (favInfoObj != null) database.FavListInfoInBoxObject = favInfoObj;
                }
                else if (key == "database_header_object")
                {
                    var headerObj = value.ToObject<DatabaseHeaderObject>();
                    if (headerObj != null) database.DatabaseHeaderObject = headerObj;
                }
                else if (key == "global_variable_object")
                {
                    var globalObj = value.ToObject<GlobalVariableObject>();
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

