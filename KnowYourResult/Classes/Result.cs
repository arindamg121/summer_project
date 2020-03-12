using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text.RegularExpressions;

namespace KnowYourResult.Classes
{
    public class Result
    {
        PdfReader reader;
        String text = null;
        String[] arr;
        int no_stu = 0;

        public String subject1, subject2, subject3, subject4, subject5, lab1, lab2, miniproject,lab3;

        String a = null; 
        bool seatNo_Existed = false;

        string name = null, seat_no = null;
        int pos = 0;
        string append = null, month_year = null;

        public Result()
        {
            subject1= subject2 =subject3 =subject4 = subject5 =lab1 =lab2=miniproject=lab3= null;
        }

        public void Extract_Text(string path)
        {
            try {
                    reader = new PdfReader(path);
                                   
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
               
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                        string currentPageText = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
               
                        text = text + currentPageText;
               
                    }
                    reader.Close();
                    arr   = text.Split(Convert.ToChar("\n"));        
                    }
                catch (Exception ex)
                {
            
                }
        
        }

        public bool FilterDetails(string seatNo_input)
        {
           // check the seat number if its number 
            int seatNo_out = 0;
            if(int.TryParse(seatNo_input.Trim(),out seatNo_out))
            {
                for (int i = 0; i < arr.Length; i++)
                {                                      
                    if (arr[i].Trim().StartsWith(seatNo_out.ToString().Trim()))
                    {
                        seatNo_Existed = true;
                        no_stu++;

                        //SetseatNo(seatNo_input);
                        SeatNumber = seatNo_input;
                        a = arr[i];
                        a = a + arr[i + 3];
                        break;
                    }

                }
            }
            return seatNo_Existed;
         }
      
