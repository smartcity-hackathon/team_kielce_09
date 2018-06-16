using GameX.HelperClass;
using GameX.Models;
using GameX.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.Infrastructure
{
    public interface IEvent
    {
        void Add(EventInputModel Event);

        void Edit(EventInputModel Event);


        void Delete(int EventID);

        List<CoordAddress> getEventsAddress();

        void SaveCoords(double lat, double lng,int EventAdressId);


        MarkerContent GetContent(int EventId);


        List<Disciplines> getDisciplines();

    }
}
