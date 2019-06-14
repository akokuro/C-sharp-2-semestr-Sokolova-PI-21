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
    public class StorageController : Controller
    {
        private readonly IStorageService _service;
        private readonly IPlumbingService _plumbService;
        private readonly IMainService _mainService;

        public StorageController(IStorageService service, IPlumbingService plumbService, IMainService mainService)
        {
            _service = service;
            _plumbService = plumbService;
            _mainService = mainService;
        }

        public ActionResult IndexStorage()
        {
            return View(_service.GetList());
        }

        public ActionResult Storages(int id)
        {
            return View(_service.GetElement(id));
        }

        public ActionResult Delete(int id)
        {
            _service.DelElement(id);
            return RedirectToAction("IndexStorage");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new StorageBindingModel
            {
                Id = id,
                StorageName = viewModel.StorageName
            };
            return View(bindingModel);
        }

        public ActionResult CreateStorage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStoragePost()
        {
            _service.AddElement(new StorageBindingModel
            {
                StorageName = Request["StorageName"]
            });
            return RedirectToAction("IndexStorage");
        }

        public ActionResult AddPlumbing()
        {
            var stores = new SelectList(_service.GetList(), "Id", "StorageName");
            ViewBag.Storages = stores;
            var materials = new SelectList(_plumbService.GetList(), "Id", "PlumbingName");
            ViewBag.Plumbings = materials;
            return View();
        }

        [HttpPost]
        public ActionResult AddPlumbingPost()
        {
            _mainService.PutComponentOnStorage(new StoragePlumbingBindingModel
            {
                PlumbingId = int.Parse(Request["PlumbingId"]),
                StorageId = int.Parse(Request["StorageId"]),
                Count = int.Parse(Request["Count"])
            });
            return RedirectToAction("IndexStorage");
        }
    }
}