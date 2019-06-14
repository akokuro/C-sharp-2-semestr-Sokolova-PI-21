using AbdtractRepairOrderServiceDAL.Interfaces;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbstractRepairPlumbingWebView.Controllers
{
    public class AddPlumbingInStorageController : Controller
    {
        private readonly IMainService _service;
        private readonly IPlumbingService _plumbService;
        private readonly IStorageService _storageService;

        public AddPlumbingInStorageController(IMainService service, IPlumbingService plumbService, IStorageService storageService)
        {
            _service = service;
            _plumbService = plumbService;
            _storageService = storageService;
        }

        public ActionResult Index()
        {
            var components = new SelectList(_plumbService.GetList(), "Id", "PlumbingName");
            ViewBag.Components = components;

            var storages = new SelectList(_storageService.GetList(), "Id", "StorageName");
            ViewBag.Storages = storages;
            return View();
        }

        [HttpPost]
        public ActionResult AddPlumbingPost()
        {
            _service.PutComponentOnStorage(new StoragePlumbingBindingModel
            {
                PlumbingId = int.Parse(Request["PlumbingId"]),
                StorageId = int.Parse(Request["StorageId"]),
                Count = int.Parse(Request["Count"])
            });
            return RedirectToAction("IndexOrder", "Main");
        }
    }
}
