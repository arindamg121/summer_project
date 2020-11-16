<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stats1.aspx.cs" Inherits="KnowYourResult.stats1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sem 1 Statistics</title>
</head>
<body style="background-color: #00adb5;">
    <form id="form1" runat="server">
        <p> </br>    
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#222831" Text="Shift :"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
         <asp:listitem Text="SEM1M"></asp:listitem>
            <asp:listitem Text="SEM1A"></asp:listitem>
        </asp:DropDownList>
&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#222831" Text="Subject :"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                 <asp:listitem Text="OOPGRADE"></asp:listitem>
    <asp:listitem Text="SEPMGRADE"></asp:listitem>
    <asp:listitem Text="COAGRADE"></asp:listitem>
    <asp:listitem Text="ITMGRADE"></asp:listitem>
    <asp:listitem Text="SPGRADE"></asp:listitem>
        </asp:DropDownList>
&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#222831" Text="Batch :"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
             <asp:listitem Text="2018"></asp:listitem>
     <asp:listitem Text="2019"></asp:listitem>
     <asp:listitem Text="2020"></asp:listitem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#222831" Text="Subject Grade:"></asp:Label>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Display" />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#222831" Text="Passed/Failed:"></asp:Label>
        <asp:Button ID="Button3" runat="server" Text="Result" OnClick="Button3_Click" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
