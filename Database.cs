using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database
{
    //public SqlConnection Connection = new SqlConnection(@"Data Source=HAKAN\HAKANAYD;Timeout=400;Initial Catalog=BASARI_B2B;Persist Security Info=True;User ID=sa;Password=11223344");
    public SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-6ERU80V;Initial Catalog=Login;Integrated Security=True");
    //public SqlConnection Connection = new SqlConnection(@"Data Source=192.168.2.6;Timeout=400;Initial Catalog=PROSO_B2B;Persist Security Info=True;User ID=sa;Password=1qaz2wsX");
    public Database() { }
    public Database(string sqlConnStr)
    {
        this.Connection = new SqlConnection(sqlConnStr);
    }
    public int Count(string tabloAd)
    {
        int _result = 0;

        try
        { _result = Convert.ToInt32(GetDataCell2("select count(*) from " + tabloAd)); }
        catch { _result = 0; }

        return _result;
    }
    public int Count(string tabloAd, string where)
    {
        int _result = 0;

        try
        { _result = Convert.ToInt32(GetDataCell2("select count(*) from " + tabloAd + " where " + where)); }
        catch { _result = 0; }

        return _result;
    }
    public DataSet GetDataSet(string sql)
    {
        if (Connection.State == ConnectionState.Open) Connection.Close();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
        DataSet ds = new DataSet();
        try
        { adapter.Fill(ds); }
        catch (SqlException ex)
        { throw new Exception(ex.Message + " (" + sql + ")"); }

        return ds;
    }
    public int Exec(string spAdi, ArrayList arryParam)
    {
        if (Connection.State == ConnectionState.Open) Connection.Close();
        SqlCommand command = new SqlCommand(spAdi, Connection);
        command.CommandType = CommandType.StoredProcedure;

        foreach (ListItem param in arryParam)
            command.Parameters.AddWithValue(param.Text, param.Value);

        int affectedRowNumber = 0;
        command.Connection.Open();
        try
        { affectedRowNumber = command.ExecuteNonQuery(); }
        catch (SqlException ex)
        { throw new Exception(ex.Message); }
        finally
        { command.Connection.Close(); }

        return affectedRowNumber;
    }
    public DataTable GetDataTable(string spAdi)
    {
        if (Connection.State == ConnectionState.Open) Connection.Close();
        SqlCommand Cmd = new SqlCommand(spAdi, Connection);
        Cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter adapter = new SqlDataAdapter(Cmd);

        DataTable dt = new DataTable();

        try
        { adapter.Fill(dt); }
        catch (SqlException ex)
        { throw new Exception(ex.Message + " (" + spAdi + ")"); }
        return dt;
    }
    public DataTable GetDataTable(string spAdi, ArrayList arryParam)
    {
        if (Connection.State == ConnectionState.Open) Connection.Close();
        SqlCommand Cmd = new SqlCommand(spAdi, Connection);
        Cmd.CommandType = CommandType.StoredProcedure;

        foreach (ListItem param in arryParam)
            Cmd.Parameters.AddWithValue(param.Text, param.Value);

        SqlDataAdapter adapter = new SqlDataAdapter(Cmd);
        adapter.SelectCommand.CommandTimeout = 1200;
        DataTable dt = new DataTable();

        try
        { adapter.Fill(dt); }
        catch (SqlException ex)
        { throw new Exception(ex.Message + " (" + spAdi + ")"); }
        return dt;
    }
    public DataTable GetDataTable2(string sql)
    {
        if (Connection.State == ConnectionState.Open) Connection.Close();
        Connection.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, Connection);
        DataTable dt = new DataTable();

        try
        { adapter.Fill(dt); }
        catch (SqlException ex)
        {throw new Exception(ex.Message + " (" + sql + ")"); }
        Connection.Close();
        return dt;
    }
    public DataRow GetDataRow(string spAdi)
    {
        DataTable table = GetDataTable(spAdi);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0];
    }
    public DataRow GetDataRow(string spAdi, ArrayList arryParam)
    {
        DataTable table = GetDataTable(spAdi, arryParam);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0];
    }
    public DataRow GetDataRow2(string sql)
    {
        DataTable table = GetDataTable2(sql);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0];
    }
    public string GetDataCell(string spAdi)
    {
        DataTable table = GetDataTable(spAdi);
        if (table.Rows.Count == 0)
            return null;
        return table.Rows[0][0].ToString();   
    }
    public string GetDataCell(string spAdi, ArrayList arryParam)
    {
        DataTable table = GetDataTable(spAdi, arryParam);
        if (table.Rows.Count == 0)
            return null;
        return table.Rows[0][0].ToString();
    }
    public string GetDataCell2(string sql)
    {
        DataTable table = GetDataTable2(sql);
        if (table.Rows.Count == 0)
            return null;
        return table.Rows[0][0].ToString();
    }    
    public int Exec(string sql)
    {
        if (Connection.State == ConnectionState.Open) Connection.Close();
        SqlCommand command = new SqlCommand(sql, Connection);
        command.Connection.Open();

        int affectedRowNumber = 0;
        try
        {
            affectedRowNumber = command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sql + ")");
        }
        finally
        {
            command.Connection.Close();
        }
        return affectedRowNumber;
    }
    public int Exec2(string sql)
    {
        if (Connection.State == ConnectionState.Open) Connection.Close();
        SqlCommand command = new SqlCommand(sql, Connection);
        command.Connection.Open();

        int affectedRowNumber = 0;
        try
        {
            affectedRowNumber = Convert.ToInt32(command.ExecuteScalar());
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sql + ")");
        }
        finally
        {
            command.Connection.Close();
        }
        return affectedRowNumber;
    }
    public DataTable getle(string query)
    {

        SqlConnection con = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        try
        {
            adapter.Fill(dt);
        }
        catch (Exception ex)
        {
            throw new Exception((ex.Message) + "(" + query + ")");
        }
        con.Close();
        return dt;
    }
    public SqlConnection baglan()
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6ERU80V;Initial Catalog=Login;Integrated Security=True");
        con.Open();
        return con;
    }

}