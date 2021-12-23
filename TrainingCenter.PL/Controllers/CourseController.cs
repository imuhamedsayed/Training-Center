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
    public class CourseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public CourseController(IMapper mapper, ICourseRepository courseRepository)
        {
            this._mapper = mapper;
            this._courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            var model = _courseRepository.Get();
            var data = _mapper.Map<IEnumerable<CourseVM>>(model);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Course>(model);
                    _courseRepository.Create(data);
                    return RedirectToAction("Index", "Course");
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
            var model = _courseRepository.GetById(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Student");
            }
            var data = _mapper.Map<CourseVM>(model);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(CourseVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Course>(model);
                    _courseRepository.Update(data);
                    return RedirectToAction("Index", "Course");
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
            var model = _courseRepository.GetById(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Student");
            }
            var data = _mapper.Map<CourseVM>(model);
            return View(data);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                var model = _courseRepository.GetById(id);


                _courseRepository.Delete(model);
                return RedirectToAction("Index", "Course");
            }
            catch (Exception ex)
            {
               
                return View();
            }
        }
    }
}
