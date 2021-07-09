using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonWebApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Controllers
{
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeRepository _paymentTypeRepo;
        private readonly IMapper _mapper;

        public PaymentTypeController(IPaymentTypeRepository paymentTyperepo, IMapper mapper)
        {
            _paymentTypeRepo = paymentTyperepo;
            _mapper = mapper;
        }



        // GET: PaymentTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
