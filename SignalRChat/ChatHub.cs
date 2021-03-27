using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        //在hub上声明public方法，以便客户端可以调用它们。
        public void Send(string name, string message)
        {
            //使用Microsoft.AspNet.SignalR.Hub.Clients动态属性与连接到此hub上的所有客户端通信。
            //在客户端上调用一个函数（如broadcastMessage函数）以更新客户端。
            //调用broadcastMessage方法来更新客户端。
            Clients.All.broadcastMessage(name, message);
        }
    }
}