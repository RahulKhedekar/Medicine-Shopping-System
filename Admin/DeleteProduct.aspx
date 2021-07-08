<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeFile="DeleteProduct.aspx.cs" Inherits="Admin_DeleteProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container col-lg-12">
  <div class="table-responsive-sm">
  <br />
   <table class="table table-hover table-bordered" style="margin-top:10px;">
     <thead class="thead-dark">
     <tr>
      <th scope="col">MID</th>
      <th scope="col">Name</th>
      <th scope="col">Category</th>
      <th scope="col">Price</th>
      <th scope="col">Selling Price</th>
      <th scope="col">Discount</th>
      <th scope="col">Image</th>
      <th scope="col">Description</th>
      <th scope="col">Delete/Update</th>
    </tr>
  </thead>
<asp:Repeater ID="RptTable" runat="server">
<ItemTemplate>
  <tbody>
    <tr>
      <td><%#Eval("Mid") %></td>
      <td><%#Eval("MName") %></td>
      <td><%#Eval("CatName") %></td>
      <td><%#Eval("MPrice") %></td>
      <td><%#Eval("MSPrice") %></td>
      <td><%#Eval("Discount") %></td>
      <td><img width="60" height="60" src="../image/ProductImages/<%#Eval("MName") %>/<%#Eval("MImage") %><%#Eval("MExtention") %>" /></td>
      <td><%#Eval("MDescription").ToString().PadRight(90).Substring(0,50).TrimEnd() %></td>
     <td>
        <a href="Update.aspx?id=<%#Eval("Mid") %>" role="button" class="btn btn-success">Edit</a><div style="margin-top:5px;"><a href="Delete.aspx?id=<%#Eval("Mid") %>" role="button" class="btn btn-danger">Delete</a></div>
  
     </td>
      </tr>
  </tbody>
      </ItemTemplate>
 </asp:Repeater>
</table>
    </div>
 </div>
</asp:Content>

