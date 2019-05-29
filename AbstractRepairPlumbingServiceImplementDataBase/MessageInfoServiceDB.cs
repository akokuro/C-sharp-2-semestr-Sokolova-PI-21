﻿using AbdtractFoodOrderServiceDAL.BindingModel;
using AbdtractFoodOrderServiceDAL.Interfaces;
using AbdtractFoodOrderServiceDAL.ViewModel;
using AbstractRepairOrderModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace AbstractRepairPlumbingServiceImplementDataBase
{
    public class MessageInfoServiceDB : IMessageInfoService
    {
        private AbstractRepairPlumbingDbContext context;
        public MessageInfoServiceDB(AbstractRepairPlumbingDbContext context)
        {
            this.context = context;
        }
        public List<MessageInfoViewModel> GetList()
        {
            List<MessageInfoViewModel> result = context.MessageInfos
            .Where(rec => !rec.ClientId.HasValue)
            .Select(rec => new MessageInfoViewModel
            {
                MessageId = rec.MessageId,
                ClientName = rec.FromMailAddress,
                DateDelivery = rec.DateDelivery,
                Subject = rec.Subject,
                Body = rec.Body
            })

        .ToList();
            return result;
        }
        public MessageInfoViewModel GetElement(int id)
        {
            MessageInfo element = context.MessageInfos.Include(rec => rec.Client)
            .FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new MessageInfoViewModel
                {
                    MessageId = element.MessageId,
                    ClientName = element.Client.ClientFIO,
                    DateDelivery = element.DateDelivery,
                    Subject = element.Subject,
                    Body = element.Body
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(MessageInfoBindingModel model)
        {
            MessageInfo element = context.MessageInfos.FirstOrDefault(rec =>
           rec.MessageId == model.MessageId);
            if (element != null)
            {
                return;
            }
            var message = new MessageInfo
            {
                MessageId = model.MessageId,
                FromMailAddress = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body
            };
            var mailAddress = Regex.Match(model.FromMailAddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (mailAddress.Success)
            {
                var client = context.Clients.FirstOrDefault(rec => rec.Mail ==
               mailAddress.Value);
                if (client != null)
                {
                    message.ClientId = client.Id;
                }
            }
            context.MessageInfos.Add(message);
            context.SaveChanges();
        }
    }
}
