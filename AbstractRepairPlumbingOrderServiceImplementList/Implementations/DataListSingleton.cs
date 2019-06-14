﻿using System;
using AbstractRepairOrderModel;
using AbstractRepairOrderServiceDAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRepairOrderServiceImplementList.Implementations
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Client> Clients { get; set; }
        public List<Plumbing> Plumbings { get; set; }
        public List<Order> Orders { get; set; }
        public List<Repair> Repairs { get; set; }
        public List<RepairPlumbing> RepairPlumbings { get; set; }
        public List<Storage> Storages { get; set; }
        public List<StorageComponent> StorageComponents { get; set; }
        private DataListSingleton()
        {
            Clients = new List<Client>();
            Plumbings = new List<Plumbing>();
            Orders = new List<Order>();
            Repairs = new List<Repair>();
            RepairPlumbings = new List<RepairPlumbing>();
            Storages = new List<Storage>();
            StorageComponents = new List<StorageComponent>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
