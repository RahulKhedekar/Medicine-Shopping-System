<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Home.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Home_Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br /><br />
<div class="container">
  <div class="row">
    <div class="col-md-4 order-md-2 mb-4">
      <h4 class="d-flex justify-content-between align-items-center mb-3">
        <span class="text-success font-weight-bold">Your cart</span>
      </h4>
      <ul class="list-group mb-3">
        <li class="list-group-item d-flex justify-content-between bg-success text-light">
          <div>
            <h5 class="my-0">Price Details</h5>
          </div>
        </li>
       
        <li class="list-group-item d-flex justify-content-between lh-condensed">
          <div>
            <h6 class="my-0">Cart Price(&#8377;)</h6>
          </div>
          <span><asp:Label ID="LP" runat="server" Text=""></asp:Label></span>
        </li>
        <li class="list-group-item d-flex justify-content-between lh-condensed"> 
            <div>         
            <h6 class="my-0">Discount(&#8377;)</h6>
          </div>
          <span>-<asp:Label ID="LD" runat="server" Text=""></asp:Label></span>
        </li>
        <li class="list-group-item d-flex justify-content-between lh-condensed">
          <div>
            <h6 class="my-0">Quantity</h6>
          </div>
          <span><asp:Label ID="CQ" runat="server" Text=""></asp:Label></span>
        </li>
        <li class="list-group-item d-flex justify-content-between">
          <h6>Total Amount Payable(&#8377;)</h6>
          <strong><asp:Label ID="LT" runat="server" Text=""></asp:Label></strong>
        </li>
      </ul>
    </div>
    <div class="col-md-8 order-md-1">
      <h4 class="mb-3 text-success">Billing Address</h4>
        <div class="col-md-6 mb-3">
            <label for="Name">Name</label>
              <asp:TextBox ID="Fname" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
        <div class="col-md-6 mb-3">
            <label for="username">Contact</label>
              <asp:TextBox ID="cont" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
        <div class="col-md-6 mb-3">
            <label for="altcontact">Alternate Contact</label>
              <asp:TextBox ID="altcont" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
        <div class="col-md-6 mb-3">
            <label for="email">Email</label>
              <asp:TextBox ID="email" runat="server" CssClass="form-control" TextMode="Email" required="required"></asp:TextBox>
                </div>       
        <div class="col-md-6 mb-3">
            <label for="address">Address</label>
              <asp:TextBox ID="address" runat="server" CssClass="form-control" TextMode="MultiLine" required="required"></asp:TextBox>
                </div>        
        <div class="col-md-6 mb-3">
            <label for="country">State</label>
              <asp:TextBox ID="state" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
        <div class="col-md-6 mb-3">
            <label for="state">City</label>
              <asp:TextBox ID="city" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                </div>
        <div class="col-md-6 mb-3">
            <label for="zip">ZipCode</label>
              <asp:TextBox ID="zipcode" runat="server" CssClass="form-control" required="required"></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="danger" ValidationExpression="^[0-9]{6}$" runat="server" ErrorMessage="Please Enter Proper Zipcode" ControlToValidate="zipcode" ValidationGroup="check" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>        
        <hr class="mb-4">
        <div class="custom-control custom-checkbox">
          <input type="checkbox" class="custom-control-input" id="same-address">
          <label class="custom-control-label" for="same-address">Shipping address is the same as my billing address</label>
        </div>
        <div class="custom-control custom-checkbox">
          <input type="checkbox" class="custom-control-input" id="save-info">
          <label class="custom-control-label" for="save-info">Save this information for next time</label>
        </div>
        <hr class="mb-4">

        <h4 class="mb-3">Payment</h4>

        <div class="d-block my-3">
          <div>
            <asp:RadioButton ID="cashRadio" runat="server" GroupName="payment" Checked="true" /> Cash On Delivery
          </div>
        </div>      
        <hr class="mb-4">
         <asp:Button ID="checkout" CssClass="btn btn-success btn-lg btn-block" OnClick="checkout_Click" runat="server" Text="Continue to checkout" ValidationGroup="check"/><br />
    </div>
  </div>
</div>
</asp:Content>

