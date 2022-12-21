using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.DataTransfer.Department;
using StaffManagement.DataTransfer.Mapper;
using StaffManagement.DataTransfer.Staff;
using StaffManagement.Model;
using StaffManagement.Web.Data.Services;
using StaffManagement.Web.Errors;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StaffManagement.Web.Controllers
{
    [Authorize]
    public class DepartmentController : BaseController
    {
        private readonly IMapper<Department, DepartmentResponse> _mapper;
        private readonly IDataService<Department> _services;
        public DepartmentController(IMapper<Department, DepartmentResponse> mapper, IDataService<Department> services)
        {
            _mapper = mapper;
            _services = services;
        }

        public async Task<IActionResult> GetPaginatedData(int skip = 0, int take = 10, string query = "")
        {

            var departments = await _services.GetAllAsync(skip, take, query);
            int total = (string.IsNullOrEmpty(query)) ? await _services.CountAsync()
                : await _services.CountAsync(query);

            var responses = _mapper.MapModelToResponse(departments,
                skip, take, total, query);
            return Ok(responses);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Department department = await _services.GetAsync(id);
                var response = _mapper.MapModelToResponse(department);
                return View(response);
            }
            catch (NotFoundException fex)
            {
                return NotFound();
            }
            catch (InvalidProcessException pex)
            {
                return Problem();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                Department department = await _services.GetAsync(id);
                var response = _mapper.MapModelToResponse(department);
                return View(response);
            }
            catch (NotFoundException fex)
            {
                return NotFound();
            }
            catch (InvalidProcessException pex)
            {
                return Problem();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(int id, DepartmentUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Department department = _mapper.MapRequestToModel(request);
                    await _services.UpdateAsync(id, department);
                    // redirect to index
                    return RedirectToAction(nameof(Index));

                }
                catch (NotFoundException fex)
                {
                    return NotFound();
                }
                catch (InvalidProcessException pex)
                {
                    return Problem();
                }
            }
            else
            {
                return Conflict(ModelState);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                Department department = _mapper.MapRequestToModel(request);
                await _services.CreateAsync(department);
                //redirect to index
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Conflict(ModelState);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _services.DeleteAsync(id);
                //redirect to index
                return RedirectToAction(nameof(Index));

            }
            catch (NotFoundException fex)
            {
                return NotFound();
            }
            catch (InvalidProcessException pex)
            {
                return Problem();
            }
        }
    }
}
