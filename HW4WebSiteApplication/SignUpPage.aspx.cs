using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4WebSiteApplication
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //sign up
        protected void Button4_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            string checkPassword;
            HttpCookie memberCookie;
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");

            //username
            if(TextBox1.Text.Equals(""))
            {
                Label1.Text = "Enter a username";
                return;
            }
            else
            {
                username = TextBox1.Text;//set username
            }
            
            //set password
            if(TextBox2.Text.Equals(""))
            {
                Label1.Text = "Enter a password";
                return;
            }
            else
            {
                password = TextBox2.Text;
            }

            //check password
            if(TextBox3.Text.Equals(""))
            {
                Label1.Text = "ReEnter your password";
                return;
            }
            else
            {
                checkPassword = TextBox3.Text;
            }

            //check if passwords match
            if(!password.Equals(checkPassword))
            {
                Label1.Text = "Passwords do not match";
                return;
            }

            if(CheckBox1.Checked)
            {
                memberCookie = new HttpCookie("Member");
                memberCookie.Expires = DateTime.MaxValue;//max value
            }
            else
            {
                memberCookie = new HttpCookie("Member");
                memberCookie.Expires = DateTime.MinValue;//max value
            }


            //call service refrence and store file
            string uid = username + "_" + password;
            string newAccountFile = uid + ".txt";
            //check for existing account
            if(client.checkForAccount(uid))
            {
                Label1.Text = "There is already an account with that username";
                return;
            }
            else
            {
                client.CreateAccount(newAccountFile);
                memberCookie["username"] = username;
                memberCookie["password"] = password;
                Response.Cookies.Add(memberCookie);
                Response.Redirect("Default.aspx");
                /*string targetDir = HttpContext.Current.Server.MapPath("~/AccountsToUpload/");
                string filePath = Path.Combine(targetDir, newAccountFile);
                //create file
                File.CreateText(filePath).Close();
                Label1.Text = "filepath: " + filePath + " with file name: " + newAccountFile;

                FileUpload1.PostedFile = new HttpPostedFileWrapper(new HttpPostedFile(filePath));*/
                //client.Storefile(filePath);

                /*string targetDir = HttpContext.Current.Server.MapPath("~/CacheAccountsUpload/");
                string filePath = Path.Combine(targetDir, newAccountFile);
                //create file
                File.CreateText(filePath).Close();
                byte[] cacheFileBytes = File.ReadAllBytes(filePath);
                client.UploadCacheFile(cacheFileBytes);*/

            }
            //string targetDir = HttpContext.Current.Server.MapPath("~/accounts/");
            //string newFilePath = Path.Combine(targetDir, newAccountFile);
            //File.Create(newFilePath).Close();





            //File.Copy("C:\\example.txt", filePath);

            // Save the uploaded file to the target directory
            /*HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + newAccountFile);
            HttpContext.Current.Response.TransmitFile(filePath);
            HttpContext.Current.Response.End();*/



            /*//http://localhost:63364/Service1.svc/cart/{uid}
            string baseUrl = $"http://localhost:63364/Service1.svc";
            string service = $"/cart/{uid}";
            string url = $"{baseUrl}{service}";
            //request -> response -> read system.io.stream


            //CHECK FOR USER IN UPLOADS IN SOAP SERVICE AND HAVE THE API CART CALL THE SOAP SERVICE

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);//get request
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();//get response
            StreamReader read = new StreamReader(resp.GetResponseStream());//reads the response

            //sets the response to a string after reading the stream
            string information = read.ReadToEnd();*/
            //Label1.Text = "Answer: " + newFilePath + ": you are now signed in with uid: " + uid + " and filename: " + newAccountFile;
        }


        //sign in
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInPage.aspx");
        }

        //home
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        
        //remember me // already used if(CheckBox1.Checked)
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}