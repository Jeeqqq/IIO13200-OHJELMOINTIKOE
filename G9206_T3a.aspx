<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G9206_T3a.aspx.cs" Inherits="G9206_T3a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:aliceblue;">
    <form id="form1" runat="server">
        <div id="banner" style="margin:0 auto; height:200px; width:900px;border-bottom:double; "><div style="float:left; margin-left:10px; "><asp:Image runat="server" ImageUrl="~\Images\hiihto.gif" /></div> <h1 style="font-size:60px; text-align:center;">LadunSuhaajat</h1>  </div>
    <div id="content"style="margin:0 auto; width:900px; background-color:antiquewhite; clear:both;">
        </div>
     
    
        
        
        <div style="width:300px;margin:0 auto;padding:10px;">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
     <asp:Label ID="lblInfo" runat="server"></asp:Label>
        <asp:Login ID="LoginWindow" runat="server" 
        OnAuthenticate="LoginWindow_Authenticate" 
        OnLoginError="LoginWindow_LoginError" 
        OnLoggedIn="LoginWindow_LoggedIn">
    </asp:Login>
    </div> 
        
        <table id="uusiHarjoitus" runat="server" style="width:300px;margin:0 auto;padding:10px;">
            <tr><th colspan="2">Lisää uusi harjoitus</th></tr>
           <tr><td>Kuka hiihti : </td> <td><asp:TextBox runat="server" CausesValidation="true" ValidateRequestMode="Enabled"  ID="txtKayttaja"  >  </asp:TextBox></td></tr>
            <tr><td>Paljonko hiihti : </td><td><asp:TextBox runat="server" ID="txtKilometrit" ></asp:TextBox></td></tr>
            <tr><td>Milloin hiihti : </td><td><asp:TextBox runat="server" TextMode="Date" ID="txtPvm" ></asp:TextBox></td></tr>
            <tr><td><asp:Button ID="btnUusi" runat="server" OnClick="btnUusi_Click" Text="Lisää uusi harjoitus" /></td></tr>
        </table>

        <div id="listViewContainer" runat="server" style="margin:0 auto; width:900px; background-color:antiquewhite; clear:both;">
            <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="True" style="float:left;margin-right:10px;" ViewStateMode="Enabled" EnableViewState="true"  ></asp:ListBox>
             
        <asp:ListView ID="ListView1" runat="server" >
        
        <LayoutTemplate>
            <h1>Kaikki hiihtoharjoitukset</h1>
              <table>
                   <tr>
                       <th>Nimi</th>
                       <th>Kilometrit</th>
                       <th>Päivämäärä</th>
                   </tr>
                   <tr runat="server" id="itemPlaceholder" />
               </table>
          </div>
        </LayoutTemplate>
         <ItemTemplate>
                   <tr runat="server" id="tr1">
                        <td><%#Eval("Nimi") %></td>
                        <td><%#Eval("Kilometrit") %></td>
                        <td><%#Eval("Pvm") %></td>    
                    </tr>
  
        </ItemTemplate>
            
    </asp:ListView>
            <div id="yhtKm" runat="server" style="margin:0 auto; width:900px;"></div>
    </div>
<a href="G9206_index.aspx">Takaisin</a>
    </form>
</body>
</html>
