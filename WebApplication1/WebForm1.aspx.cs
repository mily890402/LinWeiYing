using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] account = new string[3];
            string[] password = new string[3];
            account[0] = "123"; password[0] = "123";
            account[1] = "456"; password[1] = "456";
            account[2] = "789"; password[2] = "789";
            string Log_in_account = TextBox1.Text;
            string Log_in_password = TextBox2.Text;
            for (int i = 0; i < account.Length; i++) // 登錄
            {
                if (Log_in_account == account[i] && Log_in_password == password[i])
                {
                    Response.Redirect("WebForm2.aspx");
                }
                else
                {
                    Label1.Text = "帳號密碼錯誤";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e) //清除
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}