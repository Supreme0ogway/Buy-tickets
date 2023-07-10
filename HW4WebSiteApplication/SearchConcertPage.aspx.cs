using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4WebSiteApplication
{
    public partial class SearchConcertPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //home
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //back
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("CatalogPage.aspx");
        }

        //search
        protected void Button4_Click(object sender, EventArgs e)
        {
            //variables
            string keyword;
            string contentAmount;
            string countryID = "US";
            string dateFromNowToEvent = "2023-08-01T12:00:00Z";
            int tester;

            //if no keyword then return;
            if(TextBox1.Text.Equals(""))
            {
                Label1.Text = "Please enter a keyword.";
                return;
            }
            else
            {
                keyword = TextBox1.Text;
            }

            if(TextBox2.Text.Equals(""))
            {
                TextBox2.Text = "1";
            }
            //try to parse to int
            try
            {
                tester = int.Parse(TextBox2.Text);
                if (tester <= 0)
                {
                    Label1.Text = "Please enter an integer greater than 0.";
                    return;
                }
            }
            catch
            {
                Label1.Text = "Please enter a correct content amount (must be while number and not 0)";
                return;
            }
            contentAmount = TextBox2.Text;

            if (TextBox3.Text.Equals(""))
            {
                TextBox3.Text = countryID;
            }
            if(TextBox4.Text.Equals(""))
            {
                TextBox4.Text = dateFromNowToEvent;
            }
            //http://localhost:63364/Service1.svc/catelog?keyWord=ALL&printContentAmount=20&countryLocation=US&searchUpToThisDay=2023-08-01T12:00:00Z
            string baseUrl = $"http://localhost:63364/Service1.svc";
            string service = $"/catelog?keyWord={keyword}&printContentAmount={contentAmount}&countryLocation={countryID}&searchUpToThisDay={dateFromNowToEvent}";
            string url = $"{baseUrl}{service}";
            //request -> response -> read system.io.stream

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);//get request
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();//get response
            StreamReader read = new StreamReader(resp.GetResponseStream());//reads the response

            //sets the response to a string after reading the stream
            string information = read.ReadToEnd();

            Label2.Text = information;
        }
        
        //buy tickets button
        protected void Button7_Click(object sender, EventArgs e)
        {
            HttpCookie membercookies = Request.Cookies["Member"];
            if (membercookies != null)
            {
                Response.Redirect("BuyTickets.aspx");
            }
            else
            {
                Response.Redirect("LogInPage.aspx");
            }
        }
    }
}