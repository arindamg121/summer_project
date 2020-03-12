using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KnowYourResult.Classes;
using System.IO;
using iTextSharp.text;

using iTextSharp.text.pdf;
namespace KnowYourResult
{
    public partial class GetResult : System.Web.UI.Page
    {
        FileInfo file1 = new FileInfo(@"D:\result.csv");
        StreamWriter writ;
        StreamReader read=new StreamReader(@"D:\shift1.txt");
        FileInfo file2 = new FileInfo(@"D:\shift1_1.csv");
        StreamWriter writ1;

        StreamReader read1 = new StreamReader(@"D:\shift2.txt");
        FileInfo file3 = new FileInfo(@"D:\shift22.csv");
        StreamWriter writ2;

        FileInfo summary = new FileInfo(@"D:\summary.csv");
        StreamWriter sumwrite;
        
        string[] a;
        string[] b;
        string filecontent = null, filecontent1 = null;
        string texts = null, texts1 = null;
                
        
        Result r = new Result();
        int start = 0;
        int end = 0;
        String res;
        int t_sub1 = 0, t_sub2=0, t_sub3=0, t_sub4=0, t_sub5=0, t_sub6=0, t_sub7=0;
        int p_sub1 = 0, p_sub2 = 0, p_sub3 = 0, p_sub4 = 0, p_sub5 = 0, p_sub6 = 0, p_sub7 = 0;
        int f_sub1 = 0, f_sub2 = 0, f_sub3 = 0, f_sub4 = 0, f_sub5 = 0, f_sub6 = 0, f_sub7 = 0;
        double ps_sub1 = 0, ps_sub2 = 0, ps_sub3 = 0, ps_sub4 = 0, ps_sub5 = 0, ps_sub6 = 0, ps_sub7 = 0;