        public List<string> GenerateMarksheet()
        { 
            List<string> exc = new List<string>();

            if (seatNo_Existed == true && a != null)
            {
                String[] ar = a.Split(' ', '/', '+');
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] != "")
                    {
                        if (ar[i].Length == 3)
                        {

                            char element1 = ar[i].ElementAt(0);
                            char element2 = ar[i].ElementAt(1);
                            char element3 = ar[i].ElementAt(2);

                            if (!(ar[i].Equals("AND")) && !(ar[i].Equals("RPV")) && !(ar[i].Equals("ABS")) && !(ar[i].Equals(@"ADC")) && !(ar[i].Equals("RCC")))
                            {
                                //22F
                                if(ar[i].Count() == 3 && char.IsDigit(ar[i].ElementAt(0)) && char.IsDigit(ar[i].ElementAt(1)) &&
                                Regex.Matches(ar[i].ElementAt(2).ToString(), @"[a-zA-Z]").Count !=0)
                                {
                                    exc.Add(ar[i].Substring(0,2));
                                }
                                //(o)
                                else if (!(element1.Equals('(') && Regex.Matches(element2.ToString(), @"[A-Za-z]").Count != 0 && element3.Equals(')')))
                                {
                                    exc.Add(ar[i]);
                                }
                            }
                        }
                            // 35E(O)
                        else if (ar[i].Count() == 6 && char.IsDigit(ar[i].ElementAt(0)) && char.IsDigit(ar[i].ElementAt(1)) &&
                                Regex.Matches(ar[i].ElementAt(2).ToString(), @"[a-zA-Z]").Count != 0 && ar[i].ElementAt(3).Equals('(') &&
                                Regex.Matches(ar[i].ElementAt(4).ToString(), @"[a-zA-Z]").Count != 0 && ar[i].ElementAt(5).Equals(')'))
                        {
                            exc.Add(ar[i].Substring(0, 6 - 4));
                        }
                        else
                        {
                      
                            if (ar[i].Equals("--"))
                            {
                                exc.Add("0");
                            }
                            else if (ar[i].Equals("----"))
                            {
                                exc.Add("0");
                                exc.Add("0");   
                            }
                            else if (ar[i].Equals("------"))
                            {
                                exc.Add("0");
                                exc.Add("0");
                                exc.Add("0");
                            }
                            else if (ar[i].Equals("(COURSE") || ar[i].Equals("IV:MCA4044:ETHICS") || ar[i].Equals("IV:MCA4042:BUSSINESS") || ar[i].Equals("CSR)") || ar[i].Equals("INFRA") || ar[i].Equals("MGMT.)") || ar[i].Equals("IV:MCADLE-5042:MACHINE") || ar[i].Equals("IV:MCADLE-5043:INTERNET") || ar[i].Equals("LEARNING)") || ar[i].Equals("OF") || ar[i].Equals("THINGS)"))
                            { }
                            else
                            {
                                exc.Add(ar[i]);
                            }
                        }

                    }

                }
            }

            string name1 = null;
            for (int z = 1; z < exc.Count-3; z++)
            {
                int res = 0 ;

                if (exc[z]=="A"||int.TryParse(exc[z], out res))
                {
                    Setpos(z); // get the marks pos to use it afterwards 
                    break;
                }
                else
                {
                    name1 = name1 + " " + exc[z];//
                }
               // Setname(name1);
                Name = name1;
            }//Have to add seconde row of the data by using onther variable b=arr[i+1]

        return exc;        
    }
        public void setSubjects(string file_name)
        {
            string append1, month1;
            append1 = month1 = null;
            String[] course = file_name.Split(Convert.ToChar("-"));
            for (int o = 0; o <= 3; o++)
            {
                 append1 +="_"+ course[o];     
            }
             SetExam(append1);
             for (int k = course.Length-2; k < course.Length; k++)
             {
                 month1 += course[k]; 
             }
             SetExamHeldIn(month1);
            switch(append1)
            {
                    // for checking of the app use this pdf 
                case "_MCA_SEM_I_CHOICE": 
                        
                    Subject1 = "Object Oriented Programming";
                    Subject2= "Software Engineering & Project Management";  
                    Subject3="Computer Organization and Architecture";
                    Subject4 ="IT in Management";
                    Subject5 ="Statistics and Probability";
                    Lab1 ="SEPM and OOP Lab";
                    Lab2 ="Web Technologies and Mini Project-Lab";
                    break;
                
                case "_MCA_SEM_II_CHOICE":
  
                    this.subject1 ="Data Structures";
                    this.subject2="Operating System";
                    Subject3="Computer Networks";
                    Subject4 ="Financial accounting and Management";
                    Subject5 ="Decision making and Mathematical Modelling";
                    Lab1 ="OS and CN Lab";
                    Lab2 ="DS and Web Application Development using Open source tools Lab";
                    break;
  
                case "_MCA_SEM_III_CHOICE": 
                     Subject1 = "DBMS";
                     this.Subject2="Java Programming";
                     Subject3 = "Information Security";
                     Subject4 = "Operation Research";
                     Subject5 ="Software Testing and Quality Assurance";
                     Lab1 ="Database Management systems and Software Testing Lab";
                     Lab2 ="Java Programming and Unified Modeling Language Lab";
                     MiniProject = "Mini Project";
                     break;
                case "_MCA_SEM_IV_CHOICE":
                     Subject1="Data Mining and Business Intelligence";
                     Subject2="Advanced Web Technology";
                     Subject3="Computer Graphics";
                     Subject4 ="Elective 1";
                     this.Subject5 ="Elective 2";
                     this.Lab1 ="Advanced Web Technology and Data Mining and Business Intelligence Lab";
                     this.Lab2 ="Computer Graphics and Image Processing Lab";
                     this.Lab3 ="Soft Skill Development";
                    break;
                case "_MCA_SEM_V_CHOICE":
                    this.Subject1 = "WIRELESS AND MOBILE TECHNOLOGY";
                    this.Subject2 = "ADVANCED DISTRIBUTED COMPUTING";
                    this.Subject3 = "USER EXPERIENCE DESIGN";
                     this.Subject4 ="Elective 1";
                     this.Subject5 ="Elective 2";
                     this.Lab1 = "L-1 MOBILE APPLICATION AND USER EXPERIENCE DESIGN LAB";
                     this.Lab2 = "-2 OPEN SOURCE SYSTEM FOR ADC LAB";
                     this.MiniProject = "MINI PROJECT";
                     break;
                case "_MCA_SEM_V_CBSGS": 
                     this.Subject1 = "Advanced web technology & Dot Net";
                     this.Subject2="Wireless & Mobile Technology";
                     this.Subject3 = "Soft Computing";
                     this.Subject4 ="Distributed computing and Cloud Computing";
                     this.Subject5 ="";
                     this.Lab1 = "Lab I-AWT + Dot Net";
                     this.Lab2 ="Lab II- Wireless & Mobile Technology + Mini project";
                     this.MiniProject = "MINI PROJECT";
                     break;

                case "_MCA_SEM_IV_CBSGS": 
                     this.Subject1 = "Core & Advanced JAVA";
                     this.Subject2="Advanced DatabaseTheory and Applications";
                     this.Subject3="System Modeling and Simulation";
                     this.Subject4 = "Soft skill development";
                     //this.Subject5 ="Subject1";   // elective ask from user 
                     this.Lab1 ="Lab I - Core & Advanced JAVA";
                     this.Lab2 = "Lab II-ADTA + UML";  
                     break;
                    
                case "_MCA_SEM_III_CBSGS":
                     Subject1 = "DBMS";
                     Subject2="Java Programming";
                     Subject3 = "Information Security";
                     Subject4 = "Operation Research";
                     Subject5 ="Software Testing and Quality Assurance";
                     Lab1 ="Database Management systems and Software Testing Lab";
                     Lab2 ="Java Programming and Unified Modeling Language Lab";
                     MiniProject = "Mini Project";
                     break;

                case "_MCA_SEM_II_CBSGS": 

                    this.subject1 ="Data Structures";
                    this.subject2="Operating System";
                    Subject3="Computer Networks";
                    Subject4 ="Financial accounting and Management";
                    Subject5 ="Decision making and Mathematical Modelling";
                    Lab1 ="OS and CN Lab";
                    Lab2 ="DS and Web Application Development using Open source tools Lab";
                    break;

                case "_MCA_SEM_I_CBSGS":

                    Subject1 = "Object Oriented Programming";
                    Subject2= "Software Engineering & Project Management";  
                    Subject3="Computer Organization and Architecture";
                    Subject4 ="IT in Management";
                    Subject5 ="Statistics and Probability";
                    Lab1 ="Lab I – SEPM and OOP Lab";
                    Lab2 ="Lab II – Web Technologies and Mini Project-Lab";
                    break;
            }
        }
        public string SeatNumber
        {
            get { return this.seat_no; }
            set { this.seat_no = value; }   
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int TotalStudent
        {
            get { return no_stu; }
            set { this.no_stu = value; }
        }

        public void Setpos(int pos)
        {
             this.pos= pos;
        }
        public void SetExamHeldIn(string month_year)
        {
             this.month_year = month_year.Replace(".pdf", " ");

        }
        public void  SetExam(string append)
        {
             this.append = append.Replace('_', ' ');
        }
        public int Getpos()
        {
            return this.pos;
        }
        public string GetExamHeldIn()
        {
            return this.month_year.Replace(".pdf", " ");

        }
        public string GetExam()
        {
            return this.append.Replace('_',' ');
        }

        public string Subject1
        {
            get { return this.subject1; }
            set { this.subject1 = value; }
        }
        public string Subject2
        {
            get { return this.subject2; }
            set { this.subject2 = value; }

        }
        public string Subject3
        {
            get { return this.subject3; }
            set { this.subject3 = value; }
        }

        public string Subject4
        {
            get { return this.subject4; }
            set { this.subject4 = value; }
        }
        public string Subject5
        {
            get { return this.subject5; }
            set { this.subject5 = value; }
        }
        public string Lab1
        {
            get { return this.lab1; }
            set { this.lab1 = value; }
        }
        public string Lab2
        {
            get { return this.lab2; }
            set { this.lab2 = value; }
       
        }
        public string Lab3
        {
            get { return this.lab3; }
            set { this.lab3 = value; }
        }
        public string MiniProject
        {
            get { return this.miniproject; }
            set { this.miniproject = value; }
        }
    }
}