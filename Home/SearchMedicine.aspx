<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Home.master" AutoEventWireup="true" CodeFile="SearchMedicine.aspx.cs" Inherits="Home_SearchMedicine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br />
    <div class="container">
        <div class="row">
            <asp:Repeater ID="RepeatBooks" runat="server">
                <ItemTemplate>
                    
                        <div class="col-md-3 col-sm-6 col-xs-12 product-grid">
				            <div class="image">
					            <a href="#">
						            <img src="../image/ProductImages/<%#Eval("MName") %>/<%#Eval("Mimage") %><%#Eval("MExtention") %>" alt="<%#Eval("MName") %>" class="img-thumbnail">						    
					            </a>
				        &nbsp;&nbsp;&nbsp;</div>
				        <div class="bookName"><a href="#"><%#Eval("MName") %></a></div>
				        <div class="bookPrice"><span class="bookOrgPrice"><%#Eval("MSPrice") %><br />MRP: <%#Eval("MPrice") %></span><span class="bookDisc"> Save (20% Off)</span></div>
				        <br /><a class="btn btn-primary" href="#" role="button"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Add Cart</a>
                          </div>
                                             
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

