using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace HW5SOAPService
{
    public class Service1 : IService1
    {
        /**************** Required services ***************/
        //upload the file path and it will save the file to the server and return a url
        //stores file inside the server (SOAP service)
        public string Storefile(string localFilePath)
        {
            //gets the file name
            string fileName = Path.GetFileName(localFilePath);
            //adds the filename to the localhost server files
            string serverPath = "http://localhost:61708/uploads/" + fileName;
            //gets a target filepath and makes one
            string targetFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~/reciepts/"), fileName);

            // Copy the uploaded file to the target file path on the server
            File.Copy(localFilePath, targetFilePath);

            return serverPath;//return the url
        }

        //returns all reciepts
        public string[] GetRecieptList()
        {

            /*// Specify the directory path
            string directoryPath = HttpContext.Current.Server.MapPath("~/reciepts/");

            // Get all the file names in the directory
            string[] fileNames = Directory.GetFiles(directoryPath);

            // Convert the array to a list
            string[] fileList = fileNames.ToArray();

            return fileList;*/
            // Specify the directory path
            string directoryPath = HttpContext.Current.Server.MapPath("~/reciepts/");

            // Get all the file names in the directory
            string[] filePaths = Directory.GetFiles(directoryPath);

            // Extract the file names from the file paths
            string[] fileNames = new string[filePaths.Length];
            for (int i = 0; i < filePaths.Length; i++)
            {
                fileNames[i] = Path.GetFileName(filePaths[i]);
            }

            return fileNames;
        }

        //create reciept
        public void writeReciept(string firstName, string lastName, string creditCard, string concert)
        {
            //call service refrence and store file
            string targetDir = HttpContext.Current.Server.MapPath("~/reciepts/");
            string newFilePath = Path.Combine(targetDir, firstName + ".txt");

            string directoryPath = HttpContext.Current.Server.MapPath("~/reciepts/");
            string filePath = Path.Combine(directoryPath, firstName + ".txt");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (StreamWriter writer = new StreamWriter(newFilePath))
            {
                writer.WriteLine("Name: " + firstName + " " + lastName);
                writer.WriteLine("Card number: " + creditCard);
                writer.WriteLine(concert);
                writer.Close();
            }
        }

        //create an account
        public void CreateAccount(string uid)
        {
            string targetDir = HttpContext.Current.Server.MapPath("~/accounts/");
            string filePath = Path.Combine(targetDir, uid);
            //create file
            File.CreateText(filePath).Close();
        }

        //upload cache
        public void UploadCacheFile(byte[] cacheFileBytes) {

        }

        //plug in with no extention
        public bool checkForAccount(string uid)
        {
            string targetDir = HttpContext.Current.Server.MapPath("~/accounts/");
            string prefix = uid.Substring(0, uid.IndexOf('_'));

            try
            {
                //get files with extention
                string[] files = Directory.GetFiles(targetDir, prefix + "*.txt");
                if(files.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)//error exception
            {
                return false;
            }
        }

        //gets the password of the user
        public string GetAccountPassword(string username)
        {
            string targetDir = HttpContext.Current.Server.MapPath("~/accounts/");

            string[] files = Directory.GetFiles(targetDir); // Get all files in the folder
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (fileName.StartsWith(username + "_")) // Check if the prefix matches the file name
                {
                    string password = fileName.Substring(username.Length + 1);
                    return password; // Return the file path if a match is found
                }
            }
            return "";
        }
    }
}
