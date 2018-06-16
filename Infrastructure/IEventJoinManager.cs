using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.Infrastructure
{
    interface IEventJoinManager
    {
        void Join(int EventID,string UserID);
    }
}
