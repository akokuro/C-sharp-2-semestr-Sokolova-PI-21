using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstractRepairPlumbingWebView.Controllers
{
    public class RepairController : Controller
    {
        private readonly IRepairService _service;
        private readonly IPlumbingService _plumService;

        public RepairController(IRepairService service, IPlumbingService matService)
        {
            _service = service;
            _plumService = matService;
        }
        // GET: Repair
        public ActionResult IndexRepair()
        {
            return View(_service.GetList());
        }
        public ActionResult CreateRepair()
        {
            if (Session["Repair"] == null)
            {
                var repair = new RepairBindingModel();
                repair.RepairPlumbings = new List<RepairPlumbingBindingModel>();
                Session["Repair"] = repair;
            }
            return View((RepairBindingModel)Session["Repair"]);
        }

        [HttpPost]
        public ActionResult CreateRepairPost()
        {
            var repair = (RepairBindingModel)Session["Repair"];

            repair.RepairName = Request["RepairName"];
            repair.Price = Convert.ToDecimal(Request["Price"]);

            _service.AddElement(repair);

            Session.Remove("Repair");

            return RedirectToAction("IndexRepair");
        }

        public ActionResult AddPlumbing()
        {
            var materials = new SelectList(_plumService.GetList(), "Id", "PlumbingName");
            ViewBag.Plumbings = materials;
            return View();
        }

        [HttpPost]
        public ActionResult AddPlumbingPost()
        {
            var repair = (RepairBindingModel)Session["Repair"];
            var plumbing = new RepairPlumbingBindingModel
            {
                RepairId = repair.Id,
                PlumbingId = int.Parse(Request["PlumbingId"]),
                PlumbingName = _plumService.GetElement(int.Parse(Request["PlumbingId"])).PlumbingName,
                Count = int.Parse(Request["Count"])
            };
            repair.RepairPlumbings.Add(plumbing);
            Session["Repair"] = repair;
            return RedirectToAction("CreateRepair");
        }

        public ActionResult EditRepair(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new RepairBindingModel
            {
                Id = id,
                RepairName = viewModel.RepairName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditRepairPost()
        {
            _service.UpdElement(new RepairBindingModel
            {
                Id = int.Parse(Request["Id"]),
                RepairName = Request["RepairName"]
            });
            return RedirectToAction("IndexRepair");
        }

        public ActionResult DeleteRepair(int id)
        {
            _service.DelElement(id);
            return RedirectToAction("IndexRepair");
        }
    }
}