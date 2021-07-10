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
    public class ServiceAppointmentController : Controller
    {
        private readonly IServiceAppointmentRepository _serviceAppointmentRepo;
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public ServiceAppointmentController(IServiceAppointmentRepository serviceAppointmentrepo, IServiceRepository serviceRepo, IAppointmentRepository appointmentRepo, IMapper mapper)
        {
            _serviceAppointmentRepo = serviceAppointmentrepo;
            _serviceRepo = serviceRepo;
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;

        }

        // GET: ServiceAppointmentController
        public ActionResult Index()
        {
            var typesofserviceappointment = _serviceAppointmentRepo.FindAll().ToList();

            var maptoserviceAppointment = _mapper.Map<List<ServiceAppointment>, List<ServiceAppointmentViewModel>>(typesofserviceappointment);

            return View(maptoserviceAppointment);
        }

        // GET: ServiceAppointmentController/Details/5
        public ActionResult Details(int id)
        {

            if (!_serviceAppointmentRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofserviceappointment = _serviceAppointmentRepo.FindById(id);
            var maptoserviceAppointment = _mapper.Map<ServiceAppointmentViewModel>(typesofserviceappointment);
            return View(maptoserviceAppointment);
        }

        // GET: ServiceAppointmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceAppointmentController/Create
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

        // GET: ServiceAppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceAppointmentController/Edit/5
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

        // GET: ServiceAppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceAppointmentController/Delete/5
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
