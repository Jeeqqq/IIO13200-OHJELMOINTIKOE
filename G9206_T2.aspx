<%@ Page Language="C#" AutoEventWireup="true" CodeFile="G9206_T2.aspx.cs" Inherits="G9206_T2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <asp:ListView ID="ListView1" runat="server" >
        
        <LayoutTemplate>

               <table>
                   <tr>
                       <th>Etunimi</th>
                       <th>Sukunimi</th>
                       <th>Tyosuhde</th>
                       <th>Numero</th>
                       <th>Palkka</th>
                   </tr>
                   <tr runat="server" id="itemPlaceholder" />
               </table>
          </div>
        </LayoutTemplate>
         <ItemTemplate>
                   <tr runat="server" id="tr1">
                        <td><%#Eval("Etunimi") %></td>
                        <td><%#Eval("Sukunimi") %></td>
                        <td><%#Eval("Tyosuhde") %></td>
                        <td><%#Eval("Numero") %></td>
                        <td><%#Eval("Palkka") %></td>     
                    </tr>
  
        </ItemTemplate>
            
    </asp:ListView>
    </div>
        <div id="OtherInformation" runat="server">
            <div runat="server" id="vakituisetYht"></div>
            <div runat="server" id="palkkaYht"></div>
            <a href="G9206_index.aspx">Takaisin</a>
        </div>
    </form>
</body>
</html>
