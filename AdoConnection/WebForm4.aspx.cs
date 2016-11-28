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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                string query = "select * from tblstudents where id=" + txtStudentID.Text;
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Students");
                ViewState["sql_query"] = query;
                ViewState["DATASET"] = ds;
                if (ds.Tables["Students"].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables["Students"].Rows[0];
                    txtStudentName.Text = dr["Name"].ToString();
                    txtTotalMarks.Text = dr["TotalMarks"].ToString();
                    ddlGender.SelectedValue = dr["Gender"].ToString();
                }

                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "No student with ID=" + txtStudentID.Text;
                }

                }
            }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            
               SqlDataAdapter da = new SqlDataAdapter((string)ViewState["sql_query"],con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
           DataSet ds= (DataSet)ViewState["DATASET"];
            if (ds.Tables["students"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["students"].Rows[0];
                dr["Name"] = txtStudentName.Text;
                dr["Gender"] = ddlGender.SelectedValue;
                dr["TotalMarks"] = txtTotalMarks.Text;
            }
            else
            {

            }
            int rowsupdated = da.Update(ds, "Students");
            if (rowsupdated > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = rowsupdated.ToString() + "row(s) updated";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = rowsupdated.ToString() + " norow(s) updated";
            }

          
            
        }
    }
    } 