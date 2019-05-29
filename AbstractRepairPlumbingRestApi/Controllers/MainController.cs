using AbdtractFoodOrderServiceDAL.ViewModel;
using AbdtractRepairOrderServiceDAL.BindingModel;
using AbdtractRepairOrderServiceDAL.Interfaces;
using AbdtractRepairOrderServiceDAL.ViewModel;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairPlumbingRestApi.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace AbstractRepairPlumbingRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;
        private readonly IImplementerService _serviceImplementer;
        public MainController(IMainService service, IImplementerService
       serviceImplementer)
        {
            _service = service;
            _serviceImplementer = serviceImplementer;
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
        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            _service.CreateOrder(model);
        }
        [HttpPost]
        public void PayOrder(OrderBindingModel model)
        {
            _service.PayOrder(model);
        }
        [HttpPost]
        public void PutComponentOnStorage(StoragePlumbingBindingModel model)
        {
            _service.PutComponentOnStorage(model);
        }
        [HttpPost]
        public void StartWork()
        {
            List<OrderViewModel> orders = _service.GetFreeOrders();
            foreach (var order in orders)
            {
                ImplementerViewModel impl = _serviceImplementer.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет сотрудников");
                }
                new WorkImplementer(_service, _serviceImplementer, impl.Id, order.Id);
            }
        }
    }
}