        //grade cal
        int o_sub1 = 0, o_sub2 = 0, o_sub3 = 0, o_sub4 = 0, o_sub5 = 0, o_sub6 = 0, o_sub7 = 0;
        int a_sub1 = 0, a_sub2 = 0, a_sub3 = 0, a_sub4 = 0, a_sub5 = 0, a_sub6 = 0, a_sub7 = 0;
        int b_sub1 = 0, b_sub2 = 0, b_sub3 = 0, b_sub4 = 0, b_sub5 = 0, b_sub6 = 0, b_sub7 = 0;
        int c_sub1 = 0, c_sub2 = 0, c_sub3 = 0, c_sub4 = 0, c_sub5 = 0, c_sub6 = 0, c_sub7 = 0;
        int d_sub1 = 0, d_sub2 = 0, d_sub3 = 0, d_sub4 = 0, d_sub5 = 0, d_sub6 = 0, d_sub7 = 0;
        int e_sub1 = 0, e_sub2 = 0, e_sub3 = 0, e_sub4 = 0, e_sub5 = 0, e_sub6 = 0, e_sub7 = 0;
        int pa_sub1 = 0, pa_sub2 = 0, pa_sub3 = 0, pa_sub4 = 0, pa_sub5 = 0, pa_sub6 = 0, pa_sub7 = 0;
        int fa_sub1 = 0, fa_sub2 = 0, fa_sub3 = 0, fa_sub4 = 0, fa_sub5 = 0, fa_sub6 = 0, fa_sub7 = 0;
        int sub1_60 = 0, sub2_60 = 0, sub3_60 = 0, sub4_60 = 0, sub5_60 = 0, sub6_60 = 0, sub7_60 = 0;
        int below1_60 = 0, below2_60 = 0, below3_60 = 0, below4_60 = 0, below5_60 = 0, below6_60 = 0, below7_60 = 0;
        int totalpass=0;
        int totalf = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DirectoryInfo info = new DirectoryInfo(Server.MapPath("~/Files/"));
                FileInfo[] files = info.GetFiles("*.pdf");
                foreach (FileInfo file in files)
                {
                    ListBox1.Items.Add(file.Name);
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                start = int.Parse(Starting.Text);
                end = int.Parse(ending.Text);

                r.setSubjects(ListBox1.SelectedItem.Text);

                filecontent = read.ReadLine();

                while (filecontent != null)
                {
                    texts += filecontent + " ";
                    filecontent = read.ReadLine();
                }
                a = texts.Split(' ');
                
                filecontent1 = read1.ReadLine();

                while (filecontent1 != null)
                {
                    texts1 += filecontent1 + " ";
                    filecontent1 = read1.ReadLine();
                }
                b = texts1.Split(' ');
                sumwrite = summary.CreateText();

                writ = file1.CreateText();
                writ1 = file2.CreateText();
                writ2 = file3.CreateText();


                writ.Write("," + "," + "," + "," + "," + ",");
                writ1.Write("," + "," + "," + "," + "," + ",");
                writ2.Write("," + "," + "," + "," + "," + ",");

                writ.WriteLine("DEMO RESULT");
                writ1.WriteLine("First SHIFT RESULT");
                writ2.WriteLine("Second SHIFT RESULT");

                writ.Write("SEAT NUMBER" + ",");
                writ1.Write("SEAT NUMBER" + ",");
                writ2.Write("SEAT NUMBER" + ",");

                writ.Write("NAME OF STUDENT" + ",");
                writ1.Write("NAME OF STUDENT" + ",");
                writ2.Write("NAME OF STUDENT" + ",");

                writ.Write(r.subject1 + "," + "," + "," + "," + "," + "," + ",");
                writ1.Write(r.subject1 + "," + "," + "," + "," + "," + "," + ",");
                writ2.Write(r.subject1 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.subject2 + "," + "," + "," + "," + "," + "," + ",");
                writ1.Write(r.subject2 + "," + "," + "," + "," + "," + "," + ",");
                writ2.Write(r.subject2 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.subject3 + "," + "," + "," + "," + "," + "," + ",");
                writ1.Write(r.subject3 + "," + "," + "," + "," + "," + "," + ",");
                writ2.Write(r.subject3 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.subject4 + "," + "," + "," + "," + "," + "," + ",");
                writ1.Write(r.subject4 + "," + "," + "," + "," + "," + "," + ",");
                writ2.Write(r.subject4 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.subject5 + "," + "," + "," + "," + "," + "," + ",");
                writ1.Write(r.subject5 + "," + "," + "," + "," + "," + "," + ",");
                writ2.Write(r.subject5 + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.lab1 + "," + "," + "," + "," + "," + "," + "," + ",");
                writ1.Write(r.lab1 + "," + "," + "," + "," + "," + "," + "," + ",");
                writ2.Write(r.lab1 + "," + "," + "," + "," + "," + "," + "," + ",");

                writ.Write(r.lab2);
                writ1.Write(r.lab2);
                writ2.Write(r.lab2);

                writ.WriteLine(",");
                writ1.WriteLine(",");
                writ2.WriteLine(",");

                writ.Write("," + ",");
                writ1.Write("," + ",");
                writ2.Write("," + ",");
                for (int i = 0; i <= 4; i++)
                {
                    writ.Write("THEORY,");
                    writ.Write("INTERNAL,");
                    writ.Write("TOTAL,");
                    writ.Write("CREDIT,");
                    writ.Write("GRADE,");
                    writ.Write("GP,");
                    writ.Write("C*GP,");

                    writ1.Write("THEORY,");
                    writ1.Write("INTERNAL,");
                    writ1.Write("TOTAL,");
                    writ1.Write("CREDIT,");
                    writ1.Write("GRADE,");
                    writ1.Write("GP,");
                    writ1.Write("C*GP,");

                    writ2.Write("THEORY,");
                    writ2.Write("INTERNAL,");
                    writ2.Write("TOTAL,");
                    writ2.Write("CREDIT,");
                    writ2.Write("GRADE,");
                    writ2.Write("GP,");
                    writ2.Write("C*GP,");
                }
                for (int i = 5; i <= 6; i++)
                {
                    writ.Write("25\'\'11,");
                    writ.Write("25\'\'11,");
                    writ.Write("50\'\'23,");
                    writ.Write("Total,");
                    writ.Write("CREDIT,");
                    writ.Write("GRADE,");
                    writ.Write("GP,");
                    writ.Write("C*GP,");

                    writ1.Write("25\'\'11,");
                    writ1.Write("25\'\'11,");
                    writ1.Write("50\'\'23,");
                    writ1.Write("Total,");
                    writ1.Write("CREDIT,");
                    writ1.Write("GRADE,");
                    writ1.Write("GP,");
                    writ1.Write("C*GP,");

                    writ2.Write("25\'\'11,");
                    writ2.Write("25\'\'11,");
                    writ2.Write("50\'\'23,");
                    writ2.Write("Total,");
                    writ2.Write("CREDIT,");
                    writ2.Write("GRADE,");
                    writ2.Write("GP,");
                    writ2.Write("C*GP,");
                }
                writ.Write("G,");
                writ.Write("GPA,");
                writ.Write("Grade,");
                writ.Write("Result,");
                writ.WriteLine(",");
                writ.WriteLine(",");

                writ1.Write("G,");
                writ1.Write("GPA,");
                writ1.Write("Grade,");
                writ1.Write("Result,");
                writ1.WriteLine(",");
                writ1.WriteLine(",");

                writ2.Write("G,");
                writ2.Write("GPA,");
                writ2.Write("Grade,");
                writ2.Write("Result,");
                writ2.WriteLine(",");
                writ2.WriteLine(",");

                //direct result generate file
                if (FileUpload1.HasFile && FileUpload1.FileName.Contains("MCA") ||
                    FileUpload1.FileName.Contains("M.C.A") && FileUpload1.FileName.Contains("CBSGS") ||
                    FileUpload1.FileName.Contains("CHOICE"))
                {
                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                    if (fileExtension.ToLower() != ".pdf")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Only PDF files')", true);
                    }
                    else
                    {
                        int fileSize = FileUpload1.PostedFile.ContentLength;
                        if (fileSize > 2100000) //2 mb
                        {
                            //208911
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Kindly check the size')", true);
                        }
                        else
                        {
                            //r.setSubjects(FileUpload1.FileName);
                            /*FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Files/") + FileUpload1.FileName);
                            r.Extract_Text(Server.MapPath("~/Files/" + FileUpload1.FileName));
                            for(int re=start;  re<=end;   re++)
                            {
                                if (r.FilterDetails(Convert.ToString(re))==true)
                                { 
                                    //writ.Write("," + r.FilterDetails(Convert.ToString(re))+",");
                                    generateFinalResult(r.GenerateMarksheet(), r, ref writ);
                                }
                            }*/

                        }
                    }
                }
                else if (ListBox1.SelectedIndex != -1 &&
                    ListBox1.SelectedItem.Text.Contains("MCA")
                    || ListBox1.SelectedItem.Text.Contains("M.C.A") && ListBox1.SelectedItem.Text.Contains("CHOICE")
                    || ListBox1.SelectedItem.Text.Contains("CBSGS"))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('done!" + ListBox1.SelectedItem.Text + "')", true);


