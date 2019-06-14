using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbstractRepairOrderServiceDAL.BindingModel;
using AbstractRepairOrderServiceDAL.Interfaces;

namespace AbstractRepairPlumbingWebView.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        // GET: Client
        public ActionResult IndexClient()
        {
            return View(_service.GetList());
        }

        public ActionResult CreateClient()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateClientPost()
        {
            _service.AddElement(new ClientBindingModel
            {
                ClientFIO = Request["ClientFIO"]
            });
            return RedirectToAction("IndexClient");
        }

        public ActionResult EditClient(int id)
        {
            var viewModel = _service.GetElement(id);
            var bindingModel = new ClientBindingModel
            {
                Id = id,
                ClientFIO = viewModel.ClientFIO
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditClientPost()
        {
            _service.UpdElement(new ClientBindingModel
            {
                Id = int.Parse(Request["Id"]),
                ClientFIO = Request["ClientFIO"]
            });
            return RedirectToAction("IndexClient");
        }

        public ActionResult DeleteClient(int id)
        {
            _service.DelElement(id);
            return RedirectToAction("IndexClient");
        }
    }
}