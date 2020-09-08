<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetResult.aspx.cs" Inherits="KnowYourResult.GetResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Result</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <style>
        .container {
        margin-top:100px;
        margin-left:auto;
        }
        .con {
        color:white;
	}
    </style>
</head>
<body style="background-image:url('results.jpg');">
  <form id="form1" runat="server">
        <div class="container">
	<div class="con">
            <p style="text-decoration:solid;font-family:'Linotte';"><b>Select a Result pdf from above </b></div><asp:ListBox ID="ListBox1" runat="server" Width="300px"></asp:ListBox> 
            </p>
                <!--<p><b>Upload a Result pdf if you can't find your's on the list</b>    <asp:FileUpload ID="FileUpload1"  runat="server" /></p>-->
            <br />
                <p>
                    <asp:TextBox ID="Starting" class="form-control" runat="server" placeholder="Enter Starting Seat No." ></asp:TextBox> <br />
                    
                </p>
                <p>
                    <asp:TextBox ID="ending" runat="server" placeholder="Enter ending Seat No." ></asp:TextBox> <br />
                </p>
                <p>
                    <asp:Button ID="Button1" runat="server"  class="btn btn-primary" Text="Generate Marksheet " OnClick="Button1_Click1" />
                </p>
                <p>
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Shift 1" OnClick="Button2_Click2" />
                </p>
                <p>
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Shift 2" OnClick="Button3_Click3" />
                </p>
		</div>
            </div>
       </div>
  </form>
</body>
</html>
