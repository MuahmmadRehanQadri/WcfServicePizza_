using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServicePizza
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace="http://pizzaapp.apphb.com/")]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(UriTemplate="SignUp",
            Method="POST",
            BodyStyle=WebMessageBodyStyle.WrappedRequest,
            ResponseFormat=WebMessageFormat.Json,
            RequestFormat=WebMessageFormat.Json)]
        bool SignUp(Customer customer);

        [OperationContract]
        [WebGet(UriTemplate="Login/{phoneNo}/{password}",
            BodyStyle=WebMessageBodyStyle.WrappedRequest,
            RequestFormat=WebMessageFormat.Json,
            ResponseFormat=WebMessageFormat.Json)]
        string Login(string phoneNo, string password);

        [OperationContract]
        [WebInvoke(Method="POST", BodyStyle=WebMessageBodyStyle.WrappedRequest,RequestFormat=WebMessageFormat.Json,ResponseFormat=WebMessageFormat.Json,UriTemplate="CreatePizza")]
        bool CreatePizza(Pizza pizza);

        [OperationContract]
        [WebInvoke(Method="POST",BodyStyle=WebMessageBodyStyle.WrappedRequest, RequestFormat=WebMessageFormat.Json,ResponseFormat=WebMessageFormat.Json, UriTemplate="OrderPizza")]
        bool OrderPizza(Order order, List<OrderDetail> orderDetails);

        [OperationContract]
        [WebGet(BodyStyle=WebMessageBodyStyle.WrappedRequest, RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json,UriTemplate="GetAllOrders")] 
        List<Order> GetAllOrders();

        [OperationContract]
        [WebGet(BodyStyle=WebMessageBodyStyle.WrappedRequest, RequestFormat=WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json,UriTemplate="GetOrderDetails/{orderId}")]
        List<OrderDetail> GetOrderDetails(string orderId);
        
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
