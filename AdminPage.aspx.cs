using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeregindenAsiriFazlaUltraSuperMukemmelProje
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-6ERU80V;Initial Catalog=Login;Integrated Security=True");
            SqlCommand comm = new SqlCommand("SELECT * FROM Sikayetler", conn);
            SqlDataReader reader;
            Database db = new Database();
            DataTable dt = new DataTable();

            //try
            //{

            //    conn.Open();
            //    reader = comm.ExecuteReader();
            //    myRepeater.DataSource = reader;
            //    myRepeater.DataBind();
            //    reader.Close();

            //}
            //catch
            //{
            //    Response.Write("HATA");
            //}
            //finally
            //{
            //    conn.Close();
            //}

            try

            {

                dt = db.GetDataTable2("SELECT * FROM Sikayetler");
                




                myRepeater.DataSource = dt;

                myRepeater.DataBind();

            }

            catch (Exception ex)

            {

                Response.Write("HAHAHAHAH");



            }

        }

        private DataSet GetData()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection sqlC = new SqlConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Sikayetler", sqlC);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }

        protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}