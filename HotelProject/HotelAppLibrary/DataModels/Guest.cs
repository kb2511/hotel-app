using System;
using System.Collections.Generic;

namespace HotelAppLibrary.DataModels
{
    public partial class Guest
    {
        public Guest()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
