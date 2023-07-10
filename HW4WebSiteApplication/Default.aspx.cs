using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4WebSiteApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie memberCookie = Request.Cookies["Member"];
            if(memberCookie != null)
            {
                Label1.Text = "Welcome back " + memberCookie["username"] + "!";
                Button3.Visible = false;
                Button1.Visible = false;
                Button5.Visible = true;
            }
            else
            {
                Button5.Visible = false;
                Button4.Visible = false;
            }
        }
        //login
        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie memberCookie = Request.Cookies["Member"];
            if(memberCookie == null)
            {
                Response.Redirect("LogInPage.aspx");//send to LogInPage
            }
            else
            {
                Label1.Text = "You are already logged in.";
            }
        }

        //catelog
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CatalogPage.aspx");//send to CatalogPage
        }

        //sign up
        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpCookie memberCookie = Request.Cookies["Member"];
            if(memberCookie == null)
            {
                Response.Redirect("SignUpPage.aspx");
            }
            else
            {
                Label1.Text = "You already have an account. Logout first before you sign in with a new account.";
            }
        }

        //log out
        protected void Button4_Click(object sender, EventArgs e)
        {
            HttpCookie memberCookie = Request.Cookies["Member"];
            //no cookies to remove
            if(memberCookie == null)
            {
                Label1.Text = "You must sign in to be able to log out";
            }
            else
            {
                //remove all cookies
                memberCookie["username"] = "";
                memberCookie["password"] = "";
                memberCookie.Expires = DateTime.Now.AddDays(-1);
                //Response.Cookies.Remove("Member");
                Response.Cookies.Add(memberCookie);
                Response.Redirect("Default.aspx");
            }
        }

        //reciepts displays all
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilesPage.aspx");
        }
    }
}