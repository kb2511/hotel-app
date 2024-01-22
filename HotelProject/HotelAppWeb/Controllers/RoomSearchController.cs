using HotelAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelAppWeb.Controllers
{
    public class RoomSearchController : Controller
    {
        private readonly IHotelService _service;

        public RoomSearchController(IHotelService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult RoomSearch()
        {
            RoomSearchModel model = new RoomSearchModel();

            if (TempData["RoomSearchModel"] != null)
            {
                // Deserialize the model from TempData
                model = JsonConvert.DeserializeObject<RoomSearchModel>(TempData["RoomSearchModel"].ToString());
            }

            return View("RoomSearch", model);
        }

        [HttpPost]
        public IActionResult OnPost(RoomSearchModel model)
        {
            model.AvailableRoomTypes = _service.GetAvailableRoomTypes(model.StartDate, model.EndDate);

            // Serialize the model to a string and store in TempData
            TempData["RoomSearchModel"] = JsonConvert.SerializeObject(model);

            // Redirect to the RoomSearch GET method
            return RedirectToAction("RoomSearch");
        }
    }
}

