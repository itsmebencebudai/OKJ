<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="loginpage.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 24px;
            text-align: left;
            width: 699px;
        }
        .auto-style3 {
            text-align: right;
            width: 705px;
        }
        .auto-style4 {
            height: 24px;
            text-align: right;
            width: 705px;
        }
        .auto-style6 {
            height: 24px;
            width: 204px;
        }
        .auto-style7 {
            width: 204px;
        }
        .auto-style8 {
            text-align: left;
            width: 699px;
        }
        .auto-style9 {
            text-align: right;
            width: 705px;
            height: 30px;
        }
        .auto-style10 {
            width: 204px;
            height: 30px;
        }
        .auto-style11 {
            text-align: left;
            height: 30px;
            width: 699px;
        }
        .auto-style12 {
            width: 699px;
        }
        .auto-style13 {
            text-align: right;
            width: 705px;
            height: 27px;
        }
        .auto-style14 {
            width: 204px;
            height: 27px;
        }
        .auto-style15 {
            text-align: left;
            width: 699px;
            height: 27px;
        }
        .auto-style16 {
            text-align: center;
        }
        .auto-style17 {
            width: 705px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style16">
            <div class="auto-style16">
                <h1>Registration Page</h1>
            </div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">Username:</td>
                    <td class="auto-style6">
                        <asp:TextBox ID="user" runat="server" Height="20px" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="user" ErrorMessage="Username required" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Email:</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="email" runat="server" Height="20px" TextMode="Email" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="email" ErrorMessage="Email required" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" ErrorMessage="Email is not valid" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Password:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="password" runat="server" Height="20px" TextMode="Password" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="password" ErrorMessage="Password is not valid" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Confirm password:</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="confirmpassword" runat="server" Height="20px" TextMode="Password" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="confirmpassword" ErrorMessage="Confirm password in not the same" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password" ControlToValidate="confirmpassword" ErrorMessage="Both password must be same" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style13">Country:</td>
                    <td class="auto-style14">
                        <asp:DropDownList ID="country" runat="server" Height="20px" Width="200px">
                            <asp:ListItem>Select country</asp:ListItem>
                            <asp:ListItem>Hun</asp:ListItem>
                            <asp:ListItem>USA</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style15">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="country" ErrorMessage="Select a country" ForeColor="Red" InitialValue="Select country name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit" />
                        <input id="Reset1" type="reset" value="reset" /></td>
                    <td class="auto-style12">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style17">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
