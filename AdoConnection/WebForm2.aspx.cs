using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
 using System.Configuration;

namespace AdoConnection
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(conn))
            //{
            //    SqlDataAdapter da = new SqlDataAdapter("spgetall", con);
            //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);
            //    ds.Tables[0].TableName = "product";
            //    ds.Tables[1].TableName = "categories";

            //    GridView1.DataSource = ds.Tables["product"];
            //    GridView1.DataBind();

            //    GridView2.DataSource = ds.Tables["categories"];
            //    GridView2.DataBind();

            //}
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] == null)
            {
                string conn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spgetall", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Cache["Data"] = ds;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    Label1.Text = "data loaded from database";
                }
            }
            else
            {
                GridView1.DataSource = Cache["Data"];
                GridView1.DataBind();
                Label1.Text = "data loaded from cache";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null)
            {
                Cache.Remove("Data");
                Label1.Text = "Cache cleared successfully";
            }
            else
            {
                Label1.Text = " no Cache tp clear successfully";
            }
        }
    }
}