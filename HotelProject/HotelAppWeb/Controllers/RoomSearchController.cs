using HotelAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HotelAppWeb.Controllers
{
    public class RoomSearchController : Controller
    {
        private readonly IHotelService _service;
        private readonly ILogger<RoomSearchController> _logger;


        public RoomSearchController(IHotelService service, ILogger<RoomSearchController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                RoomSearchModel model = new RoomSearchModel();

                if (TempData["RoomSearchModel"] != null)
                {
                    // Deserialize the model from TempData
                    model = JsonConvert.DeserializeObject<RoomSearchModel>(TempData["RoomSearchModel"].ToString());
                }

                return View("~/Views/Hotel/RoomSearch.cshtml", model);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            
        }

        [HttpPost]
        public IActionResult SearchRoom(RoomSearchModel model)
        {
            try
            {
                model.AvailableRoomTypes = _service.GetAvailableRoomTypes(model.StartDate, model.EndDate);

                // Serialize the model to a string and store in TempData
                TempData["RoomSearchModel"] = JsonConvert.SerializeObject(model);

                // Redirect to the RoomSearch GET method
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}

