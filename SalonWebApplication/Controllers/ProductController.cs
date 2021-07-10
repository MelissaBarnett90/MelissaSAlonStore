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
    public class ProductController : Controller
    {

        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productrepo, IMapper mapper)
        {
            _productRepo = productrepo;
            _mapper = mapper;
        }


        // GET: ProductController
        public ActionResult Index()
        {
            var typesofProduct = _productRepo.FindAll().ToList();

            var maptoProduct = _mapper.Map<List<Product>, List<ProductViewModel>>(typesofProduct);

            return View(maptoProduct);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (!_productRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofProduct = _productRepo.FindById(id);
            var maptoProduct = _mapper.Map<ProductViewModel>(typesofProduct);
            return View(maptoProduct);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel  model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var product = _mapper.Map<Product>(model);
                var issuccessful = _productRepo.Create(product);
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_productRepo.isExist(id))
            {
                return NotFound();
            }
            var product = _productRepo.FindById(id);
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var product = _mapper.Map<Product>(model);
                var isSucess = _productRepo.Update(product);
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productRepo.FindById(id);
            var isSucess = _productRepo.Delete(product);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductViewModel model)
        {
            try
            {
                var product = _productRepo.FindById(id);
                var isSucess = _productRepo.Delete(product);
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
