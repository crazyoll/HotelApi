using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArkadiuszGrygorukServer.Models
{
    public class GuestBooking
    {
        [Key]
        public int ID { get; set; }

        public int BookingID { get; set; }
        public virtual Booking Booking { get; set; }

        public int GuestID { get; set; }
        public virtual Guest Guest { get; set; }
    }
}