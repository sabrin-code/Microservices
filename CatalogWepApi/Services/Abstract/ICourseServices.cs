using CatalogWepApi.Dtos;
using Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogWepApi.Services.Abstract
{
    public interface ICourseServices
    {
        Task<ResponseApi<List<CourseDto>>> GetAllAsync();
        Task<ResponseApi<CourseDto>> GetCourseByIdAsync(string id);
        Task<ResponseApi<List<CourseDto>>> GetCourseByUserIdAsync(string id);
        Task<ResponseApi<CourseDto>> CreateCourseAsync(CourseCreateDto courseCreateDto);
        Task<ResponseApi<CourseDto>> UpdateCOurseAsync(UpdateCourseDto updateCourseDto);
        Task<ResponseApi<CourseDto>> DeleteCourseAsync(string id);
    }
}
