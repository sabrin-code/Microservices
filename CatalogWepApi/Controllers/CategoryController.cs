using CatalogWepApi.Dtos;
using CatalogWepApi.Models;
using CatalogWepApi.Services;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }
        [HttpGet("GetAllAsync")]
        public async Task<ResponseApi<List<CategoryDto>>> GetAllAsync()
        {
            return await _categoryService.GetAllAsync();
                 
        }
        [HttpGet("GetCategoryById")]
        public async Task<ResponseApi<CategoryDto>> GetCategoryById(string id)
        {
            return await _categoryService.GetCategoryById(id);
        }
        [HttpPost("CreateCategoryAsync")]
        public async Task<ResponseApi<CategoryDto>> CreateCategoryAsync(Category category)
        {
            return await _categoryService.CreateCategoryAsync(category);
        }
    }
}
