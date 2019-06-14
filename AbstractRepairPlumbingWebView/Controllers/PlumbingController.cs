using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstractRepairPlumbingWebView.Controllers
{
    public class PlumbingController : Controller
    {
        private readonly IPlumbingService _service;

        public PlumbingController(IPlumbingService service)
        {
            _service = service;
        }
        // GET: Plumbing
        public ActionResult IndexPlumbing()
        {
            return View(_service.GetList());
        }
        public ActionResult CreatePlumbing()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePlumbingPost()
        {
            _service.AddElement(new PlumbingBindingModel
            {
                PlumbingName = Request["PlumbingName"]
            });
            return RedirectToAction("IndexPlumbing");
        }

        public ActionResult EditPlumbing(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new PlumbingBindingModel
            {
                Id = id,
                PlumbingName = viewModel.PlumbingName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPlumbingPost()
        {
            _service.UpdElement(new PlumbingBindingModel
            {
                Id = int.Parse(Request["Id"]),
                PlumbingName = Request["PlumbingName"]
            });
            return RedirectToAction("IndexPlumbing");
        }

        public ActionResult DeletePlumbing(int id)
        {
            _service.DelElement(id);
            return RedirectToAction("IndexPlumbing");
        }
    }
}