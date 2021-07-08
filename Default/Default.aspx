<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous"/>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--Iamge Slider-->
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="5"></li> 
             </ol>
             <div class="carousel-inner">
                <div class="carousel-item active">
                  <img src="../image/Slides/slide1.jpg" class="d-block w-100" alt="First Slide" />
                </div>
                <div class="carousel-item">
                  <img src="../image/Slides/slide2.jpg" class="d-block w-100" alt="Second Slide" />
                </div>
                <div class="carousel-item">
                  <img src="../image/Slides/slide3.jpg" class="d-block w-100" alt="Third Slide" />
                </div>
                <div class="carousel-item">
                  <img src="../image/Slides/slide4.jpg" class="d-block w-100" alt="Fourth Slide" />
                </div>
                <div class="carousel-item">
                  <img src="../image/Slides/slide5.jpg" class="d-block w-100" alt="Fifth Slide" />
                </div>
                <div class="carousel-item">
                  <img src="../image/Slides/slide6.jpg" class="d-block w-100" alt="Sixth Slide">
                </div>
              </div>
              <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
              </a>
              <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
              </a>
              </div>
              <br />       
<!--Iamge Slider End-->
        
<!--Product-->
    <div class="container">
        <div class="bookHead">
           <div style="float: right;margin:5px;"> 
             <h5><b><asp:DropDownList ID="dropCategory" runat="server" BackColor="#f2f2f2" ForeColor="#D33B33" Font-Bold="true" AutoPostBack="true" OnSelectedIndexChanged="dropCategory_SelectedIndexChanged"></asp:DropDownList></b></h5>
           </div>
        <h5><b><u>Recently Added:</u></b></h5>
            </div><br /><br />
        <div class="row">
            <asp:Repeater ID="RepeatBooks" runat="server">
                <ItemTemplate>                    
                        <div class="col-md-3 col-sm-6 col-xs-12 product-grid">
				            <div class="image">
					            <a href="ViewDetails.aspx?mid=<%#Eval("Mid") %>">
						            <img src="../image/ProductImages/<%#Eval("MName") %>/<%#Eval("MImage") %><%#Eval("MExtention") %>" alt="<%#Eval("MName") %>" class="img-thumbnail">						    
					            </a>
				        &nbsp;&nbsp;&nbsp;</div>
				        <div class="bookName"><a href="ViewDetails.aspx?mid=<%#Eval("Mid") %>"><%#Eval("MName") %></a></div>
				        <div class="bookPrice"><span class="bookOrgPrice"><%#Eval("MSPrice") %><br />MRP: <%#Eval("MPrice") %></span></div>
				        <br /><a class="btn btn-primary" href="AddCart.aspx" role="button"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Add Cart</a>
                          </div>
                                             
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
<!--Product End-->
</asp:Content>
