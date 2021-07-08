<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeFile="ViewPrescription.aspx.cs" Inherits="Admin_ViewPrescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
<table class="table table-bordered">
  <thead class="table-success">
    <tr>
      <th scope="col">ID</th>
      <th scope="col">Name</th>
      <th scope="col">Contact</th>
      <th scope="col">Email</th>
      <th scope="col">View Order</th>
    </tr>
  </thead>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
  <tbody>
    <tr>
      <td><%#Eval("Pid") %></td>
      <td><%#Eval("name") %></td>      
      <td><%#Eval("mobile_no") %></td>
      <td><%#Eval("email") %></td>
      <td style="text-align:center"><a href="ViewFullPrescription.aspx?id=<%#Eval("Pid") %>" role="button" class="btn btn-success">View</a></td>
    </tr>
  </tbody>
<br />
</ItemTemplate>
</asp:Repeater>
</table>
</asp:Content>

