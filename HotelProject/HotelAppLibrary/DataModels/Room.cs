using System;
using System.Collections.Generic;

namespace HotelAppLibrary.DataModels
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string RoomNumber { get; set; } = null!;
        public int RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
