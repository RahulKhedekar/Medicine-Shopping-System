<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Admin.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="Admin_AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
    <div class="form-vertical">
    <br /><br />
        <h3 style="border-bottom:solid gray 1.5px;font-family:sans-serif;"><b>Add Category</b></h3>
        <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label" Text="Name"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="cat" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" ValidationGroup="add" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="cat"></asp:RequiredFieldValidator>
                </div>
        </div>
        <div class="form-group">
            &nbsp&nbsp<asp:Button ID="addcatBtn" runat="server" Text="Add Category" 
                CssClass="btn btn-danger" ValidationGroup="add" onclick="addcatBtn_Click"  />
        </div>
   </div>
 </div>
</asp:Content>

