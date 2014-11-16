using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class User
{
    private string _pic;
    [JsonProperty("pic")]
    public string pic { get { if (_pic == null) return "https://angel.co/images/shared/nopic.png"; else return _pic; } set { _pic = value; } }

    [JsonProperty("id")]
    public int id { get; set; }
        
    [JsonProperty("url")]
    public string url { get; set; }

    [JsonProperty("name")]
    public string name { get; set; }

    [JsonProperty("type")]
    public string type { get; set; }

    public List<UserDetails> UserDetails;

}



