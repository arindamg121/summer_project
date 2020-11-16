<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KnowYourResult.Home" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="stylesheet" href="style.css">
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
  <link href="css/bootstrap.css" rel="stylesheet" />
  <title>Generate Result</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">
  <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
   <style>
       *
	   {
	   padding:0;
	   margin: 0;
	   box-sizing: border-box;
	   }
       body {
	   margin-top:150px;
	   text-align:center;
       }
	   .container {
           margin-left:360px;
	   }
	   .menu-bar
	   {
	   background:rgb(0,100,0);
	   text-align: center;
	   position: fixed;
	   top: 0;
	   width: 100%;
	   }
	   .menu-bar ul
	   {
	   display: inline-flex;
	   list-style:none;
	   color:#fff;
	   }
	   .menu-bar ul li
	   {
	   width: 120px;
	   margin: 15px;
	   padding: 15px;
	   }
	   .menu-bar ul li a
	   {
	   text-decoration:none;
	   color:#fff;
	   }
	   .active,.menu-bar ul li:hover
	   {
	   background: #2bab0d;
	   border-radius: 3px;
	   }
	   .menu-bar .fa
	   {
	   margin-right: 8px;
	   }
	   .sub-menu-1
	   {
	   display:none;
	   }
	   .menu-bar ul li:hover .sub-menu-1
	   {
	   display: block;
	   position: absolute;
	   background: rgb(0,100,0);
	   margin-top: 15px;
	   margin-left:-15px;
	   }
	   .menu-bar ul li:hover .sub-menu-1 ul
	   {
	   display: block;
	   margin: 10px;
	   }
	   .menu-bar ul li:hover .sub-menu-1 ul li
	   {
	   width: 150px;
	   padding: 10px;
	   border-bottom: 1px dotted #fff;
	   background: transparent;
	   border-radius:0;
	   text-align: left;
	   }
	   .menu-bar ul li:hover .sub-menu-1 ul li:last-child
	   {
	   border-bottom: none;
	   }
	   .menu-bar ul li:hover .sub-menu-1 ul li a:hover
	   {
	   color: #b2ff00;
	   }
	   .fa-angle-right
	   {
	   float: right;
	   }
	   .sub-menu-2
	   {
	   display: none;
	   }
	   .hover-me:hover .sub-menu-2
	   {
	   position: absolute;
	   display: block;
	   margin-top: -40px;
	   margin-left: 140px;
	   background: rgba(0,100,0)
	   }
   </style>
</head>
<body style="background-image:url('home1.jpg'); background-repeat:no-repeat; background-size: cover">
    <form id="form1" runat="server">
        <div class="container">
        <div class ="container-fluid" style="font-style: normal; font-weight: bold; font-size: large; font-family: Linotte; /*color: #d9ecf2;*/ text-transform: capitalize; /*background-color: #1aa6b7;*/" title="KnowYourResult" >
             <h1 style="font-family: 'Linotte'; color: #ffffff">Generate Your Results</h1>
             <p class="text-center" id="b"><a href="GetResult.aspx" class="btn btn-info" role="button">Get Started</a></p>   
            </div>  
       </div>
    </form>
<div class="menu-bar">
<ul>
<li><a href=""><i class="fa fa-upload"></i>UPLOAD</a>
<div class="sub-menu-1">
<ul>
<li class="hover-me"><a href="">Sem1</a><i class="fa fa-angle-right"></i>
<div class="sub-menu-2">
<ul>
<li><a href="sem1MN.aspx">Morning Shift</a></li>
<li><a href="sem1AN.aspx">Afternoon Shift</a></li>
</ul>
</div></li>

<li class="hover-me"><a href="">Sem2</a><i class="fa fa-angle-right"></i>
<div class="sub-menu-2">
<ul>
<li><a href="">Morning Shift</a></li>
<li><a href="">Afternoon Shift</a></li>
</ul>
</div></li>

<li class="hover-me"><a href="">Sem3</a><i class="fa fa-angle-right"></i>
<div class="sub-menu-2">
<ul>
<li><a href="">Morning Shift</a></li>
<li><a href="">Afternoon Shift</a></li>
</ul>
</div></li>

<li class="hover-me"><a href="">Sem4</a><i class="fa fa-angle-right"></i>
<div class="sub-menu-2">
<ul>
<li><a href="">Morning Shift</a></li>
<li><a href="">Afternoon Shift</a></li>
</ul>
</div></li>

<li class="hover-me"><a href="">Sem5</a><i class="fa fa-angle-right"></i>
<div class="sub-menu-2">
<ul>
<li><a href="">Morning Shift</a></li>
<li><a href="">Afternoon Shift</a></li>
</ul>
</div></li>

<li class="hover-me"><a href="">Sem6</a><i class="fa fa-angle-right"></i>
<div class="sub-menu-2">
<ul>
<li><a href="">Morning Shift</a></li>
<li><a href="">Afternoon Shift</a></li>
</ul>
</div></li>

</ul>
</div>
<li><a href=""><i class="fa fa-search">SEARCH</i></a>
<div class="sub-menu-1">
<ul>
<li><a href="FilterMN.aspx">Morning Shift</a></li>
<li><a href="FilterAN.aspx">Afternoon Shift</a></li>
</ul>
</div></li>
<li><a href=""><i class="fa fa-bar-chart">STATSTICS</i></a>
<div class="sub-menu-1">
<ul>
<li><a href="stats1.aspx">Sem1</a></li>
<li><a href="">Sem2</a></li>
<li><a href="">Sem3</a></li>
<li><a href="">Sem4</a></li>
<li><a href="">Sem5</a></li>
<li><a href="">Sem6</a></li>
</li>
</ul>
</div>
</body>
</html>
