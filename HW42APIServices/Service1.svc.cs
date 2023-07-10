using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace HW42APIServices
{

    public class Service1 : IService1
    {
        //required services stored in "CSE445HW3SOAPServer" project
        /*************** Elective Services ***************/
        /**************** Service 1 **********************/

        //command: get, add, search, displayList (all caps in commands)
        public string shoppingCart(string userName, string password, string command, string item)
        {
            //if the cart exists
            bool cartExists;

            //creates a user id
            string uid = userName + password;//all are text files (dont include .txt method calls for it not to be there)
            LinkedList<string> cart;//creates cart (initialized in command statements)

            //checks if the account exists
            //each account is stored in a file with the
            //name of the usernamePassword (nospace)


            //COPY FILES FROM SOAP TO HERE


            if (!searchForAccount(uid))//if account doesn't exist
            {
                /*************** take section out and implement with store file at local level ***********/
                //create new cart file
                string targetDir = HttpContext.Current.Server.MapPath("~/uploads/");
                string filename = uid + ".txt";
                //string filename = uid;
                string newFileFPath = Path.Combine(targetDir, filename);
                File.Create(newFileFPath).Close();//creates the new file
            }

            //sets if the cart exists
            if (!searchForCart(uid)) { cartExists = false; } else { cartExists = true; }

            //GET command to get item
            if (command == "GET" && searchForCart(uid))//checks for the user having a cart
            {
                //gets cart and index
                cart = getUserCart(uid);
                int indexOfItem = searchForItemInCart(cart, item);//-1 if it is not in it

                if (indexOfItem == -1)//item doesn't exist
                {
                    return returnJson("CUSTOME", "The item you are getting does not exist in the cart", -1);
                }
                else//item exists
                {
                    //say item is in the cart in the indexOfItem position
                    //return returnJson("CUSTOME", "THE ITEM INDEX IS : " + indexOfItem, -1);
                    return returnJson("GET", "", indexOfItem + 1);//ADD ONE BECAUSE WE START AT 1
                }
            }
            //GET command no cart
            if (!cartExists && command == "GET")
            {
                return returnJson("CUSTOME", "There is nothing in the cart", -1);
            }

            //adding to the cart //if cart doesn't exist this is the only lines you can do
            if (command == "ADD")
            {
                if (cartExists)//if the cart exists just add it
                {
                    cart = getUserCart(uid);///////error here
                    //cart.AddLast(item);//adds to cart the last spot
                    cart.AddLast(item);
                    saveListToFile(cart, uid);//saves the list cart to file <uid>.txt////////error here
                }
                else
                {
                    //create new cart and store in there
                    cart = createCart();
                    cart.AddLast(item);
                    saveListToFile(cart, uid);//saves the file
                }
                //adds the item to the cart
                return returnJson("ADD", item, -1);
            }

            //search the list
            if (command == "SEARCH" && searchForCart(uid))
            {
                //gets cart and index
                cart = getUserCart(uid);
                int indexOfItem = searchForItemInCart(cart, item);//-1 if it is not in it

                //item is in cart
                if (indexOfItem != -1 && indexOfItem >= 0)
                {
                    return returnJson("SEARCH", "", -1);
                }
                else//item not in cart
                {
                    return returnJson("CUSTOME", "Item not found. That item is not in the cart", -1);
                }
            }
            //error for search cart doesn't exist
            if (!cartExists && command == "SEARCH")
            {
                return returnJson("CUSTOME", "Item not found. No cart found", -1);
            }

            //displays the entire list
            if (command == "DISPLAYLIST" && searchForCart(uid))
            {
                cart = getUserCart(uid);//gets the cart
                return returnJsonCart(cart);
            }
            //nothing to display
            if (!cartExists && command == "DISPLAYLIST")
            {
                return returnJson("CUSTOME", "There is nothing in the cart", -1);
            }

            //delete the list
            if (command == "DELETELIST" && searchForCart(uid))
            {
                //deleteList(uid);//deletes the file and recreates it
                return returnJson("CUSTOME", "Your list has been deleted", -1);
            }
            //nothing to delete
            if (!cartExists && command == "DELETELIST")
            {
                return returnJson("CUSTOME", "There is nothing in the cart", -1);
            }

            //if there is not a correct input
            if (command != "GET" && command != "ADD" && command != "SEARCH" && command != "DISPLAYLIST")
            {
                return returnJson("INVALID", "", -1);
            }
            //dont want to change all to else if
            return returnJson("INVALID", "", -1);// ("", -1) means no input
        }

        //creates a linked list named cart
        private LinkedList<string> createCart()
        {
            return new LinkedList<string>();
        }

        //returns true if a account exists
        //takes in string username+password NOT with .txt
        private bool searchForAccount(string uid)
        {
            // target directory
            string targetDir = HttpContext.Current.Server.MapPath("~/uploads/");

            try
            {
                // get the files with extension .txt in the uploads directory
                string[] files = Directory.GetFiles(targetDir, "*.txt");
                // check if the file with the desired uid exists in the files array
                foreach (string file in files)
                {
                    if (Path.GetFileNameWithoutExtension(file).Equals(uid))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }

        //returns true if an account has a cart
        private bool searchForCart(string userID)
        {
            //get the filepath
            string targetDir = HttpContext.Current.Server.MapPath("~/uploads/");
            string filename = userID + ".txt";
            string filePath = Path.Combine(targetDir, filename);

            //open the file and read into an array
            if (new FileInfo(filePath).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //returns the linked list of the cart of the username
        private LinkedList<string> getUserCart(string userID)
        {
            //create temp LL
            LinkedList<string> temp = new LinkedList<string>();

            //get the filepath
            string targetDir = HttpContext.Current.Server.MapPath("~/uploads/");
            string filename = userID + ".txt";
            string filePath = Path.Combine(targetDir, filename);

            //read until the end
            StreamReader reader = new StreamReader(filePath);

            //get the contents
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line != null)
                {
                    temp.AddLast(line);
                }
            }

            //returns the temp and closes file
            reader.Close();
            return temp;
        }

        //save the linked list into the file by reading then writing all
        //returns true if successful
        private void saveListToFile(LinkedList<string> list, string userID)
        {
            //get the filepath
            string targetDir = HttpContext.Current.Server.MapPath("~/uploads/");
            string filename = userID + ".txt";
            string filePath = Path.Combine(targetDir, filename);

            //deletes the file so that it can save the entire list to the file 
            //without this it will only write the first line
            deleteList(userID);

            //write to file
            try
            {
                //write into the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string value in list)
                    {
                        writer.WriteLine(value);
                    }
                    writer.Close();//closes the writer
                }
            }
            catch (Exception ex)//return if it doesn't save the list so no break
            {
                return;
            }
            return;//default return
        }

        //delets all contents in the file
        //does this by deleting the file and recreating the same user file
        private void deleteList(string userID)
        {
            //get the filepath
            string targetDir = HttpContext.Current.Server.MapPath("~/uploads/");
            string filename = userID + ".txt";
            string filePath = Path.Combine(targetDir, filename);
            string newFileFPath = filePath;//extra (may delete the filepath)

            //delete the file if it exists
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.Create(newFileFPath).Close();//creates the new file
        }

        //returns the index of the first found item in the cart
        //returns -1 if it is not in cart
        private int searchForItemInCart(LinkedList<string> cart, string item)
        {
            int index = 0;//index
            foreach (string token in cart)
            {
                if (token.Equals(item))
                {
                    return index;
                }
                index++;//increments index
            }
            return -1;//default
        }

        //returns the amount of a certain item in the cart
        private int numberOfItemInCart(LinkedList<string> cart, string item)
        {
            int count = 0;
            int index = 0;
            LinkedList<int> locations = new LinkedList<int>();

            foreach (string token in cart)
            {
                if (token.Equals(item))
                {
                    count++;
                    locations.AddLast(index);
                }
                index++;//increments index
            }
            return count;
        }

        //returns all of the locations of of the item in the cart by index using a linked list
        private LinkedList<int> locationsOfItemsInCart(LinkedList<string> cart, string item)
        {
            int index = 0;
            LinkedList<int> locations = new LinkedList<int>();

            foreach (string token in cart)
            {
                if (token.Equals(item))
                {
                    locations.AddLast(index);
                }
                index++;//increments index
            }
            return locations;
        }

        private string returnJsonCart(LinkedList<string> cart)
        {
            var result = new Dictionary<string, object>();

            string[] cartStr = cart.ToArray();

            result["Cart"] = cartStr;

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(result);
        }

        //returns strings and Json format
        private string returnJson(string command, string item, int index)
        {
            //create a result to store json in
            var result = new Dictionary<string, object>();

            //no input ("", -1)
            if (command.Equals("") && item.Equals("") && index <= -1)//for 0 input
            {
                result["error"] = "invalid input, account does not exist";
                //return "[ERROR]: invalid input";
                //return json invalid
            }

            //GET COMMAND   
            if (command.Equals("GET") && (index != -1))
            {
                //return the item
                result["item"] = "The placment of your item is: " + index;
            }

            //ADD command
            if (command.Equals("ADD") && (!item.Equals("")) && index <= -1)
            {
                //add say it was added
                result["message"] = "item added";
            }

            //SEARCH command
            if (command.Equals("SEARCH") && item.Equals("") && index <= -1)//if this is called it has already been found just pint out that it is in there
            {
                //print out it has been found
                result["message"] = "item found";
            }

            //INVALID command
            if (command.Equals("INVALID") && item.Equals("") && index <= -1)
            {
                //return json invalid
                result["error"] = "invalid URL";
            }

            //for custome messages
            if (command.Equals("CUSTOME"))
            {
                result["RESULT"] = item;
            }

            //return json invalid
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(result);
        }

        /*************** Service 2 *****************/
        //returns the desired band or all bands
        public string catelog(string keyWord, string printContentAmount, string countryLocation, string searchUpToThisDay)//http://localhost:64673/Service1.svc/catelog/Wallen
        {
            //http://localhost:63364/Service1.svc/catelog/ALL/20/US/2023-08-01T12:00:00Z
            //http://localhost:63364/Service1.svc/catelog?keyWord=ALL&printContentAmount=20&countryLocation=US&searchUpToThisDay=2023-08-01T12:00:00Z
            //api details
            //https://app.ticketmaster.com/discovery/v2/events.json?classificationName=music&size=20&apikey=atlLoSwOAw0EXLBNyQbbigTGj4Ur9ckG&endDateTime=2023-08-01T12:00:00Z&countryCode=US
            //get api for ticket master displaying the catelog
            string apikey = "atlLoSwOAw0EXLBNyQbbigTGj4Ur9ckG";
            //all events in the us
            string printSizeStr = printContentAmount;
            int printSizeInt;

            try
            {
                printSizeInt = int.Parse(printSizeStr);
            }
            catch (Exception ex)
            {
                return "[Error]: Invalid amount of concerts.";
            }
            
            string url;
            string baseUrl = $"https://app.ticketmaster.com";
            string country = countryLocation;// $"US";//set as default
            string upToDateSearch = searchUpToThisDay;// $"2023-08-01T12:00:00Z";//set as default

            if (keyWord.Equals("ALL"))
            {
                url = $"{baseUrl}/discovery/v2/events.json?classificationName=music&size={printSizeInt}&apikey={apikey}&endDateTime={upToDateSearch}&countryCode={country}";
            }
            else
            {
                url = $"{baseUrl}/discovery/v2/events.json?apikey={apikey}&keyword={keyWord}&endDateTime={upToDateSearch}&size={printSizeInt}&countryCode={country}";

            }

            //request -> response -> read system.io.stream
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);//get request
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();//get response
            StreamReader read = new StreamReader(resp.GetResponseStream());//reads the response

            //reads
            string info = read.ReadToEnd();

            //gets response
            EventResponse response = JsonConvert.DeserializeObject<EventResponse>(info);

            //builds string
            StringBuilder sb = new StringBuilder();
            //checks the response to output to string
            if (response != null && response._embedded != null && response._embedded.events != null && response._embedded.events.Any())
            {
                foreach (Event even in response._embedded.events)
                {
                    string eventName = even.name;
                    string eventID = even.id;
                    string eventDate = even.dates.start.localDate;
                    sb.Append("Event Name: ");
                    sb.AppendLine(eventName);
                    sb.Append(" | ");
                    sb.Append("Event ID: ");
                    sb.AppendLine(eventID);
                    sb.Append(" | ");
                    sb.AppendLine("Event date: ");
                    sb.AppendLine(eventDate);
                    sb.AppendLine("*********************");
                }
            }
            else
            {
                // handle the case when there are no events
                sb.Append("There is no data in the response");
            }

            //returns information closes reader/writer
            read.Close();
            return sb.ToString();
        }
    }

    //classes for the getter and setter of the newtonsoft
    /*********** for second service 2 (catelog) **********************/
    public class EventResponse
    {
        public Embedded _embedded { get; set; }
    }

    public class Embedded
    {
        public List<Event> events { get; set; }
    }

    public class Event
    {
        public string name { get; set; }
        public string id { get; set; }
        public Dates dates { get; set; }
        public List<Classification> classifications { get; set; }
    }

    public class Dates
    {
        public Start start { get; set; }
    }

    public class Start
    {
        public string localDate { get; set; }
        public string localTime { get; set; }
    }

    public class Classification
    {
        public Segment segment { get; set; }
    }

    public class Segment
    {
        public string name { get; set; }
    }
    /********************* end of service 2 ********************/
}