                    r.Extract_Text(Server.MapPath("~/Files/" + ListBox1.SelectedItem.Text));
                    for (int re = start; re <= end; re++)
                    {
                        if (r.FilterDetails(Convert.ToString(re)) == true)
                        {
                            //writ.Write("," + r.FilterDetails(Convert.ToString(re))+",");
                            generateFinalResult(r.GenerateMarksheet(), r, ref writ);
                        }
                    }

                    //new shift 1 & 2 (3/3/20)
                    /*for (int i = 0; i < a.Length; i++)
                    {
                         for(int re1=start;  re1<=end;   re1++)
                         {
                             if(a[i]==Convert.ToString(re1))
                             {
                                  if (r.FilterDetails(Convert.ToString(a[i])) == true)
                                  {
                                      generateFinalResult1(r.GenerateMarksheet(), r,writ1);
                                  }
                             }
                         }
                     }
                    
                    for (int i = 0; i < b.Length; i++)
                    {
                        for (int re1 = start; re1 <= end; re1++)
                        {
                            if (b[i] == Convert.ToString(re1))
                            {
                                if (r.FilterDetails(Convert.ToString(b[i])) == true)
                                {
                                    generateFinalResult2(r.GenerateMarksheet(), r, writ2);
                                }
                            }
                        }
                    }*/
                    
                    int totalstudent = r.TotalStudent;
                    writ.WriteLine("," + ",");
                    writ.Write(",Total Students," + totalstudent);
                    writ.WriteLine(",");

                    writ.Write(",Total Students Appeared," + totalstudent);
                    writ.WriteLine(",");


                    decimal sum_sub1 = t_sub1 / r.TotalStudent;
                    decimal sum_sub2 = t_sub2 / r.TotalStudent;
                    decimal sum_sub3 = t_sub3 / r.TotalStudent;
                    decimal sum_sub4 = t_sub4 / r.TotalStudent;
                    decimal sum_sub5 = t_sub5 / r.TotalStudent;
                    decimal sum_sub6 = t_sub6 / r.TotalStudent;
                    decimal sum_sub7 = t_sub7 / r.TotalStudent;



