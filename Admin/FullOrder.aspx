<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeFile="FullOrder.aspx.cs" Inherits="Admin_FullOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br /><br />
<table class="table table-bordered">
   <thead class="table-success">
    <tr>    
      <th scope="col">Product Image</th>
      <th scope="col">Product Name</th>
      <th scope="col">Product Price</th>
      <th scope="col">Product Quantity</th>
    </tr>
  </thead>
<asp:Repeater ID="Repeater1" runat="server">
 <ItemTemplate>
  <tbody>
    <tr>
      <td><img src="../image/ProductImages/<%#Eval("PName") %>/<%#Eval("PImage") %>.jpg" height="80" width="100" /></td>
      <td><%#Eval("PName") %></td>
      <td><%#Eval("PAmount") %></td>
      <td><%#Eval("PQty") %></td>
    </tr>  
  </tbody>
  </ItemTemplate>
</asp:Repeater>
</table>
</asp:Content>

