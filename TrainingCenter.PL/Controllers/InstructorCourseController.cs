using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingCenter.BLL.Interface;
using TrainingCenter.BLL.Models;
using TrainingCenter.DAL.Entities;

namespace TrainingCenter.PL.Controllers
{
    public class InstructorCourseController : Controller
    {
        private readonly IMapper _mapper;
            private readonly IInstructorRepository _instructorRepository;
            private readonly IInstructorCourseRepository _instructorCourseRepository;
            private readonly ICourseRepository _courseRepository;

            public InstructorCourseController(IMapper mapper, IInstructorRepository instructorRepository , IInstructorCourseRepository instructorCourseRepository , ICourseRepository courseRepository)
            {
                this._mapper = mapper;
                this._instructorRepository = instructorRepository;
                this._instructorCourseRepository = instructorCourseRepository;
                this._courseRepository = courseRepository;
            }
            public IActionResult Index()
            {
                var model = _instructorCourseRepository.Get();
                var data = _mapper.Map<IEnumerable<InstructorCourseVM>>(model);
                return View(data);
            }

            public IActionResult Create()
            {
            var CourseModel = _mapper.Map<IEnumerable<CourseVM>>(_courseRepository.Get());
            ViewBag.CourseList = new SelectList(CourseModel, "Id", "Title");

            var InstructorModel = _mapper.Map<IEnumerable<InstructorVM>>(_instructorRepository.Get());
            ViewBag.InstructorList = new SelectList(InstructorModel, "Id", "Name");

            return View();
            }
            [HttpPost]
            public IActionResult Create(InstructorCourseVM model)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var data = _mapper.Map<InstructorCourse>(model);
                        _instructorCourseRepository.Create(data);
                        return RedirectToAction("Index", "InstructorCourse");
                    }
                var CourseModel = _mapper.Map<IEnumerable<CourseVM>>(_courseRepository.Get());
                ViewBag.CourseList = new SelectList(CourseModel, "Id", "Title");

                var InstructorModel = _mapper.Map<IEnumerable<InstructorVM>>(_instructorRepository.Get());
                ViewBag.InstructorList = new SelectList(InstructorModel, "Id", "Name");
                return View();

                }
                catch (Exception ex)
                {

                var CourseModel = _mapper.Map<IEnumerable<CourseVM>>(_courseRepository.Get());
                ViewBag.CourseList = new SelectList(CourseModel, "Id", "Title");

                var InstructorModel = _mapper.Map<IEnumerable<InstructorVM>>(_instructorRepository.Get());
                ViewBag.InstructorList = new SelectList(InstructorModel, "Id", "Name");
                return View(ex.Message);
                }

            }



        public IActionResult AssignInstructor(int id)
        {
            var model = _courseRepository.GetById(id);
            var data = _mapper.Map<CourseVM>(model);
            var CourseModel = _mapper.Map<IEnumerable<CourseVM>>(_courseRepository.Get());
            ViewBag.CourseList = new SelectList(CourseModel, "Id", "Title", data.Id);

            var InstructorModel = _mapper.Map<IEnumerable<InstructorVM>>(_instructorRepository.Get());
            ViewBag.InstructorList = new SelectList(InstructorModel, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult AssignInstructor(InstructorCourseVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<InstructorCourse>(model);
                    _instructorCourseRepository.Create(data);
                    return RedirectToAction("Index", "InstructorCourse");
                }
                var CourseModel = _mapper.Map<IEnumerable<CourseVM>>(_courseRepository.Get());
                ViewBag.CourseList = new SelectList(CourseModel, "Id", "Title");

                var InstructorModel = _mapper.Map<IEnumerable<InstructorVM>>(_instructorRepository.Get());
                ViewBag.InstructorList = new SelectList(InstructorModel, "Id", "Name");
                return View();

            }
            catch (Exception ex)
            {

                var CourseModel = _mapper.Map<IEnumerable<CourseVM>>(_courseRepository.Get());
                ViewBag.CourseList = new SelectList(CourseModel, "Id", "Title");

                var InstructorModel = _mapper.Map<IEnumerable<InstructorVM>>(_instructorRepository.Get());
                ViewBag.InstructorList = new SelectList(InstructorModel, "Id", "Name");
                return View(ex.Message);
            }

        }
    }
    }
