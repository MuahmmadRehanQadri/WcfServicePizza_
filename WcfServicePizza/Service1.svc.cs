using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServicePizza
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {

        public bool SignUp(Customer customer)
        {
            try
            {
                DatabasePizzaEntities db = new DatabasePizzaEntities();
                db.Customers.Add(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Login(string phoneNo, string password)
        {
            decimal phoneNoDecimal = Decimal.Parse(phoneNo);
            DatabasePizzaEntities db = new DatabasePizzaEntities();
            Customer customer = db.Customers.Where(c => c.PhoneNo==phoneNoDecimal && c.Password == password).SingleOrDefault();
            if (customer == null)
                return false;
            return true;
        }

        public bool CreatePizza(Pizza pizza)
        {
            try
            {
                DatabasePizzaEntities db = new DatabasePizzaEntities();
                db.Pizzas.Add(pizza);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool OrderPizza(Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                DatabasePizzaEntities db = new DatabasePizzaEntities();
                db.Orders.Add(order);
                foreach (var orderDetail in orderDetails)
                {
                    db.OrderDetails.Add(orderDetail);
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Order> GetAllOrders()
        {
            DatabasePizzaEntities db = new DatabasePizzaEntities();
            var orders = db.Orders;
            List<Order> ordersList = null;
            if (orders != null)
            {
                ordersList = new List<Order>();
            }
            foreach (var order in orders)
            {
                ordersList.Add(order);
            }
            return ordersList;
        }


        public List<OrderDetail> GetOrderDetails(string orderId)
        {
            int orderIdInt = Int32.Parse(orderId);
            DatabasePizzaEntities db = new DatabasePizzaEntities();
            var orderDetails = db.OrderDetails.Where(o => o.OrderId == orderIdInt);
            List<OrderDetail> orderDetailsList = null;
            if (orderDetails != null)
            {
                orderDetailsList = new List<OrderDetail>();
            }
            foreach (var order in orderDetails)
            {
                orderDetailsList.Add(order);
            }
            return orderDetailsList;
        }
    }
}
