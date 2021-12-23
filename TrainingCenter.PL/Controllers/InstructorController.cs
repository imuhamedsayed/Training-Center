using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingCenter.BLL.Interface;
using TrainingCenter.BLL.Models;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.PL.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;

        public InstructorController(IMapper mapper, IInstructorRepository instructorRepository)
        {
            this._mapper = mapper;
            this._instructorRepository = instructorRepository;
        }
        public IActionResult Index()
        {
            var model = _instructorRepository.Get();
            var data = _mapper.Map<IEnumerable<InstructorVM>>(model);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(InstructorVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Instructor>(model);
                    _instructorRepository.Create(data);
                    return RedirectToAction("Index", "Instructor");
                }
                return View();

            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }

        }

        public IActionResult Edit(int id)
        {
            var model = _instructorRepository.GetById(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Student");
            }
            var data = _mapper.Map<InstructorVM>(model);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(InstructorVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Instructor>(model);
                    _instructorRepository.Update(data);
                    return RedirectToAction("Index", "Instructor");
                }
                return View();

            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }

        }

        public IActionResult Delete(int id)
        {
            var model = _instructorRepository.GetById(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Student");
            }
            var data = _mapper.Map<InstructorVM>(model);
            return View(data);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                var model = _instructorRepository.GetById(id);


                _instructorRepository.Delete(model);
                return RedirectToAction("Index", "Instructor");
            }
            catch(Exception ex)
            {
              
                return View();
            }
        }

    }
}
