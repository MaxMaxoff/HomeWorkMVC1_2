using HomeWorkMVC1.Domain.Model;
using HomeWorkMVC1.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HomeWorkMVC1.Models;
using Microsoft.AspNetCore.Authorization;


namespace HomeWorkMVC1.Controllers
{
    [Route("users")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesData _employeesData;

        public EmployeeController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;

        }

        /// <summary>
        /// Return employee list
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_employeesData.GetAll());
        }

        /// <summary>
        /// Details
        /// </summary>
        /// <param name="id">employee Id</param>
        /// <returns></returns>
        [Route("details/{id}")]
        public IActionResult Details(int id)
        {
            //Получаем сотрудника по Id
            var employee = _employeesData.GetById(id);

            //Если такого не существует
            if (ReferenceEquals(employee, null))
                return NotFound();//возвращаем результат 404 Not Found

            //Иначе возвращаем сотрудника
            return View(employee);
        }

        /// <summary>
        /// Add & edit employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("edit/{id?}")]
        [Authorize(Roles = Constants.Roles.Administrator)]
        public IActionResult Edit(int? id)
        {
            EmployeeView model;
            if (id.HasValue)
            {
                model = _employeesData.GetById(id.Value);
                if (ReferenceEquals(model, null))
                    return NotFound();// возвращаем результат 404 Not Found
            }
            else
            {
                model = new EmployeeView();
            }
            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        [Authorize(Roles = Constants.Roles.Administrator)]
        public IActionResult Edit(EmployeeView model)
        {
            if (model.Age < 18 && model.Age > 75)
            {
                ModelState.AddModelError("Age", "Ошибка возраста!");
            }

            // Проверяем модель на валидность
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    var dbItem = _employeesData.GetById(model.Id);
                    if (ReferenceEquals(dbItem, null))
                        return NotFound();// возвращаем результат 404 Not Found
                    dbItem.FirstName = model.FirstName;
                    dbItem.SurName = model.SurName;
                    dbItem.Age = model.Age;
                    dbItem.Patronymic = model.Patronymic;
                    dbItem.Position = dbItem.Position;
                }
                else
                {
                    _employeesData.AddNew(model);
                }
                _employeesData.Commit();
                return RedirectToAction(nameof(Index));
            }
            // Если не валидна, возвращаем её на представление
            return View(model);
        }


        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        [Route("delete/{id}")]
        [Authorize(Roles = Constants.Roles.Administrator)]
        public IActionResult Delete(int id)
        {
            _employeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}