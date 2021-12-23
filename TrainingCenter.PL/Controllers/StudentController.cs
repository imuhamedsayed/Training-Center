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
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentController(IMapper mapper,IStudentRepository studentRepository)
        {
            this._mapper = mapper;
            this._studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            var model = _studentRepository.Get();
            var data = _mapper.Map<IEnumerable<StudentVM>>(model);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Student>(model);
                    _studentRepository.Create(data);
                    return RedirectToAction("Index", "Student");
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
            var model = _studentRepository.GetById(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Student");
            }
            var data = _mapper.Map<StudentVM>(model);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(StudentVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Student>(model);
                    _studentRepository.Update(data);
                    return RedirectToAction("Index", "Student");
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
            var model = _studentRepository.GetById(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Student");
            }
            var data = _mapper.Map<StudentVM>(model);
            return View(data);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                var model = _studentRepository.GetById(id);


                _studentRepository.Delete(model);
                return RedirectToAction("Index", "Student");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult NotFound()
        {
            TempData["notfound"] = "Resource Not Found";
            return View();
        }
    }
}
