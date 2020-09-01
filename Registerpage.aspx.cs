using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace GeregindenAsiriFazlaUltraSuperMukemmelProje
{
    public partial class Registerpage : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6ERU80V;Initial Catalog=Login;Integrated Security=True");
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool kullaniciAdiAlindiMi(string Email)
        {

            string query = "SELECT * FROM Kullanicilar WHERE Email= '" + Email + "'";
            DataRow dr = db.GetDataRow2(query);

            if (dr != null)
            {
                if (dr["Email"].ToString() == Email)
                {
                    Response.Write("Mail alınmis.");


                    return true;

                }
                return false;
            }
            else
            {
                return false;
            }
        }

        bool checkMail(string Email)
        {
            string query = "SELECT * FROM Kullanicilar WHERE Email= '" + Email + "'";
            bool emailVarMi = false;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                emailVarMi = true;
            }
            con.Close();
            return emailVarMi;



        }

        bool AdHataliMi(string ad)
        {
            foreach (char c in ad.ToCharArray())
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            if (txtName.Text.Equals("") || txtEmail.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                return true;
            }

            return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (AdHataliMi(txtName.Text))
            {
                Response.Write("<script>alert('DÜZGÜN İSİM GİR');</script>");
                return;
            }


            if (kullaniciAdiAlindiMi(txtEmail.Text))
            {
                Response.Write("Kullanici adi zaten kullaniliyor.");

                return;
            }
            else
            {
                Kullanici kullanici = new Kullanici(txtEmail.Text);
                string query = "INSERT INTO Kullanicilar(Name, Email, Password)VALUES('" + txtName.Text + "','" + txtEmail.Text + "', '" + txtPassword.Text + "')";

                cmd = new SqlCommand(query, con);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Loginpage.aspx");
            }
        }
   

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loginpage.aspx");
        }
    }
}