<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTestServicio.aspx.cs" Inherits="JoesWebApplication.WebFormTestServicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h2>Example de Web Service</h2>
            User name: <asp:TextBox ID="TextBoxUserName" runat="server" /> <br />
            Password: <asp:TextBox ID="TextBoxPassword" runat="server" /> <br />

            <asp:Label Text="" ID="labelServiceResult" runat="server" /><br />
            <asp:Button Text="Click to Call Service" ID="ButtonCallService" runat="server" OnClick="ButtonCallService_Click" />

        </div>
    </form>
</body>
</html>
