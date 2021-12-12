using _2_SignalRConsoleClient.Models;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _2_SignalRConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var querystringData = new Dictionary<string, string>
            {
                { "contosochatversion", "1.0" }
            };
            using (var hubConnection = new HubConnection("http://localhost:51310/", querystringData))
            {
                hubConnection.Headers.Add("headername", "headervalue");
                hubConnection.TraceLevel = TraceLevels.All;
                hubConnection.TraceWriter = Console.Out;

                hubConnection.Received += data =>
                {
                    //客户端方法收到参数，会调用。调用服务端方法传参，不会调用。调用服务端方法返回值，不会调用。
                    Console.WriteLine("Received: {0}", JsonConvert.SerializeObject(data));
                };
                hubConnection.ConnectionSlow += () =>
                {
                    Console.WriteLine("ConnectionSlow");
                };
                hubConnection.Reconnecting += () =>
                {
                    Console.WriteLine("Reconnecting");
                };
                hubConnection.Reconnected += () =>
                {
                    Console.WriteLine("Reconnected");
                };
                hubConnection.StateChanged += (stateChanged) =>
                {
                    Console.WriteLine("StateChanged: {0}", JsonConvert.SerializeObject(stateChanged));
                };
                hubConnection.Closed += () =>
                {
                    Console.WriteLine("Closed");
                };

                hubConnection.Error += ex =>
                {
                    Console.WriteLine("SignalR error: {0}", ex.Message);
                };

                IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("StockTickerHub");
                stockTickerHubProxy.On<Stock>("UpdateStockPrice", stock =>
                {
                    Console.WriteLine("Stock update for {0} new price {1}", stock.Symbol, stock.Price);
                });
                ServicePointManager.DefaultConnectionLimit = 10;
                await hubConnection.Start();

                await stockTickerHubProxy.Invoke("JoinGroup", "StockTicker");

                //在收到调用结果之前，连接已开始重新连接。
                var stocks = await stockTickerHubProxy.Invoke<IEnumerable<Stock>>("AddStock", new Stock() { Symbol = "MSFT" });
                foreach (Stock stock in stocks)
                {
                    Console.WriteLine(string.Format("Symbol: {0} price: {1}", stock.Symbol, stock.Price));
                }
            }

            Console.ReadKey();
        }
    }
}
