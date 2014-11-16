using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDetails
/// </summary>
public class UserDetails
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("bio")]
    public string Bio { get; set; }

    [JsonProperty("follower_count")]
    public int? FollowerCount { get; set; }

    [JsonProperty("angellist_url")]
    public string AngellistUrl { get; set; }

    [JsonProperty("blog_url")]
    public string BlogUrl { get; set; }

    [JsonProperty("online_bio_url")]
    public string OnlineBioUrl { get; set; }

    [JsonProperty("twitter_url")]
    public string TwitterUrl { get; set; }

    [JsonProperty("facebook_url")]
    public string FacebookUrl { get; set; }

    [JsonProperty("linkedin_url")]
    public string LinkedinUrl { get; set; }

    [JsonProperty("aboutme_url")]
    public string AboutmeUrl { get; set; }

    [JsonProperty("github_url")]
    public string GithubUrl { get; set; }

    [JsonProperty("dribbble_url")]
    public string DribbbleUrl { get; set; }

    [JsonProperty("behance_url")]
    public string BehanceUrl { get; set; }

    [JsonProperty("resume_url")]
    public string ResumeUrl { get; set; }

    [JsonProperty("what_ive_built")]
    public string WhatIveBuilt { get; set; }

    [JsonProperty("what_i_do")]
    public string WhatIDo { get; set; }

    [JsonProperty("criteria")]
    public string Criteria { get; set; }

    private string _pic;

    [JsonProperty("pic")]
    public string pic { 
        get { if (_pic == null) return "https://angel.co/images/shared/nopic.png"; else return _pic; } 
        set { _pic = value; } 
    }

    [JsonProperty("skills")]
    public List<UserSkills> Skills { get; set; }

    [JsonProperty("roles")]
    public List<UserSkills> Roles { get; set; }

    [JsonProperty("locations")]
    public List<UserSkills> Locations { get; set; }


    private String investor;
    [JsonProperty("investor")]
    public String Investor {
        get { if (investor == "True") return "Yes"; else return "No"; }
        set { investor = value; }
    }

}