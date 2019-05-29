using AbstractRepairPlumbingServiceDAL.Interfaces;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using System;
using System.Web.Http;

namespace AbstractPlumbingPlumbingRestApi.Controllers
{
    public class PlumbingController : ApiController
    {
          private readonly IPlumbingService _service;
        public PlumbingController(IPlumbingService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }
        [HttpPost]
        public void AddElement(PlumbingBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(PlumbingBindingModel model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(PlumbingBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
