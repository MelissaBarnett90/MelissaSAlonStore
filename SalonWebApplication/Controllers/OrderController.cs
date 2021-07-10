using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using SalonWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _OrderRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IPaymentTypeRepository _paymentRepo;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderrepo,ICustomerRepository customerRepo,IPaymentTypeRepository paymentRepo, IMapper mapper)
        {
            _OrderRepo = orderrepo;
            _customerRepo = customerRepo;
            _paymentRepo = paymentRepo;
            _mapper = mapper;

        }




        // GET: OrderController
        public ActionResult Index()
        {
            var typesoforder = _OrderRepo.FindAll().ToList();

            var maptoOrder = _mapper.Map<List<Order>, List<OrderViewModel>>(typesoforder);

            return View(maptoOrder);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {

            if (!_OrderRepo.isExist(id))
            {
                return NotFound();
            }
            var typesoforder = _OrderRepo.FindById(id);
            var maptoOrder = _mapper.Map<OrderViewModel>(typesoforder);
            return View(maptoOrder);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
