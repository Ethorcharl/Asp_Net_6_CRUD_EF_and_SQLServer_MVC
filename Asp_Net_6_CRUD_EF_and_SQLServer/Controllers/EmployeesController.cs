using Asp_Net_6_CRUD_EF_and_SQLServer.Data;
using Asp_Net_6_CRUD_EF_and_SQLServer.Models;
using Asp_Net_6_CRUD_EF_and_SQLServer.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp_Net_6_CRUD_EF_and_SQLServer.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly MVCDbContext mvcDbContext;

        public EmployeesController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var employees = await mvcDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(); // right click and add view
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest) {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
            };
            await mvcDbContext.Employees.AddAsync(employee);
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) {

            var employee = await mvcDbContext.Employees.FirstOrDefaultAsync(x=> x.Id == id);
            if (employee != null) 
            {
                var viewModel = new UpdateEmployeeViewModel()
                {

                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DateOfBirth = employee.DateOfBirth,
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");    
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateEmployeeViewModel model) {
            var employee = await mvcDbContext.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                employee.Name= model.Name;
                employee.Email= model.Email;
                employee.Salary= model.Salary;
                employee.DateOfBirth= model.DateOfBirth;
                employee.Department= model.Department;

                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");       
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model) {
            var employee = await mvcDbContext.Employees.FindAsync(model.Id);
            if(employee != null)
            {
                mvcDbContext.Employees.Remove(employee);
                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
