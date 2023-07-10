using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HW5SOAPService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Storefile(string fileNameOrUrl);

        [OperationContract]
        bool checkForAccount(string uid);

        [OperationContract]
        void UploadCacheFile(byte[] cacheFileBytes);

        [OperationContract]
        void CreateAccount(string uid);

        [OperationContract]
        string GetAccountPassword(string username);

        [OperationContract]
        void writeReciept(string firstName, string lastName, string creditCard, string concert);

        [OperationContract]
        string[] GetRecieptList();
    }
}
