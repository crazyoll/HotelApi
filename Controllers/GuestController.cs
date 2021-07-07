using ArkadiuszGrygorukServer.DAL;
using ArkadiuszGrygorukServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ArkadiuszGrygorukServer.Controllers
{
    public class GuestController : ApiController
    {
        private HotelContext db = new HotelContext();
        JavaScriptSerializer json_serializer = new JavaScriptSerializer();
        // GET: api/Guest
        public IEnumerable<Guest> Get()
        {
            IEnumerable<Guest> guests = new List<Guest>();
            //guests = db.Guests.ToList();
            //using (HotelContext db1 = new HotelContext())
            //{
            //    guests = db1.Guests.ToList();
            //}
            //foreach (var item in guests)
            //{
            //    item.GuestBookings = null;
            //}
            //IEnumerable<Guest> guests =
            //    from g in db.Guests
            //    select new Guest
            //    {
            //        Address = g.Address,
            //        BirthDate = g.BirthDate,
            //        City = g.City,
            //        Email = g.Email,
            //        ID = g.ID,
            //        Name = g.Name,
            //        PhoneNumber = g.PhoneNumber,
            //        Surname = g.Surname,
            //        ZipCode = g.ZipCode
            //    };
            //var dat = json_serializer.Serialize(data);
            return guests;
        }
        // DELETE: api/Guest
        //remove all guests with name Piotr and from city Wrocław or not
        public void Delete()
        {
            var querry =
                from g in db.Guests
                where g.Name == "Piotr" && (g.City == null || g.City == "Wrocław")
                select g;
            foreach (var item in querry)
            {
                db.Guests.Remove(item);
            }
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
