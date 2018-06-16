using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameX.DAL;
using GameX.HelperClass;
using GameX.Infrastructure;
using GameX.Models;
using GameX.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GameX.Controllers
{
    public class EventController : Controller
    {
        private readonly StoreContext context;
        private IEvent EventManager { get; set; }
        private IEventJoinManager EventJoinManager { get; set; }
        public EventController(StoreContext context)
        {
            this.EventManager = new EventManager(context);
            this.EventJoinManager = new EventJoinManager(context);
            this.context = context;
        }
        public IActionResult Index()
        {
            EventViewModel Model = new EventViewModel();
            Model.Events = context.Events.Include(x => x.EventAdress).ToList();
            return View(Model);
        }
        public IActionResult Add()
        {
            var model = new EventAddressModel();
            model.Address = this.EventManager.getEventsAddress();
            model.Disciplines = this.EventManager.getDisciplines();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(EventInputModel Event)
        {
            this.EventManager.Add(Event);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int EventId)
        {

            Events Event = context.Events.Include(x => x.EventAdress).FirstOrDefault(x => x.EventId == EventId);
            EventInputModel model = new EventInputModel()
            {
                Name = Event.Name,
                City = Event.EventAdress.City,
                Street = Event.EventAdress.Street,
                Date = Event.Date,
                HouseNumber = Event.EventAdress.HouseNumber,
                PostCode = Event.EventAdress.PostCode,
                EventId = Event.EventId,
                EventAdressId = Event.EventAdressId,
                Description = Event.Description,
                Disciplines = context.Disciplines.ToList(),
                Address = this.EventManager.getEventsAddress(),
                SelectedDisciplineID = Event.DisciplineId,
                SelectedEventAddressID = Event.EventAdressId,
                Limit = Event.Limit,
            };

            //this.EventManager.Add(Event);
            return View(model);
        }
        public IActionResult Map()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(EventInputModel Event)
        {
            this.EventManager.Edit(Event);
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public IActionResult Remove(int EventID)
        {
            this.EventManager.Delete(EventID);
            return View();
        }
        [HttpGet]
        public JsonResult getEventsAddress()
        {
            List<CoordAddress> coordAddresses= this.EventManager.getEventsAddress();
            var json = JsonConvert.SerializeObject(coordAddresses);
          
            return Json(new { json} );
        }
        [HttpPost]
        public JsonResult saveEventsCoords(double lat,double lng,int  EventAdressId)
        {
            this.EventManager.SaveCoords(lat, lng, EventAdressId);

            return Json(new { });
        }

        public JsonResult getContent(int EventId)
        {
            MarkerContent content = this.EventManager.GetContent(EventId);
            var json = JsonConvert.SerializeObject(content);
            

            return Json(new { json });
        }
        public JsonResult Join(int EventID,string userID)
        {
            this.EventJoinManager.Join(EventID, userID);


            return Json(new { });
        }

    }
}