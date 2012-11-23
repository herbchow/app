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
                    <a href='<%=
                     String.Concat("?view=departments&action=sub&departmentId=", department.departmentId)
                     %>'>
                        <%= department.name %>
                    </a>
                    <% } else {  %>
                    <a href='<%=
                     String.Concat("?view=products&action=display&departmentId=", department.departmentId)
                     %>'>
                        <%= department.name %>
                    </a>
                    <% } %>
                </td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
