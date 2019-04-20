using AbdtractRepairOrderServiceDAL.BindingModel;
using AbdtractRepairOrderServiceDAL.Interfaces;
using System;
using System.Web.Http;

namespace AbstractRepairPlumbingRestApi.Controllers
{
    public class RepairController : ApiController
    {
        private readonly IRepairService _service;
        public RepairController(IRepairService service)
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
        public void AddElement(RepairBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(RepairBindingModel model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(RepairBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
