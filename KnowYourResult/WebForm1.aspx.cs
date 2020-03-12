using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KnowYourResult
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<!DOCTYPE html><html><head><style>table, th, td {border:1px solid black; border-collapse: collapse;background-color:#ffffb3; font-weight: bold;}th, td {padding: 10px;text-align: left;padding-left: 0.5cm;}h2{text-align:center; }#detail{text-align:center;}</style></head><body><h2>KNOW YOUR RESULT !</h2><table style='width:100%'><tr><th style='text-align:center;'>Demo Result</th></tr><tr > <td>Name : xyz <br/> Seat Number : 4546 <br/> Exam Held in : Nov 2015 </td></tr></table></body></html>");
/*<table style="width:100%">
<tr id="detail">
<th>Sr.No</th>
<th>Course</th><th>TH</th><th>IA</th><th>TOTAL</th><th>Credit</th><th>Grade</th>
</tr>
<tr>

<td>1</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>


</tr>
<tr>

<td>2</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>


</tr>

<tr>

<td>3</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>


</tr>

<tr>

<td>4</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>


</tr>

<tr>

<td>5</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>


</tr>

</table>
<table style="width:100%">
<tr>
<th>Sr.No</th>
<th>Course</th><th>TH</th><th>IA</th><th>TOTAL</th><th>Credit</th><th>Grade</th>

</tr>
</table>

</body>
</html>
");*/
        }

    }
}