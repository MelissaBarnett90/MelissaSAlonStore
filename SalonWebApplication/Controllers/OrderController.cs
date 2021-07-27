using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IProductRepository _prodRepo;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderrepo,IProductRepository prodRepo, ICustomerRepository customerRepo,IPaymentTypeRepository paymentRepo, IMapper mapper)
        {
            _OrderRepo = orderrepo;
            _customerRepo = customerRepo;
            _paymentRepo = paymentRepo;
            _prodRepo = prodRepo;
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
        public ActionResult Create(OrdersDetails model)
        {
            var customer = _customerRepo.FindAll();
            var customername = customer.Select(q => new SelectListItem
            {
                Text = q.CustomerFirstName + q.CustomerLastName,
                Value = q.CustomerId.ToString()
            }
            ) ;

            var Products =_prodRepo.FindAll();
            var Productsname = Products.Select(q => new SelectListItem
            {
                Text = $"{ q.ProductName } - ${ q.ProductCost}",
                Value = q.ProductId.ToString()
            }
            );

            var Payment = _paymentRepo.FindAll();
            var Paymentname = Payment.Select(q => new SelectListItem
            {
                Text = q.PaymentName,
                Value = q.PaymentTypeId.ToString()
            }
            );


            return View();
        }
        
        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel model)
        {
            /* try
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
             };*/


            /* catch
            {
                ModelState.AddModelError("", "Something Went wrong......");*/
            var customer = _customerRepo.FindAll();
            var customername = customer.Select(q => new SelectListItem
            {
                Text = q.CustomerFirstName + q.CustomerLastName,
                Value = q.CustomerId.ToString()
            }
            );

            var Products = _prodRepo.FindAll();
            var Productsname = Products.Select(q => new SelectListItem
            {
                Text = $"{ q.ProductName } - ${ q.ProductCost}",
                Value = q.ProductId.ToString()
            }
            );

            var Payment = _paymentRepo.FindAll();
            var Paymentname = Payment.Select(q => new SelectListItem
            {
                Text = q.PaymentName,
                Value = q.PaymentTypeId.ToString()
            }
            );

            model.Customers = customername;
            model.Products = Productsname;
            model.PaymentTypes = Paymentname;

            var product = _prodRepo.FindById(model.ProductId);
            var totalcost = model.Total;
            if (product.ProductQty>model.ProductQuantity)
            {
                totalcost = product.ProductCost * model.ProductQuantity;
            }
            else if (model.ProductQuantity<=0)
            {
                ModelState.AddModelError("", "please enter a value for the quantity");
              return View(model);
                    }

            model.Total = totalcost;
            var salevalue = new OrderViewModel
            {
               // objects to pass into the model
               CustomerId=model.CustomerId,
               CustomerName=model.CustomerName,
               Customers=model.Customers,

            };
         
            
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
