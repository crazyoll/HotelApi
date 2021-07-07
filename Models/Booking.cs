using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArkadiuszGrygorukServer.Models
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string ReservationCode { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public string Currency { get; set; }


        public decimal Commission { get; set; }

        public string Source { get; set; }

        public virtual ICollection<GuestBooking> GuestBookings { get; set; }

    }
}