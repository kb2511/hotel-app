using System;
using System.Collections.Generic;

namespace HotelAppLibrary.DataModels
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CheckedIn { get; set; }
        public decimal TotalCost { get; set; }

        public virtual Guest Guest { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
    }
}
