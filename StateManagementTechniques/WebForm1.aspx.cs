using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagementTechniques
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int x = 0;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {
                //create dataset
                ds = new DataSet();
                dt = new DataTable();
               // dr = new DataRow();
                //Design the name for data table
                dt.TableName = "Emp";
                dt.Columns.Add("Eno");
                dt.Columns.Add("Ename");
                dt.Columns.Add("Salary");
                ViewState["mydt"] = dt;
                ViewState["myds"] = ds;

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            x = x + 5000;
            ViewState["x"] = x;
            Label1.Text = x.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            x = (int)ViewState["x"];
            x = x + 1000;
            ViewState["x"] = x;
            Label1.Text = x.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
         {
            x = (int)ViewState["x"];
            x = x + 10;
            ViewState["x"] = x;
            Label1.Text = x.ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ViewState["x"] = "Maddineni";
            Label1.Text = "Value is stored in ViewState";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label1.Text = ViewState["x"].ToString();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["mydt"];
            ds = (DataSet)ViewState["myds"];
            //create NEW Row
            dr = dt.NewRow();
            //Insert the Record in New Row
            dr[0] = int.Parse(TextBox1.Text);
            dr[1] = TextBox2.Text;
            dr[2] = Double.Parse(TextBox3.Text);
            //Add the Row to data Table
            dt.Rows.Add(dr);
            //Merge Datatable to dataset
            ds.Merge(dt);
            dr.Delete();
            //Display data in GridView
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
           

        }
    }
}