<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>
              <% foreach (var department in this.model)
                 { %>            
              <tr class="ListItem">
                <td>
                    <% if(department.has_sub_departments) { %>
                    <a href="?view=departments&action=sub">
                        <%= department.name %>
                    </a>
                    <% } else {  %>
                    <a href="?view=products&action=display">
                        <%= department.name %>
                    </a>
                    <% } %>
                </td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
