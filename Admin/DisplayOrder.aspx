<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeFile="DisplayOrder.aspx.cs" Inherits="Admin_DisplayOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br /><br />
<table class="table table-bordered">
  <thead class="table-success">
    <tr>
      <th scope="col">ID</th>
      <th scope="col">Name</th>
      <th scope="col">Address</th>
      <th scope="col">Contact</th>
      <th scope="col">Email</th>
      <th scope="col">Payment Mode</th>
      <th scope="col">View Order</th>
    </tr>
  </thead>
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>
  <tbody>
    <tr>
      <td><%#Eval("id") %></td>
      <td><%#Eval("name") %></td>
      <td><%#Eval("address") %><br /><%#Eval("state") %>, <%#Eval("city") %>- <%#Eval("zipcode") %></td>
      <td><%#Eval("contact") %></td>
      <td><%#Eval("email") %></td>
      <td><%#Eval("payment") %></td>
      <td style="text-align:center"><a href="FullOrder.aspx?id=<%#Eval("id") %>"><i style="font-size:50px" class="fa fa-arrow-circle-o-right fa-View Orders" aria-hidden="true"></i></a></td>
    </tr>  
  </tbody>
<br />
</ItemTemplate>
</asp:Repeater>
</table>
</asp:Content>

