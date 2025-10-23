# SDX File Implementation Guide

## Purpose
This guide provides critical information for building models, parsing, manipulating, and writing SDX files. Use this alongside `README_SDX_STRUCTURE.md` for complete implementation.

## 🔄 VALIDATION UPDATE

This guide has been **validated and corrected** based on actual SDX file analysis. Key corrections:

### Structure Corrections:
1. **watching_prog_object** - Uses ServiceID-based reference, not array indices
2. **Transponder usStartCode** - Confirmed as 43690 (not 21845)
3. **Favorite list uiMark** - Magic constant 1414812756 required
4. **Program objects** - Include DVB-T2 fields and complete subtitle structure

### New Requirements Documented:
- Transponder `ext_data` object (optional, for multistream)
- Transponder `NetName` array (optional)
- Complete `SubtArray` structure with 5 properties
- DVB-T2 multistream fields in all program objects
- Additional favorite list fields

**All code examples have been updated to reflect actual file structure.**

---

## ⚠️ Critical Information for Read/Write Operations

### 1. File Integrity and Metadata Management

#### Database Header Object - MUST BE UPDATED
When modifying the SDX file, these fields in `database_header_object` **MUST** be recalculated and updated:

```json
{
  "database_header_object": {
    "sSatellite": 62,           // ⚠️ UPDATE: Total count of satellite objects
    "sTransponder": 1493,       // ⚠️ UPDATE: Total count of transponder objects
    "sTVNumber": 5781,          // ⚠️ UPDATE: Total count of TV program objects
    "sRadioNumber": 219,        // ⚠️ UPDATE: Total count of radio program objects
    "sMaxFavor": 26,            // ⚠️ UPDATE: Total count of favorite lists
    "uiOriginalSize": 4012708,  // ⚠️ UPDATE: File size in bytes
    "uiFileLength": 4012708,    // ⚠️ UPDATE: File size in bytes (same as uiOriginalSize)
    "uiCRC32": 0,               // ⚠️ Currently 0 (may not be validated by receiver)
    "sDataBaseVer": 100,        // Database version (keep at 100)
    "szMark": "CDX",            // File marker (keep as "CDX")
    "szDatabaseName": "MSTDatabaseV1.00.sdx"  // Database name
  }
}
```

**Action Required:**
- After any add/delete/reorder operation, recalculate counts
- Update file size fields before saving
- CRC32 field appears unused (set to 0) but may be calculated in future versions

### 2. Object Naming and Indexing Rules

#### Object Naming Convention - MUST FOLLOW
When creating or reordering objects, maintain this naming pattern:

**Pattern:** `{type}_object_{index}`

**Examples:**
- `satellite_object_0`, `satellite_object_1`, ..., `satellite_object_N`
- `transponder_object_0`, `transponder_object_1`, ..., `transponder_object_N`
- `program_tv_object_0`, `program_tv_object_1`, ..., `program_tv_object_N`
- `program_radio_object_0`, `program_radio_object_1`, ..., `program_radio_object_N`
- `fav_list_object_0`, `fav_list_object_1`, ..., `fav_list_object_N`

**Singleton Objects (No Index):**
- `box_object`
- `database_header_object`
- `global_variable_object`
- `fav_list_info_in_box_object`
- `watching_prog_object`

**Critical Rules:**
1. **Zero-based indexing:** First object is `_0`, not `_1`
2. **Sequential numbering:** No gaps allowed (0, 1, 2, 3, ...)
3. **Must renumber after deletion:** If you delete `program_tv_object_100`, renumber all subsequent objects
4. **Order matters:** The object name index should match its position in the file

### 3. Reference Integrity - MUST MAINTAIN

When reordering or deleting channels, update these references:

#### A. Transponder → Satellite References
```json
{
  "transponder_object_N": {
    "stFlag": {
      "SatIndex": 5  // ⚠️ References satellite_object_5
    }
  }
}
```
**Action:** If satellites are reordered/deleted, update all `SatIndex` references in transponders

#### B. Favorite Lists → Program References
```json
{
  "fav_list_object_0": {
    "stProgNo": [],  // ⚠️ ASSUMED: Array of program unknown objects
    "sNoOfTVFavor": 4,            // ⚠️ Count of TV channels in list
    "sNoOfRadioFavor": 0          // ⚠️ Count of radio channels in list
  }
}
```
**⚠️ NOTE:** The exact structure of `stProgNo` array items is **unverified**. It may contain:
- Integer indices (as shown above - most likely)
- ServiceID strings
- Objects similar to `program.stProgNo` structure
- Test with actual favorite lists to confirm!

