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
    public partial class stats1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=REIGNZ\\SQLEXPRESS; Initial Catalog=StudentDetail; Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adpt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //sub grade
        public void Stats(string shift, string sub, string batch)
        {
            con.Open();
            string que = "select count(SEATNUMBER) as [Number of Student],count(case [" + sub + "] when 'O' then 1 else null end) as [Grade O],count(case [" + sub + "] when 'A' then 1 else null end) as [GRADE A],count(case [" + sub + "] when 'B' then 1 else null end) as [Grade B],count(case [" + sub + "] when 'C' then 1 else null end) as [Grade C],count(case [" + sub + "] when 'D' then 1 else null end) as [Grade D],count(case [" + sub + "] when 'E' then 1 else null end) as [Grade E],count(case [" + sub + "] when 'F' then 1 else null end) as [Grade F] from [" + shift + "] where batch like '" + batch + "'";
            adpt = new SqlDataAdapter(que, con);
            dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shift = DropDownList1.SelectedItem.Text;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sub = DropDownList2.SelectedItem.Text;
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string batch = DropDownList3.SelectedItem.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Stats(DropDownList1.SelectedItem.Text, DropDownList2.SelectedItem.Text, DropDownList3.SelectedItem.Text);
        }

        //stats by result
        public void result(string shift, string batch)
        {
            con.Open();
            string que = "select count(SEATNUMBER) as [Number of Student],count(case RESULT when 'P' then 1 else null end) as [PASSED],count(case RESULT when 'F' then 1 else null end) as [FAILED] from [" + shift + "]";
            adpt = new SqlDataAdapter(que, con);
            dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            result(DropDownList1.SelectedItem.Text, DropDownList3.SelectedItem.Text);
        }

        //overall grade

      /*  public void overall(string shift,string batch)
        {
            con.Open();
            string que = "select count(SEATNUMBER) as [Number of Student],count(case GRADE when 'O' then 1 else null end) as [Grade O],count(case GRADE when 'A' then 1 else null end) as [GRADE A],count(case GRADE when 'B' then 1 else null end) as [Grade B],count(case GRADE when 'C' then 1 else null end) as [Grade C],count(case GRADE when 'D' then 1 else null end) as [Grade D],count(case GRADE when 'E' then 1 else null end) as [Grade E],count(case GRADE when 'F' then 1 else null end) as [Grade F] from [" + shift + "] where batch like '" + batch + "'";
            adpt = new SqlDataAdapter(que, con);
            dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            overall(DropDownList1.SelectedItem.Text, DropDownList3.SelectedItem.Text);
        }*/
    }
}
