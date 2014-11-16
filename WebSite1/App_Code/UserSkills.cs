using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserSkills
/// </summary>
public class UserSkills
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("tag_type")]
    public string TagType { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("angellist_url")]
    public string AngellistUrl { get; set; }

    [JsonProperty("level")]
    public Double? Level { get; set; }

    
}