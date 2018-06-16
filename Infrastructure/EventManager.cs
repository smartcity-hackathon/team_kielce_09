using GameX.DAL;
using GameX.HelperClass;
using GameX.Models;
using GameX.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.Infrastructure
{
    public class EventManager : IEvent
    {
        private readonly StoreContext context;
        public List<CoordAddress> CoordAddresses { get; set; }
        public EventManager(StoreContext context)
        {
            this.context = context;
            this.CoordAddresses = new List<CoordAddress>();

        }

        public void Add(EventInputModel Event)
        {
            EventAdress eventAdress = new EventAdress();
            if (Event.EventAdressId == null)
            {
                eventAdress.City = Event.City;
                eventAdress.HouseNumber = Event.HouseNumber;
                eventAdress.PostCode = Event.PostCode;
                eventAdress.Street = Event.Street;
            }


            Events EventRecord = new Events
            {
                Date = Event.Date,
                Coords = null,
                Name = Event.Name,
                Description = Event.Description,
                DisciplineId = Event.DiciplineId,
                Limit = Event.Limit,
            };

            try
            {

                if (Event.EventAdressId != null)
                {
                    EventRecord.EventAdressId = (int)Event.EventAdressId;
                }
                else
                {
                    context.EventAdress.Add(eventAdress);
                    context.SaveChanges();
                    EventRecord.EventAdressId = eventAdress.EventAdressId;
                }
                context.Events.Add(EventRecord);
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public void Edit(EventInputModel Event)
        {
            EventAdress eventAdress = new EventAdress();
            if (Event.SelectedEventAddressID == 0)
            {
                eventAdress.City = Event.City;
                eventAdress.HouseNumber = Event.HouseNumber;
                eventAdress.PostCode = Event.PostCode;
                eventAdress.Street = Event.Street;
                eventAdress.EventAdressId = (int)Event.EventAdressId;
            }


            Events EventRecord = new Events
            {
                Date = Event.Date,
                Coords = null,
                Name = Event.Name,
                EventId = (int)Event.EventId,
                DisciplineId = Event.DiciplineId,
                Limit = Event.Limit,
                Description = Event.Description,

            };
            try
            {
                if (Event.EventAdressId != null)
                {
                    EventRecord.EventAdressId = (int)Event.EventAdressId;

                }
                else
                {
                    context.EventAdress.Update(eventAdress);
                }

                context.SaveChanges();

                context.Events.Update(EventRecord);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(int EventID)
        {
            Events Event = context.Events.FirstOrDefault(x => x.EventId == EventID);
            try
            {
                context.Events.Remove(Event);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CoordAddress> getEventsAddress()
        {

            List<Events> Events = context.Events.Include(x => x.EventAdress).ToList();
            foreach (var adress in Events)
            {
                CoordAddress co = new CoordAddress()
                {
                    City = adress.EventAdress.City,
                    HouseNumber = adress.EventAdress.HouseNumber,
                    Street = adress.EventAdress.Street,
                    EventAdressId = adress.EventAdress.EventAdressId,
                    EventId = adress.EventId,
                    Content = adress.Description
                };
                CoordAddresses.Add(co);

            }
            return CoordAddresses;


        }

        public void SaveCoords(double lat, double lng, int EventAdressId)
        {
            EventAdress EventAddress = context.EventAdress.FirstOrDefault(x => x.EventAdressId == EventAdressId);
            try
            {
                EventAddress.Lat = lat;
                EventAddress.Lng = lng;
                context.EventAdress.Update(EventAddress);
                context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public MarkerContent GetContent(int EventId)
        {
            Events Event = context.Events.Include(x => x.EventAdress).FirstOrDefault(x => x.EventId == EventId);


            MarkerContent content = new MarkerContent()
            {
                Name = Event.Name,
                Description = Event.Description,
                Data = Event.Date.ToString(@"MM\/dd\/yyyy HH:mm"),
                //Discipline = Event.Discipline.Name,
                Discipline = Event.Discipline == null ? "" : Event.Discipline.Name,
                Adress = (Event.EventAdress.City + Event.EventAdress.Street + Event.EventAdress.HouseNumber),
                Limit = Event.Limit,
                ParticipantsCount = context.EventParticipants.Where(x => x.EventID == EventId).Count(),
                EventParticipents = context.EventParticipants.Include(x => x.Users).Where(x=>x.EventID== EventId).Select(x => x.Users.UserName).ToList()
            };


            return content;
        }
        public List<Disciplines> getDisciplines()
        {
            List<Disciplines> disciplines = context.Disciplines.ToList();
            return disciplines;

        }

    }
}

