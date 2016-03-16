using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace SignalR.Controllers
{
    public class EntitySetControllerWithHub<THub> : EntitySetController<Employee, int>
         where THub : IHub
    {
        Lazy<IHubContext> hub = new Lazy<IHubContext>(
            () => GlobalHost.ConnectionManager.GetHubContext<THub>());

        protected IHubContext Hub {
            get { return hub.Value; }
        }
 
    }
    
   
}
