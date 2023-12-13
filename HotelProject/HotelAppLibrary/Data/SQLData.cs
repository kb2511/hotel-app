using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppLibrary.Data
{
    internal class SQLData : IDatabaseData
    {
        private readonly ISQLDataAccess _db;
        private const string connectionStringName = "SqlDb";
        public SQLData(ISQLDataAccess db)
        {
            _db = db;
        }

        public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
        {
            throw new NotImplementedException();
        }

        public void CheckInGuest(int id)
        {
            _db.SaveData("dbo.spBookings_CheckIn",
                         new { id },
                         connectionStringName,
                         true);

        }

        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            var listaSlobodnihSoba = _db.LoadData<RoomTypeModel, dynamic>("",
                                                                          new { startDate, endDate },
                                                                          connectionStringName,
                                                                          true);

            throw new NotImplementedException();
        }

        public List<BookingFullModel> SearchBookings(string lastName)
        {
            return _db.LoadData<BookingFullModel, dynamic>("dbo.spBookings_Search",
                                                    new { lastName, startDate = DateTime.Now.Date },
                                                    connectionStringName,
                                                    true);

        }
    }
}
