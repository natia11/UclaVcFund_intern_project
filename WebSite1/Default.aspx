<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<link href="Content/default.css" rel="stylesheet" />
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title><%: Page.Title %> - UCLA VC Fund</title>
</head>
<body>
    <div>
        <asp:DataList runat="server" ID="UserdataList" OnItemDataBound="UserdataList_ItemDataBound" BorderColor="black"
           CellPadding="5" CellSpacing="5" RepeatDirection="Vertical" RepeatLayout="Table" RepeatColumns="1"
           ShowFooter="True"  AutoGenerateColumns="False" > 
         <HeaderStyle BackColor="#e9eaec">
         </HeaderStyle>
         <ItemStyle BackColor="White" BorderColor="Gray"  BorderStyle="Dashed" BorderWidth="1px">
         </ItemStyle>
            <HeaderTemplate>
                 <h1 style="align-content:center; padding-left:400px; padding-top:20px">AngelList Users</h1>
            </HeaderTemplate>
             <ItemTemplate>
               <div height: 150 px">
               <div style="display: block; padding: 0;float: none;border-style: solid;border-radius: 79px;width: 79px;height: 79px;border-width: 3px;border-color: grey;">
                  <asp:Image runat="server" ID="_image" style="border-radius: 79px;width: 79px;height: 79px;" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "pic")%>' AlternateText="" />
               </div>
                   <b style="color:black"> <%# DataBinder.Eval(Container.DataItem, "name") %> </b><br />
               </div> 
        
               <asp:HyperLink runat="server"  ID="alUrl" Text="User Details" ImageUrl="Content/angelList.png" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "url") %>'></asp:HyperLink>  <br />
               <asp:DataList runat="server" ID="UserDetails" OnItemDataBound="UserDetails_ItemDataBound"  >
                     <ItemTemplate>
                         <b class="title">Investor:</b> <%# DataBinder.Eval(Container.DataItem, "Investor") %><br />
                         <b class="title">Follower Count:</b> <%# DataBinder.Eval(Container.DataItem, "FollowerCount") %><br />
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TwitterUrl") != "" && DataBinder.Eval(Container.DataItem, "TwitterUrl") != null %>' ID="HyperLink1" ImageUrl="Content/twitter.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "TwitterUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "FacebookUrl") != "" && DataBinder.Eval(Container.DataItem, "FacebookUrl") != null %>' ID="HyperLink2" ImageUrl="Content/fb.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "FacebookUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "LinkedinUrl") != "" && DataBinder.Eval(Container.DataItem, "LinkedinUrl") != null %>' ID="HyperLink5" ImageUrl="Content/linkedin.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkedinUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "BlogUrl") != "" && DataBinder.Eval(Container.DataItem, "BlogUrl") != null %>' ID="HyperLink3" ImageUrl="Content/blog.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "BlogUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "OnlineBioUrl") != "" && DataBinder.Eval(Container.DataItem, "OnlineBioUrl") != null %>' ID="HyperLink4" ImageUrl="Content/bio.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "OnlineBioUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "AboutmeUrl") != "" && DataBinder.Eval(Container.DataItem, "AboutmeUrl") != null %>' ID="HyperLink6" ImageUrl="Content/aboutMe.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "AboutmeUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "GithubUrl") != "" && DataBinder.Eval(Container.DataItem, "GithubUrl") != null %>' ID="HyperLink7" ImageUrl="Content/github.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "GithubUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "DribbbleUrl") != "" && DataBinder.Eval(Container.DataItem, "DribbbleUrl") != null %>' ID="HyperLink8" ImageUrl="Content/dribble.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "DribbbleUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "BehanceUrl") != "" && DataBinder.Eval(Container.DataItem, "BehanceUrl") != null %>' ID="HyperLink9" ImageUrl="Content/behance.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "BehanceUrl") %>'></asp:HyperLink>  
                         <asp:HyperLink runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "ResumeUrl") != "" && DataBinder.Eval(Container.DataItem, "ResumeUrl") != null %>' ID="HyperLink10" ImageUrl="Content/resume.jpg" ImageHeight="25px" ImageWidth="25px" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "ResumeUrl") %>'></asp:HyperLink>   <br />

                         <p visible='<%# DataBinder.Eval(Container.DataItem, "Bio") != "" && DataBinder.Eval(Container.DataItem, "Bio") != null %>'><b class="title">Bio:</b>  <%# DataBinder.Eval(Container.DataItem, "Bio") %></p>
                         <p visible='<%# DataBinder.Eval(Container.DataItem, "WhatIveBuilt") != "" && DataBinder.Eval(Container.DataItem, "WhatIveBuilt") != null %>'><b class="title">What I have built:</b>  <%# DataBinder.Eval(Container.DataItem, "WhatIveBuilt") %></p>
                         <p visible='<%# DataBinder.Eval(Container.DataItem, "WhatIDo") != "" && DataBinder.Eval(Container.DataItem, "WhatIDo") != null %>'><b class="title">What I do:</b>  <%# DataBinder.Eval(Container.DataItem, "WhatIDo") %></p>
                         <p visible='<%# DataBinder.Eval(Container.DataItem, "Criteria") != "" && DataBinder.Eval(Container.DataItem, "Criteria") != null %>'><b class="title">Criteria: </b> <%# DataBinder.Eval(Container.DataItem, "Criteria") %></p>

                         <b class="title">Locations:</b>
                         <asp:DataList runat="server" ID="UserDetailsLoc" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" CssClass="links"  Visible='<%# DataBinder.Eval(Container.DataItem, "AngellistUrl") != "" && DataBinder.Eval(Container.DataItem, "AngellistUrl") != null %>' ID="HyperLink10" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayName") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "AngellistUrl") %>'></asp:HyperLink>   
                            </ItemTemplate>
                         </asp:DataList>
                         <br/>     
                         <b class="title">Skills:</b> 
                         <asp:DataList runat="server" ID="UserDetailsSkills" RepeatDirection="Horizontal">
                            <ItemTemplate >
                                <asp:HyperLink runat="server" CssClass="links" Visible='<%# DataBinder.Eval(Container.DataItem, "AngellistUrl") != "" && DataBinder.Eval(Container.DataItem, "AngellistUrl") != null %>' ID="HyperLink10" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayName") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "AngellistUrl") %>'></asp:HyperLink>
                            </ItemTemplate>
                         </asp:DataList>
                         <br />     
                         <b class="title">Roles:</b>
                         <asp:DataList runat="server" ID="UserDetailsRoles" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:HyperLink runat="server"  CssClass="links" Visible='<%# DataBinder.Eval(Container.DataItem, "AngellistUrl") != "" && DataBinder.Eval(Container.DataItem, "AngellistUrl") != null %>' ID="HyperLink10" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayName") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "AngellistUrl") %>'></asp:HyperLink>   
                            </ItemTemplate>
                         </asp:DataList>
                         <br />     
                     </ItemTemplate>
                 </asp:DataList>
            <br/><br />     
            </ItemTemplate>
        </asp:DataList>
    </div>

</body>
</html>