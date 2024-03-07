using AutoMapper;
using IPBLL;
using IPDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripTaskEFApp.Models;

namespace TripTaskEFApp.Controllers
{
    public class TripController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
         
        [HttpGet]
        public JsonResult GetTrips()
        {
            TripService tripService = new TripService();
            var trips = tripService.GetTrips();

            List<TripVM> tripVMs = new List<TripVM>();
            
             
            Mapper.Map(trips, tripVMs);

            return Json(tripVMs, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTripById(int Id)
        {
            TripService tripService = new TripService();
            var trip = tripService.GetTrip(Id);
            return Json(trip, JsonRequestBehavior.AllowGet);
 
        }

        [HttpPost]

        public JsonResult AddTrip(Trip trip)
        {
            TripService tripService = new TripService();
            var tripAdded = tripService.AddTrip(trip);  
             
            return Json(tripAdded , JsonRequestBehavior.AllowGet);
        }


        [HttpPost]

        public JsonResult UpdateTrip(Trip trip)
        { 
            TripService tripService = new TripService();
            var tripUpdated = tripService.UpdateTrip(trip);
            return Json(tripUpdated, JsonRequestBehavior.AllowGet); 
        }
         
        [HttpPost]

        public JsonResult DeleteTrip(int tripId)
        {
            TripService tripService = new TripService();
            if (tripService.DeleteTrip(tripId))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }

    }

}

