using ArkadiuszGrygorukServer.DAL;
using ArkadiuszGrygorukServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ArkadiuszGrygorukServer.Controllers
{
    public class GuestBookingController : ApiController
    {
        // GET: api/GuestBooking
        private HotelContext db = new HotelContext();
        JavaScriptSerializer json_serializer = new JavaScriptSerializer();
        public IEnumerable<Booking> Get()
        {
            var bookings = db.Bookings.ToList();

            //remove backtrack references
            foreach (var item in bookings)
            {
                foreach (var item1 in item.GuestBookings)
                {
                    item1.Booking = null;
                    item1.Guest.GuestBookings = null;

                }
            }
            return bookings;
        }

        // GET: api/GuestBooking/5
        public Booking Get(int id)
        {
            var querry =  db.Bookings.Where(r => r.ID == id).FirstOrDefault();
            return querry;
        }

        // POST: api/GuestBooking
        //save booking with 
        public void Post([FromBody]Booking value)
        {
            //Booking booking = (Booking)json_serializer.DeserializeObject(value);

            db.Bookings.Add(value);
            db.SaveChanges();
        }

        // DELETE: api/GuestBooking
        //remove all bookings
        public void Delete()
        {
            var bookings = db.Bookings.ToList();
            bookings.ForEach(r => db.Bookings.Remove(r));
            db.SaveChanges();
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
