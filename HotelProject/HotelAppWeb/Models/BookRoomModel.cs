using HotelAppLibrary.DtoModels;

namespace HotelAppWeb.Models
{
    public class BookRoomModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomTypeId { get; set; }
        public RoomTypeDto RoomType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
