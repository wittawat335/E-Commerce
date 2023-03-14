using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_CommerceAPI.Entities;
using AutoMapper;
using E_CommerceAPI.Services.Contract;
using E_CommerceAPI.Services.Implementation;
using E_CommerceAPI.Utilities;
using E_CommerceAPI.ViewModels;
using E_CommerceAPI.Common;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly string Date;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IConfiguration configuration, IMapper mapper, IDepartmentService departmentService)
        {
            _configuration = configuration;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var _response = new ReponseApi<List<DepartmentViewModel>>();
            try
            {
                var model = await _departmentService.GetList();
                if (model.Count > 0)
                {
                    var list = _mapper.Map<List<DepartmentViewModel>>(model);
                    _response = new ReponseApi<List<DepartmentViewModel>>
                    {
                        Status = Constants.Status.True,
                        StatusMessage = Constants.StatusMessage.Success,
                        Value = list
                    };
                }
                else
                {
                    _response = new ReponseApi<List<DepartmentViewModel>>
                    {
                        Status = Constants.Status.False,
                        StatusMessage = Constants.StatusMessage.No_Data
                    };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ReponseApi<List<DepartmentViewModel>> { Status = Constants.Status.False, StatusMessage = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var _response = new ReponseApi<DepartmentViewModel>();
            try
            {
                var model = await _departmentService.GetDepartmentById(id);
                if (model !=  null)
                {
                    var list = _mapper.Map<DepartmentViewModel>(model);
                    _response = new ReponseApi<DepartmentViewModel>
                    {
                        Status = Constants.Status.True,
                        StatusMessage = Constants.StatusMessage.Success,
                        Value = list
                    };
                }
                else
                {
                    _response = new ReponseApi<DepartmentViewModel>
                    {
                        Status = Constants.Status.False,
                        StatusMessage = Constants.StatusMessage.No_Data
                    };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ReponseApi<DepartmentViewModel> { Status = Constants.Status.False, StatusMessage = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        //// PUT: api/Departments/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDepartment(int id, Department department)
        //{
        //    if (id != department.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(department).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DepartmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Departments
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Department>> PostDepartment(Department department)
        //{
        //  if (_context.Departments == null)
        //  {
        //      return Problem("Entity set 'EcommerceContext.Departments'  is null.");
        //  }
        //    _context.Departments.Add(department);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        //}

        //// DELETE: api/Departments/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDepartment(int id)
        //{
        //    if (_context.Departments == null)
        //    {
        //        return NotFound();
        //    }
        //    var department = await _context.Departments.FindAsync(id);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Departments.Remove(department);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DepartmentExists(int id)
        //{
        //    return (_context.Departments?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
