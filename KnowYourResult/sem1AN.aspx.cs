using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;


namespace KnowYourResult
{
    public partial class sem1AN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String seatno;
            String sname, oopg, sepmg, coag, itmg, spg, labpg, minig, result;
            String oopt, oopi, oopc, oopgp, oopto, oopcgp;
            String sepmt, sepmi, sepmc, sepmgp, sepmto, sepmcgp;
            String coat, coai, coac, coagp, coato, coacgp;
            String itmt, itmi, itmc, itmgp, itmto, itmcgp;
            String spt, spi, spc, spgp, spto, spcgp;
            String lab1, lab2, labp, labpt, labpc, labpgp, labpcgp;
            String lab3, lab4, mini, minit, minic, minigp, minicgp;
            String g, gpa;
            float grade;

            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(" ", "");
            FileUpload1.SaveAs(Server.MapPath("~/ExcelFile/") + path);
            String ExcelPath = Server.MapPath("~/ExcelFile/") + path;
            OleDbConnection mycon = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties='Excel 8.0;Empty Text Mode=EMPTYASNULL'; Persist Security Info = False;");
            mycon.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [shift1_1$a4:be]", mycon);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    // Response.Write("<br/>"+dr[0].ToString());
                    seatno = dr[0].ToString();
                    sname = dr[1].ToString();
                    oopt = dr[2].ToString();
                    oopi = dr[3].ToString();
                    oopto = dr[4].ToString();
                    oopc = dr[5].ToString();
                    oopg = dr[6].ToString();
                    oopgp = dr[7].ToString();
                    oopcgp = dr[8].ToString();
                    sepmt = dr[9].ToString();
                    sepmi = dr[10].ToString();
                    sepmto = dr[11].ToString();
                    sepmc = dr[12].ToString();
                    sepmg = dr[13].ToString();
                    sepmgp = dr[14].ToString();
                    sepmcgp = dr[15].ToString();
                    coat = dr[16].ToString();
                    coai = dr[17].ToString();
                    coato = dr[18].ToString();
                    coac = dr[19].ToString();
                    coag = dr[20].ToString();
                    coagp = dr[21].ToString();
                    coacgp = dr[22].ToString();
                    itmt = dr[23].ToString();
                    itmi = dr[24].ToString();
                    itmto = dr[25].ToString();
                    itmc = dr[26].ToString();
                    itmg = dr[27].ToString();
                    itmgp = dr[28].ToString();
                    itmcgp = dr[29].ToString();
                    spt = dr[30].ToString();
                    spi = dr[31].ToString();
                    spto = dr[32].ToString();
                    spc = dr[33].ToString();
                    spg = dr[34].ToString();
                    spgp = dr[35].ToString();
                    spcgp = dr[36].ToString();
                    lab1 = dr[37].ToString();
                    lab2 = dr[38].ToString();
                    labp = dr[39].ToString();
                    labpt = dr[40].ToString();
                    labpc = dr[41].ToString();
                    labpg = dr[42].ToString();
                    labpgp = dr[43].ToString();
                    labpcgp = dr[44].ToString();
                    lab3 = dr[45].ToString();
                    lab4 = dr[46].ToString();
                    mini = dr[47].ToString();
                    minit = dr[48].ToString();
                    minic = dr[49].ToString();
                    minig = dr[50].ToString();
                    minigp = dr[51].ToString();
                    minicgp = dr[52].ToString();
                    g = dr[53].ToString();
                    gpa = dr[54].ToString();
                    grade = float.Parse(dr[55].ToString());
                    result = dr[56].ToString();
                    savedata(seatno, sname, oopt, oopi, oopto, oopc, oopg, oopgp, oopcgp, sepmt, sepmi, sepmto, sepmc, sepmg, sepmgp, sepmcgp, coat, coai, coato, coac, coag, coagp, coacgp, itmt, itmi, itmto, itmc, itmg, itmgp, itmcgp, spt, spi, spto, spc, spg, spgp, spcgp, lab1, lab2, labp, labpt, labpc, labpg, labpgp, labpcgp, lab3, lab4, mini, minit, minic, minig, minigp, minicgp, g, gpa, grade, result, DropDownList1.SelectedItem.Text);
                }
                else
                {
                    break;
                }

            }
            Label3.Text = "Data Has Been Saved Successfully";


        }

        private void savedata(String seatno1, String sname1, String oopt1, String oopi1, String oopto1, String oopc1, String oopg1, String oopgp1, String oopcgp1, String sepmt1, String sepmi1, String sepmto1, String sepmc1, String sepmg1, String sepmgp1, String sepmcgp1, String coat1, String coai1, String coato1, String coac1, String coag1, String coagp1, String coacgp1, String itmt1, String itmi1, String itmto1, String itmc1, String itmg1, String itmgp1, String itmcgp1, String spt1, String spi1, String spto1, String spc1, String spg1, String spgp1, String spcgp1, String lab11, String lab21, String labp1, String labpt1, String labpc1, String labpg1, String labpgp1, String labpcgp1, String lab31, String lab41, String mini1, String minit1, String minic1, String minig1, String minigp1, String minicgp1, String g1, String gpa1, float grade1, String result1, String batch)
        {
            String query = "insert into sem1m values('" + seatno1 + "','" + sname1 + "','" + oopt1 + "','" + oopi1 + "','" + oopt1 + "','" + oopc1 + "','" + oopg1 + "','" + oopgp1 + "','" + oopcgp1 + "','" + sepmt1 + "','" + sepmi1 + "','" + sepmto1 + "','" + sepmc1 + "','" + sepmg1 + "','" + sepmgp1 + "','" + sepmcgp1 + "','" + coat1 + "','" + coai1 + "','" + coato1 + "','" + coac1 + "','" + coag1 + "','" + coagp1 + "','" + coacgp1 + "','" + itmt1 + "','" + itmi1 + "','" + itmto1 + "','" + itmc1 + "','" + itmg1 + "','" + itmgp1 + "','" + itmcgp1 + "','" + spt1 + "','" + spi1 + "','" + spto1 + "','" + spc1 + "','" + spg1 + "','" + spgp1 + "','" + spcgp1 + "','" + lab11 + "','" + lab21 + "','" + labp1 + "','" + labpt1 + "','" + labpc1 + "','" + labpg1 + "','" + labpgp1 + "','" + labpcgp1 + "','" + lab31 + "','" + lab41 + "','" + mini1 + "','" + minit1 + "','" + minic1 + "','" + minig1 + "','" + minigp1 + "','" + minicgp1 + "','" + g1 + "','" + gpa1 + "','" + grade1 + "','" + result1 + "','" + batch + "')";
            String mycon = "Data Source=DESKTOP-CB37CHE\\SQLEXPRESS; Initial Catalog=StudentDetail; Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String batch = DropDownList1.SelectedItem.Text;
        }
    }
}