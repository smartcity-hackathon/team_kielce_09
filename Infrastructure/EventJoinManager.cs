using GameX.Controllers;
using GameX.DAL;
using GameX.HelperClass;
using GameX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.Infrastructure
{
    public class EventJoinManager : IEventJoinManager
    {
        private readonly StoreContext context;
        public EventJoinManager(StoreContext context)
        {
            this.context = context;
        }
        public void Join(int EventID,string UserID)
        {
            EventParticipants participants = new EventParticipants()
            {
                EventID = EventID,
                UserID = UserID
            };
            context.EventParticipants.Add(participants);
            context.SaveChanges();
        }
    }
}
