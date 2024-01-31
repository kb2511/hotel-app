using HotelAppLibrary.DtoModels;
using HotelAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HotelAppWeb.Controllers
{
    public class BookRoomController : Controller
    {
        private readonly IHotelService _service;
        private readonly ILogger<BookRoomController> _logger;

        public BookRoomController(IHotelService service, ILogger<BookRoomController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(int roomId, DateTime startDate, DateTime endDate)
        {
            try
            {
                RoomTypeDto roomType = _service.GetRoomTypeById(roomId);

                BookRoomModel model = new BookRoomModel()
                {
                    RoomTypeId = roomId,
                    RoomType = roomType,
                    StartDate = startDate,
                    EndDate = endDate
                };

                throw new ArgumentException();
                TempData["BookRoomModel"] = JsonConvert.SerializeObject(model);

                return View("~/Views/Hotel/BookRoom.cshtml", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            
        }

        [HttpPost]
        public IActionResult BookRoom(string firstName, string lastName)
        {
            BookRoomModel model = new BookRoomModel();

            try
            {
                if (TempData["BookRoomModel"] != null)
                {
                    model = JsonConvert.DeserializeObject<BookRoomModel>(TempData["BookRoomModel"].ToString());
                }
                _service.BookGuest(firstName, lastName, model.StartDate, model.EndDate, model.RoomTypeId);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            
        }
    }
}

