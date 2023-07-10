using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace HW4WebSiteApplication
{
    public partial class CatalogPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //show upcoming concerts
        protected void Button1_Click(object sender, EventArgs e)
        {
            //https://app.ticketmaster.com/discovery/v2/events.json?classificationName=music&size=20&apikey=atlLoSwOAw0EXLBNyQbbigTGj4Ur9ckG&endDateTime=2023-08-01T12:00:00Z&countryCode=US
            string keyWord = $"ALL";
            string printContentAmount = $"20";//casted to int in api
            string countryLocation;
            if (TextBox1.Text.Equals(""))
            {
                Label1.Text = "Country code set to united states";
                TextBox1.Text = "US";
                countryLocation = TextBox1.Text;
            }
            else
            {
                countryLocation = TextBox1.Text;
            }
            //http://localhost:63364/Service1.svc/catelog?keyWord=ALL&printContentAmount=20&countryLocation=US&searchUpToThisDay=2023-08-01T12:00:00Z
            string searchUpToThisDay = $"2023-08-01T12:00:00Z";
            string baseUrl = $"http://localhost:63364/Service1.svc";
            string service = $"/catelog?keyWord={keyWord}&printContentAmount={printContentAmount}&countryLocation={countryLocation}&searchUpToThisDay={searchUpToThisDay}";
            string url = $"{baseUrl}{service}";
            //request -> response -> read system.io.stream
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);//get request
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();//get response
            StreamReader read = new StreamReader(resp.GetResponseStream());//reads the response

            //sets the response to a string after reading the stream
            string information = read.ReadToEnd();

            //add next line format to each concert
            //string[] infoBreakdown = information.Split('>');
            
            /*for(int i = 0; i < 20; i++)
            {
                infoBreakdown[i] = information.Split('>');
            }*/

            /*Label1.Text = infoBreakdown[0];
            Label2.Text = infoBreakdown[1];
            Label3.Text = infoBreakdown[2];
            Label4.Text = infoBreakdown[3];
            Label5.Text = infoBreakdown[4];
            Label6.Text = infoBreakdown[5];
            Label7.Text = infoBreakdown[6];
            Label8.Text = infoBreakdown[7];
            Label9.Text = infoBreakdown[8];
            Label10.Text = infoBreakdown[9];
            Label11.Text = infoBreakdown[10];
            Label12.Text = infoBreakdown[11];
            Label13.Text = infoBreakdown[12];
            Label14.Text = infoBreakdown[13];
            Label15.Text = infoBreakdown[14];
            Label16.Text = infoBreakdown[15];
            Label17.Text = infoBreakdown[16];
            Label18.Text = infoBreakdown[17];
            Label19.Text = infoBreakdown[18];
            Label20.Text = infoBreakdown[19];*/
            //set information

            Label1.Text = information;
        }

        //search for upcoming concerts
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchConcertPage.aspx");
        }

        //home
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            HttpCookie membercookie = Request.Cookies["Member"];
            if (membercookie == null)
            {
                Response.Redirect("LogInPage.aspx");
            }
            else
            {
                Response.Redirect("BuyTickets.aspx");
            }
        }
    }
}