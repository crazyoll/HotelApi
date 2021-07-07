using ArkadiuszGrygorukServer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ArkadiuszGrygorukServer.DAL
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("HotelContext")
        {
            Database.SetInitializer(new HotelInitializer());
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestBooking> GuestBookings { get; set; }
    }
}