<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Song Lyric Variation Tracker</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 20%; padding-bottom: 1%"> 
        <asp:FileUpload ID="fileUpload" runat="server" AllowMultiple="True" />
        <div style="padding-top: .5%">
            <asp:CheckBox ID="commonWordsCheckbox" runat="server" Text="Hide Common Words" />
            <asp:Button ID="uploadButton" runat="server" OnClick="uploadButton_Click" Text="Upload" />
        </div>       
    </div>
    <div style="width: 20%">
        <div style="padding-bottom: 1%">
            <asp:Table ID="displayTable" runat="server">
            </asp:Table>
        </div>          
        <asp:Label ID="percentageLabel" runat="server" Text="Top Ten words make up X% of all used words"></asp:Label>
    </div>
    </form>
</body>
</html>
