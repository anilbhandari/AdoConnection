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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select * from tblinventory", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                productgridview.DataSource = ds;
                productgridview.DataBind();


                //SqlCommand cmd = new SqlCommand(" select * from tblinventory; select * from tblproductcategories",con);
                //con.Open();
                //    using (SqlDataReader rdr= cmd.ExecuteReader())
                //    {
                //        productgridview.DataSource = rdr;
                //        productgridview.DataBind();
                //        while (rdr.NextResult())
                //        {
                //            categoriesGridView.DataSource = rdr;
                //            categoriesGridView.DataBind();
                //        }
                //    }
                //}
            }
        }
    }
}
