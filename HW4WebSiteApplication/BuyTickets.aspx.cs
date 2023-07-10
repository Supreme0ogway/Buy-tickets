using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4WebSiteApplication
{
    public partial class BuyTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button9.Visible = false;
        }

        //search
        protected void Button4_Click(object sender, EventArgs e)
        {
            //variables
            string keyword;
            string countryID = "US";
            string dateFromNowToEvent = "2023-08-01T12:00:00Z";

            Label2.Text = "";//reset label 2

            //if no keyword then return;
            if (TextBox1.Text.Equals(""))
            {
                Label2.Text = "Please enter a keyword.";
                Button9.Visible = false;
                Label3.Text = "";
                return;
            }
            else
            {
                keyword = TextBox1.Text;
            }

            if (TextBox3.Text.Equals(""))
            {
                TextBox3.Text = countryID;
            }
            if (TextBox4.Text.Equals(""))
            {
                TextBox4.Text = dateFromNowToEvent;
            }
            //http://localhost:63364/Service1.svc/catelog?keyWord=ALL&printContentAmount=20&countryLocation=US&searchUpToThisDay=2023-08-01T12:00:00Z
            string baseUrl = $"http://localhost:63364/Service1.svc";
            string service = $"/catelog?keyWord={keyword}&printContentAmount=1&countryLocation={countryID}&searchUpToThisDay={dateFromNowToEvent}";
            string url = $"{baseUrl}{service}";
            //request -> response -> read system.io.stream

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);//get request
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();//get response
            StreamReader read = new StreamReader(resp.GetResponseStream());//reads the response

            //sets the response to a string after reading the stream
            string information = read.ReadToEnd();

            Button9.Visible = true;
            Label3.Text = information;
            Session["ConcertName"] = information.ToString();
        }

        //home
        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //buy tickets (already signed in)
        protected void Button9_Click(object sender, EventArgs e)
        {
            string concert = Session["ConcertName"].ToString();

            if (Label3.Text.Equals(""))
            {
                Label2.Text = "Please enter information";
                return;
            }

            if (Cache["cachedData"] != null)
            {
                HttpContext.Current.Cache.Remove("cachedData");
            }

            string d = HttpContext.Current.Server.MapPath("cacheFile.txt");
            File.WriteAllText(d, concert);
            Response.Redirect("EnterCreditCardInfo.aspx");
            //HttpRuntime.Cache.Insert("cachedData", concert, new CacheDependency(d));

            //string cacheData = HttpRuntime.Cache["cachedData"] as string;
            //Label2.Text = cacheData;
            //Response.Redirect("EnterCreditCardInfo.aspx");
        }
    }
}