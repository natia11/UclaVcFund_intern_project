using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;

public partial class _Default : Page
{
    private MySqlConnection conn;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Get user info from angellist search and user apis and save them to mySql db tables.
        SaveUserInfo();

        //get the saved user info from db and display it on a page
        UserdataList.DataSource = GetUserInfoFromDB();
        UserdataList.DataBind();
    }

    //on itemDataBound for each user, populate inner dataList with userDetails information
    protected void UserdataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataListItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
        {
            var innerList = (DataList)item.FindControl("UserDetails");
            innerList.DataSource = ((User)item.DataItem).UserDetails;
            innerList.DataBind();
        }
    }

    //populate nested datalists for skills, location and roles
    protected void UserDetails_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataListItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
        {
            var innerListLoc = (DataList)item.FindControl("UserDetailsLoc");
            innerListLoc.DataSource = ((UserDetails)item.DataItem).Locations;
            innerListLoc.DataBind();
           
            var innerListSkill = (DataList)item.FindControl("UserDetailsSkills");
            innerListSkill.DataSource = ((UserDetails)item.DataItem).Skills;
            innerListSkill.DataBind();
       
            var innerListRoles = (DataList)item.FindControl("UserDetailsRoles");
            innerListRoles.DataSource = ((UserDetails)item.DataItem).Roles;
            innerListRoles.DataBind();
        }
    }

    //get user infor from DB
    private List<User> GetUserInfoFromDB()
    {
        List<User> users = new List<User>();
        List<UserDetails> userDetails = new List<UserDetails>();
        string commandText = "Select * from User_tbl;";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(commandText, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        User u = new User();
                        u.id = reader.GetInt32(0);
                        u.name = reader.GetString(1);
                        u.type = reader.GetString(2);
                        u.url = reader.GetString(3);
                        u.pic = reader.GetString(4);
                        users.Add(u);
                    }
                    catch (Exception)
                    { //log error and move to the next user to process
                    }
                }
                reader.Close();
            }

            //get detailss for each user
            commandText = "Select * from User_Info_tbl;";
            cmd = new MySqlCommand(commandText, conn);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                        UserDetails ud = new UserDetails();
                        ud = JsonConvert.DeserializeObject<UserDetails>(reader.GetString(1));
                        userDetails.Add(ud);
                    }
                    catch (Exception)
                    { 
                        //log error and move to the next row to process
                    }
                }
                reader.Close();
            }
        } 

        //connect user details to each user
        foreach (User u in users)
        {
            u.UserDetails = userDetails.Where(x => x.Id == u.id).ToList();
        }

        CloseConnection();
        return users;
    }

    
    private void SaveUserInfo()
    {
        List<User> users = new List<User>();
        //get all the users from search api
        WebRequest req = WebRequest.Create("https://api.angel.co/1/search?query=ucla&type=User");
        req.Method = "Get";
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

        if (resp.StatusCode == HttpStatusCode.OK)
        {
            using (Stream respStream = resp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(respStream, System.Text.Encoding.UTF8);
                users = JsonConvert.DeserializeObject<List<User>>(reader.ReadToEnd()); //convert json to users object

                //save all the users to db
                SaveUserInfoToDB(users);
            }

        }
       
        List<int> userIds = users.Select(x => x.id).ToList();
        Dictionary<int, string> userDetails = new Dictionary<int, string>();

        //get user details from user api for each user
        foreach (int id in userIds)
        {
            req = WebRequest.Create("https://api.angel.co/1/users/" + id);
            req.Method = "Get";
            resp = (HttpWebResponse)req.GetResponse();

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, System.Text.Encoding.UTF8);
                    String userDetailsJson = reader.ReadToEnd();
                    userDetailsJson = userDetailsJson.Replace('\'', ' ');
                    userDetails.Add(id, userDetailsJson);
                }
            }
        }

        //save user details to db as key (userId) value (the whole json string from api) pairs
        SaveUserDetailsToDB(userDetails);

    }

    
    private void SaveUserDetailsToDB(Dictionary<int, string> userDetails)
    {
        string query = "";
        if (this.OpenConnection() == true)
        {
            try
            {
                foreach (int k in userDetails.Keys)
                {
                    //insert or upate userdetails for each user in User_Info_tbl
                    //if i used sql server would be more efficient to have stored proc that would take the
                    //whole key/value pairs as table valued parameter and insert all the data in one trip to DB.
                    //because data set is small now this should be fine for testing purposes.
                    query = "REPLACE INTO User_Info_tbl VALUES ( '" + k + "' , '" + userDetails[k] + "' )";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            
            }
            catch (Exception ex)
            {
                this.CloseConnection();
            }
        }
        CloseConnection();
    }

    private void SaveUserInfoToDB(List<User> users)
    {
        string query = "";
        if (this.OpenConnection() == true)
        {
            try
            {
                foreach (User user in users)
                {
                    //insert or update users in User_tbl
                    query = "REPLACE INTO User_tbl VALUES ( '" + user.id + "' , '" + user.name + "' , '" + user.type + "' , '" + user.url + "' , '" + user.pic + "' )";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }          
            }
            catch (Exception ex)
            {
                this.CloseConnection();
            }
        }
        CloseConnection();
    }

    private bool OpenConnection()
    {
        string myConnectionString;
        myConnectionString = "server=localhost; uid=root; pwd=; database=UCLA;";
        try
        {
            conn = new MySqlConnection(myConnectionString);
            conn.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            throw ex;
        }

    }

    private bool CloseConnection()
    {
        try
        {
            conn.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            throw ex;
        }
    }

  
}
