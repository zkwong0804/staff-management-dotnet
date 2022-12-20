using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.DataTransfer.Mapper;
using StaffManagement.DataTransfer.Staff;
using StaffManagement.Model;
using StaffManagement.Web.Data.Services;
using StaffManagement.Web.Errors;
using System.Linq;

namespace StaffManagement.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IMapper<Staff, StaffResponse> _mapper;
        private readonly IDataService<Staff> _services;
        public StaffController(IMapper<Staff, StaffResponse> mapper, IDataService<Staff> services)
        {
            _mapper= mapper;
            _services = services;
        }

        public async Task<IActionResult> GetPaginatedData(int skip = 0, int take = 10, string query = "")
        {
            var staffs = await _services.GetAllAsync(skip, take, query);
            int total = (string.IsNullOrEmpty(query)) ? await _services.CountAsync()
                : await _services.CountAsync(query);

            var responses = _mapper.MapModelToResponse(staffs,
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
                Staff staff = await _services.GetAsync(id);
                var response = _mapper.MapModelToResponse(staff);
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
                Staff staff = await _services.GetAsync(id);
                var response = _mapper.MapModelToResponse(staff);
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
        public async Task<IActionResult> Update(int id, StaffUpdateRequest request)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    Staff staff = _mapper.MapRequestToModel(request);
                    await _services.UpdateAsync(id, staff);
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
            } else
            {
                return Conflict();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(StaffCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                Staff staff = _mapper.MapRequestToModel(request);
                await _services.CreateAsync(staff);
                //redirect to index
                return RedirectToAction(nameof(Index));
            } else
            {
                return Conflict();
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
