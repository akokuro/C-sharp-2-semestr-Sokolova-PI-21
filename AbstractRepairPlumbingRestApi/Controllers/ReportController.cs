using AbstractRepairPlumbingServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.Interfaces;
using System;
using System.Web.Http;

namespace AbstractRepairPlumbingRestApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _service;
        public ReportController(IReportService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetStoragesLoad()
        {
            var list = _service.GetStoragesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetClientOrders(ReportBindingModel model)
        {
            var list = _service.GetClientOrders(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveProductPrice(ReportBindingModel model)
        {
            _service.SaveRepairPrice(model);
        }
        [HttpPost]
        public void SaveStoragesLoad(ReportBindingModel model)
        {
            _service.SaveStoragesLoad(model);
        }
        [HttpPost]
        public void SaveClientOrders(ReportBindingModel model)
        {
            _service.SaveClientOrders(model);
        }
    }
}
