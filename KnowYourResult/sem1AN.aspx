<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sem1AN.aspx.cs" Inherits="KnowYourResult.sem1AN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sem 1 Afternoon</title>
</head>
<body style="background-color: #ce6262;">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
        <p style="color:#e8e8e8;margin-left: 200px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Batch :"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:listitem Text="2018"></asp:listitem>
            <asp:listitem Text="2019"></asp:listitem>            
</asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" ForeColor="#e8e8e8" Font-Bold="True" Text="File :"></asp:Label>
&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;<asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" Text="Upload" />
        </p>
        <p style="margin-left: 200px">
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" ForeColor="#e8e8e8" Font-Bold="True"></asp:Label>
        </p>
    <div>
    
    </div>
    </form>
</body>
</html>
