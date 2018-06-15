﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer(){Id = 1, Name = "John Smith"},
                new Customer(){Id = 2, Name = "Sally Doe"}
            };
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer(){Id = 1, Name = "John Smith"},
                new Customer(){Id = 2, Name = "Sally Doe"}
            };

            foreach (Customer customer in customers)
            {
                if (customer.Id == id)
                    return (View(customer));
            }
            return HttpNotFound();
        }
    }
}