using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

namespace GeregindenAsiriFazlaUltraSuperMukemmelProje
{
    public partial class HomePage : System.Web.UI.Page
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Database db = new Database();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6ERU80V;Initial Catalog=Login;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

          
          
            if (!IsPostBack)
            {
                //listMarka.Items.Clear();
                ListModel.Items.Clear();
                ListSikayet.Items.Clear();
                MarkaDoldur();
                
                fillMarka();
                fillModel();
                fillSikayet();
                listMarka.SelectedIndex = 0;
            }

            if (listMarka.SelectedIndex == 0)
            {
                ListModel.Items.Clear();
                ListModel.Visible = false;
                modelLabel.Visible = false;
            }
            


            //if (!IsPostBack)
            //{
            //    getData("Sikayetler",null);
            //}
            ahaha.Text = "Hos geldin   " + Request.QueryString["UserName"];


            gizliii.Value = Request.QueryString["Id"];
            //    lblid.Text = Request.QueryString["id"];

        }

        //void getData(string SPName, SqlParameter SPParameter)
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["entityFramework"].ConnectionString;
        //    SqlConnection con1 = new SqlConnection(cs);
        //    SqlDataAdapter da = new SqlDataAdapter(SPName, con1);
        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        if(SPParameter != null)
        //    {
        //        da.SelectCommand.Parameters.Add(SPParameter);
        //    }
        //    DataSet DS = new DataSet();
        //    da.Fill(DS);
        //    return DS;
        //}


      
        void fillMarka()
        {


            string query1 = "SELECT * FROM Marka";
            SqlDataReader reader1;
            cmd = new SqlCommand(query1, con);
            
            try
            {
                con.Open();
                reader1 = cmd.ExecuteReader();

                //ListItem lsttm = new ListItem();

                //while (reader1.Read())
                //{
                //    int _ID = Convert.ToInt32(reader1["Id"].ToString());
                //    string _Marka = reader1["Marka"].ToString();

                //    //lsttm.Value = _ID.ToString();
                //    //lsttm.Text = _Marka;


                //    //listMarka.Items.Add(lsttm);

                //}

                listMarka.DataSource = reader1;
                listMarka.DataValueField = "IdMarka";
                listMarka.DataTextField = "Marka";
                listMarka.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("HATA: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        void fillModel()
        {

            string query1 = "SELECT * FROM KarisikModel";
            SqlDataReader reader1;
            cmd = new SqlCommand(query1, con);

            try
            {
                con.Open();
                reader1 = cmd.ExecuteReader();


                ListModel.DataSource = reader1;
                ListModel.DataValueField = "IdMarka";
                ListModel.DataTextField = "Model";
                ListModel.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("HATA: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        void fillSikayet()
        {
        
            string query1 = "SELECT * FROM Sikayet";
            SqlDataReader reader1;
            cmd = new SqlCommand(query1, con);

            try
            {
                con.Open();
                reader1 = cmd.ExecuteReader();


                ListSikayet.DataSource = reader1;
                ListSikayet.DataValueField = "IdSikayet";
                ListSikayet.DataTextField = "Sikayet";
                ListSikayet.DataBind();
            }
            
            catch (Exception ex)
            {
                Response.Write("HATA: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        void getirirMisin()
        {
            string query = "SELECT Marka, Model, Sikayet FROM Sikayetler WHERE UserId='" + gizliii.Value + "'";
            DataRow dr = db.GetDataRow2(query);
            if (dr != null)
            {
                string EKLEĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞ = (string)dr["Marka"] + "  " + dr["Model"] + "  " + dr["Sikayet"];
                listGonderilen.Items.Add(EKLEĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞ);
            }


        }





        protected void Button3_Click(object sender, EventArgs e)
        {
            listGonderilen.Items.Clear();
            listYapilan.Items.Clear();
            string query = "SELECT Marka, Model, Sikayet FROM Sikayetler WHERE  UserId='" + gizliii.Value + "' and Durum='" + "BEKLEMEDE" + "'";
            DataTable dt = db.GetDataTable2(query);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string EKLEĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞ = (string)row["Marka"] + "  " + row["Model"] + "  " + row["Sikayet"];
                    listGonderilen.Items.Add(new ListItem(EKLEĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞ));
                }


            }

            string query1 = "SELECT Marka, Model, Sikayet FROM Sikayetler WHERE  UserId='" + gizliii.Value + "' and Durum='" + "ISLEME ALINDI" + "'";
            DataTable dt1 = db.GetDataTable2(query1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    string EKLEĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞ = (string)row["Marka"] + "  " + row["Model"] + "  " + row["Sikayet"];
                    listYapilan.Items.Add(new ListItem(EKLEĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞĞ));
                }


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loginpage.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var dateTime = DateTime.Now;
            string query = "INSERT INTO Sikayetler(UserId, Marka, Model, Sikayet, Yorum, Durum, Tarih)VALUES(@UserId, @Marka, @Model, @Sikayet, @Yorum, @Durum, @Tarih)";
            cmd = new SqlCommand(query, con);
            con.Open();
           
            cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(gizliii.Value));
            cmd.Parameters.AddWithValue("@Marka", listMarka.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Model", ListModel.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Tarih", dateTime);
            cmd.Parameters.AddWithValue("@Durum", "BEKLEMEDE");
            cmd.Parameters.AddWithValue("@Yorum", txtYorum.Text);
            if (ListSikayet.SelectedItem.Text == "Diger")
            {
                cmd.Parameters.AddWithValue("@Sikayet", txtSikayetPlus.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Sikayet", ListSikayet.SelectedItem.Text);
            }
            cmd.ExecuteNonQuery();



            con.Close();

        }

        protected void listMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = db.getle("SELECT * FROM KarisikModel WHERE IdMarka='"+ listMarka.SelectedItem.Value+"'");
            ListModel.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListModel.Items.Add(dt.Rows[i]["Model"].ToString());
                //ListModel.Items[i].Value = dt.Rows[i]["Id"].ToString();
                ListModel.Visible = true;
                modelLabel.Visible = true;
            }

            if (listMarka.SelectedIndex == 0)
            {
                ListModel.Items.Clear();
                ListModel.Visible = false;
                modelLabel.Visible = false;
            }
         
            
        }
        void MarkaDoldur()
        {
            DataTable dt = db.getle("SELECT * FROM Marka");
            listMarka.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listMarka.Items.Add(dt.Rows[i]["Marka"].ToString());
                listMarka.Items[i].Value = dt.Rows[i]["IdMarka"].ToString();
            }
        }

        protected void ListSikayet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListSikayet.SelectedItem.Text == "Diger")
            {
                labelSikayet.Visible = true;
                txtSikayetPlus.Visible = true;
            }
            else
            {
                labelSikayet.Visible = false;
                txtSikayetPlus.Visible = false;
            }
        }
    }


}