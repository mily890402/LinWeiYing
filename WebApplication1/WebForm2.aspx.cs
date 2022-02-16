using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel5.Visible = false;
                show();
            }
        }
        public void show()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Person", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
        protected void Button1_Click(object sender, EventArgs e) // 新增
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
        }

        protected void Button6_Click(object sender, EventArgs e)  // 確定新增
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "")
            {
                Label1.Text = "Id、Name、Phone 不能空白";
            }
            else
            {
                try
                {
                    Label1.Text = "";
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert Into Person(Id,Name,Phone,Address,Birthday,Gender) values (@paramId,@paramName,@paramPhone,@paramAddress,@paramBirthday,@paramGender)", conn);
                    cmd.Parameters.Add("@paramId", SqlDbType.NChar).Value = TextBox1.Text;
                    cmd.Parameters.Add("@paramName", SqlDbType.NChar).Value = TextBox2.Text;
                    cmd.Parameters.Add("@paramPhone", SqlDbType.NChar).Value = TextBox3.Text;
                    cmd.Parameters.Add("@paramAddress", SqlDbType.NChar).Value = TextBox4.Text;
                    cmd.Parameters.Add("@paramBirthday", SqlDbType.NChar).Value = TextBox5.Text;
                    cmd.Parameters.Add("@paramGender", SqlDbType.NChar).Value = TextBox6.Text;
                    int rows = cmd.ExecuteNonQuery(); //執行查詢
                    if (rows == 1)
                    {
                        Label1.Text = "新增" + rows.ToString() + "筆資料 !";
                    }
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();

                    show();
                }
                catch (Exception ex)
                {
                    Label1.Text = "已有此人 !";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e) // 修改
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
        }

        protected void Button7_Click(object sender, EventArgs e) // 確定修改
        {
            if (TextBox7.Text == "" || TextBox8.Text == "" || TextBox9.Text == "")
            {
                Label2.Text = "Id、Name、Phone 不能空白";
            }
            else
            {
                Label2.Text = "";
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Person Set Name=@paramName,Phone=@paramPhone,Address=@paramAddress,Birthday=@paramBirthday,Gender=@paramGender WHERE Id=@paramId", conn);
                cmd.Parameters.Add("@paramId", SqlDbType.NChar).Value = TextBox7.Text;
                cmd.Parameters.Add("@paramName", SqlDbType.NChar).Value = TextBox8.Text;
                cmd.Parameters.Add("@paramPhone", SqlDbType.NChar).Value = TextBox9.Text;
                cmd.Parameters.Add("@paramAddress", SqlDbType.NChar).Value = TextBox10.Text;
                cmd.Parameters.Add("@paramBirthday", SqlDbType.NChar).Value = TextBox11.Text;
                cmd.Parameters.Add("@paramGender", SqlDbType.NChar).Value = TextBox12.Text;
                int rows = cmd.ExecuteNonQuery(); //執行查詢
                if (rows == 0)
                {
                    Label2.Text = "查無此人 !";
                }
                else
                {
                    Label2.Text = "修改" + rows.ToString() + "筆資料 !";
                }
                cmd.Dispose();
                conn.Close();
                conn.Dispose();

                show();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) // 查詢
        {
            Panel3.Visible = true;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            TextBox13.Text = "";
            GridView2.Visible = false;
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
        }

        protected void Button8_Click(object sender, EventArgs e) // 確定查詢
        {
            if (TextBox13.Text == "")
            {
                Label3.Text = "有地方沒填";
            }
            else
            {
                Label3.Text = "";
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Person WHERE Id=@paramId", conn);
                cmd.Parameters.Add("@paramId", SqlDbType.NChar).Value = TextBox13.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView2.Visible = true;
                    GridView2.DataSource = dr;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.Visible = false;
                    Label3.Text = "查無此人 !";
                }
                cmd.Dispose();
                conn.Close();
                conn.Dispose();

                show();
            }
        }

        protected void Button9_Click(object sender, EventArgs e) // 確定刪除
        {
            if (TextBox14.Text == "")
            {
                Label4.Text = "有地方沒填";
            }
            else
            {
                Label4.Text = "";
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete From Person WHERE Id=@paramId", conn);
                cmd.Parameters.Add("@paramId", SqlDbType.NChar).Value = TextBox14.Text;
                int rows = cmd.ExecuteNonQuery(); //執行查詢
                if (rows == 0)
                {
                    Label4.Text = "查無此人 !";
                }
                else
                {
                    Label4.Text = "刪除" + rows.ToString() + "筆資料 !";
                }
                cmd.Dispose();
                conn.Close();
                conn.Dispose();

                show();
            }
        }

        protected void Button4_Click(object sender, EventArgs e) // 刪除
        {
            Panel4.Visible = true;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel5.Visible = false;
            TextBox14.Text = "";
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
        }

        protected void Button5_Click(object sender, EventArgs e) // 匯出成Excel
        {
            Panel4.Visible = false;
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel5.Visible = false;
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";

            IWorkbook wb = new XSSFWorkbook();
            ISheet ws;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            conn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From Person", conn);
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds, "person");
            DataTable dt = ds.Tables["person"];
            if (dt.TableName != string.Empty)
            {
                ws = wb.CreateSheet(dt.TableName);
            }
            else
            {
                ws = wb.CreateSheet("output");
            }

            ws.CreateRow(0);//第一行為欄位名稱
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.GetRow(0).CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ws.GetRow(i + 1).CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            FileStream file = new FileStream(@"C:\Users\Mily.Lin\Desktop\npoi.xls", FileMode.Create);//產生檔案
            wb.Write(file);
            file.Close();

            conn.Close();
            conn.Dispose();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中   
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[index];
            TableCell id = selectedRow.Cells[2];
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            conn.Open();
            switch (e.CommandName)
            {
                case "choose":
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = true;
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    TextBox15.Text = "";
                    TextBox16.Text = "";
                    TextBox17.Text = "";
                    TextBox18.Text = "";
                    TextBox19.Text = "";
                    TextBox20.Text = "";
                    Label1.Text = "";
                    Label2.Text = "";
                    Label3.Text = "";
                    Label4.Text = "";
                    Label5.Text = "";
                                      
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From Person WHERE Id=" + id.Text, conn);
                    DataSet ds = new DataSet();
                    sqlDataAdapter.Fill(ds, "person");
                    DataTable dt = ds.Tables["person"];
                    TextBox15.Text = dt.Rows[0]["Id"].ToString();
                    TextBox16.Text = dt.Rows[0]["Name"].ToString();
                    TextBox17.Text = dt.Rows[0]["Phone"].ToString();
                    TextBox18.Text = dt.Rows[0]["Address"].ToString();
                    TextBox19.Text = dt.Rows[0]["Birthday"].ToString();
                    TextBox20.Text = dt.Rows[0]["Gender"].ToString();
                    show();
                    break;
                case "del":
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    Panel5.Visible = false;
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    Label1.Text = "";
                    Label2.Text = "";
                    Label3.Text = "";
                    Label4.Text = "";
                    Label5.Text = "";
                    
                    SqlCommand cmd = new SqlCommand("Delete From Person WHERE Id=" + id.Text, conn);
                    cmd.ExecuteNonQuery(); //執行查詢
                    show();
                    break;
            }
            conn.Close();
            conn.Dispose();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Label5.Text = "";
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Person Set Name=@paramName,Phone=@paramPhone,Address=@paramAddress,Birthday=@paramBirthday,Gender=@paramGender WHERE Id=@paramId", conn);
            cmd.Parameters.Add("@paramId", SqlDbType.NChar).Value = TextBox15.Text;
            cmd.Parameters.Add("@paramName", SqlDbType.NChar).Value = TextBox16.Text;
            cmd.Parameters.Add("@paramPhone", SqlDbType.NChar).Value = TextBox17.Text;
            cmd.Parameters.Add("@paramAddress", SqlDbType.NChar).Value = TextBox18.Text;
            cmd.Parameters.Add("@paramBirthday", SqlDbType.NChar).Value = TextBox19.Text;
            cmd.Parameters.Add("@paramGender", SqlDbType.NChar).Value = TextBox20.Text;
            int rows = cmd.ExecuteNonQuery(); //執行查詢
            if (rows == 1)
            {
                Label5.Text = "修改" + rows.ToString() + "筆資料 !";
            }
            cmd.Dispose();
            conn.Close();
            conn.Dispose();

            show();
        }
    }
}