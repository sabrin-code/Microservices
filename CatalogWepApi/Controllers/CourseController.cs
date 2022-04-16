using CatalogWepApi.Dtos;
using CatalogWepApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices _courseServices;
        public CourseController(ICourseServices courseServices)
        {
            _courseServices=courseServices;
        }
        [HttpGet("GetAllAsync")]
        public async Task<ResponseApi<List<CourseDto>>> GetAllAsync()
        {
            return await _courseServices.GetAllAsync();
        }
        [HttpGet("GetCourseByIdAsync")]
        public async Task<ResponseApi<CourseDto>> GetCourseByIdAsync(string id)
        {
            return await _courseServices.GetCourseByIdAsync(id);
        }
        [HttpGet("GetCourseByUserIdAsync")]
        public async Task<ResponseApi<List<CourseDto>>> GetCourseByUserIdAsync(string id)
        {
            return await _courseServices.GetCourseByUserIdAsync(id);
        }
        [HttpPost("CreateCourseAsync")]
        public async Task<ResponseApi<CourseDto>> CreateCourseAsync(CourseCreateDto courseCreateDto)
        {
            return await _courseServices.CreateCourseAsync(courseCreateDto);
        }
        [HttpPost("UpdateCOurseAsync")]
        public async Task<ResponseApi<CourseDto>> UpdateCOurseAsync(UpdateCourseDto updateCourseDto)
        {
            return await _courseServices.UpdateCOurseAsync(updateCourseDto);
        }
        [HttpDelete(" DeleteCourseAsync")]
        public async Task<ResponseApi<CourseDto>> DeleteCourseAsync(string id)
        {
            return await _courseServices.DeleteCourseAsync(id);
        }
    }
}
