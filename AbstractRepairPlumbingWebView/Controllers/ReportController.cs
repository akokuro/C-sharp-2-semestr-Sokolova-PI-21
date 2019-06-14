using AbdtractRepairPlumbingServiceDAL.Interfaces;
using AbdtractRepairPlumbingServiceDAL.ViewModel;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairPlumbingServiceDAL.BindingModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AbstractRepairPlumbingWebView.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public FileResult RepairPrice()
        {
            ReportBindingModel model = new ReportBindingModel { FileName = @"C:\Users\Kurai\Documents\Dtest.docx" };
            _service.SaveRepairPrice(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.docx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public FileResult StoragesTableLoad()
        {
            ReportBindingModel model = new ReportBindingModel { FileName = @"C:\Users\Kurai\Documents\Xtest.xls" };
            _service.SaveStoragesLoad(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.xls";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public ActionResult ClientOrders()
        {
            //StorageName
            //TotalCount
            //Plumbings 
            var _storage = new SelectList(_service.GetStoragesLoad(), "Id", "StorageName");
            var _count = new SelectList(_service.GetStoragesLoad(), "Id", "TotalCount");
            var _plumbings = new SelectList(_service.GetStoragesLoad(), "Id", "Plumbings");
            ViewBag.StorageName = _storage;
            ViewBag.TotalCount = _count;
            ViewBag.Plumbings = _plumbings;
            return View();
        }

        [HttpGet]
        public ActionResult StoragesLoad()
        {
            return View();
        }

        [HttpPost]
        public FileResult ClientOrders(ReportBindingModel model)
        {
            model.FileName = @"C:\Users\Kurai\Documents\Ptest.pdf";
            _service.SaveClientOrders(model);
            byte[] fileBytes = System.IO.File.ReadAllBytes(model.FileName);
            string fileName = "test.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}