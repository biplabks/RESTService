using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestServiceJSON
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceMessage" in both code and config file together.
    [ServiceContract]
    public interface IServiceMessage
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findAll", ResponseFormat = 
            WebMessageFormat.Json)]
        List<Message> findAll();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "find/{id}", ResponseFormat =
            WebMessageFormat.Json)]
        Message find(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat =
            WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json)]
        bool create(Message message);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", ResponseFormat =
    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool edit(Message message);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat =
    WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool delete(Message message);
    }
}
