using HotelAppLibrary.HotelContext;
using HotelAppLibrary.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelAppLibrary.DtoModels;

namespace HotelAppLibrary.Service
{
    public class SqlService : IHotelService
    {
        private readonly HotelAppDBContext _context;

        public SqlService(HotelAppDBContext context)
        {
            _context = context;           
        }
        public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
        {
            Guest guest = new Guest()
            {
                FirstName = firstName,
                LastName = lastName,
            };

            _context.Guests.Add(guest);

            RoomTypeDto roomType = GetRoomTypeById(roomTypeId);

            TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

            var bookedRoomsId = _context.Bookings.Where(b => (startDate < b.StartDate && endDate > b.EndDate) ||
                                                            (startDate >= b.StartDate && startDate < b.EndDate) ||
                                                            (endDate >= b.StartDate && endDate < b.EndDate))
                                                    .Select(b => b.RoomId).ToList();

            Room availableRoom = _context.Rooms.Where(r =>
                                                            r.Id == roomTypeId &&
                                                            !bookedRoomsId.Contains(r.Id)
                                                        ).First();

            Booking booking = new Booking()
            {
                RoomId = availableRoom.Id,
                Room = availableRoom,
                Guest = guest,
                GuestId = guest.Id,
                StartDate = startDate,
                EndDate = endDate,
                CheckedIn = false,
                TotalCost = timeStaying.Days * roomType.Price
            };

            _context.Bookings.Add(booking);

            _context.SaveChanges();

                

        }
 

        public List<RoomTypeDto> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            var bookedRoomsId = _context.Bookings.Where(b => (startDate < b.StartDate && endDate > b.EndDate) ||
                                                        (startDate >= b.StartDate && startDate < b.EndDate) ||
                                                        (endDate >= b.StartDate && endDate < b.EndDate))
                                                .Select(b => b.RoomId).ToList();

            return _context.Rooms.Where(r => !bookedRoomsId.Contains(r.Id))
                                                            .GroupBy(r => r.RoomTypeId,
                                                            (rId, rooms) => new RoomTypeDto()
                                                            {
                                                                Id = rId,
                                                                Title = _context.RoomTypes.FirstOrDefault(t => t.Id == rId).Title,
                                                                Description = _context.RoomTypes.FirstOrDefault(t => t.Id == rId).Description,
                                                                Price = _context.RoomTypes.FirstOrDefault(t => t.Id == rId).Price
                                                            }
                                                            ).ToList();

        }

        public RoomTypeDto GetRoomTypeById(int id)
        {
            var roomType = _context.RoomTypes.FirstOrDefault(t => t.Id == id);
            return new RoomTypeDto()
            {
                Id = roomType.Id,
                Title = roomType.Title,
                Description = roomType.Description,
                Price = roomType.Price
            };
        }

        public List<BookingDto> SearchBookings(string lastName)
        {
            return _context.Bookings.Where(b => b.StartDate == DateTime.Now && b.Guest.LastName == lastName)
                                            .Select(b => new BookingDto()
                                            {
                                                Id = b.Id,
                                                RoomId = b.RoomId,
                                                GuestId = b.GuestId,
                                                StartDate = b.StartDate,
                                                EndDate = b.EndDate,
                                                CheckedIn = b.CheckedIn,
                                                TotalCost = b.TotalCost,
                                                FirstName = b.Guest.FirstName,
                                                LastName = b.Guest.LastName,
                                                RoomNumber = b.Room.RoomNumber,
                                                RoomTypeId = b.Room.RoomTypeId,
                                                Title = b.Room.RoomType.Title,
                                                Description = b.Room.RoomType.Description,
                                                Price = b.Room.RoomType.Price
                                            }
                                            ).ToList();
        }

        public void CheckInGuest(int bookingId)
        {
            _context.Bookings.Where(b => b.Id == bookingId).FirstOrDefault().CheckedIn = true;
        }
    }
}
