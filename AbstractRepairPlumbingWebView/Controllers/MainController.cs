using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.Interfaces;
using AbstractRepairOrderServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstractRepairPlumbingWebView.Controllers
{
    public class MainController : Controller
    {
        private readonly IMainService _service;
        private readonly IRepairService _repairService;
        private readonly IClientService _clientService;

        public MainController(IMainService service, IRepairService repairService, IClientService clientService)
        {
            _service = service;
            _repairService = repairService;
            _clientService = clientService;
        }
        // GET: Main
        public ActionResult IndexOrder()
        {
            return View(_service.GetList());
        }
        public ActionResult CreateOrder()
        {
            var repair = new SelectList(_repairService.GetList(), "Id", "RepairName");
            var client = new SelectList(_clientService.GetList(), "Id", "ClientFIO");
            ViewBag.Repaires = repair;
            ViewBag.Clients = client;
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrderPost()
        {
            var clientId = int.Parse(Request["ClientFIO"]);
            var repairId = int.Parse(Request["RepairName"]);
            var count = int.Parse(Request["Count"]);
            var sum = CalcSum(repairId, count);

            _service.CreateOrder(new OrderBindingModel
            {
                ClientId = clientId,
                RepairId = repairId,
                Count = count,
                Sum = sum

            });
            return RedirectToAction("IndexOrder");
        }

        private Decimal CalcSum(int Id, int Count)
        {
            RepairViewModel repair = _repairService.GetElement(Id);
            return Count * repair.Price;
        }

        public ActionResult SetStatus(int id, string status)
        {
            try
            {
                switch (status)
                {
                    case "Processing":
                        _service.TakeOrderInWork(new OrderBindingModel { Id = id });
                        break;
                    case "Ready":
                        _service.FinishOrder(new OrderBindingModel { Id = id });
                        break;
                    case "Paid":
                        _service.PayOrder(new OrderBindingModel { Id = id });
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }


            return RedirectToAction("IndexOrder");
        }
    }
}