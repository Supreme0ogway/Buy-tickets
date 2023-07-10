using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4WebSiteApplication
{
    public partial class EnterCreditCardInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //home
        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //process
        protected void Button10_Click(object sender, EventArgs e)
        {
            if(TextBox5.Text.Equals("") && TextBox7.Text.Equals("") && TextBox6.Text.Equals(""))
            {
                Label1.Text = "Please enter all required information";
                return;
            }

            HttpCookie membercookie = Request.Cookies["Member"];
            string firstName = TextBox5.Text;
            string lastName = TextBox6.Text;
            string creditCard = TextBox7.Text;

            membercookie["firstName"] = firstName;
            membercookie["lastName"] = lastName;
            membercookie["creditCard"] = creditCard;
            membercookie.Expires = DateTime.MaxValue;
            //Response.Cookies.Remove("Member");
            Response.Cookies.Add(membercookie);

            Response.Redirect("RecieptPage.aspx");
        }

        //back
        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuyTickets.aspx");
        }
    }
}