using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace KnowYourResult
{
    public partial class FilterAN : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CB37CHE\\SQLEXPRESS; Initial Catalog=StudentDetail; Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adpt;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //search by semester
        protected void Button1_Click(object sender, EventArgs e)
        {
            display(DropDownList1.SelectedItem.Text);
        }

        public void display(string sel)
        {
            con.Open();

            adpt = new SqlDataAdapter("select * from [" + sel + "]", con);
            dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sel = DropDownList1.SelectedItem.Text;
        }

        //search by batch
        public void displaybatch(string sel, string bach)
        {
            con.Open();

            adpt = new SqlDataAdapter("select * from [" + sel + "] where batch like '" + bach + "'", con);
            dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bach = DropDownList2.SelectedItem.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            displaybatch(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text);
        }

        // search by seatno

        public void searchdata(string sel, string search)
        {
            con.Open();
            string que = "select * from [" + sel + "] where seatnumber like '" + search + "'";
            adpt = new SqlDataAdapter(que, con);
            dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            searchdata(DropDownList1.SelectedItem.Text, TextBox1.Text);
        }

        //delete by seatno
        public void delete(string delete, string sel)
        {
            String query = "delete from [" + sel + "] where SEATNUMBER like '" + delete + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            delete(TextBox2.Text, DropDownList1.SelectedItem.Text);
        }
    }
}