<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="choose" Text="選取" />
                    <asp:ButtonField ButtonType="Button" CommandName="del" Text="刪除" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="新增" />
&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="修改" />
&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="查詢" />
&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="刪除" />
&nbsp;
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="匯出成Excel" />
&nbsp;
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="回前頁" />
            &nbsp;
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" Width="520px">
                &nbsp;&nbsp;
                <br />
                &nbsp;&nbsp; Id :
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp; Name :
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp; Phone :
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp; Address :
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp; Birthday :
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp; Gender :
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;
                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="確定" />
                &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
            </asp:Panel>
        </div>
        <asp:Panel ID="Panel2" runat="server" BackColor="#66CCFF" Width="520px">
            &nbsp;<br /> &nbsp;&nbsp; Id :
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Name :
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Phone :
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Address :
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Birthday :
            <asp:TextBox ID="TextBox11" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Gender :
            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="確定" />
            &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" BackColor="#9999FF" Width="520px">
            &nbsp;<br /> &nbsp; 請輸入想查詢的 Id :
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="確定" />
            &nbsp;
            <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" BackColor="#CCCCFF" Width="520px">
            &nbsp;<br /> &nbsp; 請輸入想刪除的 Id :
            <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="確定" />
            &nbsp;
            <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" BackColor="#FFCCFF" Width="520px">
            &nbsp;<br /> &nbsp;&nbsp; Id :
            <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Name :
            <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Phone :
            <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Address :
            <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Birthday :
            <asp:TextBox ID="TextBox19" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Gender :
            <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;
            <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="確定修改" />
            &nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
        </asp:Panel>
    </form>
</body>
</html>
