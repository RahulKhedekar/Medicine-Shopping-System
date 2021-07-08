<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="ViewDetails.aspx.cs" Inherits="Default_ViewDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Repeater ID="RepeatBooks" runat="server">
    <ItemTemplate>      
 <div class="container">
  <div class="row">
    <div class="col-md-6">
          <div class="image" style="max-width:450px;"> <img class="d-block w-100" src="../image/ProductImages/<%#Eval("MName") %>/<%#Eval("MImage") %><%#Eval("MExtention") %>" alt="<%#Eval("MName") %>" /> </div>
        </div>
    <div class="col-md-6">
      <div class="row">
        <h2 class="bookNameView" style="margin-top:20px;"><%#Eval("MName") %></h2>
      </div>
        
    <div class="row">
       <h4 class="bookOrgPriceView"><i class="fa fa-inr" aria-hidden="true"></i><%#Eval("MPrice") %></h4>
    </div>
     <div class="row">
       <h4 class="bookPriceView"><i class="fa fa-inr" aria-hidden="true"></i><%#Eval("MSPrice") %></h4>&nbsp;
       <h6 class="bookDiscView">(Rs.<%#Eval("Discount") %>Off)</h6>
     </div>        
      <div class="row">
        <h6><i class="fa fa-map-marker text-info" aria-hidden="true"></i>&nbsp; Delivery by 6-7 Working Days |&nbsp;<span class="text-success">FREE</span></h6> 
      </div><br />
     <div class="row" style="border-bottom:solid #a9a9a9 2px;"></div> 

    <div class="row">
        <h6 class="bookDesc"><b>About this Medicine:</b></h6>
        <p style="color:#000;font-family:sans-serif;font-size:15px;line-height:28px;"><%#Eval("MDescription") %></p>
        <h6 class="stk"><b><i class="fa fa-check-circle text-danger" style="font-size:21px;" aria-hidden="true"></i> Category:</b> <%#Eval("CatName") %></h6>    
    </div>
   <div class="row" style="border-top:dashed #a9a9a9 2px;"> </div><br />    
    
 </div>
      </div>
     </div>

      </ItemTemplate>
</asp:Repeater>

<table class="table table-borderless">
  <tbody>
    <tr>
      <td><div class="row" style="margin-left:670px;"><h6 class="bookPublishView"><b>Quantity:</b></h6>&nbsp;
         <asp:DropDownList ID="DropDownList1" runat="server" Height="25px">
             <asp:ListItem>1</asp:ListItem>
             <asp:ListItem>2</asp:ListItem>
             <asp:ListItem>3</asp:ListItem>
             <asp:ListItem>4</asp:ListItem>
             <asp:ListItem>5</asp:ListItem>
             <asp:ListItem>6</asp:ListItem>
             <asp:ListItem>7</asp:ListItem>
             <asp:ListItem>8</asp:ListItem>
             <asp:ListItem>9</asp:ListItem>
             <asp:ListItem>10</asp:ListItem>
         </asp:DropDownList> &nbsp;
        <asp:Label ID="Label1" CssClass="danger" Font-Bold="true" runat="server" Text=""></asp:Label>
    </div>
      </td>
       
    </tr>
    <tr>
        <td>   
            <div class="row">
                <a style="margin-left:680px;"><asp:Button ID="buyBtn" runat="server" Text="Buy Book" CssClass="btn btn-danger" ClientIDMode="Static" /></a>
                <a><i class="fa fa-shopping-cart" style="color:#fff" aria-hidden="true"></i>
                <asp:Button ID="cartBtn" runat="server" Text="Add Cart" CssClass="btn btn-secondary" ClientIDMode="Static" onclick="cartBtn_Click"/></a>
            </div>
        </td>
    </tr>
   </tbody>
</table>
</asp:Content>

