<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KnowYourResult.Home" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link href="css/bootstrap.css" rel="stylesheet" />
  <title>Generate Result</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">
  <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
   <style>
       body {
           margin-top:150px;
           text-align:center;
           margin-left:360px;
       }
   </style>
</head>
<body style="background-image:url('home.jpg'); background-repeat:no-repeat; height:100px; width:500px ">
    <form id="form1" runat="server">
        <div class="container">
        <div class ="container-fluid" style="font-style: normal; font-weight: bold; font-size: large; font-family: Linotte; /*color: #d9ecf2;*/ text-transform: capitalize; /*background-color: #1aa6b7;*/" title="KnowYourResult" >
             <h1 style="font-family: 'Linotte'; color: #ffffff">Generate Your Results</h1>
             <p class="text-center" id="b"><a href="GetResult.aspx" class="btn btn-info" role="button">Get Started</a></p>   
            </div>  
       </div>     
          
    </form>
</body>
</html>
