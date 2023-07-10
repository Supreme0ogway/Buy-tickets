using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HW42APIServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/cart/{userName}/{password}/{command}/{item}")]//cart/wslattus/12345/GET/sprite
        string shoppingCart(string userName, string password, string command, string item);//command: get, add, search, displayList (all caps in commands)

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/catelog?keyWord={keyWord}&printContentAmount={printContentAmount}&countryLocation={countryLocation}&searchUpToThisDay={searchUpToThisDay}")]//enter all if you want all bands")]
        string catelog(string keyWord, string printContentAmount, string countryLocation, string searchUpToThisDay);
    }
}


//service will take in the information from the url and return infromation from the cart
//working: 
//http://localhost:63364/Service1.svc/catelog/ALL/20/US/2023-08-01T12:00:00Z
//open this first before running the api
//https://app.ticketmaster.com/discovery/v2/events.json?classificationName=music&size=20&apikey=atlLoSwOAw0EXLBNyQbbigTGj4Ur9ckG&endDateTime=2023-08-01T12:00:00Z&countryCode=US
