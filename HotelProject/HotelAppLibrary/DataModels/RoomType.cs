using System;
using System.Collections.Generic;

namespace HotelAppLibrary.DataModels
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
