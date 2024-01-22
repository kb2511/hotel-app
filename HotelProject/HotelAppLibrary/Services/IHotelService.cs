using HotelAppLibrary.DataModels;
using HotelAppLibrary.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppLibrary.Services
{
    public interface IHotelService
    {
        void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
        void CheckInGuest(int bookingId);
        List<RoomTypeDto> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);
        RoomTypeDto GetRoomTypeById(int id);
        List<BookingDto> SearchBookings(string lastName);       
    }
}
