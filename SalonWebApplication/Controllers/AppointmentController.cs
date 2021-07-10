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
    public class AppointmentController : Controller
    {
        private readonly  IAppointmentRepository _AppointmentRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepository AppointmentRepo, IEmployeeRepository employeeRepo, ICustomerRepository customerRepo, Mapper mapper)
        {
            _AppointmentRepo = AppointmentRepo;
            _customerRepo = customerRepo;
            _employeeRepo = employeeRepo;

            _mapper = mapper;
        }                                     


        // GET: AppointmentController
        public ActionResult Index()
        {
            var typesofappointment = _AppointmentRepo.FindAll().ToList();

            var maptoAppointment = _mapper.Map<List<Appointment>, List<AppointmentViewModel>>(typesofappointment);

            return View(maptoAppointment);
        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
            if (!_AppointmentRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofappointment = _AppointmentRepo.FindById(id);
            var maptoAppointment = _mapper.Map<AppointmentViewModel>(typesofappointment);
            return View(maptoAppointment);
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            var employee = _employeeRepo.FindAll();
            var supplierItems = employee.Select(q => new SelectListItem
            {
                Text = q.FirstName,

                Value = q.Id.ToString()


            });

            var model = new AppointmentViewModel
            {
                Employee = supplierItems

            };

            return View(model);
        }

        // POST: AppointmentController/Create
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

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppointmentController/Edit/5
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

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppointmentController/Delete/5
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
