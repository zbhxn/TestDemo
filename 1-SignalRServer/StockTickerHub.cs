using _1_SignalRServer.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace _1_SignalRServer
{
    public class StockTickerHub : Hub
    {
        public override Task OnConnected()
        {
            var version = Context.QueryString["contosochatversion"];
            if (version != "1.0")
            {
                //没有客户端方法，示例
                Clients.Caller.notifyWrongVersion();
            }
            Console.WriteLine("OnConnected");

            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("OnReconnected");
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine("OnDisconnected: {0}", stopCalled);
            return base.OnDisconnected(stopCalled);
        }

        public void JoinGroup(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

        public IEnumerable<Stock> AddStock(Stock stock)
        {
            Clients.All.UpdateStockPrice(stock);

            //在这里打断点，等几秒钟，可以模拟客户端ConnectionSlow、Reconnecting、Reconnected
            return new List<Stock>() { stock, new Stock { Symbol = "xxx", Price = 100 } };
        }
    }
}