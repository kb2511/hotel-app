using HotelAppLibrary.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace HotelAppWeb.Models
{
    public class RoomSearchModel
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        public List<RoomTypeDto> AvailableRoomTypes { get; set; }
    }
}
