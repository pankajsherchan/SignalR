using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalR.Models;
using System.Collections.Concurrent;

namespace SignalR.Hubs
{
    [HubName("employee")]
    public class EmployeeHub : Hub
    {
        //    private SignalRContext db = new SignalRContext();

        //    private static ConcurrentDictionary<string, List<int>> _mapping = new ConcurrentDictionary<string, List<int>>();





        //    public override System.Threading.Tasks.Task OnConnected() {
        //        _mapping.TryAdd(Context.ConnectionId, new List<int>());
        //        Clients.All.newConnection(Context.ConnectionId);
        //        return base.OnConnected();

        //    }


        //    public void Lock(int id)
        //    {
        //        var employeeToPatch = db.Employees.Find(id);
        //        employeeToPatch.Locked = true;
        //        db.Entry(employeeToPatch).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        Clients.Others.lockemployee(id);
        //    }

        //    public void Unlock(int id) {

        //        var employeeToPatch = db.Employees.Find(id);
        //        employeeToPatch.Locked = false;
        //        db.Entry(employeeToPatch).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        Clients.Others.unlockemployee(id);

        //    }


        //}
    }
}