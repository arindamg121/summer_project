<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="KnowYourResult.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <style>
        body {
          margin: 0;
          padding: 0;
          background-color: #0f3460;
          height: 100vh;
        }
        #login .container #login-row #login-column #login-box {
          margin-top: 80px;
          max-width: 600px;
          height: 320px;
          border: 1px solid #ff8e6e;
          background-color: #ff8e6e;
          margin-left:300px;
        }
        #login .container #login-row #login-column #login-box #login_form {
          padding: 20px;
        }
        #login .container #login-row #login-column #login-box #login_form #register-link {
          margin-top: -85px;  
        }

     #mySidenav a {
  position: absolute;
  left: -80px;
  transition: 0.3s;
  padding: 15px;
  width: 100px;
  text-decoration: none;
  font-size: 20px;
  color: white;
  border-radius: 0 5px 5px 0;
}

#mySidenav a:hover {
  left: 0;
}

#home {
  top: 20px;
  background-color: #ff8e6e;
}

#sem1 {
  top: 80px;
  background-color: #ff8e6e;
}

#sem2 {
  top: 140px;
  background-color: #ff8e6e;
}

#sem3 {
  top: 200px;
  background-color: #ff8e6e;
}

#sem4 {
  top: 260px;
  background-color: #ff8e6e;
}

#sem5 {
  top: 320px;
  background-color: #ff8e6e;
}

#sem6 {
  top: 380px;
  background-color: #ff8e6e;
}
		footer {
		position: fixed;
		left: 0;
		bottom: 0;
		width: 100%;
		background-color: #ff8e6e;
		color: black;
		padding: 10px;
		text-align: center;
		}
    </style>
</head>
<body>


    <div id="mySidenav" class="sidenav">
  <a href="#" id="home">Home</a>
  <a href="#" id="sem1">SEM 1</a>
  <a href="#" id="sem2">SEM 2</a>
  <a href="#" id="sem3">SEM 3</a>
  <a href="#" id="sem4">SEM 4</a>
  <a href="#" id="sem5">SEM 5</a>
  <a href="#" id="sem6">SEM 6</a>

</div>
    
 

    <div id="login">
        <h3 class="text-center text-white pt-5" style="font-family: 'Linotte'; font-size:50px; text-transform: uppercase; color: #FFFFFF;">GENERATE YOUR RESULT</h3>
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                        <form id="login_form" class="form" method="post" runat="server">
                            <h3 class="text-center text-info; color: #ffffff;">Login</h3>
                            <div class="form-group">
                                <label for="username" class="text-info; color: #ffffff">Username:</label><br/>
                                <asp:TextBox type="text" name="username" id="username" class="form-control" runat="server"/>
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-info; color: #ffffff">Password:</label><br>
                                <asp:TextBox type="text" name="password" id="password" class="form-control" runat="server"/>
                            </div>
                            <div class="form-group">
                                <asp:Button type="submit" name="submit" class="btn btn-info btn-md" TEXT="Submit" runat="server" OnClick="login_Click"/>
                            </div>
                       </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
<footer>Project Created By Arindam, Ninad, Sarath</footer>
</body>
</html>