**Action:** When reordering channels (if `stProgNo` contains indices):
1. Update all indices in `stProgNo` arrays across ALL favorite lists
2. Update `sNoOfTVFavor` and `sNoOfRadioFavor` counts if needed

#### C. Watching Program → Current Channel Reference
```json
{
  "watching_prog_object": {
    "stProgNo": {
      "uiWord32": 3672234,         // ⚠️ Encoded program number (32-bit)
      "unShort": {
        "sLo16": 2218,             // ⚠️ Low 16 bits (ServiceID low)
        "sHi16": 56                // ⚠️ High 16 bits (ServiceID high)
      }
    },
    "usTransportStreamID": 0,      // Transport Stream ID
    "usOriginalNetworkID": 0,      // Original Network ID
    "usFavSelect": [0, 0, ...]     // ⚠️ Array of 26 integers (current fav selection per list)
  }
}
```
**Action:** Update stProgNo when the current channel is reordered (match with program's ServiceID)

#### D. Satellite → Last Played Channel References
```json
{
  "satellite_object_0": {
    "sSaveCurSatPlayTVIndex": 925,     // ⚠️ Last TV channel for this satellite
    "sSaveCurSatPlayRadioIndex": 19964 // ⚠️ Last radio channel for this satellite
  }
}
```
**Action:** Update if last-played channels are reordered

#### E. Program → Favorite Bit Flags
```json
{
  "program_tv_object_0": {
    "FavBit": 5  // ⚠️ Bitfield indicating favorite list membership
                 // Bit 0 = in fav_list_0, Bit 1 = in fav_list_1, etc.
  }
}
```
**Action:** Update `FavBit` when adding/removing channels from favorites

### 4. File Writing Format Requirements

#### JSON Serialization Rules
```
Format: Single-line, no formatting, adjacent objects
Encoding: UTF-8
Line breaks: NONE (entire file is one line)
Indentation: NONE
Separators: NONE between objects
Whitespace: NONE between objects
```

**Correct Format:**
```
{"satellite_object_0":{...}}{"satellite_object_1":{...}}{"transponder_object_0":{...}}
```

**WRONG Formats (Do NOT use):**
```
// ❌ With line breaks
{"satellite_object_0":{...}}
{"satellite_object_1":{...}}

// ❌ With array wrapper
[{"satellite_object_0":{...}},{"satellite_object_1":{...}}]

// ❌ With whitespace
{"satellite_object_0":{...}} {"satellite_object_1":{...}}

// ❌ With commas
{"satellite_object_0":{...}},{"satellite_object_1":{...}}
```

#### Serialization Code Pattern (C#)
```csharp
// Correct way to write SDX file
using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
{
    foreach (var obj in allObjects)
    {
        // No indentation, no whitespace
        string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions 
        { 
            WriteIndented = false 
        });
        writer.Write(json);  // Use Write, not WriteLine!
    }
}
```

### 5. Object Ordering Sequence - MUST FOLLOW (VERIFIED)

Write objects in this exact order:

```
1. satellite_object_0 to satellite_object_N
2. transponder_object_0 to transponder_object_N
3. program_tv_object_0 to program_tv_object_N
4. program_radio_object_0 to program_radio_object_N
5. box_object
6. watching_prog_object
7. fav_list_object_0 to fav_list_object_N
8. fav_list_info_in_box_object
9. database_header_object
10. global_variable_object
```

**⚠️ IMPORTANT:** This order was verified by analyzing byte positions in actual files. Previous documentation had incorrect ordering!

**Verified positions in reference file:**
- Position 4,009,981: box_object
- Position 4,014,220: watching_prog_object
- Position 4,014,430: fav_list_object_0
- Position 4,018,034: fav_list_info_in_box_object
- Position 4,018,490: database_header_object
- Position 4,018,841: global_variable_object

### 6. Data Validation Rules

#### Maximum Limits (from global_variable_object)
```json
{
  "max_no_of_programs": 20000,      // Max TV + Radio programs
  "max_no_of_transponders": 8000,   // Max transponders
  "max_no_of_satellites": 200,      // Max satellites
  "max_service_name_length": 27,    // Max channel name length
  "max_audio_pid": 32,              // Max audio tracks per channel
  "max_subtitle_pid": 10            // Max subtitle tracks per channel
}
```

**Validation Required:**
- Total programs (TV + Radio) ≤ 20,000
- Total transponders ≤ 8,000
- Total satellites ≤ 200
- Channel names ≤ 27 characters
- Audio tracks per channel ≤ 32
- Subtitle tracks per channel ≤ 10

#### Required Fields for Program Objects
Every `program_tv_object` and `program_radio_object` MUST have:
- `uiStartCode`: 21845 (magic number - always this value)
- `ServiceName`: String (channel name)
- `VideoPID`, `PCRPID`, `PMTPID`: Valid PID values
- `TTXPID`: Teletext PID (typically 8191 if not present)
- `stProgNo`: Object with ServiceID and unShort structure
- `uiSet.uiBit`: Object with channel flags
- `uiSet.uiStatus`: Encoded status value
- `AudioArray`: Array (can be empty but must exist)
- `SubtArray`: Array (can be empty but must exist)
- `FavBit`: Integer (favorite list membership bitfield)
- `TSID`, `ONID`, `SDTServiceType`: DVB metadata fields
- `t2mi_pg`, `t2mi_plp_id`, `t2mi_payload_pid`: DVB-T2 multistream fields
- `AudioSelected`, `SubtSelected`: Currently selected track indices
- `ucNameLen`, `ucAudioPID`, `ucSubPID`: Counts of name length and tracks

### 7. Channel Reordering Implementation Guide

When reordering TV channels (e.g., moving channel from position A to position B):

#### Step 1: Reorder the Objects
```csharp
// Move channel from oldIndex to newIndex
var channel = programTvObjects[oldIndex];
programTvObjects.RemoveAt(oldIndex);
programTvObjects.Insert(newIndex, channel);
```

#### Step 2: Renumber Object Names
```csharp
for (int i = 0; i < programTvObjects.Count; i++)
{
    // Update the root key name
    var oldKey = programTvObjects[i].Keys.First();
    var channelData = programTvObjects[i][oldKey];
    
    programTvObjects[i] = new Dictionary<string, object>
    {
        { $"program_tv_object_{i}", channelData }
    };
}
```

#### Step 3: Update Favorite List Indices
```csharp
foreach (var favList in favListObjects)
{
    var progNoArray = favList["stProgNo"] as List<int>;
    
    for (int i = 0; i < progNoArray.Count; i++)
    {
        if (progNoArray[i] == oldIndex)
        {
            progNoArray[i] = newIndex;
        }
        else if (oldIndex < newIndex)
        {
            // Shifted down
            if (progNoArray[i] > oldIndex && progNoArray[i] <= newIndex)
            {
                progNoArray[i]--;
            }
        }
        else
        {
            // Shifted up
            if (progNoArray[i] >= newIndex && progNoArray[i] < oldIndex)
            {
                progNoArray[i]++;
            }
        }
    }
}
```

#### Step 4: Update Current Channel Reference
```csharp
// Update watching_prog_object if the current channel's ServiceID matches
// Note: watching_prog_object uses ServiceID, not array index
// Only update if you're changing the channel's ServiceID itself
// Typically, reordering doesn't require updating watching_prog_object
// since it references by ServiceID, not by position
var currentServiceID = GetServiceIDFromProgNo(watchingProgObject["stProgNo"]);
// Compare with moved channel's ServiceID - update only if ServiceID changes
```

#### Step 5: Update Satellite Last-Played Indices
```csharp
foreach (var satellite in satelliteObjects)
{
    if (satellite["sSaveCurSatPlayTVIndex"] == oldIndex)
    {
        satellite["sSaveCurSatPlayTVIndex"] = newIndex;
    }
    // Handle shifts...
}
```

#### Step 6: Update Database Header
```csharp
// Counts don't change for reordering, but update if adding/deleting
databaseHeader["sTVNumber"] = programTvObjects.Count;
databaseHeader["sRadioNumber"] = programRadioObjects.Count;
```

#### Step 7: Write File
```csharp
// Calculate file size
string allContent = GenerateSDXContent();
databaseHeader["uiFileLength"] = allContent.Length;
databaseHeader["uiOriginalSize"] = allContent.Length;

// Write to file
File.WriteAllText(filePath, allContent, Encoding.UTF8);
```

### 8. Data Type Preservation

When parsing and re-serializing, preserve exact data types:

```csharp
// Integers must stay integers
"VideoPID": 2310          // NOT "2310" (string)

// Booleans in global_variable_object
"enable_max_fav_26": true // NOT 1 or "true"

// Strings
"ServiceName": "Al-Majd3" // Keep exact casing and characters

// Arrays must exist even if empty
"AudioArray": []          // NOT null
"SubtArray": []           // NOT null

// Nested objects must be preserved
"uiSet": {                // NOT flattened
  "uiBit": { ... }
}
```

### 9. Character Encoding and Special Characters

- **File Encoding:** UTF-8 without BOM
- **String Handling:** Preserve all Unicode characters in channel names
- **JSON Escaping:** Standard JSON escaping rules apply (`"`, `\`, control characters)
- **Special Characters:** 
  - Channel names may contain Arabic, Cyrillic, Latin characters
  - Preserve exact spacing and punctuation
  - Some names may have trailing null characters (`\u001f`) - preserve them

### 10. Testing and Validation Checklist

Before saving an SDX file, validate:

```
✓ All object names follow naming convention
✓ Indices are sequential with no gaps (0, 1, 2, 3...)
✓ database_header_object counts match actual object counts
✓ uiFileLength matches actual file size
✓ All favorite list indices point to valid channels
✓ watching_prog_object indices are valid
✓ Satellite last-played indices are valid
✓ All transponder SatIndex values reference valid satellites
✓ File is single-line with no whitespace between objects
✓ File uses UTF-8 encoding
✓ All required fields are present
✓ No objects exceed maximum limits
✓ FavBit flags match favorite list membership
```

### 11. Common Pitfalls and How to Avoid Them

#### ❌ Pitfall 1: Forgetting to Update Indices
**Problem:** Moving channel but not updating favorite lists  
**Solution:** Update ALL references (see Step 3 above)

#### ❌ Pitfall 2: Writing Formatted JSON
**Problem:** Using pretty-printed JSON with indentation  
**Solution:** Use `WriteIndented = false` and write to single line

#### ❌ Pitfall 3: Wrong Object Order
**Problem:** Writing objects in wrong sequence  
**Solution:** Follow exact order in Section 5

#### ❌ Pitfall 4: Gaps in Indices
**Problem:** After deletion, having `program_tv_object_0`, `program_tv_object_1`, `program_tv_object_3` (missing 2)  
**Solution:** Renumber all objects after deletion

#### ❌ Pitfall 5: Type Conversion Errors
**Problem:** Converting integers to strings during serialization  
**Solution:** Use strongly-typed models to preserve types

#### ❌ Pitfall 6: Not Updating File Size
**Problem:** Keeping old file size in database header  
**Solution:** Calculate and update before writing (see Step 7)

#### ❌ Pitfall 7: Incorrect UTF-8 Encoding
**Problem:** Using wrong encoding or adding BOM  
**Solution:** Explicitly specify `Encoding.UTF8` without BOM

### 12. Model Design Recommendations

#### Suggested Class Structure
```csharp
// Base interface
public interface ISdxObject
{
    string GetObjectKey();
    void UpdateObjectKey(int index);
}

// Container class
public class SdxDatabase
{
    public List<SatelliteObject> Satellites { get; set; }
    public List<TransponderObject> Transponders { get; set; }
    public List<ProgramTvObject> TvPrograms { get; set; }
    public List<ProgramRadioObject> RadioPrograms { get; set; }
    public List<FavListObject> FavoriteLists { get; set; }
    public BoxObject Box { get; set; }
    public DatabaseHeaderObject DatabaseHeader { get; set; }
    public GlobalVariableObject GlobalVariable { get; set; }
    public FavListInfoInBoxObject FavListInfo { get; set; }
    public WatchingProgObject WatchingProg { get; set; }
    
    // Methods
    public void ReorderChannel(int oldIndex, int newIndex) { }
    public void DeleteChannel(int index) { }
    public void UpdateAllReferences() { }
    public void ValidateIntegrity() { }
    public string SerializeToSdx() { }
}
```

#### Key Methods to Implement
1. `ParseFromSdxFile(string filePath)` - Load and parse
2. `SerializeToSdx()` - Generate single-line JSON string
3. `UpdateAllReferences()` - Fix all index references
4. `RenumberObjects()` - Renumber after add/delete
5. `ValidateIntegrity()` - Check all constraints
6. `CalculateFileMetadata()` - Update database header

---

## Summary

To successfully work with SDX files:

1. ✅ **Parse correctly:** Track brace depth, handle adjacent objects
2. ✅ **Maintain references:** Update ALL index references when reordering
3. ✅ **Preserve types:** Keep exact data types during serialization
4. ✅ **Follow order:** Write objects in correct sequence
5. ✅ **Update metadata:** Recalculate counts and file size
6. ✅ **Validate limits:** Check against maximum values
7. ✅ **Write correctly:** Single line, no whitespace, UTF-8
8. ✅ **Test thoroughly:** Validate integrity before saving

The SDX format is **strict but logical**. Follow these rules carefully and your implementation will work correctly with the receiver hardware.

