using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4WebSiteApplication
{
    public partial class RecieptPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie memberCookie = Request.Cookies["Member"];

            Label1.Text = memberCookie["firstName"].ToString() + " " + memberCookie["lastName"];
            Label2.Text = memberCookie["creditCard"].ToString();

            string path = HttpContext.Current.Server.MapPath("cacheFile.txt");
            string fileContents = File.ReadAllText(path);
            HttpRuntime.Cache.Insert("concert", fileContents, new CacheDependency(path));
            string printableConcert = HttpRuntime.Cache["concert"] as string;
            Label3.Text = printableConcert;
        }

        //home
        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //download
        protected void Button9_Click(object sender, EventArgs e)
        {
            //download the reciedpt and upload it to service
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            HttpCookie memberCookie = Request.Cookies["Member"];
            string firstName = memberCookie["firstName"];
            string lastName = memberCookie["lastName"];
            string creditCard = memberCookie["creditCard"];
            string concert = HttpRuntime.Cache["concert"] as string;
            client.writeReciept(firstName, lastName, creditCard, concert);

            string recieptFileName = firstName + ".txt";

            //call service refrence and store file
            string targetDir = HttpContext.Current.Server.MapPath("~/recieptDownloads/");
            string newFilePath = Path.Combine(targetDir, recieptFileName);

            string directoryPath = HttpContext.Current.Server.MapPath("~/recieptDownloads/");
            string filePath = Path.Combine(directoryPath, firstName + ".txt");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter writer = new StreamWriter(newFilePath))
            {
                writer.WriteLine("Name: " + firstName + " " + lastName);
                writer.WriteLine("Card number: " + creditCard);
                string printableConcert = HttpRuntime.Cache["concert"] as string;
                writer.WriteLine(printableConcert);
                writer.Close();
            }
            // Save the uploaded file to the target directory
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + recieptFileName);
            HttpContext.Current.Response.TransmitFile(newFilePath);
            HttpContext.Current.Response.End();
        }
    }
}