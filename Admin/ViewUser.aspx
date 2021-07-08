<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeFile="ViewUser.aspx.cs" Inherits="Admin_ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container col-lg-12">
<br />
  <div class="table-responsive-sm">
   <table class="table table-hover table-bordered" style="margin-top:10px;">
     <thead class="table-success">
     <tr>
      <th scope="col">Name</th>
      <th scope="col">Contact No.:</th>
      <th scope="col">Email ID.:</th>
      <th scope="col">Date of Register</th>
    </tr>
  </thead>
<asp:Repeater ID="RptTable" runat="server">
<ItemTemplate>
  <tbody>
    <tr>
      <td><%#Eval("name") %></td>
      <td><%#Eval("mobile_no") %></td>
      <td><%#Eval("email") %></td>
      <td><%#Eval("date") %></td>
    </tr>
  </tbody>
      </ItemTemplate>
 </asp:Repeater>
</table>
    </div>
 </div>
</asp:Content>

