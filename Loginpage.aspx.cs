using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data;

namespace GeregindenAsiriFazlaUltraSuperMukemmelProje
{


    public partial class Loginpage : System.Web.UI.Page
    {


        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6ERU80V;Initial Catalog=Login;Integrated Security=True");
        Database db = new Database();
        string adminUserName = "123";
        string adminPassword = "123";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string query = "SELECT Id FROM Kullanicilar WHERE Email='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'";

            DataRow dr = db.GetDataRow2(query);
            if (dr != null)
            {
                Response.Redirect("HomePage.aspx?UserName=" + txtUserName.Text + "&id=" + dr["Id"].ToString());

            }
            else
            {
                Label4.ForeColor = System.Drawing.Color.Red;
                Label4.Visible = true;
                Label4.Text = "Your mail or password is wrong";

            }

            if (adminUserName == txtUserName.Text & adminPassword == txtPassword.Text)
            {
                Response.Redirect("admen.aspx");
            }




            //int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            //con.Close();
            //if (temp == 1)
            //{
            //    Response.Redirect("HomePage.aspx");
            //}
            //else
            //{
            //    Label4.ForeColor = System.Drawing.Color.Red;
            //    Label4.Text = "Your mail or password is wrong";
            //}


        }
    }
}