                    writ.Write(",Average marks," + Math.Round(sum_sub1, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(sum_sub2, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(sum_sub3, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(sum_sub4, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(sum_sub5, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(sum_sub6, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(sum_sub7, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",Passed," + p_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(p_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(p_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(p_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(p_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(p_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(p_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",Failed," + f_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(f_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(f_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(f_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(f_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(f_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(f_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    ps_sub1 = (double)(p_sub1 * 100) / totalstudent;
                    ps_sub2 = (double)(p_sub2 * 100) / totalstudent;
                    ps_sub3 = (double)(p_sub3 * 100) / totalstudent;
                    ps_sub4 = (double)(p_sub4 * 100) / totalstudent;
                    ps_sub5 = (double)(p_sub5 * 100) / totalstudent;
                    ps_sub6 = (double)(p_sub6 * 100) / totalstudent;
                    ps_sub7 = (double)(p_sub7 * 100) / totalstudent;

                    writ.Write(",passing percentage," + Math.Round(ps_sub1, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(ps_sub2, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(ps_sub3, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(ps_sub4, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(ps_sub5, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(ps_sub6, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(Math.Round(ps_sub7, 2) + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");


                    writ.Write(",O grade," + o_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(o_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(o_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(o_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(o_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(o_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(o_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",A grade," + a_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(a_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(a_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(a_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(a_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(a_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(a_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",B grade," + b_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(b_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(b_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(b_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(b_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(b_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(b_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",C grade," + c_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(c_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(c_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(c_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(c_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(c_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(c_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",D grade," + d_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(d_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(d_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(d_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(d_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(d_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(d_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",E grade," + e_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(e_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(e_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(e_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(e_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(e_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(e_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",P grade," + pa_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(pa_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(pa_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(pa_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(pa_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(pa_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(pa_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write(",F grade," + fa_sub1 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(fa_sub2 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(fa_sub3 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(fa_sub4 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(fa_sub5 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(fa_sub6 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(fa_sub7 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    sub1_60 = o_sub1 + a_sub1 + b_sub1 + c_sub1;
                    sub2_60 = o_sub2 + a_sub2 + b_sub2 + c_sub2;
                    sub3_60 = o_sub3 + a_sub3 + b_sub3 + c_sub3;
                    sub4_60 = o_sub4 + a_sub4 + b_sub4 + c_sub4;
                    sub5_60 = o_sub5 + a_sub5 + b_sub5 + c_sub5;
                    sub6_60 = o_sub6 + a_sub6 + b_sub6 + c_sub6;
                    sub7_60 = o_sub7 + a_sub7 + b_sub7 + c_sub7;

                    writ.Write(",Total Student 60% and above," + sub1_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(sub2_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(sub3_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(sub4_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(sub5_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(sub6_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(sub7_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    below1_60 = d_sub1 + e_sub1 + pa_sub1;
                    below2_60 = d_sub2 + e_sub2 + pa_sub2;
                    below3_60 = d_sub3 + e_sub3 + pa_sub3;
                    below4_60 = d_sub4 + e_sub4 + pa_sub4;
                    below5_60 = d_sub5 + e_sub5 + pa_sub5;
                    below6_60 = d_sub6 + e_sub6 + pa_sub6;
                    below7_60 = d_sub7 + e_sub7 + pa_sub7;

                    writ.Write(",Total Student below 60%," + below1_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(below2_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(below3_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(below4_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(below5_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(below6_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.Write(below7_60 + "," + "," + "," + "," + "," + "," + ",");
                    writ.WriteLine(",");

                    writ.Write("Total Marks," + t_sub1 + "," + t_sub2 + "," + t_sub3 + "," + t_sub4 + "," + t_sub5 + "," + t_sub6 + "," + t_sub7);


                    sumwrite.WriteLine("Subject," + r.subject1 + "," + r.subject2 + "," + r.subject3 + "," + r.subject4 + "," + r.subject5 + ","
                       + r.lab1 + "," + r.lab2);
                    sumwrite.WriteLine(",");
                    sumwrite.WriteLine("Total Student," + r.TotalStudent + "," + r.TotalStudent + "," + r.TotalStudent + "," + r.TotalStudent + "," + r.TotalStudent + "," + r.TotalStudent + "," + r.TotalStudent + ",");
                    sumwrite.WriteLine("Average Marks," + Math.Round(sum_sub1, 2) + "," + Math.Round(sum_sub2, 2) + "," + Math.Round(sum_sub3, 2) + "," + Math.Round(sum_sub4, 2) + "," + Math.Round(sum_sub5, 2) + "," + Math.Round(sum_sub6, 2) + "," + Math.Round(sum_sub7, 2) + ",");
                    sumwrite.WriteLine("Passed," + p_sub1 + "," + p_sub2 + "," + p_sub3 + "," + p_sub4 + "," + p_sub5 + "," + p_sub6 + "," + p_sub7 + ",");
                    sumwrite.WriteLine("Failed," + f_sub1 + "," + f_sub2 + "," + f_sub3 + "," + f_sub4 + "," + f_sub5 + "," + f_sub6 + "," + f_sub7 + ",");
                    sumwrite.WriteLine("O grade," + o_sub1 + "," + o_sub2 + "," + o_sub3 + "," + o_sub4 + "," + o_sub5 + "," + o_sub6 + "," + o_sub7 + ",");
                    sumwrite.WriteLine("A grade," + a_sub1 + "," + a_sub2 + "," + a_sub3 + "," + a_sub4 + "," + a_sub5 + "," + a_sub6 + "," + a_sub7 + ",");
                    sumwrite.WriteLine("B grade," + b_sub1 + "," + b_sub2 + "," + b_sub3 + "," + b_sub4 + "," + b_sub5 + "," + b_sub6 + "," + b_sub7 + ",");
                    sumwrite.WriteLine("C grade," + c_sub1 + "," + c_sub2 + "," + c_sub3 + "," + c_sub4 + "," + c_sub5 + "," + c_sub6 + "," + c_sub7 + ",");
                    sumwrite.WriteLine("D grade," + d_sub1 + "," + d_sub2 + "," + d_sub3 + "," + d_sub4 + "," + d_sub5 + "," + d_sub6 + "," + d_sub7 + ",");
                    sumwrite.WriteLine("E garde," + e_sub1 + "," + e_sub2 + "," + e_sub3 + "," + e_sub4 + "," + e_sub5 + "," + e_sub6 + "," + e_sub7 + ",");
                    sumwrite.WriteLine("Passed," + pa_sub1 + "," + pa_sub2 + "," + pa_sub3 + "," + pa_sub4 + "," + pa_sub5 + "," + pa_sub6 + "," + pa_sub7 + ",");
                    sumwrite.WriteLine("Failed," + fa_sub1 + "," + fa_sub2 + "," + fa_sub3 + "," + fa_sub4 + "," + fa_sub5 + "," + fa_sub6 + "," + fa_sub7 + ",");
                    sumwrite.WriteLine("Total Student with 60% and above ," + sub1_60 + "," + sub2_60 + "," + sub3_60 + "," + sub4_60 + "," + sub5_60 + "," + sub6_60 + "," + sub7_60 + ",");
                    sumwrite.WriteLine("Total Student with 60% and below," + below1_60 + "," + below2_60 + "," + below3_60 + "," + below4_60 + "," + below5_60 + "," + below6_60 + "," + below7_60 + ",");

                    sumwrite.WriteLine("," + "," + ",");
                    sumwrite.WriteLine("OVERALL SUMMARY OF SEMESTER," + ",");
                    sumwrite.WriteLine("Total Student," + "," + r.TotalStudent + ",");
                    sumwrite.WriteLine("Passed," + totalpass + ",");
                    sumwrite.WriteLine("Failed," + totalf + ",");

                    double totalpassing = (double)(totalpass * 100) / totalstudent;
                    double totalfail = (double)(totalf * 100) / totalstudent;
                    sumwrite.WriteLine("Passing %," + Math.Round(totalpassing, 2) + ",");
                    sumwrite.WriteLine("Failed %," + Math.Round(totalfail, 2) + ",");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Kindly Select/upload a pdf!')", true);
                }
            }
            catch (Exception es)
            {
                GetErrorMsg("Something went wrong");
            }
            //
            finally
            {
                writ.Close();
                sumwrite.Close();
                writ1.Close();
                writ2.Close();
               // writ.Close();
                
            }
        }
        public void GetErrorMsg(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+msg+"')", true);            
        }
        public void generateFinalResult(List<string> detail, Result r,ref StreamWriter writ)
        {
                //writ.WriteLine(",");
                writ.Write(r.SeatNumber + ",");
                writ.Write(r.Name + ",");
               
                int counts = 1;
                for (int i = r.Getpos(); i < detail.Count; i++)
                { 
                    if (counts == 47 && detail[i] == "E") 
                    { i++; }
                    if (counts == 49 && detail[i] == "F")
                    { i++; }
                    writ.Write(detail[i] + ",");
                    counts++;
                   if(!detail[i].Equals("--") || !detail[i].Equals("----"))
                    {
                        if (counts == 4)
                        {
                            t_sub1 = t_sub1 + int.Parse(detail[i]);
                            if (int.Parse(detail[i]) >= 36)
                            {
                                p_sub1++;
                            }
                            else
                            {
                                f_sub1++;
                            }
                        }
                        if (counts == 11)
                        {
                            t_sub2 = t_sub2 + int.Parse(detail[i]);
                            if (int.Parse(detail[i]) >= 36)
                            {
                                p_sub2++;
                            }
                            else
                            {
                                f_sub2++;
                            }
                        }
                        if (counts == 18)
                        {
                            t_sub3 = t_sub3 + int.Parse(detail[i]);
                            if (int.Parse(detail[i]) >= 36)
                            {
                                p_sub3++;
                            }
                            else
                            {
                                f_sub3++;
                            }
                        }
                        if (counts == 25)
                        {
                            t_sub4 = t_sub4 + int.Parse(detail[i]);
                            if (int.Parse(detail[i]) >= 36)
                            {
                                p_sub4++;
                            }
                            else
                            {
                                f_sub4++;
                            }
                        }
                        if (counts == 32)
                        {
                            t_sub5 = t_sub5 + int.Parse(detail[i]);
                            if (int.Parse(detail[i]) >= 36)
                            {
                                p_sub5++;
                            }
                            else
                            {
                                f_sub5++;
                            }
                        }
                        if (counts == 40)
                        {
                            t_sub6 = t_sub6 + int.Parse(detail[i]);
                            if (int.Parse(detail[i]) >= 36)
                            {
                                p_sub6++;
                            }
                            else
                            {
                                f_sub6++;
                            }
                        }
                        if (counts == 48)
                        {
                            if ((detail[counts].Equals("F"))) 
                            { 
                                t_sub7 = t_sub7 + int.Parse(detail[i]);
                                if (int.Parse(detail[i]) >= 36)
                                {
                                    p_sub7++;
                                }
                                else
                                {
                                    f_sub7++;
                                }
                            }
                            
                        }
                    }
                    if(counts == 29)//use regexpattern to match only one element either p or f to file marks or grade
                    {
                        i++;
                        res = detail[i];
                        if (res == "P" || res == "p")
                            totalpass++;
                        else if (res == "F" || res == "f")
                            totalf++;
                    }


                    /*grade calculation*/
                    if (counts == 6 && detail[i] == "O" || detail[i] == "o")
                    {
                        o_sub1++;
                    }
                    else if (counts == 6 && detail[i] == "A" || detail[i] == "a")
                        a_sub1++;
                    else if (counts == 6 && detail[i] == "B" || detail[i] == "a")
                        b_sub1++;
                    else if (counts == 6 && detail[i] == "C" || detail[i] == "c")
                        c_sub1++;
                    else if (counts == 6 && detail[i] == "D" || detail[i] == "d")
                        d_sub1++;
                    else if (counts == 6 && detail[i] == "E" || detail[i] == "e")
                        e_sub1++;
                    else if (counts == 6 && detail[i] == "P" || detail[i] == "p")
                        pa_sub1++;
                    else if (counts == 6 && detail[i] == "--")
                        fa_sub1++;

                    else { }


                    if (counts == 13 && detail[i] == "O" || detail[i] == "o")
                    {
                        o_sub2++;
                    }
                    else if (counts == 13 && detail[i] == "A" || detail[i] == "a")
                        a_sub2++;
                    else if (counts == 13 && detail[i] == "B" || detail[i] == "a")
                        b_sub2++;
                    else if (counts == 13 && detail[i] == "C" || detail[i] == "c")
                        c_sub2++;
                    else if (counts == 13 && detail[i] == "D" || detail[i] == "d")
                        d_sub2++;
                    else if (counts == 13 && detail[i] == "E" || detail[i] == "e")
                        e_sub2++;
                    else if (counts == 13 && detail[i] == "P" || detail[i] == "p")
                        pa_sub2++;
                    else if (counts == 13 && detail[i] == "--")
                        fa_sub2++;

                    else { }

                    if (counts == 20 && detail[i] == "O" || detail[i] == "o")
                    {
                        o_sub3++;
                    }
                    else if (counts == 20 && detail[i] == "A" || detail[i] == "a")
                        a_sub3++;
                    else if (counts == 20 && detail[i] == "B" || detail[i] == "a")
                        b_sub3++;
                    else if (counts == 20 && detail[i] == "C" || detail[i] == "c")
                        c_sub3++;
                    else if (counts == 20 && detail[i] == "D" || detail[i] == "d")
                        d_sub3++;
                    else if (counts == 20 && detail[i] == "E" || detail[i] == "e")
                        e_sub3++;
                    else if (counts == 20 && detail[i] == "P" || detail[i] == "p")
                        pa_sub3++;
                    else if (counts == 20 && detail[i] == "--")
                        fa_sub3++;
                    else { }


                    if (counts == 27 && detail[i] == "O" || detail[i] == "o")
                    {
                        o_sub4++;
                    }
                    else if (counts == 27 && detail[i] == "A" || detail[i] == "a")
                        a_sub4++;
                    else if (counts == 27 && detail[i] == "B" || detail[i] == "a")
                        b_sub4++;
                    else if (counts == 27 && detail[i] == "C" || detail[i] == "c")
                        c_sub4++;
                    else if (counts == 27 && detail[i] == "D" || detail[i] == "d")
                        d_sub4++;
                    else if (counts == 27 && detail[i] == "E" || detail[i] == "e")
                        e_sub4++;
                    else if (counts == 27 && detail[i] == "P" || detail[i] == "p")
                        pa_sub4++;
                    else if (counts == 27 && detail[i] == "--")
                        fa_sub4++;
                    else { }

                    if (counts == 34 && detail[i] == "O" || detail[i] == "o")
                    {
                        o_sub5++;
                    }
                    else if (counts == 34 && detail[i] == "A" || detail[i] == "a")
                        a_sub5++;
                    else if (counts == 34 && detail[i] == "B" || detail[i] == "a")
                        b_sub5++;
                    else if (counts == 34 && detail[i] == "C" || detail[i] == "c")
                        c_sub5++;
                    else if (counts == 34 && detail[i] == "D" || detail[i] == "d")
                        d_sub5++;
                    else if (counts == 34 && detail[i] == "E" || detail[i] == "e")
                        e_sub5++;
                    else if (counts == 34 && detail[i] == "P" || detail[i] == "p")
                        pa_sub5++;
                    else if (counts == 34 && detail[i] == "--")
                        fa_sub5++;
                    else { }

                    if (counts == 42 && detail[i] == "O" || detail[i] == "o")
                    {
                        o_sub6++;
                    }
                    else if (counts == 42 && detail[i] == "A" || detail[i] == "a")
                        a_sub6++;
                    else if (counts == 42 && detail[i] == "B" || detail[i] == "a")
                        b_sub6++;
                    else if (counts == 42 && detail[i] == "C" || detail[i] == "c")
                        c_sub6++;
                    else if (counts == 42 && detail[i] == "D" || detail[i] == "d")
                        d_sub6++;
                    else if (counts == 42 && detail[i] == "E" || detail[i] == "e")
                        e_sub6++;
                    else if (counts == 42 && detail[i] == "P" || detail[i] == "p")
                        pa_sub6++;
                    else if (counts == 42 && detail[i] == "--")
                        fa_sub6++;
                    else { }
                    
                    if (counts == 50 && detail[i] == "O" || detail[i] == "o")
                    {
                        o_sub7++;
                    }
                    else if (counts == 50 && detail[i] == "A" || detail[i] == "a")
                        a_sub7++;
                    else if (counts == 50 && detail[i] == "B" || detail[i] == "a")
                        b_sub7++;
                    else if (counts == 50 && detail[i] == "C" || detail[i] == "c")
                        c_sub7++;
                    else if (counts == 50 && detail[i] == "D" || detail[i] == "d")
                        d_sub7++;
                    else if (counts == 50 && detail[i] == "E" || detail[i] == "e")
                        e_sub7++;
                    else if (counts == 50 && detail[i] == "F" || detail[i] == "F")
                        e_sub7++;
                    else if (counts == 50 && detail[i] == "P" || detail[i] == "p")
                        pa_sub7++;
                    else if (counts == 50 && detail[i] == "--")
                        fa_sub7++;
                    else { }

                   /* if (counts == 57 && detail[i] == "P" || detail[i] == "p")
                    {
                        totalpass++;
                    }
                    else if (counts == 5 && detail[i] == "F" || detail[i] == "f")
                    {
                        totalf++;
                    }*/
                }
                writ.Write(res+",");
                writ.WriteLine(","+",");
        }

        
        public void setMarks(string th,string ia,string total,string credit,string grade)
        {
 
        }
        /*protected void Button2_Click2(object sender, EventArgs e)
        {
            r.setSubjects(ListBox1.SelectedItem.Text);

            filecontent = read.ReadLine();

            while (filecontent != null)
            {
                texts += filecontent + " ";
                filecontent = read.ReadLine();
            }
            a = texts.Split(' ');
            writ1 = file2.CreateText();
            writ1.Write("," + "," + "," + "," + "," + ",");
            writ1.WriteLine("First SHIFT RESULT");
            writ1.Write("SEAT NUMBER" + ",");
            writ1.Write("NAME OF STUDENT" + ",");
            writ1.Write(r.subject1 + "," + "," + "," + "," + "," + "," + ",");
            writ1.Write(r.subject2 + "," + "," + "," + "," + "," + "," + ",");
            writ1.Write(r.subject3 + "," + "," + "," + "," + "," + "," + ",");
            writ1.Write(r.subject4 + "," + "," + "," + "," + "," + "," + ",");
            writ1.Write(r.subject5 + "," + "," + "," + "," + "," + "," + ",");
            writ1.Write(r.lab1 + "," + "," + "," + "," + "," + "," + "," + ",");
            writ1.Write(r.lab2);
            writ1.WriteLine(",");
            writ1.Write("," + ",");

            for (int i = 0; i <= 4; i++)
            {
                writ1.Write("THEORY,");
                writ1.Write("INTERNAL,");
                writ1.Write("TOTAL,");
                writ1.Write("CREDIT,");
                writ1.Write("GRADE,");
                writ1.Write("GP,");
                writ1.Write("C*GP,");
            }
            for (int i = 5; i <= 6; i++)
            {
                writ1.Write("25\'\'11,");
                writ1.Write("25\'\'11,");
                writ1.Write("50\'\'23,");
                writ1.Write("Total,");
                writ1.Write("CREDIT,");
                writ1.Write("GRADE,");
                writ1.Write("GP,");
                writ1.Write("C*GP,");
            } 
            writ1.Write("G,");
            writ1.Write("GPA,");
            writ1.Write("Grade,");
            writ1.Write("Result,");
            writ1.WriteLine(",");
            writ1.WriteLine(",");
            
            if (FileUpload1.HasFile && FileUpload1.FileName.Contains("MCA") ||
                    FileUpload1.FileName.Contains("M.C.A") && FileUpload1.FileName.Contains("CBSGS") ||
                    FileUpload1.FileName.Contains("CHOICE"))
                {
                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                    if (fileExtension.ToLower() != ".pdf")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Only PDF files')", true);
                    }
                    else
                    {
                        int fileSize = FileUpload1.PostedFile.ContentLength;
                        if (fileSize > 2100000) //2 mb
                        {
                            //208911
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Kindly check the size')", true);
                        }
                        else
                        {
                            //r.setSubjects(FileUpload1.FileName);
                            /*FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Files/") + FileUpload1.FileName);
                            r.Extract_Text(Server.MapPath("~/Files/" + FileUpload1.FileName));
                            for(int re=start;  re<=end;   re++)
                            {
                                if (r.FilterDetails(Convert.ToString(re))==true)
                                { 
                                    //writ.Write("," + r.FilterDetails(Convert.ToString(re))+",");
                                    generateFinalResult(r.GenerateMarksheet(), r, ref writ);
                                }
                            }

                        }
                    }
                }
            else if (ListBox1.SelectedIndex != -1 &&
                ListBox1.SelectedItem.Text.Contains("MCA")
                || ListBox1.SelectedItem.Text.Contains("M.C.A") && ListBox1.SelectedItem.Text.Contains("CHOICE")
                || ListBox1.SelectedItem.Text.Contains("CBSGS"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('done!" + ListBox1.SelectedItem.Text + "')", true);


                r.Extract_Text(Server.MapPath("~/Files/" + ListBox1.SelectedItem.Text));

                //new shift 1 & 2 (3/3/20)
                for (int i = 0; i < a.Length; i++)
                {
                    for (int re1 = start; re1 <= end; re1++)
                    {
                        if (a[i] == Convert.ToString(re1))
                        {
                            if (r.FilterDetails(Convert.ToString(a[i])) == true)
                            {
                                generateFinalResult1(r.GenerateMarksheet(), r,ref writ1);
                            }
                        }
                    }
                }
            }
            writ1.Close();     
              
        }*/
        public void generateFinalResult1(List<string> detail, Result r, ref StreamWriter writ1)
        {
            //writ.WriteLine(",");
            writ1.Write(r.SeatNumber + ",");
            writ1.Write(r.Name + ",");

            int counts = 1;
            for (int i = r.Getpos(); i < detail.Count; i++)
            {
                if (counts == 47 && detail[i].Equals("E"))
                { i++; }
                if (counts == 49 && detail[i] == "F")
                { i++; }
                writ1.Write(detail[i] + ",");
                counts++;
                if (counts == 29)//use regexpattern to match only one element either p or f to file marks or grade
                {
                    i++;
                    res = detail[i];
                }
            }
            writ1.Write(res + ",");
            writ1.WriteLine("," + ",");
        }

        public void generateFinalResult2(List<string> detail, Result r, StreamWriter writ2)
        {
            //writ.WriteLine(",");
            writ2.Write(r.SeatNumber + ",");
            writ2.Write(r.Name + ",");

            int counts = 1;
            for (int i = r.Getpos(); i < detail.Count; i++)
            {
                
                if (counts == 47 && detail[i].Equals("E"))
                { i++; }
                if (counts == 49 && detail[i] == "F")
                { i++; }
                writ2.Write(detail[i] + ",");
                counts++;
                if (counts == 29)//use regexpattern to match only one element either p or f to file marks or grade
                {
                    i++;
                    res = detail[i];
                }
                
            }
            writ2.Write(res + ",");
            writ2.WriteLine("," + ",");
        }
    }  
}