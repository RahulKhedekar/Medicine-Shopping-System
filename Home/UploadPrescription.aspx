<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Home.master" AutoEventWireup="true" CodeFile="UploadPrescription.aspx.cs" Inherits="Home_UploadPrescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="center3">
    <div class="container"><br /><br />
        <div class="row">
            <div class="col-md-6">
                <div>
                    <h5>&nbsp<asp:Label ID="Label1" runat="server" Text="Upload photo of your prescription"></asp:Label></h5>
                    &nbsp<asp:FileUpload ID="FileUpload1" runat="server" /><br />
                    &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="btn" runat="server" Display="Dynamic" ErrorMessage="Please Upload Prescription" ControlToValidate="FileUpload1" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <asp:Button ID="Button1" runat="server" ValidationGroup="btn" CssClass="btn btn-success" Text="PROCEED" onclick="Button1_Click" />
                    <br /><br />
                    <p>Order medicines in 3 steps<br />
                       1.Upload a valid prescription<br />
                       2.Receive a confirmation call<br />
                       3.Delivery at your door step<br />
                    </p>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">  
               
                </div>     
            </div>
        </div>
    </div>
</div>
</asp:Content>

