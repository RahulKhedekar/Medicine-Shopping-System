<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Home.master" AutoEventWireup="true" CodeFile="AddCart.aspx.cs" Inherits="Home_AddCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section>

  <!--Grid row-->
  <div class="row">

    <!--Grid column-->
    <div class="col-lg-8">

      <!-- Card -->
      <div class="mb-3">
        <div class="pt-4 wish-list">

<asp:Repeater ID="R1" runat="server">
<ItemTemplate>
          <div class="row mb-4" style="margin-bottom:10px;border:solid 1px #ccc">
            <div class="col-md-5 col-lg-3 col-xl-3">
              <div class="view zoom overlay z-depth-1 rounded mb-3 mb-md-0">
                <img class="img-fluid w-75" src="../image/ProductImages/<%#Eval("MImage") %>/<%#Eval("MImage") %>.JPG" alt="Sample">
              </div>
            </div>
            <div class="col-md-7 col-lg-9 col-xl-9">
              <div>
                <div class="d-flex justify-content-between">
                  <div>
                    <h5 class="cartView"><%#Eval("MName") %></h5>
                    <span class="bookOrgPrice"><%#Eval("MSPrice") %></span>&nbsp;
                    <span class="bookDisc">(Rs.<%#Eval("Discount") %>Off)</span>
                    <h6 class="font-weight-bold"><%#Eval("MPrice") %></h6>
                    
                  </div>
                </div>
                <div class="d-flex justify-content-between align-items-center">
                  <div><br />
                    <a href="../Default/DeleteCart.aspx?Mid=<%#Eval("Mid") %>" type="button" class="btn btn-danger mr-3">Remove</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <hr class="mb-4">
</ItemTemplate>
</asp:Repeater>
        </div>
      </div>
   </div>
    <!--Grid column-->

    <!--Grid column-->
    <div class="col-lg-4">

      <!-- Card -->
      <div class="mb-3">
        <div class="pt-4">
          <h4 class="mb-3"><b>Price Details</b></h4>
          <ul class="list-group list-group-flush">
            <li class="list-group-item d-flex justify-content-between align-items-center px-0">Price
              <span><asp:Label ID="CP" runat="server" Text=""></asp:Label></span>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-center px-0">
              Discount
              <span>- <asp:Label ID="CD" runat="server" Text=""></asp:Label></span>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-center px-0">
              Quantity
              <span>x <asp:Label ID="CQ" runat="server" Text=""></asp:Label></span>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 mb-3">
              <div>
                <strong>Total Amount</strong>
              </div>
              <span><strong>
                  <asp:Label ID="CT" runat="server" Text=""></asp:Label></strong></span>
            </li>
          </ul>
           <asp:Button ID="CheckoutBtn" CssClass="btn btn-success btn-block" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click" />
        </div>
      </div>
    </div>
    <!--Grid column-->

  </div>
  <!-- Grid row -->

</section>
</asp:Content>

