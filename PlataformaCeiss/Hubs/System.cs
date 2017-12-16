using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PlataformaCeiss.Hubs
{
    public class System : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
        public bool AddTo(string GroupName)
        {
            var ClientId = Context.ConnectionId;
            Groups.Add(ClientId, GroupName);
            return true;
        }
        public void SendGroupMessage(string GroupName, string message)
        {
            Clients.Group(GroupName).DisplayMessage(message);
        }
        public void Hello()
        {

            var clientId = Context.ConnectionId;




            Clients.All.hello();

        }
    }
}