<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Online Medicine Shopping</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha256-L/W5Wfqfa0sdBNIKN9cG6QA5F2qx4qICmU2VgLruv9Y=" crossorigin="anonymous"/>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark justify-content-sm-start fixed-top">
            <div class="container-fluid">
                <a class="navbar-brand order-1 order-lg-0 ml-lg-0 ml-3 mr-auto" href="#"><img src="image/download1.jpg" height="40" width="120px" /></a>
                    <button class="navbar-toggler align-self-start" type="button">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse bg-dark p-3 p-lg-0 mt-5 mt-lg-0 d-flex flex-column flex-lg-row flex-xl-row justify-content-lg-end mobileMenu" id="navbarSupportedContent">
                        <div class="srch">
                            <asp:TextBox ID="TextBox1" runat="server" placeholder=" Looking for Medicines?"></asp:TextBox>
                            <button id="TextBoxSearch" type="submit">Search</button>
                        </div>
                        <ul id="hel" class="navbar-nav align-self-stretch">
                            <li class="nav-item"><a class="nav-link" href="#"><i class="fa fa-medkit" aria-hidden="true"></i> Order Medicine</a></li>
                            <li class="nav-item"><a class="nav-link" href="#"><i class="fa fa-percent" aria-hidden="true"></i> Offers</a></li>
                            <li class="nav-item"><a class="nav-link" href="#"><i class="fa fa-sign-in" aria-hidden="true"></i> Login/Signup</a></li>
                            <li class="nav-item"><a class="nav-link" href="#"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Cart</a></li>
                        </ul>
                    </div>
            </div>
        </nav>
        <div class="overlay"></div>
        <div class="container my-5">
            <div class="col-md-12"></div>
        </div>
<!--Iamge Slider Part-->
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
             </ol>
             <div class="carousel-inner">
                <div class="carousel-item active">
                  <img src="image/slide4.jpg" class="d-block w-100" alt="First Slide">
                </div>
                <div class="carousel-item">
                  <img src="image/slide3.jpg" class="d-block w-100" alt="Second Slide">
                </div>
                <div class="carousel-item">
                  <img src="image/slide2.jpg" class="d-block w-100" alt="Third Slide">
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
        
                
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/js/bootstrap.bundle.min.js" integrity="sha256-OUFW7hFO0/r5aEGTQOz9F/aXQOt+TwqI1Z4fbVvww04=" crossorigin="anonymous"></script>
        <script src="./js/script.js"></script>
    </form>
</body>
</html>
