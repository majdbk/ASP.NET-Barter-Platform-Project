using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using tntroc.Services;
using tntroc.Domain.Entities;
using System.Collections.Generic;

public partial class ResultGood : System.Web.UI.Page
{
    string clientName;
    string clientLastName;
    protected void Page_Load(object sender, EventArgs e)
    {
        clientName = Request["search"].ToString();
        //clientLastName = Request["search1"].ToString();
        GetresultGood();
        
    }

    //The Method Getresult will return (Response.Write) which contains search results seprated by character "~"

    // For E.G. "Ra~Rab~Racd~Raef~Raghi"   which will going to display in search suggest box 

  


    private void GetresultGood()
    {
        IGoodService service = new GoodService();
        
       IEnumerable<goods> names = service.GetMany(c => c.label.StartsWith(clientName));
        StringBuilder sb = new StringBuilder();
        foreach (goods swap in names )
        {
            sb.Append(swap.label + "~");   //Create Con
           System.Diagnostics.Debug.WriteLine("------------------------------------///////////98   :    " + swap.label);
        }
        Response.Write(sb);   

    }
    
}
