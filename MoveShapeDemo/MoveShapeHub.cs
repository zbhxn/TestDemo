using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoveShapeDemo
{
    public class MoveShapeHub : Hub
    {
        public void UpdateModel(ShapeModel clientModel)
        {
            clientModel.LastUpdatedBy = Context.ConnectionId;
            // Update the shape model within our broadcaster
            Clients.AllExcept(clientModel.LastUpdatedBy).updateShape(clientModel);
        }
    }

    public class ShapeModel
    {
        //我们使用JsonProperty将Left和Top声明为小写，以同步客户端和服务器模型
        [JsonProperty("left")]
        public double Left { get; set; }
        [JsonProperty("top")]
        public double Top { get; set; }
        //我们不希望客户端获取“LastUpdatedBy”属性
        [JsonIgnore]
        public string LastUpdatedBy { get; set; }
    }
}