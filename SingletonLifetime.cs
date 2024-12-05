//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;

//namespace Dotnet
//{

//    public class orders
//    {
//        public int id { get; set; }
//        public string name { get; set; }

//    }
//    public interface IOrders
//    {
//        List<orders> GetOrders();
//    }

//    public interface IGuid
//    {
//        Guid GetInstanceId();
//    }

//    public class OrderDetails : IOrders, IGuid
//    {
//        Guid _instanceId = Guid.NewGuid();


//        public List<orders> GetOrders()
//        {
//            List<orders> orderlist = new List<orders>()
//            {
//                new orders {id = 1 , name = "Pencil"},
//                new orders {id = 2 , name = "Eraser" },
//                new orders {id = 3 , name = "Box" }
//            };

//            return orderlist;
//        }

//        public Guid GetInstanceId()
//        {
//            return _instanceId;
//        }


//        public class Cart
//        {
//            private readonly IOrders _orderDetails;
//            private readonly IGuid _instanceId;
//            public Cart(IOrders orderDetails, IGuid _instanceId)
//            {
//                this._orderDetails = orderDetails;
//                this._instanceId = _instanceId;
//            }

//            public List<orders> Print()
//            {
//                return _orderDetails.GetOrders();
//            }

//            public Guid GetGuid()
//            {
//                return _instanceId.GetInstanceId();
//            }
//        }

//        public class Cart1
//        {
//            private readonly IOrders _orderDetails;
//            private  IGuid _instanceId;
//            public Cart1(IOrders orderDetails, IGuid _instanceId)
//            {
//                this._orderDetails = orderDetails;
//                this._instanceId = _instanceId;
//            }

//            public List<orders> Print()
//            {
//                return _orderDetails.GetOrders();
//            }

//            public Guid GetGuid()
//            {
//                return _instanceId.GetInstanceId();
//            }
//        }


//        internal class SingletonLifetime
//        {
//            public static void Main(string[] args)
//            {
//                var services = new ServiceCollection();

//                services.AddSingleton<IOrders, OrderDetails>();
//                services.AddSingleton<IGuid, OrderDetails>();
//                //services.AddSingleton<Cart>();


//                var serviceProvider = services.BuildServiceProvider();

//                var cart = new Cart(new OrderDetails(), new OrderDetails());
//                var cart1 = new Cart1(new OrderDetails(), new OrderDetails());
                
//                cart1.GetGuid();

//                Console.WriteLine(cart.GetGuid());
//                Console.WriteLine(cart1.GetGuid());

//                //var GetService = new Cart(new OrderDetails() , new OrderDetails());

//                //var result = GetService.Print();
//                //Console.WriteLine(GetService.GetGuid());

//                //foreach (var item in result)
//                //{
//                //    Console.WriteLine(item.name);
//                //}



//            }
//        }
//    }
//}
