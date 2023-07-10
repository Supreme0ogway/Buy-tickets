using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HW4WebSiteApplication
{
    public partial class FilesPage : System.Web.UI.Page
    {
        //print out file list
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            string[] allFiles = client.GetRecieptList();
            string list = "";
            for(int i = 0; i < allFiles.Length; i++)
            {
                list += allFiles[i] + " --- ";
            }

            Label1.Text = list;
        }

        //home
        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //upload reciepts
        protected void Button4_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");

            if(FileUpload1.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    string localFilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(localFilePath);
                    string serverPath = client.Storefile(localFilePath);
                    Label2.Text = "[File uploaded]";
                    Response.Redirect("FilesPage.aspx");
                }
                catch (Exception ex)
                {
                    Label2.Text = "[Error]: " + ex.Message;
                }
            }
            else
            {
                Label2.Text = "No file selected.";
            }
        }
    }
}