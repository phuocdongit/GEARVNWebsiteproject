<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_DoanhThu.aspx.cs" Inherits="WEB_Project.REPORT.WebForm2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doanh thu</title>
    <link href="../Pikaday-master/css/pikaday.css" rel="stylesheet" />
    <link href="../Pikaday-master/css/site.css" rel="stylesheet" />
    <link href="../Pikaday-master/css/theme.css" rel="stylesheet" />
    <%--<script src="../Pikaday-master/pikaday.js"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pikaday/1.8.0/pikaday.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-6">
            <asp:Button Style="border: solid 2px; border-radius: 9px; margin-right: 200px" ID="Button1" runat="server" Text="Quay lại" BackColor="#00CCFF" Font-Bold="True" Height="40px" OnClick="Button1_Click" Width="118px" />

            <asp:Label ID="Label1" runat="server" Text="Từ"></asp:Label>
            <asp:TextBox Style="margin-right: 100px; border: solid 1px; border-radius: 5px; width: 150px; height: 25px" ID="txtTuNgay" runat="server" autocomplete="off"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Text="Đến"></asp:Label>
            <asp:TextBox Style="margin-right: 100px; border: solid 1px; border-radius: 5px; width: 150px; height: 25px" ID="txtDenNgay" runat="server" autocomplete="off"></asp:TextBox>
            <asp:Button ID="btnLoc" runat="server" Text="Lọc" Style="border: solid 2px; border-radius: 9px;" Font-Bold="True" Height="40px" Width="118px" OnClick="btnLoc_Click" />
            <script>
                var picker = new Pikaday({
                    field: document.getElementById('txtTuNgay'),
                    format: 'dd/MM/yyyy',
                    yearRange:"2022:2030",
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
                    field: document.getElementById('txtDenNgay'),
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
        <br />
        <div align="center">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="680px" Width="877px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
