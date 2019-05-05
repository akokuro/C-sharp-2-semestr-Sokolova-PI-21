﻿using AbdtractRepairOrderServiceDAL.Interfaces;
using AbstractRepairOrderServiceDAL.BindingModel;
using System;
using System.Web.Http;

namespace AbstractRepairPlumbingRestApi.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientService _service;
        public ClientController(IClientService service)
        {
            _service = service;
            Console.WriteLine("Сервер создался");
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
        public void AddElement(ClientBindingModel model)
        {
            Console.WriteLine("Попытался добавить");
            _service.AddElement(model);
            Console.WriteLine("Что-то пошло не так");
        }
        [HttpPost]
        public void UpdElement(ClientBindingModel model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(ClientBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
