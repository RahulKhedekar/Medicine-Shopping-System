<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeFile="ViewFullPrescription.aspx.cs" Inherits="Admin_ViewFullPrescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
<table class="table table-bordered">
   <thead class="table-success">
    <tr>    
      <th scope="col">Image</th>      
    </tr>
  </thead>
<asp:Repeater ID="Repeater1" runat="server">
 <ItemTemplate>
  <tbody>
    <tr>
      <td><img src="../image/Prescription/<%#Eval("name") %>/<%#Eval("pimage") %>.jpg" height="400" width="400" /></td>
    </tr>  
  </tbody>
  </ItemTemplate>
</asp:Repeater>
</table>
</asp:Content>

