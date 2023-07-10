using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4WebSiteApplication
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //sign up
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");
        }

        //home
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //log in
        protected void Button4_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            string username;
            string password;
            string storredPassword;

            //get + check username
            if(TextBox1.Text.Equals(""))
            {
                Label1.Text = "Please enter your username.";
                return;
            }
            username = TextBox1.Text;
            storredPassword = client.GetAccountPassword(username);
            if(storredPassword.Equals(""))
            {
                Label1.Text = "There is no account with that username.";
                return;
            }

            //get + check passwrod
            if(TextBox1.Text.Equals(""))
            {
                Label1.Text = "Please enter your password";
                return;
            }
            password = TextBox2.Text;

            if(!password.Equals(storredPassword))
            {
                Label1.Text = "Password is incorrect";
                return;
            }

            //add cookies
            HttpCookie membercookie = Response.Cookies["Member"];
            membercookie["username"] = username;
            membercookie["password"] = password;
            Response.Cookies.Add(membercookie);
            if (CheckBox1.Checked)
            {
                membercookie.Expires = DateTime.MaxValue;
            }
            else
            {
                membercookie.Expires = DateTime.MinValue;
            }

            //go to different page
            Response.Redirect("Default.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}