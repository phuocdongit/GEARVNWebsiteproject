<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_MatHang.aspx.cs" Inherits="WEB_Project.REPORT.Report_MatHang" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Pikaday-master/css/pikaday.css" rel="stylesheet" />
    <link href="../Pikaday-master/css/site.css" rel="stylesheet" />
    <link href="../Pikaday-master/css/theme.css" rel="stylesheet" />
    <%--<script src="../Pikaday-master/pikaday.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pikaday/1.8.0/pikaday.min.js"></script>
    <title>Mặt hàng</title>
    <style>
        .my-button {
            background-color: #00CCFF;
            font-weight: bold;
            height: 40px;
            width: 118px;
            margin-right: 50px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button class="my-button" ID="btnQuayLai" Style="border: solid 2px; border-radius: 9px;" runat="server" Text="Quay lại" Font-Size="12pt" OnClick="btnQuayLai_Click" />
            <asp:Label Style="margin-left: 10px" ID="Label1" runat="server" Text="Ngày bán:" Font-Names="Arial" Font-Bold="True"></asp:Label>
            <asp:Label Style="margin-left: 10px" ID="Label2" runat="server" Text="Từ" Font-Names="Arial" Font-Bold="True"></asp:Label>
            <asp:TextBox Style="margin-right: 50px; border: solid 1px; border-radius: 5px; width: 150px; height: 25px" ID="txtTu" runat="server" autocomplete="off"></asp:TextBox>

            <asp:Label ID="Label3" runat="server" Text="Đến" Font-Bold="True" Font-Names="Arial"></asp:Label>
            <asp:TextBox Style="margin-right: 82px; border: solid 1px; border-radius: 5px; width: 150px; height: 25px" ID="txtDen" runat="server" autocomplete="off"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Sắp xếp" Font-Bold="True" Font-Names="Arial"></asp:Label>
            <asp:DropDownList class="my-dropdown" Style="border: solid 1px; border-radius: 5px; margin-right: 80px" ID="ddlMatHang" runat="server" Font-Bold="True" Height="37px" Width="200px" Font-Names="Arial" Font-Size="16px" OnSelectedIndexChanged="ddlMatHang_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem style="height: 30px; text-align:center" Value="0" Selected="True">- - -    Chọn    - - -</asp:ListItem>
                <asp:ListItem style="height: 30px;" Value="1" >Mặc định</asp:ListItem>
                <asp:ListItem style="height: 30px;" Value="2">Xem nhiều nhất</asp:ListItem>
                <asp:ListItem style="height: 30px;" Value="3">Sắp hết</asp:ListItem>
            </asp:DropDownList>
            <script>
                var picker = new Pikaday({
                    field: document.getElementById('txtTu'),
                    format: 'dd/MM/yyyy',
                    yearRange: "2022:2030",
                    toString(date, format) {
                        const day = date.getDate();
                        const month = date.getMonth() + 1;
                        const year = date.getFullYear();
                        return `${day < 10 ? '0' : ''}${day}/${month < 10 ? '0' : ''}${month}/${year}`;
                    },
                    parse(dateString, format) {
                        const parts = dateString.split('-');
                        const day = parseInt(parts[0], 10);
                        const month = parseInt(parts[1], 10) - 1;
                        const year = parseInt(parts[2], 10);
                        return new Date(year, month, day);
                    }
                });

                var picker = new Pikaday({
                    field: document.getElementById('txtDen'),
                    format: 'dd/MM/yyyy',
                    yearRange: "2022:2030",
                    toString(date, format) {
                        const day = date.getDate();
                        const month = date.getMonth() + 1;
                        const year = date.getFullYear();
                        return `${day < 10 ? '0' : ''}${day}/${month < 10 ? '0' : ''}${month}/${year}`;
                    },
                    parse(dateString, format) {
                        const parts = dateString.split('-');
                        const day = parseInt(parts[0], 10);
                        const month = parseInt(parts[1], 10) - 1;
                        const year = parseInt(parts[2], 10);
                        return new Date(year, month, day);
                    }
                });
            </script>
        </div>
        

        <div align="center">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportMatHang" runat="server" Height="836px" Width="940px" BorderStyle="Solid" BorderWidth="1px">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
