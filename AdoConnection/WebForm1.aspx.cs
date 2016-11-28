using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace AdoConnection
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string Connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //SqlConnection con = new SqlConnection(Connection);
            //SqlCommand cmd = new SqlCommand("select * from employees", con);
            //con.Open();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //GridView1.DataSource = rdr;
            //GridView1.DataBind();
            //con.Close();

            //string cs = "data source=.;database=adonet; integrated security=SSPI";
            //SqlConnection con = new SqlConnection(cs);
            //SqlCommand cmd = new SqlCommand("select * from employees", con);
            //con.Open();
            //GridView1.DataSource= cmd.ExecuteReader();
            //GridView1.DataBind();
            //con.Close();
         

        }
        //to prevent from sql injection using parameterized query
        protected void Button1_Click(object sender, EventArgs e)
        {
           string connection= ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("select * from employees where firstname like @firstname", con);
                cmd.Parameters.AddWithValue("@firstname", TextBox1.Text + "%");
                if (TextBox1.Text == string.Empty)
                {
                    Response.Write("write something");
                }
                else
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                   
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }
        //to prevent from sql injection using store procedure
        protected void Button2_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con= new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name",TextBox2.Text);
                cmd.Parameters.AddWithValue("@gender",DropDownList1.Text);
                cmd.Parameters.AddWithValue("@salary", TextBox4.Text);

                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@employeeid";
                sp.SqlDbType = SqlDbType.Int;
                sp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sp);

                con.Open();
                cmd.ExecuteNonQuery();
                Label1.Text = "datasaved ";
              



            }
        }
    }
}