using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ArkadiuszGrygorukServer.Models;

namespace ArkadiuszGrygorukServer.DAL
{
    public class HotelInitializer : DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            List<Guest> guests = new List<Guest>
            {
                new Guest { Name = "Piotr", Surname = "Pawlik", Email = "NicolaPawlik@gmail.com" },
                new Guest { Name = "Wincenty", Surname = "Kozłowski", Email = "wicek1337@o2.pl", ZipCode = "79-929"},
                new Guest { Name = "Stanisław", Surname = "Zieliński", Email = "StanislawZielinski@wp.pl", BirthDate = DateTime.Parse("21-08-1939"), ZipCode = "49-634"},
                new Guest { Name = "Jagoda", Surname = "Czajkowska", Email = "JagodaCzajkowska@gmail.com" },
                new Guest { Name = "Piotr", Surname = "Sawicki", Email = "AlanS@o2.pl", BirthDate = DateTime.Parse("11-09-1970"), City = "Wrocław" },
                new Guest { Name = "Lucjan", Surname = "Maciejewski", Email = "Lucek13@gmail.com" },
                new Guest { Name = "Agnieszka", Surname = "Jasińska", Email = "Jasinska@wp.pl", ZipCode = "81-757"},
                new Guest { Name = "Adrianna", Surname = "Wróbel", Email = "AdriannaWrobel@o2.pl" },
                new Guest { Name = "Zdzisława", Surname = "Urbaniak", Email = "ZdzislawaUrbaniak@o2.pl" },
                new Guest { Name = "Bohdan", Surname = "Wierzbicki", Email = "BohdanWierzbicki@gmail.com", BirthDate = DateTime.Parse("30-07-1954")}
            };
            guests.ForEach(r => context.Guests.Add(r));
            context.SaveChanges();
            List<Booking> bookings = new List<Booking>
            {
                new Booking { ReservationCode = "vrncgxqe2v", CreationDate = DateTime.Parse("21-03-2021"), Price = 600, 
                    CheckInDate = DateTime.Parse("25-03-2021"), CheckOutDate = DateTime.Parse("27-03-2021"), Currency = "PLN" },
                new Booking { ReservationCode = "s876qeeq7y", CreationDate = DateTime.Parse("21-06-2021"), Price = 250, 
                    CheckInDate = DateTime.Parse("22-06-2021"), CheckOutDate = DateTime.Parse("23-06-2021"), Currency = "USD" },
                new Booking { ReservationCode = "949rksugpx", CreationDate = DateTime.Parse("02-12-2020"), Price = 800, 
                    CheckInDate = DateTime.Parse("29-12-2020"), CheckOutDate = DateTime.Parse("02-01-2021"), Currency = "EUR" },
                new Booking { ReservationCode = "bag57mpzmr", CreationDate = DateTime.Parse("21-02-2021"), Price = 2500, 
                    CheckInDate = DateTime.Parse("01-04-2021"), CheckOutDate = DateTime.Parse("01-05-2021"), Currency = "PLN" },
            };
            bookings.ForEach(r => context.Bookings.Add(r));
            context.SaveChanges();
            List<GuestBooking> guestBookings = new List<GuestBooking>
            {
                new GuestBooking{ BookingID = 1, GuestID = 1 },
                new GuestBooking{ BookingID = 1, GuestID = 2 },
                new GuestBooking{ BookingID = 1, GuestID = 3 },
                new GuestBooking{ BookingID = 1, GuestID = 4 },

                new GuestBooking{ BookingID = 2, GuestID = 1 },
                new GuestBooking{ BookingID = 2, GuestID = 5 },

                new GuestBooking{ BookingID = 3, GuestID = 3 },
                new GuestBooking{ BookingID = 3, GuestID = 4 },
                new GuestBooking{ BookingID = 3, GuestID = 5 },
                new GuestBooking{ BookingID = 3, GuestID = 6 },

                new GuestBooking{ BookingID = 4, GuestID = 5 },
                new GuestBooking{ BookingID = 4, GuestID = 6 },
                new GuestBooking{ BookingID = 4, GuestID = 7 },
                new GuestBooking{ BookingID = 4, GuestID = 8 },
                new GuestBooking{ BookingID = 4, GuestID = 9 },
                new GuestBooking{ BookingID = 4, GuestID = 10 },
            };
            guestBookings.ForEach(r => context.GuestBookings.Add(r));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}