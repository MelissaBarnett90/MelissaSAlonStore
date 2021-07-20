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
        public ActionResult Create(OrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var appservice = _mapper.Map<Order>(model);
                var issuccessful = _OrderRepo.Create(appservice);
                if (!issuccessful)
                {
                    ModelState.AddModelError("", "Something Went wrong......");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went wrong......");
                return View(model);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_OrderRepo.isExist(id))
            {
                return NotFound();
            }
            var appservice = _OrderRepo.FindById(id);
            var model = _mapper.Map<OrderViewModel>(appservice);
            return View(model);
        }

        // POST: ServiceAppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var appservice = _mapper.Map<Order>(model);
                var isSucess = _OrderRepo.Update(appservice);
                if (!isSucess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var appservice = _OrderRepo.FindById(id);
            var isSucess = _OrderRepo.Delete(appservice);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ServiceAppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrderViewModel model)
        {
            try
            {
                var appservice = _OrderRepo.FindById(id);
                var isSucess = _OrderRepo.Delete(appservice);
                if (!isSucess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
