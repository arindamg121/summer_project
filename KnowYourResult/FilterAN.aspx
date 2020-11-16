<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilterAN.aspx.cs" Inherits="KnowYourResult.FilterAN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sem 1 Afternoon</title>
</head>
<body style="background-color: #903749;">
    <form id="form1" runat="server">
        <p> </br>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#e8e8e8" Text="Semester :"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
             <asp:listitem Text="sem1A"></asp:listitem>
            <asp:listitem Text="sem2A"></asp:listitem>
                <asp:listitem Text="sem3A"></asp:listitem>
                <asp:listitem Text="sem4A"></asp:listitem>
                <asp:listitem Text="sem5A"></asp:listitem>
        </asp:DropDownList>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Display" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#e8e8e8" Text="Batch :"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
     <asp:listitem Text="2018"></asp:listitem>
            <asp:listitem Text="2019"></asp:listitem>
                <asp:listitem Text="2020"></asp:listitem>
        </asp:DropDownList>
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Display" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#e8e8e8" Text="Seat No :"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Search" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#e8e8e8" Text="Seat No :"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
